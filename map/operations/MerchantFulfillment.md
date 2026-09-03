<!-- Generated file — do not edit; regenerated with the SDK. -->

# MerchantFulfillment — operations

Accessor: `client.MerchantFulfillment` · Source: `Api/MerchantFulfillment.cs` · 5 operations

**Type sources**: the file declaring each type an operation names (`RawError` excluded — see sdk-map.md).

### CancelShipment

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `CancelShipment(string shipmentId, RequestOptions? requestOptions = null, CancellationToken ct = default)`
- **Returns**: `CancelShipmentResponse`
- **Error**: `SdkException<CancelShipmentError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorList(out ErrorList)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `CancelShipmentResponse` | `Models/CancelShipmentResponse.cs` |
| `CancelShipmentError` | `Errors/CancelShipmentError.cs` |
| `ErrorList` | `Models/ErrorList.cs` |

### CreateShipment

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `CreateShipment(CreateShipmentRequest body, RequestOptions? requestOptions = null, CancellationToken ct = default)`
- **Returns**: `CreateShipmentResponse`
- **Error**: `SdkException<CreateShipmentError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorList(out ErrorList)` [400, 403, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `CreateShipmentRequest` | `Models/CreateShipmentRequest.cs` |
| `CreateShipmentResponse` | `Models/CreateShipmentResponse.cs` |
| `CreateShipmentError` | `Errors/CreateShipmentError.cs` |
| `ErrorList` | `Models/ErrorList.cs` |

### GetEligibleShippingServices

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `GetEligibleShippingServices(GetEligibleShippingServicesRequest body, RequestOptions? requestOptions = null, CancellationToken ct = default)`
- **Returns**: `GetEligibleShippingServicesResponse`
- **Error**: `SdkException<GetEligibleShippingServicesError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorList(out ErrorList)` [400, 403, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `GetEligibleShippingServicesRequest` | `Models/GetEligibleShippingServicesRequest.cs` |
| `GetEligibleShippingServicesResponse` | `Models/GetEligibleShippingServicesResponse.cs` |
| `GetEligibleShippingServicesError` | `Errors/GetEligibleShippingServicesError.cs` |
| `ErrorList` | `Models/ErrorList.cs` |

### GetLabel

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `GetLabel(string shipmentId, Format? format, RequestOptions? requestOptions = null, CancellationToken ct = default)`
  - `format` — nullable, no default → **must pass explicitly**
- **Query params (wire ← C#)**: `format` ← `format`
- **Returns**: `Label`
- **Error**: `SdkException<GetLabelError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorList(out ErrorList)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `Format` | `Models/Enums/Format.cs` |
| `Label` | `Models/Label.cs` |
| `GetLabelError` | `Errors/GetLabelError.cs` |
| `ErrorList` | `Models/ErrorList.cs` |

### GetShipment2

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `GetShipment2(string shipmentId, RequestOptions? requestOptions = null, CancellationToken ct = default)`
- **Returns**: `GetShipmentResponse`
- **Error**: `SdkException<GetShipment2Error>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorList(out ErrorList)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `GetShipmentResponse` | `Models/GetShipmentResponse.cs` |
| `GetShipment2Error` | `Errors/GetShipment2Error.cs` |
| `ErrorList` | `Models/ErrorList.cs` |

