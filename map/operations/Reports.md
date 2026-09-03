<!-- Generated file — do not edit; regenerated with the SDK. -->

# Reports — operations

Accessor: `client.Reports` · Source: `Api/Reports.cs` · 7 operations

**Type sources**: the file declaring each type an operation names (`RawError` excluded — see sdk-map.md).

### CancelReport

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `CancelReport(string reportId, RequestOptions? requestOptions = null, CancellationToken ct = default)`
- **Returns**: `CancelReportResponse`
- **Error**: `SdkException<CancelReportError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorList(out ErrorList)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `CancelReportResponse` | `Models/CancelReportResponse.cs` |
| `CancelReportError` | `Errors/CancelReportError.cs` |
| `ErrorList` | `Models/ErrorList.cs` |

### CreateReport

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `CreateReport(CreateReportSpecification body, RequestOptions? requestOptions = null, CancellationToken ct = default)`
- **Returns**: `CreateReportResponse`
- **Error**: `SdkException<CreateReportError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorList(out ErrorList)` [400, 403, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `CreateReportSpecification` | `Models/CreateReportSpecification.cs` |
| `CreateReportResponse` | `Models/CreateReportResponse.cs` |
| `CreateReportError` | `Errors/CreateReportError.cs` |
| `ErrorList` | `Models/ErrorList.cs` |

### DownloadNewReport

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `DownloadNewReport(string partnerId, string reportDate, RequestOptions? requestOptions = null, CancellationToken ct = default)`
- **Query params (wire ← C#)**: `partnerId` ← `partnerId`, `reportDate` ← `reportDate`
- **Returns**: `BinaryContent`
- **Error**: `SdkException<DownloadNewReportError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorList(out ErrorList)` [400, 404, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `DownloadNewReportError` | `Errors/DownloadNewReportError.cs` |
| `ErrorList` | `Models/ErrorList.cs` |

### DownloadOldReport

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `DownloadOldReport(string partnerId, string reportDate, RequestOptions? requestOptions = null, CancellationToken ct = default)`
- **Query params (wire ← C#)**: `partnerId` ← `partnerId`, `reportDate` ← `reportDate`
- **Returns**: `BinaryContent`
- **Error**: `SdkException<DownloadOldReportError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorList(out ErrorList)` [400, 404, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `DownloadOldReportError` | `Errors/DownloadOldReportError.cs` |
| `ErrorList` | `Models/ErrorList.cs` |

### GetReport

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `GetReport(string reportId, RequestOptions? requestOptions = null, CancellationToken ct = default)`
- **Returns**: `Report`
- **Error**: `SdkException<GetReportError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorList(out ErrorList)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `Report` | `Models/Report.cs` |
| `GetReportError` | `Errors/GetReportError.cs` |
| `ErrorList` | `Models/ErrorList.cs` |

### GetReportDocument

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `GetReportDocument(string reportDocumentId, RequestOptions? requestOptions = null, CancellationToken ct = default)`
- **Returns**: `ReportDocument`
- **Error**: `SdkException<GetReportDocumentError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorList(out ErrorList)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `ReportDocument` | `Models/ReportDocument.cs` |
| `GetReportDocumentError` | `Errors/GetReportDocumentError.cs` |
| `ErrorList` | `Models/ErrorList.cs` |

### GetReports

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `GetReports(IReadOnlyList<ReportType1>? reportTypes, IReadOnlyList<ProcessingStatus>? processingStatuses, DateTimeOffset? createdSince, DateTimeOffset? createdUntil, string? nextToken, int? pageSize = 10, RequestOptions? requestOptions = null, CancellationToken ct = default)`
  - 5 params (`reportTypes` … `nextToken`) — nullable, no default → **must pass explicitly** (pass `null` to skip)
  - defaults: `pageSize` = `10`
- **Query params (wire ← C#)**: `reportTypes` ← `reportTypes`, `processingStatuses` ← `processingStatuses`, `createdSince` ← `createdSince`, `createdUntil` ← `createdUntil`, `pageSize` ← `pageSize`, `nextToken` ← `nextToken`
- **Returns**: `GetReportsResponse`
- **Error**: `SdkException<GetReportsError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorList(out ErrorList)` [400, 403, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `ReportType1` | `Models/Enums/ReportType1.cs` |
| `ProcessingStatus` | `Models/Enums/ProcessingStatus.cs` |
| `GetReportsResponse` | `Models/GetReportsResponse.cs` |
| `GetReportsError` | `Errors/GetReportsError.cs` |
| `ErrorList` | `Models/ErrorList.cs` |

