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
using WalmartApIs.Requests.WsrAttributionReports;

namespace WalmartApIs.Api;

/// <summary>
/// Endpoints for retrieving affiliate campaign performance reports
/// </summary>
public sealed class WsrAttributionReports
{
    private readonly RawClient _rawClient;
    private readonly Server _server;
    private readonly AuthSchemes _auth;

    internal WsrAttributionReports(RawClient rawClient, Server server, AuthSchemes auth)
    {
        _rawClient = rawClient;
        _server = server;
        _auth = auth;
    }

    /// <summary>
    /// Get Tag Templates
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="WsrTagTemplatesResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="GetTagTemplatesError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Fetch referral link tag templates for different page types (ITEM, BRANDSHOP). Tag templates contain URL patterns with placeholders that can be used to construct final referral URLs/tags for affiliate tracking.
    /// <para>
    /// &lt;span style="color:green"&gt;<b>Market availability: US</b>&lt;/span&gt;
    /// </para>
    /// </remarks>
    public Task<WsrTagTemplatesResponse> GetTagTemplates(GetTagTemplatesRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/v3/advertising/wsr/attribution/tag-templates/{templateType}"),
            [new TemplateParam("templateType", request.TemplateType)],
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
            JsonResponse.Create<WsrTagTemplatesResponse>(),
            GetTagTemplatesError.Response,
            [_auth.BearerAuth],
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Get Item Report
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="WsrItemReportResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="GetWsrItemReportError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Retrieve detailed item-level performance reports for affiliate campaigns.
    /// <para>
    /// &lt;span style="color:green"&gt;<b>Market availability: US only</b>&lt;/span&gt;
    /// </para>
    /// <para>
    /// This endpoint returns performance data at the individual item/product level,
    /// including product details such as item name, category, and product type along
    /// with performance metrics. This is useful for understanding which products are
    /// driving the most revenue through affiliate channels.
    /// </para>
    /// <para>
    /// ### Aggregation Levels and Field Availability
    /// The <c>performanceBy</c> parameter determines which identifier fields are populated in the response:
    /// </para>
    /// <para>
    /// | performanceBy | campaignId | adGroupId | creativeId |
    /// |---------------|------------|-----------|------------|
    /// | CAMPAIGN      | ✓          | null      | null       |
    /// | ADGROUP       | ✓          | ✓         | null       |
    /// | CREATIVE      | ✓          | ✓         | ✓          |
    /// </para>
    /// <para>
    /// ### Supported filters
    /// - <c>startDate</c>: Report start date (required)
    /// - <c>endDate</c>: Report end date (required)
    /// - <c>campaignId</c>: Filter by specific campaign IDs
    /// - <c>adGroupId</c>: Filter by specific ad group IDs
    /// - <c>creativeId</c>: Filter by specific creative IDs
    /// </para>
    /// <para>
    /// ### Date Validation Rules
    /// - End date must be strictly after start date
    /// - Maximum date range: less than 1 year
    /// - Dates must be in ISO format (YYYY-MM-DD)
    /// </para>
    /// </remarks>
    public Task<WsrItemReportResponse> GetWsrItemReport(GetWsrItemReportRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/v3/advertising/wsr/attribution/item-report"),
            [],
            [],
            [
                new HeaderParam("WM_SEC.ACCESS_TOKEN", request.WmSecAccessToken),
                new HeaderParam("WM_SVC.NAME", request.WmSvcName),
                new HeaderParam("WM_QOS.CORRELATION_ID", request.WmQosCorrelationId),
                new HeaderParam("WM_GLOBAL_VERSION", request.WmGlobalVersion),
                new HeaderParam("WM_MARKET", request.WmMarket),
                new HeaderParam("WM_CONSUMER.CHANNEL.TYPE", request.WmConsumerChannelType),
                new HeaderParam("Idempotency-Key", Guid.NewGuid()),
            ],
            HttpMethod.Post,
            JsonRequest.Create(request.Body),
            JsonResponse.Create<WsrItemReportResponse>(),
            GetWsrItemReportError.Response,
            [_auth.BearerAuth],
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Get Performance Report
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="WsrPerformanceReportResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="GetWsrPerformanceReportError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Retrieve performance analytics and metrics for affiliate campaigns.
    /// <para>
    /// &lt;span style="color:green"&gt;<b>Market availability: US only</b>&lt;/span&gt;
    /// </para>
    /// <para>
    /// This endpoint returns aggregated performance data including clicks, orders,
    /// GMV, and commission metrics within a specified date range. Data can be
    /// aggregated at different levels based on the <c>performanceBy</c> parameter.
    /// </para>
    /// <para>
    /// ### Aggregation Levels and Field Availability
    /// The <c>performanceBy</c> parameter determines which identifier fields are populated in the response:
    /// </para>
    /// <para>
    /// | performanceBy | campaignId | adGroupId | creativeId |
    /// |---------------|------------|-----------|------------|
    /// | CAMPAIGN      | ✓          | null      | null       |
    /// | ADGROUP       | ✓          | ✓         | null       |
    /// | CREATIVE      | ✓          | ✓         | ✓          |
    /// </para>
    /// <para>
    /// ### Supported filters
    /// - <c>startDate</c>: Report start date (required)
    /// - <c>endDate</c>: Report end date (required)
    /// - <c>campaignId</c>: Filter by specific campaign IDs
    /// - <c>adGroupId</c>: Filter by specific ad group IDs
    /// - <c>creativeId</c>: Filter by specific creative IDs
    /// </para>
    /// <para>
    /// ### Date Validation Rules
    /// - End date must be strictly after start date
    /// - Maximum date range: less than 1 year
    /// - Dates must be in ISO format (YYYY-MM-DD)
    /// </para>
    /// </remarks>
    public Task<WsrPerformanceReportResponse> GetWsrPerformanceReport(GetWsrPerformanceReportRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/v3/advertising/wsr/attribution/performance-report"),
            [],
            [],
            [
                new HeaderParam("WM_SEC.ACCESS_TOKEN", request.WmSecAccessToken),
                new HeaderParam("WM_SVC.NAME", request.WmSvcName),
                new HeaderParam("WM_QOS.CORRELATION_ID", request.WmQosCorrelationId),
                new HeaderParam("WM_GLOBAL_VERSION", request.WmGlobalVersion),
                new HeaderParam("WM_MARKET", request.WmMarket),
                new HeaderParam("WM_CONSUMER.CHANNEL.TYPE", request.WmConsumerChannelType),
                new HeaderParam("Idempotency-Key", Guid.NewGuid()),
            ],
            HttpMethod.Post,
            JsonRequest.Create(request.Body),
            JsonResponse.Create<WsrPerformanceReportResponse>(),
            GetWsrPerformanceReportError.Response,
            [_auth.BearerAuth],
            requestOptions,
            cancellationToken);
}
