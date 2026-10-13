using System.Net.Http;
using WalmartApIs.Api;
using WalmartApIs.Core;
using WalmartApIs.Core.Logging;
using WalmartApIs.Core.Models;

namespace WalmartApIs;

/// <summary>
/// OAuth token issuance for Walmart Marketplace, covering <b>both</b> v4 authorization
/// flows in one contract:
/// <para>
/// 1. <b>Seller-direct</b> (<c>client_credentials</c>) — a seller's own application exchanges
///    its client credentials for a short-lived access token, then calls the v4 APIs
///    with <c>Authorization: Bearer &lt;token&gt;</c>.
/// 2. <b>Solution-Provider delegated</b> (<c>authorization_code</c> + PKCE, <c>refresh_token</c>,
///    and Dynamic Client Registration) — a seller grants a Solution Provider's
///    application access to their Marketplace account.
/// </para>
/// <para>
/// Both flows are served by <c>the Authorization API</c> as a <b>stateless proxy</b> to
/// Walmart IAM : IAM remains the sole issuer; no secrets are stored and no
/// tokens are signed here. Access tokens are opaque, <c>Bearer</c>-type, short-lived;
/// refresh tokens (delegated flow) are rotated on use. Never log tokens.
/// </para>
/// <para>
/// ## One token endpoint, grant dispatch
/// <c>POST /auth/v4/token</c> handles all three grants (<c>client_credentials</c>,
/// <c>authorization_code</c>, <c>refresh_token</c>) via <c>grant_type</c> dispatch — the merged v4
/// contract ( for seller-direct, for delegated). This is why the two
/// formerly separate specs (<c>openapi.yaml</c> + <c>delegated-oauth.yaml</c>) are now a single
/// document: a path can carry exactly one <c>post:</c>, so one file makes the shared
/// endpoint unambiguous for codegen and for the implementing controller.
/// </para>
/// <para>
/// ## Posture
/// - <b>Seller-direct is OAuth 2.0</b> : documents what IAM/Apigee already do.
///   IAM cannot add new auth features for this flow, so <c>client_credentials</c> issues
///   <b>no</b> refresh token, <c>scope=</c> is accepted-but-ignored (no down-scoping), and
///   introspection (RFC 7662) / revocation (RFC 7009) / discovery (RFC 8414) are
///   <b>deliberately absent</b>.
/// - <b>Delegated is OAuth 2.1</b> : IAM already supports PKCE (<c>S256</c>), refresh
///   rotation (~1-year TTL via <c>offline_access</c>), and Dynamic Client Registration
///   (RFC 7591), so this flow specifies them properly.
/// </para>
/// <para>
/// The one modernization over <c>/v3</c> shared by both flows is the **access-token
/// header<b>: v4 uses the standard <c>Authorization: Bearer</c> and </b>does not use
/// <c>WM_SEC.ACCESS_TOKEN</c>** (the gateway already tolerates Bearer).
/// </para>
/// <para>
/// ## Delegated-flow upstream gaps (, pending)
/// <c>GET /auth/v4/authorize</c> documents the OAuth-2.1-correct target. Three of its
/// guarantees depend on upstream changes that are <b>not yet in place</b>: <c>iss</c>
/// emission (RFC 9207), exact <c>redirect_uri</c> enforcement, and server-side PKCE <c>S256</c>
/// enforcement (rejecting <c>plain</c>) are IAM / app-store responsibilities tracked in
/// . the Authorization API validates the request-side invariants it can and
/// redirects correctly; the full end-to-end guarantee lands when IAM + app-store ship
/// those changes.
/// </para>
/// <para>
/// <b>Pod Owner:</b> Pod 0 — Core &amp; Auth
/// <b>Implementation target:</b> the Authorization API (proxy) → Walmart IAM
/// , Retrieve catalog and product information from the Walmart Marketplace catalog.
/// </para>
/// <para>
///
/// <b>Pod Owner:</b> Pod 1 — Items &amp; Catalog
/// <b>Implementation target:</b> Partner Item Query Service (PIQS), Submit analytics queries and retrieve structured data from Walmart's
/// data platform. Modeled after Walmart Seller API Data Kiosk API.
/// </para>
/// <para>
/// ADR pending: GraphQL vs REST query language — see docs/adr/ once filed.
/// Until the ADR resolves, the query body is treated as an opaque string.
/// </para>
/// <para>
/// <b>Pod Owner:</b> Pod 4 — Feeds &amp; Reports
/// <b>Implementation target:</b> Walmart Analytics / Data Platform, Submit bulk data to Walmart Marketplace via asynchronous feed processing.
/// Sellers submit a feed file in a single API call; the server handles
/// document storage and initiates async processing. Poll feed status
/// with the feedId returned in the submission response.
/// </para>
/// <para>
/// <b>Pod Owner:</b> Pod 4 — Feeds &amp; Reports
/// <b>Implementation target:</b> Walmart Feed Service / Bulk Operations
/// </para>
/// <para>
/// &lt;!-- hello: Atul Soman (@a0s1r2d) joined Pod 4 — 2026-06-04 --&gt;
/// &lt;!-- hello: Ramprabhu Murugesan (@rmurug3) joined Pod 4 as lead — 2026-06-04 --&gt;, WFS Inbound Plans API. Walmart Seller API — Fulfillment Inbound contract.
/// Terminology: WFS = Walmart Fulfillment Services, Ship Node = fulfillment center., WFS Inbound Delivery Windows, Self-Ship Appointments &amp; Operation Status API. Walmart Seller API — Fulfillment Inbound contract.
/// Terminology: WFS = Walmart Fulfillment Services, Ship Node = fulfillment center., WFS Inbound Packing. Walmart Seller API — Fulfillment Inbound contract.
/// Terminology: WFS = Walmart Fulfillment Services, Ship Node = fulfillment center., WFS Inbound Packing &amp; Placement API. Walmart Seller API — Fulfillment Inbound contract.
/// Terminology: WFS = Walmart Fulfillment Services, Ship Node = fulfillment center., WFS Inbound Items, Compliance, Labels &amp; Prep API. Walmart Seller API — Fulfillment Inbound contract.
/// Terminology: WFS = Walmart Fulfillment Services, Ship Node = fulfillment center., WFS Inbound Shipments API. Walmart Seller API — Fulfillment Inbound contract.
/// Terminology: WFS = Walmart Fulfillment Services, Ship Node = fulfillment center., Create and manage WFS (Walmart Fulfillment Services) outbound fulfillment orders.
/// Sellers ship inventory to Walmart ship nodes; Walmart picks, packs, and ships
/// to end customers.
/// </para>
/// <para>
///
/// <b>Pod Owner:</b> Pod 2 — Orders &amp; Fulfillment
/// <b>Implementation target:</b> WFS Outbound / Ship Node Service, Manage seller inventory on the Walmart Marketplace.
/// </para>
/// <para>
///
/// <b>Pod Owner:</b> Pod 3 — Inventory &amp; Pricing
/// <b>Implementation target:</b> Walmart Inventory Service, Create, fully update, patch, and delete listings items for sellers on the
/// Walmart Marketplace. Modeled after Walmart Seller API Listings Items API.
/// </para>
/// <para>
/// <b>Pod Owner:</b> Pod 1 — Items &amp; Catalog
/// <b>Implementation target:</b> Walmart Item Setup Service, Get information about listing restrictions on items in the Walmart Marketplace.
/// Identifies compliance blocks, category restrictions, and approval requirements.
/// </para>
/// <para>
///
/// <b>Pod Owner:</b> Pod 3 — Inventory &amp; Pricing
/// <b>Implementation target:</b> Walmart Item Compliance / Restriction Service, SUPERSEDED — NOT SCHEDULED FOR IMPLEMENTATION.
/// the Merchant Fulfillment API is obsolete: its operations are covered by
/// the Shipping API, and both front the same upstream (Ship With Walmart).
/// Per Suresh's SWW-consolidation analysis, every operation below is marked
/// counts toward Pod 2 implementation scope. This spec is retained for
/// reference only (tombstone) — no code is being built against it. New
/// seller-fulfilled shipping work goes to the Shipping API.
/// </para>
/// <para>
/// Tracking: (this deprecation). The one partial-coverage gap
/// (MFN full-record <c>getShipment</c> has no single the Shipping API equivalent)
/// is owned by Suresh for decision in .
/// </para>
/// <para>
/// ---
/// Get eligible shipping services and purchase shipping labels for seller-fulfilled
/// orders. Modeled after Walmart Seller API Merchant Fulfillment API.
/// </para>
/// <para>
/// <b>Pod Owner:</b> Pod 2 — Orders &amp; Fulfillment
/// <b>Implementation target:</b> Ship With Walmart (SWW) — SWW-LABEL-SERVICE
/// (internal <c>/v3/sww/labels/*</c> synchronous REST; see
/// docs/mapper/mfn-mapper-feasibility.md), Retrieve and manage Walmart Marketplace orders.
/// </para>
/// <para>
///
/// <b>Pod Owner:</b> Pod 2 — Orders &amp; Fulfillment
/// <b>Implementation target:</b> Walmart Order Management Service (OMS)
/// &lt;!-- hello: Vikram Godbole (@vgodbol) joined Pod 2 — 2026-06-03 --&gt;
/// &lt;!-- hello: Suresh Dussa (@s0d08o6) joined Pod 2 — 2026-06-08 --&gt;
/// &lt;!-- hello: Leon Jiang (@r0j09pq) joined Pod 2 — 2026-08-10 --&gt;
/// &lt;!-- hello: Rashmi Das (@r0d01sm) joined Pod 2 — 2026-08-18 --&gt;, Unified Payments domain API for Walmart Marketplace sellers.
/// Consolidates Pod 5 (Finances / financial event reporting) and Pod 6
/// (Outbound Payments — settlement, reconciliation, payout execution) into a
/// single service under the Payments domain .
/// </para>
/// <para>
/// <b>Category A (7 routes):</b> Reporting — delegated to mp-payment-reporting upstream.
/// <b>Category B (9 routes):</b> Execution — delegated to GMPPayments upstream.
/// <b>Finances (4 routes):</b> Financial event reporting — delegated to GMP partnerTxnSearch
/// and commission endpoints (, ).
/// </para>
/// <para>
/// Routes with x-walmart-pii: true contain order/seller PII and require an RDT
/// issued by the Tokens service (Pod 0, ) in production.
/// </para>
/// <para>
/// <b>Domain Owner:</b> Payments Domain (consolidated Pod 5 + Pod 6)
/// <b>Tech Lead:</b> @cssehga
/// <b>Replaces:</b> the payments settlement backend (v3 BFF); the Payments API (Pod 5), Pricing information for seller items and competitive pricing summaries.
/// Aligned to SP-API productPricingV0 surface (April 2026 release), with
/// Walmart Item ID substituted for ASIN as the primary item identifier .
/// </para>
/// <para>
/// Three GET endpoints are backed by IQS / GCI catalog_index .
/// Five batch/item endpoints are Phase 1 stubs pending implementation —
/// through .
/// </para>
/// <para>
/// <b>Pod Owner:</b> Pod 3 — Inventory &amp; Pricing
/// <b>Implementation target:</b> Walmart Price Service / Competitive Intelligence, Fee estimate endpoints for seller items.
/// Aligned to SP-API productFeesV0 surface, with Walmart Item ID substituted
/// for ASIN as the primary item identifier , and Amazon-specific
/// branding replaced with Walmart equivalents.
/// </para>
/// <para>
/// All three endpoints are Phase 2 implementations backed by:
/// - IQS catalog_index — item enrichment (category, weight, dims, GTIN)
/// - Partner Rate Service (Columbus) — referral fee by category
/// - WFS Fulfillment Fee Service (payment-app.wfs) — WFS pick-and-pack fees
/// </para>
/// <para>
/// <b>Pod Owner:</b> Pod 3 — Inventory &amp; Pricing, Retrieve Walmart product type definitions, attribute schemas, and
/// item classification rules used when setting up seller listings.
/// </para>
/// <para>
/// <b>Pod Owner:</b> Pod 1 — Items &amp; Catalog
/// <b>Implementation target:</b> Walmart Item Classification Service, Create, cancel, and retrieve seller reports.
/// Supports scheduled and on-demand reports with async processing.
/// </para>
/// <para>
///
/// <b>Pod Owner:</b> Pod 4 — Feeds &amp; Reports
/// <b>Implementation target:</b> Walmart Seller Reporting Service, Retrieve information about a seller's Walmart Marketplace account
/// and marketplace participations.
/// </para>
/// <para>
///
/// <b>Pod Owner:</b> Pod 5 — Seller &amp; Finances
/// <b>Implementation target:</b> Walmart Seller Account Service / Seller Center, Shipping API for sellers to request rates, purchase shipping labels,
/// track shipments, and manage delivery exceptions across Walmart
/// Marketplace and WFS channels.
/// </para>
/// <para>
/// Surface aligned with industry SP-API Shipping v2. Pod 2 — Orders &amp;
/// Fulfillment owns this service. Common types (Address, Money, Weight,
/// PackageDimensions) are inlined per Pod 2 convention, byte-identical to
/// the canonical copies in the Merchant Fulfillment API; (proposed)
/// defines the future promotion path to models/_shared/ once the Rule of
/// Three triggers a coordinated extraction PR., Create upload destinations (pre-signed URLs) for feed documents and
/// retrieve previously uploaded documents. Used in conjunction with the
/// Feeds service for async bulk operations.
/// </para>
/// <para>
///
/// Pre-signed URLs must not appear in logs — treat as secrets.
/// </para>
/// <para>
/// <b>Pod Owner:</b> Pod 4 — Feeds &amp; Reports
/// <b>Implementation target:</b> Walmart Document Store / S3 pre-signed URLs
/// </para>
/// </summary>
public sealed class WalmartApIsClient
{
    private readonly RawClient _rawClient;
    private readonly Server _server;
    private readonly AuthSchemes _auth;

    public WalmartApIsClient(HttpClient httpClient, WalmartApIsClientOptions options)
    {
        _server = new Server(options.Environment, options.Server);
        var queryParameterFactory = new QueryParameterFactory([]);
        var templateParamsFactory = new TemplateParamsFactory([]);
        var urlFactory = new UriFactory(queryParameterFactory, templateParamsFactory);
        var httpStatusPolicy = new HttpStatusPolicy([]);
        var headersFactory = new HeadersFactory([
            new HeaderParam("User-Agent", "WalmartApIsClient/v4 CSharp"),
            new HeaderParam("X-APIMatic-Lang", "CSharp"),
            new HeaderParam("X-APIMatic-Package-Version", "v4"),
            new HeaderParam("X-APIMatic-Gen-Version", "4.0.0"),
            new HeaderParam("X-APIMatic-OS", RuntimeEnvironment.Os),
            new HeaderParam("X-APIMatic-Runtime", RuntimeEnvironment.Runtime),
        ]);
        var resiliencePipelineFactory = new ResiliencePipelineFactory(options.Retry, options.TimeProvider);
        var httpLogger = new HttpLogger(options.Logging, "WalmartApIsClient", options.TimeProvider);
        var responseContexts = new ResponseContextFactory(options.TimeProvider, options.StreamReadTimeout);
        _rawClient =
            new RawClient(
                httpClient,
                urlFactory,
                httpStatusPolicy,
                headersFactory,
                resiliencePipelineFactory,
                httpLogger,
                options.Hooks,
                responseContexts);
        _auth = new AuthSchemes(options, _server, _rawClient, urlFactory);
    }

    /// <summary>
    /// OAuth 2.0 / 2.1 token issuance, delegated consent, and client registration.
    /// </summary>
    public Authorization Authorization => field ??= new Authorization(_rawClient, _server, _auth);

    public Catalog Catalog => field ??= new Catalog(_rawClient, _server, _auth);

    public DataKiosk DataKiosk => field ??= new DataKiosk(_rawClient, _server, _auth);

    /// <summary>
    /// Dispute eligibility for payment issues.
    /// </summary>
    public Disputes Disputes => field ??= new Disputes(_rawClient, _server, _auth);

    public Feeds Feeds => field ??= new Feeds(_rawClient, _server, _auth);

    /// <summary>
    /// Final payout case management.
    /// </summary>
    public FinalPayout FinalPayout => field ??= new FinalPayout(_rawClient, _server, _auth);

    /// <summary>
    /// Financial event groups, financial events, and order-level financial events (consolidated from Pod 5).
    /// </summary>
    public Finances Finances => field ??= new Finances(_rawClient, _server, _auth);

    public FulfillmentOutbound FulfillmentOutbound => field ??= new FulfillmentOutbound(_rawClient, _server, _auth);

    public Inventory Inventory => field ??= new Inventory(_rawClient, _server, _auth);

    public ListingsItems ListingsItems => field ??= new ListingsItems(_rawClient, _server, _auth);

    public ListingsRestrictions ListingsRestrictions => field ??= new ListingsRestrictions(_rawClient, _server, _auth);

    public MerchantFulfillment MerchantFulfillment => field ??= new MerchantFulfillment(_rawClient, _server, _auth);

    public Orders Orders => field ??= new Orders(_rawClient, _server, _auth);

    /// <summary>
    /// Payout status, eligibility, and initiation.
    /// </summary>
    public Payouts Payouts => field ??= new Payouts(_rawClient, _server, _auth);

    public ProductTypeDefinitions ProductTypeDefinitions =>
        field ??= new ProductTypeDefinitions(_rawClient, _server, _auth);

    /// <summary>
    /// Reconciliation report availability and download.
    /// </summary>
    public Reconciliation Reconciliation => field ??= new Reconciliation(_rawClient, _server, _auth);

    public ReportSchedules ReportSchedules => field ??= new ReportSchedules(_rawClient, _server, _auth);

    /// <summary>
    /// Settlement summary report download (new and legacy formats).
    /// </summary>
    public Reports Reports => field ??= new Reports(_rawClient, _server, _auth);

    /// <summary>
    /// Seller account and marketplace participation information
    /// </summary>
    public Sellers Sellers => field ??= new Sellers(_rawClient, _server, _auth);

    /// <summary>
    /// Settlement periods and detailed transaction records.
    /// </summary>
    public Settlement Settlement => field ??= new Settlement(_rawClient, _server, _auth);

    public Uploads Uploads => field ??= new Uploads(_rawClient, _server, _auth);

    public WfsInventory WfsInventory => field ??= new WfsInventory(_rawClient, _server, _auth);

    public Messaging Messaging => field ??= new Messaging(_rawClient, _server, _auth);

    public Notifications Notifications => field ??= new Notifications(_rawClient, _server, _auth);

    /// <summary>
    /// Fee estimate operations for seller items
    /// </summary>
    public ProductFees ProductFees => field ??= new ProductFees(_rawClient, _server, _auth);

    /// <summary>
    /// Product pricing and competitive pricing operations
    /// </summary>
    public ProductPricing ProductPricing => field ??= new ProductPricing(_rawClient, _server, _auth);

    public Sales Sales => field ??= new Sales(_rawClient, _server, _auth);

    /// <summary>
    /// Rate quotes, label purchase, tracking, and delivery for seller shipments.
    /// </summary>
    public Shipping Shipping => field ??= new Shipping(_rawClient, _server, _auth);

    public Solicitations Solicitations => field ??= new Solicitations(_rawClient, _server, _auth);

    public WfsInbound WfsInbound => field ??= new WfsInbound(_rawClient, _server, _auth);
}
