<!-- Generated file — do not edit; regenerated with the SDK. -->

# ProductPricing — operations

Accessor: `client.ProductPricing` · Source: `src/WalmartApIs/Api/ProductPricing.cs` · 8 operations

**Type sources**: the file declaring each type an operation names (`RawError` excluded — see sdk-map.md).

### GetCompetitivePricing

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `GetCompetitivePricing(GetCompetitivePricingRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `MarketplaceId`
- **Query params (wire ← C#)**: `MarketplaceId` ← `MarketplaceId`, `ItemType` ← `ItemType`, `Skus` ← `Skus`, `walmartItemIds` ← `WalmartItemIds`, `CustomerType` ← `CustomerType`
- **Returns**: `GetPricingResponse`
- **Error**: `ApiException<GetCompetitivePricingError>` — **Case A (typed)**
- **Error accessors**: `TryGetListOfError3(out IReadOnlyList<Error3>)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `GetCompetitivePricingRequest` | `src/WalmartApIs/Requests/ProductPricing/GetCompetitivePricingRequest.cs` |
| `ItemType` | `src/WalmartApIs/Models/Enums/ItemType.cs` |
| `CustomerType` | `src/WalmartApIs/Models/Enums/CustomerType.cs` |
| `GetPricingResponse` | `src/WalmartApIs/Models/GetPricingResponse.cs` |
| `GetCompetitivePricingError` | `src/WalmartApIs/Errors/GetCompetitivePricingError.cs` |
| `Error3` | `src/WalmartApIs/Models/Error3.cs` |

### GetCompetitiveSummary

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `GetCompetitiveSummary(GetCompetitiveSummaryRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `Body`
- **Returns**: `CompetitiveSummaryBatchResponse`
- **Error**: `ApiException<GetCompetitiveSummaryError>` — **Case A (typed)**
- **Error accessors**: `TryGetListOfError3(out IReadOnlyList<Error3>)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `GetCompetitiveSummaryRequest` | `src/WalmartApIs/Requests/ProductPricing/GetCompetitiveSummaryRequest.cs` |
| `CompetitiveSummaryBatchRequest` | `src/WalmartApIs/Models/CompetitiveSummaryBatchRequest.cs` |
| `CompetitiveSummaryBatchResponse` | `src/WalmartApIs/Models/CompetitiveSummaryBatchResponse.cs` |
| `GetCompetitiveSummaryError` | `src/WalmartApIs/Errors/GetCompetitiveSummaryError.cs` |
| `Error3` | `src/WalmartApIs/Models/Error3.cs` |

### GetFeaturedOfferExpectedPriceBatch

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `GetFeaturedOfferExpectedPriceBatch(GetFeaturedOfferExpectedPriceBatchOperationRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `Body`
- **Returns**: `GetFeaturedOfferExpectedPriceBatchResponse`
- **Error**: `ApiException<GetFeaturedOfferExpectedPriceBatchError>` — **Case A (typed)**
- **Error accessors**: `TryGetListOfError3(out IReadOnlyList<Error3>)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `GetFeaturedOfferExpectedPriceBatchOperationRequest` | `src/WalmartApIs/Requests/ProductPricing/GetFeaturedOfferExpectedPriceBatchOperationRequest.cs` |
| `GetFeaturedOfferExpectedPriceBatchRequest` | `src/WalmartApIs/Models/GetFeaturedOfferExpectedPriceBatchRequest.cs` |
| `GetFeaturedOfferExpectedPriceBatchResponse` | `src/WalmartApIs/Models/GetFeaturedOfferExpectedPriceBatchResponse.cs` |
| `GetFeaturedOfferExpectedPriceBatchError` | `src/WalmartApIs/Errors/GetFeaturedOfferExpectedPriceBatchError.cs` |
| `Error3` | `src/WalmartApIs/Models/Error3.cs` |

### GetItemOffers

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `GetItemOffers(GetItemOffersRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `ItemId`, `MarketplaceId`, `ItemCondition`
- **Query params (wire ← C#)**: `MarketplaceId` ← `MarketplaceId`, `ItemCondition` ← `ItemCondition`, `CustomerType` ← `CustomerType`
- **Returns**: `GetOffersResponse`
- **Error**: `ApiException<GetItemOffersError>` — **Case A (typed)**
- **Error accessors**: `TryGetListOfError3(out IReadOnlyList<Error3>)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `GetItemOffersRequest` | `src/WalmartApIs/Requests/ProductPricing/GetItemOffersRequest.cs` |
| `ConditionType2` | `src/WalmartApIs/Models/Enums/ConditionType2.cs` |
| `CustomerType` | `src/WalmartApIs/Models/Enums/CustomerType.cs` |
| `GetOffersResponse` | `src/WalmartApIs/Models/GetOffersResponse.cs` |
| `GetItemOffersError` | `src/WalmartApIs/Errors/GetItemOffersError.cs` |
| `Error3` | `src/WalmartApIs/Models/Error3.cs` |

### GetItemOffersBatch

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `GetItemOffersBatch(GetItemOffersBatchOperationRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `Body`
- **Returns**: `GetItemOffersBatchResponse`
- **Error**: `ApiException<GetItemOffersBatchError>` — **Case A (typed)**
- **Error accessors**: `TryGetListOfError3(out IReadOnlyList<Error3>)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `GetItemOffersBatchOperationRequest` | `src/WalmartApIs/Requests/ProductPricing/GetItemOffersBatchOperationRequest.cs` |
| `GetItemOffersBatchRequest` | `src/WalmartApIs/Models/GetItemOffersBatchRequest.cs` |
| `GetItemOffersBatchResponse` | `src/WalmartApIs/Models/GetItemOffersBatchResponse.cs` |
| `GetItemOffersBatchError` | `src/WalmartApIs/Errors/GetItemOffersBatchError.cs` |
| `Error3` | `src/WalmartApIs/Models/Error3.cs` |

### GetListingOffers

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `GetListingOffers(GetListingOffersRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `SellerSku`, `MarketplaceId`, `ItemCondition`
- **Query params (wire ← C#)**: `MarketplaceId` ← `MarketplaceId`, `ItemCondition` ← `ItemCondition`, `CustomerType` ← `CustomerType`
- **Returns**: `GetOffersResponse`
- **Error**: `ApiException<GetListingOffersError>` — **Case A (typed)**
- **Error accessors**: `TryGetListOfError3(out IReadOnlyList<Error3>)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `GetListingOffersRequest` | `src/WalmartApIs/Requests/ProductPricing/GetListingOffersRequest.cs` |
| `ConditionType2` | `src/WalmartApIs/Models/Enums/ConditionType2.cs` |
| `CustomerType` | `src/WalmartApIs/Models/Enums/CustomerType.cs` |
| `GetOffersResponse` | `src/WalmartApIs/Models/GetOffersResponse.cs` |
| `GetListingOffersError` | `src/WalmartApIs/Errors/GetListingOffersError.cs` |
| `Error3` | `src/WalmartApIs/Models/Error3.cs` |

### GetListingOffersBatch

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `GetListingOffersBatch(GetListingOffersBatchOperationRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `Body`
- **Returns**: `GetListingOffersBatchResponse`
- **Error**: `ApiException<GetListingOffersBatchError>` — **Case A (typed)**
- **Error accessors**: `TryGetListOfError3(out IReadOnlyList<Error3>)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `GetListingOffersBatchOperationRequest` | `src/WalmartApIs/Requests/ProductPricing/GetListingOffersBatchOperationRequest.cs` |
| `GetListingOffersBatchRequest` | `src/WalmartApIs/Models/GetListingOffersBatchRequest.cs` |
| `GetListingOffersBatchResponse` | `src/WalmartApIs/Models/GetListingOffersBatchResponse.cs` |
| `GetListingOffersBatchError` | `src/WalmartApIs/Errors/GetListingOffersBatchError.cs` |
| `Error3` | `src/WalmartApIs/Models/Error3.cs` |

### GetPricing

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `GetPricing(GetPricingRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `MarketplaceId`
- **Query params (wire ← C#)**: `MarketplaceId` ← `MarketplaceId`, `ItemType` ← `ItemType`, `Skus` ← `Skus`, `walmartItemIds` ← `WalmartItemIds`, `ItemCondition` ← `ItemCondition`, `OfferType` ← `OfferType`, `CustomerType` ← `CustomerType`
- **Returns**: `GetPricingResponse`
- **Error**: `ApiException<GetPricingError>` — **Case A (typed)**
- **Error accessors**: `TryGetListOfError3(out IReadOnlyList<Error3>)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `GetPricingRequest` | `src/WalmartApIs/Requests/ProductPricing/GetPricingRequest.cs` |
| `ItemType` | `src/WalmartApIs/Models/Enums/ItemType.cs` |
| `ConditionType2` | `src/WalmartApIs/Models/Enums/ConditionType2.cs` |
| `OfferType` | `src/WalmartApIs/Models/Enums/OfferType.cs` |
| `CustomerType` | `src/WalmartApIs/Models/Enums/CustomerType.cs` |
| `GetPricingResponse` | `src/WalmartApIs/Models/GetPricingResponse.cs` |
| `GetPricingError` | `src/WalmartApIs/Errors/GetPricingError.cs` |
| `Error3` | `src/WalmartApIs/Models/Error3.cs` |

