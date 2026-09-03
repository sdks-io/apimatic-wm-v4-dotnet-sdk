<!-- Generated file — do not edit; regenerated with the SDK. -->

# ReportSchedules — operations

Accessor: `client.ReportSchedules` · Source: `Api/ReportSchedules.cs` · 4 operations

**Type sources**: the file declaring each type an operation names (`RawError` excluded — see sdk-map.md).

### CancelReportSchedule

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `CancelReportSchedule(string reportScheduleId, RequestOptions? requestOptions = null, CancellationToken ct = default)`
- **Returns**: `CancelReportScheduleResponse`
- **Error**: `SdkException<CancelReportScheduleError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorList(out ErrorList)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `CancelReportScheduleResponse` | `Models/CancelReportScheduleResponse.cs` |
| `CancelReportScheduleError` | `Errors/CancelReportScheduleError.cs` |
| `ErrorList` | `Models/ErrorList.cs` |

### CreateReportSchedule

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `CreateReportSchedule(CreateReportScheduleSpecification body, RequestOptions? requestOptions = null, CancellationToken ct = default)`
- **Returns**: `CreateReportScheduleResponse`
- **Error**: `SdkException<CreateReportScheduleError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorList(out ErrorList)` [400, 403, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `CreateReportScheduleSpecification` | `Models/CreateReportScheduleSpecification.cs` |
| `CreateReportScheduleResponse` | `Models/CreateReportScheduleResponse.cs` |
| `CreateReportScheduleError` | `Errors/CreateReportScheduleError.cs` |
| `ErrorList` | `Models/ErrorList.cs` |

### GetReportSchedule

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `GetReportSchedule(string reportScheduleId, RequestOptions? requestOptions = null, CancellationToken ct = default)`
- **Returns**: `ReportSchedule`
- **Error**: `SdkException<GetReportScheduleError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorList(out ErrorList)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `ReportSchedule` | `Models/ReportSchedule.cs` |
| `GetReportScheduleError` | `Errors/GetReportScheduleError.cs` |
| `ErrorList` | `Models/ErrorList.cs` |

### GetReportSchedules

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `GetReportSchedules(IReadOnlyList<ReportType1>? reportTypes, RequestOptions? requestOptions = null, CancellationToken ct = default)`
  - `reportTypes` — nullable, no default → **must pass explicitly**
- **Query params (wire ← C#)**: `reportTypes` ← `reportTypes`
- **Returns**: `GetReportSchedulesResponse`
- **Error**: `SdkException<GetReportSchedulesError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorList(out ErrorList)` [400, 403, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `ReportType1` | `Models/Enums/ReportType1.cs` |
| `GetReportSchedulesResponse` | `Models/GetReportSchedulesResponse.cs` |
| `GetReportSchedulesError` | `Errors/GetReportSchedulesError.cs` |
| `ErrorList` | `Models/ErrorList.cs` |

