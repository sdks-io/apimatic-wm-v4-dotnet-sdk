<!-- Generated file — do not edit; regenerated with the SDK. -->

# Inventory — operations

Accessor: `client.Inventory` · Source: `src/WalmartApIs/Api/Inventory.cs` · 4 operations

**Type sources**: the file declaring each type an operation names (`RawError` excluded — see sdk-map.md).

### BulkUpdateInventory

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `BulkUpdateInventory(BulkUpdateInventoryOperationRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `Body`
- **Returns**: `BulkUpdateInventoryResponse`
- **Error**: `ApiException<BulkUpdateInventoryError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorList(out ErrorList)` [400, 403, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `BulkUpdateInventoryOperationRequest` | `src/WalmartApIs/Requests/Inventory/BulkUpdateInventoryOperationRequest.cs` |
| `BulkUpdateInventoryRequest` | `src/WalmartApIs/Models/BulkUpdateInventoryRequest.cs` |
| `BulkUpdateInventoryResponse` | `src/WalmartApIs/Models/BulkUpdateInventoryResponse.cs` |
| `BulkUpdateInventoryError` | `src/WalmartApIs/Errors/BulkUpdateInventoryError.cs` |
| `ErrorList` | `src/WalmartApIs/Models/ErrorList.cs` |

### GetInventoryForSku

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `GetInventoryForSku(GetInventoryForSkuRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `Sku`
- **Query params (wire ← C#)**: `shipNode` ← `ShipNode`
- **Returns**: `InventorySummary`
- **Error**: `ApiException<GetInventoryForSkuError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorList(out ErrorList)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `GetInventoryForSkuRequest` | `src/WalmartApIs/Requests/Inventory/GetInventoryForSkuRequest.cs` |
| `InventorySummary` | `src/WalmartApIs/Models/InventorySummary.cs` |
| `GetInventoryForSkuError` | `src/WalmartApIs/Errors/GetInventoryForSkuError.cs` |
| `ErrorList` | `src/WalmartApIs/Models/ErrorList.cs` |

### GetInventorySummaries

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `GetInventorySummaries(GetInventorySummariesRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
- **Query params (wire ← C#)**: `skus` ← `Skus`, `shipNode` ← `ShipNode`, `pageSize` ← `PageSize`, `nextToken` ← `NextToken`
- **Returns**: `GetInventorySummariesResponse`
- **Error**: `ApiException<GetInventorySummariesError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorList(out ErrorList)` [400, 403, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `GetInventorySummariesRequest` | `src/WalmartApIs/Requests/Inventory/GetInventorySummariesRequest.cs` |
| `GetInventorySummariesResponse` | `src/WalmartApIs/Models/GetInventorySummariesResponse.cs` |
| `GetInventorySummariesError` | `src/WalmartApIs/Errors/GetInventorySummariesError.cs` |
| `ErrorList` | `src/WalmartApIs/Models/ErrorList.cs` |

### UpdateInventoryForSku

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `UpdateInventoryForSku(UpdateInventoryForSkuRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `Sku`, `Body`
- **Returns**: `UpdateInventoryResponse`
- **Error**: `ApiException<UpdateInventoryForSkuError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorList(out ErrorList)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `UpdateInventoryForSkuRequest` | `src/WalmartApIs/Requests/Inventory/UpdateInventoryForSkuRequest.cs` |
| `UpdateInventoryRequest` | `src/WalmartApIs/Models/UpdateInventoryRequest.cs` |
| `UpdateInventoryResponse` | `src/WalmartApIs/Models/UpdateInventoryResponse.cs` |
| `UpdateInventoryForSkuError` | `src/WalmartApIs/Errors/UpdateInventoryForSkuError.cs` |
| `ErrorList` | `src/WalmartApIs/Models/ErrorList.cs` |

