# Walmart APIs

[![Built with APIMatic][apimatic-badge]][apimatic-url] [![License: MIT][license-badge]][license-url]

The Walmart APIs SDK for .NET provides access to the Walmart APIs REST APIs from .NET applications.

> [!TIP]
> **Looking for a specific signature, model, enum, or error type?** This SDK ships a generated,
> machine-readable **[SDK map](sdk-map.md)** — a lookup index of the SDK's entire C# surface. Consult it
> **before** grepping or scanning the source tree; it answers most contract questions directly and,
> when a source file is genuinely needed, names the exact one to open. Details under [SDK map](#sdk-map).

OAuth token issuance for Walmart Marketplace, covering **both** v4 authorization
flows in one contract:

1. **Seller-direct** (`client_credentials`) — a seller's own application exchanges
   its client credentials for a short-lived access token, then calls the v4 APIs
   with `Authorization: Bearer <token>`.
2. **Solution-Provider delegated** (`authorization_code` + PKCE, `refresh_token`,
   and Dynamic Client Registration) — a seller grants a Solution Provider's
   application access to their Marketplace account.

Both flows are served by `the Authorization API` as a **stateless proxy** to
Walmart IAM : IAM remains the sole issuer; no secrets are stored and no
tokens are signed here. Access tokens are opaque, `Bearer`-type, short-lived;
refresh tokens (delegated flow) are rotated on use. Never log tokens.

## One token endpoint, grant dispatch
`POST /auth/v4/token` handles all three grants (`client_credentials`,
`authorization_code`, `refresh_token`) via `grant_type` dispatch — the merged v4
contract ( for seller-direct, for delegated). This is why the two
formerly separate specs (`openapi.yaml` + `delegated-oauth.yaml`) are now a single
document: a path can carry exactly one `post:`, so one file makes the shared
endpoint unambiguous for codegen and for the implementing controller.

## Posture
- **Seller-direct is OAuth 2.0** : documents what IAM/Apigee already do.
  IAM cannot add new auth features for this flow, so `client_credentials` issues
  **no** refresh token, `scope=` is accepted-but-ignored (no down-scoping), and
  introspection (RFC 7662) / revocation (RFC 7009) / discovery (RFC 8414) are
  **deliberately absent**.
- **Delegated is OAuth 2.1** : IAM already supports PKCE (`S256`), refresh
  rotation (~1-year TTL via `offline_access`), and Dynamic Client Registration
  (RFC 7591), so this flow specifies them properly.

The one modernization over `/v3` shared by both flows is the **access-token
header**: v4 uses the standard `Authorization: Bearer` and **does not use
`WM_SEC.ACCESS_TOKEN`** (the gateway already tolerates Bearer).

## Delegated-flow upstream gaps (, pending)
`GET /auth/v4/authorize` documents the OAuth-2.1-correct target. Three of its
guarantees depend on upstream changes that are **not yet in place**: `iss`
emission (RFC 9207), exact `redirect_uri` enforcement, and server-side PKCE `S256`
enforcement (rejecting `plain`) are IAM / app-store responsibilities tracked in
. the Authorization API validates the request-side invariants it can and
redirects correctly; the full end-to-end guarantee lands when IAM + app-store ship
those changes.

**Pod Owner:** Pod 0 — Core & Auth
**Implementation target:** the Authorization API (proxy) → Walmart IAM
, Retrieve catalog and product information from the Walmart Marketplace catalog.


**Pod Owner:** Pod 1 — Items & Catalog
**Implementation target:** Partner Item Query Service (PIQS), Submit analytics queries and retrieve structured data from Walmart's
data platform. Modeled after Walmart Seller API Data Kiosk API.

ADR pending: GraphQL vs REST query language — see docs/adr/ once filed.
Until the ADR resolves, the query body is treated as an opaque string.

**Pod Owner:** Pod 4 — Feeds & Reports
**Implementation target:** Walmart Analytics / Data Platform, Submit bulk data to Walmart Marketplace via asynchronous feed processing.
Sellers submit a feed file in a single API call; the server handles
document storage and initiates async processing. Poll feed status
with the feedId returned in the submission response.

**Pod Owner:** Pod 4 — Feeds & Reports
**Implementation target:** Walmart Feed Service / Bulk Operations

<!-- hello: Atul Soman (@a0s1r2d) joined Pod 4 — 2026-06-04 -->
<!-- hello: Ramprabhu Murugesan (@rmurug3) joined Pod 4 as lead — 2026-06-04 -->, WFS Inbound Plans API. Walmart Seller API — Fulfillment Inbound contract.
Terminology: WFS = Walmart Fulfillment Services, Ship Node = fulfillment center., WFS Inbound Delivery Windows, Self-Ship Appointments & Operation Status API. Walmart Seller API — Fulfillment Inbound contract.
Terminology: WFS = Walmart Fulfillment Services, Ship Node = fulfillment center., WFS Inbound Packing. Walmart Seller API — Fulfillment Inbound contract.
Terminology: WFS = Walmart Fulfillment Services, Ship Node = fulfillment center., WFS Inbound Packing & Placement API. Walmart Seller API — Fulfillment Inbound contract.
Terminology: WFS = Walmart Fulfillment Services, Ship Node = fulfillment center., WFS Inbound Items, Compliance, Labels & Prep API. Walmart Seller API — Fulfillment Inbound contract.
Terminology: WFS = Walmart Fulfillment Services, Ship Node = fulfillment center., WFS Inbound Shipments API. Walmart Seller API — Fulfillment Inbound contract.
Terminology: WFS = Walmart Fulfillment Services, Ship Node = fulfillment center., Create and manage WFS (Walmart Fulfillment Services) outbound fulfillment orders.
Sellers ship inventory to Walmart ship nodes; Walmart picks, packs, and ships
to end customers.


**Pod Owner:** Pod 2 — Orders & Fulfillment
**Implementation target:** WFS Outbound / Ship Node Service, Manage seller inventory on the Walmart Marketplace.


**Pod Owner:** Pod 3 — Inventory & Pricing
**Implementation target:** Walmart Inventory Service, Create, fully update, patch, and delete listings items for sellers on the
Walmart Marketplace. Modeled after Walmart Seller API Listings Items API.

**Pod Owner:** Pod 1 — Items & Catalog
**Implementation target:** Walmart Item Setup Service, Get information about listing restrictions on items in the Walmart Marketplace.
Identifies compliance blocks, category restrictions, and approval requirements.


**Pod Owner:** Pod 3 — Inventory & Pricing
**Implementation target:** Walmart Item Compliance / Restriction Service, SUPERSEDED — NOT SCHEDULED FOR IMPLEMENTATION.
the Merchant Fulfillment API is obsolete: its operations are covered by
the Shipping API, and both front the same upstream (Ship With Walmart).
Per Suresh's SWW-consolidation analysis, every operation below is marked
counts toward Pod 2 implementation scope. This spec is retained for
reference only (tombstone) — no code is being built against it. New
seller-fulfilled shipping work goes to the Shipping API.

Tracking: (this deprecation). The one partial-coverage gap
(MFN full-record `getShipment` has no single the Shipping API equivalent)
is owned by Suresh for decision in .

---
Get eligible shipping services and purchase shipping labels for seller-fulfilled
orders. Modeled after Walmart Seller API Merchant Fulfillment API.

**Pod Owner:** Pod 2 — Orders & Fulfillment
**Implementation target:** Ship With Walmart (SWW) — SWW-LABEL-SERVICE
(internal `/v3/sww/labels/*` synchronous REST; see
docs/mapper/mfn-mapper-feasibility.md), Retrieve and manage Walmart Marketplace orders.


**Pod Owner:** Pod 2 — Orders & Fulfillment
**Implementation target:** Walmart Order Management Service (OMS)
<!-- hello: Vikram Godbole (@vgodbol) joined Pod 2 — 2026-06-03 -->
<!-- hello: Suresh Dussa (@s0d08o6) joined Pod 2 — 2026-06-08 -->
<!-- hello: Leon Jiang (@r0j09pq) joined Pod 2 — 2026-08-10 -->
<!-- hello: Rashmi Das (@r0d01sm) joined Pod 2 — 2026-08-18 -->, Unified Payments domain API for Walmart Marketplace sellers.
Consolidates Pod 5 (Finances / financial event reporting) and Pod 6
(Outbound Payments — settlement, reconciliation, payout execution) into a
single service under the Payments domain .

**Category A (7 routes):** Reporting — delegated to mp-payment-reporting upstream.
**Category B (9 routes):** Execution — delegated to GMPPayments upstream.
**Finances (4 routes):** Financial event reporting — delegated to GMP partnerTxnSearch
and commission endpoints (, ).

Routes with x-walmart-pii: true contain order/seller PII and require an RDT
issued by the Tokens service (Pod 0, ) in production.

**Domain Owner:** Payments Domain (consolidated Pod 5 + Pod 6)
**Tech Lead:** @cssehga
**Replaces:** the payments settlement backend (v3 BFF); the Payments API (Pod 5), Pricing information for seller items and competitive pricing summaries.
Aligned to SP-API productPricingV0 surface (April 2026 release), with
Walmart Item ID substituted for ASIN as the primary item identifier .

Three GET endpoints are backed by IQS / GCI catalog_index .
Five batch/item endpoints are Phase 1 stubs pending implementation —
through .

**Pod Owner:** Pod 3 — Inventory & Pricing
**Implementation target:** Walmart Price Service / Competitive Intelligence, Fee estimate endpoints for seller items.
Aligned to SP-API productFeesV0 surface, with Walmart Item ID substituted
for ASIN as the primary item identifier , and Amazon-specific
branding replaced with Walmart equivalents.

All three endpoints are Phase 2 implementations backed by:
- IQS catalog_index — item enrichment (category, weight, dims, GTIN)
- Partner Rate Service (Columbus) — referral fee by category
- WFS Fulfillment Fee Service (payment-app.wfs) — WFS pick-and-pack fees

**Pod Owner:** Pod 3 — Inventory & Pricing, Retrieve Walmart product type definitions, attribute schemas, and
item classification rules used when setting up seller listings.

**Pod Owner:** Pod 1 — Items & Catalog
**Implementation target:** Walmart Item Classification Service, Create, cancel, and retrieve seller reports.
Supports scheduled and on-demand reports with async processing.


**Pod Owner:** Pod 4 — Feeds & Reports
**Implementation target:** Walmart Seller Reporting Service, Retrieve information about a seller's Walmart Marketplace account
and marketplace participations.


**Pod Owner:** Pod 5 — Seller & Finances
**Implementation target:** Walmart Seller Account Service / Seller Center, Shipping API for sellers to request rates, purchase shipping labels,
track shipments, and manage delivery exceptions across Walmart
Marketplace and WFS channels.

Surface aligned with industry SP-API Shipping v2. Pod 2 — Orders &
Fulfillment owns this service. Common types (Address, Money, Weight,
PackageDimensions) are inlined per Pod 2 convention, byte-identical to
the canonical copies in the Merchant Fulfillment API; (proposed)
defines the future promotion path to models/_shared/ once the Rule of
Three triggers a coordinated extraction PR., Create upload destinations (pre-signed URLs) for feed documents and
retrieve previously uploaded documents. Used in conjunction with the
Feeds service for async bulk operations.


Pre-signed URLs must not appear in logs — treat as secrets.

**Pod Owner:** Pod 4 — Feeds & Reports
**Implementation target:** Walmart Document Store / S3 pre-signed URLs

---

## Installation

Add the .NET SDK to your project from NuGet:

```bash
dotnet add package Apimaticwmv4SDK
```

---

## Quick Start

### Dependency Injection

Register the client with `IServiceCollection` and resolve it from the container. The `HttpClient` is managed by `IHttpClientFactory`. Configure the client's behavior through [WalmartApIsClientOptions](WalmartApIsClientOptions.cs).

```csharp
services.AddWalmartApIsClient(options =>
    {
        options.BasicClientAuth =
            new BasicAuthCredentials
            {
                Username = "YOUR_USERNAME",
                Password = "YOUR_PASSWORD",
            };
        options.SellerAuthClientCredentials =
            new OAuth2ClientCredentials
            {
                ClientId = "YOUR_CLIENT_ID",
                ClientSecret = "YOUR_CLIENT_SECRET",
            };
        options.WalletAuth =
            new OAuth2ClientCredentials
            {
                ClientId = "YOUR_CLIENT_ID",
                ClientSecret = "YOUR_CLIENT_SECRET",
            };
        options.SellerAuthAuthorizationCode =
            new OAuth2AuthorizationCodeCredentials
            {
                ClientId = "YOUR_CLIENT_ID",
                RedirectUri = "YOUR_REDIRECT_URI",
                PromptForAuthorizationCode = (authUrl, ct) => Task.FromResult(""),
            };
        options.Environment = ServerEnvironment.Production;
        // TODO: configure more client options here
    });
```

### Direct Instantiation

Create the client by passing an `HttpClient` you manage yourself. Configure the client's behavior through [WalmartApIsClientOptions](WalmartApIsClientOptions.cs).

```csharp
var httpClient = new HttpClient();
// TODO: configure more client options here
var options =
    new WalmartApIsClientOptions
    {
        BasicClientAuth = new BasicAuthCredentials
        {
            Username = "YOUR_USERNAME",
            Password = "YOUR_PASSWORD",
        },
        SellerAuthClientCredentials = new OAuth2ClientCredentials
        {
            ClientId = "YOUR_CLIENT_ID",
            ClientSecret = "YOUR_CLIENT_SECRET",
        },
        WalletAuth = new OAuth2ClientCredentials
        {
            ClientId = "YOUR_CLIENT_ID",
            ClientSecret = "YOUR_CLIENT_SECRET",
        },
        SellerAuthAuthorizationCode = new OAuth2AuthorizationCodeCredentials
        {
            ClientId = "YOUR_CLIENT_ID",
            RedirectUri = "YOUR_REDIRECT_URI",
            PromptForAuthorizationCode = (authUrl, ct) => Task.FromResult(""),
        },
        Environment = ServerEnvironment.Production,
    };
var client = new WalmartApIsClient(httpClient, options);
```

---

## Usage

For code examples and error responses, see [API Reference](api-reference.md).

## SDK map

This SDK ships a generated **SDK map** — [`sdk-map.md`](sdk-map.md) plus the [`map/`](map/) pages — a deterministic, lookup-oriented table of contents of the SDK's C# surface, generated by APIMatic alongside this SDK.

**Read it before scanning the source.** Whether you are an AI coding assistant or searching by hand, the map answers "what is the exact …" by lookup for every call-level contract, and for anything it does not carry it names the one file that does — so you never have to search the source tree:

- **[`sdk-map.md`](sdk-map.md)** — the index: client construction, servers/auth, the options/retry reference, the SDK-wide defaults the operation rows rely on, and link tables into [`map/`](map/).
- **[`map/operations/`](map/operations/)** — one page per controller: the exact C# signature, the return type, the error type with its typed `TryGet…` accessors, and pagination — plus, per operation, a **Type sources** table naming the file that declares every type that operation mentions.

Model shapes — record fields with their JSON wire names, enum member names and wire values, `OneOf`/`AnyOf` union variants — are **not** duplicated in the map. Take the path from the operation's Type sources table and read the declaring file; it is the single source of truth and cannot go stale against the code.

**Each operation row states what is specific to that operation.** The SDK-wide defaults are stated once in [`sdk-map.md`](sdk-map.md) — throw-only (no `Result`-style no-throw variants), no pagination, the four fixed `RawError` accessors, the `Default` server group — and a row appears only where its operation departs from one. A row silent on pagination is telling you that operation has none.

The **HTTP verb and route**, and the endpoint's **behavioural prose**, live on the operation itself, in the source file named at the top of its operations page. Read them there when something needs them — wiring a mock, reading a provider log, or settling a rule about what you must pass.

**Workflow:** look the fact up in the map → where the map leaves something ambiguous, open the **one** source file the row names → the compiler is the backstop (a name that isn't in the map won't build). Don't scan or grep the tree to find things — the map is the locator.

### Which one to reach for

The map and the [API Reference](api-reference.md) answer different questions, and the map is generated from this SDK's source so it stays in lockstep with the code it describes.

| Use | For |
| --- | --- |
| **[`sdk-map.md`](sdk-map.md) + [`map/`](map/)** | Traversing the SDK and working out its surface — locating the operation you need (this SDK exposes **174 operations**), its exact signature and parameter order, the shape and JSON wire names of the models it takes and returns, which error type it throws and how to read it, and the source file behind any of it. This is the index to consume the SDK from, and the one to reach for first. |
| **[`api-reference.md`](api-reference.md)** | Usage guidance for a single operation once you know which one you want — a runnable code sample, per-parameter descriptions, and the error responses it can return. |

## Best Practices

> [!TIP]
> Use a **single `WalmartApIsClient` instance** for the lifetime of your application and
> reuse it across all requests. Creating a new instance per request might exhaust the
> connection pool.

## License

This SDK is distributed under the [MIT License](LICENSE).

---

## Support

Refer to the [API reference](api-reference.md) for detailed information on available operations with code samples.

For further assistance, please contact support at pod-0@sellers.walmart.com.

---

[license-url]: LICENSE
[license-badge]: https://img.shields.io/badge/License-MIT-blue.svg
[apimatic-url]: https://www.apimatic.io
[apimatic-badge]: https://www.apimatic.io/hubfs/Built-with-APIMatic-badge.svg
