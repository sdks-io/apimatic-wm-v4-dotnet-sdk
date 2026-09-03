<!-- Generated file — do not edit; regenerated with the SDK. -->

# Shipping — operations

Accessor: `client.Shipping` · Source: `Api/Shipping.cs` · 9 operations

**Type sources**: the file declaring each type an operation names (`RawError` excluded — see sdk-map.md).

### CancelShipment2

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `CancelShipment2(string shipmentId, RequestOptions? requestOptions = null, CancellationToken ct = default)`
- **Returns**: `CancelShipmentResponse1`
- **Error**: `SdkException<CancelShipment2Error>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorList(out ErrorList)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `CancelShipmentResponse1` | `Models/CancelShipmentResponse1.cs` |
| `CancelShipment2Error` | `Errors/CancelShipment2Error.cs` |
| `ErrorList` | `Models/ErrorList.cs` |

### GetAccessPoints

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `GetAccessPoints(string accessPointTypes, string countryCode, string postalCode, RequestOptions? requestOptions = null, CancellationToken ct = default)`
- **Query params (wire ← C#)**: `accessPointTypes` ← `accessPointTypes`, `countryCode` ← `countryCode`, `postalCode` ← `postalCode`
- **Returns**: `GetAccessPointsResponse`
- **Error**: `SdkException<GetAccessPointsError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorList(out ErrorList)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `GetAccessPointsResponse` | `Models/GetAccessPointsResponse.cs` |
| `GetAccessPointsError` | `Errors/GetAccessPointsError.cs` |
| `ErrorList` | `Models/ErrorList.cs` |

### GetAdditionalInputs

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `GetAdditionalInputs(string rateId, string requestToken, RequestOptions? requestOptions = null, CancellationToken ct = default)`
- **Query params (wire ← C#)**: `rateId` ← `rateId`, `requestToken` ← `requestToken`
- **Returns**: `GetAdditionalInputsResponse`
- **Error**: `SdkException<GetAdditionalInputsError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorList(out ErrorList)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `GetAdditionalInputsResponse` | `Models/GetAdditionalInputsResponse.cs` |
| `GetAdditionalInputsError` | `Errors/GetAdditionalInputsError.cs` |
| `ErrorList` | `Models/ErrorList.cs` |

### GetRates

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `GetRates(GetRatesRequest body, RequestOptions? requestOptions = null, CancellationToken ct = default)`
- **Returns**: `GetFulfillmentOrderResponse`
- **Error**: `SdkException<GetRatesError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorList(out ErrorList)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `GetRatesRequest` | `Models/GetRatesRequest.cs` |
| `GetFulfillmentOrderResponse` | `Models/GetFulfillmentOrderResponse.cs` |
| `GetRatesError` | `Errors/GetRatesError.cs` |
| `ErrorList` | `Models/ErrorList.cs` |

### GetShipmentDocuments

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `GetShipmentDocuments(string shipmentId, string? packageClientReferenceId, Format1? format, RequestOptions? requestOptions = null, CancellationToken ct = default)`
  - `packageClientReferenceId` — nullable, no default → **must pass explicitly**
  - `format` — nullable, no default → **must pass explicitly**
- **Query params (wire ← C#)**: `packageClientReferenceId` ← `packageClientReferenceId`, `format` ← `format`
- **Returns**: `GetShipmentDocumentsResponse`
- **Error**: `SdkException<GetShipmentDocumentsError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorList(out ErrorList)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `Format1` | `Models/Enums/Format1.cs` |
| `GetShipmentDocumentsResponse` | `Models/GetShipmentDocumentsResponse.cs` |
| `GetShipmentDocumentsError` | `Errors/GetShipmentDocumentsError.cs` |
| `ErrorList` | `Models/ErrorList.cs` |

### GetTracking

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `GetTracking(string trackingId, string? carrierId, RequestOptions? requestOptions = null, CancellationToken ct = default)`
  - `carrierId` — nullable, no default → **must pass explicitly**
- **Query params (wire ← C#)**: `trackingId` ← `trackingId`, `carrierId` ← `carrierId`
- **Returns**: `GetTrackingResponse`
- **Error**: `SdkException<GetTrackingError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorList(out ErrorList)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `GetTrackingResponse` | `Models/GetTrackingResponse.cs` |
| `GetTrackingError` | `Errors/GetTrackingError.cs` |
| `ErrorList` | `Models/ErrorList.cs` |

### OneClickShipment

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `OneClickShipment(OneClickShipmentRequest body, RequestOptions? requestOptions = null, CancellationToken ct = default)`
- **Returns**: `GetFulfillmentOrderShipmentsResponse`
- **Error**: `SdkException<OneClickShipmentError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorList(out ErrorList)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `OneClickShipmentRequest` | `Models/OneClickShipmentRequest.cs` |
| `GetFulfillmentOrderShipmentsResponse` | `Models/GetFulfillmentOrderShipmentsResponse.cs` |
| `OneClickShipmentError` | `Errors/OneClickShipmentError.cs` |
| `ErrorList` | `Models/ErrorList.cs` |

### PurchaseShipment

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `PurchaseShipment(PurchaseShipmentRequest body, RequestOptions? requestOptions = null, CancellationToken ct = default)`
- **Returns**: `GetFulfillmentOrderShipmentsResponse`
- **Error**: `SdkException<PurchaseShipmentError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorList(out ErrorList)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `PurchaseShipmentRequest` | `Models/PurchaseShipmentRequest.cs` |
| `GetFulfillmentOrderShipmentsResponse` | `Models/GetFulfillmentOrderShipmentsResponse.cs` |
| `PurchaseShipmentError` | `Errors/PurchaseShipmentError.cs` |
| `ErrorList` | `Models/ErrorList.cs` |

### SubmitNdrFeedback

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `SubmitNdrFeedback(SubmitNdrFeedbackRequest body, RequestOptions? requestOptions = null, CancellationToken ct = default)`
- **Returns**: `void` (Task)
- **Error**: `SdkException<SubmitNdrFeedbackError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorList(out ErrorList)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `SubmitNdrFeedbackRequest` | `Models/SubmitNdrFeedbackRequest.cs` |
| `SubmitNdrFeedbackError` | `Errors/SubmitNdrFeedbackError.cs` |
| `ErrorList` | `Models/ErrorList.cs` |

