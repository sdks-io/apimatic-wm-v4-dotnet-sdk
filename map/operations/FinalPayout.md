<!-- Generated file — do not edit; regenerated with the SDK. -->

# FinalPayout — operations

Accessor: `client.FinalPayout` · Source: `Api/FinalPayout.cs` · 2 operations

**Type sources**: the file declaring each type an operation names (`RawError` excluded — see sdk-map.md).

### GetFinalPayoutCaseStatus

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `GetFinalPayoutCaseStatus(RequestOptions? requestOptions = null, CancellationToken ct = default)`
- **Returns**: `FinalPayoutCaseStatusResponse`
- **Error**: `SdkException<GetFinalPayoutCaseStatusError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorList(out ErrorList)` [400, 401, 404, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `FinalPayoutCaseStatusResponse` | `Models/FinalPayoutCaseStatusResponse.cs` |
| `GetFinalPayoutCaseStatusError` | `Errors/GetFinalPayoutCaseStatusError.cs` |
| `ErrorList` | `Models/ErrorList.cs` |

### UpdateFinalPayoutCaseStatus

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `UpdateFinalPayoutCaseStatus(DisbursementsV4FinalPayoutCaseUpdateStatusRequest body, RequestOptions? requestOptions = null, CancellationToken ct = default)`
- **Returns**: `FinalPayoutCaseStatusResponse`
- **Error**: `SdkException<UpdateFinalPayoutCaseStatusError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorList(out ErrorList)` [400, 404, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `DisbursementsV4FinalPayoutCaseUpdateStatusRequest` | `Models/DisbursementsV4FinalPayoutCaseUpdateStatusRequest.cs` |
| `FinalPayoutCaseStatusResponse` | `Models/FinalPayoutCaseStatusResponse.cs` |
| `UpdateFinalPayoutCaseStatusError` | `Errors/UpdateFinalPayoutCaseStatusError.cs` |
| `ErrorList` | `Models/ErrorList.cs` |

