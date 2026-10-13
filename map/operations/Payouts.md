<!-- Generated file — do not edit; regenerated with the SDK. -->

# Payouts — operations

Accessor: `client.Payouts` · Source: `src/WalmartApIs/Api/Payouts.cs` · 5 operations

**Type sources**: the file declaring each type an operation names (`RawError` excluded — see sdk-map.md).

### ConfigureAutoPayout

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `ConfigureAutoPayout(ConfigureAutoPayoutRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `Body`
- **Returns**: `PayoutStatusResponse`
- **Error**: `ApiException<ConfigureAutoPayoutError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorList(out ErrorList)` [400, 401, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `ConfigureAutoPayoutRequest` | `src/WalmartApIs/Requests/Payouts/ConfigureAutoPayoutRequest.cs` |
| `DisbursementsV4PaymentAutoPayoutRequest` | `src/WalmartApIs/Models/DisbursementsV4PaymentAutoPayoutRequest.cs` |
| `PayoutStatusResponse` | `src/WalmartApIs/Models/PayoutStatusResponse.cs` |
| `ConfigureAutoPayoutError` | `src/WalmartApIs/Errors/ConfigureAutoPayoutError.cs` |
| `ErrorList` | `src/WalmartApIs/Models/ErrorList.cs` |

### GetAnnualStatementOpts

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `GetAnnualStatementOpts(RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
- **Returns**: `AnnualStatementOptsResponse`
- **Error**: `ApiException<GetAnnualStatementOptsError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorList(out ErrorList)` [400, 401, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `AnnualStatementOptsResponse` | `src/WalmartApIs/Models/AnnualStatementOptsResponse.cs` |
| `GetAnnualStatementOptsError` | `src/WalmartApIs/Errors/GetAnnualStatementOptsError.cs` |
| `ErrorList` | `src/WalmartApIs/Models/ErrorList.cs` |

### GetFasterPayoutEligibility

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `GetFasterPayoutEligibility(RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
- **Returns**: `FasterPayoutEligibilityResponse`
- **Error**: `ApiException<GetFasterPayoutEligibilityError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorList(out ErrorList)` [400, 401, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `FasterPayoutEligibilityResponse` | `src/WalmartApIs/Models/FasterPayoutEligibilityResponse.cs` |
| `GetFasterPayoutEligibilityError` | `src/WalmartApIs/Errors/GetFasterPayoutEligibilityError.cs` |
| `ErrorList` | `src/WalmartApIs/Models/ErrorList.cs` |

### GetPaymentStatus

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `GetPaymentStatus(RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
- **Returns**: `PayoutStatusResponse`
- **Error**: `ApiException<GetPaymentStatusError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorList(out ErrorList)` [400, 401, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `PayoutStatusResponse` | `src/WalmartApIs/Models/PayoutStatusResponse.cs` |
| `GetPaymentStatusError` | `src/WalmartApIs/Errors/GetPaymentStatusError.cs` |
| `ErrorList` | `src/WalmartApIs/Models/ErrorList.cs` |

### InitiateFasterPayout

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `InitiateFasterPayout(RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
- **Returns**: `InitiatePayoutResponse`
- **Error**: `ApiException<InitiateFasterPayoutError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorList(out ErrorList)` [400, 401, 409, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `InitiatePayoutResponse` | `src/WalmartApIs/Models/InitiatePayoutResponse.cs` |
| `InitiateFasterPayoutError` | `src/WalmartApIs/Errors/InitiateFasterPayoutError.cs` |
| `ErrorList` | `src/WalmartApIs/Models/ErrorList.cs` |

