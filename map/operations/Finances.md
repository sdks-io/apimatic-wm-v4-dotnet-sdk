<!-- Generated file — do not edit; regenerated with the SDK. -->

# Finances — operations

Accessor: `client.Finances` · Source: `Api/Finances.cs` · 4 operations

**Type sources**: the file declaring each type an operation names (`RawError` excluded — see sdk-map.md).

### ListFinancialEventGroups

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `ListFinancialEventGroups(int? maxResultsPerPage, DateTimeOffset? financialEventGroupStartedBefore, DateTimeOffset? financialEventGroupStartedAfter, string? nextToken, RequestOptions? requestOptions = null, CancellationToken ct = default)`
  - 4 params (`maxResultsPerPage` … `nextToken`) — nullable, no default → **must pass explicitly** (pass `null` to skip)
- **Query params (wire ← C#)**: `MaxResultsPerPage` ← `maxResultsPerPage`, `FinancialEventGroupStartedBefore` ← `financialEventGroupStartedBefore`, `FinancialEventGroupStartedAfter` ← `financialEventGroupStartedAfter`, `NextToken` ← `nextToken`
- **Returns**: `object`
- **Error**: `SdkException<ListFinancialEventGroupsError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorList(out ErrorList)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `ListFinancialEventGroupsError` | `Errors/ListFinancialEventGroupsError.cs` |
| `ErrorList` | `Models/ErrorList.cs` |

### ListFinancialEvents

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `ListFinancialEvents(int? maxResultsPerPage, DateTimeOffset? postedAfter, DateTimeOffset? postedBefore, string? nextToken, RequestOptions? requestOptions = null, CancellationToken ct = default)`
  - 4 params (`maxResultsPerPage` … `nextToken`) — nullable, no default → **must pass explicitly** (pass `null` to skip)
- **Query params (wire ← C#)**: `MaxResultsPerPage` ← `maxResultsPerPage`, `PostedAfter` ← `postedAfter`, `PostedBefore` ← `postedBefore`, `NextToken` ← `nextToken`
- **Returns**: `object`
- **Error**: `SdkException<ListFinancialEventsError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorList(out ErrorList)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `ListFinancialEventsError` | `Errors/ListFinancialEventsError.cs` |
| `ErrorList` | `Models/ErrorList.cs` |

### ListFinancialEventsByGroupId

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `ListFinancialEventsByGroupId(string eventGroupId, int? maxResultsPerPage, DateTimeOffset? postedAfter, DateTimeOffset? postedBefore, string? nextToken, RequestOptions? requestOptions = null, CancellationToken ct = default)`
  - 4 params (`maxResultsPerPage` … `nextToken`) — nullable, no default → **must pass explicitly** (pass `null` to skip)
- **Query params (wire ← C#)**: `MaxResultsPerPage` ← `maxResultsPerPage`, `PostedAfter` ← `postedAfter`, `PostedBefore` ← `postedBefore`, `NextToken` ← `nextToken`
- **Returns**: `object`
- **Error**: `SdkException<ListFinancialEventsByGroupIdError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorList(out ErrorList)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `ListFinancialEventsByGroupIdError` | `Errors/ListFinancialEventsByGroupIdError.cs` |
| `ErrorList` | `Models/ErrorList.cs` |

### ListFinancialEventsByOrderId

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `ListFinancialEventsByOrderId(string orderId, int? maxResultsPerPage, string? nextToken, RequestOptions? requestOptions = null, CancellationToken ct = default)`
  - `maxResultsPerPage` — nullable, no default → **must pass explicitly**
  - `nextToken` — nullable, no default → **must pass explicitly**
- **Query params (wire ← C#)**: `MaxResultsPerPage` ← `maxResultsPerPage`, `NextToken` ← `nextToken`
- **Returns**: `object`
- **Error**: `SdkException<ListFinancialEventsByOrderIdError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorList(out ErrorList)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `ListFinancialEventsByOrderIdError` | `Errors/ListFinancialEventsByOrderIdError.cs` |
| `ErrorList` | `Models/ErrorList.cs` |

