<!-- Generated file — do not edit; regenerated with the SDK. -->

# Finances — operations

Accessor: `client.Finances` · Source: `src/WalmartApIs/Api/Finances.cs` · 4 operations

**Type sources**: the file declaring each type an operation names (`RawError` excluded — see sdk-map.md).

### ListFinancialEventGroups

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `ListFinancialEventGroups(ListFinancialEventGroupsRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
- **Query params (wire ← C#)**: `MaxResultsPerPage` ← `MaxResultsPerPage`, `FinancialEventGroupStartedBefore` ← `FinancialEventGroupStartedBefore`, `FinancialEventGroupStartedAfter` ← `FinancialEventGroupStartedAfter`, `NextToken` ← `NextToken`
- **Returns**: `object`
- **Error**: `ApiException<ListFinancialEventGroupsError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorList(out ErrorList)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `ListFinancialEventGroupsRequest` | `src/WalmartApIs/Requests/Finances/ListFinancialEventGroupsRequest.cs` |
| `ListFinancialEventGroupsError` | `src/WalmartApIs/Errors/ListFinancialEventGroupsError.cs` |
| `ErrorList` | `src/WalmartApIs/Models/ErrorList.cs` |

### ListFinancialEvents

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `ListFinancialEvents(ListFinancialEventsRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
- **Query params (wire ← C#)**: `MaxResultsPerPage` ← `MaxResultsPerPage`, `PostedAfter` ← `PostedAfter`, `PostedBefore` ← `PostedBefore`, `NextToken` ← `NextToken`
- **Returns**: `object`
- **Error**: `ApiException<ListFinancialEventsError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorList(out ErrorList)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `ListFinancialEventsRequest` | `src/WalmartApIs/Requests/Finances/ListFinancialEventsRequest.cs` |
| `ListFinancialEventsError` | `src/WalmartApIs/Errors/ListFinancialEventsError.cs` |
| `ErrorList` | `src/WalmartApIs/Models/ErrorList.cs` |

### ListFinancialEventsByGroupId

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `ListFinancialEventsByGroupId(ListFinancialEventsByGroupIdRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `EventGroupId`
- **Query params (wire ← C#)**: `MaxResultsPerPage` ← `MaxResultsPerPage`, `PostedAfter` ← `PostedAfter`, `PostedBefore` ← `PostedBefore`, `NextToken` ← `NextToken`
- **Returns**: `object`
- **Error**: `ApiException<ListFinancialEventsByGroupIdError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorList(out ErrorList)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `ListFinancialEventsByGroupIdRequest` | `src/WalmartApIs/Requests/Finances/ListFinancialEventsByGroupIdRequest.cs` |
| `ListFinancialEventsByGroupIdError` | `src/WalmartApIs/Errors/ListFinancialEventsByGroupIdError.cs` |
| `ErrorList` | `src/WalmartApIs/Models/ErrorList.cs` |

### ListFinancialEventsByOrderId

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `ListFinancialEventsByOrderId(ListFinancialEventsByOrderIdRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `OrderId`
- **Query params (wire ← C#)**: `MaxResultsPerPage` ← `MaxResultsPerPage`, `NextToken` ← `NextToken`
- **Returns**: `object`
- **Error**: `ApiException<ListFinancialEventsByOrderIdError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorList(out ErrorList)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `ListFinancialEventsByOrderIdRequest` | `src/WalmartApIs/Requests/Finances/ListFinancialEventsByOrderIdRequest.cs` |
| `ListFinancialEventsByOrderIdError` | `src/WalmartApIs/Errors/ListFinancialEventsByOrderIdError.cs` |
| `ErrorList` | `src/WalmartApIs/Models/ErrorList.cs` |

