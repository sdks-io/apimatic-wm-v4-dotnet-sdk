<!-- Generated file — do not edit; regenerated with the SDK. -->

# FeedsApi — operations

Accessor: `client.FeedsApi` · Source: `src/WalmartApIs/Api/FeedsApi.cs` · 3 operations

**Type sources**: the file declaring each type an operation names (`RawError` excluded — see sdk-map.md).

### GetAllFeedStatuses

- **Auth**: `options.AccessToken`
- **Signature**: `GetAllFeedStatuses(GetAllFeedStatusesRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `WmSecAccessToken`, `WmQosCorrelationId`, `WmSvcName`, `WmMarket`, `WmGlobalVersion`
- **Query params (wire ← C#)**: `feedId` ← `FeedId`, `feedType` ← `FeedType`, `feedStatus` ← `FeedStatus`, `offset` ← `Offset`, `limit` ← `Limit`
- **Returns**: `FeedRecordResponse`
- **Error**: `ApiException<GetAllFeedStatusesError>` — **Case A (typed)**
- **Error accessors**: `TryGetFeedRecordResponse(out FeedRecordResponse)` [404, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `GetAllFeedStatusesRequest` | `src/WalmartApIs/Requests/FeedsApi/GetAllFeedStatusesRequest.cs` |
| `FeedStatus1` | `src/WalmartApIs/Models/Enums/FeedStatus1.cs` |
| `WmMarket1` | `src/WalmartApIs/Models/Enums/WmMarket1.cs` |
| `WmGlobalVersion` | `src/WalmartApIs/Models/Enums/WmGlobalVersion.cs` |
| `FeedRecordResponse` | `src/WalmartApIs/Models/FeedRecordResponse.cs` |
| `GetAllFeedStatusesError` | `src/WalmartApIs/Errors/GetAllFeedStatusesError.cs` |

### GetFeedErrorReport

- **Auth**: `options.AccessToken`
- **Signature**: `GetFeedErrorReport(GetFeedErrorReportRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `FeedId`, `FeedType`, `WmSecAccessToken`, `WmQosCorrelationId`, `WmSvcName`, `WmMarket`, `WmGlobalVersion`
- **Query params (wire ← C#)**: `feedType` ← `FeedType`
- **Returns**: `BinaryContent`
- **Error**: `ApiException<RawError>` — **Case B**

| Type | Source |
| --- | --- |
| `GetFeedErrorReportRequest` | `src/WalmartApIs/Requests/FeedsApi/GetFeedErrorReportRequest.cs` |
| `FeedType` | `src/WalmartApIs/Models/Enums/FeedType.cs` |
| `WmMarket1` | `src/WalmartApIs/Models/Enums/WmMarket1.cs` |
| `WmGlobalVersion` | `src/WalmartApIs/Models/Enums/WmGlobalVersion.cs` |

### GetFeedItemStatus

- **Auth**: `options.AccessToken`
- **Signature**: `GetFeedItemStatus(GetFeedItemStatusRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `FeedId`, `WmSecAccessToken`, `WmQosCorrelationId`, `WmSvcName`, `WmMarket`, `WmGlobalVersion`
- **Query params (wire ← C#)**: `includeDetails` ← `IncludeDetails`, `offset` ← `Offset`, `limit` ← `Limit`
- **Returns**: `V3FeedsResponse1`
- **Error**: `ApiException<GetFeedItemStatusError>` — **Case A (typed)**
- **Error accessors**: `TryGetV3Feeds404Error21(out V3Feeds404Error21)` [404] · `TryGetV3Feeds500Error21(out V3Feeds500Error21)` [500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `GetFeedItemStatusRequest` | `src/WalmartApIs/Requests/FeedsApi/GetFeedItemStatusRequest.cs` |
| `WmMarket1` | `src/WalmartApIs/Models/Enums/WmMarket1.cs` |
| `WmGlobalVersion` | `src/WalmartApIs/Models/Enums/WmGlobalVersion.cs` |
| `V3FeedsResponse1` | `src/WalmartApIs/Models/V3FeedsResponse1.cs` |
| `GetFeedItemStatusError` | `src/WalmartApIs/Errors/GetFeedItemStatusError.cs` |
| `V3Feeds404Error21` | `src/WalmartApIs/Models/V3Feeds404Error21.cs` |
| `V3Feeds500Error21` | `src/WalmartApIs/Models/V3Feeds500Error21.cs` |

