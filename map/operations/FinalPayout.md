<!-- Generated file — do not edit; regenerated with the SDK. -->

# FinalPayout — operations

Accessor: `client.FinalPayout` · Source: `src/WalmartApIs/Api/FinalPayout.cs` · 2 operations

**Type sources**: the file declaring each type an operation names (`RawError` excluded — see sdk-map.md).

### GetFinalPayoutCaseStatus

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `GetFinalPayoutCaseStatus(RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
- **Returns**: `FinalPayoutCaseStatusResponse`
- **Error**: `ApiException<GetFinalPayoutCaseStatusError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorList(out ErrorList)` [400, 401, 404, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `FinalPayoutCaseStatusResponse` | `src/WalmartApIs/Models/FinalPayoutCaseStatusResponse.cs` |
| `GetFinalPayoutCaseStatusError` | `src/WalmartApIs/Errors/GetFinalPayoutCaseStatusError.cs` |
| `ErrorList` | `src/WalmartApIs/Models/ErrorList.cs` |

### UpdateFinalPayoutCaseStatus

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `UpdateFinalPayoutCaseStatus(UpdateFinalPayoutCaseStatusRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `Body`
- **Returns**: `FinalPayoutCaseStatusResponse`
- **Error**: `ApiException<UpdateFinalPayoutCaseStatusError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorList(out ErrorList)` [400, 404, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `UpdateFinalPayoutCaseStatusRequest` | `src/WalmartApIs/Requests/FinalPayout/UpdateFinalPayoutCaseStatusRequest.cs` |
| `DisbursementsV4FinalPayoutCaseUpdateStatusRequest` | `src/WalmartApIs/Models/DisbursementsV4FinalPayoutCaseUpdateStatusRequest.cs` |
| `FinalPayoutCaseStatusResponse` | `src/WalmartApIs/Models/FinalPayoutCaseStatusResponse.cs` |
| `UpdateFinalPayoutCaseStatusError` | `src/WalmartApIs/Errors/UpdateFinalPayoutCaseStatusError.cs` |
| `ErrorList` | `src/WalmartApIs/Models/ErrorList.cs` |

