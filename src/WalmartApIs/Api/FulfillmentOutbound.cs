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
using WalmartApIs.Requests.FulfillmentOutbound;

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
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="CancelFulfillmentOrderResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="CancelFulfillmentOrderError"/> when the server returns an error response.</exception>
    public Task<CancelFulfillmentOrderResponse> CancelFulfillmentOrder(CancelFulfillmentOrderRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default1("/wfs/outbound/v4/fulfillmentOrders/{sellerFulfillmentOrderId}/cancel"),
            [new TemplateParam("sellerFulfillmentOrderId", request.SellerFulfillmentOrderId)],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Put,
            EmptyBody.Instance,
            JsonResponse.Create<CancelFulfillmentOrderResponse>(),
            CancelFulfillmentOrderError.Response,
            [_auth.WalletAuth],
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Requests that Walmart ship items from the seller's inventory in WFS
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="CreateFulfillmentOrderResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="CreateFulfillmentOrderError"/> when the server returns an error response.</exception>
    public Task<CreateFulfillmentOrderResponse> CreateFulfillmentOrder(CreateFulfillmentOrderOperationRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default1("/wfs/outbound/v4/fulfillmentOrders"),
            [],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Post,
            JsonRequest.Create(request.Body),
            JsonResponse.Create<CreateFulfillmentOrderResponse>(),
            CreateFulfillmentOrderError.Response,
            [_auth.WalletAuth],
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Returns the fulfillment order indicated by the sellerFulfillmentOrderId
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="GetFulfillmentOrderResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="GetFulfillmentOrderError"/> when the server returns an error response.</exception>
    public Task<GetFulfillmentOrderResponse> GetFulfillmentOrder(GetFulfillmentOrderRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default1("/wfs/outbound/v4/fulfillmentOrders/{sellerFulfillmentOrderId}"),
            [new TemplateParam("sellerFulfillmentOrderId", request.SellerFulfillmentOrderId)],
            [],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<GetFulfillmentOrderResponse>(),
            GetFulfillmentOrderError.Response,
            [_auth.WalletAuth],
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Returns shipment information for a fulfillment order
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="GetFulfillmentOrderShipmentsResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="GetFulfillmentOrderShipmentsError"/> when the server returns an error response.</exception>
    public Task<GetFulfillmentOrderShipmentsResponse> GetFulfillmentOrderShipments(GetFulfillmentOrderShipmentsRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default1("/wfs/outbound/v4/fulfillmentOrders/{sellerFulfillmentOrderId}/shipments"),
            [new TemplateParam("sellerFulfillmentOrderId", request.SellerFulfillmentOrderId)],
            [],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<GetFulfillmentOrderShipmentsResponse>(),
            GetFulfillmentOrderShipmentsError.Response,
            [_auth.WalletAuth],
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Returns a list of fulfillment order previews based on shipping criteria
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="GetFulfillmentPreviewResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="GetFulfillmentPreviewError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Returns estimated delivery dates, shipping costs, and available ship nodes
    /// for a prospective fulfillment order. Use before creating the order.
    /// </remarks>
    public Task<GetFulfillmentPreviewResponse> GetFulfillmentPreview(GetFulfillmentPreviewOperationRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default1("/wfs/outbound/v4/fulfillmentOrders/preview"),
            [],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Post,
            JsonRequest.Create(request.Body),
            JsonResponse.Create<GetFulfillmentPreviewResponse>(),
            GetFulfillmentPreviewError.Response,
            [_auth.WalletAuth],
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Returns a list of fulfillment orders fulfilled after (or at) a specified date
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="ListAllFulfillmentOrdersResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="ListAllFulfillmentOrdersError"/> when the server returns an error response.</exception>
    public Task<ListAllFulfillmentOrdersResponse> ListAllFulfillmentOrders(ListAllFulfillmentOrdersRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default1("/wfs/outbound/v4/fulfillmentOrders"),
            [],
            [
                new Param("queryStartDate", request.QueryStartDate?.ToIso8601()),
                new Param("nextToken", request.NextToken),
            ],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<ListAllFulfillmentOrdersResponse>(),
            ListAllFulfillmentOrdersError.Response,
            [_auth.WalletAuth],
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Updates and/or requests shipment for a fulfillment order with an INCOMPLETE status
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="UpdateFulfillmentOrderResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="UpdateFulfillmentOrderError"/> when the server returns an error response.</exception>
    public Task<UpdateFulfillmentOrderResponse> UpdateFulfillmentOrder(UpdateFulfillmentOrderOperationRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default1("/wfs/outbound/v4/fulfillmentOrders/{sellerFulfillmentOrderId}"),
            [new TemplateParam("sellerFulfillmentOrderId", request.SellerFulfillmentOrderId)],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Put,
            JsonRequest.Create(request.Body),
            JsonResponse.Create<UpdateFulfillmentOrderResponse>(),
            UpdateFulfillmentOrderError.Response,
            [_auth.WalletAuth],
            requestOptions,
            cancellationToken);
}
