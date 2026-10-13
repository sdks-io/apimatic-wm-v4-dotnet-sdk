<!-- Generated file — do not edit; regenerated with the SDK. -->

# WfsInventory — operations

Accessor: `client.WfsInventory` · Source: `src/WalmartApIs/Api/WfsInventory.cs` · 1 operation

**Type sources**: the file declaring each type an operation names (`RawError` excluded — see sdk-map.md).

### GetWfsInventoryItems

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `GetWfsInventoryItems(GetWfsInventoryItemsRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
- **Query params (wire ← C#)**: `skus` ← `Skus`, `pageSize` ← `PageSize`, `nextToken` ← `NextToken`
- **Returns**: `GetWfsInventoryResponse`
- **Error**: `ApiException<GetWfsInventoryItemsError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorList(out ErrorList)` [400, 403, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `GetWfsInventoryItemsRequest` | `src/WalmartApIs/Requests/WfsInventory/GetWfsInventoryItemsRequest.cs` |
| `GetWfsInventoryResponse` | `src/WalmartApIs/Models/GetWfsInventoryResponse.cs` |
| `GetWfsInventoryItemsError` | `src/WalmartApIs/Errors/GetWfsInventoryItemsError.cs` |
| `ErrorList` | `src/WalmartApIs/Models/ErrorList.cs` |

