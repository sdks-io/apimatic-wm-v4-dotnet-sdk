using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using WalmartApIs.Core;
using WalmartApIs.Core.Exceptions;
using WalmartApIs.Core.Extensions;
using WalmartApIs.Core.Models;
using WalmartApIs.Core.Request;
using WalmartApIs.Core.Response;
using WalmartApIs.Errors;
using WalmartApIs.Models;

namespace WalmartApIs.Api;

public sealed class FulfillmentOutbound
{
    private readonly RawClient _rawClient;
    private readonly Server _server;
    private readonly AuthSchemes _auth;

    internal FulfillmentOutbound(RawClient rawClient, Server server, AuthSchemes auth)
    {
        _rawClient = rawClient;
        _server = server;
        _auth = auth;
    }

    /// <summary>
    /// Requests that Walmart stop attempting to fulfil the fulfillment order
    /// </summary>
    /// <param name="sellerFulfillmentOrderId"></param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="CancelFulfillmentOrderResponse"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="CancelFulfillmentOrderError"/> when the server returns an error response.</exception>
    public Task<CancelFulfillmentOrderResponse> CancelFulfillmentOrder(string sellerFulfillmentOrderId,
        RequestOptions? requestOptions = null,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default1("/wfs/outbound/v4/fulfillmentOrders/{sellerFulfillmentOrderId}/cancel"),
            [new TemplateParam("sellerFulfillmentOrderId", sellerFulfillmentOrderId)],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Put,
            EmptyBody.Instance,
            JsonResponse.Create<CancelFulfillmentOrderResponse>(),
            CancelFulfillmentOrderErrorResponse.Instance,
            [_auth.WalletAuth],
            requestOptions,
            ct);

    /// <summary>
    /// Requests that Walmart ship items from the seller's inventory in WFS
    /// </summary>
    /// <param name="body"></param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="CreateFulfillmentOrderResponse"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="CreateFulfillmentOrderError"/> when the server returns an error response.</exception>
    public Task<CreateFulfillmentOrderResponse> CreateFulfillmentOrder(CreateFulfillmentOrderRequest body,
        RequestOptions? requestOptions = null,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default1("/wfs/outbound/v4/fulfillmentOrders"),
            [],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Post,
            JsonRequest.Create(body),
            JsonResponse.Create<CreateFulfillmentOrderResponse>(),
            CreateFulfillmentOrderErrorResponse.Instance,
            [_auth.WalletAuth],
            requestOptions,
            ct);

    /// <summary>
    /// Returns the fulfillment order indicated by the sellerFulfillmentOrderId
    /// </summary>
    /// <param name="sellerFulfillmentOrderId"></param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="GetFulfillmentOrderResponse"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="GetFulfillmentOrderError"/> when the server returns an error response.</exception>
    public Task<GetFulfillmentOrderResponse> GetFulfillmentOrder(string sellerFulfillmentOrderId,
        RequestOptions? requestOptions = null,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default1("/wfs/outbound/v4/fulfillmentOrders/{sellerFulfillmentOrderId}"),
            [new TemplateParam("sellerFulfillmentOrderId", sellerFulfillmentOrderId)],
            [],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<GetFulfillmentOrderResponse>(),
            GetFulfillmentOrderErrorResponse.Instance,
            [_auth.WalletAuth],
            requestOptions,
            ct);

    /// <summary>
    /// Returns shipment information for a fulfillment order
    /// </summary>
    /// <param name="sellerFulfillmentOrderId"></param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="GetFulfillmentOrderShipmentsResponse"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="GetFulfillmentOrderShipmentsError"/> when the server returns an error response.</exception>
    public Task<GetFulfillmentOrderShipmentsResponse> GetFulfillmentOrderShipments(string sellerFulfillmentOrderId,
        RequestOptions? requestOptions = null,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default1("/wfs/outbound/v4/fulfillmentOrders/{sellerFulfillmentOrderId}/shipments"),
            [new TemplateParam("sellerFulfillmentOrderId", sellerFulfillmentOrderId)],
            [],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<GetFulfillmentOrderShipmentsResponse>(),
            GetFulfillmentOrderShipmentsErrorResponse.Instance,
            [_auth.WalletAuth],
            requestOptions,
            ct);

    /// <summary>
    /// Returns a list of fulfillment order previews based on shipping criteria
    /// </summary>
    /// <param name="body"></param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="GetFulfillmentPreviewResponse"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="GetFulfillmentPreviewError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Returns estimated delivery dates, shipping costs, and available ship nodes
    /// for a prospective fulfillment order. Use before creating the order.
    /// </remarks>
    public Task<GetFulfillmentPreviewResponse> GetFulfillmentPreview(GetFulfillmentPreviewRequest body,
        RequestOptions? requestOptions = null,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default1("/wfs/outbound/v4/fulfillmentOrders/preview"),
            [],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Post,
            JsonRequest.Create(body),
            JsonResponse.Create<GetFulfillmentPreviewResponse>(),
            GetFulfillmentPreviewErrorResponse.Instance,
            [_auth.WalletAuth],
            requestOptions,
            ct);

    /// <summary>
    /// Returns a list of fulfillment orders fulfilled after (or at) a specified date
    /// </summary>
    /// <param name="queryStartDate"></param>
    /// <param name="nextToken"></param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="ListAllFulfillmentOrdersResponse"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="ListAllFulfillmentOrdersError"/> when the server returns an error response.</exception>
    public Task<ListAllFulfillmentOrdersResponse> ListAllFulfillmentOrders(DateTimeOffset? queryStartDate,
        string? nextToken,
        RequestOptions? requestOptions = null,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default1("/wfs/outbound/v4/fulfillmentOrders"),
            [],
            [new Param("queryStartDate", queryStartDate?.ToIso8601()), new Param("nextToken", nextToken)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<ListAllFulfillmentOrdersResponse>(),
            ListAllFulfillmentOrdersErrorResponse.Instance,
            [_auth.WalletAuth],
            requestOptions,
            ct);

    /// <summary>
    /// Updates and/or requests shipment for a fulfillment order with an INCOMPLETE status
    /// </summary>
    /// <param name="sellerFulfillmentOrderId"></param>
    /// <param name="body"></param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="UpdateFulfillmentOrderResponse"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="UpdateFulfillmentOrderError"/> when the server returns an error response.</exception>
    public Task<UpdateFulfillmentOrderResponse> UpdateFulfillmentOrder(string sellerFulfillmentOrderId,
        UpdateFulfillmentOrderRequest body,
        RequestOptions? requestOptions = null,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default1("/wfs/outbound/v4/fulfillmentOrders/{sellerFulfillmentOrderId}"),
            [new TemplateParam("sellerFulfillmentOrderId", sellerFulfillmentOrderId)],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Put,
            JsonRequest.Create(body),
            JsonResponse.Create<UpdateFulfillmentOrderResponse>(),
            UpdateFulfillmentOrderErrorResponse.Instance,
            [_auth.WalletAuth],
            requestOptions,
            ct);
}
