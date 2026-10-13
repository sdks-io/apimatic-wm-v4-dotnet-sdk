<!-- Generated file — do not edit; regenerated with the SDK. -->

# Settlement — operations

Accessor: `client.Settlement` · Source: `src/WalmartApIs/Api/Settlement.cs` · 3 operations

**Type sources**: the file declaring each type an operation names (`RawError` excluded — see sdk-map.md).

### ListSettlementDetails

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `ListSettlementDetails(ListSettlementDetailsRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `PartnerId`, `ReportDate`
- **Query params (wire ← C#)**: `partnerId` ← `PartnerId`, `reportDate` ← `ReportDate`, `pageSize` ← `PageSize`, `nextToken` ← `NextToken`
- **Returns**: `SettlementDetailsResponse`
- **Error**: `ApiException<ListSettlementDetailsError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorList(out ErrorList)` [400, 401, 403, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `ListSettlementDetailsRequest` | `src/WalmartApIs/Requests/Settlement/ListSettlementDetailsRequest.cs` |
| `SettlementDetailsResponse` | `src/WalmartApIs/Models/SettlementDetailsResponse.cs` |
| `ListSettlementDetailsError` | `src/WalmartApIs/Errors/ListSettlementDetailsError.cs` |
| `ErrorList` | `src/WalmartApIs/Models/ErrorList.cs` |

### ListSettlementPeriods

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `ListSettlementPeriods(ListSettlementPeriodsRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
- **Query params (wire ← C#)**: `pageSize` ← `PageSize`, `nextToken` ← `NextToken`
- **Returns**: `SettlementPeriodsResponse`
- **Error**: `ApiException<ListSettlementPeriodsError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorList(out ErrorList)` [400, 401, 403, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `ListSettlementPeriodsRequest` | `src/WalmartApIs/Requests/Settlement/ListSettlementPeriodsRequest.cs` |
| `SettlementPeriodsResponse` | `src/WalmartApIs/Models/SettlementPeriodsResponse.cs` |
| `ListSettlementPeriodsError` | `src/WalmartApIs/Errors/ListSettlementPeriodsError.cs` |
| `ErrorList` | `src/WalmartApIs/Models/ErrorList.cs` |

### SearchTransactions

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `SearchTransactions(SearchTransactionsRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
- **Query params (wire ← C#)**: `pageSize` ← `PageSize`, `nextToken` ← `NextToken`, `postedAfter` ← `PostedAfter`, `postedBefore` ← `PostedBefore`
- **Returns**: `TransactionSearchResponse`
- **Error**: `ApiException<SearchTransactionsError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorList(out ErrorList)` [400, 401, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `SearchTransactionsRequest` | `src/WalmartApIs/Requests/Settlement/SearchTransactionsRequest.cs` |
| `TransactionSearchResponse` | `src/WalmartApIs/Models/TransactionSearchResponse.cs` |
| `SearchTransactionsError` | `src/WalmartApIs/Errors/SearchTransactionsError.cs` |
| `ErrorList` | `src/WalmartApIs/Models/ErrorList.cs` |

