<!-- Generated file — do not edit; regenerated with the SDK. -->

# Reports — operations

Accessor: `client.Reports` · Source: `src/WalmartApIs/Api/Reports.cs` · 7 operations

**Type sources**: the file declaring each type an operation names (`RawError` excluded — see sdk-map.md).

### CancelReport

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `CancelReport(CancelReportRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `ReportId`
- **Returns**: `CancelReportResponse`
- **Error**: `ApiException<CancelReportError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorList(out ErrorList)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `CancelReportRequest` | `src/WalmartApIs/Requests/Reports/CancelReportRequest.cs` |
| `CancelReportResponse` | `src/WalmartApIs/Models/CancelReportResponse.cs` |
| `CancelReportError` | `src/WalmartApIs/Errors/CancelReportError.cs` |
| `ErrorList` | `src/WalmartApIs/Models/ErrorList.cs` |

### CreateReport

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `CreateReport(CreateReportRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `Body`
- **Returns**: `CreateReportResponse`
- **Error**: `ApiException<CreateReportError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorList(out ErrorList)` [400, 403, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `CreateReportRequest` | `src/WalmartApIs/Requests/Reports/CreateReportRequest.cs` |
| `CreateReportSpecification` | `src/WalmartApIs/Models/CreateReportSpecification.cs` |
| `CreateReportResponse` | `src/WalmartApIs/Models/CreateReportResponse.cs` |
| `CreateReportError` | `src/WalmartApIs/Errors/CreateReportError.cs` |
| `ErrorList` | `src/WalmartApIs/Models/ErrorList.cs` |

### DownloadNewReport

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `DownloadNewReport(DownloadNewReportRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `PartnerId`, `ReportDate`
- **Query params (wire ← C#)**: `partnerId` ← `PartnerId`, `reportDate` ← `ReportDate`
- **Returns**: `BinaryContent`
- **Error**: `ApiException<DownloadNewReportError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorList(out ErrorList)` [400, 404, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `DownloadNewReportRequest` | `src/WalmartApIs/Requests/Reports/DownloadNewReportRequest.cs` |
| `DownloadNewReportError` | `src/WalmartApIs/Errors/DownloadNewReportError.cs` |
| `ErrorList` | `src/WalmartApIs/Models/ErrorList.cs` |

### DownloadOldReport

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `DownloadOldReport(DownloadOldReportRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `PartnerId`, `ReportDate`
- **Query params (wire ← C#)**: `partnerId` ← `PartnerId`, `reportDate` ← `ReportDate`
- **Returns**: `BinaryContent`
- **Error**: `ApiException<DownloadOldReportError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorList(out ErrorList)` [400, 404, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `DownloadOldReportRequest` | `src/WalmartApIs/Requests/Reports/DownloadOldReportRequest.cs` |
| `DownloadOldReportError` | `src/WalmartApIs/Errors/DownloadOldReportError.cs` |
| `ErrorList` | `src/WalmartApIs/Models/ErrorList.cs` |

### GetReport

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `GetReport(GetReportRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `ReportId`
- **Returns**: `Report`
- **Error**: `ApiException<GetReportError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorList(out ErrorList)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `GetReportRequest` | `src/WalmartApIs/Requests/Reports/GetReportRequest.cs` |
| `Report` | `src/WalmartApIs/Models/Report.cs` |
| `GetReportError` | `src/WalmartApIs/Errors/GetReportError.cs` |
| `ErrorList` | `src/WalmartApIs/Models/ErrorList.cs` |

### GetReportDocument

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `GetReportDocument(GetReportDocumentRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `ReportDocumentId`
- **Returns**: `ReportDocument`
- **Error**: `ApiException<GetReportDocumentError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorList(out ErrorList)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `GetReportDocumentRequest` | `src/WalmartApIs/Requests/Reports/GetReportDocumentRequest.cs` |
| `ReportDocument` | `src/WalmartApIs/Models/ReportDocument.cs` |
| `GetReportDocumentError` | `src/WalmartApIs/Errors/GetReportDocumentError.cs` |
| `ErrorList` | `src/WalmartApIs/Models/ErrorList.cs` |

### GetReports

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `GetReports(GetReportsRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
- **Query params (wire ← C#)**: `reportTypes` ← `ReportTypes`, `processingStatuses` ← `ProcessingStatuses`, `createdSince` ← `CreatedSince`, `createdUntil` ← `CreatedUntil`, `pageSize` ← `PageSize`, `nextToken` ← `NextToken`
- **Returns**: `GetReportsResponse`
- **Error**: `ApiException<GetReportsError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorList(out ErrorList)` [400, 403, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `GetReportsRequest` | `src/WalmartApIs/Requests/Reports/GetReportsRequest.cs` |
| `ReportType1` | `src/WalmartApIs/Models/Enums/ReportType1.cs` |
| `ProcessingStatus` | `src/WalmartApIs/Models/Enums/ProcessingStatus.cs` |
| `GetReportsResponse` | `src/WalmartApIs/Models/GetReportsResponse.cs` |
| `GetReportsError` | `src/WalmartApIs/Errors/GetReportsError.cs` |
| `ErrorList` | `src/WalmartApIs/Models/ErrorList.cs` |

