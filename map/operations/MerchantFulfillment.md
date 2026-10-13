<!-- Generated file — do not edit; regenerated with the SDK. -->

# MerchantFulfillment — operations

Accessor: `client.MerchantFulfillment` · Source: `src/WalmartApIs/Api/MerchantFulfillment.cs` · 5 operations

**Type sources**: the file declaring each type an operation names (`RawError` excluded — see sdk-map.md).

### CancelShipment

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `CancelShipment(CancelShipmentRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `ShipmentId`
- **Returns**: `CancelShipmentResponse`
- **Error**: `ApiException<CancelShipmentError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorList(out ErrorList)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `CancelShipmentRequest` | `src/WalmartApIs/Requests/MerchantFulfillment/CancelShipmentRequest.cs` |
| `CancelShipmentResponse` | `src/WalmartApIs/Models/CancelShipmentResponse.cs` |
| `CancelShipmentError` | `src/WalmartApIs/Errors/CancelShipmentError.cs` |
| `ErrorList` | `src/WalmartApIs/Models/ErrorList.cs` |

### CreateShipment

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `CreateShipment(CreateShipmentOperationRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `Body`
- **Returns**: `CreateShipmentResponse`
- **Error**: `ApiException<CreateShipmentError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorList(out ErrorList)` [400, 403, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `CreateShipmentOperationRequest` | `src/WalmartApIs/Requests/MerchantFulfillment/CreateShipmentOperationRequest.cs` |
| `CreateShipmentRequest` | `src/WalmartApIs/Models/CreateShipmentRequest.cs` |
| `CreateShipmentResponse` | `src/WalmartApIs/Models/CreateShipmentResponse.cs` |
| `CreateShipmentError` | `src/WalmartApIs/Errors/CreateShipmentError.cs` |
| `ErrorList` | `src/WalmartApIs/Models/ErrorList.cs` |

### GetEligibleShippingServices

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `GetEligibleShippingServices(GetEligibleShippingServicesOperationRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `Body`
- **Returns**: `GetEligibleShippingServicesResponse`
- **Error**: `ApiException<GetEligibleShippingServicesError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorList(out ErrorList)` [400, 403, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `GetEligibleShippingServicesOperationRequest` | `src/WalmartApIs/Requests/MerchantFulfillment/GetEligibleShippingServicesOperationRequest.cs` |
| `GetEligibleShippingServicesRequest` | `src/WalmartApIs/Models/GetEligibleShippingServicesRequest.cs` |
| `GetEligibleShippingServicesResponse` | `src/WalmartApIs/Models/GetEligibleShippingServicesResponse.cs` |
| `GetEligibleShippingServicesError` | `src/WalmartApIs/Errors/GetEligibleShippingServicesError.cs` |
| `ErrorList` | `src/WalmartApIs/Models/ErrorList.cs` |

### GetLabel

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `GetLabel(GetLabelRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `ShipmentId`
- **Query params (wire ← C#)**: `format` ← `Format`
- **Returns**: `Label`
- **Error**: `ApiException<GetLabelError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorList(out ErrorList)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `GetLabelRequest` | `src/WalmartApIs/Requests/MerchantFulfillment/GetLabelRequest.cs` |
| `Format` | `src/WalmartApIs/Models/Enums/Format.cs` |
| `Label` | `src/WalmartApIs/Models/Label.cs` |
| `GetLabelError` | `src/WalmartApIs/Errors/GetLabelError.cs` |
| `ErrorList` | `src/WalmartApIs/Models/ErrorList.cs` |

### GetShipment2

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `GetShipment2(GetShipment2Request request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `ShipmentId`
- **Returns**: `GetShipmentResponse`
- **Error**: `ApiException<GetShipment2Error>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorList(out ErrorList)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `GetShipment2Request` | `src/WalmartApIs/Requests/MerchantFulfillment/GetShipment2Request.cs` |
| `GetShipmentResponse` | `src/WalmartApIs/Models/GetShipmentResponse.cs` |
| `GetShipment2Error` | `src/WalmartApIs/Errors/GetShipment2Error.cs` |
| `ErrorList` | `src/WalmartApIs/Models/ErrorList.cs` |

