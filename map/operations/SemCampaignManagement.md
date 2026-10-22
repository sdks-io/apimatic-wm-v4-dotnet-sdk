<!-- Generated file — do not edit; regenerated with the SDK. -->

# SemCampaignManagement — operations

Accessor: `client.SemCampaignManagement` · Source: `src/WalmartApIs/Api/SemCampaignManagement.cs` · 6 operations

**Type sources**: the file declaring each type an operation names (`RawError` excluded — see sdk-map.md).

### CreateCampaign

- **Auth**: `options.BearerAuth`
- **Signature**: `CreateCampaign(CreateCampaignRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `WmSecAccessToken`, `WmQosCorrelationId`, `WmSvcName`, `Body`
- **Returns**: `SemCampaignResponse`
- **Error**: `ApiException<CreateCampaignError>` — **Case A (typed)**
- **Error accessors**: `TryGetSemErrorResponse400(out SemErrorResponse400)` [400, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `CreateCampaignRequest` | `src/WalmartApIs/Requests/SemCampaignManagement/CreateCampaignRequest.cs` |
| `SemCampaignCreateRequest` | `src/WalmartApIs/Models/SemCampaignCreateRequest.cs` |
| `SemCampaignResponse` | `src/WalmartApIs/Models/SemCampaignResponse.cs` |
| `CreateCampaignError` | `src/WalmartApIs/Errors/CreateCampaignError.cs` |
| `SemErrorResponse400` | `src/WalmartApIs/Models/SemErrorResponse400.cs` |

### DeleteCampaign

- **Auth**: `options.BearerAuth`
- **Signature**: `DeleteCampaign(DeleteCampaignRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `CampaignId`, `WmSecAccessToken`, `WmQosCorrelationId`, `WmSvcName`
- **Returns**: `SemCampaignResponse`
- **Error**: `ApiException<DeleteCampaignError>` — **Case A (typed)**
- **Error accessors**: `TryGetSemErrorResponse400(out SemErrorResponse400)` [400, 404, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `DeleteCampaignRequest` | `src/WalmartApIs/Requests/SemCampaignManagement/DeleteCampaignRequest.cs` |
| `SemCampaignResponse` | `src/WalmartApIs/Models/SemCampaignResponse.cs` |
| `DeleteCampaignError` | `src/WalmartApIs/Errors/DeleteCampaignError.cs` |
| `SemErrorResponse400` | `src/WalmartApIs/Models/SemErrorResponse400.cs` |

### GetCampaignDetails

- **Auth**: `options.BearerAuth`
- **Signature**: `GetCampaignDetails(GetCampaignDetailsRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `CampaignId`, `WmSecAccessToken`, `WmQosCorrelationId`, `WmSvcName`
- **Returns**: `SemCampaign`
- **Error**: `ApiException<GetCampaignDetailsError>` — **Case A (typed)**
- **Error accessors**: `TryGetSemErrorResponse400(out SemErrorResponse400)` [400, 404, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `GetCampaignDetailsRequest` | `src/WalmartApIs/Requests/SemCampaignManagement/GetCampaignDetailsRequest.cs` |
| `SemCampaign` | `src/WalmartApIs/Models/SemCampaign.cs` |
| `GetCampaignDetailsError` | `src/WalmartApIs/Errors/GetCampaignDetailsError.cs` |
| `SemErrorResponse400` | `src/WalmartApIs/Models/SemErrorResponse400.cs` |

### SearchCampaignRecommendations

- **Auth**: `options.AccessToken`
- **Signature**: `SearchCampaignRecommendations(SearchCampaignRecommendationsRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `WmSecAccessToken`, `WmSvcName`, `WmQosCorrelationId`
- **Returns**: `CampaignRecommendationsSearchResponse`
- **Error**: `ApiException<SearchCampaignRecommendationsError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorResponseModel(out ErrorResponseModel)` [400, 401, 403, 422, 500, 503] · `TryGetErrorResponse429(out ErrorResponse429)` [429] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `SearchCampaignRecommendationsRequest` | `src/WalmartApIs/Requests/SemCampaignManagement/SearchCampaignRecommendationsRequest.cs` |
| `WmGlobalVersion` | `src/WalmartApIs/Models/Enums/WmGlobalVersion.cs` |
| `WmMarket` | `src/WalmartApIs/Models/Enums/WmMarket.cs` |
| `Accept` | `src/WalmartApIs/Models/Enums/Accept.cs` |
| `CampaignRecommendationsSearchRequest` | `src/WalmartApIs/Models/CampaignRecommendationsSearchRequest.cs` |
| `CampaignRecommendationsSearchResponse` | `src/WalmartApIs/Models/CampaignRecommendationsSearchResponse.cs` |
| `SearchCampaignRecommendationsError` | `src/WalmartApIs/Errors/SearchCampaignRecommendationsError.cs` |
| `ErrorResponseModel` | `src/WalmartApIs/Models/ErrorResponseModel.cs` |
| `ErrorResponse429` | `src/WalmartApIs/Models/ErrorResponse429.cs` |

### StopCampaign

- **Auth**: `options.BearerAuth`
- **Signature**: `StopCampaign(StopCampaignRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `CampaignId`, `WmSecAccessToken`, `WmQosCorrelationId`, `WmSvcName`
- **Returns**: `SemCampaignResponse`
- **Error**: `ApiException<StopCampaignError>` — **Case A (typed)**
- **Error accessors**: `TryGetSemErrorResponse400(out SemErrorResponse400)` [400, 404, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `StopCampaignRequest` | `src/WalmartApIs/Requests/SemCampaignManagement/StopCampaignRequest.cs` |
| `SemCampaignResponse` | `src/WalmartApIs/Models/SemCampaignResponse.cs` |
| `StopCampaignError` | `src/WalmartApIs/Errors/StopCampaignError.cs` |
| `SemErrorResponse400` | `src/WalmartApIs/Models/SemErrorResponse400.cs` |

### UpdateCampaign

- **Auth**: `options.BearerAuth`
- **Signature**: `UpdateCampaign(UpdateCampaignRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `CampaignId`, `WmSecAccessToken`, `WmQosCorrelationId`, `WmSvcName`, `Body`
- **Returns**: `SemCampaignResponse`
- **Error**: `ApiException<UpdateCampaignError>` — **Case A (typed)**
- **Error accessors**: `TryGetSemErrorResponse400(out SemErrorResponse400)` [400, 404, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `UpdateCampaignRequest` | `src/WalmartApIs/Requests/SemCampaignManagement/UpdateCampaignRequest.cs` |
| `SemCampaignUpdateRequest` | `src/WalmartApIs/Models/SemCampaignUpdateRequest.cs` |
| `SemCampaignResponse` | `src/WalmartApIs/Models/SemCampaignResponse.cs` |
| `UpdateCampaignError` | `src/WalmartApIs/Errors/UpdateCampaignError.cs` |
| `SemErrorResponse400` | `src/WalmartApIs/Models/SemErrorResponse400.cs` |

