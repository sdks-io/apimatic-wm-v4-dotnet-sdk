<!-- Generated file — do not edit; regenerated with the SDK. -->

# Solicitations — operations

Accessor: `client.Solicitations` · Source: `src/WalmartApIs/Api/Solicitations.cs` · 2 operations

**Type sources**: the file declaring each type an operation names (`RawError` excluded — see sdk-map.md).

### CreateProductReviewAndSellerFeedbackSolicitation

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `CreateProductReviewAndSellerFeedbackSolicitation(CreateProductReviewAndSellerFeedbackSolicitationRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `SpApiOrderId`, `MarketplaceIds`
- **Query params (wire ← C#)**: `marketplaceIds` ← `MarketplaceIds`
- **Returns**: `object`
- **Error**: `ApiException<CreateProductReviewAndSellerFeedbackSolicitationError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorList(out ErrorList)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `CreateProductReviewAndSellerFeedbackSolicitationRequest` | `src/WalmartApIs/Requests/Solicitations/CreateProductReviewAndSellerFeedbackSolicitationRequest.cs` |
| `CreateProductReviewAndSellerFeedbackSolicitationError` | `src/WalmartApIs/Errors/CreateProductReviewAndSellerFeedbackSolicitationError.cs` |
| `ErrorList` | `src/WalmartApIs/Models/ErrorList.cs` |

### GetSolicitationActionsForOrder

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `GetSolicitationActionsForOrder(GetSolicitationActionsForOrderRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `SpApiOrderId`, `MarketplaceIds`
- **Query params (wire ← C#)**: `marketplaceIds` ← `MarketplaceIds`
- **Returns**: `object`
- **Error**: `ApiException<GetSolicitationActionsForOrderError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorList(out ErrorList)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `GetSolicitationActionsForOrderRequest` | `src/WalmartApIs/Requests/Solicitations/GetSolicitationActionsForOrderRequest.cs` |
| `GetSolicitationActionsForOrderError` | `src/WalmartApIs/Errors/GetSolicitationActionsForOrderError.cs` |
| `ErrorList` | `src/WalmartApIs/Models/ErrorList.cs` |

