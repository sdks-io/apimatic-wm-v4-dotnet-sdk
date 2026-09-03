<!-- Generated file — do not edit; regenerated with the SDK. -->

# FulfillmentOutbound — operations

Accessor: `client.FulfillmentOutbound` · Source: `Api/FulfillmentOutbound.cs` · 7 operations

**Type sources**: the file declaring each type an operation names (`RawError` excluded — see sdk-map.md).

### CancelFulfillmentOrder

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `CancelFulfillmentOrder(string sellerFulfillmentOrderId, RequestOptions? requestOptions = null, CancellationToken ct = default)`
- **Returns**: `CancelFulfillmentOrderResponse`
- **Error**: `SdkException<CancelFulfillmentOrderError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorList(out ErrorList)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `CancelFulfillmentOrderResponse` | `Models/CancelFulfillmentOrderResponse.cs` |
| `CancelFulfillmentOrderError` | `Errors/CancelFulfillmentOrderError.cs` |
| `ErrorList` | `Models/ErrorList.cs` |

### CreateFulfillmentOrder

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `CreateFulfillmentOrder(CreateFulfillmentOrderRequest body, RequestOptions? requestOptions = null, CancellationToken ct = default)`
- **Returns**: `CreateFulfillmentOrderResponse`
- **Error**: `SdkException<CreateFulfillmentOrderError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorList(out ErrorList)` [400, 403, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `CreateFulfillmentOrderRequest` | `Models/CreateFulfillmentOrderRequest.cs` |
| `CreateFulfillmentOrderResponse` | `Models/CreateFulfillmentOrderResponse.cs` |
| `CreateFulfillmentOrderError` | `Errors/CreateFulfillmentOrderError.cs` |
| `ErrorList` | `Models/ErrorList.cs` |

### GetFulfillmentOrder

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `GetFulfillmentOrder(string sellerFulfillmentOrderId, RequestOptions? requestOptions = null, CancellationToken ct = default)`
- **Returns**: `GetFulfillmentOrderResponse`
- **Error**: `SdkException<GetFulfillmentOrderError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorList(out ErrorList)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `GetFulfillmentOrderResponse` | `Models/GetFulfillmentOrderResponse.cs` |
| `GetFulfillmentOrderError` | `Errors/GetFulfillmentOrderError.cs` |
| `ErrorList` | `Models/ErrorList.cs` |

### GetFulfillmentOrderShipments

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `GetFulfillmentOrderShipments(string sellerFulfillmentOrderId, RequestOptions? requestOptions = null, CancellationToken ct = default)`
- **Returns**: `GetFulfillmentOrderShipmentsResponse`
- **Error**: `SdkException<GetFulfillmentOrderShipmentsError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorList(out ErrorList)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `GetFulfillmentOrderShipmentsResponse` | `Models/GetFulfillmentOrderShipmentsResponse.cs` |
| `GetFulfillmentOrderShipmentsError` | `Errors/GetFulfillmentOrderShipmentsError.cs` |
| `ErrorList` | `Models/ErrorList.cs` |

### GetFulfillmentPreview

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `GetFulfillmentPreview(GetFulfillmentPreviewRequest body, RequestOptions? requestOptions = null, CancellationToken ct = default)`
- **Returns**: `GetFulfillmentPreviewResponse`
- **Error**: `SdkException<GetFulfillmentPreviewError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorList(out ErrorList)` [400, 403, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `GetFulfillmentPreviewRequest` | `Models/GetFulfillmentPreviewRequest.cs` |
| `GetFulfillmentPreviewResponse` | `Models/GetFulfillmentPreviewResponse.cs` |
| `GetFulfillmentPreviewError` | `Errors/GetFulfillmentPreviewError.cs` |
| `ErrorList` | `Models/ErrorList.cs` |

### ListAllFulfillmentOrders

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `ListAllFulfillmentOrders(DateTimeOffset? queryStartDate, string? nextToken, RequestOptions? requestOptions = null, CancellationToken ct = default)`
  - `queryStartDate` — nullable, no default → **must pass explicitly**
  - `nextToken` — nullable, no default → **must pass explicitly**
- **Query params (wire ← C#)**: `queryStartDate` ← `queryStartDate`, `nextToken` ← `nextToken`
- **Returns**: `ListAllFulfillmentOrdersResponse`
- **Error**: `SdkException<ListAllFulfillmentOrdersError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorList(out ErrorList)` [400, 403, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `ListAllFulfillmentOrdersResponse` | `Models/ListAllFulfillmentOrdersResponse.cs` |
| `ListAllFulfillmentOrdersError` | `Errors/ListAllFulfillmentOrdersError.cs` |
| `ErrorList` | `Models/ErrorList.cs` |

### UpdateFulfillmentOrder

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `UpdateFulfillmentOrder(string sellerFulfillmentOrderId, UpdateFulfillmentOrderRequest body, RequestOptions? requestOptions = null, CancellationToken ct = default)`
- **Returns**: `UpdateFulfillmentOrderResponse`
- **Error**: `SdkException<UpdateFulfillmentOrderError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorList(out ErrorList)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `UpdateFulfillmentOrderRequest` | `Models/UpdateFulfillmentOrderRequest.cs` |
| `UpdateFulfillmentOrderResponse` | `Models/UpdateFulfillmentOrderResponse.cs` |
| `UpdateFulfillmentOrderError` | `Errors/UpdateFulfillmentOrderError.cs` |
| `ErrorList` | `Models/ErrorList.cs` |

