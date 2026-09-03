<!-- Generated file — do not edit; regenerated with the SDK. -->

# Feeds — operations

Accessor: `client.Feeds` · Source: `Api/Feeds.cs` · 5 operations

**Type sources**: the file declaring each type an operation names (`RawError` excluded — see sdk-map.md).

### CancelFeed

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `CancelFeed(string feedId, RequestOptions? requestOptions = null, CancellationToken ct = default)`
- **Returns**: `CancelFeedResponse`
- **Error**: `SdkException<CancelFeedError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorList1(out ErrorList1)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `CancelFeedResponse` | `Models/CancelFeedResponse.cs` |
| `CancelFeedError` | `Errors/CancelFeedError.cs` |
| `ErrorList1` | `Models/ErrorList1.cs` |

### CreateFeed

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `CreateFeed(FeedType feedType, string? marketplaceId, BinaryContent file, ContentType? contentType, RequestOptions? requestOptions = null, CancellationToken ct = default)`
  - `marketplaceId` — nullable, no default → **must pass explicitly**
  - `contentType` — nullable, no default → **must pass explicitly**
- **Query params (wire ← C#)**: `feedType` ← `feedType`, `marketplaceId` ← `marketplaceId`
- **Returns**: `CreateFeedResponse`
- **Error**: `SdkException<CreateFeedError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorList1(out ErrorList1)` [400, 403, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `FeedType` | `Models/Enums/FeedType.cs` |
| `ContentType` | `Models/Enums/ContentType.cs` |
| `CreateFeedResponse` | `Models/CreateFeedResponse.cs` |
| `CreateFeedError` | `Errors/CreateFeedError.cs` |
| `ErrorList1` | `Models/ErrorList1.cs` |

### GetFeed

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `GetFeed(string feedId, RequestOptions? requestOptions = null, CancellationToken ct = default)`
- **Returns**: `Feed`
- **Error**: `SdkException<GetFeedError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorList1(out ErrorList1)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `Feed` | `Models/Feed.cs` |
| `GetFeedError` | `Errors/GetFeedError.cs` |
| `ErrorList1` | `Models/ErrorList1.cs` |

### GetFeedDocument

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `GetFeedDocument(string feedId, RequestOptions? requestOptions = null, CancellationToken ct = default)`
- **Returns**: `BinaryContent`
- **Error**: `SdkException<GetFeedDocumentError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorList1(out ErrorList1)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `GetFeedDocumentError` | `Errors/GetFeedDocumentError.cs` |
| `ErrorList1` | `Models/ErrorList1.cs` |

### GetFeeds

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `GetFeeds(IReadOnlyList<FeedType>? feedTypes, IReadOnlyList<FeedStatus>? feedStatuses, DateTimeOffset? createdSince, DateTimeOffset? createdUntil, string? nextToken, int? pageSize = 10, RequestOptions? requestOptions = null, CancellationToken ct = default)`
  - 5 params (`feedTypes` … `nextToken`) — nullable, no default → **must pass explicitly** (pass `null` to skip)
  - defaults: `pageSize` = `10`
- **Query params (wire ← C#)**: `feedTypes` ← `feedTypes`, `feedStatuses` ← `feedStatuses`, `createdSince` ← `createdSince`, `createdUntil` ← `createdUntil`, `pageSize` ← `pageSize`, `nextToken` ← `nextToken`
- **Returns**: `GetFeedsResponse`
- **Error**: `SdkException<GetFeedsError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorList1(out ErrorList1)` [400, 403, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `FeedType` | `Models/Enums/FeedType.cs` |
| `FeedStatus` | `Models/Enums/FeedStatus.cs` |
| `GetFeedsResponse` | `Models/GetFeedsResponse.cs` |
| `GetFeedsError` | `Errors/GetFeedsError.cs` |
| `ErrorList1` | `Models/ErrorList1.cs` |

