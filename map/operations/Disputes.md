<!-- Generated file — do not edit; regenerated with the SDK. -->

# Disputes — operations

Accessor: `client.Disputes` · Source: `Api/Disputes.cs` · 1 operation

**Type sources**: the file declaring each type an operation names (`RawError` excluded — see sdk-map.md).

### CheckDisputeEligibility

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `CheckDisputeEligibility(RequestOptions? requestOptions = null, CancellationToken ct = default)`
- **Returns**: `DisputeEligibilityResponse`
- **Error**: `SdkException<CheckDisputeEligibilityError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorList(out ErrorList)` [400, 401, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `DisputeEligibilityResponse` | `Models/DisputeEligibilityResponse.cs` |
| `CheckDisputeEligibilityError` | `Errors/CheckDisputeEligibilityError.cs` |
| `ErrorList` | `Models/ErrorList.cs` |

