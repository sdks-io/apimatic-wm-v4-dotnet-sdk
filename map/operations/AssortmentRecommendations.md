<!-- Generated file — do not edit; regenerated with the SDK. -->

# AssortmentRecommendations — operations

Accessor: `client.AssortmentRecommendations` · Source: `src/WalmartApIs/Api/AssortmentRecommendations.cs` · 5 operations

**Type sources**: the file declaring each type an operation names (`RawError` excluded — see sdk-map.md).

### GetAssortmentRecommendationTrends

- **Signature**: `GetAssortmentRecommendationTrends(GetAssortmentRecommendationTrendsRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `RecommendationUniqueId`, `WmGlobalVersion`, `WmSecAccessToken`, `WmQosCorrelationId`, `WmSvcName`, `WmMarket`
- **Query params (wire ← C#)**: `recommendationUniqueId` ← `RecommendationUniqueId`, `trendTypes` ← `TrendTypes`
- **Returns**: `V3GrowthAssortmentRecommendationsTrendsResponse`
- **Error**: `ApiException<GetAssortmentRecommendationTrendsError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorResponse1(out ErrorResponse1)` [400, 500] · `TryGetV3Token500Error1(out V3Token500Error1)` [403] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `GetAssortmentRecommendationTrendsRequest` | `src/WalmartApIs/Requests/AssortmentRecommendations/GetAssortmentRecommendationTrendsRequest.cs` |
| `WmGlobalVersion` | `src/WalmartApIs/Models/Enums/WmGlobalVersion.cs` |
| `WmMarket1` | `src/WalmartApIs/Models/Enums/WmMarket1.cs` |
| `V3GrowthAssortmentRecommendationsTrendsResponse` | `src/WalmartApIs/Models/V3GrowthAssortmentRecommendationsTrendsResponse.cs` |
| `GetAssortmentRecommendationTrendsError` | `src/WalmartApIs/Errors/GetAssortmentRecommendationTrendsError.cs` |
| `ErrorResponse1` | `src/WalmartApIs/Models/ErrorResponse1.cs` |
| `V3Token500Error1` | `src/WalmartApIs/Models/V3Token500Error1.cs` |

### GetAssortmentRecommendationVariants

- **Signature**: `GetAssortmentRecommendationVariants(GetAssortmentRecommendationVariantsRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `PrimaryVariantItemId`, `WmGlobalVersion`, `WmSecAccessToken`, `WmQosCorrelationId`, `WmSvcName`, `WmMarket`
- **Query params (wire ← C#)**: `primaryVariantItemId` ← `PrimaryVariantItemId`, `nextCursor` ← `NextCursor`
- **Returns**: `V3GrowthAssortmentRecommendationsVariantsResponse`
- **Error**: `ApiException<GetAssortmentRecommendationVariantsError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorResponse1(out ErrorResponse1)` [400, 500] · `TryGetV3Token500Error1(out V3Token500Error1)` [403] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `GetAssortmentRecommendationVariantsRequest` | `src/WalmartApIs/Requests/AssortmentRecommendations/GetAssortmentRecommendationVariantsRequest.cs` |
| `WmGlobalVersion` | `src/WalmartApIs/Models/Enums/WmGlobalVersion.cs` |
| `WmMarket1` | `src/WalmartApIs/Models/Enums/WmMarket1.cs` |
| `V3GrowthAssortmentRecommendationsVariantsResponse` | `src/WalmartApIs/Models/V3GrowthAssortmentRecommendationsVariantsResponse.cs` |
| `GetAssortmentRecommendationVariantsError` | `src/WalmartApIs/Errors/GetAssortmentRecommendationVariantsError.cs` |
| `ErrorResponse1` | `src/WalmartApIs/Models/ErrorResponse1.cs` |
| `V3Token500Error1` | `src/WalmartApIs/Models/V3Token500Error1.cs` |

### GetAssortmentRecommendations

- **Signature**: `GetAssortmentRecommendations(GetAssortmentRecommendationsRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `WmGlobalVersion`, `WmSecAccessToken`, `WmQosCorrelationId`, `WmSvcName`, `WmMarket`, `Body`
- **Returns**: `V3GrowthAssortmentRecommendationsResponse`
- **Error**: `ApiException<GetAssortmentRecommendationsError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorResponse1(out ErrorResponse1)` [400, 500] · `TryGetV3Token500Error1(out V3Token500Error1)` [403] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `GetAssortmentRecommendationsRequest` | `src/WalmartApIs/Requests/AssortmentRecommendations/GetAssortmentRecommendationsRequest.cs` |
| `WmGlobalVersion` | `src/WalmartApIs/Models/Enums/WmGlobalVersion.cs` |
| `WmMarket1` | `src/WalmartApIs/Models/Enums/WmMarket1.cs` |
| `V3GrowthAssortmentRecommendationsRequest` | `src/WalmartApIs/Models/V3GrowthAssortmentRecommendationsRequest.cs` |
| `V3GrowthAssortmentRecommendationsResponse` | `src/WalmartApIs/Models/V3GrowthAssortmentRecommendationsResponse.cs` |
| `GetAssortmentRecommendationsError` | `src/WalmartApIs/Errors/GetAssortmentRecommendationsError.cs` |
| `ErrorResponse1` | `src/WalmartApIs/Models/ErrorResponse1.cs` |
| `V3Token500Error1` | `src/WalmartApIs/Models/V3Token500Error1.cs` |

### GetCategorizationDetailsOfAssortmentRecommendations

- **Signature**: `GetCategorizationDetailsOfAssortmentRecommendations(GetCategorizationDetailsOfAssortmentRecommendationsRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `WmSecAccessToken`, `WmQosCorrelationId`, `WmSvcName`, `WmMarket`, `WmGlobalVersion`, `Body`
- **Returns**: `V3GrowthAssortmentRecommendationsCategorizationCountsResponse`
- **Error**: `ApiException<GetCategorizationDetailsOfAssortmentRecommendationsError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorResponse1(out ErrorResponse1)` [400, 500] · `TryGetV3Token500Error1(out V3Token500Error1)` [403] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `GetCategorizationDetailsOfAssortmentRecommendationsRequest` | `src/WalmartApIs/Requests/AssortmentRecommendations/GetCategorizationDetailsOfAssortmentRecommendationsRequest.cs` |
| `WmMarket1` | `src/WalmartApIs/Models/Enums/WmMarket1.cs` |
| `WmGlobalVersion` | `src/WalmartApIs/Models/Enums/WmGlobalVersion.cs` |
| `V3GrowthAssortmentRecommendationsCategorizationCountsRequest` | `src/WalmartApIs/Models/V3GrowthAssortmentRecommendationsCategorizationCountsRequest.cs` |
| `V3GrowthAssortmentRecommendationsCategorizationCountsResponse` | `src/WalmartApIs/Models/V3GrowthAssortmentRecommendationsCategorizationCountsResponse.cs` |
| `GetCategorizationDetailsOfAssortmentRecommendationsError` | `src/WalmartApIs/Errors/GetCategorizationDetailsOfAssortmentRecommendationsError.cs` |
| `ErrorResponse1` | `src/WalmartApIs/Models/ErrorResponse1.cs` |
| `V3Token500Error1` | `src/WalmartApIs/Models/V3Token500Error1.cs` |

### RejectAssortmentRecommendations

- **Signature**: `RejectAssortmentRecommendations(RejectAssortmentRecommendationsRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `WmGlobalVersion`, `WmSecAccessToken`, `WmQosCorrelationId`, `WmSvcName`, `WmMarket`, `Body`
- **Returns**: `V3GrowthAssortmentRecommendationsRejectionsResponse`
- **Error**: `ApiException<RejectAssortmentRecommendationsError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorResponse1(out ErrorResponse1)` [400, 500] · `TryGetV3Token500Error1(out V3Token500Error1)` [403] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `RejectAssortmentRecommendationsRequest` | `src/WalmartApIs/Requests/AssortmentRecommendations/RejectAssortmentRecommendationsRequest.cs` |
| `WmGlobalVersion` | `src/WalmartApIs/Models/Enums/WmGlobalVersion.cs` |
| `WmMarket1` | `src/WalmartApIs/Models/Enums/WmMarket1.cs` |
| `V3GrowthAssortmentRecommendationsRejectionsRequest` | `src/WalmartApIs/Models/V3GrowthAssortmentRecommendationsRejectionsRequest.cs` |
| `V3GrowthAssortmentRecommendationsRejectionsResponse` | `src/WalmartApIs/Models/V3GrowthAssortmentRecommendationsRejectionsResponse.cs` |
| `RejectAssortmentRecommendationsError` | `src/WalmartApIs/Errors/RejectAssortmentRecommendationsError.cs` |
| `ErrorResponse1` | `src/WalmartApIs/Models/ErrorResponse1.cs` |
| `V3Token500Error1` | `src/WalmartApIs/Models/V3Token500Error1.cs` |

