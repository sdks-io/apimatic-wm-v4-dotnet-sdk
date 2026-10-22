<!-- Generated file — do not edit; regenerated with the SDK. -->

# Reviews — operations

Accessor: `client.Reviews` · Source: `src/WalmartApIs/Api/Reviews.cs` · 3 operations

**Type sources**: the file declaring each type an operation names (`RawError` excluded — see sdk-map.md).

### BulkUpdateItemStatus

- **Auth**: `options.AccessToken`
- **Signature**: `BulkUpdateItemStatus(BulkUpdateItemStatusRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `WmGlobalVersion`, `WmQosCorrelationId`, `WmSvcName`, `WmMarket`, `Body`
- **Returns**: `V3GrowthReviewsAcceleratorItemsStatusResponse`
- **Error**: `ApiException<BulkUpdateItemStatusError>` — **Case A (typed)**
- **Error accessors**: `TryGetV3GrowthReviewsAcceleratorItemsStatus400Error1(out V3GrowthReviewsAcceleratorItemsStatus400Error1)` [400] · `TryGetV3GrowthReviewsAcceleratorItemsStatus401Error1(out V3GrowthReviewsAcceleratorItemsStatus401Error1)` [401] · `TryGetV3GrowthReviewsAcceleratorItemsStatus403Error1(out V3GrowthReviewsAcceleratorItemsStatus403Error1)` [403] · `TryGetV3GrowthReviewsAcceleratorItemsStatus500Error1(out V3GrowthReviewsAcceleratorItemsStatus500Error1)` [500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `BulkUpdateItemStatusRequest` | `src/WalmartApIs/Requests/Reviews/BulkUpdateItemStatusRequest.cs` |
| `WmGlobalVersion` | `src/WalmartApIs/Models/Enums/WmGlobalVersion.cs` |
| `WmMarket1` | `src/WalmartApIs/Models/Enums/WmMarket1.cs` |
| `V3GrowthReviewsAcceleratorItemsStatusRequest` | `src/WalmartApIs/Models/V3GrowthReviewsAcceleratorItemsStatusRequest.cs` |
| `V3GrowthReviewsAcceleratorItemsStatusResponse` | `src/WalmartApIs/Models/V3GrowthReviewsAcceleratorItemsStatusResponse.cs` |
| `BulkUpdateItemStatusError` | `src/WalmartApIs/Errors/BulkUpdateItemStatusError.cs` |
| `V3GrowthReviewsAcceleratorItemsStatus400Error1` | `src/WalmartApIs/Models/V3GrowthReviewsAcceleratorItemsStatus400Error1.cs` |
| `V3GrowthReviewsAcceleratorItemsStatus401Error1` | `src/WalmartApIs/Models/V3GrowthReviewsAcceleratorItemsStatus401Error1.cs` |
| `V3GrowthReviewsAcceleratorItemsStatus403Error1` | `src/WalmartApIs/Models/V3GrowthReviewsAcceleratorItemsStatus403Error1.cs` |
| `V3GrowthReviewsAcceleratorItemsStatus500Error1` | `src/WalmartApIs/Models/V3GrowthReviewsAcceleratorItemsStatus500Error1.cs` |

### GetIrpCategories

- **Auth**: `options.AccessToken`
- **Signature**: `GetIrpCategories(GetIrpCategoriesRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `WmGlobalVersion`, `WmQosCorrelationId`, `WmSvcName`, `WmMarket`, `Body`
- **Returns**: `V3GrowthReviewsAcceleratorCategoriesResponse`
- **Error**: `ApiException<GetIrpCategoriesError>` — **Case A (typed)**
- **Error accessors**: `TryGetV3GrowthReviewsAcceleratorCategories400Error1(out V3GrowthReviewsAcceleratorCategories400Error1)` [400] · `TryGetV3GrowthReviewsAcceleratorCategories401Error1(out V3GrowthReviewsAcceleratorCategories401Error1)` [401] · `TryGetV3GrowthReviewsAcceleratorCategories403Error1(out V3GrowthReviewsAcceleratorCategories403Error1)` [403] · `TryGetV3InsightsItemsListingQualityItems500Error1(out V3InsightsItemsListingQualityItems500Error1)` [500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `GetIrpCategoriesRequest` | `src/WalmartApIs/Requests/Reviews/GetIrpCategoriesRequest.cs` |
| `WmGlobalVersion` | `src/WalmartApIs/Models/Enums/WmGlobalVersion.cs` |
| `WmMarket1` | `src/WalmartApIs/Models/Enums/WmMarket1.cs` |
| `V3GrowthReviewsAcceleratorCategoriesRequest` | `src/WalmartApIs/Models/V3GrowthReviewsAcceleratorCategoriesRequest.cs` |
| `V3GrowthReviewsAcceleratorCategoriesResponse` | `src/WalmartApIs/Models/V3GrowthReviewsAcceleratorCategoriesResponse.cs` |
| `GetIrpCategoriesError` | `src/WalmartApIs/Errors/GetIrpCategoriesError.cs` |
| `V3GrowthReviewsAcceleratorCategories400Error1` | `src/WalmartApIs/Models/V3GrowthReviewsAcceleratorCategories400Error1.cs` |
| `V3GrowthReviewsAcceleratorCategories401Error1` | `src/WalmartApIs/Models/V3GrowthReviewsAcceleratorCategories401Error1.cs` |
| `V3GrowthReviewsAcceleratorCategories403Error1` | `src/WalmartApIs/Models/V3GrowthReviewsAcceleratorCategories403Error1.cs` |
| `V3InsightsItemsListingQualityItems500Error1` | `src/WalmartApIs/Models/V3InsightsItemsListingQualityItems500Error1.cs` |

### GetIrpItems

- **Auth**: `options.AccessToken`
- **Signature**: `GetIrpItems(GetIrpItemsOperationRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `WmGlobalVersion`, `WmQosCorrelationId`, `WmSvcName`, `WmMarket`, `Body`
- **Query params (wire ← C#)**: `scrollId` ← `ScrollId`
- **Returns**: `V3GrowthReviewsAcceleratorItemsResponse`
- **Error**: `ApiException<GetIrpItemsError>` — **Case A (typed)**
- **Error accessors**: `TryGetV3GrowthReviewsAcceleratorItems400Error1(out V3GrowthReviewsAcceleratorItems400Error1)` [400] · `TryGetV3GrowthReviewsAcceleratorItems401Error1(out V3GrowthReviewsAcceleratorItems401Error1)` [401] · `TryGetV3GrowthReviewsAcceleratorItems403Error1(out V3GrowthReviewsAcceleratorItems403Error1)` [403] · `TryGetV3InsightsItemsListingQualityItems500Error1(out V3InsightsItemsListingQualityItems500Error1)` [500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `GetIrpItemsOperationRequest` | `src/WalmartApIs/Requests/Reviews/GetIrpItemsOperationRequest.cs` |
| `WmGlobalVersion` | `src/WalmartApIs/Models/Enums/WmGlobalVersion.cs` |
| `WmMarket1` | `src/WalmartApIs/Models/Enums/WmMarket1.cs` |
| `V3GrowthReviewsAcceleratorItemsRequest` | `src/WalmartApIs/Models/V3GrowthReviewsAcceleratorItemsRequest.cs` |
| `V3GrowthReviewsAcceleratorItemsResponse` | `src/WalmartApIs/Models/V3GrowthReviewsAcceleratorItemsResponse.cs` |
| `GetIrpItemsError` | `src/WalmartApIs/Errors/GetIrpItemsError.cs` |
| `V3GrowthReviewsAcceleratorItems400Error1` | `src/WalmartApIs/Models/V3GrowthReviewsAcceleratorItems400Error1.cs` |
| `V3GrowthReviewsAcceleratorItems401Error1` | `src/WalmartApIs/Models/V3GrowthReviewsAcceleratorItems401Error1.cs` |
| `V3GrowthReviewsAcceleratorItems403Error1` | `src/WalmartApIs/Models/V3GrowthReviewsAcceleratorItems403Error1.cs` |
| `V3InsightsItemsListingQualityItems500Error1` | `src/WalmartApIs/Models/V3InsightsItemsListingQualityItems500Error1.cs` |

