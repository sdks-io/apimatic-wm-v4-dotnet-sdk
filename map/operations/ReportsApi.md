<!-- Generated file — do not edit; regenerated with the SDK. -->

# ReportsApi — operations

Accessor: `client.ReportsApi` · Source: `src/WalmartApIs/Api/ReportsApi.cs` · 7 operations

**Type sources**: the file declaring each type an operation names (`RawError` excluded — see sdk-map.md).

### GetAvailableReconReportDates

- **Auth**: `options.AccessToken`
- **Signature**: `GetAvailableReconReportDates(GetAvailableReconReportDatesRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `WmSecAccessToken`, `WmQosCorrelationId`, `WmSvcName`
- **Returns**: `ReconReportDateResponse`
- **Error**: `ApiException<RawError>` — **Case B**

| Type | Source |
| --- | --- |
| `GetAvailableReconReportDatesRequest` | `src/WalmartApIs/Requests/ReportsApi/GetAvailableReconReportDatesRequest.cs` |
| `ReconReportDateResponse` | `src/WalmartApIs/Models/ReconReportDateResponse.cs` |

### GetAvailableV1ReconReportAsJson

- **Auth**: `options.AccessToken`
- **Signature**: `GetAvailableV1ReconReportAsJson(GetAvailableV1ReconReportAsJsonRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `ReportDate`, `Offset`, `NoOfRecords`, `WmSecAccessToken`, `WmQosCorrelationId`, `WmSvcName`
- **Query params (wire ← C#)**: `reportDate` ← `ReportDate`, `offset` ← `Offset`, `noOfRecords` ← `NoOfRecords`
- **Returns**: `ReconReportV1AsJsonResponse`
- **Error**: `ApiException<RawError>` — **Case B**

| Type | Source |
| --- | --- |
| `GetAvailableV1ReconReportAsJsonRequest` | `src/WalmartApIs/Requests/ReportsApi/GetAvailableV1ReconReportAsJsonRequest.cs` |
| `ReconReportV1AsJsonResponse` | `src/WalmartApIs/Models/ReconReportV1AsJsonResponse.cs` |

### GetAvailableV1ReconReportDates

- **Auth**: `options.AccessToken`
- **Signature**: `GetAvailableV1ReconReportDates(GetAvailableV1ReconReportDatesRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `WmSecAccessToken`, `WmQosCorrelationId`, `WmSvcName`
- **Returns**: `ReconReportDateResponse`
- **Error**: `ApiException<RawError>` — **Case B**

| Type | Source |
| --- | --- |
| `GetAvailableV1ReconReportDatesRequest` | `src/WalmartApIs/Requests/ReportsApi/GetAvailableV1ReconReportDatesRequest.cs` |
| `ReconReportDateResponse` | `src/WalmartApIs/Models/ReconReportDateResponse.cs` |

### GetPartnerPerformance

- **Auth**: `options.AccessToken`
- **Signature**: `GetPartnerPerformance(GetPartnerPerformanceRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `WmSecAccessToken`, `WmQosCorrelationId`, `WmSvcName`
- **Returns**: `PartnerProgramPerformanceRes`
- **Error**: `ApiException<RawError>` — **Case B**

| Type | Source |
| --- | --- |
| `GetPartnerPerformanceRequest` | `src/WalmartApIs/Requests/ReportsApi/GetPartnerPerformanceRequest.cs` |
| `PartnerProgramPerformanceRes` | `src/WalmartApIs/Models/PartnerProgramPerformanceRes.cs` |

### GetPartnerStatement

- **Auth**: `options.AccessToken`
- **Signature**: `GetPartnerStatement(GetPartnerStatementRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `WmSecAccessToken`, `WmQosCorrelationId`, `WmSvcName`
- **Returns**: `PartnerProgramStatementRes`
- **Error**: `ApiException<RawError>` — **Case B**

| Type | Source |
| --- | --- |
| `GetPartnerStatementRequest` | `src/WalmartApIs/Requests/ReportsApi/GetPartnerStatementRequest.cs` |
| `PartnerProgramStatementRes` | `src/WalmartApIs/Models/PartnerProgramStatementRes.cs` |

### GetReconReport

- **Auth**: `options.AccessToken`
- **Signature**: `GetReconReport(GetReconReportRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `ReportDate`, `WmSecAccessToken`, `WmQosCorrelationId`, `WmSvcName`
- **Query params (wire ← C#)**: `reportDate` ← `ReportDate`
- **Returns**: `BinaryContent`
- **Error**: `ApiException<GetReconReportError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent(out RawError)` [400] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `GetReconReportRequest` | `src/WalmartApIs/Requests/ReportsApi/GetReconReportRequest.cs` |
| `GetReconReportError` | `src/WalmartApIs/Errors/GetReconReportError.cs` |

### GetReconReportV1

- **Auth**: `options.AccessToken`
- **Signature**: `GetReconReportV1(GetReconReportV1Request request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `ReportDate`, `ReportVersion`, `WmSecAccessToken`, `WmQosCorrelationId`, `WmSvcName`
- **Query params (wire ← C#)**: `reportDate` ← `ReportDate`, `reportVersion` ← `ReportVersion`
- **Returns**: `BinaryContent`
- **Error**: `ApiException<GetReconReportV1Error>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent(out RawError)` [400] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `GetReconReportV1Request` | `src/WalmartApIs/Requests/ReportsApi/GetReconReportV1Request.cs` |
| `GetReconReportV1Error` | `src/WalmartApIs/Errors/GetReconReportV1Error.cs` |

