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
using WalmartApIs.Requests.Disputes;

namespace WalmartApIs.Api;

public sealed class Disputes
{
    private readonly RawClient _rawClient;
    private readonly Server _server;

    internal Disputes(RawClient rawClient, Server server)
    {
        _rawClient = rawClient;
        _server = server;
    }

    /// <summary>
    /// Dispute submission
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="DisputeContestResponses"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="PostContestError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Use this API to submit dispute for up to 100 items at a time.
    /// <para>
    /// We need to pass <c>productId</c>, and <c>productIdType</c> in the body for creating a dispute.
    /// </para>
    /// <para>
    /// *   POST {{url}}/v3/items/dispute/duplicates/contest
    /// &lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US only&lt;/b&gt;
    /// </para>
    /// </remarks>
    public Task<DisputeContestResponses> PostContest(PostContestRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/v3/items/dispute/duplicates/contest"),
            [],
            [],
            [
                new HeaderParam("WM_SEC.ACCESS_TOKEN", request.WmSecAccessToken),
                new HeaderParam("WM_QOS.CORRELATION_ID", request.WmQosCorrelationId),
                new HeaderParam("WM_SVC.NAME", request.WmSvcName),
                new HeaderParam("WM_MARKET", request.WmMarket),
                new HeaderParam("WM_GLOBAL_VERSION", request.WmGlobalVersion),
                new HeaderParam("WM_CONSUMER.CHANNEL.TYPE", request.WmConsumerChannelType),
                new HeaderParam("Idempotency-Key", Guid.NewGuid()),
            ],
            HttpMethod.Post,
            JsonRequest.Create(request.Body),
            JsonResponse.Create<DisputeContestResponses>(),
            PostContestError.Response,
            [],
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Dispute status
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="V3ItemsDisputeDuplicatesStatusResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="PostStatusError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Use this API to retrieve the status of up to 100 disputed items at a time.
    /// <para>
    /// We need to pass <c>productId</c>, and <c>productIdType</c> in the body for creating a dispute.
    /// </para>
    /// <list type="bullet">
    ///   <item><description>  POST {{url}}/v3/items/dispute/duplicates/status</description></item>
    /// </list>
    /// <para>
    /// Responses will be based on the item status:
    /// </para>
    /// <list type="bullet">
    ///   <item><description>404: No item Response</description></item>
    /// </list>
    /// <list type="bullet">
    ///   <item><description>200: Response received for all items</description></item>
    /// </list>
    /// <list type="bullet">
    ///   <item><description>206: Partial response received</description></item>
    /// </list>
    /// <para>
    /// An Item can be in 4 different stages:
    /// * <c>IN_REVIEW</c>, <c>IS_DUPLICATE</c>, <c>ERROR</c>, <c>NOT_DUPLICATE</c>
    /// &lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US only&lt;/b&gt;
    /// </para>
    /// </remarks>
    public Task<V3ItemsDisputeDuplicatesStatusResponse> PostStatus(PostStatusRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/v3/items/dispute/duplicates/status"),
            [],
            [],
            [
                new HeaderParam("WM_SEC.ACCESS_TOKEN", request.WmSecAccessToken),
                new HeaderParam("WM_QOS.CORRELATION_ID", request.WmQosCorrelationId),
                new HeaderParam("WM_SVC.NAME", request.WmSvcName),
                new HeaderParam("WM_MARKET", request.WmMarket),
                new HeaderParam("WM_GLOBAL_VERSION", request.WmGlobalVersion),
                new HeaderParam("WM_CONSUMER.CHANNEL.TYPE", request.WmConsumerChannelType),
                new HeaderParam("Idempotency-Key", Guid.NewGuid()),
            ],
            HttpMethod.Post,
            JsonRequest.Create(request.Body),
            JsonResponse.Create<V3ItemsDisputeDuplicatesStatusResponse>(),
            PostStatusError.Response,
            [],
            requestOptions,
            cancellationToken);
}
