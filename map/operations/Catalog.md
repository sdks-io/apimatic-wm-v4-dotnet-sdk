<!-- Generated file — do not edit; regenerated with the SDK. -->

# Catalog — operations

Accessor: `client.Catalog` · Source: `Api/Catalog.cs` · 2 operations

**Type sources**: the file declaring each type an operation names (`RawError` excluded — see sdk-map.md).

### GetCatalogItem

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `GetCatalogItem(string walmartItemId, IReadOnlyList<string> marketplaceIds, IReadOnlyList<IncludedDatum>? includedData, RequestOptions? requestOptions = null, CancellationToken ct = default)`
  - `includedData` — nullable, no default → **must pass explicitly**
- **Query params (wire ← C#)**: `marketplaceIds` ← `marketplaceIds`, `includedData` ← `includedData`
- **Returns**: `Item`
- **Error**: `SdkException<GetCatalogItemError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorList(out ErrorList)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `IncludedDatum` | `Models/Enums/IncludedDatum.cs` |
| `Item` | `Models/Item.cs` |
| `GetCatalogItemError` | `Errors/GetCatalogItemError.cs` |
| `ErrorList` | `Models/ErrorList.cs` |

### SearchCatalogItems

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `SearchCatalogItems(IReadOnlyList<string> marketplaceIds, string? keywords, string? walmartItemIds, string? sellerSku, string? gtin, string? upc, IReadOnlyList<IncludedDatum>? includedData, string? pageToken, int? pageSize = 10, RequestOptions? requestOptions = null, CancellationToken ct = default)`
  - 7 params (`keywords` … `pageToken`) — nullable, no default → **must pass explicitly** (pass `null` to skip)
  - defaults: `pageSize` = `10`
- **Query params (wire ← C#)**: `marketplaceIds` ← `marketplaceIds`, `keywords` ← `keywords`, `walmartItemIds` ← `walmartItemIds`, `sellerSku` ← `sellerSku`, `gtin` ← `gtin`, `upc` ← `upc`, `includedData` ← `includedData`, `pageSize` ← `pageSize`, `pageToken` ← `pageToken`
- **Returns**: `ItemSearchResults`
- **Error**: `SdkException<SearchCatalogItemsError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorList(out ErrorList)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `IncludedDatum` | `Models/Enums/IncludedDatum.cs` |
| `ItemSearchResults` | `Models/ItemSearchResults.cs` |
| `SearchCatalogItemsError` | `Errors/SearchCatalogItemsError.cs` |
| `ErrorList` | `Models/ErrorList.cs` |

