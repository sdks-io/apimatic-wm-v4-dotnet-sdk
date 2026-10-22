<!-- Generated file — do not edit; regenerated with the SDK. -->

# ReturnsRefund — operations

Accessor: `client.ReturnsRefund` · Source: `src/WalmartApIs/Api/ReturnsRefund.cs` · 3 operations

**Type sources**: the file declaring each type an operation names (`RawError` excluded — see sdk-map.md).

### GetReturns

- **Auth**: `options.AccessToken`
- **Signature**: `GetReturns(GetReturnsRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `QueryParams`, `WmQosCorrelationId`, `WmSvcName`, `WmMarket`, `WmGlobalVersion`
- **Query params (wire ← C#)**: `Query Params` ← `QueryParams`
- **Returns**: `ReturnOrderResponse`
- **Error**: `ApiException<GetReturnsError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorResponse3(out ErrorResponse3)` [400] · `TryGetUnauthorized1(out Unauthorized1)` [401] · `TryGetForbidden1(out Forbidden1)` [403] · `TryGetTooManyRequests1(out TooManyRequests1)` [429] · `TryGetErrorResponses(out ErrorResponses)` [500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `GetReturnsRequest` | `src/WalmartApIs/Requests/ReturnsRefund/GetReturnsRequest.cs` |
| `QueryParams` | `src/WalmartApIs/Models/QueryParams.cs` |
| `WmMarket1` | `src/WalmartApIs/Models/Enums/WmMarket1.cs` |
| `WmGlobalVersion` | `src/WalmartApIs/Models/Enums/WmGlobalVersion.cs` |
| `ReturnOrderResponse` | `src/WalmartApIs/Models/ReturnOrderResponse.cs` |
| `GetReturnsError` | `src/WalmartApIs/Errors/GetReturnsError.cs` |
| `ErrorResponse3` | `src/WalmartApIs/Models/ErrorResponse3.cs` |
| `Unauthorized1` | `src/WalmartApIs/Models/Unauthorized1.cs` |
| `Forbidden1` | `src/WalmartApIs/Models/Forbidden1.cs` |
| `TooManyRequests1` | `src/WalmartApIs/Models/TooManyRequests1.cs` |
| `ErrorResponses` | `src/WalmartApIs/Models/ErrorResponses.cs` |

### RefundRequest

- **Auth**: `options.AccessToken`
- **Signature**: `RefundRequest(RefundRequestOperationRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `ReturnOrderId`, `WmQosCorrelationId`, `WmSvcName`, `WmMarket`, `WmGlobalVersion`, `Body`
- **Returns**: `RequestModel`
- **Error**: `ApiException<RefundRequestError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorResponse3(out ErrorResponse3)` [400] · `TryGetUnauthorized1(out Unauthorized1)` [401] · `TryGetForbidden1(out Forbidden1)` [403] · `TryGetTooManyRequests1(out TooManyRequests1)` [429] · `TryGetErrorResponses(out ErrorResponses)` [500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `RefundRequestOperationRequest` | `src/WalmartApIs/Requests/ReturnsRefund/RefundRequestOperationRequest.cs` |
| `WmMarket3` | `src/WalmartApIs/Models/Enums/WmMarket3.cs` |
| `WmGlobalVersion` | `src/WalmartApIs/Models/Enums/WmGlobalVersion.cs` |
| `RefundRequest` | `src/WalmartApIs/Models/RefundRequest.cs` |
| `RequestModel` | `src/WalmartApIs/Models/RequestModel.cs` |
| `RefundRequestError` | `src/WalmartApIs/Errors/RefundRequestError.cs` |
| `ErrorResponse3` | `src/WalmartApIs/Models/ErrorResponse3.cs` |
| `Unauthorized1` | `src/WalmartApIs/Models/Unauthorized1.cs` |
| `Forbidden1` | `src/WalmartApIs/Models/Forbidden1.cs` |
| `TooManyRequests1` | `src/WalmartApIs/Models/TooManyRequests1.cs` |
| `ErrorResponses` | `src/WalmartApIs/Models/ErrorResponses.cs` |

### ReturnOrderCursor

- **Auth**: `options.AccessToken`
- **Signature**: `ReturnOrderCursor(ReturnOrderCursorRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `QueryParams`, `WmQosCorrelationId`, `WmSvcName`, `WmMarket`, `WmGlobalVersion`
- **Query params (wire ← C#)**: `Query Params` ← `QueryParams`
- **Returns**: `ReturnOrdersResponses`
- **Error**: `ApiException<ReturnOrderCursorError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorResponse3(out ErrorResponse3)` [400] · `TryGetUnauthorized1(out Unauthorized1)` [401] · `TryGetForbidden1(out Forbidden1)` [403] · `TryGetTooManyRequests1(out TooManyRequests1)` [429] · `TryGetErrorResponses(out ErrorResponses)` [500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `ReturnOrderCursorRequest` | `src/WalmartApIs/Requests/ReturnsRefund/ReturnOrderCursorRequest.cs` |
| `QueryParamsMx` | `src/WalmartApIs/Models/QueryParamsMx.cs` |
| `WmMarket21` | `src/WalmartApIs/Models/Enums/WmMarket21.cs` |
| `WmGlobalVersion` | `src/WalmartApIs/Models/Enums/WmGlobalVersion.cs` |
| `ReturnOrdersResponses` | `src/WalmartApIs/Models/ReturnOrdersResponses.cs` |
| `ReturnOrderCursorError` | `src/WalmartApIs/Errors/ReturnOrderCursorError.cs` |
| `ErrorResponse3` | `src/WalmartApIs/Models/ErrorResponse3.cs` |
| `Unauthorized1` | `src/WalmartApIs/Models/Unauthorized1.cs` |
| `Forbidden1` | `src/WalmartApIs/Models/Forbidden1.cs` |
| `TooManyRequests1` | `src/WalmartApIs/Models/TooManyRequests1.cs` |
| `ErrorResponses` | `src/WalmartApIs/Models/ErrorResponses.cs` |

