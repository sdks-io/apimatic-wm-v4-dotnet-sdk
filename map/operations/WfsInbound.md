<!-- Generated file — do not edit; regenerated with the SDK. -->

# WfsInbound — operations

Accessor: `client.WfsInbound` · Source: `Api/WfsInbound.cs` · 45 operations

**Type sources**: the file declaring each type an operation names (`RawError` excluded — see sdk-map.md).

### CancelInboundPlan

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `CancelInboundPlan(string inboundPlanId, RequestOptions? requestOptions = null, CancellationToken ct = default)`
- **Returns**: `CancelInboundPlanResponse`
- **Error**: `SdkException<CancelInboundPlanError>` — **Case A (typed)**
- **Error accessors**: `TryGetCommonErrorList(out CommonErrorList)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `CancelInboundPlanResponse` | `Models/CancelInboundPlanResponse.cs` |
| `CancelInboundPlanError` | `Errors/CancelInboundPlanError.cs` |
| `CommonErrorList` | `Models/CommonErrorList.cs` |

### CancelSelfShipAppointment

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `CancelSelfShipAppointment(string inboundPlanId, string shipmentId, CancelSelfShipAppointmentRequest body, RequestOptions? requestOptions = null, CancellationToken ct = default)`
- **Returns**: `CancelInboundPlanResponse`
- **Error**: `SdkException<CancelSelfShipAppointmentError>` — **Case A (typed)**
- **Error accessors**: `TryGetCommonErrorList(out CommonErrorList)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `CancelSelfShipAppointmentRequest` | `Models/CancelSelfShipAppointmentRequest.cs` |
| `CancelInboundPlanResponse` | `Models/CancelInboundPlanResponse.cs` |
| `CancelSelfShipAppointmentError` | `Errors/CancelSelfShipAppointmentError.cs` |
| `CommonErrorList` | `Models/CommonErrorList.cs` |

### ConfirmDeliveryWindowOptions

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `ConfirmDeliveryWindowOptions(string inboundPlanId, string shipmentId, string deliveryWindowOptionId, RequestOptions? requestOptions = null, CancellationToken ct = default)`
- **Returns**: `CancelInboundPlanResponse`
- **Error**: `SdkException<ConfirmDeliveryWindowOptionsError>` — **Case A (typed)**
- **Error accessors**: `TryGetCommonErrorList(out CommonErrorList)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `CancelInboundPlanResponse` | `Models/CancelInboundPlanResponse.cs` |
| `ConfirmDeliveryWindowOptionsError` | `Errors/ConfirmDeliveryWindowOptionsError.cs` |
| `CommonErrorList` | `Models/CommonErrorList.cs` |

### ConfirmPackingOption

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `ConfirmPackingOption(string inboundPlanId, string packingOptionId, RequestOptions? requestOptions = null, CancellationToken ct = default)`
- **Returns**: `CancelInboundPlanResponse`
- **Error**: `SdkException<ConfirmPackingOptionError>` — **Case A (typed)**
- **Error accessors**: `TryGetCommonErrorList(out CommonErrorList)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `CancelInboundPlanResponse` | `Models/CancelInboundPlanResponse.cs` |
| `ConfirmPackingOptionError` | `Errors/ConfirmPackingOptionError.cs` |
| `CommonErrorList` | `Models/CommonErrorList.cs` |

### ConfirmPlacementOption

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `ConfirmPlacementOption(string inboundPlanId, string placementOptionId, RequestOptions? requestOptions = null, CancellationToken ct = default)`
- **Returns**: `CancelInboundPlanResponse`
- **Error**: `SdkException<ConfirmPlacementOptionError>` — **Case A (typed)**
- **Error accessors**: `TryGetCommonErrorList(out CommonErrorList)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `CancelInboundPlanResponse` | `Models/CancelInboundPlanResponse.cs` |
| `ConfirmPlacementOptionError` | `Errors/ConfirmPlacementOptionError.cs` |
| `CommonErrorList` | `Models/CommonErrorList.cs` |

### ConfirmShipmentContentUpdatePreview

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `ConfirmShipmentContentUpdatePreview(string inboundPlanId, string shipmentId, string contentUpdatePreviewId, RequestOptions? requestOptions = null, CancellationToken ct = default)`
- **Returns**: `CancelInboundPlanResponse`
- **Error**: `SdkException<ConfirmShipmentContentUpdatePreviewError>` — **Case A (typed)**
- **Error accessors**: `TryGetCommonErrorList(out CommonErrorList)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `CancelInboundPlanResponse` | `Models/CancelInboundPlanResponse.cs` |
| `ConfirmShipmentContentUpdatePreviewError` | `Errors/ConfirmShipmentContentUpdatePreviewError.cs` |
| `CommonErrorList` | `Models/CommonErrorList.cs` |

### ConfirmTransportationOptions

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `ConfirmTransportationOptions(string inboundPlanId, ConfirmTransportationOptionsRequest body, RequestOptions? requestOptions = null, CancellationToken ct = default)`
- **Returns**: `CancelInboundPlanResponse`
- **Error**: `SdkException<ConfirmTransportationOptionsError>` — **Case A (typed)**
- **Error accessors**: `TryGetCommonErrorList(out CommonErrorList)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `ConfirmTransportationOptionsRequest` | `Models/ConfirmTransportationOptionsRequest.cs` |
| `CancelInboundPlanResponse` | `Models/CancelInboundPlanResponse.cs` |
| `ConfirmTransportationOptionsError` | `Errors/ConfirmTransportationOptionsError.cs` |
| `CommonErrorList` | `Models/CommonErrorList.cs` |

### CreateInboundPlan

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `CreateInboundPlan(CreateInboundPlanRequest body, RequestOptions? requestOptions = null, CancellationToken ct = default)`
- **Returns**: `CreateInboundPlanResponse`
- **Error**: `SdkException<CreateInboundPlanError>` — **Case A (typed)**
- **Error accessors**: `TryGetCommonErrorList(out CommonErrorList)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `CreateInboundPlanRequest` | `Models/CreateInboundPlanRequest.cs` |
| `CreateInboundPlanResponse` | `Models/CreateInboundPlanResponse.cs` |
| `CreateInboundPlanError` | `Errors/CreateInboundPlanError.cs` |
| `CommonErrorList` | `Models/CommonErrorList.cs` |

### CreateMarketplaceItemLabels

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `CreateMarketplaceItemLabels(CreateMarketplaceItemLabelsRequest body, RequestOptions? requestOptions = null, CancellationToken ct = default)`
- **Returns**: `CreateMarketplaceItemLabelsResponse`
- **Error**: `SdkException<CreateMarketplaceItemLabelsError>` — **Case A (typed)**
- **Error accessors**: `TryGetCommonErrorList(out CommonErrorList)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `CreateMarketplaceItemLabelsRequest` | `Models/CreateMarketplaceItemLabelsRequest.cs` |
| `CreateMarketplaceItemLabelsResponse` | `Models/CreateMarketplaceItemLabelsResponse.cs` |
| `CreateMarketplaceItemLabelsError` | `Errors/CreateMarketplaceItemLabelsError.cs` |
| `CommonErrorList` | `Models/CommonErrorList.cs` |

### GenerateDeliveryWindowOptions

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `GenerateDeliveryWindowOptions(string inboundPlanId, string shipmentId, RequestOptions? requestOptions = null, CancellationToken ct = default)`
- **Returns**: `CancelInboundPlanResponse`
- **Error**: `SdkException<GenerateDeliveryWindowOptionsError>` — **Case A (typed)**
- **Error accessors**: `TryGetCommonErrorList(out CommonErrorList)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `CancelInboundPlanResponse` | `Models/CancelInboundPlanResponse.cs` |
| `GenerateDeliveryWindowOptionsError` | `Errors/GenerateDeliveryWindowOptionsError.cs` |
| `CommonErrorList` | `Models/CommonErrorList.cs` |

### GeneratePackingOptions

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `GeneratePackingOptions(string inboundPlanId, RequestOptions? requestOptions = null, CancellationToken ct = default)`
- **Returns**: `CancelInboundPlanResponse`
- **Error**: `SdkException<GeneratePackingOptionsError>` — **Case A (typed)**
- **Error accessors**: `TryGetCommonErrorList(out CommonErrorList)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `CancelInboundPlanResponse` | `Models/CancelInboundPlanResponse.cs` |
| `GeneratePackingOptionsError` | `Errors/GeneratePackingOptionsError.cs` |
| `CommonErrorList` | `Models/CommonErrorList.cs` |

### GeneratePlacementOptions

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `GeneratePlacementOptions(string inboundPlanId, GeneratePlacementOptionsRequest body, RequestOptions? requestOptions = null, CancellationToken ct = default)`
- **Returns**: `CancelInboundPlanResponse`
- **Error**: `SdkException<GeneratePlacementOptionsError>` — **Case A (typed)**
- **Error accessors**: `TryGetCommonErrorList(out CommonErrorList)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `GeneratePlacementOptionsRequest` | `Models/GeneratePlacementOptionsRequest.cs` |
| `CancelInboundPlanResponse` | `Models/CancelInboundPlanResponse.cs` |
| `GeneratePlacementOptionsError` | `Errors/GeneratePlacementOptionsError.cs` |
| `CommonErrorList` | `Models/CommonErrorList.cs` |

### GenerateSelfShipAppointmentSlots

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `GenerateSelfShipAppointmentSlots(string inboundPlanId, string shipmentId, GenerateSelfShipAppointmentSlotsRequest body, RequestOptions? requestOptions = null, CancellationToken ct = default)`
- **Returns**: `CancelInboundPlanResponse`
- **Error**: `SdkException<GenerateSelfShipAppointmentSlotsError>` — **Case A (typed)**
- **Error accessors**: `TryGetCommonErrorList(out CommonErrorList)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `GenerateSelfShipAppointmentSlotsRequest` | `Models/GenerateSelfShipAppointmentSlotsRequest.cs` |
| `CancelInboundPlanResponse` | `Models/CancelInboundPlanResponse.cs` |
| `GenerateSelfShipAppointmentSlotsError` | `Errors/GenerateSelfShipAppointmentSlotsError.cs` |
| `CommonErrorList` | `Models/CommonErrorList.cs` |

### GenerateShipmentContentUpdatePreviews

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `GenerateShipmentContentUpdatePreviews(string inboundPlanId, string shipmentId, GenerateShipmentContentUpdatePreviewsRequest body, RequestOptions? requestOptions = null, CancellationToken ct = default)`
- **Returns**: `CancelInboundPlanResponse`
- **Error**: `SdkException<GenerateShipmentContentUpdatePreviewsError>` — **Case A (typed)**
- **Error accessors**: `TryGetCommonErrorList(out CommonErrorList)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `GenerateShipmentContentUpdatePreviewsRequest` | `Models/GenerateShipmentContentUpdatePreviewsRequest.cs` |
| `CancelInboundPlanResponse` | `Models/CancelInboundPlanResponse.cs` |
| `GenerateShipmentContentUpdatePreviewsError` | `Errors/GenerateShipmentContentUpdatePreviewsError.cs` |
| `CommonErrorList` | `Models/CommonErrorList.cs` |

### GenerateTransportationOptions

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `GenerateTransportationOptions(string inboundPlanId, GenerateTransportationOptionsRequest body, RequestOptions? requestOptions = null, CancellationToken ct = default)`
- **Returns**: `CancelInboundPlanResponse`
- **Error**: `SdkException<GenerateTransportationOptionsError>` — **Case A (typed)**
- **Error accessors**: `TryGetCommonErrorList(out CommonErrorList)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `GenerateTransportationOptionsRequest` | `Models/GenerateTransportationOptionsRequest.cs` |
| `CancelInboundPlanResponse` | `Models/CancelInboundPlanResponse.cs` |
| `GenerateTransportationOptionsError` | `Errors/GenerateTransportationOptionsError.cs` |
| `CommonErrorList` | `Models/CommonErrorList.cs` |

### GetDeliveryChallanDocument

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `GetDeliveryChallanDocument(string inboundPlanId, string shipmentId, RequestOptions? requestOptions = null, CancellationToken ct = default)`
- **Returns**: `GetDeliveryChallanDocumentResponse`
- **Error**: `SdkException<GetDeliveryChallanDocumentError>` — **Case A (typed)**
- **Error accessors**: `TryGetCommonErrorList(out CommonErrorList)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `GetDeliveryChallanDocumentResponse` | `Models/GetDeliveryChallanDocumentResponse.cs` |
| `GetDeliveryChallanDocumentError` | `Errors/GetDeliveryChallanDocumentError.cs` |
| `CommonErrorList` | `Models/CommonErrorList.cs` |

### GetInboundOperationStatus

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `GetInboundOperationStatus(string operationId, RequestOptions? requestOptions = null, CancellationToken ct = default)`
- **Returns**: `CommonInboundOperationStatus`
- **Error**: `SdkException<GetInboundOperationStatusError>` — **Case A (typed)**
- **Error accessors**: `TryGetCommonErrorList(out CommonErrorList)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `CommonInboundOperationStatus` | `Models/CommonInboundOperationStatus.cs` |
| `GetInboundOperationStatusError` | `Errors/GetInboundOperationStatusError.cs` |
| `CommonErrorList` | `Models/CommonErrorList.cs` |

### GetInboundPlan

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `GetInboundPlan(string inboundPlanId, RequestOptions? requestOptions = null, CancellationToken ct = default)`
- **Returns**: `InboundPlan`
- **Error**: `SdkException<GetInboundPlanError>` — **Case A (typed)**
- **Error accessors**: `TryGetCommonErrorList(out CommonErrorList)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `InboundPlan` | `Models/InboundPlan.cs` |
| `GetInboundPlanError` | `Errors/GetInboundPlanError.cs` |
| `CommonErrorList` | `Models/CommonErrorList.cs` |

### GetSelfShipAppointmentSlots

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `GetSelfShipAppointmentSlots(string inboundPlanId, string shipmentId, int? pageSize, string? paginationToken, RequestOptions? requestOptions = null, CancellationToken ct = default)`
  - `pageSize` — nullable, no default → **must pass explicitly**
  - `paginationToken` — nullable, no default → **must pass explicitly**
- **Query params (wire ← C#)**: `pageSize` ← `pageSize`, `paginationToken` ← `paginationToken`
- **Returns**: `GetSelfShipAppointmentSlotsResponse`
- **Error**: `SdkException<GetSelfShipAppointmentSlotsError>` — **Case A (typed)**
- **Error accessors**: `TryGetCommonErrorList(out CommonErrorList)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `GetSelfShipAppointmentSlotsResponse` | `Models/GetSelfShipAppointmentSlotsResponse.cs` |
| `GetSelfShipAppointmentSlotsError` | `Errors/GetSelfShipAppointmentSlotsError.cs` |
| `CommonErrorList` | `Models/CommonErrorList.cs` |

### GetShipment

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `GetShipment(string inboundPlanId, string shipmentId, RequestOptions? requestOptions = null, CancellationToken ct = default)`
- **Returns**: `CommonShipment`
- **Error**: `SdkException<GetShipmentError>` — **Case A (typed)**
- **Error accessors**: `TryGetCommonErrorList(out CommonErrorList)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `CommonShipment` | `Models/CommonShipment.cs` |
| `GetShipmentError` | `Errors/GetShipmentError.cs` |
| `CommonErrorList` | `Models/CommonErrorList.cs` |

### GetShipmentContentUpdatePreview

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `GetShipmentContentUpdatePreview(string inboundPlanId, string shipmentId, string contentUpdatePreviewId, RequestOptions? requestOptions = null, CancellationToken ct = default)`
- **Returns**: `CommonContentUpdatePreview`
- **Error**: `SdkException<GetShipmentContentUpdatePreviewError>` — **Case A (typed)**
- **Error accessors**: `TryGetCommonErrorList(out CommonErrorList)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `CommonContentUpdatePreview` | `Models/CommonContentUpdatePreview.cs` |
| `GetShipmentContentUpdatePreviewError` | `Errors/GetShipmentContentUpdatePreviewError.cs` |
| `CommonErrorList` | `Models/CommonErrorList.cs` |

### ListDeliveryWindowOptions

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `ListDeliveryWindowOptions(string inboundPlanId, string shipmentId, int? pageSize, string? paginationToken, RequestOptions? requestOptions = null, CancellationToken ct = default)`
  - `pageSize` — nullable, no default → **must pass explicitly**
  - `paginationToken` — nullable, no default → **must pass explicitly**
- **Query params (wire ← C#)**: `pageSize` ← `pageSize`, `paginationToken` ← `paginationToken`
- **Returns**: `ListDeliveryWindowOptionsResponse`
- **Error**: `SdkException<ListDeliveryWindowOptionsError>` — **Case A (typed)**
- **Error accessors**: `TryGetCommonErrorList(out CommonErrorList)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `ListDeliveryWindowOptionsResponse` | `Models/ListDeliveryWindowOptionsResponse.cs` |
| `ListDeliveryWindowOptionsError` | `Errors/ListDeliveryWindowOptionsError.cs` |
| `CommonErrorList` | `Models/CommonErrorList.cs` |

### ListInboundPlanBoxes

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `ListInboundPlanBoxes(string inboundPlanId, int? pageSize, string? paginationToken, RequestOptions? requestOptions = null, CancellationToken ct = default)`
  - `pageSize` — nullable, no default → **must pass explicitly**
  - `paginationToken` — nullable, no default → **must pass explicitly**
- **Query params (wire ← C#)**: `pageSize` ← `pageSize`, `paginationToken` ← `paginationToken`
- **Returns**: `ListInboundPlanBoxesResponse`
- **Error**: `SdkException<ListInboundPlanBoxesError>` — **Case A (typed)**
- **Error accessors**: `TryGetCommonErrorList(out CommonErrorList)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `ListInboundPlanBoxesResponse` | `Models/ListInboundPlanBoxesResponse.cs` |
| `ListInboundPlanBoxesError` | `Errors/ListInboundPlanBoxesError.cs` |
| `CommonErrorList` | `Models/CommonErrorList.cs` |

### ListInboundPlanItems

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `ListInboundPlanItems(string inboundPlanId, int? pageSize, string? paginationToken, RequestOptions? requestOptions = null, CancellationToken ct = default)`
  - `pageSize` — nullable, no default → **must pass explicitly**
  - `paginationToken` — nullable, no default → **must pass explicitly**
- **Query params (wire ← C#)**: `pageSize` ← `pageSize`, `paginationToken` ← `paginationToken`
- **Returns**: `ListInboundPlanItemsResponse`
- **Error**: `SdkException<ListInboundPlanItemsError>` — **Case A (typed)**
- **Error accessors**: `TryGetCommonErrorList(out CommonErrorList)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `ListInboundPlanItemsResponse` | `Models/ListInboundPlanItemsResponse.cs` |
| `ListInboundPlanItemsError` | `Errors/ListInboundPlanItemsError.cs` |
| `CommonErrorList` | `Models/CommonErrorList.cs` |

### ListInboundPlanPallets

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `ListInboundPlanPallets(string inboundPlanId, int? pageSize, string? paginationToken, RequestOptions? requestOptions = null, CancellationToken ct = default)`
  - `pageSize` — nullable, no default → **must pass explicitly**
  - `paginationToken` — nullable, no default → **must pass explicitly**
- **Query params (wire ← C#)**: `pageSize` ← `pageSize`, `paginationToken` ← `paginationToken`
- **Returns**: `ListInboundPlanPalletsResponse`
- **Error**: `SdkException<ListInboundPlanPalletsError>` — **Case A (typed)**
- **Error accessors**: `TryGetCommonErrorList(out CommonErrorList)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `ListInboundPlanPalletsResponse` | `Models/ListInboundPlanPalletsResponse.cs` |
| `ListInboundPlanPalletsError` | `Errors/ListInboundPlanPalletsError.cs` |
| `CommonErrorList` | `Models/CommonErrorList.cs` |

### ListInboundPlans

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `ListInboundPlans(string? paginationToken, string? status, string? sortBy, string? sortOrder, int? pageSize = 10, RequestOptions? requestOptions = null, CancellationToken ct = default)`
  - 4 params (`paginationToken` … `sortOrder`) — nullable, no default → **must pass explicitly** (pass `null` to skip)
  - defaults: `pageSize` = `10`
- **Query params (wire ← C#)**: `pageSize` ← `pageSize`, `paginationToken` ← `paginationToken`, `status` ← `status`, `sortBy` ← `sortBy`, `sortOrder` ← `sortOrder`
- **Returns**: `ListInboundPlansResponse`
- **Error**: `SdkException<ListInboundPlansError>` — **Case A (typed)**
- **Error accessors**: `TryGetCommonErrorList(out CommonErrorList)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `ListInboundPlansResponse` | `Models/ListInboundPlansResponse.cs` |
| `ListInboundPlansError` | `Errors/ListInboundPlansError.cs` |
| `CommonErrorList` | `Models/CommonErrorList.cs` |

### ListItemComplianceDetails

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `ListItemComplianceDetails(IReadOnlyList<string> mskus, string marketplaceId, RequestOptions? requestOptions = null, CancellationToken ct = default)`
- **Query params (wire ← C#)**: `mskus` ← `mskus`, `marketplaceId` ← `marketplaceId`
- **Returns**: `ListItemComplianceDetailsResponse`
- **Error**: `SdkException<ListItemComplianceDetailsError>` — **Case A (typed)**
- **Error accessors**: `TryGetCommonErrorList(out CommonErrorList)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `ListItemComplianceDetailsResponse` | `Models/ListItemComplianceDetailsResponse.cs` |
| `ListItemComplianceDetailsError` | `Errors/ListItemComplianceDetailsError.cs` |
| `CommonErrorList` | `Models/CommonErrorList.cs` |

### ListPackingGroupBoxes

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `ListPackingGroupBoxes(string inboundPlanId, string packingGroupId, int? pageSize, string? paginationToken, RequestOptions? requestOptions = null, CancellationToken ct = default)`
  - `pageSize` — nullable, no default → **must pass explicitly**
  - `paginationToken` — nullable, no default → **must pass explicitly**
- **Query params (wire ← C#)**: `pageSize` ← `pageSize`, `paginationToken` ← `paginationToken`
- **Returns**: `ListInboundPlanBoxesResponse`
- **Error**: `SdkException<ListPackingGroupBoxesError>` — **Case A (typed)**
- **Error accessors**: `TryGetCommonErrorList(out CommonErrorList)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `ListInboundPlanBoxesResponse` | `Models/ListInboundPlanBoxesResponse.cs` |
| `ListPackingGroupBoxesError` | `Errors/ListPackingGroupBoxesError.cs` |
| `CommonErrorList` | `Models/CommonErrorList.cs` |

### ListPackingGroupItems

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `ListPackingGroupItems(string inboundPlanId, string packingGroupId, int? pageSize, string? paginationToken, RequestOptions? requestOptions = null, CancellationToken ct = default)`
  - `pageSize` — nullable, no default → **must pass explicitly**
  - `paginationToken` — nullable, no default → **must pass explicitly**
- **Query params (wire ← C#)**: `pageSize` ← `pageSize`, `paginationToken` ← `paginationToken`
- **Returns**: `ListInboundPlanItemsResponse`
- **Error**: `SdkException<ListPackingGroupItemsError>` — **Case A (typed)**
- **Error accessors**: `TryGetCommonErrorList(out CommonErrorList)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `ListInboundPlanItemsResponse` | `Models/ListInboundPlanItemsResponse.cs` |
| `ListPackingGroupItemsError` | `Errors/ListPackingGroupItemsError.cs` |
| `CommonErrorList` | `Models/CommonErrorList.cs` |

### ListPackingOptions

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `ListPackingOptions(string inboundPlanId, int? pageSize, string? paginationToken, RequestOptions? requestOptions = null, CancellationToken ct = default)`
  - `pageSize` — nullable, no default → **must pass explicitly**
  - `paginationToken` — nullable, no default → **must pass explicitly**
- **Query params (wire ← C#)**: `pageSize` ← `pageSize`, `paginationToken` ← `paginationToken`
- **Returns**: `ListPackingOptionsResponse`
- **Error**: `SdkException<ListPackingOptionsError>` — **Case A (typed)**
- **Error accessors**: `TryGetCommonErrorList(out CommonErrorList)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `ListPackingOptionsResponse` | `Models/ListPackingOptionsResponse.cs` |
| `ListPackingOptionsError` | `Errors/ListPackingOptionsError.cs` |
| `CommonErrorList` | `Models/CommonErrorList.cs` |

### ListPlacementOptions

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `ListPlacementOptions(string inboundPlanId, int? pageSize, string? paginationToken, RequestOptions? requestOptions = null, CancellationToken ct = default)`
  - `pageSize` — nullable, no default → **must pass explicitly**
  - `paginationToken` — nullable, no default → **must pass explicitly**
- **Query params (wire ← C#)**: `pageSize` ← `pageSize`, `paginationToken` ← `paginationToken`
- **Returns**: `ListPlacementOptionsResponse`
- **Error**: `SdkException<ListPlacementOptionsError>` — **Case A (typed)**
- **Error accessors**: `TryGetCommonErrorList(out CommonErrorList)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `ListPlacementOptionsResponse` | `Models/ListPlacementOptionsResponse.cs` |
| `ListPlacementOptionsError` | `Errors/ListPlacementOptionsError.cs` |
| `CommonErrorList` | `Models/CommonErrorList.cs` |

### ListPrepDetails

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `ListPrepDetails(string marketplaceId, IReadOnlyList<string> mskus, RequestOptions? requestOptions = null, CancellationToken ct = default)`
- **Query params (wire ← C#)**: `marketplaceId` ← `marketplaceId`, `mskus` ← `mskus`
- **Returns**: `ListPrepDetailsResponse`
- **Error**: `SdkException<ListPrepDetailsError>` — **Case A (typed)**
- **Error accessors**: `TryGetCommonErrorList(out CommonErrorList)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `ListPrepDetailsResponse` | `Models/ListPrepDetailsResponse.cs` |
| `ListPrepDetailsError` | `Errors/ListPrepDetailsError.cs` |
| `CommonErrorList` | `Models/CommonErrorList.cs` |

### ListShipmentBoxes

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `ListShipmentBoxes(string inboundPlanId, string shipmentId, int? pageSize, string? paginationToken, RequestOptions? requestOptions = null, CancellationToken ct = default)`
  - `pageSize` — nullable, no default → **must pass explicitly**
  - `paginationToken` — nullable, no default → **must pass explicitly**
- **Query params (wire ← C#)**: `pageSize` ← `pageSize`, `paginationToken` ← `paginationToken`
- **Returns**: `ListInboundPlanBoxesResponse`
- **Error**: `SdkException<ListShipmentBoxesError>` — **Case A (typed)**
- **Error accessors**: `TryGetCommonErrorList(out CommonErrorList)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `ListInboundPlanBoxesResponse` | `Models/ListInboundPlanBoxesResponse.cs` |
| `ListShipmentBoxesError` | `Errors/ListShipmentBoxesError.cs` |
| `CommonErrorList` | `Models/CommonErrorList.cs` |

### ListShipmentContentUpdatePreviews

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `ListShipmentContentUpdatePreviews(string inboundPlanId, string shipmentId, int? pageSize, string? paginationToken, RequestOptions? requestOptions = null, CancellationToken ct = default)`
  - `pageSize` — nullable, no default → **must pass explicitly**
  - `paginationToken` — nullable, no default → **must pass explicitly**
- **Query params (wire ← C#)**: `pageSize` ← `pageSize`, `paginationToken` ← `paginationToken`
- **Returns**: `ListShipmentContentUpdatePreviewsResponse`
- **Error**: `SdkException<ListShipmentContentUpdatePreviewsError>` — **Case A (typed)**
- **Error accessors**: `TryGetCommonErrorList(out CommonErrorList)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `ListShipmentContentUpdatePreviewsResponse` | `Models/ListShipmentContentUpdatePreviewsResponse.cs` |
| `ListShipmentContentUpdatePreviewsError` | `Errors/ListShipmentContentUpdatePreviewsError.cs` |
| `CommonErrorList` | `Models/CommonErrorList.cs` |

### ListShipmentItems

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `ListShipmentItems(string inboundPlanId, string shipmentId, int? pageSize, string? paginationToken, RequestOptions? requestOptions = null, CancellationToken ct = default)`
  - `pageSize` — nullable, no default → **must pass explicitly**
  - `paginationToken` — nullable, no default → **must pass explicitly**
- **Query params (wire ← C#)**: `pageSize` ← `pageSize`, `paginationToken` ← `paginationToken`
- **Returns**: `ListInboundPlanItemsResponse`
- **Error**: `SdkException<ListShipmentItemsError>` — **Case A (typed)**
- **Error accessors**: `TryGetCommonErrorList(out CommonErrorList)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `ListInboundPlanItemsResponse` | `Models/ListInboundPlanItemsResponse.cs` |
| `ListShipmentItemsError` | `Errors/ListShipmentItemsError.cs` |
| `CommonErrorList` | `Models/CommonErrorList.cs` |

### ListShipmentPallets

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `ListShipmentPallets(string inboundPlanId, string shipmentId, int? pageSize, string? paginationToken, RequestOptions? requestOptions = null, CancellationToken ct = default)`
  - `pageSize` — nullable, no default → **must pass explicitly**
  - `paginationToken` — nullable, no default → **must pass explicitly**
- **Query params (wire ← C#)**: `pageSize` ← `pageSize`, `paginationToken` ← `paginationToken`
- **Returns**: `ListInboundPlanPalletsResponse`
- **Error**: `SdkException<ListShipmentPalletsError>` — **Case A (typed)**
- **Error accessors**: `TryGetCommonErrorList(out CommonErrorList)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `ListInboundPlanPalletsResponse` | `Models/ListInboundPlanPalletsResponse.cs` |
| `ListShipmentPalletsError` | `Errors/ListShipmentPalletsError.cs` |
| `CommonErrorList` | `Models/CommonErrorList.cs` |

### ListTransportationOptions

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `ListTransportationOptions(string inboundPlanId, int? pageSize, string? paginationToken, string? placementOptionId, string? shipmentId, RequestOptions? requestOptions = null, CancellationToken ct = default)`
  - 4 params (`pageSize` … `shipmentId`) — nullable, no default → **must pass explicitly** (pass `null` to skip)
- **Query params (wire ← C#)**: `pageSize` ← `pageSize`, `paginationToken` ← `paginationToken`, `placementOptionId` ← `placementOptionId`, `shipmentId` ← `shipmentId`
- **Returns**: `ListTransportationOptionsResponse`
- **Error**: `SdkException<ListTransportationOptionsError>` — **Case A (typed)**
- **Error accessors**: `TryGetCommonErrorList(out CommonErrorList)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `ListTransportationOptionsResponse` | `Models/ListTransportationOptionsResponse.cs` |
| `ListTransportationOptionsError` | `Errors/ListTransportationOptionsError.cs` |
| `CommonErrorList` | `Models/CommonErrorList.cs` |

### ScheduleSelfShipAppointment

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `ScheduleSelfShipAppointment(string inboundPlanId, string shipmentId, string slotId, ScheduleSelfShipAppointmentRequest body, RequestOptions? requestOptions = null, CancellationToken ct = default)`
- **Returns**: `ScheduleSelfShipAppointmentResponse`
- **Error**: `SdkException<ScheduleSelfShipAppointmentError>` — **Case A (typed)**
- **Error accessors**: `TryGetCommonErrorList(out CommonErrorList)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `ScheduleSelfShipAppointmentRequest` | `Models/ScheduleSelfShipAppointmentRequest.cs` |
| `ScheduleSelfShipAppointmentResponse` | `Models/ScheduleSelfShipAppointmentResponse.cs` |
| `ScheduleSelfShipAppointmentError` | `Errors/ScheduleSelfShipAppointmentError.cs` |
| `CommonErrorList` | `Models/CommonErrorList.cs` |

### SetPackingInformation

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `SetPackingInformation(string inboundPlanId, SetPackingInformationRequest body, RequestOptions? requestOptions = null, CancellationToken ct = default)`
- **Returns**: `CancelInboundPlanResponse`
- **Error**: `SdkException<SetPackingInformationError>` — **Case A (typed)**
- **Error accessors**: `TryGetCommonErrorList(out CommonErrorList)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `SetPackingInformationRequest` | `Models/SetPackingInformationRequest.cs` |
| `CancelInboundPlanResponse` | `Models/CancelInboundPlanResponse.cs` |
| `SetPackingInformationError` | `Errors/SetPackingInformationError.cs` |
| `CommonErrorList` | `Models/CommonErrorList.cs` |

### SetPrepDetails

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `SetPrepDetails(SetPrepDetailsRequest body, RequestOptions? requestOptions = null, CancellationToken ct = default)`
- **Returns**: `CancelInboundPlanResponse`
- **Error**: `SdkException<SetPrepDetailsError>` — **Case A (typed)**
- **Error accessors**: `TryGetCommonErrorList(out CommonErrorList)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `SetPrepDetailsRequest` | `Models/SetPrepDetailsRequest.cs` |
| `CancelInboundPlanResponse` | `Models/CancelInboundPlanResponse.cs` |
| `SetPrepDetailsError` | `Errors/SetPrepDetailsError.cs` |
| `CommonErrorList` | `Models/CommonErrorList.cs` |

### UpdateInboundPlanName

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `UpdateInboundPlanName(string inboundPlanId, UpdateInboundPlanNameRequest body, RequestOptions? requestOptions = null, CancellationToken ct = default)`
- **Returns**: `void` (Task)
- **Error**: `SdkException<UpdateInboundPlanNameError>` — **Case A (typed)**
- **Error accessors**: `TryGetCommonErrorList(out CommonErrorList)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `UpdateInboundPlanNameRequest` | `Models/UpdateInboundPlanNameRequest.cs` |
| `UpdateInboundPlanNameError` | `Errors/UpdateInboundPlanNameError.cs` |
| `CommonErrorList` | `Models/CommonErrorList.cs` |

### UpdateItemComplianceDetails

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `UpdateItemComplianceDetails(string marketplaceId, UpdateItemComplianceDetailsRequest body, RequestOptions? requestOptions = null, CancellationToken ct = default)`
- **Query params (wire ← C#)**: `marketplaceId` ← `marketplaceId`
- **Returns**: `CancelInboundPlanResponse`
- **Error**: `SdkException<UpdateItemComplianceDetailsError>` — **Case A (typed)**
- **Error accessors**: `TryGetCommonErrorList(out CommonErrorList)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `UpdateItemComplianceDetailsRequest` | `Models/UpdateItemComplianceDetailsRequest.cs` |
| `CancelInboundPlanResponse` | `Models/CancelInboundPlanResponse.cs` |
| `UpdateItemComplianceDetailsError` | `Errors/UpdateItemComplianceDetailsError.cs` |
| `CommonErrorList` | `Models/CommonErrorList.cs` |

### UpdateShipmentName

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `UpdateShipmentName(string inboundPlanId, string shipmentId, UpdateShipmentNameRequest body, RequestOptions? requestOptions = null, CancellationToken ct = default)`
- **Returns**: `void` (Task)
- **Error**: `SdkException<UpdateShipmentNameError>` — **Case A (typed)**
- **Error accessors**: `TryGetCommonErrorList(out CommonErrorList)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `UpdateShipmentNameRequest` | `Models/UpdateShipmentNameRequest.cs` |
| `UpdateShipmentNameError` | `Errors/UpdateShipmentNameError.cs` |
| `CommonErrorList` | `Models/CommonErrorList.cs` |

### UpdateShipmentSourceAddress

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `UpdateShipmentSourceAddress(string inboundPlanId, string shipmentId, UpdateShipmentSourceAddressRequest body, RequestOptions? requestOptions = null, CancellationToken ct = default)`
- **Returns**: `CancelInboundPlanResponse`
- **Error**: `SdkException<UpdateShipmentSourceAddressError>` — **Case A (typed)**
- **Error accessors**: `TryGetCommonErrorList(out CommonErrorList)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `UpdateShipmentSourceAddressRequest` | `Models/UpdateShipmentSourceAddressRequest.cs` |
| `CancelInboundPlanResponse` | `Models/CancelInboundPlanResponse.cs` |
| `UpdateShipmentSourceAddressError` | `Errors/UpdateShipmentSourceAddressError.cs` |
| `CommonErrorList` | `Models/CommonErrorList.cs` |

### UpdateShipmentTrackingDetails

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `UpdateShipmentTrackingDetails(string inboundPlanId, string shipmentId, UpdateShipmentTrackingDetailsRequest body, RequestOptions? requestOptions = null, CancellationToken ct = default)`
- **Returns**: `CancelInboundPlanResponse`
- **Error**: `SdkException<UpdateShipmentTrackingDetailsError>` — **Case A (typed)**
- **Error accessors**: `TryGetCommonErrorList(out CommonErrorList)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `UpdateShipmentTrackingDetailsRequest` | `Models/UpdateShipmentTrackingDetailsRequest.cs` |
| `CancelInboundPlanResponse` | `Models/CancelInboundPlanResponse.cs` |
| `UpdateShipmentTrackingDetailsError` | `Errors/UpdateShipmentTrackingDetailsError.cs` |
| `CommonErrorList` | `Models/CommonErrorList.cs` |

