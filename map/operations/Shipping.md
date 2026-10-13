<!-- Generated file — do not edit; regenerated with the SDK. -->

# Shipping — operations

Accessor: `client.Shipping` · Source: `src/WalmartApIs/Api/Shipping.cs` · 9 operations

**Type sources**: the file declaring each type an operation names (`RawError` excluded — see sdk-map.md).

### CancelShipment2

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `CancelShipment2(CancelShipment2Request request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `ShipmentId`
- **Returns**: `CancelShipmentResponse1`
- **Error**: `ApiException<CancelShipment2Error>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorList(out ErrorList)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `CancelShipment2Request` | `src/WalmartApIs/Requests/Shipping/CancelShipment2Request.cs` |
| `CancelShipmentResponse1` | `src/WalmartApIs/Models/CancelShipmentResponse1.cs` |
| `CancelShipment2Error` | `src/WalmartApIs/Errors/CancelShipment2Error.cs` |
| `ErrorList` | `src/WalmartApIs/Models/ErrorList.cs` |

### GetAccessPoints

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `GetAccessPoints(GetAccessPointsRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `AccessPointTypes`, `CountryCode`, `PostalCode`
- **Query params (wire ← C#)**: `accessPointTypes` ← `AccessPointTypes`, `countryCode` ← `CountryCode`, `postalCode` ← `PostalCode`
- **Returns**: `GetAccessPointsResponse`
- **Error**: `ApiException<GetAccessPointsError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorList(out ErrorList)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `GetAccessPointsRequest` | `src/WalmartApIs/Requests/Shipping/GetAccessPointsRequest.cs` |
| `GetAccessPointsResponse` | `src/WalmartApIs/Models/GetAccessPointsResponse.cs` |
| `GetAccessPointsError` | `src/WalmartApIs/Errors/GetAccessPointsError.cs` |
| `ErrorList` | `src/WalmartApIs/Models/ErrorList.cs` |

### GetAdditionalInputs

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `GetAdditionalInputs(GetAdditionalInputsRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `RateId`, `RequestToken`
- **Query params (wire ← C#)**: `rateId` ← `RateId`, `requestToken` ← `RequestToken`
- **Returns**: `GetAdditionalInputsResponse`
- **Error**: `ApiException<GetAdditionalInputsError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorList(out ErrorList)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `GetAdditionalInputsRequest` | `src/WalmartApIs/Requests/Shipping/GetAdditionalInputsRequest.cs` |
| `GetAdditionalInputsResponse` | `src/WalmartApIs/Models/GetAdditionalInputsResponse.cs` |
| `GetAdditionalInputsError` | `src/WalmartApIs/Errors/GetAdditionalInputsError.cs` |
| `ErrorList` | `src/WalmartApIs/Models/ErrorList.cs` |

### GetRates

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `GetRates(GetRatesOperationRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `Body`
- **Returns**: `GetFulfillmentOrderResponse`
- **Error**: `ApiException<GetRatesError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorList(out ErrorList)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `GetRatesOperationRequest` | `src/WalmartApIs/Requests/Shipping/GetRatesOperationRequest.cs` |
| `GetRatesRequest` | `src/WalmartApIs/Models/GetRatesRequest.cs` |
| `GetFulfillmentOrderResponse` | `src/WalmartApIs/Models/GetFulfillmentOrderResponse.cs` |
| `GetRatesError` | `src/WalmartApIs/Errors/GetRatesError.cs` |
| `ErrorList` | `src/WalmartApIs/Models/ErrorList.cs` |

### GetShipmentDocuments

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `GetShipmentDocuments(GetShipmentDocumentsRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `ShipmentId`
- **Query params (wire ← C#)**: `packageClientReferenceId` ← `PackageClientReferenceId`, `format` ← `Format`
- **Returns**: `GetShipmentDocumentsResponse`
- **Error**: `ApiException<GetShipmentDocumentsError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorList(out ErrorList)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `GetShipmentDocumentsRequest` | `src/WalmartApIs/Requests/Shipping/GetShipmentDocumentsRequest.cs` |
| `Format1` | `src/WalmartApIs/Models/Enums/Format1.cs` |
| `GetShipmentDocumentsResponse` | `src/WalmartApIs/Models/GetShipmentDocumentsResponse.cs` |
| `GetShipmentDocumentsError` | `src/WalmartApIs/Errors/GetShipmentDocumentsError.cs` |
| `ErrorList` | `src/WalmartApIs/Models/ErrorList.cs` |

### GetTracking

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `GetTracking(GetTrackingRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `TrackingId`
- **Query params (wire ← C#)**: `trackingId` ← `TrackingId`, `carrierId` ← `CarrierId`
- **Returns**: `GetTrackingResponse`
- **Error**: `ApiException<GetTrackingError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorList(out ErrorList)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `GetTrackingRequest` | `src/WalmartApIs/Requests/Shipping/GetTrackingRequest.cs` |
| `GetTrackingResponse` | `src/WalmartApIs/Models/GetTrackingResponse.cs` |
| `GetTrackingError` | `src/WalmartApIs/Errors/GetTrackingError.cs` |
| `ErrorList` | `src/WalmartApIs/Models/ErrorList.cs` |

### OneClickShipment

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `OneClickShipment(OneClickShipmentOperationRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `Body`
- **Returns**: `GetFulfillmentOrderShipmentsResponse`
- **Error**: `ApiException<OneClickShipmentError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorList(out ErrorList)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `OneClickShipmentOperationRequest` | `src/WalmartApIs/Requests/Shipping/OneClickShipmentOperationRequest.cs` |
| `OneClickShipmentRequest` | `src/WalmartApIs/Models/OneClickShipmentRequest.cs` |
| `GetFulfillmentOrderShipmentsResponse` | `src/WalmartApIs/Models/GetFulfillmentOrderShipmentsResponse.cs` |
| `OneClickShipmentError` | `src/WalmartApIs/Errors/OneClickShipmentError.cs` |
| `ErrorList` | `src/WalmartApIs/Models/ErrorList.cs` |

### PurchaseShipment

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `PurchaseShipment(PurchaseShipmentOperationRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `Body`
- **Returns**: `GetFulfillmentOrderShipmentsResponse`
- **Error**: `ApiException<PurchaseShipmentError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorList(out ErrorList)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `PurchaseShipmentOperationRequest` | `src/WalmartApIs/Requests/Shipping/PurchaseShipmentOperationRequest.cs` |
| `PurchaseShipmentRequest` | `src/WalmartApIs/Models/PurchaseShipmentRequest.cs` |
| `GetFulfillmentOrderShipmentsResponse` | `src/WalmartApIs/Models/GetFulfillmentOrderShipmentsResponse.cs` |
| `PurchaseShipmentError` | `src/WalmartApIs/Errors/PurchaseShipmentError.cs` |
| `ErrorList` | `src/WalmartApIs/Models/ErrorList.cs` |

### SubmitNdrFeedback

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `SubmitNdrFeedback(SubmitNdrFeedbackOperationRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `Body`
- **Returns**: `void` (Task)
- **Error**: `ApiException<SubmitNdrFeedbackError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorList(out ErrorList)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `SubmitNdrFeedbackOperationRequest` | `src/WalmartApIs/Requests/Shipping/SubmitNdrFeedbackOperationRequest.cs` |
| `SubmitNdrFeedbackRequest` | `src/WalmartApIs/Models/SubmitNdrFeedbackRequest.cs` |
| `SubmitNdrFeedbackError` | `src/WalmartApIs/Errors/SubmitNdrFeedbackError.cs` |
| `ErrorList` | `src/WalmartApIs/Models/ErrorList.cs` |

