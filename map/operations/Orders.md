<!-- Generated file — do not edit; regenerated with the SDK. -->

# Orders — operations

Accessor: `client.Orders` · Source: `Api/Orders.cs` · 14 operations

**Type sources**: the file declaring each type an operation names (`RawError` excluded — see sdk-map.md).

### AcknowledgeOrder

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `AcknowledgeOrder(string purchaseOrderId, AcknowledgeOrderRequest body, RequestOptions? requestOptions = null, CancellationToken ct = default)`
- **Returns**: `AcknowledgeOrderResponse`
- **Error**: `SdkException<AcknowledgeOrderError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorList(out ErrorList)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `AcknowledgeOrderRequest` | `Models/AcknowledgeOrderRequest.cs` |
| `AcknowledgeOrderResponse` | `Models/AcknowledgeOrderResponse.cs` |
| `AcknowledgeOrderError` | `Errors/AcknowledgeOrderError.cs` |
| `ErrorList` | `Models/ErrorList.cs` |

### CancelOrderLines

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `CancelOrderLines(string purchaseOrderId, CancelOrderLinesRequest body, RequestOptions? requestOptions = null, CancellationToken ct = default)`
- **Returns**: `CancelOrderLinesResponse`
- **Error**: `SdkException<CancelOrderLinesError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorList(out ErrorList)` [400, 403, 404, 429, 500, 503] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `CancelOrderLinesRequest` | `Models/CancelOrderLinesRequest.cs` |
| `CancelOrderLinesResponse` | `Models/CancelOrderLinesResponse.cs` |
| `CancelOrderLinesError` | `Errors/CancelOrderLinesError.cs` |
| `ErrorList` | `Models/ErrorList.cs` |

### DeliverOrderLines

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `DeliverOrderLines(string purchaseOrderId, DeliverOrderLinesRequest body, RequestOptions? requestOptions = null, CancellationToken ct = default)`
- **Returns**: `DeliverOrderLinesResponse`
- **Error**: `SdkException<DeliverOrderLinesError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorList(out ErrorList)` [400, 403, 404, 429, 500, 503] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `DeliverOrderLinesRequest` | `Models/DeliverOrderLinesRequest.cs` |
| `DeliverOrderLinesResponse` | `Models/DeliverOrderLinesResponse.cs` |
| `DeliverOrderLinesError` | `Errors/DeliverOrderLinesError.cs` |
| `ErrorList` | `Models/ErrorList.cs` |

### GetOrder

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `GetOrder(string purchaseOrderId, RequestOptions? requestOptions = null, CancellationToken ct = default)`
- **Returns**: `GetOrderResponse`
- **Error**: `SdkException<GetOrderError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorList(out ErrorList)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `GetOrderResponse` | `Models/GetOrderResponse.cs` |
| `GetOrderError` | `Errors/GetOrderError.cs` |
| `ErrorList` | `Models/ErrorList.cs` |

### GetOrderAddress

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `GetOrderAddress(string purchaseOrderId, RequestOptions? requestOptions = null, CancellationToken ct = default)`
- **Returns**: `GetOrderAddressResponse`
- **Error**: `SdkException<GetOrderAddressError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorList(out ErrorList)` [400, 403, 404, 429, 500, 503] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `GetOrderAddressResponse` | `Models/GetOrderAddressResponse.cs` |
| `GetOrderAddressError` | `Errors/GetOrderAddressError.cs` |
| `ErrorList` | `Models/ErrorList.cs` |

### GetOrderBuyerInfo

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `GetOrderBuyerInfo(string purchaseOrderId, RequestOptions? requestOptions = null, CancellationToken ct = default)`
- **Returns**: `GetOrderBuyerInfoResponse`
- **Error**: `SdkException<GetOrderBuyerInfoError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorList(out ErrorList)` [400, 403, 404, 429, 500, 503] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `GetOrderBuyerInfoResponse` | `Models/GetOrderBuyerInfoResponse.cs` |
| `GetOrderBuyerInfoError` | `Errors/GetOrderBuyerInfoError.cs` |
| `ErrorList` | `Models/ErrorList.cs` |

### GetOrderItems

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `GetOrderItems(string purchaseOrderId, RequestOptions? requestOptions = null, CancellationToken ct = default)`
- **Returns**: `GetFulfillmentOrderShipmentsResponse`
- **Error**: `SdkException<GetOrderItemsError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorList(out ErrorList)` [400, 403, 404, 429, 500, 503] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `GetFulfillmentOrderShipmentsResponse` | `Models/GetFulfillmentOrderShipmentsResponse.cs` |
| `GetOrderItemsError` | `Errors/GetOrderItemsError.cs` |
| `ErrorList` | `Models/ErrorList.cs` |

### GetOrderRegulatedInfo

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `GetOrderRegulatedInfo(string purchaseOrderId, RequestOptions? requestOptions = null, CancellationToken ct = default)`
- **Returns**: `GetOrderRegulatedInfoResponse`
- **Error**: `SdkException<GetOrderRegulatedInfoError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorList(out ErrorList)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `GetOrderRegulatedInfoResponse` | `Models/GetOrderRegulatedInfoResponse.cs` |
| `GetOrderRegulatedInfoError` | `Errors/GetOrderRegulatedInfoError.cs` |
| `ErrorList` | `Models/ErrorList.cs` |

### GetOrders

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `GetOrders(DateTimeOffset? createdAfter, DateTimeOffset? createdBefore, DateTimeOffset? lastUpdatedAfter, IReadOnlyList<OrderStatus>? orderStatuses, IReadOnlyList<FulfillmentType>? fulfillmentTypes, string? nextToken, int? pageSize = 100, RequestOptions? requestOptions = null, CancellationToken ct = default)`
  - 6 params (`createdAfter` … `nextToken`) — nullable, no default → **must pass explicitly** (pass `null` to skip)
  - defaults: `pageSize` = `100`
- **Query params (wire ← C#)**: `createdAfter` ← `createdAfter`, `createdBefore` ← `createdBefore`, `lastUpdatedAfter` ← `lastUpdatedAfter`, `orderStatuses` ← `orderStatuses`, `fulfillmentTypes` ← `fulfillmentTypes`, `pageSize` ← `pageSize`, `nextToken` ← `nextToken`
- **Returns**: `GetFulfillmentOrderResponse`
- **Error**: `SdkException<GetOrdersError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorList(out ErrorList)` [400, 403, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `OrderStatus` | `Models/Enums/OrderStatus.cs` |
| `FulfillmentType` | `Models/Enums/FulfillmentType.cs` |
| `GetFulfillmentOrderResponse` | `Models/GetFulfillmentOrderResponse.cs` |
| `GetOrdersError` | `Errors/GetOrdersError.cs` |
| `ErrorList` | `Models/ErrorList.cs` |

### RefundOrderLines

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `RefundOrderLines(string purchaseOrderId, RefundOrderLinesRequest body, RequestOptions? requestOptions = null, CancellationToken ct = default)`
- **Returns**: `RefundOrderLinesResponse`
- **Error**: `SdkException<RefundOrderLinesError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorList(out ErrorList)` [400, 403, 404, 429, 500, 503] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `RefundOrderLinesRequest` | `Models/RefundOrderLinesRequest.cs` |
| `RefundOrderLinesResponse` | `Models/RefundOrderLinesResponse.cs` |
| `RefundOrderLinesError` | `Errors/RefundOrderLinesError.cs` |
| `ErrorList` | `Models/ErrorList.cs` |

### ShipOrderLines

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `ShipOrderLines(string purchaseOrderId, ShipOrderLinesRequest body, RequestOptions? requestOptions = null, CancellationToken ct = default)`
- **Returns**: `ShipOrderLinesResponse`
- **Error**: `SdkException<ShipOrderLinesError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorList(out ErrorList)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `ShipOrderLinesRequest` | `Models/ShipOrderLinesRequest.cs` |
| `ShipOrderLinesResponse` | `Models/ShipOrderLinesResponse.cs` |
| `ShipOrderLinesError` | `Errors/ShipOrderLinesError.cs` |
| `ErrorList` | `Models/ErrorList.cs` |

### ShipOrderMultiPackage

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `ShipOrderMultiPackage(string purchaseOrderId, MultiPackageShipRequest body, RequestOptions? requestOptions = null, CancellationToken ct = default)`
- **Returns**: `MultiPackageShipResponse`
- **Error**: `SdkException<ShipOrderMultiPackageError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorList(out ErrorList)` [400, 403, 404, 429, 500, 503] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `MultiPackageShipRequest` | `Models/MultiPackageShipRequest.cs` |
| `MultiPackageShipResponse` | `Models/MultiPackageShipResponse.cs` |
| `ShipOrderMultiPackageError` | `Errors/ShipOrderMultiPackageError.cs` |
| `ErrorList` | `Models/ErrorList.cs` |

### UpdateShipmentStatus

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `UpdateShipmentStatus(string purchaseOrderId, UpdateShipmentStatusRequest body, RequestOptions? requestOptions = null, CancellationToken ct = default)`
- **Returns**: `UpdateShipmentStatusResponse`
- **Error**: `SdkException<UpdateShipmentStatusError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorList(out ErrorList)` [400, 403, 404, 429, 500, 503] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `UpdateShipmentStatusRequest` | `Models/UpdateShipmentStatusRequest.cs` |
| `UpdateShipmentStatusResponse` | `Models/UpdateShipmentStatusResponse.cs` |
| `UpdateShipmentStatusError` | `Errors/UpdateShipmentStatusError.cs` |
| `ErrorList` | `Models/ErrorList.cs` |

### UpdateVerificationStatus

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `UpdateVerificationStatus(string purchaseOrderId, UpdateVerificationStatusRequest body, RequestOptions? requestOptions = null, CancellationToken ct = default)`
- **Returns**: `UpdateVerificationStatusResponse`
- **Error**: `SdkException<UpdateVerificationStatusError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorList(out ErrorList)` [400, 403, 404, 429, 500, 503] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `UpdateVerificationStatusRequest` | `Models/UpdateVerificationStatusRequest.cs` |
| `UpdateVerificationStatusResponse` | `Models/UpdateVerificationStatusResponse.cs` |
| `UpdateVerificationStatusError` | `Errors/UpdateVerificationStatusError.cs` |
| `ErrorList` | `Models/ErrorList.cs` |

