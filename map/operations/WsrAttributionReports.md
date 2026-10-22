<!-- Generated file — do not edit; regenerated with the SDK. -->

# WsrAttributionReports — operations

Accessor: `client.WsrAttributionReports` · Source: `src/WalmartApIs/Api/WsrAttributionReports.cs` · 3 operations

**Type sources**: the file declaring each type an operation names (`RawError` excluded — see sdk-map.md).

### GetTagTemplates

- **Auth**: `options.BearerAuth`
- **Signature**: `GetTagTemplates(GetTagTemplatesRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `WmSecAccessToken`, `WmSvcName`, `WmQosCorrelationId`
- **Returns**: `WsrTagTemplatesResponse`
- **Error**: `ApiException<GetTagTemplatesError>` — **Case A (typed)**
- **Error accessors**: `TryGetWsrErrorResponse(out WsrErrorResponse)` [400, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `GetTagTemplatesRequest` | `src/WalmartApIs/Requests/WsrAttributionReports/GetTagTemplatesRequest.cs` |
| `TemplateType` | `src/WalmartApIs/Models/Enums/TemplateType.cs` |
| `WmGlobalVersion` | `src/WalmartApIs/Models/Enums/WmGlobalVersion.cs` |
| `WmMarket` | `src/WalmartApIs/Models/Enums/WmMarket.cs` |
| `WsrTagTemplatesResponse` | `src/WalmartApIs/Models/WsrTagTemplatesResponse.cs` |
| `GetTagTemplatesError` | `src/WalmartApIs/Errors/GetTagTemplatesError.cs` |
| `WsrErrorResponse` | `src/WalmartApIs/Models/WsrErrorResponse.cs` |

### GetWsrItemReport

- **Auth**: `options.BearerAuth`
- **Signature**: `GetWsrItemReport(GetWsrItemReportRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `WmSecAccessToken`, `WmSvcName`, `WmQosCorrelationId`, `Body`
- **Returns**: `WsrItemReportResponse`
- **Error**: `ApiException<GetWsrItemReportError>` — **Case A (typed)**
- **Error accessors**: `TryGetWsrErrorResponse(out WsrErrorResponse)` [400, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `GetWsrItemReportRequest` | `src/WalmartApIs/Requests/WsrAttributionReports/GetWsrItemReportRequest.cs` |
| `WmGlobalVersion` | `src/WalmartApIs/Models/Enums/WmGlobalVersion.cs` |
| `WmMarket` | `src/WalmartApIs/Models/Enums/WmMarket.cs` |
| `WsrReportRequest` | `src/WalmartApIs/Models/WsrReportRequest.cs` |
| `WsrItemReportResponse` | `src/WalmartApIs/Models/WsrItemReportResponse.cs` |
| `GetWsrItemReportError` | `src/WalmartApIs/Errors/GetWsrItemReportError.cs` |
| `WsrErrorResponse` | `src/WalmartApIs/Models/WsrErrorResponse.cs` |

### GetWsrPerformanceReport

- **Auth**: `options.BearerAuth`
- **Signature**: `GetWsrPerformanceReport(GetWsrPerformanceReportRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `WmSecAccessToken`, `WmSvcName`, `WmQosCorrelationId`, `Body`
- **Returns**: `WsrPerformanceReportResponse`
- **Error**: `ApiException<GetWsrPerformanceReportError>` — **Case A (typed)**
- **Error accessors**: `TryGetWsrErrorResponse(out WsrErrorResponse)` [400, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `GetWsrPerformanceReportRequest` | `src/WalmartApIs/Requests/WsrAttributionReports/GetWsrPerformanceReportRequest.cs` |
| `WmGlobalVersion` | `src/WalmartApIs/Models/Enums/WmGlobalVersion.cs` |
| `WmMarket` | `src/WalmartApIs/Models/Enums/WmMarket.cs` |
| `WsrReportRequest` | `src/WalmartApIs/Models/WsrReportRequest.cs` |
| `WsrPerformanceReportResponse` | `src/WalmartApIs/Models/WsrPerformanceReportResponse.cs` |
| `GetWsrPerformanceReportError` | `src/WalmartApIs/Errors/GetWsrPerformanceReportError.cs` |
| `WsrErrorResponse` | `src/WalmartApIs/Models/WsrErrorResponse.cs` |

