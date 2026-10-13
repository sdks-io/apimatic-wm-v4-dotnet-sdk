<!-- Generated file — do not edit; regenerated with the SDK. -->

# ListingsItems — operations

Accessor: `client.ListingsItems` · Source: `src/WalmartApIs/Api/ListingsItems.cs` · 5 operations

**Type sources**: the file declaring each type an operation names (`RawError` excluded — see sdk-map.md).

### DeleteListingsItem

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `DeleteListingsItem(DeleteListingsItemRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `SellerId`, `Sku`, `MarketplaceIds`
- **Query params (wire ← C#)**: `marketplaceIds` ← `MarketplaceIds`, `issueLocale` ← `IssueLocale`
- **Returns**: `ListingsItemSubmissionResponse`
- **Error**: `ApiException<DeleteListingsItemError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorList(out ErrorList)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `DeleteListingsItemRequest` | `src/WalmartApIs/Requests/ListingsItems/DeleteListingsItemRequest.cs` |
| `ListingsItemSubmissionResponse` | `src/WalmartApIs/Models/ListingsItemSubmissionResponse.cs` |
| `DeleteListingsItemError` | `src/WalmartApIs/Errors/DeleteListingsItemError.cs` |
| `ErrorList` | `src/WalmartApIs/Models/ErrorList.cs` |

### GetListingsItem

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `GetListingsItem(GetListingsItemRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `SellerId`, `Sku`, `MarketplaceIds`
- **Query params (wire ← C#)**: `marketplaceIds` ← `MarketplaceIds`, `issueLocale` ← `IssueLocale`, `includedData` ← `IncludedData`
- **Returns**: `Item1`
- **Error**: `ApiException<GetListingsItemError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorList(out ErrorList)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `GetListingsItemRequest` | `src/WalmartApIs/Requests/ListingsItems/GetListingsItemRequest.cs` |
| `IncludedDatum1` | `src/WalmartApIs/Models/Enums/IncludedDatum1.cs` |
| `Item1` | `src/WalmartApIs/Models/Item1.cs` |
| `GetListingsItemError` | `src/WalmartApIs/Errors/GetListingsItemError.cs` |
| `ErrorList` | `src/WalmartApIs/Models/ErrorList.cs` |

### PatchListingsItem

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `PatchListingsItem(PatchListingsItemRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `SellerId`, `Sku`, `MarketplaceIds`, `Body`
- **Query params (wire ← C#)**: `marketplaceIds` ← `MarketplaceIds`, `issueLocale` ← `IssueLocale`
- **Returns**: `ListingsItemSubmissionResponse`
- **Error**: `ApiException<PatchListingsItemError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorList(out ErrorList)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `PatchListingsItemRequest` | `src/WalmartApIs/Requests/ListingsItems/PatchListingsItemRequest.cs` |
| `ListingsItemPatchRequest` | `src/WalmartApIs/Models/ListingsItemPatchRequest.cs` |
| `ListingsItemSubmissionResponse` | `src/WalmartApIs/Models/ListingsItemSubmissionResponse.cs` |
| `PatchListingsItemError` | `src/WalmartApIs/Errors/PatchListingsItemError.cs` |
| `ErrorList` | `src/WalmartApIs/Models/ErrorList.cs` |

### PutListingsItem

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `PutListingsItem(PutListingsItemRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `SellerId`, `Sku`, `MarketplaceIds`, `Body`
- **Query params (wire ← C#)**: `marketplaceIds` ← `MarketplaceIds`, `issueLocale` ← `IssueLocale`
- **Returns**: `ListingsItemSubmissionResponse`
- **Error**: `ApiException<PutListingsItemError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorList(out ErrorList)` [400, 403, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `PutListingsItemRequest` | `src/WalmartApIs/Requests/ListingsItems/PutListingsItemRequest.cs` |
| `ListingsItemPutRequest` | `src/WalmartApIs/Models/ListingsItemPutRequest.cs` |
| `ListingsItemSubmissionResponse` | `src/WalmartApIs/Models/ListingsItemSubmissionResponse.cs` |
| `PutListingsItemError` | `src/WalmartApIs/Errors/PutListingsItemError.cs` |
| `ErrorList` | `src/WalmartApIs/Models/ErrorList.cs` |

### SearchListingsItems

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `SearchListingsItems(SearchListingsItemsRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `SellerId`, `MarketplaceIds`
- **Query params (wire ← C#)**: `marketplaceIds` ← `MarketplaceIds`, `includedData` ← `IncludedData`, `pageSize` ← `PageSize`, `pageToken` ← `PageToken`
- **Returns**: `ItemSearchResults1`
- **Error**: `ApiException<SearchListingsItemsError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorList(out ErrorList)` [400, 403, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `SearchListingsItemsRequest` | `src/WalmartApIs/Requests/ListingsItems/SearchListingsItemsRequest.cs` |
| `IncludedDatum1` | `src/WalmartApIs/Models/Enums/IncludedDatum1.cs` |
| `ItemSearchResults1` | `src/WalmartApIs/Models/ItemSearchResults1.cs` |
| `SearchListingsItemsError` | `src/WalmartApIs/Errors/SearchListingsItemsError.cs` |
| `ErrorList` | `src/WalmartApIs/Models/ErrorList.cs` |

