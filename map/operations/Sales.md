<!-- Generated file — do not edit; regenerated with the SDK. -->

# Sales — operations

Accessor: `client.Sales` · Source: `Api/Sales.cs` · 1 operation

**Type sources**: the file declaring each type an operation names (`RawError` excluded — see sdk-map.md).

### GetOrderMetrics

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `GetOrderMetrics(IReadOnlyList<string> marketplaceIds, string interval, Granularity granularity, string? granularityTimeZone, BuyerType? buyerType, string? fulfillmentNetwork, FirstDayOfWeek? firstDayOfWeek, string? asin, string? sku, string? spApiProgram, RequestOptions? requestOptions = null, CancellationToken ct = default)`
  - 7 params (`granularityTimeZone` … `spApiProgram`) — nullable, no default → **must pass explicitly** (pass `null` to skip)
- **Query params (wire ← C#)**: `marketplaceIds` ← `marketplaceIds`, `interval` ← `interval`, `granularity` ← `granularity`, `granularityTimeZone` ← `granularityTimeZone`, `buyerType` ← `buyerType`, `fulfillmentNetwork` ← `fulfillmentNetwork`, `firstDayOfWeek` ← `firstDayOfWeek`, `asin` ← `asin`, `sku` ← `sku`, `sp-apiProgram` ← `spApiProgram`
- **Returns**: `object`
- **Error**: `SdkException<GetOrderMetricsError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorList(out ErrorList)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `Granularity` | `Models/Enums/Granularity.cs` |
| `BuyerType` | `Models/Enums/BuyerType.cs` |
| `FirstDayOfWeek` | `Models/Enums/FirstDayOfWeek.cs` |
| `GetOrderMetricsError` | `Errors/GetOrderMetricsError.cs` |
| `ErrorList` | `Models/ErrorList.cs` |

