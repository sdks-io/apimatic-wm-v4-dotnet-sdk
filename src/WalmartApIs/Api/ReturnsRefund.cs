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
using WalmartApIs.Requests.ReturnsRefund;

namespace WalmartApIs.Api;

public sealed class ReturnsRefund
{
    private readonly RawClient _rawClient;
    private readonly Server _server;
    private readonly AuthSchemes _auth;

    internal ReturnsRefund(RawClient rawClient, Server server, AuthSchemes auth)
    {
        _rawClient = rawClient;
        _server = server;
        _auth = auth;
    }

    /// <summary>
    /// Get Returns
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="ReturnOrderResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="GetReturnsError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Retrieves the details of all return orders for the specified filter criteria.
    /// <para>
    /// &lt;br&gt;&lt;b style='color:green;'&gt;Market availability: Global&lt;/b&gt;
    /// </para>
    /// </remarks>
    public Task<ReturnOrderResponse> GetReturns(GetReturnsRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/v3/returns"),
            [],
            [new Param("Query Params", request.QueryParams)],
            [
                new HeaderParam("WM_QOS.CORRELATION_ID", request.WmQosCorrelationId),
                new HeaderParam("WM_SVC.NAME", request.WmSvcName),
                new HeaderParam("WM_MARKET", request.WmMarket),
                new HeaderParam("WM_GLOBAL_VERSION", request.WmGlobalVersion),
                new HeaderParam("WM_CONSUMER.CHANNEL.TYPE", request.WmConsumerChannelType),
            ],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<ReturnOrderResponse>(),
            GetReturnsError.Response,
            [_auth.AccessToken],
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Refund Order Lines
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="RequestModel"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="RefundRequestError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Refunds one or more order lines that have been shipped. The response to a successful call contains the order with the refunded line item.
    /// <para>
    /// &lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US | MX&lt;/b&gt;
    /// </para>
    /// </remarks>
    public Task<RequestModel> RefundRequest(RefundRequestOperationRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/v3/returns/{returnOrderId}/refund"),
            [new TemplateParam("returnOrderId", request.ReturnOrderId)],
            [],
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
            JsonResponse.Create<RequestModel>(),
            RefundRequestError.Response,
            [_auth.AccessToken],
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Get all returns with cursor mark
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="ReturnOrdersResponses"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="ReturnOrderCursorError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// This API retrieves the details of all return orders based on the specified filter criteria and returns all orders in the response. It returns a nextCursorMark for the next 100 orders, and continues in this manner until the last order. The same API can also be used to search for a single order based on returnOrderId or customerOrderId.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: MX&lt;/b&gt;
    /// </remarks>
    public Task<ReturnOrdersResponses> ReturnOrderCursor(ReturnOrderCursorRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/v3/returns/cursor"),
            [],
            [new Param("Query Params", request.QueryParams)],
            [
                new HeaderParam("WM_QOS.CORRELATION_ID", request.WmQosCorrelationId),
                new HeaderParam("WM_SVC.NAME", request.WmSvcName),
                new HeaderParam("WM_MARKET", request.WmMarket),
                new HeaderParam("WM_GLOBAL_VERSION", request.WmGlobalVersion),
                new HeaderParam("WM_CONSUMER.CHANNEL.TYPE", request.WmConsumerChannelType),
            ],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<ReturnOrdersResponses>(),
            ReturnOrderCursorError.Response,
            [_auth.AccessToken],
            requestOptions,
            cancellationToken);
}
