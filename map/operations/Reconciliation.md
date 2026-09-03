<!-- Generated file — do not edit; regenerated with the SDK. -->

# Reconciliation — operations

Accessor: `client.Reconciliation` · Source: `Api/Reconciliation.cs` · 3 operations

**Type sources**: the file declaring each type an operation names (`RawError` excluded — see sdk-map.md).

### CheckDownloadReportByPeriod

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `CheckDownloadReportByPeriod(string partnerId, DateTimeOffset date, RequestOptions? requestOptions = null, CancellationToken ct = default)`
- **Query params (wire ← C#)**: `partnerId` ← `partnerId`, `date` ← `date`
- **Returns**: `ReportAvailabilityResponse`
- **Error**: `SdkException<CheckDownloadReportByPeriodError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorList(out ErrorList)` [400, 401, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `ReportAvailabilityResponse` | `Models/ReportAvailabilityResponse.cs` |
| `CheckDownloadReportByPeriodError` | `Errors/CheckDownloadReportByPeriodError.cs` |
| `ErrorList` | `Models/ErrorList.cs` |

### DownloadReconciliationReport

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `DownloadReconciliationReport(string partnerId, string reportDate, RequestOptions? requestOptions = null, CancellationToken ct = default)`
- **Query params (wire ← C#)**: `partnerId` ← `partnerId`, `reportDate` ← `reportDate`
- **Returns**: `BinaryContent`
- **Error**: `SdkException<DownloadReconciliationReportError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorList(out ErrorList)` [400, 401, 404, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `DownloadReconciliationReportError` | `Errors/DownloadReconciliationReportError.cs` |
| `ErrorList` | `Models/ErrorList.cs` |

### ListReconciliationDates

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `ListReconciliationDates(string partnerId, RequestOptions? requestOptions = null, CancellationToken ct = default)`
- **Query params (wire ← C#)**: `partnerId` ← `partnerId`
- **Returns**: `ReportAvailabilityResponse`
- **Error**: `SdkException<ListReconciliationDatesError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorList(out ErrorList)` [400, 401, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `ReportAvailabilityResponse` | `Models/ReportAvailabilityResponse.cs` |
| `ListReconciliationDatesError` | `Errors/ListReconciliationDatesError.cs` |
| `ErrorList` | `Models/ErrorList.cs` |

