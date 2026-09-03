<!-- Generated file — do not edit; regenerated with the SDK. -->

# WfsInventory — operations

Accessor: `client.WfsInventory` · Source: `Api/WfsInventory.cs` · 1 operation

**Type sources**: the file declaring each type an operation names (`RawError` excluded — see sdk-map.md).

### GetWfsInventoryItems

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `GetWfsInventoryItems(string? skus, string? nextToken, int? pageSize = 100, RequestOptions? requestOptions = null, CancellationToken ct = default)`
  - `skus` — nullable, no default → **must pass explicitly**
  - `nextToken` — nullable, no default → **must pass explicitly**
  - defaults: `pageSize` = `100`
- **Query params (wire ← C#)**: `skus` ← `skus`, `pageSize` ← `pageSize`, `nextToken` ← `nextToken`
- **Returns**: `GetWfsInventoryResponse`
- **Error**: `SdkException<GetWfsInventoryItemsError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorList(out ErrorList)` [400, 403, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `GetWfsInventoryResponse` | `Models/GetWfsInventoryResponse.cs` |
| `GetWfsInventoryItemsError` | `Errors/GetWfsInventoryItemsError.cs` |
| `ErrorList` | `Models/ErrorList.cs` |

