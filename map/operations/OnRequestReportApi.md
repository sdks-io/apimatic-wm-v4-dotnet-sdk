<!-- Generated file — do not edit; regenerated with the SDK. -->

# OnRequestReportApi — operations

Accessor: `client.OnRequestReportApi` · Source: `src/WalmartApIs/Api/OnRequestReportApi.cs` · 3 operations

**Type sources**: the file declaring each type an operation names (`RawError` excluded — see sdk-map.md).

### DownloadReport

- **Auth**: `options.AccessToken`
- **Signature**: `DownloadReport(DownloadReportRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `RequestId`, `WmQosCorrelationId`, `WmSvcName`, `WmMarket`, `WmGlobalVersion`, `Accept`
- **Query params (wire ← C#)**: `requestId` ← `RequestId`
- **Returns**: `DownloadReportResponse`
- **Error**: `ApiException<RawError>` — **Case B**

| Type | Source |
| --- | --- |
| `DownloadReportRequest` | `src/WalmartApIs/Requests/OnRequestReportApi/DownloadReportRequest.cs` |
| `WmMarket1` | `src/WalmartApIs/Models/Enums/WmMarket1.cs` |
| `WmGlobalVersion` | `src/WalmartApIs/Models/Enums/WmGlobalVersion.cs` |
| `DownloadReportResponse` | `src/WalmartApIs/Models/DownloadReportResponse.cs` |

### GetRequestsStatus

- **Auth**: `options.AccessToken`
- **Signature**: `GetRequestsStatus(GetRequestsStatusRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `ReportType`, `WmQosCorrelationId`, `WmSvcName`, `WmMarket`, `WmGlobalVersion`, `Accept`
- **Query params (wire ← C#)**: `reportType` ← `ReportType`, `reportVersion` ← `ReportVersion`, `requestStatus` ← `RequestStatus`, `requestSubmissionStartDate` ← `RequestSubmissionStartDate`, `requestSubmissionEndDate` ← `RequestSubmissionEndDate`
- **Returns**: `RequestsStatusResponse`
- **Error**: `ApiException<RawError>` — **Case B**

| Type | Source |
| --- | --- |
| `GetRequestsStatusRequest` | `src/WalmartApIs/Requests/OnRequestReportApi/GetRequestsStatusRequest.cs` |
| `ReportType4` | `src/WalmartApIs/Models/Enums/ReportType4.cs` |
| `RequestStatus4` | `src/WalmartApIs/Models/Enums/RequestStatus4.cs` |
| `WmMarket1` | `src/WalmartApIs/Models/Enums/WmMarket1.cs` |
| `WmGlobalVersion` | `src/WalmartApIs/Models/Enums/WmGlobalVersion.cs` |
| `RequestsStatusResponse` | `src/WalmartApIs/Models/RequestsStatusResponse.cs` |

### GetSingleRequestStatus

- **Auth**: `options.AccessToken`
- **Signature**: `GetSingleRequestStatus(GetSingleRequestStatusRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `RequestId`, `WmQosCorrelationId`, `WmSvcName`, `WmMarket`, `WmGlobalVersion`, `Accept`
- **Returns**: `RequestStatusResponse`
- **Error**: `ApiException<RawError>` — **Case B**

| Type | Source |
| --- | --- |
| `GetSingleRequestStatusRequest` | `src/WalmartApIs/Requests/OnRequestReportApi/GetSingleRequestStatusRequest.cs` |
| `WmMarket1` | `src/WalmartApIs/Models/Enums/WmMarket1.cs` |
| `WmGlobalVersion` | `src/WalmartApIs/Models/Enums/WmGlobalVersion.cs` |
| `RequestStatusResponse` | `src/WalmartApIs/Models/RequestStatusResponse.cs` |

