<!-- Generated file — do not edit; regenerated with the SDK. -->

# ReportScheduler — operations

Accessor: `client.ReportScheduler` · Source: `src/WalmartApIs/Api/ReportScheduler.cs` · 4 operations

**Type sources**: the file declaring each type an operation names (`RawError` excluded — see sdk-map.md).

### DeleteReportSchedule

- **Auth**: `options.AccessToken`
- **Signature**: `DeleteReportSchedule(DeleteReportScheduleRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `ScheduleId`, `WmSvcName`, `WmQosCorrelationId`, `WmSecAccessToken`
- **Returns**: `RejectRecommendationsResponsePayload`
- **Error**: `ApiException<RawError>` — **Case B**

| Type | Source |
| --- | --- |
| `DeleteReportScheduleRequest` | `src/WalmartApIs/Requests/ReportScheduler/DeleteReportScheduleRequest.cs` |
| `RejectRecommendationsResponsePayload` | `src/WalmartApIs/Models/RejectRecommendationsResponsePayload.cs` |

### GetAllReportSchedules

- **Auth**: `options.AccessToken`
- **Signature**: `GetAllReportSchedules(GetAllReportSchedulesRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `ReportType`, `WmSvcName`, `WmQosCorrelationId`, `WmSecAccessToken`
- **Query params (wire ← C#)**: `reportType` ← `ReportType`
- **Returns**: `V3ReportsSchedulesResponse`
- **Error**: `ApiException<RawError>` — **Case B**

| Type | Source |
| --- | --- |
| `GetAllReportSchedulesRequest` | `src/WalmartApIs/Requests/ReportScheduler/GetAllReportSchedulesRequest.cs` |
| `ReportType10` | `src/WalmartApIs/Models/Enums/ReportType10.cs` |
| `V3ReportsSchedulesResponse` | `src/WalmartApIs/Models/V3ReportsSchedulesResponse.cs` |

### GetReportSchedule

- **Auth**: `options.AccessToken`
- **Signature**: `GetReportSchedule(GetReportScheduleRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `ScheduleId`, `WmSvcName`, `WmQosCorrelationId`, `WmSecAccessToken`
- **Returns**: `V3ReportsSchedulesResponse1`
- **Error**: `ApiException<RawError>` — **Case B**

| Type | Source |
| --- | --- |
| `GetReportScheduleRequest` | `src/WalmartApIs/Requests/ReportScheduler/GetReportScheduleRequest.cs` |
| `V3ReportsSchedulesResponse1` | `src/WalmartApIs/Models/V3ReportsSchedulesResponse1.cs` |

### UpdateReportSchedule

- **Auth**: `options.AccessToken`
- **Signature**: `UpdateReportSchedule(UpdateReportScheduleRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `ScheduleId`, `WmSvcName`, `WmQosCorrelationId`, `WmSecAccessToken`
- **Returns**: `V3ReportsSchedulesResponse1`
- **Error**: `ApiException<RawError>` — **Case B**

| Type | Source |
| --- | --- |
| `UpdateReportScheduleRequest` | `src/WalmartApIs/Requests/ReportScheduler/UpdateReportScheduleRequest.cs` |
| `V3ReportsSchedulesRequest` | `src/WalmartApIs/Models/V3ReportsSchedulesRequest.cs` |
| `V3ReportsSchedulesResponse1` | `src/WalmartApIs/Models/V3ReportsSchedulesResponse1.cs` |

