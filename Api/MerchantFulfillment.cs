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
using WalmartApIs.Models.Enums;

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
    /// <param name="shipmentId"></param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="CancelShipmentResponse"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="CancelShipmentError"/> when the server returns an error response.</exception>
    public Task<CancelShipmentResponse> CancelShipment(string shipmentId,
        RequestOptions? requestOptions = null,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default1("/mfn/v4/shipments/{shipmentId}"),
            [new TemplateParam("shipmentId", shipmentId)],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Delete,
            EmptyBody.Instance,
            JsonResponse.Create<CancelShipmentResponse>(),
            CancelShipmentErrorResponse.Instance,
            [_auth.WalletAuth],
            requestOptions,
            ct);

    /// <summary>
    /// Purchases shipping and returns a shipping label
    /// </summary>
    /// <param name="body"></param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="CreateShipmentResponse"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="CreateShipmentError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Creates a shipment for an order, purchases a shipping label from the
    /// selected carrier, and returns the label for printing.
    /// </remarks>
    public Task<CreateShipmentResponse> CreateShipment(CreateShipmentRequest body,
        RequestOptions? requestOptions = null,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default1("/mfn/v4/shipments"),
            [],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Post,
            JsonRequest.Create(body),
            JsonResponse.Create<CreateShipmentResponse>(),
            CreateShipmentErrorResponse.Instance,
            [_auth.WalletAuth],
            requestOptions,
            ct);

    /// <summary>
    /// Returns a list of shipping service offers
    /// </summary>
    /// <param name="body"></param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="GetEligibleShippingServicesResponse"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="GetEligibleShippingServicesError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Returns available carriers and rates for a shipment based on package
    /// dimensions, weight, and destination address.
    /// </remarks>
    public Task<GetEligibleShippingServicesResponse> GetEligibleShippingServices(GetEligibleShippingServicesRequest body,
        RequestOptions? requestOptions = null,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default1("/mfn/v4/eligibleShippingServices"),
            [],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Post,
            JsonRequest.Create(body),
            JsonResponse.Create<GetEligibleShippingServicesResponse>(),
            GetEligibleShippingServicesErrorResponse.Instance,
            [_auth.WalletAuth],
            requestOptions,
            ct);

    /// <summary>
    /// Returns the shipping label for an existing shipment
    /// </summary>
    /// <param name="shipmentId"></param>
    /// <param name="format"></param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="Label"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="GetLabelError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Returns the purchased shipping label for a shipment in the requested
    /// file format for printing.
    /// </remarks>
    public Task<Label> GetLabel(string shipmentId,
        Format? format,
        RequestOptions? requestOptions = null,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default1("/mfn/v4/shipments/{shipmentId}/label"),
            [new TemplateParam("shipmentId", shipmentId)],
            [new Param("format", format)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<Label>(),
            GetLabelErrorResponse.Instance,
            [_auth.WalletAuth],
            requestOptions,
            ct);

    /// <summary>
    /// Returns the shipment information for an existing shipment
    /// </summary>
    /// <param name="shipmentId"></param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="GetShipmentResponse"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="GetShipment2Error"/> when the server returns an error response.</exception>
    public Task<GetShipmentResponse> GetShipment2(string shipmentId,
        RequestOptions? requestOptions = null,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default1("/mfn/v4/shipments/{shipmentId}"),
            [new TemplateParam("shipmentId", shipmentId)],
            [],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<GetShipmentResponse>(),
            GetShipment2ErrorResponse.Instance,
            [_auth.WalletAuth],
            requestOptions,
            ct);
}
