using System;
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
using WalmartApIs.Requests.SemCampaignManagement;

namespace WalmartApIs.Api;

/// <summary>
/// Endpoints for managing Search Engine Marketing campaigns
/// </summary>
public sealed class SemCampaignManagement
{
    private readonly RawClient _rawClient;
    private readonly Server _server;
    private readonly AuthSchemes _auth;

    internal SemCampaignManagement(RawClient rawClient, Server server, AuthSchemes auth)
    {
        _rawClient = rawClient;
        _server = server;
        _auth = auth;
    }

    /// <summary>
    /// Create a new campaign
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="SemCampaignResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="CreateCampaignError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// This API allows you to create a new campaign by providing the required details in the request. Upon successful creation, a unique campaign ID will be assigned to the newly created campaign for identification and management purposes.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US only&lt;/b&gt;
    /// </remarks>
    public Task<SemCampaignResponse> CreateCampaign(CreateCampaignRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/v3/advertising/sem/campaigns"),
            [],
            [],
            [
                new HeaderParam("WM_SEC.ACCESS_TOKEN", request.WmSecAccessToken),
                new HeaderParam("WM_QOS.CORRELATION_ID", request.WmQosCorrelationId),
                new HeaderParam("WM_SVC.NAME", request.WmSvcName),
                new HeaderParam("WM_CONSUMER.CHANNEL.TYPE", request.WmConsumerChannelType),
                new HeaderParam("Idempotency-Key", Guid.NewGuid()),
            ],
            HttpMethod.Post,
            JsonRequest.Create(request.Body),
            JsonResponse.Create<SemCampaignResponse>(),
            CreateCampaignError.Response,
            [_auth.BearerAuth],
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Delete an existing campaign
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="SemCampaignResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="DeleteCampaignError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// This API allows you to permanently remove an existing campaign from the system. Once deleted, the campaign and its unique ID will no longer be retrievable. The campaign's unique ID must be included in the request.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US only&lt;/b&gt;
    /// </remarks>
    public Task<SemCampaignResponse> DeleteCampaign(DeleteCampaignRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/v3/advertising/sem/campaigns/{campaignId}"),
            [new TemplateParam("campaignId", request.CampaignId)],
            [],
            [
                new HeaderParam("WM_SEC.ACCESS_TOKEN", request.WmSecAccessToken),
                new HeaderParam("WM_QOS.CORRELATION_ID", request.WmQosCorrelationId),
                new HeaderParam("WM_SVC.NAME", request.WmSvcName),
                new HeaderParam("WM_CONSUMER.CHANNEL.TYPE", request.WmConsumerChannelType),
                new HeaderParam("Idempotency-Key", Guid.NewGuid()),
            ],
            HttpMethod.Delete,
            EmptyBody.Instance,
            JsonResponse.Create<SemCampaignResponse>(),
            DeleteCampaignError.Response,
            [_auth.BearerAuth],
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Get campaign details
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="SemCampaign"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="GetCampaignDetailsError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// This API allows you to retrieve detailed information about a specific campaign. Provide the campaign's unique ID in the request to fetch its attributes.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US only&lt;/b&gt;
    /// </remarks>
    public Task<SemCampaign> GetCampaignDetails(GetCampaignDetailsRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/v3/advertising/sem/campaigns/{campaignId}"),
            [new TemplateParam("campaignId", request.CampaignId)],
            [],
            [
                new HeaderParam("WM_SEC.ACCESS_TOKEN", request.WmSecAccessToken),
                new HeaderParam("WM_QOS.CORRELATION_ID", request.WmQosCorrelationId),
                new HeaderParam("WM_SVC.NAME", request.WmSvcName),
                new HeaderParam("WM_CONSUMER.CHANNEL.TYPE", request.WmConsumerChannelType),
            ],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<SemCampaign>(),
            GetCampaignDetailsError.Response,
            [_auth.BearerAuth],
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Search campaign recommendations
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="CampaignRecommendationsSearchResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="SearchCampaignRecommendationsError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Search for campaign-level recommendations to improve SEM campaign performance. Returns a paginated list of active campaigns for the authenticated seller, each enriched with actionable recommendations — including budget adjustments and bidding strategy optimizations — along with projected performance impact metrics (clicks, impressions, ad spend).&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US only&lt;/b&gt;
    /// <para>
    /// ### Why this API matters
    /// SEM campaigns require continuous optimization to stay competitive. Budget constraints and suboptimal bidding strategies are the two most common reasons campaigns underperform. Without data-driven guidance, sellers either overspend without results or miss revenue opportunities by underspending.
    /// </para>
    /// <para>
    /// This API bridges that gap by surfacing <b>machine-generated recommendations</b> for each active campaign, complete with projected impact on clicks, impressions, and ad spend. Partners can integrate these recommendations into their dashboards and automation pipelines to:
    /// - <b>Increase ROAS</b>: Apply budget and bidding strategy recommendations to maximize return on ad spend
    /// - <b>Reduce wasted spend</b>: Identify campaigns where budget is being underutilized or misallocated
    /// - <b>Automate campaign tuning</b>: Build automated workflows that periodically fetch recommendations and apply them programmatically, reducing manual effort and reaction time
    /// - <b>Enable data-driven decisions</b>: Each recommendation includes three impact scenarios (recommended, conservative, aggressive) so sellers can choose the option that fits their risk tolerance
    /// </para>
    /// <para>
    /// ### Key use cases
    /// 1. <b>Campaign Health Dashboard</b>: Display campaigns with pending recommendations, color-coded by type (<c>BUDGET</c> vs <c>BIDDING_STRATEGY</c>), with projected impact metrics
    /// 2. <b>Automated Budget Optimizer</b>: Periodically poll this API and auto-apply budget recommendations that meet a minimum projected ROAS threshold
    /// 3. <b>Bidding Strategy Advisor</b>: Surface bidding strategy change suggestions to sellers with before/after performance projections
    /// 4. <b>Bulk Campaign Management</b>: Retrieve all recommendations across campaigns in a single paginated call, enabling batch review and bulk application of changes
    /// </para>
    /// <para>
    /// ### How it works
    /// The API returns only active campaigns that are eligible for recommendations. You can filter results using <c>campaignIds</c> or <c>recommendationType</c> (<c>BUDGET</c> or <c>BIDDING_STRATEGY</c>).
    /// </para>
    /// <para>
    /// ### Default behavior
    /// - When no request body is provided, the API defaults to <c>offset=0</c>, <c>limit=10</c>.
    /// - By default, the API returns recommendations for both <c>BUDGET</c> and <c>BIDDING_STRATEGY</c>.
    /// - Results are not sorted by default; use the sort object to order by adspend.
    /// - Returns only <b>active campaigns</b> that have at least one pending recommendation
    /// - Results are not sorted by default; use the <c>sort</c> object to order by <c>adspend</c>
    /// </para>
    /// <para>
    /// ### Supported filters
    /// Filters are combined with AND logic. Multiple values within a single filter act as OR.
    /// </para>
    /// <para>
    /// | Filter Field              | Supported Values              | Description                                              |
    /// |---------------------------|-------------------------------|----------------------------------------------------------|
    /// | <c>campaignIds</c>             | Numeric string campaign IDs   | Filter by specific campaign identifiers                  |
    /// | <c>recommendationType</c>  | <c>BUDGET</c>, <c>BIDDING_STRATEGY</c>  | Filter by recommendation type                            |
    /// </para>
    /// <para>
    /// ### Sorting
    /// Results can be sorted using the <c>sort</c> object:
    /// </para>
    /// <para>
    /// | Sort Field | Supported Orders | Description                              |
    /// |------------|------------------|------------------------------------------|
    /// | <c>adspend</c>  | <c>ASC</c>, <c>DESC</c>    | Sort campaigns by ad spend               |
    /// </para>
    /// <para>
    /// ### Recommendation types
    /// | Type               | Description                                                              |
    /// |--------------------|--------------------------------------------------------------------------|
    /// | <c>BUDGET</c>           | Recommended total or daily budget adjustment to improve campaign reach    |
    /// | <c>BIDDING_STRATEGY</c> | Recommended change to bidding strategy for better performance            |
    /// </para>
    /// <para>
    /// ### Response structure
    /// Each response contains two top-level fields:
    /// - <c>pagination</c>: Standard pagination metadata (<c>pageNo</c>, <c>pageSize</c>, <c>totalCount</c>, <c>totalPages</c>, <c>hasNextPage</c>, <c>hasPreviousPage</c>)
    /// - <c>data</c>: Array of campaign-level suggestions. Each campaign includes current settings (bidding strategy, target ROAS, daily budget) and an array of <c>campaignRecommendations</c> with projected performance impact at three levels: recommended, minimum, and maximum.
    /// </para>
    /// <para>
    /// ### Performance impact projections
    /// Each recommendation includes a <c>recommendedValueImpact</c> object with up to three scenarios:
    /// - <b>recommended</b>: The optimal suggested value (marked <c>isRecommended: true</c>)
    /// - <b>minRecommendation</b>: A conservative lower-bound option (may be <c>null</c> if not applicable)
    /// - <b>maxRecommendation</b>: An aggressive upper-bound option
    /// </para>
    /// </remarks>
    public Task<CampaignRecommendationsSearchResponse> SearchCampaignRecommendations(SearchCampaignRecommendationsRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/v3/advertising/sem/campaigns/recommendations/search"),
            [],
            [],
            [
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
            JsonResponse.Create<CampaignRecommendationsSearchResponse>(),
            SearchCampaignRecommendationsError.Response,
            [_auth.AccessToken],
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Stop a running campaign
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="SemCampaignResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="StopCampaignError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// This API allows you to stop an active campaign. Stopping a campaign does not delete it but prevents further actions. The campaign's unique ID must be included in the request.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US only&lt;/b&gt;
    /// </remarks>
    public Task<SemCampaignResponse> StopCampaign(StopCampaignRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/v3/advertising/sem/campaigns/{campaignId}/stop"),
            [new TemplateParam("campaignId", request.CampaignId)],
            [],
            [
                new HeaderParam("WM_SEC.ACCESS_TOKEN", request.WmSecAccessToken),
                new HeaderParam("WM_QOS.CORRELATION_ID", request.WmQosCorrelationId),
                new HeaderParam("WM_SVC.NAME", request.WmSvcName),
                new HeaderParam("WM_CONSUMER.CHANNEL.TYPE", request.WmConsumerChannelType),
                new HeaderParam("Idempotency-Key", Guid.NewGuid()),
            ],
            HttpMethod.Put,
            EmptyBody.Instance,
            JsonResponse.Create<SemCampaignResponse>(),
            StopCampaignError.Response,
            [_auth.BearerAuth],
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Update an existing campaign
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="SemCampaignResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="UpdateCampaignError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// This API allows you to modify an existing campaign's details and manage its associated items. You must provide the campaign's unique ID along with the necessary changes in the request. The specified updates will be applied while preserving the campaign's unique identifier.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US only&lt;/b&gt;
    /// </remarks>
    public Task<SemCampaignResponse> UpdateCampaign(UpdateCampaignRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/v3/advertising/sem/campaigns/{campaignId}"),
            [new TemplateParam("campaignId", request.CampaignId)],
            [],
            [
                new HeaderParam("WM_SEC.ACCESS_TOKEN", request.WmSecAccessToken),
                new HeaderParam("WM_QOS.CORRELATION_ID", request.WmQosCorrelationId),
                new HeaderParam("WM_SVC.NAME", request.WmSvcName),
                new HeaderParam("WM_CONSUMER.CHANNEL.TYPE", request.WmConsumerChannelType),
                new HeaderParam("Idempotency-Key", Guid.NewGuid()),
            ],
            HttpMethod.Put,
            JsonRequest.Create(request.Body),
            JsonResponse.Create<SemCampaignResponse>(),
            UpdateCampaignError.Response,
            [_auth.BearerAuth],
            requestOptions,
            cancellationToken);
}
