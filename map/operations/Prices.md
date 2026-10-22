<!-- Generated file — do not edit; regenerated with the SDK. -->

# Prices — operations

Accessor: `client.Prices` · Source: `src/WalmartApIs/Api/Prices.cs` · 11 operations

**Type sources**: the file declaring each type an operation names (`RawError` excluded — see sdk-map.md).

### CreateStrategy

- **Auth**: `options.AccessToken`
- **Signature**: `CreateStrategy(CreateStrategyRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `WmQosCorrelationId`, `WmSvcName`, `WmMarket`, `WmGlobalVersion`, `Body`
- **Returns**: `V3RepricerStrategyResponse2`
- **Error**: `ApiException<CreateStrategyError>` — **Case A (typed)**
- **Error accessors**: `TryGetV3RepricerStrategy400Error1(out V3RepricerStrategy400Error1)` [400] · `TryGetV3Token400Error1(out V3Token400Error1)` [403, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `CreateStrategyRequest` | `src/WalmartApIs/Requests/Prices/CreateStrategyRequest.cs` |
| `WmMarket1` | `src/WalmartApIs/Models/Enums/WmMarket1.cs` |
| `WmGlobalVersion` | `src/WalmartApIs/Models/Enums/WmGlobalVersion.cs` |
| `V3RepricerStrategyRequest1` | `src/WalmartApIs/Models/V3RepricerStrategyRequest1.cs` |
| `V3RepricerStrategyResponse2` | `src/WalmartApIs/Models/V3RepricerStrategyResponse2.cs` |
| `CreateStrategyError` | `src/WalmartApIs/Errors/CreateStrategyError.cs` |
| `V3RepricerStrategy400Error1` | `src/WalmartApIs/Models/V3RepricerStrategy400Error1.cs` |
| `V3Token400Error1` | `src/WalmartApIs/Models/V3Token400Error1.cs` |

### DeleteStrategy

- **Auth**: `options.AccessToken`
- **Signature**: `DeleteStrategy(DeleteStrategyRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `StrategyCollectionId`, `WmQosCorrelationId`, `WmSvcName`, `WmMarket`, `WmGlobalVersion`
- **Returns**: `RejectRecommendationsResponsePayload`
- **Error**: `ApiException<DeleteStrategyError>` — **Case A (typed)**
- **Error accessors**: `TryGetV3RepricerStrategy400Error1(out V3RepricerStrategy400Error1)` [400] · `TryGetV3Token400Error1(out V3Token400Error1)` [403, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `DeleteStrategyRequest` | `src/WalmartApIs/Requests/Prices/DeleteStrategyRequest.cs` |
| `WmMarket1` | `src/WalmartApIs/Models/Enums/WmMarket1.cs` |
| `WmGlobalVersion` | `src/WalmartApIs/Models/Enums/WmGlobalVersion.cs` |
| `RejectRecommendationsResponsePayload` | `src/WalmartApIs/Models/RejectRecommendationsResponsePayload.cs` |
| `DeleteStrategyError` | `src/WalmartApIs/Errors/DeleteStrategyError.cs` |
| `V3RepricerStrategy400Error1` | `src/WalmartApIs/Models/V3RepricerStrategy400Error1.cs` |
| `V3Token400Error1` | `src/WalmartApIs/Models/V3Token400Error1.cs` |

### GetAllIncentives

- **Auth**: `options.AccessToken`
- **Signature**: `GetAllIncentives(GetAllIncentivesRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `WmQosCorrelationId`, `WmSvcName`, `WmMarket`, `WmGlobalVersion`
- **Query params (wire ← C#)**: `incentiveStatus` ← `IncentiveStatus`, `limit` ← `Limit`, `offset` ← `Offset`, `sortBy` ← `SortBy`, `sortOrder` ← `SortOrder`, `incentiveType` ← `IncentiveType`
- **Returns**: `V3PriceIncentivesResponse`
- **Error**: `ApiException<GetAllIncentivesError>` — **Case A (typed)**
- **Error accessors**: `TryGetV3PriceIncentives400Error1(out V3PriceIncentives400Error1)` [400] · `TryGetV3Token400Error1(out V3Token400Error1)` [403, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `GetAllIncentivesRequest` | `src/WalmartApIs/Requests/Prices/GetAllIncentivesRequest.cs` |
| `IncentiveStatus` | `src/WalmartApIs/Models/Enums/IncentiveStatus.cs` |
| `SortBy1` | `src/WalmartApIs/Models/Enums/SortBy1.cs` |
| `Order` | `src/WalmartApIs/Models/Enums/Order.cs` |
| `IncentiveType` | `src/WalmartApIs/Models/Enums/IncentiveType.cs` |
| `WmMarket1` | `src/WalmartApIs/Models/Enums/WmMarket1.cs` |
| `WmGlobalVersion` | `src/WalmartApIs/Models/Enums/WmGlobalVersion.cs` |
| `V3PriceIncentivesResponse` | `src/WalmartApIs/Models/V3PriceIncentivesResponse.cs` |
| `GetAllIncentivesError` | `src/WalmartApIs/Errors/GetAllIncentivesError.cs` |
| `V3PriceIncentives400Error1` | `src/WalmartApIs/Models/V3PriceIncentives400Error1.cs` |
| `V3Token400Error1` | `src/WalmartApIs/Models/V3Token400Error1.cs` |

### GetRepricerFeed

- **Auth**: `options.AccessToken`
- **Signature**: `GetRepricerFeed(GetRepricerFeedRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `WmQosCorrelationId`, `WmSvcName`, `WmMarket`, `WmGlobalVersion`, `Body`
- **Returns**: `FeedId1`
- **Error**: `ApiException<GetRepricerFeedError>` — **Case A (typed)**
- **Error accessors**: `TryGetV3Token400Error1(out V3Token400Error1)` [403, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `GetRepricerFeedRequest` | `src/WalmartApIs/Requests/Prices/GetRepricerFeedRequest.cs` |
| `WmMarket1` | `src/WalmartApIs/Models/Enums/WmMarket1.cs` |
| `WmGlobalVersion` | `src/WalmartApIs/Models/Enums/WmGlobalVersion.cs` |
| `V3RepricerFeedsRequest` | `src/WalmartApIs/Models/V3RepricerFeedsRequest.cs` |
| `FeedId1` | `src/WalmartApIs/Models/FeedId1.cs` |
| `GetRepricerFeedError` | `src/WalmartApIs/Errors/GetRepricerFeedError.cs` |
| `V3Token400Error1` | `src/WalmartApIs/Models/V3Token400Error1.cs` |

### GetStrategies

- **Auth**: `options.AccessToken`
- **Signature**: `GetStrategies(GetStrategiesRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `WmQosCorrelationId`, `WmSvcName`, `WmMarket`, `WmGlobalVersion`
- **Query params (wire ← C#)**: `offset` ← `Offset`, `limit` ← `Limit`
- **Returns**: `V3RepricerStrategiesResponse`
- **Error**: `ApiException<GetStrategiesError>` — **Case A (typed)**
- **Error accessors**: `TryGetV3Token400Error1(out V3Token400Error1)` [403, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `GetStrategiesRequest` | `src/WalmartApIs/Requests/Prices/GetStrategiesRequest.cs` |
| `WmMarket1` | `src/WalmartApIs/Models/Enums/WmMarket1.cs` |
| `WmGlobalVersion` | `src/WalmartApIs/Models/Enums/WmGlobalVersion.cs` |
| `V3RepricerStrategiesResponse` | `src/WalmartApIs/Models/V3RepricerStrategiesResponse.cs` |
| `GetStrategiesError` | `src/WalmartApIs/Errors/GetStrategiesError.cs` |
| `V3Token400Error1` | `src/WalmartApIs/Models/V3Token400Error1.cs` |

### PriceAndPromotionBulkUploads

- **Auth**: `options.AccessToken`
- **Signature**: `PriceAndPromotionBulkUploads(PriceAndPromotionBulkUploadsRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `FeedType`, `WmQosCorrelationId`, `WmSvcName`, `WmMarket`, `WmGlobalVersion`, `Body`
- **Query params (wire ← C#)**: `feedType` ← `FeedType`
- **Returns**: `FeedId`
- **Error**: `ApiException<PriceAndPromotionBulkUploadsError>` — **Case A (typed)**
- **Error accessors**: `TryGetV3Token400Error1(out V3Token400Error1)` [403, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `PriceAndPromotionBulkUploadsRequest` | `src/WalmartApIs/Requests/Prices/PriceAndPromotionBulkUploadsRequest.cs` |
| `FeedType21` | `src/WalmartApIs/Models/Enums/FeedType21.cs` |
| `WmMarket1` | `src/WalmartApIs/Models/Enums/WmMarket1.cs` |
| `WmGlobalVersion` | `src/WalmartApIs/Models/Enums/WmGlobalVersion.cs` |
| `V3FeedsFeedTypePriceAndPromotionRequest` | `src/WalmartApIs/Models/V3FeedsFeedTypePriceAndPromotionRequest.cs` |
| `FeedId` | `src/WalmartApIs/Models/FeedId.cs` |
| `PriceAndPromotionBulkUploadsError` | `src/WalmartApIs/Errors/PriceAndPromotionBulkUploadsError.cs` |
| `V3Token400Error1` | `src/WalmartApIs/Models/V3Token400Error1.cs` |

### ReducedReferralFeeIncentivesEnrollment

- **Auth**: `options.AccessToken`
- **Signature**: `ReducedReferralFeeIncentivesEnrollment(ReducedReferralFeeIncentivesEnrollmentRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `FeedType`, `WmQosCorrelationId`, `WmSvcName`, `WmMarket`, `WmGlobalVersion`, `Body`
- **Query params (wire ← C#)**: `feedType` ← `FeedType`
- **Returns**: `V3FeedsFeedTypeIncentiveEnrollmentResponse`
- **Error**: `ApiException<ReducedReferralFeeIncentivesEnrollmentError>` — **Case A (typed)**
- **Error accessors**: `TryGetV3Token400Error1(out V3Token400Error1)` [403, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `ReducedReferralFeeIncentivesEnrollmentRequest` | `src/WalmartApIs/Requests/Prices/ReducedReferralFeeIncentivesEnrollmentRequest.cs` |
| `FeedType11` | `src/WalmartApIs/Models/Enums/FeedType11.cs` |
| `WmMarket1` | `src/WalmartApIs/Models/Enums/WmMarket1.cs` |
| `WmGlobalVersion` | `src/WalmartApIs/Models/Enums/WmGlobalVersion.cs` |
| `V3FeedsFeedTypeIncentiveEnrollmentRequest` | `src/WalmartApIs/Models/V3FeedsFeedTypeIncentiveEnrollmentRequest.cs` |
| `V3FeedsFeedTypeIncentiveEnrollmentResponse` | `src/WalmartApIs/Models/V3FeedsFeedTypeIncentiveEnrollmentResponse.cs` |
| `ReducedReferralFeeIncentivesEnrollmentError` | `src/WalmartApIs/Errors/ReducedReferralFeeIncentivesEnrollmentError.cs` |
| `V3Token400Error1` | `src/WalmartApIs/Models/V3Token400Error1.cs` |

### UpdatePrice

- **Auth**: `options.AccessToken`
- **Signature**: `UpdatePrice(UpdatePriceRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `WmQosCorrelationId`, `WmSvcName`, `WmMarket`, `WmGlobalVersion`, `Body`
- **Returns**: `V3PriceResponse`
- **Error**: `ApiException<UpdatePriceError>` — **Case A (typed)**
- **Error accessors**: `TryGetV3Token400Error1(out V3Token400Error1)` [403, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `UpdatePriceRequest` | `src/WalmartApIs/Requests/Prices/UpdatePriceRequest.cs` |
| `WmMarket1` | `src/WalmartApIs/Models/Enums/WmMarket1.cs` |
| `WmGlobalVersion` | `src/WalmartApIs/Models/Enums/WmGlobalVersion.cs` |
| `V3PriceRequest` | `src/WalmartApIs/Models/V3PriceRequest.cs` |
| `V3PriceResponse` | `src/WalmartApIs/Models/V3PriceResponse.cs` |
| `UpdatePriceError` | `src/WalmartApIs/Errors/UpdatePriceError.cs` |
| `V3Token400Error1` | `src/WalmartApIs/Models/V3Token400Error1.cs` |

### UpdateStrategy

- **Auth**: `options.AccessToken`
- **Signature**: `UpdateStrategy(UpdateStrategyRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `StrategyCollectionId`, `WmQosCorrelationId`, `WmSvcName`, `WmMarket`, `WmGlobalVersion`, `Body`
- **Returns**: `V3RepricerStrategyResponse`
- **Error**: `ApiException<UpdateStrategyError>` — **Case A (typed)**
- **Error accessors**: `TryGetV3RepricerStrategy400Error1(out V3RepricerStrategy400Error1)` [400] · `TryGetV3Token400Error1(out V3Token400Error1)` [403, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `UpdateStrategyRequest` | `src/WalmartApIs/Requests/Prices/UpdateStrategyRequest.cs` |
| `WmMarket1` | `src/WalmartApIs/Models/Enums/WmMarket1.cs` |
| `WmGlobalVersion` | `src/WalmartApIs/Models/Enums/WmGlobalVersion.cs` |
| `V3RepricerStrategyRequest` | `src/WalmartApIs/Models/V3RepricerStrategyRequest.cs` |
| `V3RepricerStrategyResponse` | `src/WalmartApIs/Models/V3RepricerStrategyResponse.cs` |
| `UpdateStrategyError` | `src/WalmartApIs/Errors/UpdateStrategyError.cs` |
| `V3RepricerStrategy400Error1` | `src/WalmartApIs/Models/V3RepricerStrategy400Error1.cs` |
| `V3Token400Error1` | `src/WalmartApIs/Models/V3Token400Error1.cs` |

### UpdateWalmartFundedIncentivesEnrollmentStatus

- **Auth**: `options.AccessToken`
- **Signature**: `UpdateWalmartFundedIncentivesEnrollmentStatus(UpdateWalmartFundedIncentivesEnrollmentStatusRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `WmQosCorrelationId`, `WmSvcName`, `WmMarket`, `WmGlobalVersion`
- **Query params (wire ← C#)**: `autoEnrollEnabled` ← `AutoEnrollEnabled`
- **Returns**: `V3PriceIncentivesWfpreferenceResponse`
- **Error**: `ApiException<UpdateWalmartFundedIncentivesEnrollmentStatusError>` — **Case A (typed)**
- **Error accessors**: `TryGetV3Token400Error1(out V3Token400Error1)` [403, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `UpdateWalmartFundedIncentivesEnrollmentStatusRequest` | `src/WalmartApIs/Requests/Prices/UpdateWalmartFundedIncentivesEnrollmentStatusRequest.cs` |
| `WmMarket1` | `src/WalmartApIs/Models/Enums/WmMarket1.cs` |
| `WmGlobalVersion` | `src/WalmartApIs/Models/Enums/WmGlobalVersion.cs` |
| `V3PriceIncentivesWfpreferenceResponse` | `src/WalmartApIs/Models/V3PriceIncentivesWfpreferenceResponse.cs` |
| `UpdateWalmartFundedIncentivesEnrollmentStatusError` | `src/WalmartApIs/Errors/UpdateWalmartFundedIncentivesEnrollmentStatusError.cs` |
| `V3Token400Error1` | `src/WalmartApIs/Models/V3Token400Error1.cs` |

### WalmartFundedIncentivesEnrollment

- **Auth**: `options.AccessToken`
- **Signature**: `WalmartFundedIncentivesEnrollment(WalmartFundedIncentivesEnrollmentRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `FeedType`, `WmQosCorrelationId`, `WmSvcName`, `WmMarket`, `WmGlobalVersion`, `Body`
- **Query params (wire ← C#)**: `feedType` ← `FeedType`
- **Returns**: `FeedId`
- **Error**: `ApiException<WalmartFundedIncentivesEnrollmentError>` — **Case A (typed)**
- **Error accessors**: `TryGetV3Token400Error1(out V3Token400Error1)` [403, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `WalmartFundedIncentivesEnrollmentRequest` | `src/WalmartApIs/Requests/Prices/WalmartFundedIncentivesEnrollmentRequest.cs` |
| `FeedType2` | `src/WalmartApIs/Models/Enums/FeedType2.cs` |
| `WmMarket1` | `src/WalmartApIs/Models/Enums/WmMarket1.cs` |
| `WmGlobalVersion` | `src/WalmartApIs/Models/Enums/WmGlobalVersion.cs` |
| `V3FeedsFeedTypeWalmartFundedIncentivesEnrollmentRequest` | `src/WalmartApIs/Models/V3FeedsFeedTypeWalmartFundedIncentivesEnrollmentRequest.cs` |
| `FeedId` | `src/WalmartApIs/Models/FeedId.cs` |
| `WalmartFundedIncentivesEnrollmentError` | `src/WalmartApIs/Errors/WalmartFundedIncentivesEnrollmentError.cs` |
| `V3Token400Error1` | `src/WalmartApIs/Models/V3Token400Error1.cs` |

