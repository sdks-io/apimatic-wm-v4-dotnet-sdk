<!-- Generated file — do not edit; regenerated with the SDK. -->

# Payouts — operations

Accessor: `client.Payouts` · Source: `Api/Payouts.cs` · 5 operations

**Type sources**: the file declaring each type an operation names (`RawError` excluded — see sdk-map.md).

### ConfigureAutoPayout

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `ConfigureAutoPayout(DisbursementsV4PaymentAutoPayoutRequest body, RequestOptions? requestOptions = null, CancellationToken ct = default)`
- **Returns**: `PayoutStatusResponse`
- **Error**: `SdkException<ConfigureAutoPayoutError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorList(out ErrorList)` [400, 401, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `DisbursementsV4PaymentAutoPayoutRequest` | `Models/DisbursementsV4PaymentAutoPayoutRequest.cs` |
| `PayoutStatusResponse` | `Models/PayoutStatusResponse.cs` |
| `ConfigureAutoPayoutError` | `Errors/ConfigureAutoPayoutError.cs` |
| `ErrorList` | `Models/ErrorList.cs` |

### GetAnnualStatementOpts

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `GetAnnualStatementOpts(RequestOptions? requestOptions = null, CancellationToken ct = default)`
- **Returns**: `AnnualStatementOptsResponse`
- **Error**: `SdkException<GetAnnualStatementOptsError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorList(out ErrorList)` [400, 401, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `AnnualStatementOptsResponse` | `Models/AnnualStatementOptsResponse.cs` |
| `GetAnnualStatementOptsError` | `Errors/GetAnnualStatementOptsError.cs` |
| `ErrorList` | `Models/ErrorList.cs` |

### GetFasterPayoutEligibility

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `GetFasterPayoutEligibility(RequestOptions? requestOptions = null, CancellationToken ct = default)`
- **Returns**: `FasterPayoutEligibilityResponse`
- **Error**: `SdkException<GetFasterPayoutEligibilityError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorList(out ErrorList)` [400, 401, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `FasterPayoutEligibilityResponse` | `Models/FasterPayoutEligibilityResponse.cs` |
| `GetFasterPayoutEligibilityError` | `Errors/GetFasterPayoutEligibilityError.cs` |
| `ErrorList` | `Models/ErrorList.cs` |

### GetPaymentStatus

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `GetPaymentStatus(RequestOptions? requestOptions = null, CancellationToken ct = default)`
- **Returns**: `PayoutStatusResponse`
- **Error**: `SdkException<GetPaymentStatusError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorList(out ErrorList)` [400, 401, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `PayoutStatusResponse` | `Models/PayoutStatusResponse.cs` |
| `GetPaymentStatusError` | `Errors/GetPaymentStatusError.cs` |
| `ErrorList` | `Models/ErrorList.cs` |

### InitiateFasterPayout

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `InitiateFasterPayout(RequestOptions? requestOptions = null, CancellationToken ct = default)`
- **Returns**: `InitiatePayoutResponse`
- **Error**: `SdkException<InitiateFasterPayoutError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorList(out ErrorList)` [400, 401, 409, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `InitiatePayoutResponse` | `Models/InitiatePayoutResponse.cs` |
| `InitiateFasterPayoutError` | `Errors/InitiateFasterPayoutError.cs` |
| `ErrorList` | `Models/ErrorList.cs` |

