<!-- Generated file — do not edit; regenerated with the SDK. -->

# FulfillmentOutbound — operations

Accessor: `client.FulfillmentOutbound` · Source: `src/WalmartApIs/Api/FulfillmentOutbound.cs` · 7 operations

**Type sources**: the file declaring each type an operation names (`RawError` excluded — see sdk-map.md).

### CancelFulfillmentOrder

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `CancelFulfillmentOrder(CancelFulfillmentOrderRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `SellerFulfillmentOrderId`
- **Returns**: `CancelFulfillmentOrderResponse`
- **Error**: `ApiException<CancelFulfillmentOrderError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorList(out ErrorList)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `CancelFulfillmentOrderRequest` | `src/WalmartApIs/Requests/FulfillmentOutbound/CancelFulfillmentOrderRequest.cs` |
| `CancelFulfillmentOrderResponse` | `src/WalmartApIs/Models/CancelFulfillmentOrderResponse.cs` |
| `CancelFulfillmentOrderError` | `src/WalmartApIs/Errors/CancelFulfillmentOrderError.cs` |
| `ErrorList` | `src/WalmartApIs/Models/ErrorList.cs` |

### CreateFulfillmentOrder

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `CreateFulfillmentOrder(CreateFulfillmentOrderOperationRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `Body`
- **Returns**: `CreateFulfillmentOrderResponse`
- **Error**: `ApiException<CreateFulfillmentOrderError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorList(out ErrorList)` [400, 403, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `CreateFulfillmentOrderOperationRequest` | `src/WalmartApIs/Requests/FulfillmentOutbound/CreateFulfillmentOrderOperationRequest.cs` |
| `CreateFulfillmentOrderRequest` | `src/WalmartApIs/Models/CreateFulfillmentOrderRequest.cs` |
| `CreateFulfillmentOrderResponse` | `src/WalmartApIs/Models/CreateFulfillmentOrderResponse.cs` |
| `CreateFulfillmentOrderError` | `src/WalmartApIs/Errors/CreateFulfillmentOrderError.cs` |
| `ErrorList` | `src/WalmartApIs/Models/ErrorList.cs` |

### GetFulfillmentOrder

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `GetFulfillmentOrder(GetFulfillmentOrderRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `SellerFulfillmentOrderId`
- **Returns**: `GetFulfillmentOrderResponse`
- **Error**: `ApiException<GetFulfillmentOrderError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorList(out ErrorList)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `GetFulfillmentOrderRequest` | `src/WalmartApIs/Requests/FulfillmentOutbound/GetFulfillmentOrderRequest.cs` |
| `GetFulfillmentOrderResponse` | `src/WalmartApIs/Models/GetFulfillmentOrderResponse.cs` |
| `GetFulfillmentOrderError` | `src/WalmartApIs/Errors/GetFulfillmentOrderError.cs` |
| `ErrorList` | `src/WalmartApIs/Models/ErrorList.cs` |

### GetFulfillmentOrderShipments

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `GetFulfillmentOrderShipments(GetFulfillmentOrderShipmentsRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `SellerFulfillmentOrderId`
- **Returns**: `GetFulfillmentOrderShipmentsResponse`
- **Error**: `ApiException<GetFulfillmentOrderShipmentsError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorList(out ErrorList)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `GetFulfillmentOrderShipmentsRequest` | `src/WalmartApIs/Requests/FulfillmentOutbound/GetFulfillmentOrderShipmentsRequest.cs` |
| `GetFulfillmentOrderShipmentsResponse` | `src/WalmartApIs/Models/GetFulfillmentOrderShipmentsResponse.cs` |
| `GetFulfillmentOrderShipmentsError` | `src/WalmartApIs/Errors/GetFulfillmentOrderShipmentsError.cs` |
| `ErrorList` | `src/WalmartApIs/Models/ErrorList.cs` |

### GetFulfillmentPreview

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `GetFulfillmentPreview(GetFulfillmentPreviewOperationRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `Body`
- **Returns**: `GetFulfillmentPreviewResponse`
- **Error**: `ApiException<GetFulfillmentPreviewError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorList(out ErrorList)` [400, 403, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `GetFulfillmentPreviewOperationRequest` | `src/WalmartApIs/Requests/FulfillmentOutbound/GetFulfillmentPreviewOperationRequest.cs` |
| `GetFulfillmentPreviewRequest` | `src/WalmartApIs/Models/GetFulfillmentPreviewRequest.cs` |
| `GetFulfillmentPreviewResponse` | `src/WalmartApIs/Models/GetFulfillmentPreviewResponse.cs` |
| `GetFulfillmentPreviewError` | `src/WalmartApIs/Errors/GetFulfillmentPreviewError.cs` |
| `ErrorList` | `src/WalmartApIs/Models/ErrorList.cs` |

### ListAllFulfillmentOrders

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `ListAllFulfillmentOrders(ListAllFulfillmentOrdersRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
- **Query params (wire ← C#)**: `queryStartDate` ← `QueryStartDate`, `nextToken` ← `NextToken`
- **Returns**: `ListAllFulfillmentOrdersResponse`
- **Error**: `ApiException<ListAllFulfillmentOrdersError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorList(out ErrorList)` [400, 403, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `ListAllFulfillmentOrdersRequest` | `src/WalmartApIs/Requests/FulfillmentOutbound/ListAllFulfillmentOrdersRequest.cs` |
| `ListAllFulfillmentOrdersResponse` | `src/WalmartApIs/Models/ListAllFulfillmentOrdersResponse.cs` |
| `ListAllFulfillmentOrdersError` | `src/WalmartApIs/Errors/ListAllFulfillmentOrdersError.cs` |
| `ErrorList` | `src/WalmartApIs/Models/ErrorList.cs` |

### UpdateFulfillmentOrder

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `UpdateFulfillmentOrder(UpdateFulfillmentOrderOperationRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `SellerFulfillmentOrderId`, `Body`
- **Returns**: `UpdateFulfillmentOrderResponse`
- **Error**: `ApiException<UpdateFulfillmentOrderError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorList(out ErrorList)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `UpdateFulfillmentOrderOperationRequest` | `src/WalmartApIs/Requests/FulfillmentOutbound/UpdateFulfillmentOrderOperationRequest.cs` |
| `UpdateFulfillmentOrderRequest` | `src/WalmartApIs/Models/UpdateFulfillmentOrderRequest.cs` |
| `UpdateFulfillmentOrderResponse` | `src/WalmartApIs/Models/UpdateFulfillmentOrderResponse.cs` |
| `UpdateFulfillmentOrderError` | `src/WalmartApIs/Errors/UpdateFulfillmentOrderError.cs` |
| `ErrorList` | `src/WalmartApIs/Models/ErrorList.cs` |

