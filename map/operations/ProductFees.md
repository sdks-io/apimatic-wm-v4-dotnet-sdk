<!-- Generated file — do not edit; regenerated with the SDK. -->

# ProductFees — operations

Accessor: `client.ProductFees` · Source: `src/WalmartApIs/Api/ProductFees.cs` · 3 operations

**Type sources**: the file declaring each type an operation names (`RawError` excluded — see sdk-map.md).

### GetMyFeesEstimateForItem

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `GetMyFeesEstimateForItem(GetMyFeesEstimateForItemRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `WalmartItemId`, `Body`
- **Returns**: `GetMyFeesEstimateResponse`
- **Error**: `ApiException<GetMyFeesEstimateForItemError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorList(out ErrorList)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `GetMyFeesEstimateForItemRequest` | `src/WalmartApIs/Requests/ProductFees/GetMyFeesEstimateForItemRequest.cs` |
| `GetMyFeesEstimateRequest` | `src/WalmartApIs/Models/GetMyFeesEstimateRequest.cs` |
| `GetMyFeesEstimateResponse` | `src/WalmartApIs/Models/GetMyFeesEstimateResponse.cs` |
| `GetMyFeesEstimateForItemError` | `src/WalmartApIs/Errors/GetMyFeesEstimateForItemError.cs` |
| `ErrorList` | `src/WalmartApIs/Models/ErrorList.cs` |

### GetMyFeesEstimateForSku

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `GetMyFeesEstimateForSku(GetMyFeesEstimateForSkuRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `SellerSku`, `MarketplaceId`, `Body`
- **Query params (wire ← C#)**: `MarketplaceId` ← `MarketplaceId`
- **Returns**: `GetMyFeesEstimateResponse`
- **Error**: `ApiException<GetMyFeesEstimateForSkuError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorList(out ErrorList)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `GetMyFeesEstimateForSkuRequest` | `src/WalmartApIs/Requests/ProductFees/GetMyFeesEstimateForSkuRequest.cs` |
| `GetMyFeesEstimateRequest` | `src/WalmartApIs/Models/GetMyFeesEstimateRequest.cs` |
| `GetMyFeesEstimateResponse` | `src/WalmartApIs/Models/GetMyFeesEstimateResponse.cs` |
| `GetMyFeesEstimateForSkuError` | `src/WalmartApIs/Errors/GetMyFeesEstimateForSkuError.cs` |
| `ErrorList` | `src/WalmartApIs/Models/ErrorList.cs` |

### GetMyFeesEstimates

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `GetMyFeesEstimates(GetMyFeesEstimatesRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `Body`
- **Returns**: `IReadOnlyList<FeesEstimateResult>`
- **Error**: `ApiException<GetMyFeesEstimatesError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorList(out ErrorList)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `GetMyFeesEstimatesRequest` | `src/WalmartApIs/Requests/ProductFees/GetMyFeesEstimatesRequest.cs` |
| `FeesEstimateByIdRequest` | `src/WalmartApIs/Models/FeesEstimateByIdRequest.cs` |
| `FeesEstimateResult` | `src/WalmartApIs/Models/FeesEstimateResult.cs` |
| `GetMyFeesEstimatesError` | `src/WalmartApIs/Errors/GetMyFeesEstimatesError.cs` |
| `ErrorList` | `src/WalmartApIs/Models/ErrorList.cs` |

