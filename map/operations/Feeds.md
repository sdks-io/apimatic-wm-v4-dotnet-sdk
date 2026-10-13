<!-- Generated file — do not edit; regenerated with the SDK. -->

# Feeds — operations

Accessor: `client.Feeds` · Source: `src/WalmartApIs/Api/Feeds.cs` · 5 operations

**Type sources**: the file declaring each type an operation names (`RawError` excluded — see sdk-map.md).

### CancelFeed

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `CancelFeed(CancelFeedRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `FeedId`
- **Returns**: `CancelFeedResponse`
- **Error**: `ApiException<CancelFeedError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorList1(out ErrorList1)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `CancelFeedRequest` | `src/WalmartApIs/Requests/Feeds/CancelFeedRequest.cs` |
| `CancelFeedResponse` | `src/WalmartApIs/Models/CancelFeedResponse.cs` |
| `CancelFeedError` | `src/WalmartApIs/Errors/CancelFeedError.cs` |
| `ErrorList1` | `src/WalmartApIs/Models/ErrorList1.cs` |

### CreateFeed

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `CreateFeed(CreateFeedRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `FeedType`, `File`
- **Query params (wire ← C#)**: `feedType` ← `FeedType`, `marketplaceId` ← `MarketplaceId`
- **Returns**: `CreateFeedResponse`
- **Error**: `ApiException<CreateFeedError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorList1(out ErrorList1)` [400, 403, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `CreateFeedRequest` | `src/WalmartApIs/Requests/Feeds/CreateFeedRequest.cs` |
| `FeedType` | `src/WalmartApIs/Models/Enums/FeedType.cs` |
| `ContentType` | `src/WalmartApIs/Models/Enums/ContentType.cs` |
| `CreateFeedResponse` | `src/WalmartApIs/Models/CreateFeedResponse.cs` |
| `CreateFeedError` | `src/WalmartApIs/Errors/CreateFeedError.cs` |
| `ErrorList1` | `src/WalmartApIs/Models/ErrorList1.cs` |

### GetFeed

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `GetFeed(GetFeedRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `FeedId`
- **Returns**: `Feed`
- **Error**: `ApiException<GetFeedError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorList1(out ErrorList1)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `GetFeedRequest` | `src/WalmartApIs/Requests/Feeds/GetFeedRequest.cs` |
| `Feed` | `src/WalmartApIs/Models/Feed.cs` |
| `GetFeedError` | `src/WalmartApIs/Errors/GetFeedError.cs` |
| `ErrorList1` | `src/WalmartApIs/Models/ErrorList1.cs` |

### GetFeedDocument

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `GetFeedDocument(GetFeedDocumentRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `FeedId`
- **Returns**: `BinaryContent`
- **Error**: `ApiException<GetFeedDocumentError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorList1(out ErrorList1)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `GetFeedDocumentRequest` | `src/WalmartApIs/Requests/Feeds/GetFeedDocumentRequest.cs` |
| `GetFeedDocumentError` | `src/WalmartApIs/Errors/GetFeedDocumentError.cs` |
| `ErrorList1` | `src/WalmartApIs/Models/ErrorList1.cs` |

### GetFeeds

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `GetFeeds(GetFeedsRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
- **Query params (wire ← C#)**: `feedTypes` ← `FeedTypes`, `feedStatuses` ← `FeedStatuses`, `createdSince` ← `CreatedSince`, `createdUntil` ← `CreatedUntil`, `pageSize` ← `PageSize`, `nextToken` ← `NextToken`
- **Returns**: `GetFeedsResponse`
- **Error**: `ApiException<GetFeedsError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorList1(out ErrorList1)` [400, 403, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `GetFeedsRequest` | `src/WalmartApIs/Requests/Feeds/GetFeedsRequest.cs` |
| `FeedType` | `src/WalmartApIs/Models/Enums/FeedType.cs` |
| `FeedStatus` | `src/WalmartApIs/Models/Enums/FeedStatus.cs` |
| `GetFeedsResponse` | `src/WalmartApIs/Models/GetFeedsResponse.cs` |
| `GetFeedsError` | `src/WalmartApIs/Errors/GetFeedsError.cs` |
| `ErrorList1` | `src/WalmartApIs/Models/ErrorList1.cs` |

