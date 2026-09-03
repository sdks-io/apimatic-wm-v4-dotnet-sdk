<!-- Generated file — do not edit; regenerated with the SDK. -->

# ProductFees — operations

Accessor: `client.ProductFees` · Source: `Api/ProductFees.cs` · 3 operations

**Type sources**: the file declaring each type an operation names (`RawError` excluded — see sdk-map.md).

### GetMyFeesEstimateForItem

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `GetMyFeesEstimateForItem(string walmartItemId, GetMyFeesEstimateRequest body, RequestOptions? requestOptions = null, CancellationToken ct = default)`
- **Returns**: `GetMyFeesEstimateResponse`
- **Error**: `SdkException<GetMyFeesEstimateForItemError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorList(out ErrorList)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `GetMyFeesEstimateRequest` | `Models/GetMyFeesEstimateRequest.cs` |
| `GetMyFeesEstimateResponse` | `Models/GetMyFeesEstimateResponse.cs` |
| `GetMyFeesEstimateForItemError` | `Errors/GetMyFeesEstimateForItemError.cs` |
| `ErrorList` | `Models/ErrorList.cs` |

### GetMyFeesEstimateForSku

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `GetMyFeesEstimateForSku(string sellerSku, string marketplaceId, GetMyFeesEstimateRequest body, RequestOptions? requestOptions = null, CancellationToken ct = default)`
- **Query params (wire ← C#)**: `MarketplaceId` ← `marketplaceId`
- **Returns**: `GetMyFeesEstimateResponse`
- **Error**: `SdkException<GetMyFeesEstimateForSkuError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorList(out ErrorList)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `GetMyFeesEstimateRequest` | `Models/GetMyFeesEstimateRequest.cs` |
| `GetMyFeesEstimateResponse` | `Models/GetMyFeesEstimateResponse.cs` |
| `GetMyFeesEstimateForSkuError` | `Errors/GetMyFeesEstimateForSkuError.cs` |
| `ErrorList` | `Models/ErrorList.cs` |

### GetMyFeesEstimates

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `GetMyFeesEstimates(IReadOnlyList<FeesEstimateByIdRequest> body, RequestOptions? requestOptions = null, CancellationToken ct = default)`
- **Returns**: `IReadOnlyList<FeesEstimateResult>`
- **Error**: `SdkException<GetMyFeesEstimatesError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorList(out ErrorList)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `FeesEstimateByIdRequest` | `Models/FeesEstimateByIdRequest.cs` |
| `FeesEstimateResult` | `Models/FeesEstimateResult.cs` |
| `GetMyFeesEstimatesError` | `Errors/GetMyFeesEstimatesError.cs` |
| `ErrorList` | `Models/ErrorList.cs` |

