<!-- Generated file — do not edit; regenerated with the SDK. -->

# RichMedia — operations

Accessor: `client.RichMedia` · Source: `src/WalmartApIs/Api/RichMedia.cs` · 2 operations

**Type sources**: the file declaring each type an operation names (`RawError` excluded — see sdk-map.md).

### GetAllAssets

- **Auth**: `options.AccessToken`
- **Signature**: `GetAllAssets(GetAllAssetsRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `WmQosCorrelationId`, `WmSvcName`
- **Query params (wire ← C#)**: `page` ← `Page`, `limit` ← `Limit`, `linkedGtins` ← `LinkedGtins`, `richMediaTitle` ← `RichMediaTitle`, `richMediaType` ← `RichMediaType`
- **Returns**: `AssetsResponse`
- **Error**: `ApiException<GetAllAssetsError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent(out RawError)` [400, 401, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `GetAllAssetsRequest` | `src/WalmartApIs/Requests/RichMedia/GetAllAssetsRequest.cs` |
| `RichMediaType` | `src/WalmartApIs/Models/Enums/RichMediaType.cs` |
| `AssetsResponse` | `src/WalmartApIs/Models/AssetsResponse.cs` |
| `GetAllAssetsError` | `src/WalmartApIs/Errors/GetAllAssetsError.cs` |

### RichMediaOperation

- **Auth**: `options.AccessToken`
- **Signature**: `RichMediaOperation(RichMediaOperationRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `WmQosCorrelationId`, `WmSvcName`, `Body`
- **Returns**: `FeedId1`
- **Error**: `ApiException<RichMediaOperationError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent(out RawError)` [400, 401, 403, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `RichMediaOperationRequest` | `src/WalmartApIs/Requests/RichMedia/RichMediaOperationRequest.cs` |
| `RichMediaFeedRequest` | `src/WalmartApIs/Models/RichMediaFeedRequest.cs` |
| `FeedId1` | `src/WalmartApIs/Models/FeedId1.cs` |
| `RichMediaOperationError` | `src/WalmartApIs/Errors/RichMediaOperationError.cs` |

