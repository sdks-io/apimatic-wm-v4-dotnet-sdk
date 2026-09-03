<!-- Generated file — do not edit; regenerated with the SDK. -->

# Settlement — operations

Accessor: `client.Settlement` · Source: `Api/Settlement.cs` · 3 operations

**Type sources**: the file declaring each type an operation names (`RawError` excluded — see sdk-map.md).

### ListSettlementDetails

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `ListSettlementDetails(string partnerId, string reportDate, string? nextToken, int? pageSize = 10, RequestOptions? requestOptions = null, CancellationToken ct = default)`
  - `nextToken` — nullable, no default → **must pass explicitly**
  - defaults: `pageSize` = `10`
- **Query params (wire ← C#)**: `partnerId` ← `partnerId`, `reportDate` ← `reportDate`, `pageSize` ← `pageSize`, `nextToken` ← `nextToken`
- **Returns**: `SettlementDetailsResponse`
- **Error**: `SdkException<ListSettlementDetailsError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorList(out ErrorList)` [400, 401, 403, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `SettlementDetailsResponse` | `Models/SettlementDetailsResponse.cs` |
| `ListSettlementDetailsError` | `Errors/ListSettlementDetailsError.cs` |
| `ErrorList` | `Models/ErrorList.cs` |

### ListSettlementPeriods

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `ListSettlementPeriods(string? nextToken, int? pageSize = 10, RequestOptions? requestOptions = null, CancellationToken ct = default)`
  - `nextToken` — nullable, no default → **must pass explicitly**
  - defaults: `pageSize` = `10`
- **Query params (wire ← C#)**: `pageSize` ← `pageSize`, `nextToken` ← `nextToken`
- **Returns**: `SettlementPeriodsResponse`
- **Error**: `SdkException<ListSettlementPeriodsError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorList(out ErrorList)` [400, 401, 403, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `SettlementPeriodsResponse` | `Models/SettlementPeriodsResponse.cs` |
| `ListSettlementPeriodsError` | `Errors/ListSettlementPeriodsError.cs` |
| `ErrorList` | `Models/ErrorList.cs` |

### SearchTransactions

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `SearchTransactions(string? nextToken, DateTimeOffset? postedAfter, DateTimeOffset? postedBefore, int? pageSize = 10, RequestOptions? requestOptions = null, CancellationToken ct = default)`
  - `nextToken` — nullable, no default → **must pass explicitly**
  - `postedAfter` — nullable, no default → **must pass explicitly**
  - `postedBefore` — nullable, no default → **must pass explicitly**
  - defaults: `pageSize` = `10`
- **Query params (wire ← C#)**: `pageSize` ← `pageSize`, `nextToken` ← `nextToken`, `postedAfter` ← `postedAfter`, `postedBefore` ← `postedBefore`
- **Returns**: `TransactionSearchResponse`
- **Error**: `SdkException<SearchTransactionsError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorList(out ErrorList)` [400, 401, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `TransactionSearchResponse` | `Models/TransactionSearchResponse.cs` |
| `SearchTransactionsError` | `Errors/SearchTransactionsError.cs` |
| `ErrorList` | `Models/ErrorList.cs` |

