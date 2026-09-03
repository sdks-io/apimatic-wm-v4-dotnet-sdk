using System;
using System.Collections.Generic;
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

namespace WalmartApIs.Api;

public sealed class WfsInbound
{
    private readonly RawClient _rawClient;
    private readonly Server _server;
    private readonly AuthSchemes _auth;

    internal WfsInbound(RawClient rawClient, Server server, AuthSchemes auth)
    {
        _rawClient = rawClient;
        _server = server;
        _auth = auth;
    }

    /// <summary>
    /// Cancels an inbound plan. The inbound plan must be in a state that allows cancellation.
    /// </summary>
    /// <param name="inboundPlanId">Identifier of an inbound plan.</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="CancelInboundPlanResponse"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="CancelInboundPlanError"/> when the server returns an error response.</exception>
    public Task<CancelInboundPlanResponse> CancelInboundPlan(string inboundPlanId,
        RequestOptions? requestOptions = null,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default1("/inbound/wfs/v4/inboundPlans/{inboundPlanId}/cancellation"),
            [new TemplateParam("inboundPlanId", inboundPlanId)],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Put,
            EmptyBody.Instance,
            JsonResponse.Create<CancelInboundPlanResponse>(),
            CancelInboundPlanErrorResponse.Instance,
            [_auth.WalletAuth],
            requestOptions,
            ct);

    /// <summary>
    /// Cancels a self-ship appointment for a shipment.
    /// </summary>
    /// <param name="inboundPlanId">Identifier of an inbound plan.</param>
    /// <param name="shipmentId">Identifier of a shipment.</param>
    /// <param name="body"></param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="CancelInboundPlanResponse"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="CancelSelfShipAppointmentError"/> when the server returns an error response.</exception>
    public Task<CancelInboundPlanResponse> CancelSelfShipAppointment(string inboundPlanId,
        string shipmentId,
        CancelSelfShipAppointmentRequest body,
        RequestOptions? requestOptions = null,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default1("/inbound/wfs/v4/inboundPlans/{inboundPlanId}/shipments/{shipmentId}/selfShipAppointmentCancellation"),
            [new TemplateParam("inboundPlanId", inboundPlanId), new TemplateParam("shipmentId", shipmentId)],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Put,
            JsonRequest.Create(body),
            JsonResponse.Create<CancelInboundPlanResponse>(),
            CancelSelfShipAppointmentErrorResponse.Instance,
            [_auth.WalletAuth],
            requestOptions,
            ct);

    /// <summary>
    /// Confirms the delivery window option for a shipment.
    /// </summary>
    /// <param name="inboundPlanId">Identifier of an inbound plan.</param>
    /// <param name="shipmentId">The shipment to confirm the delivery window option for.</param>
    /// <param name="deliveryWindowOptionId">The ID of the delivery window option to be confirmed.</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="CancelInboundPlanResponse"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="ConfirmDeliveryWindowOptionsError"/> when the server returns an error response.</exception>
    public Task<CancelInboundPlanResponse> ConfirmDeliveryWindowOptions(string inboundPlanId,
        string shipmentId,
        string deliveryWindowOptionId,
        RequestOptions? requestOptions = null,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default1("/inbound/wfs/v4/inboundPlans/{inboundPlanId}/shipments/{shipmentId}/deliveryWindowOptions/{deliveryWindowOptionId}/confirmation"),
            [new TemplateParam("inboundPlanId", inboundPlanId),
                new TemplateParam("shipmentId", shipmentId),
                new TemplateParam("deliveryWindowOptionId", deliveryWindowOptionId)],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Post,
            EmptyBody.Instance,
            JsonResponse.Create<CancelInboundPlanResponse>(),
            ConfirmDeliveryWindowOptionsErrorResponse.Instance,
            [_auth.WalletAuth],
            requestOptions,
            ct);

    /// <summary>
    /// Confirms the packing option for an inbound plan.
    /// </summary>
    /// <param name="inboundPlanId">Identifier of an inbound plan.</param>
    /// <param name="packingOptionId">Identifier of a packing option.</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="CancelInboundPlanResponse"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="ConfirmPackingOptionError"/> when the server returns an error response.</exception>
    public Task<CancelInboundPlanResponse> ConfirmPackingOption(string inboundPlanId,
        string packingOptionId,
        RequestOptions? requestOptions = null,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default1("/inbound/wfs/v4/inboundPlans/{inboundPlanId}/packingOptions/{packingOptionId}/confirmation"),
            [new TemplateParam("inboundPlanId", inboundPlanId), new TemplateParam("packingOptionId", packingOptionId)],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Post,
            EmptyBody.Instance,
            JsonResponse.Create<CancelInboundPlanResponse>(),
            ConfirmPackingOptionErrorResponse.Instance,
            [_auth.WalletAuth],
            requestOptions,
            ct);

    /// <summary>
    /// Confirms a placement option for an inbound plan.
    /// </summary>
    /// <param name="inboundPlanId">Identifier of an inbound plan.</param>
    /// <param name="placementOptionId">The identifier of a placement option.</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="CancelInboundPlanResponse"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="ConfirmPlacementOptionError"/> when the server returns an error response.</exception>
    public Task<CancelInboundPlanResponse> ConfirmPlacementOption(string inboundPlanId,
        string placementOptionId,
        RequestOptions? requestOptions = null,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default1("/inbound/wfs/v4/inboundPlans/{inboundPlanId}/placementOptions/{placementOptionId}/confirmation"),
            [new TemplateParam("inboundPlanId", inboundPlanId),
                new TemplateParam("placementOptionId", placementOptionId)],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Post,
            EmptyBody.Instance,
            JsonResponse.Create<CancelInboundPlanResponse>(),
            ConfirmPlacementOptionErrorResponse.Instance,
            [_auth.WalletAuth],
            requestOptions,
            ct);

    /// <summary>
    /// Confirms a shipment content update preview and applies the changes to the shipment.
    /// </summary>
    /// <param name="inboundPlanId">Identifier of an inbound plan.</param>
    /// <param name="shipmentId">Identifier of a shipment.</param>
    /// <param name="contentUpdatePreviewId">Identifier of a content update preview.</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="CancelInboundPlanResponse"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="ConfirmShipmentContentUpdatePreviewError"/> when the server returns an error response.</exception>
    public Task<CancelInboundPlanResponse> ConfirmShipmentContentUpdatePreview(string inboundPlanId,
        string shipmentId,
        string contentUpdatePreviewId,
        RequestOptions? requestOptions = null,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default1("/inbound/wfs/v4/inboundPlans/{inboundPlanId}/shipments/{shipmentId}/contentUpdatePreviews/{contentUpdatePreviewId}/confirmation"),
            [new TemplateParam("inboundPlanId", inboundPlanId),
                new TemplateParam("shipmentId", shipmentId),
                new TemplateParam("contentUpdatePreviewId", contentUpdatePreviewId)],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Post,
            EmptyBody.Instance,
            JsonResponse.Create<CancelInboundPlanResponse>(),
            ConfirmShipmentContentUpdatePreviewErrorResponse.Instance,
            [_auth.WalletAuth],
            requestOptions,
            ct);

    /// <summary>
    /// Confirms the transportation options for an inbound plan.
    /// </summary>
    /// <param name="inboundPlanId">Identifier of an inbound plan.</param>
    /// <param name="body"></param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="CancelInboundPlanResponse"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="ConfirmTransportationOptionsError"/> when the server returns an error response.</exception>
    public Task<CancelInboundPlanResponse> ConfirmTransportationOptions(string inboundPlanId,
        ConfirmTransportationOptionsRequest body,
        RequestOptions? requestOptions = null,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default1("/inbound/wfs/v4/inboundPlans/{inboundPlanId}/transportationOptions/confirmation"),
            [new TemplateParam("inboundPlanId", inboundPlanId)],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Post,
            JsonRequest.Create(body),
            JsonResponse.Create<CancelInboundPlanResponse>(),
            ConfirmTransportationOptionsErrorResponse.Instance,
            [_auth.WalletAuth],
            requestOptions,
            ct);

    /// <summary>
    /// Creates an inbound plan. An inbound plan contains all the necessary information to send shipments into Walmart's fulfillment network.
    /// </summary>
    /// <param name="body"></param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="CreateInboundPlanResponse"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="CreateInboundPlanError"/> when the server returns an error response.</exception>
    public Task<CreateInboundPlanResponse> CreateInboundPlan(CreateInboundPlanRequest body,
        RequestOptions? requestOptions = null,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default1("/inbound/wfs/v4/inboundPlans"),
            [],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Post,
            JsonRequest.Create(body),
            JsonResponse.Create<CreateInboundPlanResponse>(),
            CreateInboundPlanErrorResponse.Instance,
            [_auth.WalletAuth],
            requestOptions,
            ct);

    /// <summary>
    /// Creates item labels for a given list of MSKUs.
    /// </summary>
    /// <param name="body"></param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="CreateMarketplaceItemLabelsResponse"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="CreateMarketplaceItemLabelsError"/> when the server returns an error response.</exception>
    public Task<CreateMarketplaceItemLabelsResponse> CreateMarketplaceItemLabels(CreateMarketplaceItemLabelsRequest body,
        RequestOptions? requestOptions = null,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default1("/inbound/wfs/v4/items/labels"),
            [],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Post,
            JsonRequest.Create(body),
            JsonResponse.Create<CreateMarketplaceItemLabelsResponse>(),
            CreateMarketplaceItemLabelsErrorResponse.Instance,
            [_auth.WalletAuth],
            requestOptions,
            ct);

    /// <summary>
    /// Generates delivery window options for a given shipment. This is an asynchronous operation.
    /// </summary>
    /// <param name="inboundPlanId">Identifier of an inbound plan.</param>
    /// <param name="shipmentId">The shipment to generate delivery window options for.</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="CancelInboundPlanResponse"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="GenerateDeliveryWindowOptionsError"/> when the server returns an error response.</exception>
    public Task<CancelInboundPlanResponse> GenerateDeliveryWindowOptions(string inboundPlanId,
        string shipmentId,
        RequestOptions? requestOptions = null,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default1("/inbound/wfs/v4/inboundPlans/{inboundPlanId}/shipments/{shipmentId}/deliveryWindowOptions"),
            [new TemplateParam("inboundPlanId", inboundPlanId), new TemplateParam("shipmentId", shipmentId)],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Post,
            EmptyBody.Instance,
            JsonResponse.Create<CancelInboundPlanResponse>(),
            GenerateDeliveryWindowOptionsErrorResponse.Instance,
            [_auth.WalletAuth],
            requestOptions,
            ct);

    /// <summary>
    /// Generates packing options for an inbound plan. This is an asynchronous operation.
    /// </summary>
    /// <param name="inboundPlanId">Identifier of an inbound plan.</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="CancelInboundPlanResponse"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="GeneratePackingOptionsError"/> when the server returns an error response.</exception>
    public Task<CancelInboundPlanResponse> GeneratePackingOptions(string inboundPlanId,
        RequestOptions? requestOptions = null,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default1("/inbound/wfs/v4/inboundPlans/{inboundPlanId}/packingOptions"),
            [new TemplateParam("inboundPlanId", inboundPlanId)],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Post,
            EmptyBody.Instance,
            JsonResponse.Create<CancelInboundPlanResponse>(),
            GeneratePackingOptionsErrorResponse.Instance,
            [_auth.WalletAuth],
            requestOptions,
            ct);

    /// <summary>
    /// Generates placement options for an inbound plan. This is an asynchronous operation.
    /// </summary>
    /// <param name="inboundPlanId">Identifier of an inbound plan.</param>
    /// <param name="body"></param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="CancelInboundPlanResponse"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="GeneratePlacementOptionsError"/> when the server returns an error response.</exception>
    public Task<CancelInboundPlanResponse> GeneratePlacementOptions(string inboundPlanId,
        GeneratePlacementOptionsRequest body,
        RequestOptions? requestOptions = null,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default1("/inbound/wfs/v4/inboundPlans/{inboundPlanId}/placementOptions"),
            [new TemplateParam("inboundPlanId", inboundPlanId)],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Post,
            JsonRequest.Create(body),
            JsonResponse.Create<CancelInboundPlanResponse>(),
            GeneratePlacementOptionsErrorResponse.Instance,
            [_auth.WalletAuth],
            requestOptions,
            ct);

    /// <summary>
    /// Generates a list of self-ship appointment slots for a given shipment. This is an asynchronous operation.
    /// </summary>
    /// <param name="inboundPlanId">Identifier of an inbound plan.</param>
    /// <param name="shipmentId">Identifier of a shipment.</param>
    /// <param name="body"></param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="CancelInboundPlanResponse"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="GenerateSelfShipAppointmentSlotsError"/> when the server returns an error response.</exception>
    public Task<CancelInboundPlanResponse> GenerateSelfShipAppointmentSlots(string inboundPlanId,
        string shipmentId,
        GenerateSelfShipAppointmentSlotsRequest body,
        RequestOptions? requestOptions = null,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default1("/inbound/wfs/v4/inboundPlans/{inboundPlanId}/shipments/{shipmentId}/selfShipAppointmentSlots"),
            [new TemplateParam("inboundPlanId", inboundPlanId), new TemplateParam("shipmentId", shipmentId)],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Post,
            JsonRequest.Create(body),
            JsonResponse.Create<CancelInboundPlanResponse>(),
            GenerateSelfShipAppointmentSlotsErrorResponse.Instance,
            [_auth.WalletAuth],
            requestOptions,
            ct);

    /// <summary>
    /// Generates content update previews for a given shipment and set of intended updates.
    /// </summary>
    /// <param name="inboundPlanId">Identifier of an inbound plan.</param>
    /// <param name="shipmentId">Identifier of a shipment.</param>
    /// <param name="body"></param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="CancelInboundPlanResponse"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="GenerateShipmentContentUpdatePreviewsError"/> when the server returns an error response.</exception>
    public Task<CancelInboundPlanResponse> GenerateShipmentContentUpdatePreviews(string inboundPlanId,
        string shipmentId,
        GenerateShipmentContentUpdatePreviewsRequest body,
        RequestOptions? requestOptions = null,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default1("/inbound/wfs/v4/inboundPlans/{inboundPlanId}/shipments/{shipmentId}/contentUpdatePreviews"),
            [new TemplateParam("inboundPlanId", inboundPlanId), new TemplateParam("shipmentId", shipmentId)],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Post,
            JsonRequest.Create(body),
            JsonResponse.Create<CancelInboundPlanResponse>(),
            GenerateShipmentContentUpdatePreviewsErrorResponse.Instance,
            [_auth.WalletAuth],
            requestOptions,
            ct);

    /// <summary>
    /// Generates transportation options for a placement option. This is an asynchronous operation.
    /// </summary>
    /// <param name="inboundPlanId">Identifier of an inbound plan.</param>
    /// <param name="body"></param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="CancelInboundPlanResponse"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="GenerateTransportationOptionsError"/> when the server returns an error response.</exception>
    public Task<CancelInboundPlanResponse> GenerateTransportationOptions(string inboundPlanId,
        GenerateTransportationOptionsRequest body,
        RequestOptions? requestOptions = null,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default1("/inbound/wfs/v4/inboundPlans/{inboundPlanId}/transportationOptions"),
            [new TemplateParam("inboundPlanId", inboundPlanId)],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Post,
            JsonRequest.Create(body),
            JsonResponse.Create<CancelInboundPlanResponse>(),
            GenerateTransportationOptionsErrorResponse.Instance,
            [_auth.WalletAuth],
            requestOptions,
            ct);

    /// <summary>
    /// Returns the delivery challan document for a given shipment.
    /// </summary>
    /// <param name="inboundPlanId">Identifier of an inbound plan.</param>
    /// <param name="shipmentId">Identifier of a shipment.</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="GetDeliveryChallanDocumentResponse"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="GetDeliveryChallanDocumentError"/> when the server returns an error response.</exception>
    public Task<GetDeliveryChallanDocumentResponse> GetDeliveryChallanDocument(string inboundPlanId,
        string shipmentId,
        RequestOptions? requestOptions = null,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default1("/inbound/wfs/v4/inboundPlans/{inboundPlanId}/shipments/{shipmentId}/deliveryChallanDocument"),
            [new TemplateParam("inboundPlanId", inboundPlanId), new TemplateParam("shipmentId", shipmentId)],
            [],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<GetDeliveryChallanDocumentResponse>(),
            GetDeliveryChallanDocumentErrorResponse.Instance,
            [_auth.WalletAuth],
            requestOptions,
            ct);

    /// <summary>
    /// Returns the status of an asynchronous WFS inbound operation.
    /// </summary>
    /// <param name="operationId">Identifier of an asynchronous operation.</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="CommonInboundOperationStatus"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="GetInboundOperationStatusError"/> when the server returns an error response.</exception>
    public Task<CommonInboundOperationStatus> GetInboundOperationStatus(string operationId,
        RequestOptions? requestOptions = null,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default1("/inbound/wfs/v4/operations/{operationId}"),
            [new TemplateParam("operationId", operationId)],
            [],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<CommonInboundOperationStatus>(),
            GetInboundOperationStatusErrorResponse.Instance,
            [_auth.WalletAuth],
            requestOptions,
            ct);

    /// <summary>
    /// Fetches the details of an inbound plan.
    /// </summary>
    /// <param name="inboundPlanId">Identifier of an inbound plan.</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="InboundPlan"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="GetInboundPlanError"/> when the server returns an error response.</exception>
    public Task<InboundPlan> GetInboundPlan(string inboundPlanId,
        RequestOptions? requestOptions = null,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default1("/inbound/wfs/v4/inboundPlans/{inboundPlanId}"),
            [new TemplateParam("inboundPlanId", inboundPlanId)],
            [],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<InboundPlan>(),
            GetInboundPlanErrorResponse.Instance,
            [_auth.WalletAuth],
            requestOptions,
            ct);

    /// <summary>
    /// Retrieves a list of self-ship appointment slots for a shipment.
    /// </summary>
    /// <param name="inboundPlanId">Identifier of an inbound plan.</param>
    /// <param name="shipmentId">Identifier of a shipment.</param>
    /// <param name="pageSize">The number of self ship appointment slots to return in the response matching the given query.</param>
    /// <param name="paginationToken">A token to fetch a certain page when there are multiple pages worth of results.</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="GetSelfShipAppointmentSlotsResponse"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="GetSelfShipAppointmentSlotsError"/> when the server returns an error response.</exception>
    public Task<GetSelfShipAppointmentSlotsResponse> GetSelfShipAppointmentSlots(string inboundPlanId,
        string shipmentId,
        int? pageSize,
        string? paginationToken,
        RequestOptions? requestOptions = null,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default1("/inbound/wfs/v4/inboundPlans/{inboundPlanId}/shipments/{shipmentId}/selfShipAppointmentSlots"),
            [new TemplateParam("inboundPlanId", inboundPlanId), new TemplateParam("shipmentId", shipmentId)],
            [new Param("pageSize", pageSize), new Param("paginationToken", paginationToken)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<GetSelfShipAppointmentSlotsResponse>(),
            GetSelfShipAppointmentSlotsErrorResponse.Instance,
            [_auth.WalletAuth],
            requestOptions,
            ct);

    /// <summary>
    /// Provides the full details of a shipment within an inbound plan.
    /// </summary>
    /// <param name="inboundPlanId">Identifier of an inbound plan.</param>
    /// <param name="shipmentId">Identifier of a shipment. A shipment contains the boxes and units being inbounded.</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="CommonShipment"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="GetShipmentError"/> when the server returns an error response.</exception>
    public Task<CommonShipment> GetShipment(string inboundPlanId,
        string shipmentId,
        RequestOptions? requestOptions = null,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default1("/inbound/wfs/v4/inboundPlans/{inboundPlanId}/shipments/{shipmentId}"),
            [new TemplateParam("inboundPlanId", inboundPlanId), new TemplateParam("shipmentId", shipmentId)],
            [],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<CommonShipment>(),
            GetShipmentErrorResponse.Instance,
            [_auth.WalletAuth],
            requestOptions,
            ct);

    /// <summary>
    /// Retrieves the full details of a specific content update preview.
    /// </summary>
    /// <param name="inboundPlanId">Identifier of an inbound plan.</param>
    /// <param name="shipmentId">Identifier of a shipment.</param>
    /// <param name="contentUpdatePreviewId">Identifier of a content update preview.</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="CommonContentUpdatePreview"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="GetShipmentContentUpdatePreviewError"/> when the server returns an error response.</exception>
    public Task<CommonContentUpdatePreview> GetShipmentContentUpdatePreview(string inboundPlanId,
        string shipmentId,
        string contentUpdatePreviewId,
        RequestOptions? requestOptions = null,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default1("/inbound/wfs/v4/inboundPlans/{inboundPlanId}/shipments/{shipmentId}/contentUpdatePreviews/{contentUpdatePreviewId}"),
            [new TemplateParam("inboundPlanId", inboundPlanId),
                new TemplateParam("shipmentId", shipmentId),
                new TemplateParam("contentUpdatePreviewId", contentUpdatePreviewId)],
            [],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<CommonContentUpdatePreview>(),
            GetShipmentContentUpdatePreviewErrorResponse.Instance,
            [_auth.WalletAuth],
            requestOptions,
            ct);

    /// <summary>
    /// Retrieves a paginated list of delivery window options for a shipment.
    /// </summary>
    /// <param name="inboundPlanId">Identifier of an inbound plan.</param>
    /// <param name="shipmentId">The shipment to get delivery window options for.</param>
    /// <param name="pageSize">The number of delivery window options to return in the response matching the given query.</param>
    /// <param name="paginationToken">A token to fetch a certain page when there are multiple pages worth of results.</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="ListDeliveryWindowOptionsResponse"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="ListDeliveryWindowOptionsError"/> when the server returns an error response.</exception>
    public Task<ListDeliveryWindowOptionsResponse> ListDeliveryWindowOptions(string inboundPlanId,
        string shipmentId,
        int? pageSize,
        string? paginationToken,
        RequestOptions? requestOptions = null,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default1("/inbound/wfs/v4/inboundPlans/{inboundPlanId}/shipments/{shipmentId}/deliveryWindowOptions"),
            [new TemplateParam("inboundPlanId", inboundPlanId), new TemplateParam("shipmentId", shipmentId)],
            [new Param("pageSize", pageSize), new Param("paginationToken", paginationToken)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<ListDeliveryWindowOptionsResponse>(),
            ListDeliveryWindowOptionsErrorResponse.Instance,
            [_auth.WalletAuth],
            requestOptions,
            ct);

    /// <summary>
    /// Provides a paginated list of box packages in an inbound plan.
    /// </summary>
    /// <param name="inboundPlanId">Identifier of an inbound plan.</param>
    /// <param name="pageSize">The number of boxes to return in the response matching the given query.</param>
    /// <param name="paginationToken">A token to fetch a certain page when there are multiple pages worth of results.</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="ListInboundPlanBoxesResponse"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="ListInboundPlanBoxesError"/> when the server returns an error response.</exception>
    public Task<ListInboundPlanBoxesResponse> ListInboundPlanBoxes(string inboundPlanId,
        int? pageSize,
        string? paginationToken,
        RequestOptions? requestOptions = null,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default1("/inbound/wfs/v4/inboundPlans/{inboundPlanId}/boxes"),
            [new TemplateParam("inboundPlanId", inboundPlanId)],
            [new Param("pageSize", pageSize), new Param("paginationToken", paginationToken)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<ListInboundPlanBoxesResponse>(),
            ListInboundPlanBoxesErrorResponse.Instance,
            [_auth.WalletAuth],
            requestOptions,
            ct);

    /// <summary>
    /// Provides a paginated list of item packages in an inbound plan.
    /// </summary>
    /// <param name="inboundPlanId">Identifier of an inbound plan.</param>
    /// <param name="pageSize">The number of items to return in the response matching the given query.</param>
    /// <param name="paginationToken">A token to fetch a certain page when there are multiple pages worth of results.</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="ListInboundPlanItemsResponse"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="ListInboundPlanItemsError"/> when the server returns an error response.</exception>
    public Task<ListInboundPlanItemsResponse> ListInboundPlanItems(string inboundPlanId,
        int? pageSize,
        string? paginationToken,
        RequestOptions? requestOptions = null,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default1("/inbound/wfs/v4/inboundPlans/{inboundPlanId}/items"),
            [new TemplateParam("inboundPlanId", inboundPlanId)],
            [new Param("pageSize", pageSize), new Param("paginationToken", paginationToken)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<ListInboundPlanItemsResponse>(),
            ListInboundPlanItemsErrorResponse.Instance,
            [_auth.WalletAuth],
            requestOptions,
            ct);

    /// <summary>
    /// Provides a paginated list of pallet packages in an inbound plan.
    /// </summary>
    /// <param name="inboundPlanId">Identifier of an inbound plan.</param>
    /// <param name="pageSize">The number of pallets to return in the response matching the given query.</param>
    /// <param name="paginationToken">A token to fetch a certain page when there are multiple pages worth of results.</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="ListInboundPlanPalletsResponse"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="ListInboundPlanPalletsError"/> when the server returns an error response.</exception>
    public Task<ListInboundPlanPalletsResponse> ListInboundPlanPallets(string inboundPlanId,
        int? pageSize,
        string? paginationToken,
        RequestOptions? requestOptions = null,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default1("/inbound/wfs/v4/inboundPlans/{inboundPlanId}/pallets"),
            [new TemplateParam("inboundPlanId", inboundPlanId)],
            [new Param("pageSize", pageSize), new Param("paginationToken", paginationToken)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<ListInboundPlanPalletsResponse>(),
            ListInboundPlanPalletsErrorResponse.Instance,
            [_auth.WalletAuth],
            requestOptions,
            ct);

    /// <summary>
    /// Returns a list of inbound plans with minimal information.
    /// </summary>
    /// <param name="paginationToken">A token to fetch a certain page when there are multiple pages worth of results.</param>
    /// <param name="status">The status of an inbound plan. Possible values: <c>ACTIVE</c>, <c>VOIDED</c>, <c>SHIPPED</c>, <c>ERRORED</c>.</param>
    /// <param name="sortBy">Sort by field.</param>
    /// <param name="sortOrder">The sort order. Possible values: <c>ASC</c>, <c>DESC</c>.</param>
    /// <param name="pageSize">The number of inbound plans to return in the response matching the given query.</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="ListInboundPlansResponse"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="ListInboundPlansError"/> when the server returns an error response.</exception>
    public Task<ListInboundPlansResponse> ListInboundPlans(string? paginationToken,
        string? status,
        string? sortBy,
        string? sortOrder,
        int? pageSize = 10,
        RequestOptions? requestOptions = null,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default1("/inbound/wfs/v4/inboundPlans"),
            [],
            [new Param("pageSize", pageSize),
                new Param("paginationToken", paginationToken),
                new Param("status", status),
                new Param("sortBy", sortBy),
                new Param("sortOrder", sortOrder)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<ListInboundPlansResponse>(),
            ListInboundPlansErrorResponse.Instance,
            [_auth.WalletAuth],
            requestOptions,
            ct);

    /// <summary>
    /// List compliance details for a given list of MSKUs.
    /// </summary>
    /// <param name="mskus">A list of merchant SKUs, a merchant-supplied identifier of a specific SKU.</param>
    /// <param name="marketplaceId">The Walmart Marketplace ID. For a list of possible values, refer to <see href="https://developer-docs.walmart.com/seller-api/docs/marketplace-ids">Marketplace IDs</see>.</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="ListItemComplianceDetailsResponse"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="ListItemComplianceDetailsError"/> when the server returns an error response.</exception>
    public Task<ListItemComplianceDetailsResponse> ListItemComplianceDetails(IReadOnlyList<string> mskus,
        string marketplaceId,
        RequestOptions? requestOptions = null,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default1("/inbound/wfs/v4/items/compliance"),
            [],
            [new Param("mskus", mskus), new Param("marketplaceId", marketplaceId)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<ListItemComplianceDetailsResponse>(),
            ListItemComplianceDetailsErrorResponse.Instance,
            [_auth.WalletAuth],
            requestOptions,
            ct);

    /// <summary>
    /// Retrieves a page of boxes in a given packing group.
    /// </summary>
    /// <param name="inboundPlanId">Identifier of an inbound plan.</param>
    /// <param name="packingGroupId">Identifier of a packing group.</param>
    /// <param name="pageSize">The number of packing group boxes to return in the response matching the given query.</param>
    /// <param name="paginationToken">A token to fetch a certain page when there are multiple pages worth of results.</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="ListInboundPlanBoxesResponse"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="ListPackingGroupBoxesError"/> when the server returns an error response.</exception>
    public Task<ListInboundPlanBoxesResponse> ListPackingGroupBoxes(string inboundPlanId,
        string packingGroupId,
        int? pageSize,
        string? paginationToken,
        RequestOptions? requestOptions = null,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default1("/inbound/wfs/v4/inboundPlans/{inboundPlanId}/packingGroups/{packingGroupId}/boxes"),
            [new TemplateParam("inboundPlanId", inboundPlanId), new TemplateParam("packingGroupId", packingGroupId)],
            [new Param("pageSize", pageSize), new Param("paginationToken", paginationToken)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<ListInboundPlanBoxesResponse>(),
            ListPackingGroupBoxesErrorResponse.Instance,
            [_auth.WalletAuth],
            requestOptions,
            ct);

    /// <summary>
    /// Retrieves a page of items in a given packing group.
    /// </summary>
    /// <param name="inboundPlanId">Identifier of an inbound plan.</param>
    /// <param name="packingGroupId">Identifier of a packing group.</param>
    /// <param name="pageSize">The number of packing group items to return in the response matching the given query.</param>
    /// <param name="paginationToken">A token to fetch a certain page when there are multiple pages worth of results.</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="ListInboundPlanItemsResponse"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="ListPackingGroupItemsError"/> when the server returns an error response.</exception>
    public Task<ListInboundPlanItemsResponse> ListPackingGroupItems(string inboundPlanId,
        string packingGroupId,
        int? pageSize,
        string? paginationToken,
        RequestOptions? requestOptions = null,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default1("/inbound/wfs/v4/inboundPlans/{inboundPlanId}/packingGroups/{packingGroupId}/items"),
            [new TemplateParam("inboundPlanId", inboundPlanId), new TemplateParam("packingGroupId", packingGroupId)],
            [new Param("pageSize", pageSize), new Param("paginationToken", paginationToken)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<ListInboundPlanItemsResponse>(),
            ListPackingGroupItemsErrorResponse.Instance,
            [_auth.WalletAuth],
            requestOptions,
            ct);

    /// <summary>
    /// Retrieves a list of packing options for an inbound plan.
    /// </summary>
    /// <param name="inboundPlanId">Identifier of an inbound plan.</param>
    /// <param name="pageSize">The number of packing options to return in the response matching the given query.</param>
    /// <param name="paginationToken">A token to fetch a certain page when there are multiple pages worth of results.</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="ListPackingOptionsResponse"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="ListPackingOptionsError"/> when the server returns an error response.</exception>
    public Task<ListPackingOptionsResponse> ListPackingOptions(string inboundPlanId,
        int? pageSize,
        string? paginationToken,
        RequestOptions? requestOptions = null,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default1("/inbound/wfs/v4/inboundPlans/{inboundPlanId}/packingOptions"),
            [new TemplateParam("inboundPlanId", inboundPlanId)],
            [new Param("pageSize", pageSize), new Param("paginationToken", paginationToken)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<ListPackingOptionsResponse>(),
            ListPackingOptionsErrorResponse.Instance,
            [_auth.WalletAuth],
            requestOptions,
            ct);

    /// <summary>
    /// Retrieves a list of placement options for an inbound plan.
    /// </summary>
    /// <param name="inboundPlanId">Identifier of an inbound plan.</param>
    /// <param name="pageSize">The number of placement options to return in the response matching the given query.</param>
    /// <param name="paginationToken">A token to fetch a certain page when there are multiple pages worth of results.</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="ListPlacementOptionsResponse"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="ListPlacementOptionsError"/> when the server returns an error response.</exception>
    public Task<ListPlacementOptionsResponse> ListPlacementOptions(string inboundPlanId,
        int? pageSize,
        string? paginationToken,
        RequestOptions? requestOptions = null,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default1("/inbound/wfs/v4/inboundPlans/{inboundPlanId}/placementOptions"),
            [new TemplateParam("inboundPlanId", inboundPlanId)],
            [new Param("pageSize", pageSize), new Param("paginationToken", paginationToken)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<ListPlacementOptionsResponse>(),
            ListPlacementOptionsErrorResponse.Instance,
            [_auth.WalletAuth],
            requestOptions,
            ct);

    /// <summary>
    /// Returns prep details for a list of MSKUs.
    /// </summary>
    /// <param name="marketplaceId">The Walmart Marketplace ID. For a list of possible values, refer to <see href="https://developer-docs.walmart.com/seller-api/docs/marketplace-ids">Marketplace IDs</see>.</param>
    /// <param name="mskus">A list of merchant SKUs, a merchant-supplied identifier of a specific SKU.</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="ListPrepDetailsResponse"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="ListPrepDetailsError"/> when the server returns an error response.</exception>
    public Task<ListPrepDetailsResponse> ListPrepDetails(string marketplaceId,
        IReadOnlyList<string> mskus,
        RequestOptions? requestOptions = null,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default1("/inbound/wfs/v4/items/prepDetails"),
            [],
            [new Param("marketplaceId", marketplaceId), new Param("mskus", mskus)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<ListPrepDetailsResponse>(),
            ListPrepDetailsErrorResponse.Instance,
            [_auth.WalletAuth],
            requestOptions,
            ct);

    /// <summary>
    /// Provides a paginated list of box packages in a shipment.
    /// </summary>
    /// <param name="inboundPlanId">Identifier of an inbound plan.</param>
    /// <param name="shipmentId">Identifier of a shipment. A shipment contains the boxes and units being inbounded.</param>
    /// <param name="pageSize">The number of boxes to return in the response matching the given query.</param>
    /// <param name="paginationToken">A token to fetch a certain page when there are multiple pages worth of results.</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="ListInboundPlanBoxesResponse"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="ListShipmentBoxesError"/> when the server returns an error response.</exception>
    public Task<ListInboundPlanBoxesResponse> ListShipmentBoxes(string inboundPlanId,
        string shipmentId,
        int? pageSize,
        string? paginationToken,
        RequestOptions? requestOptions = null,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default1("/inbound/wfs/v4/inboundPlans/{inboundPlanId}/shipments/{shipmentId}/boxes"),
            [new TemplateParam("inboundPlanId", inboundPlanId), new TemplateParam("shipmentId", shipmentId)],
            [new Param("pageSize", pageSize), new Param("paginationToken", paginationToken)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<ListInboundPlanBoxesResponse>(),
            ListShipmentBoxesErrorResponse.Instance,
            [_auth.WalletAuth],
            requestOptions,
            ct);

    /// <summary>
    /// Retrieves a paginated list of content update previews for a given shipment.
    /// </summary>
    /// <param name="inboundPlanId">Identifier of an inbound plan.</param>
    /// <param name="shipmentId">Identifier of a shipment.</param>
    /// <param name="pageSize">The number of content update previews to return.</param>
    /// <param name="paginationToken">A token to fetch a certain page when there are multiple pages worth of results.</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="ListShipmentContentUpdatePreviewsResponse"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="ListShipmentContentUpdatePreviewsError"/> when the server returns an error response.</exception>
    public Task<ListShipmentContentUpdatePreviewsResponse> ListShipmentContentUpdatePreviews(string inboundPlanId,
        string shipmentId,
        int? pageSize,
        string? paginationToken,
        RequestOptions? requestOptions = null,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default1("/inbound/wfs/v4/inboundPlans/{inboundPlanId}/shipments/{shipmentId}/contentUpdatePreviews"),
            [new TemplateParam("inboundPlanId", inboundPlanId), new TemplateParam("shipmentId", shipmentId)],
            [new Param("pageSize", pageSize), new Param("paginationToken", paginationToken)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<ListShipmentContentUpdatePreviewsResponse>(),
            ListShipmentContentUpdatePreviewsErrorResponse.Instance,
            [_auth.WalletAuth],
            requestOptions,
            ct);

    /// <summary>
    /// Provides a paginated list of item packages in a shipment.
    /// </summary>
    /// <param name="inboundPlanId">Identifier of an inbound plan.</param>
    /// <param name="shipmentId">Identifier of a shipment. A shipment contains the boxes and units being inbounded.</param>
    /// <param name="pageSize">The number of items to return in the response matching the given query.</param>
    /// <param name="paginationToken">A token to fetch a certain page when there are multiple pages worth of results.</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="ListInboundPlanItemsResponse"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="ListShipmentItemsError"/> when the server returns an error response.</exception>
    public Task<ListInboundPlanItemsResponse> ListShipmentItems(string inboundPlanId,
        string shipmentId,
        int? pageSize,
        string? paginationToken,
        RequestOptions? requestOptions = null,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default1("/inbound/wfs/v4/inboundPlans/{inboundPlanId}/shipments/{shipmentId}/items"),
            [new TemplateParam("inboundPlanId", inboundPlanId), new TemplateParam("shipmentId", shipmentId)],
            [new Param("pageSize", pageSize), new Param("paginationToken", paginationToken)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<ListInboundPlanItemsResponse>(),
            ListShipmentItemsErrorResponse.Instance,
            [_auth.WalletAuth],
            requestOptions,
            ct);

    /// <summary>
    /// Provides a paginated list of pallet packages in a shipment.
    /// </summary>
    /// <param name="inboundPlanId">Identifier of an inbound plan.</param>
    /// <param name="shipmentId">Identifier of a shipment.</param>
    /// <param name="pageSize">The number of pallets to return in the response matching the given query.</param>
    /// <param name="paginationToken">A token to fetch a certain page when there are multiple pages worth of results.</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="ListInboundPlanPalletsResponse"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="ListShipmentPalletsError"/> when the server returns an error response.</exception>
    public Task<ListInboundPlanPalletsResponse> ListShipmentPallets(string inboundPlanId,
        string shipmentId,
        int? pageSize,
        string? paginationToken,
        RequestOptions? requestOptions = null,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default1("/inbound/wfs/v4/inboundPlans/{inboundPlanId}/shipments/{shipmentId}/pallets"),
            [new TemplateParam("inboundPlanId", inboundPlanId), new TemplateParam("shipmentId", shipmentId)],
            [new Param("pageSize", pageSize), new Param("paginationToken", paginationToken)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<ListInboundPlanPalletsResponse>(),
            ListShipmentPalletsErrorResponse.Instance,
            [_auth.WalletAuth],
            requestOptions,
            ct);

    /// <summary>
    /// Retrieves a list of transportation options for a placement option.
    /// </summary>
    /// <param name="inboundPlanId">Identifier of an inbound plan.</param>
    /// <param name="pageSize">The number of transportation options to return in the response matching the given query.</param>
    /// <param name="paginationToken">A token to fetch a certain page when there are multiple pages worth of results.</param>
    /// <param name="placementOptionId">The placement option to get transportation options for. Either <c>placementOptionId</c> or <c>shipmentId</c> must be specified.</param>
    /// <param name="shipmentId">The shipment to get transportation options for. Either <c>placementOptionId</c> or <c>shipmentId</c> must be specified.</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="ListTransportationOptionsResponse"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="ListTransportationOptionsError"/> when the server returns an error response.</exception>
    public Task<ListTransportationOptionsResponse> ListTransportationOptions(string inboundPlanId,
        int? pageSize,
        string? paginationToken,
        string? placementOptionId,
        string? shipmentId,
        RequestOptions? requestOptions = null,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default1("/inbound/wfs/v4/inboundPlans/{inboundPlanId}/transportationOptions"),
            [new TemplateParam("inboundPlanId", inboundPlanId)],
            [new Param("pageSize", pageSize),
                new Param("paginationToken", paginationToken),
                new Param("placementOptionId", placementOptionId),
                new Param("shipmentId", shipmentId)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<ListTransportationOptionsResponse>(),
            ListTransportationOptionsErrorResponse.Instance,
            [_auth.WalletAuth],
            requestOptions,
            ct);

    /// <summary>
    /// Confirms and schedules a self-ship appointment slot for a shipment.
    /// </summary>
    /// <param name="inboundPlanId">Identifier of an inbound plan.</param>
    /// <param name="shipmentId">Identifier of a shipment.</param>
    /// <param name="slotId">An identifier to a self-ship appointment slot.</param>
    /// <param name="body"></param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="ScheduleSelfShipAppointmentResponse"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="ScheduleSelfShipAppointmentError"/> when the server returns an error response.</exception>
    public Task<ScheduleSelfShipAppointmentResponse> ScheduleSelfShipAppointment(string inboundPlanId,
        string shipmentId,
        string slotId,
        ScheduleSelfShipAppointmentRequest body,
        RequestOptions? requestOptions = null,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default1("/inbound/wfs/v4/inboundPlans/{inboundPlanId}/shipments/{shipmentId}/selfShipAppointmentSlots/{slotId}/schedule"),
            [new TemplateParam("inboundPlanId", inboundPlanId),
                new TemplateParam("shipmentId", shipmentId),
                new TemplateParam("slotId", slotId)],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Post,
            JsonRequest.Create(body),
            JsonResponse.Create<ScheduleSelfShipAppointmentResponse>(),
            ScheduleSelfShipAppointmentErrorResponse.Instance,
            [_auth.WalletAuth],
            requestOptions,
            ct);

    /// <summary>
    /// Sets packing information for an inbound plan.
    /// </summary>
    /// <param name="inboundPlanId">Identifier of an inbound plan.</param>
    /// <param name="body"></param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="CancelInboundPlanResponse"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="SetPackingInformationError"/> when the server returns an error response.</exception>
    public Task<CancelInboundPlanResponse> SetPackingInformation(string inboundPlanId,
        SetPackingInformationRequest body,
        RequestOptions? requestOptions = null,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default1("/inbound/wfs/v4/inboundPlans/{inboundPlanId}/packingInformation"),
            [new TemplateParam("inboundPlanId", inboundPlanId)],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Post,
            JsonRequest.Create(body),
            JsonResponse.Create<CancelInboundPlanResponse>(),
            SetPackingInformationErrorResponse.Instance,
            [_auth.WalletAuth],
            requestOptions,
            ct);

    /// <summary>
    /// Sets prep details for a list of MSKUs.
    /// </summary>
    /// <param name="body"></param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="CancelInboundPlanResponse"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="SetPrepDetailsError"/> when the server returns an error response.</exception>
    public Task<CancelInboundPlanResponse> SetPrepDetails(SetPrepDetailsRequest body,
        RequestOptions? requestOptions = null,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default1("/inbound/wfs/v4/items/prepDetails"),
            [],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Post,
            JsonRequest.Create(body),
            JsonResponse.Create<CancelInboundPlanResponse>(),
            SetPrepDetailsErrorResponse.Instance,
            [_auth.WalletAuth],
            requestOptions,
            ct);

    /// <summary>
    /// Updates the name of an existing inbound plan.
    /// </summary>
    /// <param name="inboundPlanId">Identifier of an inbound plan.</param>
    /// <param name="body"></param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="UpdateInboundPlanNameError"/> when the server returns an error response.</exception>
    public Task UpdateInboundPlanName(string inboundPlanId,
        UpdateInboundPlanNameRequest body,
        RequestOptions? requestOptions = null,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default1("/inbound/wfs/v4/inboundPlans/{inboundPlanId}/name"),
            [new TemplateParam("inboundPlanId", inboundPlanId)],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Put,
            JsonRequest.Create(body),
            VoidResponse.Instance,
            UpdateInboundPlanNameErrorResponse.Instance,
            [_auth.WalletAuth],
            requestOptions,
            ct);

    /// <summary>
    /// Update compliance details for a given MSKU.
    /// </summary>
    /// <param name="marketplaceId">The Walmart Marketplace ID. For a list of possible values, refer to <see href="https://developer-docs.walmart.com/seller-api/docs/marketplace-ids">Marketplace IDs</see>.</param>
    /// <param name="body"></param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="CancelInboundPlanResponse"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="UpdateItemComplianceDetailsError"/> when the server returns an error response.</exception>
    public Task<CancelInboundPlanResponse> UpdateItemComplianceDetails(string marketplaceId,
        UpdateItemComplianceDetailsRequest body,
        RequestOptions? requestOptions = null,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default1("/inbound/wfs/v4/items/compliance"),
            [],
            [new Param("marketplaceId", marketplaceId)],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Put,
            JsonRequest.Create(body),
            JsonResponse.Create<CancelInboundPlanResponse>(),
            UpdateItemComplianceDetailsErrorResponse.Instance,
            [_auth.WalletAuth],
            requestOptions,
            ct);

    /// <summary>
    /// Updates the name of an existing shipment.
    /// </summary>
    /// <param name="inboundPlanId">Identifier of an inbound plan.</param>
    /// <param name="shipmentId">Identifier of a shipment.</param>
    /// <param name="body"></param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="UpdateShipmentNameError"/> when the server returns an error response.</exception>
    public Task UpdateShipmentName(string inboundPlanId,
        string shipmentId,
        UpdateShipmentNameRequest body,
        RequestOptions? requestOptions = null,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default1("/inbound/wfs/v4/inboundPlans/{inboundPlanId}/shipments/{shipmentId}/name"),
            [new TemplateParam("inboundPlanId", inboundPlanId), new TemplateParam("shipmentId", shipmentId)],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Put,
            JsonRequest.Create(body),
            VoidResponse.Instance,
            UpdateShipmentNameErrorResponse.Instance,
            [_auth.WalletAuth],
            requestOptions,
            ct);

    /// <summary>
    /// Updates the source address for a shipment.
    /// </summary>
    /// <param name="inboundPlanId">Identifier of an inbound plan.</param>
    /// <param name="shipmentId">Identifier of a shipment.</param>
    /// <param name="body"></param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="CancelInboundPlanResponse"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="UpdateShipmentSourceAddressError"/> when the server returns an error response.</exception>
    public Task<CancelInboundPlanResponse> UpdateShipmentSourceAddress(string inboundPlanId,
        string shipmentId,
        UpdateShipmentSourceAddressRequest body,
        RequestOptions? requestOptions = null,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default1("/inbound/wfs/v4/inboundPlans/{inboundPlanId}/shipments/{shipmentId}/sourceAddress"),
            [new TemplateParam("inboundPlanId", inboundPlanId), new TemplateParam("shipmentId", shipmentId)],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Put,
            JsonRequest.Create(body),
            JsonResponse.Create<CancelInboundPlanResponse>(),
            UpdateShipmentSourceAddressErrorResponse.Instance,
            [_auth.WalletAuth],
            requestOptions,
            ct);

    /// <summary>
    /// Updates tracking details for a shipment.
    /// </summary>
    /// <param name="inboundPlanId">Identifier of an inbound plan.</param>
    /// <param name="shipmentId">Identifier of a shipment.</param>
    /// <param name="body"></param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="CancelInboundPlanResponse"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="UpdateShipmentTrackingDetailsError"/> when the server returns an error response.</exception>
    public Task<CancelInboundPlanResponse> UpdateShipmentTrackingDetails(string inboundPlanId,
        string shipmentId,
        UpdateShipmentTrackingDetailsRequest body,
        RequestOptions? requestOptions = null,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default1("/inbound/wfs/v4/inboundPlans/{inboundPlanId}/shipments/{shipmentId}/trackingDetails"),
            [new TemplateParam("inboundPlanId", inboundPlanId), new TemplateParam("shipmentId", shipmentId)],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Put,
            JsonRequest.Create(body),
            JsonResponse.Create<CancelInboundPlanResponse>(),
            UpdateShipmentTrackingDetailsErrorResponse.Instance,
            [_auth.WalletAuth],
            requestOptions,
            ct);
}
