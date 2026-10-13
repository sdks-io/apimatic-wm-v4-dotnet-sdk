<!-- Generated file — do not edit; regenerated with the SDK. -->

# Authorization — operations

Accessor: `client.Authorization` · Source: `src/WalmartApIs/Api/Authorization.cs` · 3 operations

**Type sources**: the file declaring each type an operation names (`RawError` excluded — see sdk-map.md).

### Authorize

- **Signature**: `Authorize(AuthorizeRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `ResponseType`, `ClientId`, `RedirectUri`, `Scope`, `State`, `CodeChallenge`, `CodeChallengeMethod`
- **Query params (wire ← C#)**: `response_type` ← `ResponseType`, `client_id` ← `ClientId`, `redirect_uri` ← `RedirectUri`, `scope` ← `Scope`, `state` ← `State`, `code_challenge` ← `CodeChallenge`, `code_challenge_method` ← `CodeChallengeMethod`
- **Returns**: `void` (Task)
- **Error**: `ApiException<AuthorizeApiError>` — **Case A (typed)**
- **Error accessors**: `TryGetAuthorizeError(out AuthorizeError)` [400] · `TryGetOAuthError(out OAuthError)` [429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `AuthorizeRequest` | `src/WalmartApIs/Requests/Authorization/AuthorizeRequest.cs` |
| `ResponseType1` | `src/WalmartApIs/Models/Enums/ResponseType1.cs` |
| `CodeChallengeMethod` | `src/WalmartApIs/Models/Enums/CodeChallengeMethod.cs` |
| `AuthorizeApiError` | `src/WalmartApIs/Errors/AuthorizeApiError.cs` |
| `AuthorizeError` | `src/WalmartApIs/Models/AuthorizeError.cs` |
| `OAuthError` | `src/WalmartApIs/Models/OAuthError.cs` |

### CreateToken

- **Auth**: `options.BasicClientAuth`
- **Signature**: `CreateToken(CreateTokenRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `GrantType`
- **Returns**: `TokenResponse`
- **Error**: `ApiException<CreateTokenError>` — **Case A (typed)**
- **Error accessors**: `TryGetOAuthError(out OAuthError)` [400, 401, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `CreateTokenRequest` | `src/WalmartApIs/Requests/Authorization/CreateTokenRequest.cs` |
| `GrantType` | `src/WalmartApIs/Models/Enums/GrantType.cs` |
| `TokenResponse` | `src/WalmartApIs/Models/TokenResponse.cs` |
| `CreateTokenError` | `src/WalmartApIs/Errors/CreateTokenError.cs` |
| `OAuthError` | `src/WalmartApIs/Models/OAuthError.cs` |

### RegisterClient

- **Signature**: `RegisterClient(RegisterClientRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `Body`
- **Returns**: `ClientRegistrationResponse`
- **Error**: `ApiException<RegisterClientError>` — **Case A (typed)**
- **Error accessors**: `TryGetRegistrationError(out RegistrationError)` [400, 401] · `TryGetOAuthError(out OAuthError)` [429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `RegisterClientRequest` | `src/WalmartApIs/Requests/Authorization/RegisterClientRequest.cs` |
| `ClientRegistrationRequest` | `src/WalmartApIs/Models/ClientRegistrationRequest.cs` |
| `ClientRegistrationResponse` | `src/WalmartApIs/Models/ClientRegistrationResponse.cs` |
| `RegisterClientError` | `src/WalmartApIs/Errors/RegisterClientError.cs` |
| `RegistrationError` | `src/WalmartApIs/Models/RegistrationError.cs` |
| `OAuthError` | `src/WalmartApIs/Models/OAuthError.cs` |

