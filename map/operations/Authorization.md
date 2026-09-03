<!-- Generated file — do not edit; regenerated with the SDK. -->

# Authorization — operations

Accessor: `client.Authorization` · Source: `Api/Authorization.cs` · 3 operations

**Type sources**: the file declaring each type an operation names (`RawError` excluded — see sdk-map.md).

### Authorize

- **Signature**: `Authorize(ResponseType1 responseType, string clientId, string redirectUri, string scope, string state, string codeChallenge, CodeChallengeMethod codeChallengeMethod, RequestOptions? requestOptions = null, CancellationToken ct = default)`
- **Query params (wire ← C#)**: `response_type` ← `responseType`, `client_id` ← `clientId`, `redirect_uri` ← `redirectUri`, `scope` ← `scope`, `state` ← `state`, `code_challenge` ← `codeChallenge`, `code_challenge_method` ← `codeChallengeMethod`
- **Returns**: `void` (Task)
- **Error**: `SdkException<AuthorizeApiError>` — **Case A (typed)**
- **Error accessors**: `TryGetAuthorizeError(out AuthorizeError)` [400] · `TryGetOAuthError(out OAuthError)` [429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `ResponseType1` | `Models/Enums/ResponseType1.cs` |
| `CodeChallengeMethod` | `Models/Enums/CodeChallengeMethod.cs` |
| `AuthorizeApiError` | `Errors/AuthorizeApiError.cs` |
| `AuthorizeError` | `Models/AuthorizeError.cs` |
| `OAuthError` | `Models/OAuthError.cs` |

### CreateToken

- **Auth**: `options.BasicClientAuth`
- **Signature**: `CreateToken(GrantType grantType, string? clientId, string? clientSecret, string? code, string? codeVerifier, string? refreshToken, string? redirectUri, string? scope, RequestOptions? requestOptions = null, CancellationToken ct = default)`
  - 7 params (`clientId` … `scope`) — nullable, no default → **must pass explicitly** (pass `null` to skip)
- **Returns**: `TokenResponse`
- **Error**: `SdkException<CreateTokenError>` — **Case A (typed)**
- **Error accessors**: `TryGetOAuthError(out OAuthError)` [400, 401, 429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `GrantType` | `Models/Enums/GrantType.cs` |
| `TokenResponse` | `Models/TokenResponse.cs` |
| `CreateTokenError` | `Errors/CreateTokenError.cs` |
| `OAuthError` | `Models/OAuthError.cs` |

### RegisterClient

- **Signature**: `RegisterClient(ClientRegistrationRequest body, RequestOptions? requestOptions = null, CancellationToken ct = default)`
- **Returns**: `ClientRegistrationResponse`
- **Error**: `SdkException<RegisterClientError>` — **Case A (typed)**
- **Error accessors**: `TryGetRegistrationError(out RegistrationError)` [400, 401] · `TryGetOAuthError(out OAuthError)` [429, 500] · `TryGetRawError(out RawError)` [fallback]

| Type | Source |
| --- | --- |
| `ClientRegistrationRequest` | `Models/ClientRegistrationRequest.cs` |
| `ClientRegistrationResponse` | `Models/ClientRegistrationResponse.cs` |
| `RegisterClientError` | `Errors/RegisterClientError.cs` |
| `RegistrationError` | `Models/RegistrationError.cs` |
| `OAuthError` | `Models/OAuthError.cs` |

