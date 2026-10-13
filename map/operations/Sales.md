<!-- Generated file — do not edit; regenerated with the SDK. -->

# Sales — operations

Accessor: `client.Sales` · Source: `src/WalmartApIs/Api/Sales.cs` · 1 operation

**Type sources**: the file declaring each type an operation names (`RawError` excluded — see sdk-map.md).

### GetOrderMetrics

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `GetOrderMetrics(GetOrderMetricsRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `MarketplaceIds`, `Interval`, `Granularity`
- **Query params (wire ← C#)**: `marketplaceIds` ← `MarketplaceIds`, `interval` ← `Interval`, `granularity` ← `Granularity`, `granularityTimeZone` ← `GranularityTimeZone`, `buyerType` ← `BuyerType`, `fulfillmentNetwork` ← `FulfillmentNetwork`, `firstDayOfWeek` ← `FirstDayOfWeek`, `asin` ← `Asin`, `sku` ← `Sku`, `sp-apiProgram` ← `SpApiProgram`
- **Returns**: `object`
- **Error**: `ApiException<GetOrderMetricsError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorList(out ErrorList)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `GetOrderMetricsRequest` | `src/WalmartApIs/Requests/Sales/GetOrderMetricsRequest.cs` |
| `Granularity` | `src/WalmartApIs/Models/Enums/Granularity.cs` |
| `BuyerType` | `src/WalmartApIs/Models/Enums/BuyerType.cs` |
| `FirstDayOfWeek` | `src/WalmartApIs/Models/Enums/FirstDayOfWeek.cs` |
| `GetOrderMetricsError` | `src/WalmartApIs/Errors/GetOrderMetricsError.cs` |
| `ErrorList` | `src/WalmartApIs/Models/ErrorList.cs` |

