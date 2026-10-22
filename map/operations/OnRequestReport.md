<!-- Generated file — do not edit; regenerated with the SDK. -->

# OnRequestReport — operations

Accessor: `client.OnRequestReport` · Source: `src/WalmartApIs/Api/OnRequestReport.cs` · 1 operation

**Type sources**: the file declaring each type an operation names (`RawError` excluded — see sdk-map.md).

### GenerateReport

- **Auth**: `options.AccessToken`
- **Signature**: `GenerateReport(GenerateReportRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `ReportType`, `ReportVersion`, `WmSecAccessToken`, `WmQosCorrelationId`, `WmSvcName`, `WmMarket`, `WmGlobalVersion`, `Accept`
- **Query params (wire ← C#)**: `reportType` ← `ReportType`, `reportVersion` ← `ReportVersion`
- **Returns**: `V3ReportsReportRequestsResponse1`
- **Error**: `ApiException<GenerateReportError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent(out RawError)` [400] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `GenerateReportRequest` | `src/WalmartApIs/Requests/OnRequestReport/GenerateReportRequest.cs` |
| `ReportType4` | `src/WalmartApIs/Models/Enums/ReportType4.cs` |
| `WmMarket1` | `src/WalmartApIs/Models/Enums/WmMarket1.cs` |
| `WmGlobalVersion` | `src/WalmartApIs/Models/Enums/WmGlobalVersion.cs` |
| `V3ReportsReportRequestsRequest` | `src/WalmartApIs/Models/V3ReportsReportRequestsRequest.cs` |
| `V3ReportsReportRequestsResponse1` | `src/WalmartApIs/Models/V3ReportsReportRequestsResponse1.cs` |
| `GenerateReportError` | `src/WalmartApIs/Errors/GenerateReportError.cs` |

