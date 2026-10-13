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
using WalmartApIs.Requests.WfsInbound;

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
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="CancelInboundPlanResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="CancelInboundPlanError"/> when the server returns an error response.</exception>
    public Task<CancelInboundPlanResponse> CancelInboundPlan(CancelInboundPlanRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default1("/inbound/wfs/v4/inboundPlans/{inboundPlanId}/cancellation"),
            [new TemplateParam("inboundPlanId", request.InboundPlanId)],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Put,
            EmptyBody.Instance,
            JsonResponse.Create<CancelInboundPlanResponse>(),
            CancelInboundPlanError.Response,
            [_auth.WalletAuth],
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Cancels a self-ship appointment for a shipment.
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="CancelInboundPlanResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="CancelSelfShipAppointmentError"/> when the server returns an error response.</exception>
    public Task<CancelInboundPlanResponse> CancelSelfShipAppointment(CancelSelfShipAppointmentOperationRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default1(
                "/inbound/wfs/v4/inboundPlans/{inboundPlanId}/shipments/{shipmentId}/selfShipAppointmentCancellation"),
            [
                new TemplateParam("inboundPlanId", request.InboundPlanId),
                new TemplateParam("shipmentId", request.ShipmentId),
            ],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Put,
            JsonRequest.Create(request.Body),
            JsonResponse.Create<CancelInboundPlanResponse>(),
            CancelSelfShipAppointmentError.Response,
            [_auth.WalletAuth],
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Confirms the delivery window option for a shipment.
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="CancelInboundPlanResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="ConfirmDeliveryWindowOptionsError"/> when the server returns an error response.</exception>
    public Task<CancelInboundPlanResponse> ConfirmDeliveryWindowOptions(ConfirmDeliveryWindowOptionsRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default1(
                "/inbound/wfs/v4/inboundPlans/{inboundPlanId}/shipments/{shipmentId}/deliveryWindowOptions/{deliveryWindowOptionId}/confirmation"),
            [
                new TemplateParam("inboundPlanId", request.InboundPlanId),
                new TemplateParam("shipmentId", request.ShipmentId),
                new TemplateParam("deliveryWindowOptionId", request.DeliveryWindowOptionId),
            ],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Post,
            EmptyBody.Instance,
            JsonResponse.Create<CancelInboundPlanResponse>(),
            ConfirmDeliveryWindowOptionsError.Response,
            [_auth.WalletAuth],
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Confirms the packing option for an inbound plan.
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="CancelInboundPlanResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="ConfirmPackingOptionError"/> when the server returns an error response.</exception>
    public Task<CancelInboundPlanResponse> ConfirmPackingOption(ConfirmPackingOptionRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default1(
                "/inbound/wfs/v4/inboundPlans/{inboundPlanId}/packingOptions/{packingOptionId}/confirmation"),
            [
                new TemplateParam("inboundPlanId", request.InboundPlanId),
                new TemplateParam("packingOptionId", request.PackingOptionId),
            ],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Post,
            EmptyBody.Instance,
            JsonResponse.Create<CancelInboundPlanResponse>(),
            ConfirmPackingOptionError.Response,
            [_auth.WalletAuth],
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Confirms a placement option for an inbound plan.
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="CancelInboundPlanResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="ConfirmPlacementOptionError"/> when the server returns an error response.</exception>
    public Task<CancelInboundPlanResponse> ConfirmPlacementOption(ConfirmPlacementOptionRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default1(
                "/inbound/wfs/v4/inboundPlans/{inboundPlanId}/placementOptions/{placementOptionId}/confirmation"),
            [
                new TemplateParam("inboundPlanId", request.InboundPlanId),
                new TemplateParam("placementOptionId", request.PlacementOptionId),
            ],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Post,
            EmptyBody.Instance,
            JsonResponse.Create<CancelInboundPlanResponse>(),
            ConfirmPlacementOptionError.Response,
            [_auth.WalletAuth],
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Confirms a shipment content update preview and applies the changes to the shipment.
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="CancelInboundPlanResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="ConfirmShipmentContentUpdatePreviewError"/> when the server returns an error response.</exception>
    public Task<CancelInboundPlanResponse> ConfirmShipmentContentUpdatePreview(ConfirmShipmentContentUpdatePreviewRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default1(
                "/inbound/wfs/v4/inboundPlans/{inboundPlanId}/shipments/{shipmentId}/contentUpdatePreviews/{contentUpdatePreviewId}/confirmation"),
            [
                new TemplateParam("inboundPlanId", request.InboundPlanId),
                new TemplateParam("shipmentId", request.ShipmentId),
                new TemplateParam("contentUpdatePreviewId", request.ContentUpdatePreviewId),
            ],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Post,
            EmptyBody.Instance,
            JsonResponse.Create<CancelInboundPlanResponse>(),
            ConfirmShipmentContentUpdatePreviewError.Response,
            [_auth.WalletAuth],
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Confirms the transportation options for an inbound plan.
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="CancelInboundPlanResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="ConfirmTransportationOptionsError"/> when the server returns an error response.</exception>
    public Task<CancelInboundPlanResponse> ConfirmTransportationOptions(ConfirmTransportationOptionsOperationRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default1("/inbound/wfs/v4/inboundPlans/{inboundPlanId}/transportationOptions/confirmation"),
            [new TemplateParam("inboundPlanId", request.InboundPlanId)],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Post,
            JsonRequest.Create(request.Body),
            JsonResponse.Create<CancelInboundPlanResponse>(),
            ConfirmTransportationOptionsError.Response,
            [_auth.WalletAuth],
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Creates an inbound plan. An inbound plan contains all the necessary information to send shipments into Walmart's fulfillment network.
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="CreateInboundPlanResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="CreateInboundPlanError"/> when the server returns an error response.</exception>
    public Task<CreateInboundPlanResponse> CreateInboundPlan(CreateInboundPlanOperationRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default1("/inbound/wfs/v4/inboundPlans"),
            [],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Post,
            JsonRequest.Create(request.Body),
            JsonResponse.Create<CreateInboundPlanResponse>(),
            CreateInboundPlanError.Response,
            [_auth.WalletAuth],
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Creates item labels for a given list of MSKUs.
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="CreateMarketplaceItemLabelsResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="CreateMarketplaceItemLabelsError"/> when the server returns an error response.</exception>
    public Task<CreateMarketplaceItemLabelsResponse> CreateMarketplaceItemLabels(CreateMarketplaceItemLabelsOperationRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default1("/inbound/wfs/v4/items/labels"),
            [],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Post,
            JsonRequest.Create(request.Body),
            JsonResponse.Create<CreateMarketplaceItemLabelsResponse>(),
            CreateMarketplaceItemLabelsError.Response,
            [_auth.WalletAuth],
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Generates delivery window options for a given shipment. This is an asynchronous operation.
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="CancelInboundPlanResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="GenerateDeliveryWindowOptionsError"/> when the server returns an error response.</exception>
    public Task<CancelInboundPlanResponse> GenerateDeliveryWindowOptions(GenerateDeliveryWindowOptionsRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default1(
                "/inbound/wfs/v4/inboundPlans/{inboundPlanId}/shipments/{shipmentId}/deliveryWindowOptions"),
            [
                new TemplateParam("inboundPlanId", request.InboundPlanId),
                new TemplateParam("shipmentId", request.ShipmentId),
            ],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Post,
            EmptyBody.Instance,
            JsonResponse.Create<CancelInboundPlanResponse>(),
            GenerateDeliveryWindowOptionsError.Response,
            [_auth.WalletAuth],
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Generates packing options for an inbound plan. This is an asynchronous operation.
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="CancelInboundPlanResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="GeneratePackingOptionsError"/> when the server returns an error response.</exception>
    public Task<CancelInboundPlanResponse> GeneratePackingOptions(GeneratePackingOptionsRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default1("/inbound/wfs/v4/inboundPlans/{inboundPlanId}/packingOptions"),
            [new TemplateParam("inboundPlanId", request.InboundPlanId)],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Post,
            EmptyBody.Instance,
            JsonResponse.Create<CancelInboundPlanResponse>(),
            GeneratePackingOptionsError.Response,
            [_auth.WalletAuth],
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Generates placement options for an inbound plan. This is an asynchronous operation.
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="CancelInboundPlanResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="GeneratePlacementOptionsError"/> when the server returns an error response.</exception>
    public Task<CancelInboundPlanResponse> GeneratePlacementOptions(GeneratePlacementOptionsOperationRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default1("/inbound/wfs/v4/inboundPlans/{inboundPlanId}/placementOptions"),
            [new TemplateParam("inboundPlanId", request.InboundPlanId)],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Post,
            JsonRequest.Create(request.Body),
            JsonResponse.Create<CancelInboundPlanResponse>(),
            GeneratePlacementOptionsError.Response,
            [_auth.WalletAuth],
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Generates a list of self-ship appointment slots for a given shipment. This is an asynchronous operation.
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="CancelInboundPlanResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="GenerateSelfShipAppointmentSlotsError"/> when the server returns an error response.</exception>
    public Task<CancelInboundPlanResponse> GenerateSelfShipAppointmentSlots(GenerateSelfShipAppointmentSlotsOperationRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default1(
                "/inbound/wfs/v4/inboundPlans/{inboundPlanId}/shipments/{shipmentId}/selfShipAppointmentSlots"),
            [
                new TemplateParam("inboundPlanId", request.InboundPlanId),
                new TemplateParam("shipmentId", request.ShipmentId),
            ],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Post,
            JsonRequest.Create(request.Body),
            JsonResponse.Create<CancelInboundPlanResponse>(),
            GenerateSelfShipAppointmentSlotsError.Response,
            [_auth.WalletAuth],
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Generates content update previews for a given shipment and set of intended updates.
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="CancelInboundPlanResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="GenerateShipmentContentUpdatePreviewsError"/> when the server returns an error response.</exception>
    public Task<CancelInboundPlanResponse> GenerateShipmentContentUpdatePreviews(GenerateShipmentContentUpdatePreviewsOperationRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default1(
                "/inbound/wfs/v4/inboundPlans/{inboundPlanId}/shipments/{shipmentId}/contentUpdatePreviews"),
            [
                new TemplateParam("inboundPlanId", request.InboundPlanId),
                new TemplateParam("shipmentId", request.ShipmentId),
            ],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Post,
            JsonRequest.Create(request.Body),
            JsonResponse.Create<CancelInboundPlanResponse>(),
            GenerateShipmentContentUpdatePreviewsError.Response,
            [_auth.WalletAuth],
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Generates transportation options for a placement option. This is an asynchronous operation.
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="CancelInboundPlanResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="GenerateTransportationOptionsError"/> when the server returns an error response.</exception>
    public Task<CancelInboundPlanResponse> GenerateTransportationOptions(GenerateTransportationOptionsOperationRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default1("/inbound/wfs/v4/inboundPlans/{inboundPlanId}/transportationOptions"),
            [new TemplateParam("inboundPlanId", request.InboundPlanId)],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Post,
            JsonRequest.Create(request.Body),
            JsonResponse.Create<CancelInboundPlanResponse>(),
            GenerateTransportationOptionsError.Response,
            [_auth.WalletAuth],
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Returns the delivery challan document for a given shipment.
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="GetDeliveryChallanDocumentResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="GetDeliveryChallanDocumentError"/> when the server returns an error response.</exception>
    public Task<GetDeliveryChallanDocumentResponse> GetDeliveryChallanDocument(GetDeliveryChallanDocumentRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default1(
                "/inbound/wfs/v4/inboundPlans/{inboundPlanId}/shipments/{shipmentId}/deliveryChallanDocument"),
            [
                new TemplateParam("inboundPlanId", request.InboundPlanId),
                new TemplateParam("shipmentId", request.ShipmentId),
            ],
            [],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<GetDeliveryChallanDocumentResponse>(),
            GetDeliveryChallanDocumentError.Response,
            [_auth.WalletAuth],
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Returns the status of an asynchronous WFS inbound operation.
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="CommonInboundOperationStatus"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="GetInboundOperationStatusError"/> when the server returns an error response.</exception>
    public Task<CommonInboundOperationStatus> GetInboundOperationStatus(GetInboundOperationStatusRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default1("/inbound/wfs/v4/operations/{operationId}"),
            [new TemplateParam("operationId", request.OperationId)],
            [],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<CommonInboundOperationStatus>(),
            GetInboundOperationStatusError.Response,
            [_auth.WalletAuth],
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Fetches the details of an inbound plan.
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="InboundPlan"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="GetInboundPlanError"/> when the server returns an error response.</exception>
    public Task<InboundPlan> GetInboundPlan(GetInboundPlanRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default1("/inbound/wfs/v4/inboundPlans/{inboundPlanId}"),
            [new TemplateParam("inboundPlanId", request.InboundPlanId)],
            [],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<InboundPlan>(),
            GetInboundPlanError.Response,
            [_auth.WalletAuth],
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Retrieves a list of self-ship appointment slots for a shipment.
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="GetSelfShipAppointmentSlotsResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="GetSelfShipAppointmentSlotsError"/> when the server returns an error response.</exception>
    public Task<GetSelfShipAppointmentSlotsResponse> GetSelfShipAppointmentSlots(GetSelfShipAppointmentSlotsRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default1(
                "/inbound/wfs/v4/inboundPlans/{inboundPlanId}/shipments/{shipmentId}/selfShipAppointmentSlots"),
            [
                new TemplateParam("inboundPlanId", request.InboundPlanId),
                new TemplateParam("shipmentId", request.ShipmentId),
            ],
            [new Param("pageSize", request.PageSize), new Param("paginationToken", request.PaginationToken)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<GetSelfShipAppointmentSlotsResponse>(),
            GetSelfShipAppointmentSlotsError.Response,
            [_auth.WalletAuth],
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Provides the full details of a shipment within an inbound plan.
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="CommonShipment"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="GetShipmentError"/> when the server returns an error response.</exception>
    public Task<CommonShipment> GetShipment(GetShipmentRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default1("/inbound/wfs/v4/inboundPlans/{inboundPlanId}/shipments/{shipmentId}"),
            [
                new TemplateParam("inboundPlanId", request.InboundPlanId),
                new TemplateParam("shipmentId", request.ShipmentId),
            ],
            [],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<CommonShipment>(),
            GetShipmentError.Response,
            [_auth.WalletAuth],
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Retrieves the full details of a specific content update preview.
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="CommonContentUpdatePreview"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="GetShipmentContentUpdatePreviewError"/> when the server returns an error response.</exception>
    public Task<CommonContentUpdatePreview> GetShipmentContentUpdatePreview(GetShipmentContentUpdatePreviewRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default1(
                "/inbound/wfs/v4/inboundPlans/{inboundPlanId}/shipments/{shipmentId}/contentUpdatePreviews/{contentUpdatePreviewId}"),
            [
                new TemplateParam("inboundPlanId", request.InboundPlanId),
                new TemplateParam("shipmentId", request.ShipmentId),
                new TemplateParam("contentUpdatePreviewId", request.ContentUpdatePreviewId),
            ],
            [],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<CommonContentUpdatePreview>(),
            GetShipmentContentUpdatePreviewError.Response,
            [_auth.WalletAuth],
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Retrieves a paginated list of delivery window options for a shipment.
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="ListDeliveryWindowOptionsResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="ListDeliveryWindowOptionsError"/> when the server returns an error response.</exception>
    public Task<ListDeliveryWindowOptionsResponse> ListDeliveryWindowOptions(ListDeliveryWindowOptionsRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default1(
                "/inbound/wfs/v4/inboundPlans/{inboundPlanId}/shipments/{shipmentId}/deliveryWindowOptions"),
            [
                new TemplateParam("inboundPlanId", request.InboundPlanId),
                new TemplateParam("shipmentId", request.ShipmentId),
            ],
            [new Param("pageSize", request.PageSize), new Param("paginationToken", request.PaginationToken)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<ListDeliveryWindowOptionsResponse>(),
            ListDeliveryWindowOptionsError.Response,
            [_auth.WalletAuth],
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Provides a paginated list of box packages in an inbound plan.
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="ListInboundPlanBoxesResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="ListInboundPlanBoxesError"/> when the server returns an error response.</exception>
    public Task<ListInboundPlanBoxesResponse> ListInboundPlanBoxes(ListInboundPlanBoxesRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default1("/inbound/wfs/v4/inboundPlans/{inboundPlanId}/boxes"),
            [new TemplateParam("inboundPlanId", request.InboundPlanId)],
            [new Param("pageSize", request.PageSize), new Param("paginationToken", request.PaginationToken)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<ListInboundPlanBoxesResponse>(),
            ListInboundPlanBoxesError.Response,
            [_auth.WalletAuth],
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Provides a paginated list of item packages in an inbound plan.
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="ListInboundPlanItemsResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="ListInboundPlanItemsError"/> when the server returns an error response.</exception>
    public Task<ListInboundPlanItemsResponse> ListInboundPlanItems(ListInboundPlanItemsRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default1("/inbound/wfs/v4/inboundPlans/{inboundPlanId}/items"),
            [new TemplateParam("inboundPlanId", request.InboundPlanId)],
            [new Param("pageSize", request.PageSize), new Param("paginationToken", request.PaginationToken)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<ListInboundPlanItemsResponse>(),
            ListInboundPlanItemsError.Response,
            [_auth.WalletAuth],
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Provides a paginated list of pallet packages in an inbound plan.
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="ListInboundPlanPalletsResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="ListInboundPlanPalletsError"/> when the server returns an error response.</exception>
    public Task<ListInboundPlanPalletsResponse> ListInboundPlanPallets(ListInboundPlanPalletsRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default1("/inbound/wfs/v4/inboundPlans/{inboundPlanId}/pallets"),
            [new TemplateParam("inboundPlanId", request.InboundPlanId)],
            [new Param("pageSize", request.PageSize), new Param("paginationToken", request.PaginationToken)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<ListInboundPlanPalletsResponse>(),
            ListInboundPlanPalletsError.Response,
            [_auth.WalletAuth],
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Returns a list of inbound plans with minimal information.
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="ListInboundPlansResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="ListInboundPlansError"/> when the server returns an error response.</exception>
    public Task<ListInboundPlansResponse> ListInboundPlans(ListInboundPlansRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default1("/inbound/wfs/v4/inboundPlans"),
            [],
            [
                new Param("pageSize", request.PageSize),
                new Param("paginationToken", request.PaginationToken),
                new Param("status", request.Status),
                new Param("sortBy", request.SortBy),
                new Param("sortOrder", request.SortOrder),
            ],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<ListInboundPlansResponse>(),
            ListInboundPlansError.Response,
            [_auth.WalletAuth],
            requestOptions,
            cancellationToken);

    /// <summary>
    /// List compliance details for a given list of MSKUs.
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="ListItemComplianceDetailsResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="ListItemComplianceDetailsError"/> when the server returns an error response.</exception>
    public Task<ListItemComplianceDetailsResponse> ListItemComplianceDetails(ListItemComplianceDetailsRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default1("/inbound/wfs/v4/items/compliance"),
            [],
            [new Param("mskus", request.Mskus), new Param("marketplaceId", request.MarketplaceId)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<ListItemComplianceDetailsResponse>(),
            ListItemComplianceDetailsError.Response,
            [_auth.WalletAuth],
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Retrieves a page of boxes in a given packing group.
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="ListInboundPlanBoxesResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="ListPackingGroupBoxesError"/> when the server returns an error response.</exception>
    public Task<ListInboundPlanBoxesResponse> ListPackingGroupBoxes(ListPackingGroupBoxesRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default1("/inbound/wfs/v4/inboundPlans/{inboundPlanId}/packingGroups/{packingGroupId}/boxes"),
            [
                new TemplateParam("inboundPlanId", request.InboundPlanId),
                new TemplateParam("packingGroupId", request.PackingGroupId),
            ],
            [new Param("pageSize", request.PageSize), new Param("paginationToken", request.PaginationToken)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<ListInboundPlanBoxesResponse>(),
            ListPackingGroupBoxesError.Response,
            [_auth.WalletAuth],
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Retrieves a page of items in a given packing group.
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="ListInboundPlanItemsResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="ListPackingGroupItemsError"/> when the server returns an error response.</exception>
    public Task<ListInboundPlanItemsResponse> ListPackingGroupItems(ListPackingGroupItemsRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default1("/inbound/wfs/v4/inboundPlans/{inboundPlanId}/packingGroups/{packingGroupId}/items"),
            [
                new TemplateParam("inboundPlanId", request.InboundPlanId),
                new TemplateParam("packingGroupId", request.PackingGroupId),
            ],
            [new Param("pageSize", request.PageSize), new Param("paginationToken", request.PaginationToken)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<ListInboundPlanItemsResponse>(),
            ListPackingGroupItemsError.Response,
            [_auth.WalletAuth],
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Retrieves a list of packing options for an inbound plan.
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="ListPackingOptionsResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="ListPackingOptionsError"/> when the server returns an error response.</exception>
    public Task<ListPackingOptionsResponse> ListPackingOptions(ListPackingOptionsRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default1("/inbound/wfs/v4/inboundPlans/{inboundPlanId}/packingOptions"),
            [new TemplateParam("inboundPlanId", request.InboundPlanId)],
            [new Param("pageSize", request.PageSize), new Param("paginationToken", request.PaginationToken)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<ListPackingOptionsResponse>(),
            ListPackingOptionsError.Response,
            [_auth.WalletAuth],
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Retrieves a list of placement options for an inbound plan.
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="ListPlacementOptionsResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="ListPlacementOptionsError"/> when the server returns an error response.</exception>
    public Task<ListPlacementOptionsResponse> ListPlacementOptions(ListPlacementOptionsRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default1("/inbound/wfs/v4/inboundPlans/{inboundPlanId}/placementOptions"),
            [new TemplateParam("inboundPlanId", request.InboundPlanId)],
            [new Param("pageSize", request.PageSize), new Param("paginationToken", request.PaginationToken)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<ListPlacementOptionsResponse>(),
            ListPlacementOptionsError.Response,
            [_auth.WalletAuth],
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Returns prep details for a list of MSKUs.
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="ListPrepDetailsResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="ListPrepDetailsError"/> when the server returns an error response.</exception>
    public Task<ListPrepDetailsResponse> ListPrepDetails(ListPrepDetailsRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default1("/inbound/wfs/v4/items/prepDetails"),
            [],
            [new Param("marketplaceId", request.MarketplaceId), new Param("mskus", request.Mskus)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<ListPrepDetailsResponse>(),
            ListPrepDetailsError.Response,
            [_auth.WalletAuth],
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Provides a paginated list of box packages in a shipment.
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="ListInboundPlanBoxesResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="ListShipmentBoxesError"/> when the server returns an error response.</exception>
    public Task<ListInboundPlanBoxesResponse> ListShipmentBoxes(ListShipmentBoxesRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default1("/inbound/wfs/v4/inboundPlans/{inboundPlanId}/shipments/{shipmentId}/boxes"),
            [
                new TemplateParam("inboundPlanId", request.InboundPlanId),
                new TemplateParam("shipmentId", request.ShipmentId),
            ],
            [new Param("pageSize", request.PageSize), new Param("paginationToken", request.PaginationToken)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<ListInboundPlanBoxesResponse>(),
            ListShipmentBoxesError.Response,
            [_auth.WalletAuth],
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Retrieves a paginated list of content update previews for a given shipment.
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="ListShipmentContentUpdatePreviewsResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="ListShipmentContentUpdatePreviewsError"/> when the server returns an error response.</exception>
    public Task<ListShipmentContentUpdatePreviewsResponse> ListShipmentContentUpdatePreviews(ListShipmentContentUpdatePreviewsRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default1(
                "/inbound/wfs/v4/inboundPlans/{inboundPlanId}/shipments/{shipmentId}/contentUpdatePreviews"),
            [
                new TemplateParam("inboundPlanId", request.InboundPlanId),
                new TemplateParam("shipmentId", request.ShipmentId),
            ],
            [new Param("pageSize", request.PageSize), new Param("paginationToken", request.PaginationToken)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<ListShipmentContentUpdatePreviewsResponse>(),
            ListShipmentContentUpdatePreviewsError.Response,
            [_auth.WalletAuth],
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Provides a paginated list of item packages in a shipment.
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="ListInboundPlanItemsResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="ListShipmentItemsError"/> when the server returns an error response.</exception>
    public Task<ListInboundPlanItemsResponse> ListShipmentItems(ListShipmentItemsRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default1("/inbound/wfs/v4/inboundPlans/{inboundPlanId}/shipments/{shipmentId}/items"),
            [
                new TemplateParam("inboundPlanId", request.InboundPlanId),
                new TemplateParam("shipmentId", request.ShipmentId),
            ],
            [new Param("pageSize", request.PageSize), new Param("paginationToken", request.PaginationToken)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<ListInboundPlanItemsResponse>(),
            ListShipmentItemsError.Response,
            [_auth.WalletAuth],
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Provides a paginated list of pallet packages in a shipment.
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="ListInboundPlanPalletsResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="ListShipmentPalletsError"/> when the server returns an error response.</exception>
    public Task<ListInboundPlanPalletsResponse> ListShipmentPallets(ListShipmentPalletsRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default1("/inbound/wfs/v4/inboundPlans/{inboundPlanId}/shipments/{shipmentId}/pallets"),
            [
                new TemplateParam("inboundPlanId", request.InboundPlanId),
                new TemplateParam("shipmentId", request.ShipmentId),
            ],
            [new Param("pageSize", request.PageSize), new Param("paginationToken", request.PaginationToken)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<ListInboundPlanPalletsResponse>(),
            ListShipmentPalletsError.Response,
            [_auth.WalletAuth],
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Retrieves a list of transportation options for a placement option.
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="ListTransportationOptionsResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="ListTransportationOptionsError"/> when the server returns an error response.</exception>
    public Task<ListTransportationOptionsResponse> ListTransportationOptions(ListTransportationOptionsRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default1("/inbound/wfs/v4/inboundPlans/{inboundPlanId}/transportationOptions"),
            [new TemplateParam("inboundPlanId", request.InboundPlanId)],
            [
                new Param("pageSize", request.PageSize),
                new Param("paginationToken", request.PaginationToken),
                new Param("placementOptionId", request.PlacementOptionId),
                new Param("shipmentId", request.ShipmentId),
            ],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<ListTransportationOptionsResponse>(),
            ListTransportationOptionsError.Response,
            [_auth.WalletAuth],
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Confirms and schedules a self-ship appointment slot for a shipment.
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="ScheduleSelfShipAppointmentResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="ScheduleSelfShipAppointmentError"/> when the server returns an error response.</exception>
    public Task<ScheduleSelfShipAppointmentResponse> ScheduleSelfShipAppointment(ScheduleSelfShipAppointmentOperationRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default1(
                "/inbound/wfs/v4/inboundPlans/{inboundPlanId}/shipments/{shipmentId}/selfShipAppointmentSlots/{slotId}/schedule"),
            [
                new TemplateParam("inboundPlanId", request.InboundPlanId),
                new TemplateParam("shipmentId", request.ShipmentId),
                new TemplateParam("slotId", request.SlotId),
            ],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Post,
            JsonRequest.Create(request.Body),
            JsonResponse.Create<ScheduleSelfShipAppointmentResponse>(),
            ScheduleSelfShipAppointmentError.Response,
            [_auth.WalletAuth],
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Sets packing information for an inbound plan.
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="CancelInboundPlanResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="SetPackingInformationError"/> when the server returns an error response.</exception>
    public Task<CancelInboundPlanResponse> SetPackingInformation(SetPackingInformationOperationRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default1("/inbound/wfs/v4/inboundPlans/{inboundPlanId}/packingInformation"),
            [new TemplateParam("inboundPlanId", request.InboundPlanId)],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Post,
            JsonRequest.Create(request.Body),
            JsonResponse.Create<CancelInboundPlanResponse>(),
            SetPackingInformationError.Response,
            [_auth.WalletAuth],
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Sets prep details for a list of MSKUs.
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="CancelInboundPlanResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="SetPrepDetailsError"/> when the server returns an error response.</exception>
    public Task<CancelInboundPlanResponse> SetPrepDetails(SetPrepDetailsOperationRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default1("/inbound/wfs/v4/items/prepDetails"),
            [],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Post,
            JsonRequest.Create(request.Body),
            JsonResponse.Create<CancelInboundPlanResponse>(),
            SetPrepDetailsError.Response,
            [_auth.WalletAuth],
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Updates the name of an existing inbound plan.
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="UpdateInboundPlanNameError"/> when the server returns an error response.</exception>
    public Task UpdateInboundPlanName(UpdateInboundPlanNameOperationRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default1("/inbound/wfs/v4/inboundPlans/{inboundPlanId}/name"),
            [new TemplateParam("inboundPlanId", request.InboundPlanId)],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Put,
            JsonRequest.Create(request.Body),
            VoidResponse.Instance,
            UpdateInboundPlanNameError.Response,
            [_auth.WalletAuth],
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Update compliance details for a given MSKU.
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="CancelInboundPlanResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="UpdateItemComplianceDetailsError"/> when the server returns an error response.</exception>
    public Task<CancelInboundPlanResponse> UpdateItemComplianceDetails(UpdateItemComplianceDetailsOperationRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default1("/inbound/wfs/v4/items/compliance"),
            [],
            [new Param("marketplaceId", request.MarketplaceId)],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Put,
            JsonRequest.Create(request.Body),
            JsonResponse.Create<CancelInboundPlanResponse>(),
            UpdateItemComplianceDetailsError.Response,
            [_auth.WalletAuth],
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Updates the name of an existing shipment.
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="UpdateShipmentNameError"/> when the server returns an error response.</exception>
    public Task UpdateShipmentName(UpdateShipmentNameOperationRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default1("/inbound/wfs/v4/inboundPlans/{inboundPlanId}/shipments/{shipmentId}/name"),
            [
                new TemplateParam("inboundPlanId", request.InboundPlanId),
                new TemplateParam("shipmentId", request.ShipmentId),
            ],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Put,
            JsonRequest.Create(request.Body),
            VoidResponse.Instance,
            UpdateShipmentNameError.Response,
            [_auth.WalletAuth],
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Updates the source address for a shipment.
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="CancelInboundPlanResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="UpdateShipmentSourceAddressError"/> when the server returns an error response.</exception>
    public Task<CancelInboundPlanResponse> UpdateShipmentSourceAddress(UpdateShipmentSourceAddressOperationRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default1("/inbound/wfs/v4/inboundPlans/{inboundPlanId}/shipments/{shipmentId}/sourceAddress"),
            [
                new TemplateParam("inboundPlanId", request.InboundPlanId),
                new TemplateParam("shipmentId", request.ShipmentId),
            ],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Put,
            JsonRequest.Create(request.Body),
            JsonResponse.Create<CancelInboundPlanResponse>(),
            UpdateShipmentSourceAddressError.Response,
            [_auth.WalletAuth],
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Updates tracking details for a shipment.
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="CancelInboundPlanResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="UpdateShipmentTrackingDetailsError"/> when the server returns an error response.</exception>
    public Task<CancelInboundPlanResponse> UpdateShipmentTrackingDetails(UpdateShipmentTrackingDetailsOperationRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default1("/inbound/wfs/v4/inboundPlans/{inboundPlanId}/shipments/{shipmentId}/trackingDetails"),
            [
                new TemplateParam("inboundPlanId", request.InboundPlanId),
                new TemplateParam("shipmentId", request.ShipmentId),
            ],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Put,
            JsonRequest.Create(request.Body),
            JsonResponse.Create<CancelInboundPlanResponse>(),
            UpdateShipmentTrackingDetailsError.Response,
            [_auth.WalletAuth],
            requestOptions,
            cancellationToken);
}
