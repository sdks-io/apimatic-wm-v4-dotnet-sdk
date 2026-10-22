<!-- Generated file — do not edit; regenerated with the SDK. -->

# SemItemDiagnostics — operations

Accessor: `client.SemItemDiagnostics` · Source: `src/WalmartApIs/Api/SemItemDiagnostics.cs` · 2 operations

**Type sources**: the file declaring each type an operation names (`RawError` excluded — see sdk-map.md).

### GetIssueTypes

- **Auth**: `options.AccessToken`
- **Signature**: `GetIssueTypes(GetIssueTypesRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `WmSecAccessToken`, `WmSvcName`, `WmQosCorrelationId`
- **Returns**: `IReadOnlyDictionary<string, IssueMetadata>`
- **Error**: `ApiException<GetIssueTypesError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorResponseModel(out ErrorResponseModel)` [401, 403, 500, 503] · `TryGetErrorResponse429(out ErrorResponse429)` [429] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `GetIssueTypesRequest` | `src/WalmartApIs/Requests/SemItemDiagnostics/GetIssueTypesRequest.cs` |
| `WmGlobalVersion` | `src/WalmartApIs/Models/Enums/WmGlobalVersion.cs` |
| `WmMarket` | `src/WalmartApIs/Models/Enums/WmMarket.cs` |
| `IssueMetadata` | `src/WalmartApIs/Models/IssueMetadata.cs` |
| `GetIssueTypesError` | `src/WalmartApIs/Errors/GetIssueTypesError.cs` |
| `ErrorResponseModel` | `src/WalmartApIs/Models/ErrorResponseModel.cs` |
| `ErrorResponse429` | `src/WalmartApIs/Models/ErrorResponse429.cs` |

### SearchItemIssues

- **Auth**: `options.AccessToken`
- **Signature**: `SearchItemIssues(SearchItemIssuesRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `WmSecAccessToken`, `WmSvcName`, `WmQosCorrelationId`
- **Returns**: `ItemDiagnosticSearchResponse`
- **Error**: `ApiException<SearchItemIssuesError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorResponseModel(out ErrorResponseModel)` [400, 401, 403, 422, 500, 503] · `TryGetErrorResponse429(out ErrorResponse429)` [429] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `SearchItemIssuesRequest` | `src/WalmartApIs/Requests/SemItemDiagnostics/SearchItemIssuesRequest.cs` |
| `WmGlobalVersion` | `src/WalmartApIs/Models/Enums/WmGlobalVersion.cs` |
| `WmMarket` | `src/WalmartApIs/Models/Enums/WmMarket.cs` |
| `Accept` | `src/WalmartApIs/Models/Enums/Accept.cs` |
| `ItemDiagnosticSearchRequest` | `src/WalmartApIs/Models/ItemDiagnosticSearchRequest.cs` |
| `ItemDiagnosticSearchResponse` | `src/WalmartApIs/Models/ItemDiagnosticSearchResponse.cs` |
| `SearchItemIssuesError` | `src/WalmartApIs/Errors/SearchItemIssuesError.cs` |
| `ErrorResponseModel` | `src/WalmartApIs/Models/ErrorResponseModel.cs` |
| `ErrorResponse429` | `src/WalmartApIs/Models/ErrorResponse429.cs` |

