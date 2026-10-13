<!-- Generated file — do not edit; regenerated with the SDK. -->

# ReportSchedules — operations

Accessor: `client.ReportSchedules` · Source: `src/WalmartApIs/Api/ReportSchedules.cs` · 4 operations

**Type sources**: the file declaring each type an operation names (`RawError` excluded — see sdk-map.md).

### CancelReportSchedule

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `CancelReportSchedule(CancelReportScheduleRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `ReportScheduleId`
- **Returns**: `CancelReportScheduleResponse`
- **Error**: `ApiException<CancelReportScheduleError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorList(out ErrorList)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `CancelReportScheduleRequest` | `src/WalmartApIs/Requests/ReportSchedules/CancelReportScheduleRequest.cs` |
| `CancelReportScheduleResponse` | `src/WalmartApIs/Models/CancelReportScheduleResponse.cs` |
| `CancelReportScheduleError` | `src/WalmartApIs/Errors/CancelReportScheduleError.cs` |
| `ErrorList` | `src/WalmartApIs/Models/ErrorList.cs` |

### CreateReportSchedule

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `CreateReportSchedule(CreateReportScheduleRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `Body`
- **Returns**: `CreateReportScheduleResponse`
- **Error**: `ApiException<CreateReportScheduleError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorList(out ErrorList)` [400, 403, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `CreateReportScheduleRequest` | `src/WalmartApIs/Requests/ReportSchedules/CreateReportScheduleRequest.cs` |
| `CreateReportScheduleSpecification` | `src/WalmartApIs/Models/CreateReportScheduleSpecification.cs` |
| `CreateReportScheduleResponse` | `src/WalmartApIs/Models/CreateReportScheduleResponse.cs` |
| `CreateReportScheduleError` | `src/WalmartApIs/Errors/CreateReportScheduleError.cs` |
| `ErrorList` | `src/WalmartApIs/Models/ErrorList.cs` |

### GetReportSchedule

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `GetReportSchedule(GetReportScheduleRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `ReportScheduleId`
- **Returns**: `ReportSchedule`
- **Error**: `ApiException<GetReportScheduleError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorList(out ErrorList)` [400, 403, 404, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `GetReportScheduleRequest` | `src/WalmartApIs/Requests/ReportSchedules/GetReportScheduleRequest.cs` |
| `ReportSchedule` | `src/WalmartApIs/Models/ReportSchedule.cs` |
| `GetReportScheduleError` | `src/WalmartApIs/Errors/GetReportScheduleError.cs` |
| `ErrorList` | `src/WalmartApIs/Models/ErrorList.cs` |

### GetReportSchedules

- **Server group**: `Default1`
- **Auth**: `options.WalletAuth`
- **Signature**: `GetReportSchedules(GetReportSchedulesRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
- **Query params (wire ← C#)**: `reportTypes` ← `ReportTypes`
- **Returns**: `GetReportSchedulesResponse`
- **Error**: `ApiException<GetReportSchedulesError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorList(out ErrorList)` [400, 403, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `GetReportSchedulesRequest` | `src/WalmartApIs/Requests/ReportSchedules/GetReportSchedulesRequest.cs` |
| `ReportType1` | `src/WalmartApIs/Models/Enums/ReportType1.cs` |
| `GetReportSchedulesResponse` | `src/WalmartApIs/Models/GetReportSchedulesResponse.cs` |
| `GetReportSchedulesError` | `src/WalmartApIs/Errors/GetReportSchedulesError.cs` |
| `ErrorList` | `src/WalmartApIs/Models/ErrorList.cs` |

