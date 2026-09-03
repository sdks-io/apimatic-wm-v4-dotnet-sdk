<!-- Generated file — do not edit; regenerated with the SDK. -->

# Solicitations — operations

Accessor: `client.Solicitations` · Source: `Api/Solicitations.cs` · 2 operations

**Type sources**: the file declaring each type an operation names (`RawError` excluded — see sdk-map.md).

### CreateProductReviewAndSellerFeedbackSolicitation

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `CreateProductReviewAndSellerFeedbackSolicitation(string spApiOrderId, IReadOnlyList<string> marketplaceIds, RequestOptions? requestOptions = null, CancellationToken ct = default)`
- **Query params (wire ← C#)**: `marketplaceIds` ← `marketplaceIds`
- **Returns**: `object`
- **Error**: `SdkException<CreateProductReviewAndSellerFeedbackSolicitationError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorList(out ErrorList)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `CreateProductReviewAndSellerFeedbackSolicitationError` | `Errors/CreateProductReviewAndSellerFeedbackSolicitationError.cs` |
| `ErrorList` | `Models/ErrorList.cs` |

### GetSolicitationActionsForOrder

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `GetSolicitationActionsForOrder(string spApiOrderId, IReadOnlyList<string> marketplaceIds, RequestOptions? requestOptions = null, CancellationToken ct = default)`
- **Query params (wire ← C#)**: `marketplaceIds` ← `marketplaceIds`
- **Returns**: `object`
- **Error**: `SdkException<GetSolicitationActionsForOrderError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorList(out ErrorList)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `GetSolicitationActionsForOrderError` | `Errors/GetSolicitationActionsForOrderError.cs` |
| `ErrorList` | `Models/ErrorList.cs` |

