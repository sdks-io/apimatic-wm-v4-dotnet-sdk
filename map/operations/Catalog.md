<!-- Generated file — do not edit; regenerated with the SDK. -->

# Catalog — operations

Accessor: `client.Catalog` · Source: `src/WalmartApIs/Api/Catalog.cs` · 2 operations

**Type sources**: the file declaring each type an operation names (`RawError` excluded — see sdk-map.md).

### GetCatalogItem

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `GetCatalogItem(GetCatalogItemRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `WalmartItemId`, `MarketplaceIds`
- **Query params (wire ← C#)**: `marketplaceIds` ← `MarketplaceIds`, `includedData` ← `IncludedData`
- **Returns**: `Item`
- **Error**: `ApiException<GetCatalogItemError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorList(out ErrorList)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `GetCatalogItemRequest` | `src/WalmartApIs/Requests/Catalog/GetCatalogItemRequest.cs` |
| `IncludedDatum` | `src/WalmartApIs/Models/Enums/IncludedDatum.cs` |
| `Item` | `src/WalmartApIs/Models/Item.cs` |
| `GetCatalogItemError` | `src/WalmartApIs/Errors/GetCatalogItemError.cs` |
| `ErrorList` | `src/WalmartApIs/Models/ErrorList.cs` |

### SearchCatalogItems

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `SearchCatalogItems(SearchCatalogItemsRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `MarketplaceIds`
- **Query params (wire ← C#)**: `marketplaceIds` ← `MarketplaceIds`, `keywords` ← `Keywords`, `walmartItemIds` ← `WalmartItemIds`, `sellerSku` ← `SellerSku`, `gtin` ← `Gtin`, `upc` ← `Upc`, `includedData` ← `IncludedData`, `pageSize` ← `PageSize`, `pageToken` ← `PageToken`
- **Returns**: `ItemSearchResults`
- **Error**: `ApiException<SearchCatalogItemsError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorList(out ErrorList)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `SearchCatalogItemsRequest` | `src/WalmartApIs/Requests/Catalog/SearchCatalogItemsRequest.cs` |
| `IncludedDatum` | `src/WalmartApIs/Models/Enums/IncludedDatum.cs` |
| `ItemSearchResults` | `src/WalmartApIs/Models/ItemSearchResults.cs` |
| `SearchCatalogItemsError` | `src/WalmartApIs/Errors/SearchCatalogItemsError.cs` |
| `ErrorList` | `src/WalmartApIs/Models/ErrorList.cs` |

