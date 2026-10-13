<!-- Generated file — do not edit; regenerated with the SDK. -->

# Disputes — operations

Accessor: `client.Disputes` · Source: `src/WalmartApIs/Api/Disputes.cs` · 1 operation

**Type sources**: the file declaring each type an operation names (`RawError` excluded — see sdk-map.md).

### CheckDisputeEligibility

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `CheckDisputeEligibility(RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
- **Returns**: `DisputeEligibilityResponse`
- **Error**: `ApiException<CheckDisputeEligibilityError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorList(out ErrorList)` [400, 401, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `DisputeEligibilityResponse` | `src/WalmartApIs/Models/DisputeEligibilityResponse.cs` |
| `CheckDisputeEligibilityError` | `src/WalmartApIs/Errors/CheckDisputeEligibilityError.cs` |
| `ErrorList` | `src/WalmartApIs/Models/ErrorList.cs` |

