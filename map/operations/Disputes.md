<!-- Generated file — do not edit; regenerated with the SDK. -->

# Disputes — operations

Accessor: `client.Disputes` · Source: `src/WalmartApIs/Api/Disputes.cs` · 2 operations

**Type sources**: the file declaring each type an operation names (`RawError` excluded — see sdk-map.md).

### PostContest

- **Signature**: `PostContest(PostContestRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `WmSecAccessToken`, `WmQosCorrelationId`, `WmSvcName`, `WmMarket`, `WmGlobalVersion`, `Body`
- **Returns**: `DisputeContestResponses`
- **Error**: `ApiException<PostContestError>` — **Case A (typed)**
- **Error accessors**: `TryGetV3ItemsDisputeDuplicatesContest403Error1(out V3ItemsDisputeDuplicatesContest403Error1)` [403] · `TryGetV3ItemsDisputeDuplicatesContest404Error1(out V3ItemsDisputeDuplicatesContest404Error1)` [404] · `TryGetV3ItemsDisputeDuplicatesContest500Error1(out V3ItemsDisputeDuplicatesContest500Error1)` [500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `PostContestRequest` | `src/WalmartApIs/Requests/Disputes/PostContestRequest.cs` |
| `WmMarket1` | `src/WalmartApIs/Models/Enums/WmMarket1.cs` |
| `WmGlobalVersion` | `src/WalmartApIs/Models/Enums/WmGlobalVersion.cs` |
| `V3ItemsDisputeDuplicatesContestRequest` | `src/WalmartApIs/Models/V3ItemsDisputeDuplicatesContestRequest.cs` |
| `DisputeContestResponses` | `src/WalmartApIs/Models/DisputeContestResponses.cs` |
| `PostContestError` | `src/WalmartApIs/Errors/PostContestError.cs` |
| `V3ItemsDisputeDuplicatesContest403Error1` | `src/WalmartApIs/Models/V3ItemsDisputeDuplicatesContest403Error1.cs` |
| `V3ItemsDisputeDuplicatesContest404Error1` | `src/WalmartApIs/Models/V3ItemsDisputeDuplicatesContest404Error1.cs` |
| `V3ItemsDisputeDuplicatesContest500Error1` | `src/WalmartApIs/Models/V3ItemsDisputeDuplicatesContest500Error1.cs` |

### PostStatus

- **Signature**: `PostStatus(PostStatusRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `WmSecAccessToken`, `WmQosCorrelationId`, `WmSvcName`, `WmMarket`, `WmGlobalVersion`, `Body`
- **Returns**: `V3ItemsDisputeDuplicatesStatusResponse`
- **Error**: `ApiException<PostStatusError>` — **Case A (typed)**
- **Error accessors**: `TryGetV3ItemsDisputeDuplicatesStatus403Error1(out V3ItemsDisputeDuplicatesStatus403Error1)` [403] · `TryGetV3ItemsDisputeDuplicatesStatus404Error1(out V3ItemsDisputeDuplicatesStatus404Error1)` [404] · `TryGetV3ItemsDisputeDuplicatesStatus500Error1(out V3ItemsDisputeDuplicatesStatus500Error1)` [500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `PostStatusRequest` | `src/WalmartApIs/Requests/Disputes/PostStatusRequest.cs` |
| `WmMarket1` | `src/WalmartApIs/Models/Enums/WmMarket1.cs` |
| `WmGlobalVersion` | `src/WalmartApIs/Models/Enums/WmGlobalVersion.cs` |
| `V3ItemsDisputeDuplicatesStatusRequest` | `src/WalmartApIs/Models/V3ItemsDisputeDuplicatesStatusRequest.cs` |
| `V3ItemsDisputeDuplicatesStatusResponse` | `src/WalmartApIs/Models/V3ItemsDisputeDuplicatesStatusResponse.cs` |
| `PostStatusError` | `src/WalmartApIs/Errors/PostStatusError.cs` |
| `V3ItemsDisputeDuplicatesStatus403Error1` | `src/WalmartApIs/Models/V3ItemsDisputeDuplicatesStatus403Error1.cs` |
| `V3ItemsDisputeDuplicatesStatus404Error1` | `src/WalmartApIs/Models/V3ItemsDisputeDuplicatesStatus404Error1.cs` |
| `V3ItemsDisputeDuplicatesStatus500Error1` | `src/WalmartApIs/Models/V3ItemsDisputeDuplicatesStatus500Error1.cs` |

