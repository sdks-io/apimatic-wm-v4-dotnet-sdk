<!-- Generated file — do not edit; regenerated with the SDK. -->

# Reconciliation — operations

Accessor: `client.Reconciliation` · Source: `src/WalmartApIs/Api/Reconciliation.cs` · 3 operations

**Type sources**: the file declaring each type an operation names (`RawError` excluded — see sdk-map.md).

### CheckDownloadReportByPeriod

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `CheckDownloadReportByPeriod(CheckDownloadReportByPeriodRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `PartnerId`, `Date`
- **Query params (wire ← C#)**: `partnerId` ← `PartnerId`, `date` ← `Date`
- **Returns**: `ReportAvailabilityResponse`
- **Error**: `ApiException<CheckDownloadReportByPeriodError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorList(out ErrorList)` [400, 401, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `CheckDownloadReportByPeriodRequest` | `src/WalmartApIs/Requests/Reconciliation/CheckDownloadReportByPeriodRequest.cs` |
| `ReportAvailabilityResponse` | `src/WalmartApIs/Models/ReportAvailabilityResponse.cs` |
| `CheckDownloadReportByPeriodError` | `src/WalmartApIs/Errors/CheckDownloadReportByPeriodError.cs` |
| `ErrorList` | `src/WalmartApIs/Models/ErrorList.cs` |

### DownloadReconciliationReport

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `DownloadReconciliationReport(DownloadReconciliationReportRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `PartnerId`, `ReportDate`
- **Query params (wire ← C#)**: `partnerId` ← `PartnerId`, `reportDate` ← `ReportDate`
- **Returns**: `BinaryContent`
- **Error**: `ApiException<DownloadReconciliationReportError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorList(out ErrorList)` [400, 401, 404, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `DownloadReconciliationReportRequest` | `src/WalmartApIs/Requests/Reconciliation/DownloadReconciliationReportRequest.cs` |
| `DownloadReconciliationReportError` | `src/WalmartApIs/Errors/DownloadReconciliationReportError.cs` |
| `ErrorList` | `src/WalmartApIs/Models/ErrorList.cs` |

### ListReconciliationDates

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `ListReconciliationDates(ListReconciliationDatesRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `PartnerId`
- **Query params (wire ← C#)**: `partnerId` ← `PartnerId`
- **Returns**: `ReportAvailabilityResponse`
- **Error**: `ApiException<ListReconciliationDatesError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorList(out ErrorList)` [400, 401, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `ListReconciliationDatesRequest` | `src/WalmartApIs/Requests/Reconciliation/ListReconciliationDatesRequest.cs` |
| `ReportAvailabilityResponse` | `src/WalmartApIs/Models/ReportAvailabilityResponse.cs` |
| `ListReconciliationDatesError` | `src/WalmartApIs/Errors/ListReconciliationDatesError.cs` |
| `ErrorList` | `src/WalmartApIs/Models/ErrorList.cs` |

