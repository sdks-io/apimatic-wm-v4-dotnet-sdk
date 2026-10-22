<!-- Generated file — do not edit; regenerated with the SDK. -->

# SeoRecommendations — operations

Accessor: `client.SeoRecommendations` · Source: `src/WalmartApIs/Api/SeoRecommendations.cs` · 2 operations

**Type sources**: the file declaring each type an operation names (`RawError` excluded — see sdk-map.md).

### GetSeoRecommendations

- **Auth**: `options.AccessToken`
- **Signature**: `GetSeoRecommendations(GetSeoRecommendationsRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `WmSecAccessToken`, `WmQosCorrelationId`, `WmSvcName`, `Accept`
- **Query params (wire ← C#)**: `status` ← `Status`, `limit` ← `Limit`, `next_cursor` ← `NextCursor`, `previous_cursor` ← `PreviousCursor`
- **Returns**: `V3SeoRecommendationGetItemsResponse`
- **Error**: `ApiException<GetSeoRecommendationsError>` — **Case A (typed)**
- **Error accessors**: `TryGetV3SeoRecommendationGetItems400Error1(out V3SeoRecommendationGetItems400Error1)` [400] · `TryGetV3SeoRecommendationGetItems500Error1(out V3SeoRecommendationGetItems500Error1)` [500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `GetSeoRecommendationsRequest` | `src/WalmartApIs/Requests/SeoRecommendations/GetSeoRecommendationsRequest.cs` |
| `Status2` | `src/WalmartApIs/Models/Enums/Status2.cs` |
| `V3SeoRecommendationGetItemsRequest` | `src/WalmartApIs/Models/V3SeoRecommendationGetItemsRequest.cs` |
| `V3SeoRecommendationGetItemsResponse` | `src/WalmartApIs/Models/V3SeoRecommendationGetItemsResponse.cs` |
| `GetSeoRecommendationsError` | `src/WalmartApIs/Errors/GetSeoRecommendationsError.cs` |
| `V3SeoRecommendationGetItems400Error1` | `src/WalmartApIs/Models/V3SeoRecommendationGetItems400Error1.cs` |
| `V3SeoRecommendationGetItems500Error1` | `src/WalmartApIs/Models/V3SeoRecommendationGetItems500Error1.cs` |

### UpdateSeoRecommendations

- **Auth**: `options.AccessToken`
- **Signature**: `UpdateSeoRecommendations(UpdateSeoRecommendationsRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `ItemId`, `Decision`, `WmSecAccessToken`, `WmQosCorrelationId`, `WmSvcName`, `Accept`
- **Returns**: `V3SeoRecommendationUpdateItemsResponse`
- **Error**: `ApiException<UpdateSeoRecommendationsError>` — **Case A (typed)**
- **Error accessors**: `TryGetV3SeoRecommendationUpdateItems400Error1(out V3SeoRecommendationUpdateItems400Error1)` [400] · `TryGetV3SeoRecommendationUpdateItems404Error1(out V3SeoRecommendationUpdateItems404Error1)` [404] · `TryGetV3SeoRecommendationUpdateItems500Error1(out V3SeoRecommendationUpdateItems500Error1)` [500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `UpdateSeoRecommendationsRequest` | `src/WalmartApIs/Requests/SeoRecommendations/UpdateSeoRecommendationsRequest.cs` |
| `Decision` | `src/WalmartApIs/Models/Enums/Decision.cs` |
| `V3SeoRecommendationUpdateItemsRequest` | `src/WalmartApIs/Models/V3SeoRecommendationUpdateItemsRequest.cs` |
| `V3SeoRecommendationUpdateItemsResponse` | `src/WalmartApIs/Models/V3SeoRecommendationUpdateItemsResponse.cs` |
| `UpdateSeoRecommendationsError` | `src/WalmartApIs/Errors/UpdateSeoRecommendationsError.cs` |
| `V3SeoRecommendationUpdateItems400Error1` | `src/WalmartApIs/Models/V3SeoRecommendationUpdateItems400Error1.cs` |
| `V3SeoRecommendationUpdateItems404Error1` | `src/WalmartApIs/Models/V3SeoRecommendationUpdateItems404Error1.cs` |
| `V3SeoRecommendationUpdateItems500Error1` | `src/WalmartApIs/Models/V3SeoRecommendationUpdateItems500Error1.cs` |

