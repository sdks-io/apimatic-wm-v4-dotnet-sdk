<!-- Generated file — do not edit; regenerated with the SDK. -->

# WalmartSellerFulfilled — operations

Accessor: `client.WalmartSellerFulfilled` · Source: `src/WalmartApIs/Api/WalmartSellerFulfilled.cs` · 1 operation

**Type sources**: the file declaring each type an operation names (`RawError` excluded — see sdk-map.md).

### WalmartPlusEnrollment

- **Signature**: `WalmartPlusEnrollment(WalmartPlusEnrollmentRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `FeedType`, `RequestType`, `WmSecAccessToken`, `WmQosCorrelationId`, `WmSvcName`, `WmMarket`, `FileName`
- **Query params (wire ← C#)**: `feedType` ← `FeedType`, `requestType` ← `RequestType`
- **Returns**: `V3FeedsFeedTypeProgramActionsRequestTypeWalmartPlusSffResponse`
- **Error**: `ApiException<WalmartPlusEnrollmentError>` — **Case A (typed)**
- **Error accessors**: `TryGetV3FeedsFeedTypeProgramActionsRequestTypeWalmartPlusSff400Error1(out V3FeedsFeedTypeProgramActionsRequestTypeWalmartPlusSff400Error1)` [400] · `TryGetV3FeedsFeedTypeProgramActionsRequestTypeWalmartPlusSff500Error1(out V3FeedsFeedTypeProgramActionsRequestTypeWalmartPlusSff500Error1)` [500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `WalmartPlusEnrollmentRequest` | `src/WalmartApIs/Requests/WalmartSellerFulfilled/WalmartPlusEnrollmentRequest.cs` |
| `FeedType3` | `src/WalmartApIs/Models/Enums/FeedType3.cs` |
| `RequestType` | `src/WalmartApIs/Models/Enums/RequestType.cs` |
| `WmMarket` | `src/WalmartApIs/Models/Enums/WmMarket.cs` |
| `V3FeedsFeedTypeProgramActionsRequestTypeWalmartPlusSffResponse` | `src/WalmartApIs/Models/V3FeedsFeedTypeProgramActionsRequestTypeWalmartPlusSffResponse.cs` |
| `WalmartPlusEnrollmentError` | `src/WalmartApIs/Errors/WalmartPlusEnrollmentError.cs` |
| `V3FeedsFeedTypeProgramActionsRequestTypeWalmartPlusSff400Error1` | `src/WalmartApIs/Models/V3FeedsFeedTypeProgramActionsRequestTypeWalmartPlusSff400Error1.cs` |
| `V3FeedsFeedTypeProgramActionsRequestTypeWalmartPlusSff500Error1` | `src/WalmartApIs/Models/V3FeedsFeedTypeProgramActionsRequestTypeWalmartPlusSff500Error1.cs` |

