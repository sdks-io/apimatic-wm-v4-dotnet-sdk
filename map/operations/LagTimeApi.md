<!-- Generated file — do not edit; regenerated with the SDK. -->

# LagTimeApi — operations

Accessor: `client.LagTimeApi` · Source: `src/WalmartApIs/Api/LagTimeApi.cs` · 2 operations

**Type sources**: the file declaring each type an operation names (`RawError` excluded — see sdk-map.md).

### GetLagTime

- **Auth**: `options.AccessToken`
- **Signature**: `GetLagTime(GetLagTimeRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `Sku`, `WmSecAccessToken`, `WmQosCorrelationId`, `WmSvcName`, `WmMarket`, `WmGlobalVersion`
- **Query params (wire ← C#)**: `sku` ← `Sku`
- **Returns**: `LagTimeResponse`
- **Error**: `ApiException<GetLagTimeError>` — **Case A (typed)**
- **Error accessors**: `TryGetV3Lagtime400Error1(out V3Lagtime400Error1)` [400] · `TryGetV3Lagtime404Error1(out V3Lagtime404Error1)` [404] · `TryGetV3Lagtime500Error1(out V3Lagtime500Error1)` [500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `GetLagTimeRequest` | `src/WalmartApIs/Requests/LagTimeApi/GetLagTimeRequest.cs` |
| `WmMarket1` | `src/WalmartApIs/Models/Enums/WmMarket1.cs` |
| `WmGlobalVersion` | `src/WalmartApIs/Models/Enums/WmGlobalVersion.cs` |
| `LagTimeResponse` | `src/WalmartApIs/Models/LagTimeResponse.cs` |
| `GetLagTimeError` | `src/WalmartApIs/Errors/GetLagTimeError.cs` |
| `V3Lagtime400Error1` | `src/WalmartApIs/Models/V3Lagtime400Error1.cs` |
| `V3Lagtime404Error1` | `src/WalmartApIs/Models/V3Lagtime404Error1.cs` |
| `V3Lagtime500Error1` | `src/WalmartApIs/Models/V3Lagtime500Error1.cs` |

### UpdateLagTimeBulk

- **Auth**: `options.AccessToken`
- **Signature**: `UpdateLagTimeBulk(UpdateLagTimeBulkRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `FeedType`, `WmSecAccessToken`, `WmQosCorrelationId`, `WmSvcName`, `WmMarket`, `WmGlobalVersion`, `Body`
- **Query params (wire ← C#)**: `feedType` ← `FeedType`
- **Returns**: `FeedId1`
- **Error**: `ApiException<RawError>` — **Case B**

| Type | Source |
| --- | --- |
| `UpdateLagTimeBulkRequest` | `src/WalmartApIs/Requests/LagTimeApi/UpdateLagTimeBulkRequest.cs` |
| `WmMarket1` | `src/WalmartApIs/Models/Enums/WmMarket1.cs` |
| `WmGlobalVersion` | `src/WalmartApIs/Models/Enums/WmGlobalVersion.cs` |
| `V3FeedsRequest` | `src/WalmartApIs/Models/V3FeedsRequest.cs` |
| `FeedId1` | `src/WalmartApIs/Models/FeedId1.cs` |

