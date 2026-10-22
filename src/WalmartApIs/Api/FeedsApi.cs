using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using WalmartApIs.Core;
using WalmartApIs.Core.ErrorResponse;
using WalmartApIs.Core.Exceptions;
using WalmartApIs.Core.Models;
using WalmartApIs.Core.Request;
using WalmartApIs.Core.Response;
using WalmartApIs.Errors;
using WalmartApIs.Models;
using WalmartApIs.Requests.FeedsApi;

namespace WalmartApIs.Api;

public sealed class FeedsApi
{
    private readonly RawClient _rawClient;
    private readonly Server _server;
    private readonly AuthSchemes _auth;

    internal FeedsApi(RawClient rawClient, Server server, AuthSchemes auth)
    {
        _rawClient = rawClient;
        _server = server;
        _auth = auth;
    }

    /// <summary>
    /// All feed statuses
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="FeedRecordResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="GetAllFeedStatusesError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// This API returns the feed statuses for all the specified feed IDs. Use the specified feedTypes to query the status of each feed and identify whether it was processed successfully, failed, or is still in progress.
    /// <para>
    ///  | FeedTypes | Availability |
    /// |--------|----------|
    /// | MP_MAINTENANCE, MP_ITEM_MATCH, LAGTIME | Global |
    /// | MP_INVENTORY, SKU_TEMPLATE_MAP | US, CA, MX |
    /// | MP_ITEM_INTL | CA, MX, CL |
    /// | MP_ITEM, MP_WFS_ITEM, WALMART_FUNDED_INCENTIVES_ENROLLMENT, INCENTIVE_ENROLLMENT,PRICE_AND_PROMOTION | US Only |
    /// | OMNI_WFS, RETIRE_ITEM, SHIPPING_OVERRIDES, FITMENT_ACES, FITMENT_PIES, SPLIT_AND_MERGE | US Only |
    /// | OMNI_WFSSETUP, OMNI_WFSCONVERT | CA, MX |
    /// </para>
    /// <para>
    /// &lt;br&gt;&lt;b style='color:green;'&gt;Market availability: Global&lt;/b&gt;
    /// </para>
    /// </remarks>
    public Task<FeedRecordResponse> GetAllFeedStatuses(GetAllFeedStatusesRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/v3/feeds"),
            [],
            [
                new Param("feedId", request.FeedId),
                new Param("feedType", request.FeedType),
                new Param("feedStatus", request.FeedStatus),
                new Param("offset", request.Offset),
                new Param("limit", request.Limit),
            ],
            [
                new HeaderParam("WM_SEC.ACCESS_TOKEN", request.WmSecAccessToken),
                new HeaderParam("WM_QOS.CORRELATION_ID", request.WmQosCorrelationId),
                new HeaderParam("WM_SVC.NAME", request.WmSvcName),
                new HeaderParam("WM_MARKET", request.WmMarket),
                new HeaderParam("WM_GLOBAL_VERSION", request.WmGlobalVersion),
                new HeaderParam("WM_CONSUMER.CHANNEL.TYPE", request.WmConsumerChannelType),
            ],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<FeedRecordResponse>(),
            GetAllFeedStatusesError.Response,
            [_auth.AccessToken],
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Get Feed Error Report
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="BinaryContent"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="RawError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Get Feed Error Report API allows you to download a detailed error report for a submitted feed.
    /// <para>
    /// Currently the API supports error report download for the following feeds:
    /// *   FITMENT_ACES
    /// *   FITMENT_PIES
    /// </para>
    /// <para>
    ///  This API returns a zipped .csv file, which contains line item level detailed error messages. For details and a sample, please refer to the guide section link below.
    /// &lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US only&lt;/b&gt;
    /// </para>
    /// </remarks>
    public Task<BinaryContent> GetFeedErrorReport(GetFeedErrorReportRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/v3/feeds/{feedId}/errorReport"),
            [new TemplateParam("feedId", request.FeedId)],
            [new Param("feedType", request.FeedType)],
            [
                new HeaderParam("WM_SEC.ACCESS_TOKEN", request.WmSecAccessToken),
                new HeaderParam("WM_QOS.CORRELATION_ID", request.WmQosCorrelationId),
                new HeaderParam("WM_SVC.NAME", request.WmSvcName),
                new HeaderParam("WM_MARKET", request.WmMarket),
                new HeaderParam("WM_GLOBAL_VERSION", request.WmGlobalVersion),
                new HeaderParam("WM_CONSUMER.CHANNEL.TYPE", request.WmConsumerChannelType),
            ],
            HttpMethod.Get,
            EmptyBody.Instance,
            BinaryResponse.Instance,
            RawErrorResponse.Instance,
            [_auth.AccessToken],
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Feed item status
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="V3FeedsResponse1"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="GetFeedItemStatusError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Returns the feed and item status for a specified Feed ID.
    /// &lt;br&gt;&lt;b style='color:green;'&gt;Market availability: Global&lt;/b&gt;
    /// </remarks>
    public Task<V3FeedsResponse1> GetFeedItemStatus(GetFeedItemStatusRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/v3/feeds/{feedId}"),
            [new TemplateParam("feedId", request.FeedId)],
            [
                new Param("includeDetails", request.IncludeDetails),
                new Param("offset", request.Offset),
                new Param("limit", request.Limit),
            ],
            [
                new HeaderParam("WM_SEC.ACCESS_TOKEN", request.WmSecAccessToken),
                new HeaderParam("WM_QOS.CORRELATION_ID", request.WmQosCorrelationId),
                new HeaderParam("WM_SVC.NAME", request.WmSvcName),
                new HeaderParam("WM_MARKET", request.WmMarket),
                new HeaderParam("WM_GLOBAL_VERSION", request.WmGlobalVersion),
                new HeaderParam("WM_CONSUMER.CHANNEL.TYPE", request.WmConsumerChannelType),
            ],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<V3FeedsResponse1>(),
            GetFeedItemStatusError.Response,
            [_auth.AccessToken],
            requestOptions,
            cancellationToken);
}
