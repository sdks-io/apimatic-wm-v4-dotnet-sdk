<!-- Generated file — do not edit; regenerated with the SDK. -->

# InsightApi — operations

Accessor: `client.InsightApi` · Source: `src/WalmartApIs/Api/InsightApi.cs` · 7 operations

**Type sources**: the file declaring each type an operation names (`RawError` excluded — see sdk-map.md).

### GetCategoriesList

- **Auth**: `options.AccessToken`
- **Signature**: `GetCategoriesList(GetCategoriesListRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `WmGlobalVersion`, `WmQosCorrelationId`, `WmSvcName`, `WmMarket`
- **Query params (wire ← C#)**: `viewTrendingItems` ← `ViewTrendingItems`, `wfsFlag` ← `WfsFlag`, `hasIssue` ← `HasIssue`, `type` ← `Type`, `inDemandIndicator` ← `InDemandIndicator`, `limit` ← `Limit`, `offset` ← `Offset`
- **Returns**: `V3InsightsItemsListingQualityCountResponse`
- **Error**: `ApiException<GetCategoriesListError>` — **Case A (typed)**
- **Error accessors**: `TryGetV3InsightsItemsListingQualityCount400Error1(out V3InsightsItemsListingQualityCount400Error1)` [400] · `TryGetV3Token400Error1(out V3Token400Error1)` [401, 403] · `TryGetV3InsightsItemsListingQualityCount500Error1(out V3InsightsItemsListingQualityCount500Error1)` [500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `GetCategoriesListRequest` | `src/WalmartApIs/Requests/InsightApi/GetCategoriesListRequest.cs` |
| `Type3` | `src/WalmartApIs/Models/Enums/Type3.cs` |
| `WmGlobalVersion` | `src/WalmartApIs/Models/Enums/WmGlobalVersion.cs` |
| `WmMarket1` | `src/WalmartApIs/Models/Enums/WmMarket1.cs` |
| `V3InsightsItemsListingQualityCountResponse` | `src/WalmartApIs/Models/V3InsightsItemsListingQualityCountResponse.cs` |
| `GetCategoriesListError` | `src/WalmartApIs/Errors/GetCategoriesListError.cs` |
| `V3InsightsItemsListingQualityCount400Error1` | `src/WalmartApIs/Models/V3InsightsItemsListingQualityCount400Error1.cs` |
| `V3Token400Error1` | `src/WalmartApIs/Models/V3Token400Error1.cs` |
| `V3InsightsItemsListingQualityCount500Error1` | `src/WalmartApIs/Models/V3InsightsItemsListingQualityCount500Error1.cs` |

### GetListingQualityScore

- **Auth**: `options.AccessToken`
- **Signature**: `GetListingQualityScore(GetListingQualityScoreRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `WmGlobalVersion`, `WmQosCorrelationId`, `WmSvcName`, `WmMarket`
- **Query params (wire ← C#)**: `viewTrendingItems` ← `ViewTrendingItems`, `wfsFlag` ← `WfsFlag`
- **Returns**: `V3InsightsItemsListingQualityScoreResponse`
- **Error**: `ApiException<GetListingQualityScoreError>` — **Case A (typed)**
- **Error accessors**: `TryGetV3InsightsItemsListingQualityScore400Error1(out V3InsightsItemsListingQualityScore400Error1)` [400] · `TryGetV3Token400Error1(out V3Token400Error1)` [401, 403] · `TryGetV3InsightsItemsListingQualityScore500Error1(out V3InsightsItemsListingQualityScore500Error1)` [500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `GetListingQualityScoreRequest` | `src/WalmartApIs/Requests/InsightApi/GetListingQualityScoreRequest.cs` |
| `WmGlobalVersion` | `src/WalmartApIs/Models/Enums/WmGlobalVersion.cs` |
| `WmMarket1` | `src/WalmartApIs/Models/Enums/WmMarket1.cs` |
| `V3InsightsItemsListingQualityScoreResponse` | `src/WalmartApIs/Models/V3InsightsItemsListingQualityScoreResponse.cs` |
| `GetListingQualityScoreError` | `src/WalmartApIs/Errors/GetListingQualityScoreError.cs` |
| `V3InsightsItemsListingQualityScore400Error1` | `src/WalmartApIs/Models/V3InsightsItemsListingQualityScore400Error1.cs` |
| `V3Token400Error1` | `src/WalmartApIs/Models/V3Token400Error1.cs` |
| `V3InsightsItemsListingQualityScore500Error1` | `src/WalmartApIs/Models/V3InsightsItemsListingQualityScore500Error1.cs` |

### GetProSellerBadgeInfo

- **Auth**: `options.AccessToken`
- **Signature**: `GetProSellerBadgeInfo(GetProSellerBadgeInfoRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `WmGlobalVersion`, `WmQosCorrelationId`, `WmSvcName`, `WmMarket`
- **Returns**: `V3InsightsProsellerbadgeResponse`
- **Error**: `ApiException<GetProSellerBadgeInfoError>` — **Case A (typed)**
- **Error accessors**: `TryGetV3InsightsProsellerbadge400Error1(out V3InsightsProsellerbadge400Error1)` [400] · `TryGetV3Token400Error1(out V3Token400Error1)` [401, 403] · `TryGetV3InsightsProsellerbadge500Error1(out V3InsightsProsellerbadge500Error1)` [500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `GetProSellerBadgeInfoRequest` | `src/WalmartApIs/Requests/InsightApi/GetProSellerBadgeInfoRequest.cs` |
| `WmGlobalVersion` | `src/WalmartApIs/Models/Enums/WmGlobalVersion.cs` |
| `WmMarket1` | `src/WalmartApIs/Models/Enums/WmMarket1.cs` |
| `V3InsightsProsellerbadgeResponse` | `src/WalmartApIs/Models/V3InsightsProsellerbadgeResponse.cs` |
| `GetProSellerBadgeInfoError` | `src/WalmartApIs/Errors/GetProSellerBadgeInfoError.cs` |
| `V3InsightsProsellerbadge400Error1` | `src/WalmartApIs/Models/V3InsightsProsellerbadge400Error1.cs` |
| `V3Token400Error1` | `src/WalmartApIs/Models/V3Token400Error1.cs` |
| `V3InsightsProsellerbadge500Error1` | `src/WalmartApIs/Models/V3InsightsProsellerbadge500Error1.cs` |

### GetSellerIncentivesInfo

- **Auth**: `options.AccessToken`
- **Signature**: `GetSellerIncentivesInfo(GetSellerIncentivesInfoRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `WmGlobalVersion`, `WmQosCorrelationId`, `WmSvcName`, `WmMarket`
- **Returns**: `V3InsightsSellerIncentivesResponse`
- **Error**: `ApiException<GetSellerIncentivesInfoError>` — **Case A (typed)**
- **Error accessors**: `TryGetV3Token400Error1(out V3Token400Error1)` [401, 403] · `TryGetV3InsightsSellerIncentives500Error1(out V3InsightsSellerIncentives500Error1)` [500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `GetSellerIncentivesInfoRequest` | `src/WalmartApIs/Requests/InsightApi/GetSellerIncentivesInfoRequest.cs` |
| `WmGlobalVersion` | `src/WalmartApIs/Models/Enums/WmGlobalVersion.cs` |
| `WmMarket1` | `src/WalmartApIs/Models/Enums/WmMarket1.cs` |
| `V3InsightsSellerIncentivesResponse` | `src/WalmartApIs/Models/V3InsightsSellerIncentivesResponse.cs` |
| `GetSellerIncentivesInfoError` | `src/WalmartApIs/Errors/GetSellerIncentivesInfoError.cs` |
| `V3Token400Error1` | `src/WalmartApIs/Models/V3Token400Error1.cs` |
| `V3InsightsSellerIncentives500Error1` | `src/WalmartApIs/Models/V3InsightsSellerIncentives500Error1.cs` |

### GetUnpublishedItemCount

- **Auth**: `options.AccessToken`
- **Signature**: `GetUnpublishedItemCount(GetUnpublishedItemCountRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `FromDate`, `WmGlobalVersion`, `WmQosCorrelationId`, `WmSvcName`, `WmMarket`
- **Query params (wire ← C#)**: `fromDate` ← `FromDate`
- **Returns**: `V3InsightsItemsUnpublishedCountsResponse`
- **Error**: `ApiException<GetUnpublishedItemCountError>` — **Case A (typed)**
- **Error accessors**: `TryGetV3Token400Error1(out V3Token400Error1)` [401, 403] · `TryGetV3InsightsItemsUnpublishedCounts500Error1(out V3InsightsItemsUnpublishedCounts500Error1)` [500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `GetUnpublishedItemCountRequest` | `src/WalmartApIs/Requests/InsightApi/GetUnpublishedItemCountRequest.cs` |
| `WmGlobalVersion` | `src/WalmartApIs/Models/Enums/WmGlobalVersion.cs` |
| `WmMarket1` | `src/WalmartApIs/Models/Enums/WmMarket1.cs` |
| `V3InsightsItemsUnpublishedCountsResponse` | `src/WalmartApIs/Models/V3InsightsItemsUnpublishedCountsResponse.cs` |
| `GetUnpublishedItemCountError` | `src/WalmartApIs/Errors/GetUnpublishedItemCountError.cs` |
| `V3Token400Error1` | `src/WalmartApIs/Models/V3Token400Error1.cs` |
| `V3InsightsItemsUnpublishedCounts500Error1` | `src/WalmartApIs/Models/V3InsightsItemsUnpublishedCounts500Error1.cs` |

### GetUnpublishedItems

- **Auth**: `options.AccessToken`
- **Signature**: `GetUnpublishedItems(GetUnpublishedItemsRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `FromDate`, `WmGlobalVersion`, `WmQosCorrelationId`, `WmSvcName`, `WmMarket`
- **Query params (wire ← C#)**: `fromDate` ← `FromDate`, `unpublishedReasonCode` ← `UnpublishedReasonCode`, `limit` ← `Limit`, `offerLifecycleStatus` ← `OfferLifecycleStatus`, `marketTrending` ← `MarketTrending`, `itemsWithInventory` ← `ItemsWithInventory`, `isCustomerFavorite` ← `IsCustomerFavorite`
- **Returns**: `V3InsightsItemsUnpublishedItemsResponse`
- **Error**: `ApiException<GetUnpublishedItemsError>` — **Case A (typed)**
- **Error accessors**: `TryGetV3Token400Error1(out V3Token400Error1)` [400, 401, 403] · `TryGetV3InsightsItemsUnpublishedItems500Error1(out V3InsightsItemsUnpublishedItems500Error1)` [500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `GetUnpublishedItemsRequest` | `src/WalmartApIs/Requests/InsightApi/GetUnpublishedItemsRequest.cs` |
| `WmGlobalVersion` | `src/WalmartApIs/Models/Enums/WmGlobalVersion.cs` |
| `WmMarket1` | `src/WalmartApIs/Models/Enums/WmMarket1.cs` |
| `V3InsightsItemsUnpublishedItemsResponse` | `src/WalmartApIs/Models/V3InsightsItemsUnpublishedItemsResponse.cs` |
| `GetUnpublishedItemsError` | `src/WalmartApIs/Errors/GetUnpublishedItemsError.cs` |
| `V3Token400Error1` | `src/WalmartApIs/Models/V3Token400Error1.cs` |
| `V3InsightsItemsUnpublishedItems500Error1` | `src/WalmartApIs/Models/V3InsightsItemsUnpublishedItems500Error1.cs` |

### ItemsDetailsForListing

- **Auth**: `options.AccessToken`
- **Signature**: `ItemsDetailsForListing(ItemsDetailsForListingRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `WmGlobalVersion`, `WmQosCorrelationId`, `WmSvcName`, `WmMarket`, `Body`
- **Query params (wire ← C#)**: `limit` ← `Limit`, `nextCursor` ← `NextCursor`, `offset` ← `Offset`
- **Returns**: `V3InsightsItemsListingQualityItemsResponse`
- **Error**: `ApiException<ItemsDetailsForListingError>` — **Case A (typed)**
- **Error accessors**: `TryGetV3Token400Error1(out V3Token400Error1)` [401, 403] · `TryGetV3InsightsItemsListingQualityItems500Error1(out V3InsightsItemsListingQualityItems500Error1)` [500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `ItemsDetailsForListingRequest` | `src/WalmartApIs/Requests/InsightApi/ItemsDetailsForListingRequest.cs` |
| `WmGlobalVersion` | `src/WalmartApIs/Models/Enums/WmGlobalVersion.cs` |
| `WmMarket1` | `src/WalmartApIs/Models/Enums/WmMarket1.cs` |
| `V3InsightsItemsListingQualityItemsRequest` | `src/WalmartApIs/Models/V3InsightsItemsListingQualityItemsRequest.cs` |
| `V3InsightsItemsListingQualityItemsResponse` | `src/WalmartApIs/Models/V3InsightsItemsListingQualityItemsResponse.cs` |
| `ItemsDetailsForListingError` | `src/WalmartApIs/Errors/ItemsDetailsForListingError.cs` |
| `V3Token400Error1` | `src/WalmartApIs/Models/V3Token400Error1.cs` |
| `V3InsightsItemsListingQualityItems500Error1` | `src/WalmartApIs/Models/V3InsightsItemsListingQualityItems500Error1.cs` |

