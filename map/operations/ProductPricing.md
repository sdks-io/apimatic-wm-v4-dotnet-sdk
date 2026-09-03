<!-- Generated file — do not edit; regenerated with the SDK. -->

# ProductPricing — operations

Accessor: `client.ProductPricing` · Source: `Api/ProductPricing.cs` · 8 operations

**Type sources**: the file declaring each type an operation names (`RawError` excluded — see sdk-map.md).

### GetCompetitivePricing

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `GetCompetitivePricing(string marketplaceId, ItemType itemType, IReadOnlyList<string>? skus, IReadOnlyList<string>? walmartItemIds, CustomerType? customerType, RequestOptions? requestOptions = null, CancellationToken ct = default)`
  - `skus` — nullable, no default → **must pass explicitly**
  - `walmartItemIds` — nullable, no default → **must pass explicitly**
  - `customerType` — nullable, no default → **must pass explicitly**
- **Query params (wire ← C#)**: `MarketplaceId` ← `marketplaceId`, `ItemType` ← `itemType`, `Skus` ← `skus`, `walmartItemIds` ← `walmartItemIds`, `CustomerType` ← `customerType`
- **Returns**: `GetPricingResponse`
- **Error**: `SdkException<GetCompetitivePricingError>` — **Case A (typed)**
- **Error accessors**: `TryGetListOfError3(out IReadOnlyList<Error3>)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `ItemType` | `Models/Enums/ItemType.cs` |
| `CustomerType` | `Models/Enums/CustomerType.cs` |
| `GetPricingResponse` | `Models/GetPricingResponse.cs` |
| `GetCompetitivePricingError` | `Errors/GetCompetitivePricingError.cs` |
| `Error3` | `Models/Error3.cs` |

### GetCompetitiveSummary

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `GetCompetitiveSummary(CompetitiveSummaryBatchRequest body, RequestOptions? requestOptions = null, CancellationToken ct = default)`
- **Returns**: `CompetitiveSummaryBatchResponse`
- **Error**: `SdkException<GetCompetitiveSummaryError>` — **Case A (typed)**
- **Error accessors**: `TryGetListOfError3(out IReadOnlyList<Error3>)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `CompetitiveSummaryBatchRequest` | `Models/CompetitiveSummaryBatchRequest.cs` |
| `CompetitiveSummaryBatchResponse` | `Models/CompetitiveSummaryBatchResponse.cs` |
| `GetCompetitiveSummaryError` | `Errors/GetCompetitiveSummaryError.cs` |
| `Error3` | `Models/Error3.cs` |

### GetFeaturedOfferExpectedPriceBatch

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `GetFeaturedOfferExpectedPriceBatch(GetFeaturedOfferExpectedPriceBatchRequest body, RequestOptions? requestOptions = null, CancellationToken ct = default)`
- **Returns**: `GetFeaturedOfferExpectedPriceBatchResponse`
- **Error**: `SdkException<GetFeaturedOfferExpectedPriceBatchError>` — **Case A (typed)**
- **Error accessors**: `TryGetListOfError3(out IReadOnlyList<Error3>)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `GetFeaturedOfferExpectedPriceBatchRequest` | `Models/GetFeaturedOfferExpectedPriceBatchRequest.cs` |
| `GetFeaturedOfferExpectedPriceBatchResponse` | `Models/GetFeaturedOfferExpectedPriceBatchResponse.cs` |
| `GetFeaturedOfferExpectedPriceBatchError` | `Errors/GetFeaturedOfferExpectedPriceBatchError.cs` |
| `Error3` | `Models/Error3.cs` |

### GetItemOffers

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `GetItemOffers(string itemId, string marketplaceId, ConditionType2 itemCondition, CustomerType? customerType, RequestOptions? requestOptions = null, CancellationToken ct = default)`
  - `customerType` — nullable, no default → **must pass explicitly**
- **Query params (wire ← C#)**: `MarketplaceId` ← `marketplaceId`, `ItemCondition` ← `itemCondition`, `CustomerType` ← `customerType`
- **Returns**: `GetOffersResponse`
- **Error**: `SdkException<GetItemOffersError>` — **Case A (typed)**
- **Error accessors**: `TryGetListOfError3(out IReadOnlyList<Error3>)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `ConditionType2` | `Models/Enums/ConditionType2.cs` |
| `CustomerType` | `Models/Enums/CustomerType.cs` |
| `GetOffersResponse` | `Models/GetOffersResponse.cs` |
| `GetItemOffersError` | `Errors/GetItemOffersError.cs` |
| `Error3` | `Models/Error3.cs` |

### GetItemOffersBatch

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `GetItemOffersBatch(GetItemOffersBatchRequest body, RequestOptions? requestOptions = null, CancellationToken ct = default)`
- **Returns**: `GetItemOffersBatchResponse`
- **Error**: `SdkException<GetItemOffersBatchError>` — **Case A (typed)**
- **Error accessors**: `TryGetListOfError3(out IReadOnlyList<Error3>)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `GetItemOffersBatchRequest` | `Models/GetItemOffersBatchRequest.cs` |
| `GetItemOffersBatchResponse` | `Models/GetItemOffersBatchResponse.cs` |
| `GetItemOffersBatchError` | `Errors/GetItemOffersBatchError.cs` |
| `Error3` | `Models/Error3.cs` |

### GetListingOffers

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `GetListingOffers(string sellerSku, string marketplaceId, ConditionType2 itemCondition, CustomerType? customerType, RequestOptions? requestOptions = null, CancellationToken ct = default)`
  - `customerType` — nullable, no default → **must pass explicitly**
- **Query params (wire ← C#)**: `MarketplaceId` ← `marketplaceId`, `ItemCondition` ← `itemCondition`, `CustomerType` ← `customerType`
- **Returns**: `GetOffersResponse`
- **Error**: `SdkException<GetListingOffersError>` — **Case A (typed)**
- **Error accessors**: `TryGetListOfError3(out IReadOnlyList<Error3>)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `ConditionType2` | `Models/Enums/ConditionType2.cs` |
| `CustomerType` | `Models/Enums/CustomerType.cs` |
| `GetOffersResponse` | `Models/GetOffersResponse.cs` |
| `GetListingOffersError` | `Errors/GetListingOffersError.cs` |
| `Error3` | `Models/Error3.cs` |

### GetListingOffersBatch

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `GetListingOffersBatch(GetListingOffersBatchRequest body, RequestOptions? requestOptions = null, CancellationToken ct = default)`
- **Returns**: `GetListingOffersBatchResponse`
- **Error**: `SdkException<GetListingOffersBatchError>` — **Case A (typed)**
- **Error accessors**: `TryGetListOfError3(out IReadOnlyList<Error3>)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `GetListingOffersBatchRequest` | `Models/GetListingOffersBatchRequest.cs` |
| `GetListingOffersBatchResponse` | `Models/GetListingOffersBatchResponse.cs` |
| `GetListingOffersBatchError` | `Errors/GetListingOffersBatchError.cs` |
| `Error3` | `Models/Error3.cs` |

### GetPricing

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `GetPricing(string marketplaceId, ItemType itemType, IReadOnlyList<string>? skus, IReadOnlyList<string>? walmartItemIds, ConditionType2? itemCondition, OfferType? offerType, CustomerType? customerType, RequestOptions? requestOptions = null, CancellationToken ct = default)`
  - 5 params (`skus` … `customerType`) — nullable, no default → **must pass explicitly** (pass `null` to skip)
- **Query params (wire ← C#)**: `MarketplaceId` ← `marketplaceId`, `ItemType` ← `itemType`, `Skus` ← `skus`, `walmartItemIds` ← `walmartItemIds`, `ItemCondition` ← `itemCondition`, `OfferType` ← `offerType`, `CustomerType` ← `customerType`
- **Returns**: `GetPricingResponse`
- **Error**: `SdkException<GetPricingError>` — **Case A (typed)**
- **Error accessors**: `TryGetListOfError3(out IReadOnlyList<Error3>)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `ItemType` | `Models/Enums/ItemType.cs` |
| `ConditionType2` | `Models/Enums/ConditionType2.cs` |
| `OfferType` | `Models/Enums/OfferType.cs` |
| `CustomerType` | `Models/Enums/CustomerType.cs` |
| `GetPricingResponse` | `Models/GetPricingResponse.cs` |
| `GetPricingError` | `Errors/GetPricingError.cs` |
| `Error3` | `Models/Error3.cs` |

