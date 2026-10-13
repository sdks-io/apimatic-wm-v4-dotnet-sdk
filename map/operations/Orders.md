<!-- Generated file — do not edit; regenerated with the SDK. -->

# Orders — operations

Accessor: `client.Orders` · Source: `src/WalmartApIs/Api/Orders.cs` · 14 operations

**Type sources**: the file declaring each type an operation names (`RawError` excluded — see sdk-map.md).

### AcknowledgeOrder

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `AcknowledgeOrder(AcknowledgeOrderOperationRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `PurchaseOrderId`, `Body`
- **Returns**: `AcknowledgeOrderResponse`
- **Error**: `ApiException<AcknowledgeOrderError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorList(out ErrorList)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `AcknowledgeOrderOperationRequest` | `src/WalmartApIs/Requests/Orders/AcknowledgeOrderOperationRequest.cs` |
| `AcknowledgeOrderRequest` | `src/WalmartApIs/Models/AcknowledgeOrderRequest.cs` |
| `AcknowledgeOrderResponse` | `src/WalmartApIs/Models/AcknowledgeOrderResponse.cs` |
| `AcknowledgeOrderError` | `src/WalmartApIs/Errors/AcknowledgeOrderError.cs` |
| `ErrorList` | `src/WalmartApIs/Models/ErrorList.cs` |

### CancelOrderLines

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `CancelOrderLines(CancelOrderLinesOperationRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `PurchaseOrderId`, `Body`
- **Returns**: `CancelOrderLinesResponse`
- **Error**: `ApiException<CancelOrderLinesError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorList(out ErrorList)` [400, 403, 404, 429, 500, 503] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `CancelOrderLinesOperationRequest` | `src/WalmartApIs/Requests/Orders/CancelOrderLinesOperationRequest.cs` |
| `CancelOrderLinesRequest` | `src/WalmartApIs/Models/CancelOrderLinesRequest.cs` |
| `CancelOrderLinesResponse` | `src/WalmartApIs/Models/CancelOrderLinesResponse.cs` |
| `CancelOrderLinesError` | `src/WalmartApIs/Errors/CancelOrderLinesError.cs` |
| `ErrorList` | `src/WalmartApIs/Models/ErrorList.cs` |

### DeliverOrderLines

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `DeliverOrderLines(DeliverOrderLinesOperationRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `PurchaseOrderId`, `Body`
- **Returns**: `DeliverOrderLinesResponse`
- **Error**: `ApiException<DeliverOrderLinesError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorList(out ErrorList)` [400, 403, 404, 429, 500, 503] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `DeliverOrderLinesOperationRequest` | `src/WalmartApIs/Requests/Orders/DeliverOrderLinesOperationRequest.cs` |
| `DeliverOrderLinesRequest` | `src/WalmartApIs/Models/DeliverOrderLinesRequest.cs` |
| `DeliverOrderLinesResponse` | `src/WalmartApIs/Models/DeliverOrderLinesResponse.cs` |
| `DeliverOrderLinesError` | `src/WalmartApIs/Errors/DeliverOrderLinesError.cs` |
| `ErrorList` | `src/WalmartApIs/Models/ErrorList.cs` |

### GetOrder

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `GetOrder(GetOrderRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `PurchaseOrderId`
- **Returns**: `GetOrderResponse`
- **Error**: `ApiException<GetOrderError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorList(out ErrorList)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `GetOrderRequest` | `src/WalmartApIs/Requests/Orders/GetOrderRequest.cs` |
| `GetOrderResponse` | `src/WalmartApIs/Models/GetOrderResponse.cs` |
| `GetOrderError` | `src/WalmartApIs/Errors/GetOrderError.cs` |
| `ErrorList` | `src/WalmartApIs/Models/ErrorList.cs` |

### GetOrderAddress

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `GetOrderAddress(GetOrderAddressRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `PurchaseOrderId`
- **Returns**: `GetOrderAddressResponse`
- **Error**: `ApiException<GetOrderAddressError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorList(out ErrorList)` [400, 403, 404, 429, 500, 503] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `GetOrderAddressRequest` | `src/WalmartApIs/Requests/Orders/GetOrderAddressRequest.cs` |
| `GetOrderAddressResponse` | `src/WalmartApIs/Models/GetOrderAddressResponse.cs` |
| `GetOrderAddressError` | `src/WalmartApIs/Errors/GetOrderAddressError.cs` |
| `ErrorList` | `src/WalmartApIs/Models/ErrorList.cs` |

### GetOrderBuyerInfo

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `GetOrderBuyerInfo(GetOrderBuyerInfoRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `PurchaseOrderId`
- **Returns**: `GetOrderBuyerInfoResponse`
- **Error**: `ApiException<GetOrderBuyerInfoError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorList(out ErrorList)` [400, 403, 404, 429, 500, 503] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `GetOrderBuyerInfoRequest` | `src/WalmartApIs/Requests/Orders/GetOrderBuyerInfoRequest.cs` |
| `GetOrderBuyerInfoResponse` | `src/WalmartApIs/Models/GetOrderBuyerInfoResponse.cs` |
| `GetOrderBuyerInfoError` | `src/WalmartApIs/Errors/GetOrderBuyerInfoError.cs` |
| `ErrorList` | `src/WalmartApIs/Models/ErrorList.cs` |

### GetOrderItems

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `GetOrderItems(GetOrderItemsRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `PurchaseOrderId`
- **Returns**: `GetFulfillmentOrderShipmentsResponse`
- **Error**: `ApiException<GetOrderItemsError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorList(out ErrorList)` [400, 403, 404, 429, 500, 503] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `GetOrderItemsRequest` | `src/WalmartApIs/Requests/Orders/GetOrderItemsRequest.cs` |
| `GetFulfillmentOrderShipmentsResponse` | `src/WalmartApIs/Models/GetFulfillmentOrderShipmentsResponse.cs` |
| `GetOrderItemsError` | `src/WalmartApIs/Errors/GetOrderItemsError.cs` |
| `ErrorList` | `src/WalmartApIs/Models/ErrorList.cs` |

### GetOrderRegulatedInfo

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `GetOrderRegulatedInfo(GetOrderRegulatedInfoRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `PurchaseOrderId`
- **Returns**: `GetOrderRegulatedInfoResponse`
- **Error**: `ApiException<GetOrderRegulatedInfoError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorList(out ErrorList)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `GetOrderRegulatedInfoRequest` | `src/WalmartApIs/Requests/Orders/GetOrderRegulatedInfoRequest.cs` |
| `GetOrderRegulatedInfoResponse` | `src/WalmartApIs/Models/GetOrderRegulatedInfoResponse.cs` |
| `GetOrderRegulatedInfoError` | `src/WalmartApIs/Errors/GetOrderRegulatedInfoError.cs` |
| `ErrorList` | `src/WalmartApIs/Models/ErrorList.cs` |

### GetOrders

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `GetOrders(GetOrdersRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
- **Query params (wire ← C#)**: `createdAfter` ← `CreatedAfter`, `createdBefore` ← `CreatedBefore`, `lastUpdatedAfter` ← `LastUpdatedAfter`, `orderStatuses` ← `OrderStatuses`, `fulfillmentTypes` ← `FulfillmentTypes`, `pageSize` ← `PageSize`, `nextToken` ← `NextToken`
- **Returns**: `GetFulfillmentOrderResponse`
- **Error**: `ApiException<GetOrdersError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorList(out ErrorList)` [400, 403, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `GetOrdersRequest` | `src/WalmartApIs/Requests/Orders/GetOrdersRequest.cs` |
| `OrderStatus` | `src/WalmartApIs/Models/Enums/OrderStatus.cs` |
| `FulfillmentType` | `src/WalmartApIs/Models/Enums/FulfillmentType.cs` |
| `GetFulfillmentOrderResponse` | `src/WalmartApIs/Models/GetFulfillmentOrderResponse.cs` |
| `GetOrdersError` | `src/WalmartApIs/Errors/GetOrdersError.cs` |
| `ErrorList` | `src/WalmartApIs/Models/ErrorList.cs` |

### RefundOrderLines

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `RefundOrderLines(RefundOrderLinesOperationRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `PurchaseOrderId`, `Body`
- **Returns**: `RefundOrderLinesResponse`
- **Error**: `ApiException<RefundOrderLinesError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorList(out ErrorList)` [400, 403, 404, 429, 500, 503] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `RefundOrderLinesOperationRequest` | `src/WalmartApIs/Requests/Orders/RefundOrderLinesOperationRequest.cs` |
| `RefundOrderLinesRequest` | `src/WalmartApIs/Models/RefundOrderLinesRequest.cs` |
| `RefundOrderLinesResponse` | `src/WalmartApIs/Models/RefundOrderLinesResponse.cs` |
| `RefundOrderLinesError` | `src/WalmartApIs/Errors/RefundOrderLinesError.cs` |
| `ErrorList` | `src/WalmartApIs/Models/ErrorList.cs` |

### ShipOrderLines

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `ShipOrderLines(ShipOrderLinesOperationRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `PurchaseOrderId`, `Body`
- **Returns**: `ShipOrderLinesResponse`
- **Error**: `ApiException<ShipOrderLinesError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorList(out ErrorList)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `ShipOrderLinesOperationRequest` | `src/WalmartApIs/Requests/Orders/ShipOrderLinesOperationRequest.cs` |
| `ShipOrderLinesRequest` | `src/WalmartApIs/Models/ShipOrderLinesRequest.cs` |
| `ShipOrderLinesResponse` | `src/WalmartApIs/Models/ShipOrderLinesResponse.cs` |
| `ShipOrderLinesError` | `src/WalmartApIs/Errors/ShipOrderLinesError.cs` |
| `ErrorList` | `src/WalmartApIs/Models/ErrorList.cs` |

### ShipOrderMultiPackage

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `ShipOrderMultiPackage(ShipOrderMultiPackageRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `PurchaseOrderId`, `Body`
- **Returns**: `MultiPackageShipResponse`
- **Error**: `ApiException<ShipOrderMultiPackageError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorList(out ErrorList)` [400, 403, 404, 429, 500, 503] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `ShipOrderMultiPackageRequest` | `src/WalmartApIs/Requests/Orders/ShipOrderMultiPackageRequest.cs` |
| `MultiPackageShipRequest` | `src/WalmartApIs/Models/MultiPackageShipRequest.cs` |
| `MultiPackageShipResponse` | `src/WalmartApIs/Models/MultiPackageShipResponse.cs` |
| `ShipOrderMultiPackageError` | `src/WalmartApIs/Errors/ShipOrderMultiPackageError.cs` |
| `ErrorList` | `src/WalmartApIs/Models/ErrorList.cs` |

### UpdateShipmentStatus

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `UpdateShipmentStatus(UpdateShipmentStatusOperationRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `PurchaseOrderId`, `Body`
- **Returns**: `UpdateShipmentStatusResponse`
- **Error**: `ApiException<UpdateShipmentStatusError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorList(out ErrorList)` [400, 403, 404, 429, 500, 503] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `UpdateShipmentStatusOperationRequest` | `src/WalmartApIs/Requests/Orders/UpdateShipmentStatusOperationRequest.cs` |
| `UpdateShipmentStatusRequest` | `src/WalmartApIs/Models/UpdateShipmentStatusRequest.cs` |
| `UpdateShipmentStatusResponse` | `src/WalmartApIs/Models/UpdateShipmentStatusResponse.cs` |
| `UpdateShipmentStatusError` | `src/WalmartApIs/Errors/UpdateShipmentStatusError.cs` |
| `ErrorList` | `src/WalmartApIs/Models/ErrorList.cs` |

### UpdateVerificationStatus

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `UpdateVerificationStatus(UpdateVerificationStatusOperationRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `PurchaseOrderId`, `Body`
- **Returns**: `UpdateVerificationStatusResponse`
- **Error**: `ApiException<UpdateVerificationStatusError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorList(out ErrorList)` [400, 403, 404, 429, 500, 503] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `UpdateVerificationStatusOperationRequest` | `src/WalmartApIs/Requests/Orders/UpdateVerificationStatusOperationRequest.cs` |
| `UpdateVerificationStatusRequest` | `src/WalmartApIs/Models/UpdateVerificationStatusRequest.cs` |
| `UpdateVerificationStatusResponse` | `src/WalmartApIs/Models/UpdateVerificationStatusResponse.cs` |
| `UpdateVerificationStatusError` | `src/WalmartApIs/Errors/UpdateVerificationStatusError.cs` |
| `ErrorList` | `src/WalmartApIs/Models/ErrorList.cs` |

