<!-- Generated file — do not edit; regenerated with the SDK. -->

# DataKiosk — operations

Accessor: `client.DataKiosk` · Source: `Api/DataKiosk.cs` · 5 operations

**Type sources**: the file declaring each type an operation names (`RawError` excluded — see sdk-map.md).

### CancelQuery

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `CancelQuery(string queryId, RequestOptions? requestOptions = null, CancellationToken ct = default)`
- **Returns**: `CancelQueryResponse`
- **Error**: `SdkException<CancelQueryError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorList(out ErrorList)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `CancelQueryResponse` | `Models/CancelQueryResponse.cs` |
| `CancelQueryError` | `Errors/CancelQueryError.cs` |
| `ErrorList` | `Models/ErrorList.cs` |

### CreateQuery

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `CreateQuery(CreateQuerySpecification body, RequestOptions? requestOptions = null, CancellationToken ct = default)`
- **Returns**: `CreateQueryResponse`
- **Error**: `SdkException<CreateQueryError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorList(out ErrorList)` [400, 403, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `CreateQuerySpecification` | `Models/CreateQuerySpecification.cs` |
| `CreateQueryResponse` | `Models/CreateQueryResponse.cs` |
| `CreateQueryError` | `Errors/CreateQueryError.cs` |
| `ErrorList` | `Models/ErrorList.cs` |

### GetDocument

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `GetDocument(string documentId, RequestOptions? requestOptions = null, CancellationToken ct = default)`
- **Returns**: `Document`
- **Error**: `SdkException<GetDocumentError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorList(out ErrorList)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `Document` | `Models/Document.cs` |
| `GetDocumentError` | `Errors/GetDocumentError.cs` |
| `ErrorList` | `Models/ErrorList.cs` |

### GetQueries

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `GetQueries(IReadOnlyList<ProcessingStatus>? processingStatuses, DateTimeOffset? createdSince, DateTimeOffset? createdUntil, string? paginationToken, int? pageSize = 10, RequestOptions? requestOptions = null, CancellationToken ct = default)`
  - 4 params (`processingStatuses` … `paginationToken`) — nullable, no default → **must pass explicitly** (pass `null` to skip)
  - defaults: `pageSize` = `10`
- **Query params (wire ← C#)**: `processingStatuses` ← `processingStatuses`, `pageSize` ← `pageSize`, `createdSince` ← `createdSince`, `createdUntil` ← `createdUntil`, `paginationToken` ← `paginationToken`
- **Returns**: `GetQueriesResponse`
- **Error**: `SdkException<GetQueriesError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorList(out ErrorList)` [400, 403, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `ProcessingStatus` | `Models/Enums/ProcessingStatus.cs` |
| `GetQueriesResponse` | `Models/GetQueriesResponse.cs` |
| `GetQueriesError` | `Errors/GetQueriesError.cs` |
| `ErrorList` | `Models/ErrorList.cs` |

### GetQuery

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `GetQuery(string queryId, RequestOptions? requestOptions = null, CancellationToken ct = default)`
- **Returns**: `Query`
- **Error**: `SdkException<GetQueryError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorList(out ErrorList)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `Query` | `Models/Query.cs` |
| `GetQueryError` | `Errors/GetQueryError.cs` |
| `ErrorList` | `Models/ErrorList.cs` |

