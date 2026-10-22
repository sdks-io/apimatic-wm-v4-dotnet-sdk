<!-- Generated file — do not edit; regenerated with the SDK. -->

# RecommendationsApi — operations

Accessor: `client.RecommendationsApi` · Source: `src/WalmartApIs/Api/RecommendationsApi.cs` · 4 operations

**Type sources**: the file declaring each type an operation names (`RawError` excluded — see sdk-map.md).

### GetFulfillWithWfsRecommendations

- **Signature**: `GetFulfillWithWfsRecommendations(GetFulfillWithWfsRecommendationsRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `ContentType`, `Accept`, `WmGlobalVersion`, `WmMarket`, `WmAuditOriginSource`
- **Query params (wire ← C#)**: `customerFavorite` ← `CustomerFavorite`, `showInsights` ← `ShowInsights`, `limit` ← `Limit`, `offset` ← `Offset`, `sort_by` ← `SortBy`, `sort_order` ← `SortOrder`, `showHiddenRecordsOnly` ← `ShowHiddenRecordsOnly`
- **Returns**: `V3WfsRecommendationFulfilWithWfsResponse`
- **Error**: `ApiException<GetFulfillWithWfsRecommendationsError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorResponse2(out ErrorResponse2)` [400, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `GetFulfillWithWfsRecommendationsRequest` | `src/WalmartApIs/Requests/RecommendationsApi/GetFulfillWithWfsRecommendationsRequest.cs` |
| `SortOrder` | `src/WalmartApIs/Models/Enums/SortOrder.cs` |
| `V3WfsRecommendationFulfilWithWfsResponse` | `src/WalmartApIs/Models/V3WfsRecommendationFulfilWithWfsResponse.cs` |
| `GetFulfillWithWfsRecommendationsError` | `src/WalmartApIs/Errors/GetFulfillWithWfsRecommendationsError.cs` |
| `ErrorResponse2` | `src/WalmartApIs/Models/ErrorResponse2.cs` |

### GetRestockRecommendations

- **Signature**: `GetRestockRecommendations(GetRestockRecommendationsRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `Authorization`, `ContentType`, `Accept`, `WmGlobalVersion`, `WmMarket`, `WmAuditOriginSource`
- **Query params (wire ← C#)**: `customerFavorite` ← `CustomerFavorite`, `showInsights` ← `ShowInsights`, `limit` ← `Limit`, `offset` ← `Offset`, `sort_by` ← `SortBy`, `sort_order` ← `SortOrder`, `showHiddenRecordsOnly` ← `ShowHiddenRecordsOnly`
- **Returns**: `V3WfsRecommendationRestockResponse`
- **Error**: `ApiException<GetRestockRecommendationsError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorResponse2(out ErrorResponse2)` [400, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `GetRestockRecommendationsRequest` | `src/WalmartApIs/Requests/RecommendationsApi/GetRestockRecommendationsRequest.cs` |
| `SortOrder` | `src/WalmartApIs/Models/Enums/SortOrder.cs` |
| `V3WfsRecommendationRestockResponse` | `src/WalmartApIs/Models/V3WfsRecommendationRestockResponse.cs` |
| `GetRestockRecommendationsError` | `src/WalmartApIs/Errors/GetRestockRecommendationsError.cs` |
| `ErrorResponse2` | `src/WalmartApIs/Models/ErrorResponse2.cs` |

### GetShipmentQuantityRecommendations

- **Signature**: `GetShipmentQuantityRecommendations(GetShipmentQuantityRecommendationsRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `Authorization`, `WmSecAccessToken`, `WmQosCorrelationId`, `WmSvcName`, `Accept`, `WmGlobalVersion`, `WmMarket`, `Body`
- **Returns**: `V3WfsRecommendationShipmentQuantityResponse`
- **Error**: `ApiException<GetShipmentQuantityRecommendationsError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorResponse2(out ErrorResponse2)` [400, 500] · `TryGetNotFoundResponse(out NotFoundResponse)` [404] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `GetShipmentQuantityRecommendationsRequest` | `src/WalmartApIs/Requests/RecommendationsApi/GetShipmentQuantityRecommendationsRequest.cs` |
| `V3WfsRecommendationShipmentQuantityRequest` | `src/WalmartApIs/Models/V3WfsRecommendationShipmentQuantityRequest.cs` |
| `V3WfsRecommendationShipmentQuantityResponse` | `src/WalmartApIs/Models/V3WfsRecommendationShipmentQuantityResponse.cs` |
| `GetShipmentQuantityRecommendationsError` | `src/WalmartApIs/Errors/GetShipmentQuantityRecommendationsError.cs` |
| `ErrorResponse2` | `src/WalmartApIs/Models/ErrorResponse2.cs` |
| `NotFoundResponse` | `src/WalmartApIs/Models/NotFoundResponse.cs` |

### GetUnpublishedRecommendations

- **Signature**: `GetUnpublishedRecommendations(GetUnpublishedRecommendationsRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `ContentType`, `Accept`, `WmGlobalVersion`, `WmMarket`, `WmAuditOriginSource`
- **Query params (wire ← C#)**: `customerFavorite` ← `CustomerFavorite`, `showInsights` ← `ShowInsights`, `limit` ← `Limit`, `offset` ← `Offset`, `sort_by` ← `SortBy`, `sort_order` ← `SortOrder`
- **Returns**: `V3WfsRecommendationUnpublishedResponse`
- **Error**: `ApiException<GetUnpublishedRecommendationsError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorResponse2(out ErrorResponse2)` [400, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `GetUnpublishedRecommendationsRequest` | `src/WalmartApIs/Requests/RecommendationsApi/GetUnpublishedRecommendationsRequest.cs` |
| `SortOrder` | `src/WalmartApIs/Models/Enums/SortOrder.cs` |
| `V3WfsRecommendationUnpublishedResponse` | `src/WalmartApIs/Models/V3WfsRecommendationUnpublishedResponse.cs` |
| `GetUnpublishedRecommendationsError` | `src/WalmartApIs/Errors/GetUnpublishedRecommendationsError.cs` |
| `ErrorResponse2` | `src/WalmartApIs/Models/ErrorResponse2.cs` |

