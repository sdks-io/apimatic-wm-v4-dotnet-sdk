using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using WalmartApIs.Core;
using WalmartApIs.Core.Exceptions;
using WalmartApIs.Core.Models;
using WalmartApIs.Core.Request;
using WalmartApIs.Core.Response;
using WalmartApIs.Errors;
using WalmartApIs.Models;
using WalmartApIs.Requests.SemItemDiagnostics;

namespace WalmartApIs.Api;

public sealed class SemItemDiagnostics
{
    private readonly RawClient _rawClient;
    private readonly Server _server;
    private readonly AuthSchemes _auth;

    internal SemItemDiagnostics(RawClient rawClient, Server server, AuthSchemes auth)
    {
        _rawClient = rawClient;
        _server = server;
        _auth = auth;
    }

    /// <summary>
    /// Get issue types
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="IReadOnlyDictionary{TKey, TValue}"/> of <see cref="IssueMetadata"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="GetIssueTypesError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Returns the complete, authoritative metadata for all SEM eligibility issue types (~61 issue types, ~5KB).&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US only&lt;/b&gt;
    /// <para>
    /// Items used in Search Engine Marketing (SEM) campaigns such as Google Shopping Ads must meet specific content, quality, and policy requirements before they can be advertised on search engines. When items fail to meet these requirements, they are flagged with specific issue types that either <b>block</b> the item from being advertised entirely or <b>limit</b> its visibility and performance in SEM.
    /// </para>
    /// <para>
    /// This endpoint returns the complete catalog of all issue types that can affect an item's SEM eligibility, along with human-readable names, descriptions, remediation guidance, severity categories, and help links. It serves as the <b>single source of truth</b> for issue metadata.
    /// </para>
    /// <para>
    /// ### Current scope
    /// The issue types returned by this endpoint apply to items that are currently part of active SEM campaigns. The <c>POST /item-issues/search</c> endpoint uses these issue types to report diagnostics on campaign items.
    /// </para>
    /// <para>
    /// ### Future extensibility
    /// In a future release, the <c>POST /item-issues/search</c> endpoint will support querying diagnostic issues for any item in the seller's catalog — even items not yet added to a campaign — using the <c>itemId</c> filter. The same issue types returned by this endpoint will apply to those items as well, enabling sellers to proactively diagnose and fix issues before campaign onboarding.
    /// </para>
    /// <para>
    /// ### SEM eligibility issue categories
    /// Each issue type belongs to one of three categories that indicate its impact on an item's ability to be advertised on search engines:
    /// </para>
    /// <para>
    /// | Category     | Count | SEM Impact                                                                     |
    /// |--------------|-------|--------------------------------------------------------------------------------|
    /// | <c>BLOCKED</c>    | ~49   | Item <b>cannot be advertised</b> on search engines. Must be resolved before the item can appear in SEM ads. Examples: <c>ITEM_OUT_OF_STOCK</c>, <c>POLICY_VIOLATION</c>, <c>MISSING_INVALID_TITLE</c>, <c>INVALID_IMAGE</c>, <c>BUYBOX_NOT_WINNER</c> |
    /// | <c>LIMITED</c>    | ~11   | Item <b>can be advertised but with reduced visibility</b> or performance on search engines. Resolving these issues improves ad reach and effectiveness. Examples: <c>TITLE_TOO_LONG</c>, <c>LOW_IMAGE_QUALITY</c>, <c>DESCRIPTION_TOO_SHORT</c>, <c>LOW_OFFER_LISTING_QUALITY</c> |
    /// | <c>NO_ISSUES</c>  | ~1    | Informational statuses such as <c>DUPLICATE_OFFER</c> — item has no SEM eligibility issues |
    /// </para>
    /// <para>
    /// ### Actionable vs non-actionable issues
    /// Each issue type includes an <c>isFixable</c> flag that indicates whether the seller can resolve the issue:
    /// - <c>isFixable=true</c>: Seller can take action to restore or improve SEM eligibility (For example, restock inventory, update title, improve image quality). Partners should surface these with a "Fix Now" UI affordance.
    /// - <c>isFixable=false</c>: Requires Walmart or system intervention (For example, Google policy violations, BuyBox eligibility). Partners should display these as informational — the seller cannot directly resolve them.
    /// </para>
    /// <para>
    /// ### Response structure
    /// The response is a map keyed by <c>issueType</c> (string), where each value is an <c>IssueMetadata</c> object containing:
    /// - <c>issueName</c>: Human-readable short headline for UI display (For example, "Item Out of Stock")
    /// - <c>issueCategory</c>: SEM eligibility impact — <c>BLOCKED</c> (cannot advertise on search engines) or <c>LIMITED</c> (reduced SEM visibility)
    /// - <c>isFixable</c>: Whether the partner can remediate this issue to restore SEM eligibility
    /// - <c>issueDescription</c>: Human-readable description with specific remediation guidance (For example, "Item is out of stock. Add inventory to make the item available.")
    /// - <c>learnMoreUrl</c>: Help link to Walmart-hosted or Google support documentation for step-by-step remediation. May be null for some issue types.
    /// </para>
    /// <para>
    /// ### Recommended usage pattern
    /// 1. Call this endpoint <b>once</b> on application initialization
    /// 2. Cache the result locally (recommended <b>TTL: 24 hours</b>)
    /// 3. Use cached metadata to enrich items returned by the <c>POST /item-issues/search</c> endpoint — match each item's <c>issueType</c> to the cached metadata for display name, description, and help links
    /// 4. Use <c>isFixable</c> to drive UI affordances: show "Fix Now" buttons for fixable SEM issues, informational badges for non-fixable ones
    /// 5. Use <c>learnMoreUrl</c> to deep-link to help documentation for step-by-step remediation guidance
    /// 6. Use <c>issueCategory</c> to color-code or badge issues in your UI: red for <c>BLOCKED</c> (cannot advertise), yellow for <c>LIMITED</c> (reduced SEM performance)
    /// </para>
    /// </remarks>
    public Task<IReadOnlyDictionary<string, IssueMetadata>> GetIssueTypes(GetIssueTypesRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/v3/advertising/sem/item-issues/issue-types"),
            [],
            [],
            [
                new HeaderParam("WM_SEC.ACCESS_TOKEN", request.WmSecAccessToken),
                new HeaderParam("WM_SVC.NAME", request.WmSvcName),
                new HeaderParam("WM_QOS.CORRELATION_ID", request.WmQosCorrelationId),
                new HeaderParam("WM_GLOBAL_VERSION", request.WmGlobalVersion),
                new HeaderParam("WM_MARKET", request.WmMarket),
                new HeaderParam("WM_CONSUMER.CHANNEL.TYPE", request.WmConsumerChannelType),
            ],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<IReadOnlyDictionary<string, IssueMetadata>>(),
            GetIssueTypesError.Response,
            [_auth.AccessToken],
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Search item issues
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="ItemDiagnosticSearchResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="SearchItemIssuesError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Search for item-level diagnostic issues that block or limit items from being used in Search Engine Marketing (SEM). Returns paginated, item-level diagnostic details including campaign associations, issue types, severity, remediation guidance, and overall item status.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US only&lt;/b&gt;
    /// <para>
    /// Items in SEM campaigns must meet content, quality, and policy requirements before they can be advertised on search engines (For example, Google Shopping Ads). This endpoint surfaces the specific issues preventing or limiting an item's SEM eligibility, along with actionable remediation guidance so sellers can resolve problems and restore advertising reach.
    /// </para>
    /// <para>
    /// ### Current scope
    /// This endpoint currently returns diagnostics for <b>items that are part of active SEM campaigns</b> for the authenticated seller. Each item in the response includes its <c>campaignAssociations</c> — the list of campaigns the item belongs to. Items not associated with any campaign are not included in the results.
    /// </para>
    /// <para>
    /// ### Default behavior
    /// - When no request body is provided, defaults to <c>offset=0</c>, <c>limit=100</c> with no filters
    /// - When no <c>issueCategory</c> filter is provided, returns <b>only items with issues</b> (<c>BLOCKED</c> or <c>LIMITED</c>)
    /// - To include healthy items, explicitly pass <c>issueCategory</c> filter with <c>NO_ISSUES</c> or all three values
    /// - By default, the API prioritizes returning actionable diagnostic issues rather than healthy items. This reduces payload size and improves relevance
    /// </para>
    /// <para>
    /// ### Supported filters
    /// Filters are combined with AND logic. Multiple values within a single filter act as OR.
    /// </para>
    /// <para>
    /// | Filter Field    | Supported Values                          | Max Values | Description                                              |
    /// |-----------------|-------------------------------------------|------------|----------------------------------------------------------|
    /// | <c>issues</c>        | Any valid <c>issueType</c> enum value          | 100        | Filter by specific SEM issue types (For example, <c>ITEM_OUT_OF_STOCK</c>, <c>TITLE_TOO_LONG</c>, <c>POLICY_VIOLATION</c>) |
    /// | <c>issueCategory</c> | <c>LIMITED</c>, <c>BLOCKED</c>, <c>NO_ISSUES</c>         | 100        | Filter by SEM issue severity — <c>BLOCKED</c> items cannot be advertised at all, <c>LIMITED</c> items have reduced SEM performance |
    /// | <c>itemId</c>        | Numeric string item IDs                   | 100        | Filter by Walmart catalog item identifiers within the seller's active campaigns. *In a future release, this filter will also support items outside of campaigns.* |
    /// </para>
    /// <para>
    /// ### Response structure
    /// Each response contains two top-level fields:
    /// - <c>pagination</c>: Standard pagination metadata including <c>hasNextPage</c>/<c>hasPreviousPage</c> for convenient UI navigation
    /// - <c>data</c>: Array of item-level diagnostics. Each item appears <b>once</b> per unique <c>offerId</c> with all campaign associations listed. Each item includes an <c>issueCategory</c> field representing the overall SEM eligibility status of the item, and an <c>issues</c> array containing issue type identifiers. Issues are item-level, not campaign-specific — a blocked item is blocked in all SEM campaigns it belongs to.
    /// </para>
    /// <para>
    /// Issue metadata (name, description, fixability, help links) is not included in this response. Partners should use the dedicated <c>GET /item-issues/issue-types</c> endpoint to retrieve complete issue metadata and cache it locally (TTL: 24 hours).
    /// </para>
    /// <para>
    /// ### Issue categories
    /// | Category     | SEM Impact                                                                     |
    /// |--------------|--------------------------------------------------------------------------------|
    /// | <c>BLOCKED</c>    | Item <b>cannot be advertised</b> on search engines. Must be resolved before the item can appear in SEM ads. Examples: out of stock, missing title, policy violation, invalid image. |
    /// | <c>LIMITED</c>    | Item <b>can be advertised but with reduced visibility</b> or performance on search engines. Resolving these issues improves ad reach and effectiveness. Examples: title too long, low image quality, description too short. |
    /// | <c>NO_ISSUES</c>  | Item has no SEM issues and can be advertised normally with full visibility.      |
    /// </para>
    /// <para>
    /// ### Actionable vs non-actionable issues
    /// Each issue type has an <c>isFixable</c> flag available via the <c>GET /item-issues/issue-types</c> reference endpoint:
    /// - <c>isFixable=true</c>: Seller can fix the issue to restore SEM eligibility (For example, restock inventory, update title, fix image). Partners should surface these with a "Fix Now" UI affordance.
    /// - <c>isFixable=false</c>: Requires Walmart or system intervention (For example, Google policy violations). Partners should display these as informational — the seller cannot directly resolve them.
    /// </para>
    /// </remarks>
    public Task<ItemDiagnosticSearchResponse> SearchItemIssues(SearchItemIssuesRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/v3/advertising/sem/item-issues/search"),
            [],
            [],
            [
                new HeaderParam("WM_SEC.ACCESS_TOKEN", request.WmSecAccessToken),
                new HeaderParam("WM_SVC.NAME", request.WmSvcName),
                new HeaderParam("WM_QOS.CORRELATION_ID", request.WmQosCorrelationId),
                new HeaderParam("WM_GLOBAL_VERSION", request.WmGlobalVersion),
                new HeaderParam("WM_MARKET", request.WmMarket),
                new HeaderParam("Accept", request.Accept),
                new HeaderParam("WM_CONSUMER.CHANNEL.TYPE", request.WmConsumerChannelType),
                new HeaderParam("Idempotency-Key", Guid.NewGuid()),
            ],
            HttpMethod.Post,
            JsonRequest.Create(request.Body),
            JsonResponse.Create<ItemDiagnosticSearchResponse>(),
            SearchItemIssuesError.Response,
            [_auth.AccessToken],
            requestOptions,
            cancellationToken);
}
