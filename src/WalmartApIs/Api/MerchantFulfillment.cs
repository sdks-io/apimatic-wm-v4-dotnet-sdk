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
using WalmartApIs.Requests.MerchantFulfillment;

namespace WalmartApIs.Api;

public sealed class MerchantFulfillment
{
    private readonly RawClient _rawClient;
    private readonly Server _server;
    private readonly AuthSchemes _auth;

    internal MerchantFulfillment(RawClient rawClient, Server server, AuthSchemes auth)
    {
        _rawClient = rawClient;
        _server = server;
        _auth = auth;
    }

    /// <summary>
    /// Cancels a shipment and returns the pre-paid shipping label
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="CancelShipmentResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="CancelShipmentError"/> when the server returns an error response.</exception>
    public Task<CancelShipmentResponse> CancelShipment(CancelShipmentRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default1("/mfn/v4/shipments/{shipmentId}"),
            [new TemplateParam("shipmentId", request.ShipmentId)],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Delete,
            EmptyBody.Instance,
            JsonResponse.Create<CancelShipmentResponse>(),
            CancelShipmentError.Response,
            [_auth.WalletAuth],
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Purchases shipping and returns a shipping label
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="CreateShipmentResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="CreateShipmentError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Creates a shipment for an order, purchases a shipping label from the
    /// selected carrier, and returns the label for printing.
    /// </remarks>
    public Task<CreateShipmentResponse> CreateShipment(CreateShipmentOperationRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default1("/mfn/v4/shipments"),
            [],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Post,
            JsonRequest.Create(request.Body),
            JsonResponse.Create<CreateShipmentResponse>(),
            CreateShipmentError.Response,
            [_auth.WalletAuth],
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Returns a list of shipping service offers
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="GetEligibleShippingServicesResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="GetEligibleShippingServicesError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Returns available carriers and rates for a shipment based on package
    /// dimensions, weight, and destination address.
    /// </remarks>
    public Task<GetEligibleShippingServicesResponse> GetEligibleShippingServices(GetEligibleShippingServicesOperationRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default1("/mfn/v4/eligibleShippingServices"),
            [],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Post,
            JsonRequest.Create(request.Body),
            JsonResponse.Create<GetEligibleShippingServicesResponse>(),
            GetEligibleShippingServicesError.Response,
            [_auth.WalletAuth],
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Returns the shipping label for an existing shipment
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="Label"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="GetLabelError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Returns the purchased shipping label for a shipment in the requested
    /// file format for printing.
    /// </remarks>
    public Task<Label> GetLabel(GetLabelRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default1("/mfn/v4/shipments/{shipmentId}/label"),
            [new TemplateParam("shipmentId", request.ShipmentId)],
            [new Param("format", request.Format)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<Label>(),
            GetLabelError.Response,
            [_auth.WalletAuth],
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Returns the shipment information for an existing shipment
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="GetShipmentResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="GetShipment2Error"/> when the server returns an error response.</exception>
    public Task<GetShipmentResponse> GetShipment2(GetShipment2Request request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default1("/mfn/v4/shipments/{shipmentId}"),
            [new TemplateParam("shipmentId", request.ShipmentId)],
            [],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<GetShipmentResponse>(),
            GetShipment2Error.Response,
            [_auth.WalletAuth],
            requestOptions,
            cancellationToken);
}
