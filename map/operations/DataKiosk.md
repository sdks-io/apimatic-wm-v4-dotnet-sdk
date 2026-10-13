<!-- Generated file — do not edit; regenerated with the SDK. -->

# DataKiosk — operations

Accessor: `client.DataKiosk` · Source: `src/WalmartApIs/Api/DataKiosk.cs` · 5 operations

**Type sources**: the file declaring each type an operation names (`RawError` excluded — see sdk-map.md).

### CancelQuery

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `CancelQuery(CancelQueryRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `QueryId`
- **Returns**: `CancelQueryResponse`
- **Error**: `ApiException<CancelQueryError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorList(out ErrorList)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `CancelQueryRequest` | `src/WalmartApIs/Requests/DataKiosk/CancelQueryRequest.cs` |
| `CancelQueryResponse` | `src/WalmartApIs/Models/CancelQueryResponse.cs` |
| `CancelQueryError` | `src/WalmartApIs/Errors/CancelQueryError.cs` |
| `ErrorList` | `src/WalmartApIs/Models/ErrorList.cs` |

### CreateQuery

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `CreateQuery(CreateQueryRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `Body`
- **Returns**: `CreateQueryResponse`
- **Error**: `ApiException<CreateQueryError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorList(out ErrorList)` [400, 403, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `CreateQueryRequest` | `src/WalmartApIs/Requests/DataKiosk/CreateQueryRequest.cs` |
| `CreateQuerySpecification` | `src/WalmartApIs/Models/CreateQuerySpecification.cs` |
| `CreateQueryResponse` | `src/WalmartApIs/Models/CreateQueryResponse.cs` |
| `CreateQueryError` | `src/WalmartApIs/Errors/CreateQueryError.cs` |
| `ErrorList` | `src/WalmartApIs/Models/ErrorList.cs` |

### GetDocument

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `GetDocument(GetDocumentRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `DocumentId`
- **Returns**: `Document`
- **Error**: `ApiException<GetDocumentError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorList(out ErrorList)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `GetDocumentRequest` | `src/WalmartApIs/Requests/DataKiosk/GetDocumentRequest.cs` |
| `Document` | `src/WalmartApIs/Models/Document.cs` |
| `GetDocumentError` | `src/WalmartApIs/Errors/GetDocumentError.cs` |
| `ErrorList` | `src/WalmartApIs/Models/ErrorList.cs` |

### GetQueries

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `GetQueries(GetQueriesRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
- **Query params (wire ← C#)**: `processingStatuses` ← `ProcessingStatuses`, `pageSize` ← `PageSize`, `createdSince` ← `CreatedSince`, `createdUntil` ← `CreatedUntil`, `paginationToken` ← `PaginationToken`
- **Returns**: `GetQueriesResponse`
- **Error**: `ApiException<GetQueriesError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorList(out ErrorList)` [400, 403, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `GetQueriesRequest` | `src/WalmartApIs/Requests/DataKiosk/GetQueriesRequest.cs` |
| `ProcessingStatus` | `src/WalmartApIs/Models/Enums/ProcessingStatus.cs` |
| `GetQueriesResponse` | `src/WalmartApIs/Models/GetQueriesResponse.cs` |
| `GetQueriesError` | `src/WalmartApIs/Errors/GetQueriesError.cs` |
| `ErrorList` | `src/WalmartApIs/Models/ErrorList.cs` |

### GetQuery

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `GetQuery(GetQueryRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `QueryId`
- **Returns**: `Query`
- **Error**: `ApiException<GetQueryError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorList(out ErrorList)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `GetQueryRequest` | `src/WalmartApIs/Requests/DataKiosk/GetQueryRequest.cs` |
| `Query` | `src/WalmartApIs/Models/Query.cs` |
| `GetQueryError` | `src/WalmartApIs/Errors/GetQueryError.cs` |
| `ErrorList` | `src/WalmartApIs/Models/ErrorList.cs` |

