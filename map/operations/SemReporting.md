<!-- Generated file — do not edit; regenerated with the SDK. -->

# SemReporting — operations

Accessor: `client.SemReporting` · Source: `src/WalmartApIs/Api/SemReporting.cs` · 3 operations

**Type sources**: the file declaring each type an operation names (`RawError` excluded — see sdk-map.md).

### GetBillingHistory

- **Auth**: `options.BearerAuth`
- **Signature**: `GetBillingHistory(GetBillingHistoryRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `WmSecAccessToken`, `WmQosCorrelationId`, `WmSvcName`
- **Returns**: `SemBillingHistoryResponse`
- **Error**: `ApiException<GetBillingHistoryError>` — **Case A (typed)**
- **Error accessors**: `TryGetSemErrorResponse400(out SemErrorResponse400)` [400, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `GetBillingHistoryRequest` | `src/WalmartApIs/Requests/SemReporting/GetBillingHistoryRequest.cs` |
| `SemBillingHistoryRequest` | `src/WalmartApIs/Models/SemBillingHistoryRequest.cs` |
| `SemBillingHistoryResponse` | `src/WalmartApIs/Models/SemBillingHistoryResponse.cs` |
| `GetBillingHistoryError` | `src/WalmartApIs/Errors/GetBillingHistoryError.cs` |
| `SemErrorResponse400` | `src/WalmartApIs/Models/SemErrorResponse400.cs` |

### GetCampaignLevelSummary

- **Auth**: `options.BearerAuth`
- **Signature**: `GetCampaignLevelSummary(GetCampaignLevelSummaryRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `WmSecAccessToken`, `WmQosCorrelationId`, `WmSvcName`
- **Returns**: `SemCampaignLevelReportResponse`
- **Error**: `ApiException<GetCampaignLevelSummaryError>` — **Case A (typed)**
- **Error accessors**: `TryGetSemErrorResponse400(out SemErrorResponse400)` [400, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `GetCampaignLevelSummaryRequest` | `src/WalmartApIs/Requests/SemReporting/GetCampaignLevelSummaryRequest.cs` |
| `SemReportRequest` | `src/WalmartApIs/Models/SemReportRequest.cs` |
| `SemCampaignLevelReportResponse` | `src/WalmartApIs/Models/SemCampaignLevelReportResponse.cs` |
| `GetCampaignLevelSummaryError` | `src/WalmartApIs/Errors/GetCampaignLevelSummaryError.cs` |
| `SemErrorResponse400` | `src/WalmartApIs/Models/SemErrorResponse400.cs` |

### GetItemLevelSummary

- **Auth**: `options.BearerAuth`
- **Signature**: `GetItemLevelSummary(GetItemLevelSummaryRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `CampaignId`, `WmSecAccessToken`, `WmQosCorrelationId`, `WmSvcName`
- **Returns**: `SemItemLevelReportResponse`
- **Error**: `ApiException<GetItemLevelSummaryError>` — **Case A (typed)**
- **Error accessors**: `TryGetSemErrorResponse400(out SemErrorResponse400)` [400, 404, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `GetItemLevelSummaryRequest` | `src/WalmartApIs/Requests/SemReporting/GetItemLevelSummaryRequest.cs` |
| `SemReportRequest` | `src/WalmartApIs/Models/SemReportRequest.cs` |
| `SemItemLevelReportResponse` | `src/WalmartApIs/Models/SemItemLevelReportResponse.cs` |
| `GetItemLevelSummaryError` | `src/WalmartApIs/Errors/GetItemLevelSummaryError.cs` |
| `SemErrorResponse400` | `src/WalmartApIs/Models/SemErrorResponse400.cs` |

