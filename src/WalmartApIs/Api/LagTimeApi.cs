using System;
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
using WalmartApIs.Requests.LagTimeApi;

namespace WalmartApIs.Api;

public sealed class LagTimeApi
{
    private readonly RawClient _rawClient;
    private readonly Server _server;
    private readonly AuthSchemes _auth;

    internal LagTimeApi(RawClient rawClient, Server server, AuthSchemes auth)
    {
        _rawClient = rawClient;
        _server = server;
        _auth = auth;
    }

    /// <summary>
    /// Lag Time
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="LagTimeResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="GetLagTimeError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Use this API to retrieve the lag time for a specific item using its SKU.
    /// <para>
    /// Lag Time represents the number of days between when an item is ordered and when it is shipped. Approval thresholds and exemption processes for higher lag times vary by market. For more details, refer to the relevant market-specific knowledge article.
    /// &lt;br&gt;&lt;b style='color:green;'&gt;Market availability: Global&lt;/strong&gt;
    /// </para>
    /// </remarks>
    public Task<LagTimeResponse> GetLagTime(GetLagTimeRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/v3/lagtime"),
            [],
            [new Param("sku", request.Sku)],
            [
                new HeaderParam("WM_QOS.CORRELATION_ID", request.WmQosCorrelationId),
                new HeaderParam("WM_SVC.NAME", request.WmSvcName),
                new HeaderParam("WM_MARKET", request.WmMarket),
                new HeaderParam("WM_GLOBAL_VERSION", request.WmGlobalVersion),
                new HeaderParam("WM_CONSUMER.CHANNEL.TYPE", request.WmConsumerChannelType),
            ],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<LagTimeResponse>(),
            GetLagTimeError.Response,
            [_auth.AccessToken],
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Update lag time
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="FeedId1"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="RawError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Use this API to update lag time for multiple items at once.
    /// <para>
    /// Lag Time represents the number of days between when an item is ordered and when it is shipped. Approval thresholds and exemption processes for higher lag times vary by market. For more details, refer to the relevant market-specific knowledge article.
    /// &lt;br&gt;&lt;b style='color:green;'&gt;Market availability: Global&lt;/b&gt;
    /// </para>
    /// </remarks>
    public Task<FeedId1> UpdateLagTimeBulk(UpdateLagTimeBulkRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/v3/feeds"),
            [],
            [new Param("feedType", request.FeedType)],
            [
                new HeaderParam("WM_QOS.CORRELATION_ID", request.WmQosCorrelationId),
                new HeaderParam("WM_SVC.NAME", request.WmSvcName),
                new HeaderParam("WM_MARKET", request.WmMarket),
                new HeaderParam("WM_GLOBAL_VERSION", request.WmGlobalVersion),
                new HeaderParam("WM_CONSUMER.CHANNEL.TYPE", request.WmConsumerChannelType),
                new HeaderParam("Idempotency-Key", Guid.NewGuid()),
            ],
            HttpMethod.Post,
            JsonRequest.Create(request.Body),
            JsonResponse.Create<FeedId1>(),
            RawErrorResponse.Instance,
            [_auth.AccessToken],
            requestOptions,
            cancellationToken);
}
