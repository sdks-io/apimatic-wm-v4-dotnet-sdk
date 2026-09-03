<!-- Generated file — do not edit; regenerated with the SDK. -->

# ListingsItems — operations

Accessor: `client.ListingsItems` · Source: `Api/ListingsItems.cs` · 5 operations

**Type sources**: the file declaring each type an operation names (`RawError` excluded — see sdk-map.md).

### DeleteListingsItem

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `DeleteListingsItem(string sellerId, string sku, IReadOnlyList<string> marketplaceIds, string? issueLocale = "en_US", RequestOptions? requestOptions = null, CancellationToken ct = default)`
  - defaults: `issueLocale` = `"en_US"`
- **Query params (wire ← C#)**: `marketplaceIds` ← `marketplaceIds`, `issueLocale` ← `issueLocale`
- **Returns**: `ListingsItemSubmissionResponse`
- **Error**: `SdkException<DeleteListingsItemError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorList(out ErrorList)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `ListingsItemSubmissionResponse` | `Models/ListingsItemSubmissionResponse.cs` |
| `DeleteListingsItemError` | `Errors/DeleteListingsItemError.cs` |
| `ErrorList` | `Models/ErrorList.cs` |

### GetListingsItem

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `GetListingsItem(string sellerId, string sku, IReadOnlyList<string> marketplaceIds, IReadOnlyList<IncludedDatum1>? includedData, string? issueLocale = "en_US", RequestOptions? requestOptions = null, CancellationToken ct = default)`
  - `includedData` — nullable, no default → **must pass explicitly**
  - defaults: `issueLocale` = `"en_US"`
- **Query params (wire ← C#)**: `marketplaceIds` ← `marketplaceIds`, `issueLocale` ← `issueLocale`, `includedData` ← `includedData`
- **Returns**: `Item1`
- **Error**: `SdkException<GetListingsItemError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorList(out ErrorList)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `IncludedDatum1` | `Models/Enums/IncludedDatum1.cs` |
| `Item1` | `Models/Item1.cs` |
| `GetListingsItemError` | `Errors/GetListingsItemError.cs` |
| `ErrorList` | `Models/ErrorList.cs` |

### PatchListingsItem

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `PatchListingsItem(string sellerId, string sku, IReadOnlyList<string> marketplaceIds, ListingsItemPatchRequest body, string? issueLocale = "en_US", RequestOptions? requestOptions = null, CancellationToken ct = default)`
  - defaults: `issueLocale` = `"en_US"`
- **Query params (wire ← C#)**: `marketplaceIds` ← `marketplaceIds`, `issueLocale` ← `issueLocale`
- **Returns**: `ListingsItemSubmissionResponse`
- **Error**: `SdkException<PatchListingsItemError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorList(out ErrorList)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `ListingsItemPatchRequest` | `Models/ListingsItemPatchRequest.cs` |
| `ListingsItemSubmissionResponse` | `Models/ListingsItemSubmissionResponse.cs` |
| `PatchListingsItemError` | `Errors/PatchListingsItemError.cs` |
| `ErrorList` | `Models/ErrorList.cs` |

### PutListingsItem

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `PutListingsItem(string sellerId, string sku, IReadOnlyList<string> marketplaceIds, ListingsItemPutRequest body, string? issueLocale = "en_US", RequestOptions? requestOptions = null, CancellationToken ct = default)`
  - defaults: `issueLocale` = `"en_US"`
- **Query params (wire ← C#)**: `marketplaceIds` ← `marketplaceIds`, `issueLocale` ← `issueLocale`
- **Returns**: `ListingsItemSubmissionResponse`
- **Error**: `SdkException<PutListingsItemError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorList(out ErrorList)` [400, 403, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `ListingsItemPutRequest` | `Models/ListingsItemPutRequest.cs` |
| `ListingsItemSubmissionResponse` | `Models/ListingsItemSubmissionResponse.cs` |
| `PutListingsItemError` | `Errors/PutListingsItemError.cs` |
| `ErrorList` | `Models/ErrorList.cs` |

### SearchListingsItems

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `SearchListingsItems(string sellerId, IReadOnlyList<string> marketplaceIds, IReadOnlyList<IncludedDatum1>? includedData, string? pageToken, int? pageSize = 10, RequestOptions? requestOptions = null, CancellationToken ct = default)`
  - `includedData` — nullable, no default → **must pass explicitly**
  - `pageToken` — nullable, no default → **must pass explicitly**
  - defaults: `pageSize` = `10`
- **Query params (wire ← C#)**: `marketplaceIds` ← `marketplaceIds`, `includedData` ← `includedData`, `pageSize` ← `pageSize`, `pageToken` ← `pageToken`
- **Returns**: `ItemSearchResults1`
- **Error**: `SdkException<SearchListingsItemsError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorList(out ErrorList)` [400, 403, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `IncludedDatum1` | `Models/Enums/IncludedDatum1.cs` |
| `ItemSearchResults1` | `Models/ItemSearchResults1.cs` |
| `SearchListingsItemsError` | `Errors/SearchListingsItemsError.cs` |
| `ErrorList` | `Models/ErrorList.cs` |

