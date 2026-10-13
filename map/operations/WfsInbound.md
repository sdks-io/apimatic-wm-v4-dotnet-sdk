<!-- Generated file — do not edit; regenerated with the SDK. -->

# WfsInbound — operations

Accessor: `client.WfsInbound` · Source: `src/WalmartApIs/Api/WfsInbound.cs` · 45 operations

**Type sources**: the file declaring each type an operation names (`RawError` excluded — see sdk-map.md).

### CancelInboundPlan

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `CancelInboundPlan(CancelInboundPlanRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `InboundPlanId`
- **Returns**: `CancelInboundPlanResponse`
- **Error**: `ApiException<CancelInboundPlanError>` — **Case A (typed)**
- **Error accessors**: `TryGetCommonErrorList(out CommonErrorList)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `CancelInboundPlanRequest` | `src/WalmartApIs/Requests/WfsInbound/CancelInboundPlanRequest.cs` |
| `CancelInboundPlanResponse` | `src/WalmartApIs/Models/CancelInboundPlanResponse.cs` |
| `CancelInboundPlanError` | `src/WalmartApIs/Errors/CancelInboundPlanError.cs` |
| `CommonErrorList` | `src/WalmartApIs/Models/CommonErrorList.cs` |

### CancelSelfShipAppointment

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `CancelSelfShipAppointment(CancelSelfShipAppointmentOperationRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `InboundPlanId`, `ShipmentId`, `Body`
- **Returns**: `CancelInboundPlanResponse`
- **Error**: `ApiException<CancelSelfShipAppointmentError>` — **Case A (typed)**
- **Error accessors**: `TryGetCommonErrorList(out CommonErrorList)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `CancelSelfShipAppointmentOperationRequest` | `src/WalmartApIs/Requests/WfsInbound/CancelSelfShipAppointmentOperationRequest.cs` |
| `CancelSelfShipAppointmentRequest` | `src/WalmartApIs/Models/CancelSelfShipAppointmentRequest.cs` |
| `CancelInboundPlanResponse` | `src/WalmartApIs/Models/CancelInboundPlanResponse.cs` |
| `CancelSelfShipAppointmentError` | `src/WalmartApIs/Errors/CancelSelfShipAppointmentError.cs` |
| `CommonErrorList` | `src/WalmartApIs/Models/CommonErrorList.cs` |

### ConfirmDeliveryWindowOptions

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `ConfirmDeliveryWindowOptions(ConfirmDeliveryWindowOptionsRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `InboundPlanId`, `ShipmentId`, `DeliveryWindowOptionId`
- **Returns**: `CancelInboundPlanResponse`
- **Error**: `ApiException<ConfirmDeliveryWindowOptionsError>` — **Case A (typed)**
- **Error accessors**: `TryGetCommonErrorList(out CommonErrorList)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `ConfirmDeliveryWindowOptionsRequest` | `src/WalmartApIs/Requests/WfsInbound/ConfirmDeliveryWindowOptionsRequest.cs` |
| `CancelInboundPlanResponse` | `src/WalmartApIs/Models/CancelInboundPlanResponse.cs` |
| `ConfirmDeliveryWindowOptionsError` | `src/WalmartApIs/Errors/ConfirmDeliveryWindowOptionsError.cs` |
| `CommonErrorList` | `src/WalmartApIs/Models/CommonErrorList.cs` |

### ConfirmPackingOption

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `ConfirmPackingOption(ConfirmPackingOptionRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `InboundPlanId`, `PackingOptionId`
- **Returns**: `CancelInboundPlanResponse`
- **Error**: `ApiException<ConfirmPackingOptionError>` — **Case A (typed)**
- **Error accessors**: `TryGetCommonErrorList(out CommonErrorList)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `ConfirmPackingOptionRequest` | `src/WalmartApIs/Requests/WfsInbound/ConfirmPackingOptionRequest.cs` |
| `CancelInboundPlanResponse` | `src/WalmartApIs/Models/CancelInboundPlanResponse.cs` |
| `ConfirmPackingOptionError` | `src/WalmartApIs/Errors/ConfirmPackingOptionError.cs` |
| `CommonErrorList` | `src/WalmartApIs/Models/CommonErrorList.cs` |

### ConfirmPlacementOption

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `ConfirmPlacementOption(ConfirmPlacementOptionRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `InboundPlanId`, `PlacementOptionId`
- **Returns**: `CancelInboundPlanResponse`
- **Error**: `ApiException<ConfirmPlacementOptionError>` — **Case A (typed)**
- **Error accessors**: `TryGetCommonErrorList(out CommonErrorList)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `ConfirmPlacementOptionRequest` | `src/WalmartApIs/Requests/WfsInbound/ConfirmPlacementOptionRequest.cs` |
| `CancelInboundPlanResponse` | `src/WalmartApIs/Models/CancelInboundPlanResponse.cs` |
| `ConfirmPlacementOptionError` | `src/WalmartApIs/Errors/ConfirmPlacementOptionError.cs` |
| `CommonErrorList` | `src/WalmartApIs/Models/CommonErrorList.cs` |

### ConfirmShipmentContentUpdatePreview

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `ConfirmShipmentContentUpdatePreview(ConfirmShipmentContentUpdatePreviewRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `InboundPlanId`, `ShipmentId`, `ContentUpdatePreviewId`
- **Returns**: `CancelInboundPlanResponse`
- **Error**: `ApiException<ConfirmShipmentContentUpdatePreviewError>` — **Case A (typed)**
- **Error accessors**: `TryGetCommonErrorList(out CommonErrorList)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `ConfirmShipmentContentUpdatePreviewRequest` | `src/WalmartApIs/Requests/WfsInbound/ConfirmShipmentContentUpdatePreviewRequest.cs` |
| `CancelInboundPlanResponse` | `src/WalmartApIs/Models/CancelInboundPlanResponse.cs` |
| `ConfirmShipmentContentUpdatePreviewError` | `src/WalmartApIs/Errors/ConfirmShipmentContentUpdatePreviewError.cs` |
| `CommonErrorList` | `src/WalmartApIs/Models/CommonErrorList.cs` |

### ConfirmTransportationOptions

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `ConfirmTransportationOptions(ConfirmTransportationOptionsOperationRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `InboundPlanId`, `Body`
- **Returns**: `CancelInboundPlanResponse`
- **Error**: `ApiException<ConfirmTransportationOptionsError>` — **Case A (typed)**
- **Error accessors**: `TryGetCommonErrorList(out CommonErrorList)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `ConfirmTransportationOptionsOperationRequest` | `src/WalmartApIs/Requests/WfsInbound/ConfirmTransportationOptionsOperationRequest.cs` |
| `ConfirmTransportationOptionsRequest` | `src/WalmartApIs/Models/ConfirmTransportationOptionsRequest.cs` |
| `CancelInboundPlanResponse` | `src/WalmartApIs/Models/CancelInboundPlanResponse.cs` |
| `ConfirmTransportationOptionsError` | `src/WalmartApIs/Errors/ConfirmTransportationOptionsError.cs` |
| `CommonErrorList` | `src/WalmartApIs/Models/CommonErrorList.cs` |

### CreateInboundPlan

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `CreateInboundPlan(CreateInboundPlanOperationRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `Body`
- **Returns**: `CreateInboundPlanResponse`
- **Error**: `ApiException<CreateInboundPlanError>` — **Case A (typed)**
- **Error accessors**: `TryGetCommonErrorList(out CommonErrorList)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `CreateInboundPlanOperationRequest` | `src/WalmartApIs/Requests/WfsInbound/CreateInboundPlanOperationRequest.cs` |
| `CreateInboundPlanRequest` | `src/WalmartApIs/Models/CreateInboundPlanRequest.cs` |
| `CreateInboundPlanResponse` | `src/WalmartApIs/Models/CreateInboundPlanResponse.cs` |
| `CreateInboundPlanError` | `src/WalmartApIs/Errors/CreateInboundPlanError.cs` |
| `CommonErrorList` | `src/WalmartApIs/Models/CommonErrorList.cs` |

### CreateMarketplaceItemLabels

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `CreateMarketplaceItemLabels(CreateMarketplaceItemLabelsOperationRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `Body`
- **Returns**: `CreateMarketplaceItemLabelsResponse`
- **Error**: `ApiException<CreateMarketplaceItemLabelsError>` — **Case A (typed)**
- **Error accessors**: `TryGetCommonErrorList(out CommonErrorList)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `CreateMarketplaceItemLabelsOperationRequest` | `src/WalmartApIs/Requests/WfsInbound/CreateMarketplaceItemLabelsOperationRequest.cs` |
| `CreateMarketplaceItemLabelsRequest` | `src/WalmartApIs/Models/CreateMarketplaceItemLabelsRequest.cs` |
| `CreateMarketplaceItemLabelsResponse` | `src/WalmartApIs/Models/CreateMarketplaceItemLabelsResponse.cs` |
| `CreateMarketplaceItemLabelsError` | `src/WalmartApIs/Errors/CreateMarketplaceItemLabelsError.cs` |
| `CommonErrorList` | `src/WalmartApIs/Models/CommonErrorList.cs` |

### GenerateDeliveryWindowOptions

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `GenerateDeliveryWindowOptions(GenerateDeliveryWindowOptionsRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `InboundPlanId`, `ShipmentId`
- **Returns**: `CancelInboundPlanResponse`
- **Error**: `ApiException<GenerateDeliveryWindowOptionsError>` — **Case A (typed)**
- **Error accessors**: `TryGetCommonErrorList(out CommonErrorList)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `GenerateDeliveryWindowOptionsRequest` | `src/WalmartApIs/Requests/WfsInbound/GenerateDeliveryWindowOptionsRequest.cs` |
| `CancelInboundPlanResponse` | `src/WalmartApIs/Models/CancelInboundPlanResponse.cs` |
| `GenerateDeliveryWindowOptionsError` | `src/WalmartApIs/Errors/GenerateDeliveryWindowOptionsError.cs` |
| `CommonErrorList` | `src/WalmartApIs/Models/CommonErrorList.cs` |

### GeneratePackingOptions

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `GeneratePackingOptions(GeneratePackingOptionsRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `InboundPlanId`
- **Returns**: `CancelInboundPlanResponse`
- **Error**: `ApiException<GeneratePackingOptionsError>` — **Case A (typed)**
- **Error accessors**: `TryGetCommonErrorList(out CommonErrorList)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `GeneratePackingOptionsRequest` | `src/WalmartApIs/Requests/WfsInbound/GeneratePackingOptionsRequest.cs` |
| `CancelInboundPlanResponse` | `src/WalmartApIs/Models/CancelInboundPlanResponse.cs` |
| `GeneratePackingOptionsError` | `src/WalmartApIs/Errors/GeneratePackingOptionsError.cs` |
| `CommonErrorList` | `src/WalmartApIs/Models/CommonErrorList.cs` |

### GeneratePlacementOptions

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `GeneratePlacementOptions(GeneratePlacementOptionsOperationRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `InboundPlanId`, `Body`
- **Returns**: `CancelInboundPlanResponse`
- **Error**: `ApiException<GeneratePlacementOptionsError>` — **Case A (typed)**
- **Error accessors**: `TryGetCommonErrorList(out CommonErrorList)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `GeneratePlacementOptionsOperationRequest` | `src/WalmartApIs/Requests/WfsInbound/GeneratePlacementOptionsOperationRequest.cs` |
| `GeneratePlacementOptionsRequest` | `src/WalmartApIs/Models/GeneratePlacementOptionsRequest.cs` |
| `CancelInboundPlanResponse` | `src/WalmartApIs/Models/CancelInboundPlanResponse.cs` |
| `GeneratePlacementOptionsError` | `src/WalmartApIs/Errors/GeneratePlacementOptionsError.cs` |
| `CommonErrorList` | `src/WalmartApIs/Models/CommonErrorList.cs` |

### GenerateSelfShipAppointmentSlots

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `GenerateSelfShipAppointmentSlots(GenerateSelfShipAppointmentSlotsOperationRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `InboundPlanId`, `ShipmentId`, `Body`
- **Returns**: `CancelInboundPlanResponse`
- **Error**: `ApiException<GenerateSelfShipAppointmentSlotsError>` — **Case A (typed)**
- **Error accessors**: `TryGetCommonErrorList(out CommonErrorList)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `GenerateSelfShipAppointmentSlotsOperationRequest` | `src/WalmartApIs/Requests/WfsInbound/GenerateSelfShipAppointmentSlotsOperationRequest.cs` |
| `GenerateSelfShipAppointmentSlotsRequest` | `src/WalmartApIs/Models/GenerateSelfShipAppointmentSlotsRequest.cs` |
| `CancelInboundPlanResponse` | `src/WalmartApIs/Models/CancelInboundPlanResponse.cs` |
| `GenerateSelfShipAppointmentSlotsError` | `src/WalmartApIs/Errors/GenerateSelfShipAppointmentSlotsError.cs` |
| `CommonErrorList` | `src/WalmartApIs/Models/CommonErrorList.cs` |

### GenerateShipmentContentUpdatePreviews

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `GenerateShipmentContentUpdatePreviews(GenerateShipmentContentUpdatePreviewsOperationRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `InboundPlanId`, `ShipmentId`, `Body`
- **Returns**: `CancelInboundPlanResponse`
- **Error**: `ApiException<GenerateShipmentContentUpdatePreviewsError>` — **Case A (typed)**
- **Error accessors**: `TryGetCommonErrorList(out CommonErrorList)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `GenerateShipmentContentUpdatePreviewsOperationRequest` | `src/WalmartApIs/Requests/WfsInbound/GenerateShipmentContentUpdatePreviewsOperationRequest.cs` |
| `GenerateShipmentContentUpdatePreviewsRequest` | `src/WalmartApIs/Models/GenerateShipmentContentUpdatePreviewsRequest.cs` |
| `CancelInboundPlanResponse` | `src/WalmartApIs/Models/CancelInboundPlanResponse.cs` |
| `GenerateShipmentContentUpdatePreviewsError` | `src/WalmartApIs/Errors/GenerateShipmentContentUpdatePreviewsError.cs` |
| `CommonErrorList` | `src/WalmartApIs/Models/CommonErrorList.cs` |

### GenerateTransportationOptions

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `GenerateTransportationOptions(GenerateTransportationOptionsOperationRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `InboundPlanId`, `Body`
- **Returns**: `CancelInboundPlanResponse`
- **Error**: `ApiException<GenerateTransportationOptionsError>` — **Case A (typed)**
- **Error accessors**: `TryGetCommonErrorList(out CommonErrorList)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `GenerateTransportationOptionsOperationRequest` | `src/WalmartApIs/Requests/WfsInbound/GenerateTransportationOptionsOperationRequest.cs` |
| `GenerateTransportationOptionsRequest` | `src/WalmartApIs/Models/GenerateTransportationOptionsRequest.cs` |
| `CancelInboundPlanResponse` | `src/WalmartApIs/Models/CancelInboundPlanResponse.cs` |
| `GenerateTransportationOptionsError` | `src/WalmartApIs/Errors/GenerateTransportationOptionsError.cs` |
| `CommonErrorList` | `src/WalmartApIs/Models/CommonErrorList.cs` |

### GetDeliveryChallanDocument

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `GetDeliveryChallanDocument(GetDeliveryChallanDocumentRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `InboundPlanId`, `ShipmentId`
- **Returns**: `GetDeliveryChallanDocumentResponse`
- **Error**: `ApiException<GetDeliveryChallanDocumentError>` — **Case A (typed)**
- **Error accessors**: `TryGetCommonErrorList(out CommonErrorList)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `GetDeliveryChallanDocumentRequest` | `src/WalmartApIs/Requests/WfsInbound/GetDeliveryChallanDocumentRequest.cs` |
| `GetDeliveryChallanDocumentResponse` | `src/WalmartApIs/Models/GetDeliveryChallanDocumentResponse.cs` |
| `GetDeliveryChallanDocumentError` | `src/WalmartApIs/Errors/GetDeliveryChallanDocumentError.cs` |
| `CommonErrorList` | `src/WalmartApIs/Models/CommonErrorList.cs` |

### GetInboundOperationStatus

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `GetInboundOperationStatus(GetInboundOperationStatusRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `OperationId`
- **Returns**: `CommonInboundOperationStatus`
- **Error**: `ApiException<GetInboundOperationStatusError>` — **Case A (typed)**
- **Error accessors**: `TryGetCommonErrorList(out CommonErrorList)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `GetInboundOperationStatusRequest` | `src/WalmartApIs/Requests/WfsInbound/GetInboundOperationStatusRequest.cs` |
| `CommonInboundOperationStatus` | `src/WalmartApIs/Models/CommonInboundOperationStatus.cs` |
| `GetInboundOperationStatusError` | `src/WalmartApIs/Errors/GetInboundOperationStatusError.cs` |
| `CommonErrorList` | `src/WalmartApIs/Models/CommonErrorList.cs` |

### GetInboundPlan

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `GetInboundPlan(GetInboundPlanRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `InboundPlanId`
- **Returns**: `InboundPlan`
- **Error**: `ApiException<GetInboundPlanError>` — **Case A (typed)**
- **Error accessors**: `TryGetCommonErrorList(out CommonErrorList)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `GetInboundPlanRequest` | `src/WalmartApIs/Requests/WfsInbound/GetInboundPlanRequest.cs` |
| `InboundPlan` | `src/WalmartApIs/Models/InboundPlan.cs` |
| `GetInboundPlanError` | `src/WalmartApIs/Errors/GetInboundPlanError.cs` |
| `CommonErrorList` | `src/WalmartApIs/Models/CommonErrorList.cs` |

### GetSelfShipAppointmentSlots

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `GetSelfShipAppointmentSlots(GetSelfShipAppointmentSlotsRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `InboundPlanId`, `ShipmentId`
- **Query params (wire ← C#)**: `pageSize` ← `PageSize`, `paginationToken` ← `PaginationToken`
- **Returns**: `GetSelfShipAppointmentSlotsResponse`
- **Error**: `ApiException<GetSelfShipAppointmentSlotsError>` — **Case A (typed)**
- **Error accessors**: `TryGetCommonErrorList(out CommonErrorList)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `GetSelfShipAppointmentSlotsRequest` | `src/WalmartApIs/Requests/WfsInbound/GetSelfShipAppointmentSlotsRequest.cs` |
| `GetSelfShipAppointmentSlotsResponse` | `src/WalmartApIs/Models/GetSelfShipAppointmentSlotsResponse.cs` |
| `GetSelfShipAppointmentSlotsError` | `src/WalmartApIs/Errors/GetSelfShipAppointmentSlotsError.cs` |
| `CommonErrorList` | `src/WalmartApIs/Models/CommonErrorList.cs` |

### GetShipment

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `GetShipment(GetShipmentRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `InboundPlanId`, `ShipmentId`
- **Returns**: `CommonShipment`
- **Error**: `ApiException<GetShipmentError>` — **Case A (typed)**
- **Error accessors**: `TryGetCommonErrorList(out CommonErrorList)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `GetShipmentRequest` | `src/WalmartApIs/Requests/WfsInbound/GetShipmentRequest.cs` |
| `CommonShipment` | `src/WalmartApIs/Models/CommonShipment.cs` |
| `GetShipmentError` | `src/WalmartApIs/Errors/GetShipmentError.cs` |
| `CommonErrorList` | `src/WalmartApIs/Models/CommonErrorList.cs` |

### GetShipmentContentUpdatePreview

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `GetShipmentContentUpdatePreview(GetShipmentContentUpdatePreviewRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `InboundPlanId`, `ShipmentId`, `ContentUpdatePreviewId`
- **Returns**: `CommonContentUpdatePreview`
- **Error**: `ApiException<GetShipmentContentUpdatePreviewError>` — **Case A (typed)**
- **Error accessors**: `TryGetCommonErrorList(out CommonErrorList)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `GetShipmentContentUpdatePreviewRequest` | `src/WalmartApIs/Requests/WfsInbound/GetShipmentContentUpdatePreviewRequest.cs` |
| `CommonContentUpdatePreview` | `src/WalmartApIs/Models/CommonContentUpdatePreview.cs` |
| `GetShipmentContentUpdatePreviewError` | `src/WalmartApIs/Errors/GetShipmentContentUpdatePreviewError.cs` |
| `CommonErrorList` | `src/WalmartApIs/Models/CommonErrorList.cs` |

### ListDeliveryWindowOptions

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `ListDeliveryWindowOptions(ListDeliveryWindowOptionsRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `InboundPlanId`, `ShipmentId`
- **Query params (wire ← C#)**: `pageSize` ← `PageSize`, `paginationToken` ← `PaginationToken`
- **Returns**: `ListDeliveryWindowOptionsResponse`
- **Error**: `ApiException<ListDeliveryWindowOptionsError>` — **Case A (typed)**
- **Error accessors**: `TryGetCommonErrorList(out CommonErrorList)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `ListDeliveryWindowOptionsRequest` | `src/WalmartApIs/Requests/WfsInbound/ListDeliveryWindowOptionsRequest.cs` |
| `ListDeliveryWindowOptionsResponse` | `src/WalmartApIs/Models/ListDeliveryWindowOptionsResponse.cs` |
| `ListDeliveryWindowOptionsError` | `src/WalmartApIs/Errors/ListDeliveryWindowOptionsError.cs` |
| `CommonErrorList` | `src/WalmartApIs/Models/CommonErrorList.cs` |

### ListInboundPlanBoxes

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `ListInboundPlanBoxes(ListInboundPlanBoxesRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `InboundPlanId`
- **Query params (wire ← C#)**: `pageSize` ← `PageSize`, `paginationToken` ← `PaginationToken`
- **Returns**: `ListInboundPlanBoxesResponse`
- **Error**: `ApiException<ListInboundPlanBoxesError>` — **Case A (typed)**
- **Error accessors**: `TryGetCommonErrorList(out CommonErrorList)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `ListInboundPlanBoxesRequest` | `src/WalmartApIs/Requests/WfsInbound/ListInboundPlanBoxesRequest.cs` |
| `ListInboundPlanBoxesResponse` | `src/WalmartApIs/Models/ListInboundPlanBoxesResponse.cs` |
| `ListInboundPlanBoxesError` | `src/WalmartApIs/Errors/ListInboundPlanBoxesError.cs` |
| `CommonErrorList` | `src/WalmartApIs/Models/CommonErrorList.cs` |

### ListInboundPlanItems

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `ListInboundPlanItems(ListInboundPlanItemsRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `InboundPlanId`
- **Query params (wire ← C#)**: `pageSize` ← `PageSize`, `paginationToken` ← `PaginationToken`
- **Returns**: `ListInboundPlanItemsResponse`
- **Error**: `ApiException<ListInboundPlanItemsError>` — **Case A (typed)**
- **Error accessors**: `TryGetCommonErrorList(out CommonErrorList)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `ListInboundPlanItemsRequest` | `src/WalmartApIs/Requests/WfsInbound/ListInboundPlanItemsRequest.cs` |
| `ListInboundPlanItemsResponse` | `src/WalmartApIs/Models/ListInboundPlanItemsResponse.cs` |
| `ListInboundPlanItemsError` | `src/WalmartApIs/Errors/ListInboundPlanItemsError.cs` |
| `CommonErrorList` | `src/WalmartApIs/Models/CommonErrorList.cs` |

### ListInboundPlanPallets

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `ListInboundPlanPallets(ListInboundPlanPalletsRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `InboundPlanId`
- **Query params (wire ← C#)**: `pageSize` ← `PageSize`, `paginationToken` ← `PaginationToken`
- **Returns**: `ListInboundPlanPalletsResponse`
- **Error**: `ApiException<ListInboundPlanPalletsError>` — **Case A (typed)**
- **Error accessors**: `TryGetCommonErrorList(out CommonErrorList)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `ListInboundPlanPalletsRequest` | `src/WalmartApIs/Requests/WfsInbound/ListInboundPlanPalletsRequest.cs` |
| `ListInboundPlanPalletsResponse` | `src/WalmartApIs/Models/ListInboundPlanPalletsResponse.cs` |
| `ListInboundPlanPalletsError` | `src/WalmartApIs/Errors/ListInboundPlanPalletsError.cs` |
| `CommonErrorList` | `src/WalmartApIs/Models/CommonErrorList.cs` |

### ListInboundPlans

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `ListInboundPlans(ListInboundPlansRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
- **Query params (wire ← C#)**: `pageSize` ← `PageSize`, `paginationToken` ← `PaginationToken`, `status` ← `Status`, `sortBy` ← `SortBy`, `sortOrder` ← `SortOrder`
- **Returns**: `ListInboundPlansResponse`
- **Error**: `ApiException<ListInboundPlansError>` — **Case A (typed)**
- **Error accessors**: `TryGetCommonErrorList(out CommonErrorList)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `ListInboundPlansRequest` | `src/WalmartApIs/Requests/WfsInbound/ListInboundPlansRequest.cs` |
| `ListInboundPlansResponse` | `src/WalmartApIs/Models/ListInboundPlansResponse.cs` |
| `ListInboundPlansError` | `src/WalmartApIs/Errors/ListInboundPlansError.cs` |
| `CommonErrorList` | `src/WalmartApIs/Models/CommonErrorList.cs` |

### ListItemComplianceDetails

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `ListItemComplianceDetails(ListItemComplianceDetailsRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `Mskus`, `MarketplaceId`
- **Query params (wire ← C#)**: `mskus` ← `Mskus`, `marketplaceId` ← `MarketplaceId`
- **Returns**: `ListItemComplianceDetailsResponse`
- **Error**: `ApiException<ListItemComplianceDetailsError>` — **Case A (typed)**
- **Error accessors**: `TryGetCommonErrorList(out CommonErrorList)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `ListItemComplianceDetailsRequest` | `src/WalmartApIs/Requests/WfsInbound/ListItemComplianceDetailsRequest.cs` |
| `ListItemComplianceDetailsResponse` | `src/WalmartApIs/Models/ListItemComplianceDetailsResponse.cs` |
| `ListItemComplianceDetailsError` | `src/WalmartApIs/Errors/ListItemComplianceDetailsError.cs` |
| `CommonErrorList` | `src/WalmartApIs/Models/CommonErrorList.cs` |

### ListPackingGroupBoxes

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `ListPackingGroupBoxes(ListPackingGroupBoxesRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `InboundPlanId`, `PackingGroupId`
- **Query params (wire ← C#)**: `pageSize` ← `PageSize`, `paginationToken` ← `PaginationToken`
- **Returns**: `ListInboundPlanBoxesResponse`
- **Error**: `ApiException<ListPackingGroupBoxesError>` — **Case A (typed)**
- **Error accessors**: `TryGetCommonErrorList(out CommonErrorList)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `ListPackingGroupBoxesRequest` | `src/WalmartApIs/Requests/WfsInbound/ListPackingGroupBoxesRequest.cs` |
| `ListInboundPlanBoxesResponse` | `src/WalmartApIs/Models/ListInboundPlanBoxesResponse.cs` |
| `ListPackingGroupBoxesError` | `src/WalmartApIs/Errors/ListPackingGroupBoxesError.cs` |
| `CommonErrorList` | `src/WalmartApIs/Models/CommonErrorList.cs` |

### ListPackingGroupItems

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `ListPackingGroupItems(ListPackingGroupItemsRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `InboundPlanId`, `PackingGroupId`
- **Query params (wire ← C#)**: `pageSize` ← `PageSize`, `paginationToken` ← `PaginationToken`
- **Returns**: `ListInboundPlanItemsResponse`
- **Error**: `ApiException<ListPackingGroupItemsError>` — **Case A (typed)**
- **Error accessors**: `TryGetCommonErrorList(out CommonErrorList)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `ListPackingGroupItemsRequest` | `src/WalmartApIs/Requests/WfsInbound/ListPackingGroupItemsRequest.cs` |
| `ListInboundPlanItemsResponse` | `src/WalmartApIs/Models/ListInboundPlanItemsResponse.cs` |
| `ListPackingGroupItemsError` | `src/WalmartApIs/Errors/ListPackingGroupItemsError.cs` |
| `CommonErrorList` | `src/WalmartApIs/Models/CommonErrorList.cs` |

### ListPackingOptions

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `ListPackingOptions(ListPackingOptionsRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `InboundPlanId`
- **Query params (wire ← C#)**: `pageSize` ← `PageSize`, `paginationToken` ← `PaginationToken`
- **Returns**: `ListPackingOptionsResponse`
- **Error**: `ApiException<ListPackingOptionsError>` — **Case A (typed)**
- **Error accessors**: `TryGetCommonErrorList(out CommonErrorList)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `ListPackingOptionsRequest` | `src/WalmartApIs/Requests/WfsInbound/ListPackingOptionsRequest.cs` |
| `ListPackingOptionsResponse` | `src/WalmartApIs/Models/ListPackingOptionsResponse.cs` |
| `ListPackingOptionsError` | `src/WalmartApIs/Errors/ListPackingOptionsError.cs` |
| `CommonErrorList` | `src/WalmartApIs/Models/CommonErrorList.cs` |

### ListPlacementOptions

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `ListPlacementOptions(ListPlacementOptionsRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `InboundPlanId`
- **Query params (wire ← C#)**: `pageSize` ← `PageSize`, `paginationToken` ← `PaginationToken`
- **Returns**: `ListPlacementOptionsResponse`
- **Error**: `ApiException<ListPlacementOptionsError>` — **Case A (typed)**
- **Error accessors**: `TryGetCommonErrorList(out CommonErrorList)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `ListPlacementOptionsRequest` | `src/WalmartApIs/Requests/WfsInbound/ListPlacementOptionsRequest.cs` |
| `ListPlacementOptionsResponse` | `src/WalmartApIs/Models/ListPlacementOptionsResponse.cs` |
| `ListPlacementOptionsError` | `src/WalmartApIs/Errors/ListPlacementOptionsError.cs` |
| `CommonErrorList` | `src/WalmartApIs/Models/CommonErrorList.cs` |

### ListPrepDetails

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `ListPrepDetails(ListPrepDetailsRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `MarketplaceId`, `Mskus`
- **Query params (wire ← C#)**: `marketplaceId` ← `MarketplaceId`, `mskus` ← `Mskus`
- **Returns**: `ListPrepDetailsResponse`
- **Error**: `ApiException<ListPrepDetailsError>` — **Case A (typed)**
- **Error accessors**: `TryGetCommonErrorList(out CommonErrorList)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `ListPrepDetailsRequest` | `src/WalmartApIs/Requests/WfsInbound/ListPrepDetailsRequest.cs` |
| `ListPrepDetailsResponse` | `src/WalmartApIs/Models/ListPrepDetailsResponse.cs` |
| `ListPrepDetailsError` | `src/WalmartApIs/Errors/ListPrepDetailsError.cs` |
| `CommonErrorList` | `src/WalmartApIs/Models/CommonErrorList.cs` |

### ListShipmentBoxes

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `ListShipmentBoxes(ListShipmentBoxesRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `InboundPlanId`, `ShipmentId`
- **Query params (wire ← C#)**: `pageSize` ← `PageSize`, `paginationToken` ← `PaginationToken`
- **Returns**: `ListInboundPlanBoxesResponse`
- **Error**: `ApiException<ListShipmentBoxesError>` — **Case A (typed)**
- **Error accessors**: `TryGetCommonErrorList(out CommonErrorList)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `ListShipmentBoxesRequest` | `src/WalmartApIs/Requests/WfsInbound/ListShipmentBoxesRequest.cs` |
| `ListInboundPlanBoxesResponse` | `src/WalmartApIs/Models/ListInboundPlanBoxesResponse.cs` |
| `ListShipmentBoxesError` | `src/WalmartApIs/Errors/ListShipmentBoxesError.cs` |
| `CommonErrorList` | `src/WalmartApIs/Models/CommonErrorList.cs` |

### ListShipmentContentUpdatePreviews

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `ListShipmentContentUpdatePreviews(ListShipmentContentUpdatePreviewsRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `InboundPlanId`, `ShipmentId`
- **Query params (wire ← C#)**: `pageSize` ← `PageSize`, `paginationToken` ← `PaginationToken`
- **Returns**: `ListShipmentContentUpdatePreviewsResponse`
- **Error**: `ApiException<ListShipmentContentUpdatePreviewsError>` — **Case A (typed)**
- **Error accessors**: `TryGetCommonErrorList(out CommonErrorList)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `ListShipmentContentUpdatePreviewsRequest` | `src/WalmartApIs/Requests/WfsInbound/ListShipmentContentUpdatePreviewsRequest.cs` |
| `ListShipmentContentUpdatePreviewsResponse` | `src/WalmartApIs/Models/ListShipmentContentUpdatePreviewsResponse.cs` |
| `ListShipmentContentUpdatePreviewsError` | `src/WalmartApIs/Errors/ListShipmentContentUpdatePreviewsError.cs` |
| `CommonErrorList` | `src/WalmartApIs/Models/CommonErrorList.cs` |

### ListShipmentItems

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `ListShipmentItems(ListShipmentItemsRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `InboundPlanId`, `ShipmentId`
- **Query params (wire ← C#)**: `pageSize` ← `PageSize`, `paginationToken` ← `PaginationToken`
- **Returns**: `ListInboundPlanItemsResponse`
- **Error**: `ApiException<ListShipmentItemsError>` — **Case A (typed)**
- **Error accessors**: `TryGetCommonErrorList(out CommonErrorList)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `ListShipmentItemsRequest` | `src/WalmartApIs/Requests/WfsInbound/ListShipmentItemsRequest.cs` |
| `ListInboundPlanItemsResponse` | `src/WalmartApIs/Models/ListInboundPlanItemsResponse.cs` |
| `ListShipmentItemsError` | `src/WalmartApIs/Errors/ListShipmentItemsError.cs` |
| `CommonErrorList` | `src/WalmartApIs/Models/CommonErrorList.cs` |

### ListShipmentPallets

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `ListShipmentPallets(ListShipmentPalletsRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `InboundPlanId`, `ShipmentId`
- **Query params (wire ← C#)**: `pageSize` ← `PageSize`, `paginationToken` ← `PaginationToken`
- **Returns**: `ListInboundPlanPalletsResponse`
- **Error**: `ApiException<ListShipmentPalletsError>` — **Case A (typed)**
- **Error accessors**: `TryGetCommonErrorList(out CommonErrorList)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `ListShipmentPalletsRequest` | `src/WalmartApIs/Requests/WfsInbound/ListShipmentPalletsRequest.cs` |
| `ListInboundPlanPalletsResponse` | `src/WalmartApIs/Models/ListInboundPlanPalletsResponse.cs` |
| `ListShipmentPalletsError` | `src/WalmartApIs/Errors/ListShipmentPalletsError.cs` |
| `CommonErrorList` | `src/WalmartApIs/Models/CommonErrorList.cs` |

### ListTransportationOptions

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `ListTransportationOptions(ListTransportationOptionsRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `InboundPlanId`
- **Query params (wire ← C#)**: `pageSize` ← `PageSize`, `paginationToken` ← `PaginationToken`, `placementOptionId` ← `PlacementOptionId`, `shipmentId` ← `ShipmentId`
- **Returns**: `ListTransportationOptionsResponse`
- **Error**: `ApiException<ListTransportationOptionsError>` — **Case A (typed)**
- **Error accessors**: `TryGetCommonErrorList(out CommonErrorList)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `ListTransportationOptionsRequest` | `src/WalmartApIs/Requests/WfsInbound/ListTransportationOptionsRequest.cs` |
| `ListTransportationOptionsResponse` | `src/WalmartApIs/Models/ListTransportationOptionsResponse.cs` |
| `ListTransportationOptionsError` | `src/WalmartApIs/Errors/ListTransportationOptionsError.cs` |
| `CommonErrorList` | `src/WalmartApIs/Models/CommonErrorList.cs` |

### ScheduleSelfShipAppointment

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `ScheduleSelfShipAppointment(ScheduleSelfShipAppointmentOperationRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `InboundPlanId`, `ShipmentId`, `SlotId`, `Body`
- **Returns**: `ScheduleSelfShipAppointmentResponse`
- **Error**: `ApiException<ScheduleSelfShipAppointmentError>` — **Case A (typed)**
- **Error accessors**: `TryGetCommonErrorList(out CommonErrorList)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `ScheduleSelfShipAppointmentOperationRequest` | `src/WalmartApIs/Requests/WfsInbound/ScheduleSelfShipAppointmentOperationRequest.cs` |
| `ScheduleSelfShipAppointmentRequest` | `src/WalmartApIs/Models/ScheduleSelfShipAppointmentRequest.cs` |
| `ScheduleSelfShipAppointmentResponse` | `src/WalmartApIs/Models/ScheduleSelfShipAppointmentResponse.cs` |
| `ScheduleSelfShipAppointmentError` | `src/WalmartApIs/Errors/ScheduleSelfShipAppointmentError.cs` |
| `CommonErrorList` | `src/WalmartApIs/Models/CommonErrorList.cs` |

### SetPackingInformation

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `SetPackingInformation(SetPackingInformationOperationRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `InboundPlanId`, `Body`
- **Returns**: `CancelInboundPlanResponse`
- **Error**: `ApiException<SetPackingInformationError>` — **Case A (typed)**
- **Error accessors**: `TryGetCommonErrorList(out CommonErrorList)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `SetPackingInformationOperationRequest` | `src/WalmartApIs/Requests/WfsInbound/SetPackingInformationOperationRequest.cs` |
| `SetPackingInformationRequest` | `src/WalmartApIs/Models/SetPackingInformationRequest.cs` |
| `CancelInboundPlanResponse` | `src/WalmartApIs/Models/CancelInboundPlanResponse.cs` |
| `SetPackingInformationError` | `src/WalmartApIs/Errors/SetPackingInformationError.cs` |
| `CommonErrorList` | `src/WalmartApIs/Models/CommonErrorList.cs` |

### SetPrepDetails

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `SetPrepDetails(SetPrepDetailsOperationRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `Body`
- **Returns**: `CancelInboundPlanResponse`
- **Error**: `ApiException<SetPrepDetailsError>` — **Case A (typed)**
- **Error accessors**: `TryGetCommonErrorList(out CommonErrorList)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `SetPrepDetailsOperationRequest` | `src/WalmartApIs/Requests/WfsInbound/SetPrepDetailsOperationRequest.cs` |
| `SetPrepDetailsRequest` | `src/WalmartApIs/Models/SetPrepDetailsRequest.cs` |
| `CancelInboundPlanResponse` | `src/WalmartApIs/Models/CancelInboundPlanResponse.cs` |
| `SetPrepDetailsError` | `src/WalmartApIs/Errors/SetPrepDetailsError.cs` |
| `CommonErrorList` | `src/WalmartApIs/Models/CommonErrorList.cs` |

### UpdateInboundPlanName

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `UpdateInboundPlanName(UpdateInboundPlanNameOperationRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `InboundPlanId`, `Body`
- **Returns**: `void` (Task)
- **Error**: `ApiException<UpdateInboundPlanNameError>` — **Case A (typed)**
- **Error accessors**: `TryGetCommonErrorList(out CommonErrorList)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `UpdateInboundPlanNameOperationRequest` | `src/WalmartApIs/Requests/WfsInbound/UpdateInboundPlanNameOperationRequest.cs` |
| `UpdateInboundPlanNameRequest` | `src/WalmartApIs/Models/UpdateInboundPlanNameRequest.cs` |
| `UpdateInboundPlanNameError` | `src/WalmartApIs/Errors/UpdateInboundPlanNameError.cs` |
| `CommonErrorList` | `src/WalmartApIs/Models/CommonErrorList.cs` |

### UpdateItemComplianceDetails

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `UpdateItemComplianceDetails(UpdateItemComplianceDetailsOperationRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `MarketplaceId`, `Body`
- **Query params (wire ← C#)**: `marketplaceId` ← `MarketplaceId`
- **Returns**: `CancelInboundPlanResponse`
- **Error**: `ApiException<UpdateItemComplianceDetailsError>` — **Case A (typed)**
- **Error accessors**: `TryGetCommonErrorList(out CommonErrorList)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `UpdateItemComplianceDetailsOperationRequest` | `src/WalmartApIs/Requests/WfsInbound/UpdateItemComplianceDetailsOperationRequest.cs` |
| `UpdateItemComplianceDetailsRequest` | `src/WalmartApIs/Models/UpdateItemComplianceDetailsRequest.cs` |
| `CancelInboundPlanResponse` | `src/WalmartApIs/Models/CancelInboundPlanResponse.cs` |
| `UpdateItemComplianceDetailsError` | `src/WalmartApIs/Errors/UpdateItemComplianceDetailsError.cs` |
| `CommonErrorList` | `src/WalmartApIs/Models/CommonErrorList.cs` |

### UpdateShipmentName

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `UpdateShipmentName(UpdateShipmentNameOperationRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `InboundPlanId`, `ShipmentId`, `Body`
- **Returns**: `void` (Task)
- **Error**: `ApiException<UpdateShipmentNameError>` — **Case A (typed)**
- **Error accessors**: `TryGetCommonErrorList(out CommonErrorList)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `UpdateShipmentNameOperationRequest` | `src/WalmartApIs/Requests/WfsInbound/UpdateShipmentNameOperationRequest.cs` |
| `UpdateShipmentNameRequest` | `src/WalmartApIs/Models/UpdateShipmentNameRequest.cs` |
| `UpdateShipmentNameError` | `src/WalmartApIs/Errors/UpdateShipmentNameError.cs` |
| `CommonErrorList` | `src/WalmartApIs/Models/CommonErrorList.cs` |

### UpdateShipmentSourceAddress

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `UpdateShipmentSourceAddress(UpdateShipmentSourceAddressOperationRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `InboundPlanId`, `ShipmentId`, `Body`
- **Returns**: `CancelInboundPlanResponse`
- **Error**: `ApiException<UpdateShipmentSourceAddressError>` — **Case A (typed)**
- **Error accessors**: `TryGetCommonErrorList(out CommonErrorList)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `UpdateShipmentSourceAddressOperationRequest` | `src/WalmartApIs/Requests/WfsInbound/UpdateShipmentSourceAddressOperationRequest.cs` |
| `UpdateShipmentSourceAddressRequest` | `src/WalmartApIs/Models/UpdateShipmentSourceAddressRequest.cs` |
| `CancelInboundPlanResponse` | `src/WalmartApIs/Models/CancelInboundPlanResponse.cs` |
| `UpdateShipmentSourceAddressError` | `src/WalmartApIs/Errors/UpdateShipmentSourceAddressError.cs` |
| `CommonErrorList` | `src/WalmartApIs/Models/CommonErrorList.cs` |

### UpdateShipmentTrackingDetails

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `UpdateShipmentTrackingDetails(UpdateShipmentTrackingDetailsOperationRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `InboundPlanId`, `ShipmentId`, `Body`
- **Returns**: `CancelInboundPlanResponse`
- **Error**: `ApiException<UpdateShipmentTrackingDetailsError>` — **Case A (typed)**
- **Error accessors**: `TryGetCommonErrorList(out CommonErrorList)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `UpdateShipmentTrackingDetailsOperationRequest` | `src/WalmartApIs/Requests/WfsInbound/UpdateShipmentTrackingDetailsOperationRequest.cs` |
| `UpdateShipmentTrackingDetailsRequest` | `src/WalmartApIs/Models/UpdateShipmentTrackingDetailsRequest.cs` |
| `CancelInboundPlanResponse` | `src/WalmartApIs/Models/CancelInboundPlanResponse.cs` |
| `UpdateShipmentTrackingDetailsError` | `src/WalmartApIs/Errors/UpdateShipmentTrackingDetailsError.cs` |
| `CommonErrorList` | `src/WalmartApIs/Models/CommonErrorList.cs` |

