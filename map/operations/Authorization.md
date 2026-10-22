<!-- Generated file — do not edit; regenerated with the SDK. -->

# Authorization — operations

Accessor: `client.Authorization` · Source: `src/WalmartApIs/Api/Authorization.cs` · 2 operations

**Type sources**: the file declaring each type an operation names (`RawError` excluded — see sdk-map.md).

### GetTokenDetail

- **Signature**: `GetTokenDetail(GetTokenDetailRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `WmSecAccessToken`, `WmMarket`, `ContentType`, `WmQosCorrelationId`, `WmSvcName`
- **Returns**: `TokenDetailResponse`
- **Error**: `ApiException<RawError>` — **Case B**

| Type | Source |
| --- | --- |
| `GetTokenDetailRequest` | `src/WalmartApIs/Requests/Authorization/GetTokenDetailRequest.cs` |
| `TokenDetailResponse` | `src/WalmartApIs/Models/TokenDetailResponse.cs` |

### TokenApi

- **Signature**: `TokenApi(TokenApiRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `WmMarket`, `Authorization`, `WmQosCorrelationId`, `WmSvcName`
- **Returns**: `OAuthTokenModel`
- **Error**: `ApiException<TokenApiError>` — **Case A (typed)**
- **Error accessors**: `TryGetV3Token400Error1(out V3Token400Error1)` [400] · `TryGetV3Token401Error1(out V3Token401Error1)` [401] · `TryGetV3Token500Error1(out V3Token500Error1)` [500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `TokenApiRequest` | `src/WalmartApIs/Requests/Authorization/TokenApiRequest.cs` |
| `GrantType1` | `src/WalmartApIs/Models/Enums/GrantType1.cs` |
| `OAuthTokenModel` | `src/WalmartApIs/Models/OAuthTokenModel.cs` |
| `TokenApiError` | `src/WalmartApIs/Errors/TokenApiError.cs` |
| `V3Token400Error1` | `src/WalmartApIs/Models/V3Token400Error1.cs` |
| `V3Token401Error1` | `src/WalmartApIs/Models/V3Token401Error1.cs` |
| `V3Token500Error1` | `src/WalmartApIs/Models/V3Token500Error1.cs` |

