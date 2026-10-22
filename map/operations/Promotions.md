<!-- Generated file — do not edit; regenerated with the SDK. -->

# Promotions — operations

Accessor: `client.Promotions` · Source: `src/WalmartApIs/Api/Promotions.cs` · 3 operations

**Type sources**: the file declaring each type an operation names (`RawError` excluded — see sdk-map.md).

### GetPromotionalPrices

- **Signature**: `GetPromotionalPrices(GetPromotionalPricesRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `Sku`, `WmSecAccessToken`, `WmQosCorrelationId`, `WmSvcName`, `WmMarket`, `WmGlobalVersion`
- **Returns**: `V3PromoSkuResponse`
- **Error**: `ApiException<GetPromotionalPricesError>` — **Case A (typed)**
- **Error accessors**: `TryGetV3Token500Error1(out V3Token500Error1)` [401] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `GetPromotionalPricesRequest` | `src/WalmartApIs/Requests/Promotions/GetPromotionalPricesRequest.cs` |
| `WmMarket1` | `src/WalmartApIs/Models/Enums/WmMarket1.cs` |
| `WmGlobalVersion` | `src/WalmartApIs/Models/Enums/WmGlobalVersion.cs` |
| `V3PromoSkuResponse` | `src/WalmartApIs/Models/V3PromoSkuResponse.cs` |
| `GetPromotionalPricesError` | `src/WalmartApIs/Errors/GetPromotionalPricesError.cs` |
| `V3Token500Error1` | `src/WalmartApIs/Models/V3Token500Error1.cs` |

### PriceBulkUploads

- **Signature**: `PriceBulkUploads(PriceBulkUploadsRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `FeedType`, `WmSecAccessToken`, `WmQosCorrelationId`, `WmSvcName`, `WmMarket`, `WmGlobalVersion`
- **Query params (wire ← C#)**: `feedType` ← `FeedType`
- **Returns**: `FeedId1`
- **Error**: `ApiException<PriceBulkUploadsError>` — **Case A (typed)**
- **Error accessors**: `TryGetV3Token500Error1(out V3Token500Error1)` [401, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `PriceBulkUploadsRequest` | `src/WalmartApIs/Requests/Promotions/PriceBulkUploadsRequest.cs` |
| `FeedType21` | `src/WalmartApIs/Models/Enums/FeedType21.cs` |
| `WmMarket1` | `src/WalmartApIs/Models/Enums/WmMarket1.cs` |
| `WmGlobalVersion` | `src/WalmartApIs/Models/Enums/WmGlobalVersion.cs` |
| `V3FeedsFeedTypePriceAndPromotionRequest1` | `src/WalmartApIs/Models/V3FeedsFeedTypePriceAndPromotionRequest1.cs` |
| `FeedId1` | `src/WalmartApIs/Models/FeedId1.cs` |
| `PriceBulkUploadsError` | `src/WalmartApIs/Errors/PriceBulkUploadsError.cs` |
| `V3Token500Error1` | `src/WalmartApIs/Models/V3Token500Error1.cs` |

### UpdatePromotionalPrices

- **Signature**: `UpdatePromotionalPrices(UpdatePromotionalPricesRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `WmSecAccessToken`, `WmQosCorrelationId`, `WmSvcName`, `WmMarket`, `WmGlobalVersion`, `Body`
- **Returns**: `V3PriceResponse`
- **Error**: `ApiException<UpdatePromotionalPricesError>` — **Case A (typed)**
- **Error accessors**: `TryGetV3Token500Error1(out V3Token500Error1)` [403, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `UpdatePromotionalPricesRequest` | `src/WalmartApIs/Requests/Promotions/UpdatePromotionalPricesRequest.cs` |
| `WmMarket1` | `src/WalmartApIs/Models/Enums/WmMarket1.cs` |
| `WmGlobalVersion` | `src/WalmartApIs/Models/Enums/WmGlobalVersion.cs` |
| `V3PriceRequest` | `src/WalmartApIs/Models/V3PriceRequest.cs` |
| `V3PriceResponse` | `src/WalmartApIs/Models/V3PriceResponse.cs` |
| `UpdatePromotionalPricesError` | `src/WalmartApIs/Errors/UpdatePromotionalPricesError.cs` |
| `V3Token500Error1` | `src/WalmartApIs/Models/V3Token500Error1.cs` |

