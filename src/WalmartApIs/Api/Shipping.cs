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
using WalmartApIs.Requests.Shipping;

namespace WalmartApIs.Api;

/// <summary>
/// Rate quotes, label purchase, tracking, and delivery for seller shipments.
/// </summary>
public sealed class Shipping
{
    private readonly RawClient _rawClient;
    private readonly Server _server;
    private readonly AuthSchemes _auth;

    internal Shipping(RawClient rawClient, Server server, AuthSchemes auth)
    {
        _rawClient = rawClient;
        _server = server;
        _auth = auth;
    }

    /// <summary>
    /// Cancel a previously-purchased shipment
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="CancelShipmentResponse1"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="CancelShipment2Error"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Cancels a shipment that has not yet shipped. Cancellation
    /// eligibility is carrier-dependent; refer to the response
    /// cancellation status to confirm.
    /// </remarks>
    public Task<CancelShipmentResponse1> CancelShipment2(CancelShipment2Request request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default1("/shipping/v4/shipments/{shipmentId}/cancel"),
            [new TemplateParam("shipmentId", request.ShipmentId)],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Put,
            EmptyBody.Instance,
            JsonResponse.Create<CancelShipmentResponse1>(),
            CancelShipment2Error.Response,
            [_auth.WalletAuth],
            requestOptions,
            cancellationToken);

    /// <summary>
    /// List nearby pickup/dropoff access points
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="GetAccessPointsResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="GetAccessPointsError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Returns access points (pickup and dropoff locations) near the
    /// supplied postal code and country, optionally filtered by access
    /// point type.
    /// </remarks>
    public Task<GetAccessPointsResponse> GetAccessPoints(GetAccessPointsRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default1("/shipping/v4/accessPoints"),
            [],
            [
                new Param("accessPointTypes", request.AccessPointTypes),
                new Param("countryCode", request.CountryCode),
                new Param("postalCode", request.PostalCode),
            ],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<GetAccessPointsResponse>(),
            GetAccessPointsError.Response,
            [_auth.WalletAuth],
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Get the JSON Schema for additional carrier/service inputs
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="GetAdditionalInputsResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="GetAdditionalInputsError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Returns a JSON Schema document describing any
    /// carrier-and-service-specific inputs required to purchase a
    /// shipment for the supplied requestToken + rateId. The schema is
    /// served verbatim and the calling client should validate the
    /// seller's input against it before issuing purchaseShipment.
    /// </remarks>
    public Task<GetAdditionalInputsResponse> GetAdditionalInputs(GetAdditionalInputsRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default1("/shipping/v4/shipments/additionalInputs/schema"),
            [],
            [new Param("rateId", request.RateId), new Param("requestToken", request.RequestToken)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<GetAdditionalInputsResponse>(),
            GetAdditionalInputsError.Response,
            [_auth.WalletAuth],
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Get shipping rate quotes
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="GetFulfillmentOrderResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="GetRatesError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Returns a list of shipping rate quotes for the given shipment
    /// request. The seller can then call purchaseShipment with the
    /// selected rateId to commit to a label purchase.
    /// </remarks>
    public Task<GetFulfillmentOrderResponse> GetRates(GetRatesOperationRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default1("/shipping/v4/shipments/rates"),
            [],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Post,
            JsonRequest.Create(request.Body),
            JsonResponse.Create<GetFulfillmentOrderResponse>(),
            GetRatesError.Response,
            [_auth.WalletAuth],
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Retrieve printable documents for a purchased shipment
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="GetShipmentDocumentsResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="GetShipmentDocumentsError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Returns the label, customs, and other printable documents
    /// associated with a previously-purchased shipment.
    /// </remarks>
    public Task<GetShipmentDocumentsResponse> GetShipmentDocuments(GetShipmentDocumentsRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default1("/shipping/v4/shipments/{shipmentId}/documents"),
            [new TemplateParam("shipmentId", request.ShipmentId)],
            [
                new Param("packageClientReferenceId", request.PackageClientReferenceId),
                new Param("format", request.Format),
            ],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<GetShipmentDocumentsResponse>(),
            GetShipmentDocumentsError.Response,
            [_auth.WalletAuth],
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Get tracking status for a tracked shipment
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="GetTrackingResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="GetTrackingError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Returns the current tracking status, event history, and any
    /// proof-of-delivery details for the given trackingId. TNT
    /// resolves carrier internally from the trackingId alone, so
    /// carrierId is optional -- confirmed unnecessary by the TNT/
    /// Vulcan team (STRIDE-TNT-CORE-PACKAGE-SERVICES) 2026-08-19.
    /// When provided, it's used only as a defense-in-depth check
    /// against the resolved carrier; a mismatch surfaces as 404.
    /// </remarks>
    public Task<GetTrackingResponse> GetTracking(GetTrackingRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default1("/shipping/v4/tracking"),
            [],
            [new Param("trackingId", request.TrackingId), new Param("carrierId", request.CarrierId)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<GetTrackingResponse>(),
            GetTrackingError.Response,
            [_auth.WalletAuth],
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Quote and purchase a shipment in a single call
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="GetFulfillmentOrderShipmentsResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="OneClickShipmentError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Convenience endpoint that combines rate quote and purchase into
    /// a single round trip when the seller already knows the desired
    /// service level. Returns the purchased shipment record directly.
    /// </remarks>
    public Task<GetFulfillmentOrderShipmentsResponse> OneClickShipment(OneClickShipmentOperationRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default1("/shipping/v4/oneClickShipment"),
            [],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Post,
            JsonRequest.Create(request.Body),
            JsonResponse.Create<GetFulfillmentOrderShipmentsResponse>(),
            OneClickShipmentError.Response,
            [_auth.WalletAuth],
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Purchase a shipping label for a previously-quoted rate
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="GetFulfillmentOrderShipmentsResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="PurchaseShipmentError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Purchases the shipping label for the rate selected from a prior
    /// getRates response. Returns the shipment record with label
    /// document references.
    /// </remarks>
    public Task<GetFulfillmentOrderShipmentsResponse> PurchaseShipment(PurchaseShipmentOperationRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default1("/shipping/v4/shipments"),
            [],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Post,
            JsonRequest.Create(request.Body),
            JsonResponse.Create<GetFulfillmentOrderShipmentsResponse>(),
            PurchaseShipmentError.Response,
            [_auth.WalletAuth],
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Submit non-delivery report feedback
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="SubmitNdrFeedbackError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Submits seller feedback on a non-delivery event for a shipment,
    /// instructing the carrier on how to proceed (return, reattempt,
    /// redirect, etc).
    /// </remarks>
    public Task SubmitNdrFeedback(SubmitNdrFeedbackOperationRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default1("/shipping/v4/ndrFeedback"),
            [],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Post,
            JsonRequest.Create(request.Body),
            VoidResponse.Instance,
            SubmitNdrFeedbackError.Response,
            [_auth.WalletAuth],
            requestOptions,
            cancellationToken);
}
