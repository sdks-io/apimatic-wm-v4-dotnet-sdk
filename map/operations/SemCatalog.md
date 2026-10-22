<!-- Generated file — do not edit; regenerated with the SDK. -->

# SemCatalog — operations

Accessor: `client.SemCatalog` · Source: `src/WalmartApIs/Api/SemCatalog.cs` · 2 operations

**Type sources**: the file declaring each type an operation names (`RawError` excluded — see sdk-map.md).

### GetEligibleItems

- **Auth**: `options.BearerAuth`
- **Signature**: `GetEligibleItems(GetEligibleItemsRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `WmSecAccessToken`, `WmQosCorrelationId`, `WmSvcName`, `Body`
- **Returns**: `SemCatalogueResponse`
- **Error**: `ApiException<GetEligibleItemsError>` — **Case A (typed)**
- **Error accessors**: `TryGetSemErrorResponse400(out SemErrorResponse400)` [400, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `GetEligibleItemsRequest` | `src/WalmartApIs/Requests/SemCatalog/GetEligibleItemsRequest.cs` |
| `SemItemEligibilityRequest` | `src/WalmartApIs/Models/SemItemEligibilityRequest.cs` |
| `SemCatalogueResponse` | `src/WalmartApIs/Models/SemCatalogueResponse.cs` |
| `GetEligibleItemsError` | `src/WalmartApIs/Errors/GetEligibleItemsError.cs` |
| `SemErrorResponse400` | `src/WalmartApIs/Models/SemErrorResponse400.cs` |

### GetItemRecommendations

- **Auth**: `options.BearerAuth`
- **Signature**: `GetItemRecommendations(GetItemRecommendationsRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `WmSecAccessToken`, `WmQosCorrelationId`, `WmSvcName`
- **Query params (wire ← C#)**: `limit` ← `Limit`
- **Returns**: `SemCatalogueResponse`
- **Error**: `ApiException<GetItemRecommendationsError>` — **Case A (typed)**
- **Error accessors**: `TryGetSemErrorResponse400(out SemErrorResponse400)` [400, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `GetItemRecommendationsRequest` | `src/WalmartApIs/Requests/SemCatalog/GetItemRecommendationsRequest.cs` |
| `SemCatalogueResponse` | `src/WalmartApIs/Models/SemCatalogueResponse.cs` |
| `GetItemRecommendationsError` | `src/WalmartApIs/Errors/GetItemRecommendationsError.cs` |
| `SemErrorResponse400` | `src/WalmartApIs/Models/SemErrorResponse400.cs` |

