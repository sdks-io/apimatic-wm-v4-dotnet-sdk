<!-- Generated file — do not edit; regenerated with the SDK. -->

# Inventory — operations

Accessor: `client.Inventory` · Source: `Api/Inventory.cs` · 4 operations

**Type sources**: the file declaring each type an operation names (`RawError` excluded — see sdk-map.md).

### BulkUpdateInventory

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `BulkUpdateInventory(BulkUpdateInventoryRequest body, RequestOptions? requestOptions = null, CancellationToken ct = default)`
- **Returns**: `BulkUpdateInventoryResponse`
- **Error**: `SdkException<BulkUpdateInventoryError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorList(out ErrorList)` [400, 403, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `BulkUpdateInventoryRequest` | `Models/BulkUpdateInventoryRequest.cs` |
| `BulkUpdateInventoryResponse` | `Models/BulkUpdateInventoryResponse.cs` |
| `BulkUpdateInventoryError` | `Errors/BulkUpdateInventoryError.cs` |
| `ErrorList` | `Models/ErrorList.cs` |

### GetInventoryForSku

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `GetInventoryForSku(string sku, string? shipNode, RequestOptions? requestOptions = null, CancellationToken ct = default)`
  - `shipNode` — nullable, no default → **must pass explicitly**
- **Query params (wire ← C#)**: `shipNode` ← `shipNode`
- **Returns**: `InventorySummary`
- **Error**: `SdkException<GetInventoryForSkuError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorList(out ErrorList)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `InventorySummary` | `Models/InventorySummary.cs` |
| `GetInventoryForSkuError` | `Errors/GetInventoryForSkuError.cs` |
| `ErrorList` | `Models/ErrorList.cs` |

### GetInventorySummaries

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `GetInventorySummaries(string? skus, string? shipNode, string? nextToken, int? pageSize = 100, RequestOptions? requestOptions = null, CancellationToken ct = default)`
  - `skus` — nullable, no default → **must pass explicitly**
  - `shipNode` — nullable, no default → **must pass explicitly**
  - `nextToken` — nullable, no default → **must pass explicitly**
  - defaults: `pageSize` = `100`
- **Query params (wire ← C#)**: `skus` ← `skus`, `shipNode` ← `shipNode`, `pageSize` ← `pageSize`, `nextToken` ← `nextToken`
- **Returns**: `GetInventorySummariesResponse`
- **Error**: `SdkException<GetInventorySummariesError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorList(out ErrorList)` [400, 403, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `GetInventorySummariesResponse` | `Models/GetInventorySummariesResponse.cs` |
| `GetInventorySummariesError` | `Errors/GetInventorySummariesError.cs` |
| `ErrorList` | `Models/ErrorList.cs` |

### UpdateInventoryForSku

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `UpdateInventoryForSku(string sku, UpdateInventoryRequest body, RequestOptions? requestOptions = null, CancellationToken ct = default)`
- **Returns**: `UpdateInventoryResponse`
- **Error**: `SdkException<UpdateInventoryForSkuError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorList(out ErrorList)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `UpdateInventoryRequest` | `Models/UpdateInventoryRequest.cs` |
| `UpdateInventoryResponse` | `Models/UpdateInventoryResponse.cs` |
| `UpdateInventoryForSkuError` | `Errors/UpdateInventoryForSkuError.cs` |
| `ErrorList` | `Models/ErrorList.cs` |

