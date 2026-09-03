# Reference

> Source: [WalmartApIsClient](WalmartApIsClient.cs)

## Authorization

> Source: [Authorization](Api/Authorization.cs)

<details>
<summary><code>Task Authorize(ResponseType1 responseType, string clientId, string redirectUri, string scope, string state, string codeChallenge, CodeChallengeMethod codeChallengeMethod, RequestOptions? requestOptions = null, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Browser endpoint for the authorization-code grant (RFC 6749 §3.1). The
Solution Provider redirects the seller here; the seller authenticates and
consents at Walmart IAM, and the response redirects to `redirect_uri` with a
single-use `code`.

- **PKCE required** — `code_challenge` + `code_challenge_method=S256`
  (RFC 7636). `plain` is not accepted.
- **Exact** `redirect_uri` match against a value registered for the client.
- `state` required; echoed back verbatim (CSRF).
- The success and error redirects (performed by IAM) carry `iss` (RFC 9207);
  clients MUST validate it.

**Error handling.** For a valid request, this endpoint `302`-redirects to the
Walmart IAM consent URL; IAM then drives consent and performs the RFC 6749
§4.1.2.1 redirect back to the client's `redirect_uri` (success or error),
because IAM is the party that can verify the `redirect_uri` is registered.
For request-level errors that `the Authorization API` itself detects
(missing/invalid `client_id`/`redirect_uri`, `response_type` != `code`,
`code_challenge_method` != `S256`), it returns a JSON `400` (`AuthorizeError`).
It deliberately does **not** redirect these errors to the supplied
`redirect_uri`: the proxy has no client registry, so self-redirecting to an
unverified URI would be an open redirect.

> **Upstream status (, pending):** `iss` emission, exact-redirect
> enforcement, and server-side rejection of `code_challenge_method=plain` are
> IAM / app-store responsibilities not yet fully in place. the Authorization API
> enforces the request-side invariants it can and redirects valid requests to
> IAM; the full guarantee lands when those upstream changes ship.


</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    await client.Authorization.Authorize(responseType,
        clientId,
        redirectUri,
        scope,
        state,
        codeChallenge,
        codeChallengeMethod);
}
catch (SdkException<AuthorizeApiError> ex)
{
    if (ex.Error.TryGetAuthorizeError(out var error))
    {
        // TODO: Handle 'error' of type AuthorizeError
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>responseType</code> | <code>[ResponseType1](Models/Enums/ResponseType1.cs)</code> | Must be `code`. |
| <code>clientId</code> | <code>string</code> | The registered client identifier. |
| <code>redirectUri</code> | <code>string</code> | Callback URI; must exactly match a registered value. |
| <code>scope</code> | <code>string</code> | Space-delimited scopes. Include `offline_access` to receive a refresh token. |
| <code>state</code> | <code>string</code> | Opaque CSRF token; echoed back unchanged. |
| <code>codeChallenge</code> | <code>string</code> | PKCE challenge — base64url(SHA-256(code_verifier)). |
| <code>codeChallengeMethod</code> | <code>[CodeChallengeMethod](Models/Enums/CodeChallengeMethod.cs)</code> | Must be `S256`. |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: No content

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[AuthorizeApiError](Errors/AuthorizeApiError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;TokenResponse&gt; CreateToken(GrantType grantType, string? clientId, string? clientSecret, string? code, string? codeVerifier, string? refreshToken, string? redirectUri, string? scope, RequestOptions? requestOptions = null, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Exchanges a grant for an OAuth access token. Supported `grant_type` values:

| grant_type | Flow | Required (besides grant_type) |
|----------------------|------------------|---------------------------------|
| `client_credentials` | seller-direct | client auth (see below) |
| `authorization_code` | delegated | `code`, `code_verifier` (PKCE) |
| `refresh_token` | delegated | `refresh_token` |

**Client authentication:** credentials in the form body (`client_secret_post`)
— `client_id` + `client_secret`. HTTP Basic is also accepted. **Public
clients** (Solution-Provider apps registered `token_endpoint_auth_method: none`)
send no secret on the delegated grants; PKCE protects the code.

**`client_credentials`:** issues **no** refresh token (re-mint on expiry).
**`scope` is decorative here** — accepted for compatibility but **not honored**;
access is governed by the scopes provisioned per client in IAM ; there
is no down-scoping and the response does not echo `scope`. (Verified: `/v3/token`
ignores any `scope=` value.)

**`authorization_code`:** `redirect_uri` is accepted for OAuth 2.0 back-compat
but not required in 2.1 (PKCE covers injection).

**`refresh_token`:** the response includes a **rotated** `refresh_token` — the
presented token is invalidated (OAuth 2.1 §4.3.1; IAM rotates today, ~1-year
TTL). A requested `scope` MUST NOT exceed the originally granted scope.

**Token:** `Bearer` (RFC 6750), sent downstream as `Authorization: Bearer
<token>` — **not** `WM_SEC.ACCESS_TOKEN`.

**Implemented by `the Authorization API` as a stateless proxy to Walmart IAM .**


</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Authorization.CreateToken(grantType,
        clientId,
        clientSecret,
        code,
        codeVerifier,
        refreshToken,
        redirectUri,
        scope);
    // TODO: Handle 'response' of type TokenResponse
}
catch (SdkException<CreateTokenError> ex)
{
    if (ex.Error.TryGetOAuthError(out var error))
    {
        // TODO: Handle 'error' of type OAuthError
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>grantType</code> | <code>[GrantType](Models/Enums/GrantType.cs)</code> | - |
| <code>clientId</code> | <code>string?</code> | - |
| <code>clientSecret</code> | <code>string?</code> | - |
| <code>code</code> | <code>string?</code> | - |
| <code>codeVerifier</code> | <code>string?</code> | - |
| <code>refreshToken</code> | <code>string?</code> | - |
| <code>redirectUri</code> | <code>string?</code> | - |
| <code>scope</code> | <code>string?</code> | - |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[TokenResponse](Models/TokenResponse.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[CreateTokenError](Errors/CreateTokenError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;ClientRegistrationResponse&gt; RegisterClient(ClientRegistrationRequest body, RequestOptions? requestOptions = null, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Registers a Solution Provider client and returns its `client_id` (RFC
7591). Lets Solution Providers onboard without manual registration.

Public clients set `token_endpoint_auth_method: none` (no secret; PKCE
required). Confidential clients receive a `client_secret`. `redirect_uris`
are validated and later enforced by exact match at `/auth/v4/authorize`.

Proxied to Walmart IAM's registration endpoint (/). RFC 7592
registration management (read/update/delete via a
`registration_access_token`) is not offered in this version.


</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Authorization.RegisterClient(body);
    // TODO: Handle 'response' of type ClientRegistrationResponse
}
catch (SdkException<RegisterClientError> ex)
{
    if (ex.Error.TryGetRegistrationError(out var error))
    {
        // TODO: Handle 'error' of type RegistrationError
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>body</code> | <code>[ClientRegistrationRequest](Models/ClientRegistrationRequest.cs)</code> | - |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[ClientRegistrationResponse](Models/ClientRegistrationResponse.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[RegisterClientError](Errors/RegisterClientError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

## Catalog

> Source: [Catalog](Api/Catalog.cs)

<details>
<summary><code>Task&lt;Item&gt; GetCatalogItem(string walmartItemId, IReadOnlyList&lt;string&gt; marketplaceIds, IReadOnlyList&lt;IncludedDatum&gt;? includedData, RequestOptions? requestOptions = null, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Catalog.GetCatalogItem(walmartItemId, marketplaceIds, includedData);
    // TODO: Handle 'response' of type Item
}
catch (SdkException<GetCatalogItemError> ex)
{
    if (ex.Error.TryGetErrorList(out var error))
    {
        // TODO: Handle 'error' of type ErrorList
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>walmartItemId</code> | <code>string</code> | Walmart Item ID (14-digit numeric identifier) |
| <code>marketplaceIds</code> | <code>IReadOnlyList&lt;string&gt;</code> | Walmart marketplace identifiers. Use WALMART_US for the US marketplace. |
| <code>includedData</code> | <code>IReadOnlyList&lt;[IncludedDatum](Models/Enums/IncludedDatum.cs)&gt;?</code> | Data sections to include in the response |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[Item](Models/Item.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[GetCatalogItemError](Errors/GetCatalogItemError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;ItemSearchResults&gt; SearchCatalogItems(IReadOnlyList&lt;string&gt; marketplaceIds, string? keywords, string? walmartItemIds, string? sellerSku, string? gtin, string? upc, IReadOnlyList&lt;IncludedDatum&gt;? includedData, string? pageToken, int? pageSize = 10, RequestOptions? requestOptions = null, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Search the Walmart Marketplace catalog using keywords, WalmartItemId,
GTIN, UPC, or seller SKU. Returns matching catalog items.


</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Catalog.SearchCatalogItems(marketplaceIds,
        keywords,
        walmartItemIds,
        sellerSku,
        gtin,
        upc,
        includedData,
        pageToken);
    // TODO: Handle 'response' of type ItemSearchResults
}
catch (SdkException<SearchCatalogItemsError> ex)
{
    if (ex.Error.TryGetErrorList(out var error))
    {
        // TODO: Handle 'error' of type ErrorList
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>marketplaceIds</code> | <code>IReadOnlyList&lt;string&gt;</code> | Walmart marketplace identifiers. Use WALMART_US for the US marketplace. |
| <code>keywords</code> | <code>string?</code> | Keyword search terms |
| <code>walmartItemIds</code> | <code>string?</code> | Comma-separated Walmart Item IDs (14-digit). Max 20. |
| <code>sellerSku</code> | <code>string?</code> | Seller-defined SKU |
| <code>gtin</code> | <code>string?</code> | Global Trade Item Number (14-digit) |
| <code>upc</code> | <code>string?</code> | Universal Product Code (12-digit) |
| <code>includedData</code> | <code>IReadOnlyList&lt;[IncludedDatum](Models/Enums/IncludedDatum.cs)&gt;?</code> | Data sections to include in the response |
| <code>pageToken</code> | <code>string?</code> | Token for the next page of results, obtained from `pagination.nextToken` in a previous response.<br>**Known limitation:** Cursor-based pagination is not currently supported for keyword search. The PIQS search backend (`/v3/items/walmart/search`) does not return a `nextCursor` and does not honour this parameter. Results are capped at 40 items per call. Reserved for future use once PIQS exposes pagination support. |
| <code>pageSize</code> | <code>int?</code> | Number of results per page (1–20).<br>**Known limitation:** The PIQS keyword search backend hard-caps results at 40 items per call regardless of this value.<br>**Default**: 10 |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[ItemSearchResults](Models/ItemSearchResults.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[SearchCatalogItemsError](Errors/SearchCatalogItemsError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

## DataKiosk

> Source: [DataKiosk](Api/DataKiosk.cs)

<details>
<summary><code>Task&lt;CancelQueryResponse&gt; CancelQuery(string queryId, RequestOptions? requestOptions = null, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.DataKiosk.CancelQuery(queryId);
    // TODO: Handle 'response' of type CancelQueryResponse
}
catch (SdkException<CancelQueryError> ex)
{
    if (ex.Error.TryGetErrorList(out var error))
    {
        // TODO: Handle 'error' of type ErrorList
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>queryId</code> | <code>string</code> | - |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[CancelQueryResponse](Models/CancelQueryResponse.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[CancelQueryError](Errors/CancelQueryError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;CreateQueryResponse&gt; CreateQuery(CreateQuerySpecification body, RequestOptions? requestOptions = null, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Submits a structured query for async processing.
Query language TBD pending ADR (GraphQL vs REST hybrid — Pod 4).


</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.DataKiosk.CreateQuery(body);
    // TODO: Handle 'response' of type CreateQueryResponse
}
catch (SdkException<CreateQueryError> ex)
{
    if (ex.Error.TryGetErrorList(out var error))
    {
        // TODO: Handle 'error' of type ErrorList
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>body</code> | <code>[CreateQuerySpecification](Models/CreateQuerySpecification.cs)</code> | - |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[CreateQueryResponse](Models/CreateQueryResponse.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[CreateQueryError](Errors/CreateQueryError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;Document&gt; GetDocument(string documentId, RequestOptions? requestOptions = null, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Returns a pre-signed URL for downloading query result data.
Do not log the pre-signed URL.


</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.DataKiosk.GetDocument(documentId);
    // TODO: Handle 'response' of type Document
}
catch (SdkException<GetDocumentError> ex)
{
    if (ex.Error.TryGetErrorList(out var error))
    {
        // TODO: Handle 'error' of type ErrorList
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>documentId</code> | <code>string</code> | - |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[Document](Models/Document.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[GetDocumentError](Errors/GetDocumentError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;GetQueriesResponse&gt; GetQueries(IReadOnlyList&lt;ProcessingStatus&gt;? processingStatuses, DateTimeOffset? createdSince, DateTimeOffset? createdUntil, string? paginationToken, int? pageSize = 10, RequestOptions? requestOptions = null, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Returns a paginated list of Data Kiosk queries submitted by the seller,
optionally filtered by processing status and creation date range.


</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.DataKiosk.GetQueries(processingStatuses, createdSince, createdUntil, paginationToken);
    // TODO: Handle 'response' of type GetQueriesResponse
}
catch (SdkException<GetQueriesError> ex)
{
    if (ex.Error.TryGetErrorList(out var error))
    {
        // TODO: Handle 'error' of type ErrorList
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>processingStatuses</code> | <code>IReadOnlyList&lt;[ProcessingStatus](Models/Enums/ProcessingStatus.cs)&gt;?</code> | - |
| <code>createdSince</code> | <code>DateTimeOffset?</code> | - |
| <code>createdUntil</code> | <code>DateTimeOffset?</code> | - |
| <code>paginationToken</code> | <code>string?</code> | - |
| <code>pageSize</code> | <code>int?</code> | **Default**: 10 |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[GetQueriesResponse](Models/GetQueriesResponse.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[GetQueriesError](Errors/GetQueriesError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;Query&gt; GetQuery(string queryId, RequestOptions? requestOptions = null, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.DataKiosk.GetQuery(queryId);
    // TODO: Handle 'response' of type Query
}
catch (SdkException<GetQueryError> ex)
{
    if (ex.Error.TryGetErrorList(out var error))
    {
        // TODO: Handle 'error' of type ErrorList
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>queryId</code> | <code>string</code> | - |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[Query](Models/Query.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[GetQueryError](Errors/GetQueryError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

## Disputes

> Source: [Disputes](Api/Disputes.cs)

<details>
<summary><code>Task&lt;DisputeEligibilityResponse&gt; CheckDisputeEligibility(RequestOptions? requestOptions = null, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Returns whether the authenticated seller is eligible to raise a payment
dispute and, if not, the reason for ineligibility. Delegates to
GMPPaymentsPlatform (Phase 5).


</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Disputes.CheckDisputeEligibility();
    // TODO: Handle 'response' of type DisputeEligibilityResponse
}
catch (SdkException<CheckDisputeEligibilityError> ex)
{
    if (ex.Error.TryGetErrorList(out var error))
    {
        // TODO: Handle 'error' of type ErrorList
    }
}
```

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[DisputeEligibilityResponse](Models/DisputeEligibilityResponse.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[CheckDisputeEligibilityError](Errors/CheckDisputeEligibilityError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

## Feeds

> Source: [Feeds](Api/Feeds.cs)

<details>
<summary><code>Task&lt;CancelFeedResponse&gt; CancelFeed(string feedId, RequestOptions? requestOptions = null, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

**Placeholder — not yet implemented.** Cancels the feed identified by
feedId if it is still queued or in progress. Mirrors Amazon SP-API
`cancelFeed` (DELETE /feeds/2021-06-30/feeds/{feedId}) so partners can
generate a client against the final contract now. A feed that has
already reached DONE or ERROR cannot be cancelled.


</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Feeds.CancelFeed(feedId);
    // TODO: Handle 'response' of type CancelFeedResponse
}
catch (SdkException<CancelFeedError> ex)
{
    if (ex.Error.TryGetErrorList1(out var error))
    {
        // TODO: Handle 'error' of type ErrorList1
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>feedId</code> | <code>string</code> | - |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[CancelFeedResponse](Models/CancelFeedResponse.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[CancelFeedError](Errors/CancelFeedError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;CreateFeedResponse&gt; CreateFeed(FeedType feedType, string? marketplaceId, BinaryContent file, ContentType? contentType, RequestOptions? requestOptions = null, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Upload a feed file and submit it for asynchronous processing in a single call.
The server handles document storage internally. Use the returned feedId to poll
processing status via GET /feeds/v4/feeds/{feedId}.


</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Feeds.CreateFeed(feedType, marketplaceId, file, contentType);
    // TODO: Handle 'response' of type CreateFeedResponse
}
catch (SdkException<CreateFeedError> ex)
{
    if (ex.Error.TryGetErrorList1(out var error))
    {
        // TODO: Handle 'error' of type ErrorList1
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>feedType</code> | <code>[FeedType](Models/Enums/FeedType.cs)</code> | The type of feed being submitted |
| <code>marketplaceId</code> | <code>string?</code> | Marketplace identifier (opaque token). If omitted, the service applies WALMART_US. |
| <code>file</code> | <code>BinaryContent</code> | - |
| <code>contentType</code> | <code>[ContentType?](Models/Enums/ContentType.cs)</code> | - |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[CreateFeedResponse](Models/CreateFeedResponse.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[CreateFeedError](Errors/CreateFeedError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;Feed&gt; GetFeed(string feedId, RequestOptions? requestOptions = null, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Feeds.GetFeed(feedId);
    // TODO: Handle 'response' of type Feed
}
catch (SdkException<GetFeedError> ex)
{
    if (ex.Error.TryGetErrorList1(out var error))
    {
        // TODO: Handle 'error' of type ErrorList1
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>feedId</code> | <code>string</code> | - |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[Feed](Models/Feed.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[GetFeedError](Errors/GetFeedError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;BinaryContent&gt; GetFeedDocument(string feedId, RequestOptions? requestOptions = null, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Downloads the raw feed document file. The response is a binary stream
(application/octet-stream). The Content-Disposition header contains the
original filename when available. Content-Length header is always set
to enable download progress tracking.

An IDOR check is performed before the download — the authenticated
seller must own the feed referenced by feedId.


</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Feeds.GetFeedDocument(feedId);
    // TODO: Handle 'response' of type BinaryContent
}
catch (SdkException<GetFeedDocumentError> ex)
{
    if (ex.Error.TryGetErrorList1(out var error))
    {
        // TODO: Handle 'error' of type ErrorList1
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>feedId</code> | <code>string</code> | - |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>BinaryContent</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[GetFeedDocumentError](Errors/GetFeedDocumentError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;GetFeedsResponse&gt; GetFeeds(IReadOnlyList&lt;FeedType&gt;? feedTypes, IReadOnlyList&lt;FeedStatus&gt;? feedStatuses, DateTimeOffset? createdSince, DateTimeOffset? createdUntil, string? nextToken, int? pageSize = 10, RequestOptions? requestOptions = null, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Feeds.GetFeeds(feedTypes, feedStatuses, createdSince, createdUntil, nextToken);
    // TODO: Handle 'response' of type GetFeedsResponse
}
catch (SdkException<GetFeedsError> ex)
{
    if (ex.Error.TryGetErrorList1(out var error))
    {
        // TODO: Handle 'error' of type ErrorList1
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>feedTypes</code> | <code>IReadOnlyList&lt;[FeedType](Models/Enums/FeedType.cs)&gt;?</code> | Feed type filter |
| <code>feedStatuses</code> | <code>IReadOnlyList&lt;[FeedStatus](Models/Enums/FeedStatus.cs)&gt;?</code> | - |
| <code>createdSince</code> | <code>DateTimeOffset?</code> | - |
| <code>createdUntil</code> | <code>DateTimeOffset?</code> | - |
| <code>nextToken</code> | <code>string?</code> | - |
| <code>pageSize</code> | <code>int?</code> | **Default**: 10 |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[GetFeedsResponse](Models/GetFeedsResponse.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[GetFeedsError](Errors/GetFeedsError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

## FinalPayout

> Source: [FinalPayout](Api/FinalPayout.cs)

<details>
<summary><code>Task&lt;FinalPayoutCaseStatusResponse&gt; GetFinalPayoutCaseStatus(RequestOptions? requestOptions = null, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Returns the current state, case ID, and payable amount for the authenticated
seller's final payout case (used when a seller account is being offboarded).
Delegates to GMPPaymentsPlatform (Phase 5).


</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.FinalPayout.GetFinalPayoutCaseStatus();
    // TODO: Handle 'response' of type FinalPayoutCaseStatusResponse
}
catch (SdkException<GetFinalPayoutCaseStatusError> ex)
{
    if (ex.Error.TryGetErrorList(out var error))
    {
        // TODO: Handle 'error' of type ErrorList
    }
}
```

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[FinalPayoutCaseStatusResponse](Models/FinalPayoutCaseStatusResponse.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[GetFinalPayoutCaseStatusError](Errors/GetFinalPayoutCaseStatusError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;FinalPayoutCaseStatusResponse&gt; UpdateFinalPayoutCaseStatus(DisbursementsV4FinalPayoutCaseUpdateStatusRequest body, RequestOptions? requestOptions = null, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Transitions the authenticated seller's final payout case to Resolved or
Closed, optionally including resolution notes. Requires disbursements:write
scope. Delegates to GMPPaymentsPlatform (Phase 5).


</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.FinalPayout.UpdateFinalPayoutCaseStatus(body);
    // TODO: Handle 'response' of type FinalPayoutCaseStatusResponse
}
catch (SdkException<UpdateFinalPayoutCaseStatusError> ex)
{
    if (ex.Error.TryGetErrorList(out var error))
    {
        // TODO: Handle 'error' of type ErrorList
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>body</code> | <code>[DisbursementsV4FinalPayoutCaseUpdateStatusRequest](Models/DisbursementsV4FinalPayoutCaseUpdateStatusRequest.cs)</code> | - |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[FinalPayoutCaseStatusResponse](Models/FinalPayoutCaseStatusResponse.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[UpdateFinalPayoutCaseStatusError](Errors/UpdateFinalPayoutCaseStatusError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

## Finances

> Source: [Finances](Api/Finances.cs)

<details>
<summary><code>Task&lt;object&gt; ListFinancialEventGroups(int? maxResultsPerPage, DateTimeOffset? financialEventGroupStartedBefore, DateTimeOffset? financialEventGroupStartedAfter, string? nextToken, RequestOptions? requestOptions = null, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Returns financial event groups for the seller.

**Status: stub** — no upstream endpoint found that models the SP-API
FinancialEventGroup (requires eventGroupId keying, date-range filter,
and cursor pagination). Returns empty response pending Phase 5.


</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Finances.ListFinancialEventGroups(maxResultsPerPage,
        financialEventGroupStartedBefore,
        financialEventGroupStartedAfter,
        nextToken);
    // TODO: Handle 'response' of type object
}
catch (SdkException<ListFinancialEventGroupsError> ex)
{
    if (ex.Error.TryGetErrorList(out var error))
    {
        // TODO: Handle 'error' of type ErrorList
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>maxResultsPerPage</code> | <code>int?</code> | The maximum number of results per page. |
| <code>financialEventGroupStartedBefore</code> | <code>DateTimeOffset?</code> | Financial event groups that opened before this date/time (ISO 8601). |
| <code>financialEventGroupStartedAfter</code> | <code>DateTimeOffset?</code> | Financial event groups that opened after this date/time (ISO 8601). |
| <code>nextToken</code> | <code>string?</code> | Cursor token for the next page of results. |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>object</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[ListFinancialEventGroupsError](Errors/ListFinancialEventGroupsError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;object&gt; ListFinancialEvents(int? maxResultsPerPage, DateTimeOffset? postedAfter, DateTimeOffset? postedBefore, string? nextToken, RequestOptions? requestOptions = null, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Returns financial events for the authenticated seller via GMP partnerTxnSearch.

**Best-effort implementation** — backed by GMP partnerTxnSearch.
Returns transaction records for the seller keyed by partnerId.

**Unsupported parameters:** PostedAfter, PostedBefore, and NextToken are not
supported by the upstream. Supplying any of these parameters returns 400 Bad Request.


</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Finances.ListFinancialEvents(maxResultsPerPage, postedAfter, postedBefore, nextToken);
    // TODO: Handle 'response' of type object
}
catch (SdkException<ListFinancialEventsError> ex)
{
    if (ex.Error.TryGetErrorList(out var error))
    {
        // TODO: Handle 'error' of type ErrorList
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>maxResultsPerPage</code> | <code>int?</code> | Ignored — GMP returns all results in a single page. |
| <code>postedAfter</code> | <code>DateTimeOffset?</code> | Not supported — returns 400 Bad Request if supplied. |
| <code>postedBefore</code> | <code>DateTimeOffset?</code> | Not supported — returns 400 Bad Request if supplied. |
| <code>nextToken</code> | <code>string?</code> | Not supported — returns 400 Bad Request if supplied. |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>object</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[ListFinancialEventsError](Errors/ListFinancialEventsError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;object&gt; ListFinancialEventsByGroupId(string eventGroupId, int? maxResultsPerPage, DateTimeOffset? postedAfter, DateTimeOffset? postedBefore, string? nextToken, RequestOptions? requestOptions = null, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Returns financial events for a specific financial event group.

**Status: stub** — no upstream maps eventGroupId to a financial event
set. Returns empty response pending Phase 5.


</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Finances.ListFinancialEventsByGroupId(eventGroupId,
        maxResultsPerPage,
        postedAfter,
        postedBefore,
        nextToken);
    // TODO: Handle 'response' of type object
}
catch (SdkException<ListFinancialEventsByGroupIdError> ex)
{
    if (ex.Error.TryGetErrorList(out var error))
    {
        // TODO: Handle 'error' of type ErrorList
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>eventGroupId</code> | <code>string</code> | The identifier of the financial event group. |
| <code>maxResultsPerPage</code> | <code>int?</code> | The maximum number of results to return per page. |
| <code>postedAfter</code> | <code>DateTimeOffset?</code> | Financial events posted after (or on) this date (ISO 8601). |
| <code>postedBefore</code> | <code>DateTimeOffset?</code> | Financial events posted before (but not on) this date (ISO 8601). |
| <code>nextToken</code> | <code>string?</code> | Cursor token for the next page of results. |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>object</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[ListFinancialEventsByGroupIdError](Errors/ListFinancialEventsByGroupIdError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;object&gt; ListFinancialEventsByOrderId(string orderId, int? maxResultsPerPage, string? nextToken, RequestOptions? requestOptions = null, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Returns financial events for a specific order via GMP commission endpoint.

**Best-effort implementation** — returns commission charges only;
refunds, fees, and adjustments are absent. IDOR ownership gate enforced.


</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Finances.ListFinancialEventsByOrderId(orderId, maxResultsPerPage, nextToken);
    // TODO: Handle 'response' of type object
}
catch (SdkException<ListFinancialEventsByOrderIdError> ex)
{
    if (ex.Error.TryGetErrorList(out var error))
    {
        // TODO: Handle 'error' of type ErrorList
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>orderId</code> | <code>string</code> | Walmart order number — must be numeric (1–50 digits). |
| <code>maxResultsPerPage</code> | <code>int?</code> | Ignored — GMP returns all commission entries in one page. |
| <code>nextToken</code> | <code>string?</code> | Not supported — returns 400 Bad Request if supplied. |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>object</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[ListFinancialEventsByOrderIdError](Errors/ListFinancialEventsByOrderIdError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

## FulfillmentOutbound

> Source: [FulfillmentOutbound](Api/FulfillmentOutbound.cs)

<details>
<summary><code>Task&lt;CancelFulfillmentOrderResponse&gt; CancelFulfillmentOrder(string sellerFulfillmentOrderId, RequestOptions? requestOptions = null, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.FulfillmentOutbound.CancelFulfillmentOrder(sellerFulfillmentOrderId);
    // TODO: Handle 'response' of type CancelFulfillmentOrderResponse
}
catch (SdkException<CancelFulfillmentOrderError> ex)
{
    if (ex.Error.TryGetErrorList(out var error))
    {
        // TODO: Handle 'error' of type ErrorList
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>sellerFulfillmentOrderId</code> | <code>string</code> | - |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[CancelFulfillmentOrderResponse](Models/CancelFulfillmentOrderResponse.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[CancelFulfillmentOrderError](Errors/CancelFulfillmentOrderError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;CreateFulfillmentOrderResponse&gt; CreateFulfillmentOrder(CreateFulfillmentOrderRequest body, RequestOptions? requestOptions = null, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.FulfillmentOutbound.CreateFulfillmentOrder(body);
    // TODO: Handle 'response' of type CreateFulfillmentOrderResponse
}
catch (SdkException<CreateFulfillmentOrderError> ex)
{
    if (ex.Error.TryGetErrorList(out var error))
    {
        // TODO: Handle 'error' of type ErrorList
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>body</code> | <code>[CreateFulfillmentOrderRequest](Models/CreateFulfillmentOrderRequest.cs)</code> | - |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[CreateFulfillmentOrderResponse](Models/CreateFulfillmentOrderResponse.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[CreateFulfillmentOrderError](Errors/CreateFulfillmentOrderError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;GetFulfillmentOrderResponse&gt; GetFulfillmentOrder(string sellerFulfillmentOrderId, RequestOptions? requestOptions = null, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.FulfillmentOutbound.GetFulfillmentOrder(sellerFulfillmentOrderId);
    // TODO: Handle 'response' of type GetFulfillmentOrderResponse
}
catch (SdkException<GetFulfillmentOrderError> ex)
{
    if (ex.Error.TryGetErrorList(out var error))
    {
        // TODO: Handle 'error' of type ErrorList
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>sellerFulfillmentOrderId</code> | <code>string</code> | - |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[GetFulfillmentOrderResponse](Models/GetFulfillmentOrderResponse.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[GetFulfillmentOrderError](Errors/GetFulfillmentOrderError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;GetFulfillmentOrderShipmentsResponse&gt; GetFulfillmentOrderShipments(string sellerFulfillmentOrderId, RequestOptions? requestOptions = null, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.FulfillmentOutbound.GetFulfillmentOrderShipments(sellerFulfillmentOrderId);
    // TODO: Handle 'response' of type GetFulfillmentOrderShipmentsResponse
}
catch (SdkException<GetFulfillmentOrderShipmentsError> ex)
{
    if (ex.Error.TryGetErrorList(out var error))
    {
        // TODO: Handle 'error' of type ErrorList
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>sellerFulfillmentOrderId</code> | <code>string</code> | - |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[GetFulfillmentOrderShipmentsResponse](Models/GetFulfillmentOrderShipmentsResponse.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[GetFulfillmentOrderShipmentsError](Errors/GetFulfillmentOrderShipmentsError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;GetFulfillmentPreviewResponse&gt; GetFulfillmentPreview(GetFulfillmentPreviewRequest body, RequestOptions? requestOptions = null, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Returns estimated delivery dates, shipping costs, and available ship nodes
for a prospective fulfillment order. Use before creating the order.


</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.FulfillmentOutbound.GetFulfillmentPreview(body);
    // TODO: Handle 'response' of type GetFulfillmentPreviewResponse
}
catch (SdkException<GetFulfillmentPreviewError> ex)
{
    if (ex.Error.TryGetErrorList(out var error))
    {
        // TODO: Handle 'error' of type ErrorList
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>body</code> | <code>[GetFulfillmentPreviewRequest](Models/GetFulfillmentPreviewRequest.cs)</code> | - |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[GetFulfillmentPreviewResponse](Models/GetFulfillmentPreviewResponse.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[GetFulfillmentPreviewError](Errors/GetFulfillmentPreviewError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;ListAllFulfillmentOrdersResponse&gt; ListAllFulfillmentOrders(DateTimeOffset? queryStartDate, string? nextToken, RequestOptions? requestOptions = null, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.FulfillmentOutbound.ListAllFulfillmentOrders(queryStartDate, nextToken);
    // TODO: Handle 'response' of type ListAllFulfillmentOrdersResponse
}
catch (SdkException<ListAllFulfillmentOrdersError> ex)
{
    if (ex.Error.TryGetErrorList(out var error))
    {
        // TODO: Handle 'error' of type ErrorList
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>queryStartDate</code> | <code>DateTimeOffset?</code> | - |
| <code>nextToken</code> | <code>string?</code> | - |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[ListAllFulfillmentOrdersResponse](Models/ListAllFulfillmentOrdersResponse.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[ListAllFulfillmentOrdersError](Errors/ListAllFulfillmentOrdersError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;UpdateFulfillmentOrderResponse&gt; UpdateFulfillmentOrder(string sellerFulfillmentOrderId, UpdateFulfillmentOrderRequest body, RequestOptions? requestOptions = null, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.FulfillmentOutbound.UpdateFulfillmentOrder(sellerFulfillmentOrderId, body);
    // TODO: Handle 'response' of type UpdateFulfillmentOrderResponse
}
catch (SdkException<UpdateFulfillmentOrderError> ex)
{
    if (ex.Error.TryGetErrorList(out var error))
    {
        // TODO: Handle 'error' of type ErrorList
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>sellerFulfillmentOrderId</code> | <code>string</code> | - |
| <code>body</code> | <code>[UpdateFulfillmentOrderRequest](Models/UpdateFulfillmentOrderRequest.cs)</code> | - |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[UpdateFulfillmentOrderResponse](Models/UpdateFulfillmentOrderResponse.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[UpdateFulfillmentOrderError](Errors/UpdateFulfillmentOrderError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

## Inventory

> Source: [Inventory](Api/Inventory.cs)

<details>
<summary><code>Task&lt;BulkUpdateInventoryResponse&gt; BulkUpdateInventory(BulkUpdateInventoryRequest body, RequestOptions? requestOptions = null, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Bulk inventory update. Max 500 items per request.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Inventory.BulkUpdateInventory(body);
    // TODO: Handle 'response' of type BulkUpdateInventoryResponse
}
catch (SdkException<BulkUpdateInventoryError> ex)
{
    if (ex.Error.TryGetErrorList(out var error))
    {
        // TODO: Handle 'error' of type ErrorList
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>body</code> | <code>[BulkUpdateInventoryRequest](Models/BulkUpdateInventoryRequest.cs)</code> | - |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[BulkUpdateInventoryResponse](Models/BulkUpdateInventoryResponse.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[BulkUpdateInventoryError](Errors/BulkUpdateInventoryError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;InventorySummary&gt; GetInventoryForSku(string sku, string? shipNode, RequestOptions? requestOptions = null, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Inventory.GetInventoryForSku(sku, shipNode);
    // TODO: Handle 'response' of type InventorySummary
}
catch (SdkException<GetInventoryForSkuError> ex)
{
    if (ex.Error.TryGetErrorList(out var error))
    {
        // TODO: Handle 'error' of type ErrorList
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>sku</code> | <code>string</code> | - |
| <code>shipNode</code> | <code>string?</code> | Walmart Ship Node ID (for multi-node sellers) |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[InventorySummary](Models/InventorySummary.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[GetInventoryForSkuError](Errors/GetInventoryForSkuError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;GetInventorySummariesResponse&gt; GetInventorySummaries(string? skus, string? shipNode, string? nextToken, int? pageSize = 100, RequestOptions? requestOptions = null, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Inventory.GetInventorySummaries(skus, shipNode, nextToken);
    // TODO: Handle 'response' of type GetInventorySummariesResponse
}
catch (SdkException<GetInventorySummariesError> ex)
{
    if (ex.Error.TryGetErrorList(out var error))
    {
        // TODO: Handle 'error' of type ErrorList
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>skus</code> | <code>string?</code> | Comma-separated seller SKUs (max 50) |
| <code>shipNode</code> | <code>string?</code> | Walmart Ship Node ID (for multi-node sellers) |
| <code>nextToken</code> | <code>string?</code> | - |
| <code>pageSize</code> | <code>int?</code> | **Default**: 100 |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[GetInventorySummariesResponse](Models/GetInventorySummariesResponse.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[GetInventorySummariesError](Errors/GetInventorySummariesError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;UpdateInventoryResponse&gt; UpdateInventoryForSku(string sku, UpdateInventoryRequest body, RequestOptions? requestOptions = null, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Inventory.UpdateInventoryForSku(sku, body);
    // TODO: Handle 'response' of type UpdateInventoryResponse
}
catch (SdkException<UpdateInventoryForSkuError> ex)
{
    if (ex.Error.TryGetErrorList(out var error))
    {
        // TODO: Handle 'error' of type ErrorList
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>sku</code> | <code>string</code> | - |
| <code>body</code> | <code>[UpdateInventoryRequest](Models/UpdateInventoryRequest.cs)</code> | - |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[UpdateInventoryResponse](Models/UpdateInventoryResponse.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[UpdateInventoryForSkuError](Errors/UpdateInventoryForSkuError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

## ListingsItems

> Source: [ListingsItems](Api/ListingsItems.cs)

<details>
<summary><code>Task&lt;ListingsItemSubmissionResponse&gt; DeleteListingsItem(string sellerId, string sku, IReadOnlyList&lt;string&gt; marketplaceIds, string? issueLocale = "en_US", RequestOptions? requestOptions = null, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.ListingsItems.DeleteListingsItem(sellerId, sku, marketplaceIds);
    // TODO: Handle 'response' of type ListingsItemSubmissionResponse
}
catch (SdkException<DeleteListingsItemError> ex)
{
    if (ex.Error.TryGetErrorList(out var error))
    {
        // TODO: Handle 'error' of type ErrorList
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>sellerId</code> | <code>string</code> | Seller identifier |
| <code>sku</code> | <code>string</code> | Seller SKU identifying the listing |
| <code>marketplaceIds</code> | <code>IReadOnlyList&lt;string&gt;</code> | - |
| <code>issueLocale</code> | <code>string?</code> | **Default**: "en_US" |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[ListingsItemSubmissionResponse](Models/ListingsItemSubmissionResponse.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[DeleteListingsItemError](Errors/DeleteListingsItemError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;Item1&gt; GetListingsItem(string sellerId, string sku, IReadOnlyList&lt;string&gt; marketplaceIds, IReadOnlyList&lt;IncludedDatum1&gt;? includedData, string? issueLocale = "en_US", RequestOptions? requestOptions = null, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.ListingsItems.GetListingsItem(sellerId, sku, marketplaceIds, includedData);
    // TODO: Handle 'response' of type Item1
}
catch (SdkException<GetListingsItemError> ex)
{
    if (ex.Error.TryGetErrorList(out var error))
    {
        // TODO: Handle 'error' of type ErrorList
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>sellerId</code> | <code>string</code> | Seller identifier |
| <code>sku</code> | <code>string</code> | Seller SKU identifying the listing |
| <code>marketplaceIds</code> | <code>IReadOnlyList&lt;string&gt;</code> | - |
| <code>includedData</code> | <code>IReadOnlyList&lt;[IncludedDatum1](Models/Enums/IncludedDatum1.cs)&gt;?</code> | - |
| <code>issueLocale</code> | <code>string?</code> | Locale for issue messages (e.g. en_US)<br>**Default**: "en_US" |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[Item1](Models/Item1.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[GetListingsItemError](Errors/GetListingsItemError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;ListingsItemSubmissionResponse&gt; PatchListingsItem(string sellerId, string sku, IReadOnlyList&lt;string&gt; marketplaceIds, ListingsItemPatchRequest body, string? issueLocale = "en_US", RequestOptions? requestOptions = null, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.ListingsItems.PatchListingsItem(sellerId, sku, marketplaceIds, body);
    // TODO: Handle 'response' of type ListingsItemSubmissionResponse
}
catch (SdkException<PatchListingsItemError> ex)
{
    if (ex.Error.TryGetErrorList(out var error))
    {
        // TODO: Handle 'error' of type ErrorList
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>sellerId</code> | <code>string</code> | Seller identifier |
| <code>sku</code> | <code>string</code> | Seller SKU identifying the listing |
| <code>marketplaceIds</code> | <code>IReadOnlyList&lt;string&gt;</code> | - |
| <code>body</code> | <code>[ListingsItemPatchRequest](Models/ListingsItemPatchRequest.cs)</code> | - |
| <code>issueLocale</code> | <code>string?</code> | **Default**: "en_US" |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[ListingsItemSubmissionResponse](Models/ListingsItemSubmissionResponse.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[PatchListingsItemError](Errors/PatchListingsItemError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;ListingsItemSubmissionResponse&gt; PutListingsItem(string sellerId, string sku, IReadOnlyList&lt;string&gt; marketplaceIds, ListingsItemPutRequest body, string? issueLocale = "en_US", RequestOptions? requestOptions = null, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.ListingsItems.PutListingsItem(sellerId, sku, marketplaceIds, body);
    // TODO: Handle 'response' of type ListingsItemSubmissionResponse
}
catch (SdkException<PutListingsItemError> ex)
{
    if (ex.Error.TryGetErrorList(out var error))
    {
        // TODO: Handle 'error' of type ErrorList
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>sellerId</code> | <code>string</code> | Seller identifier |
| <code>sku</code> | <code>string</code> | Seller SKU identifying the listing |
| <code>marketplaceIds</code> | <code>IReadOnlyList&lt;string&gt;</code> | - |
| <code>body</code> | <code>[ListingsItemPutRequest](Models/ListingsItemPutRequest.cs)</code> | - |
| <code>issueLocale</code> | <code>string?</code> | **Default**: "en_US" |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[ListingsItemSubmissionResponse](Models/ListingsItemSubmissionResponse.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[PutListingsItemError](Errors/PutListingsItemError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;ItemSearchResults1&gt; SearchListingsItems(string sellerId, IReadOnlyList&lt;string&gt; marketplaceIds, IReadOnlyList&lt;IncludedDatum1&gt;? includedData, string? pageToken, int? pageSize = 10, RequestOptions? requestOptions = null, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Returns a paginated list of the seller's listings items. Mirrors Amazon
SP-API `searchListingsItems` so an existing SP-API client can call the
seller-level collection endpoint (no SKU in the path) against v4.


</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.ListingsItems.SearchListingsItems(sellerId, marketplaceIds, includedData, pageToken);
    // TODO: Handle 'response' of type ItemSearchResults1
}
catch (SdkException<SearchListingsItemsError> ex)
{
    if (ex.Error.TryGetErrorList(out var error))
    {
        // TODO: Handle 'error' of type ErrorList
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>sellerId</code> | <code>string</code> | Seller identifier |
| <code>marketplaceIds</code> | <code>IReadOnlyList&lt;string&gt;</code> | - |
| <code>includedData</code> | <code>IReadOnlyList&lt;[IncludedDatum1](Models/Enums/IncludedDatum1.cs)&gt;?</code> | - |
| <code>pageToken</code> | <code>string?</code> | Opaque cursor returned by a previous call for the next page |
| <code>pageSize</code> | <code>int?</code> | Maximum number of results per page<br>**Default**: 10 |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[ItemSearchResults1](Models/ItemSearchResults1.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[SearchListingsItemsError](Errors/SearchListingsItemsError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

## ListingsRestrictions

> Source: [ListingsRestrictions](Api/ListingsRestrictions.cs)

<details>
<summary><code>Task&lt;RestrictionList&gt; GetListingsRestrictions(string asin, ConditionType1 conditionType, string sellerId, IReadOnlyList&lt;string&gt; marketplaceIds, string? reasonLocale = "en_US", RequestOptions? requestOptions = null, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Returns restrictions on listing an item for a given ASIN and seller.
A successful response does not guarantee the seller can list — check
the restrictions array.


</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.ListingsRestrictions.GetListingsRestrictions(asin,
        conditionType,
        sellerId,
        marketplaceIds);
    // TODO: Handle 'response' of type RestrictionList
}
catch (SdkException<GetListingsRestrictionsError> ex)
{
    if (ex.Error.TryGetErrorList(out var error))
    {
        // TODO: Handle 'error' of type ErrorList
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>asin</code> | <code>string</code> | Walmart Item ID (maps to ASIN in Walmart Seller API) |
| <code>conditionType</code> | <code>[ConditionType1](Models/Enums/ConditionType1.cs)</code> | - |
| <code>sellerId</code> | <code>string</code> | - |
| <code>marketplaceIds</code> | <code>IReadOnlyList&lt;string&gt;</code> | - |
| <code>reasonLocale</code> | <code>string?</code> | Locale for localized restriction reason messages<br>**Default**: "en_US" |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[RestrictionList](Models/RestrictionList.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[GetListingsRestrictionsError](Errors/GetListingsRestrictionsError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

## MerchantFulfillment

> Source: [MerchantFulfillment](Api/MerchantFulfillment.cs)

<details>
<summary><code>Task&lt;CancelShipmentResponse&gt; CancelShipment(string shipmentId, RequestOptions? requestOptions = null, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.MerchantFulfillment.CancelShipment(shipmentId);
    // TODO: Handle 'response' of type CancelShipmentResponse
}
catch (SdkException<CancelShipmentError> ex)
{
    if (ex.Error.TryGetErrorList(out var error))
    {
        // TODO: Handle 'error' of type ErrorList
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>shipmentId</code> | <code>string</code> | - |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[CancelShipmentResponse](Models/CancelShipmentResponse.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[CancelShipmentError](Errors/CancelShipmentError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;CreateShipmentResponse&gt; CreateShipment(CreateShipmentRequest body, RequestOptions? requestOptions = null, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Creates a shipment for an order, purchases a shipping label from the
selected carrier, and returns the label for printing.


</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.MerchantFulfillment.CreateShipment(body);
    // TODO: Handle 'response' of type CreateShipmentResponse
}
catch (SdkException<CreateShipmentError> ex)
{
    if (ex.Error.TryGetErrorList(out var error))
    {
        // TODO: Handle 'error' of type ErrorList
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>body</code> | <code>[CreateShipmentRequest](Models/CreateShipmentRequest.cs)</code> | - |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[CreateShipmentResponse](Models/CreateShipmentResponse.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[CreateShipmentError](Errors/CreateShipmentError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;GetEligibleShippingServicesResponse&gt; GetEligibleShippingServices(GetEligibleShippingServicesRequest body, RequestOptions? requestOptions = null, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Returns available carriers and rates for a shipment based on package
dimensions, weight, and destination address.


</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.MerchantFulfillment.GetEligibleShippingServices(body);
    // TODO: Handle 'response' of type GetEligibleShippingServicesResponse
}
catch (SdkException<GetEligibleShippingServicesError> ex)
{
    if (ex.Error.TryGetErrorList(out var error))
    {
        // TODO: Handle 'error' of type ErrorList
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>body</code> | <code>[GetEligibleShippingServicesRequest](Models/GetEligibleShippingServicesRequest.cs)</code> | - |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[GetEligibleShippingServicesResponse](Models/GetEligibleShippingServicesResponse.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[GetEligibleShippingServicesError](Errors/GetEligibleShippingServicesError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;Label&gt; GetLabel(string shipmentId, Format? format, RequestOptions? requestOptions = null, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Returns the purchased shipping label for a shipment in the requested
file format for printing.


</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.MerchantFulfillment.GetLabel(shipmentId, format);
    // TODO: Handle 'response' of type Label
}
catch (SdkException<GetLabelError> ex)
{
    if (ex.Error.TryGetErrorList(out var error))
    {
        // TODO: Handle 'error' of type ErrorList
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>shipmentId</code> | <code>string</code> | - |
| <code>format</code> | <code>[Format?](Models/Enums/Format.cs)</code> | - |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[Label](Models/Label.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[GetLabelError](Errors/GetLabelError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;GetShipmentResponse&gt; GetShipment2(string shipmentId, RequestOptions? requestOptions = null, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.MerchantFulfillment.GetShipment2(shipmentId);
    // TODO: Handle 'response' of type GetShipmentResponse
}
catch (SdkException<GetShipment2Error> ex)
{
    if (ex.Error.TryGetErrorList(out var error))
    {
        // TODO: Handle 'error' of type ErrorList
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>shipmentId</code> | <code>string</code> | - |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[GetShipmentResponse](Models/GetShipmentResponse.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[GetShipment2Error](Errors/GetShipment2Error.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

## Orders

> Source: [Orders](Api/Orders.cs)

<details>
<summary><code>Task&lt;AcknowledgeOrderResponse&gt; AcknowledgeOrder(string purchaseOrderId, AcknowledgeOrderRequest body, RequestOptions? requestOptions = null, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Orders.AcknowledgeOrder(purchaseOrderId, body);
    // TODO: Handle 'response' of type AcknowledgeOrderResponse
}
catch (SdkException<AcknowledgeOrderError> ex)
{
    if (ex.Error.TryGetErrorList(out var error))
    {
        // TODO: Handle 'error' of type ErrorList
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>purchaseOrderId</code> | <code>string</code> | - |
| <code>body</code> | <code>[AcknowledgeOrderRequest](Models/AcknowledgeOrderRequest.cs)</code> | - |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[AcknowledgeOrderResponse](Models/AcknowledgeOrderResponse.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[AcknowledgeOrderError](Errors/AcknowledgeOrderError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;CancelOrderLinesResponse&gt; CancelOrderLines(string purchaseOrderId, CancelOrderLinesRequest body, RequestOptions? requestOptions = null, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Orders.CancelOrderLines(purchaseOrderId, body);
    // TODO: Handle 'response' of type CancelOrderLinesResponse
}
catch (SdkException<CancelOrderLinesError> ex)
{
    if (ex.Error.TryGetErrorList(out var error))
    {
        // TODO: Handle 'error' of type ErrorList
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>purchaseOrderId</code> | <code>string</code> | - |
| <code>body</code> | <code>[CancelOrderLinesRequest](Models/CancelOrderLinesRequest.cs)</code> | - |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[CancelOrderLinesResponse](Models/CancelOrderLinesResponse.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[CancelOrderLinesError](Errors/CancelOrderLinesError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;DeliverOrderLinesResponse&gt; DeliverOrderLines(string purchaseOrderId, DeliverOrderLinesRequest body, RequestOptions? requestOptions = null, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Records the terminal `Delivered` event for one or more order
lines, optionally with package-level proof-of-delivery
(tracking number, package number, delivery timestamp). This is
separated from `/shipment-status` because delivery is a
terminal state and carries different downstream semantics
(invoicing windows open, return windows start).

Walmart parity from gmp-orders-mono `deliverOrder`.


</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Orders.DeliverOrderLines(purchaseOrderId, body);
    // TODO: Handle 'response' of type DeliverOrderLinesResponse
}
catch (SdkException<DeliverOrderLinesError> ex)
{
    if (ex.Error.TryGetErrorList(out var error))
    {
        // TODO: Handle 'error' of type ErrorList
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>purchaseOrderId</code> | <code>string</code> | - |
| <code>body</code> | <code>[DeliverOrderLinesRequest](Models/DeliverOrderLinesRequest.cs)</code> | - |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[DeliverOrderLinesResponse](Models/DeliverOrderLinesResponse.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[DeliverOrderLinesError](Errors/DeliverOrderLinesError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;GetOrderResponse&gt; GetOrder(string purchaseOrderId, RequestOptions? requestOptions = null, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Orders.GetOrder(purchaseOrderId);
    // TODO: Handle 'response' of type GetOrderResponse
}
catch (SdkException<GetOrderError> ex)
{
    if (ex.Error.TryGetErrorList(out var error))
    {
        // TODO: Handle 'error' of type ErrorList
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>purchaseOrderId</code> | <code>string</code> | Walmart Purchase Order ID |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[GetOrderResponse](Models/GetOrderResponse.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[GetOrderError](Errors/GetOrderError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;GetOrderAddressResponse&gt; GetOrderAddress(string purchaseOrderId, RequestOptions? requestOptions = null, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Returns the ship-to postal address for a single purchase order.
Mirrors Amazon SP-API `getOrderAddress`. PII-restricted endpoint:
handlers are marked `@RestrictedData` server-side and the
response body must NOT be logged.


</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Orders.GetOrderAddress(purchaseOrderId);
    // TODO: Handle 'response' of type GetOrderAddressResponse
}
catch (SdkException<GetOrderAddressError> ex)
{
    if (ex.Error.TryGetErrorList(out var error))
    {
        // TODO: Handle 'error' of type ErrorList
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>purchaseOrderId</code> | <code>string</code> | - |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[GetOrderAddressResponse](Models/GetOrderAddressResponse.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[GetOrderAddressError](Errors/GetOrderAddressError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;GetOrderBuyerInfoResponse&gt; GetOrderBuyerInfo(string purchaseOrderId, RequestOptions? requestOptions = null, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Returns the buyer's display name, email address, and an
anonymized phone (last 4 digits only). Mirrors Amazon SP-API
`getOrderBuyerInfo`. PII-restricted endpoint: handlers are
marked `@RestrictedData` server-side and request/response
bodies must NOT be logged.


</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Orders.GetOrderBuyerInfo(purchaseOrderId);
    // TODO: Handle 'response' of type GetOrderBuyerInfoResponse
}
catch (SdkException<GetOrderBuyerInfoError> ex)
{
    if (ex.Error.TryGetErrorList(out var error))
    {
        // TODO: Handle 'error' of type ErrorList
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>purchaseOrderId</code> | <code>string</code> | - |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[GetOrderBuyerInfoResponse](Models/GetOrderBuyerInfoResponse.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[GetOrderBuyerInfoError](Errors/GetOrderBuyerInfoError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;GetFulfillmentOrderShipmentsResponse&gt; GetOrderItems(string purchaseOrderId, RequestOptions? requestOptions = null, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Returns the SKU / quantity / item-price projection of a single
purchase order. Mirrors Amazon SP-API `getOrderItems`. Not
PII-restricted: only product, quantity, and price are returned.


</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Orders.GetOrderItems(purchaseOrderId);
    // TODO: Handle 'response' of type GetFulfillmentOrderShipmentsResponse
}
catch (SdkException<GetOrderItemsError> ex)
{
    if (ex.Error.TryGetErrorList(out var error))
    {
        // TODO: Handle 'error' of type ErrorList
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>purchaseOrderId</code> | <code>string</code> | - |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[GetFulfillmentOrderShipmentsResponse](Models/GetFulfillmentOrderShipmentsResponse.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[GetOrderItemsError](Errors/GetOrderItemsError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;GetOrderRegulatedInfoResponse&gt; GetOrderRegulatedInfo(string purchaseOrderId, RequestOptions? requestOptions = null, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Parity with Amazon SP-API Orders v0 `getOrderRegulatedInfo`. Returns
the verification requirements that apply to an order containing
regulated items (alcohol, tobacco, age-restricted goods): the
required ID-verification method, the minimum buyer age, the
regulated category, and any value-added services the order ships
with.

**Walmart OMS coverage gap .** The the underlying service Order
Lookup response does not currently surface regulated-item
metadata. Until upstream support lands (tracked separately as a
follow-up to this PR), every order returns the safe default
`regulatedCategory=NOT_REGULATED` with `requiredVerificationMethod=NONE`.
The endpoint shape and contract are stable; only the projected
values will become richer once OMS exposes the fields.


</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Orders.GetOrderRegulatedInfo(purchaseOrderId);
    // TODO: Handle 'response' of type GetOrderRegulatedInfoResponse
}
catch (SdkException<GetOrderRegulatedInfoError> ex)
{
    if (ex.Error.TryGetErrorList(out var error))
    {
        // TODO: Handle 'error' of type ErrorList
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>purchaseOrderId</code> | <code>string</code> | Walmart Purchase Order ID |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[GetOrderRegulatedInfoResponse](Models/GetOrderRegulatedInfoResponse.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[GetOrderRegulatedInfoError](Errors/GetOrderRegulatedInfoError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;GetFulfillmentOrderResponse&gt; GetOrders(DateTimeOffset? createdAfter, DateTimeOffset? createdBefore, DateTimeOffset? lastUpdatedAfter, IReadOnlyList&lt;OrderStatus&gt;? orderStatuses, IReadOnlyList&lt;FulfillmentType&gt;? fulfillmentTypes, string? nextToken, int? pageSize = 100, RequestOptions? requestOptions = null, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Returns orders matching the given filters. Orders are fulfilled by
sellers (WFS or seller-fulfilled). Maps to Walmart OMS order queries.

### Current limitations (roadmap)

The underlying the Orders service backend does not yet support
every filter declared below. Calls using any of the following will
return `400 Bad Request` with `code=FILTER_NOT_SUPPORTED` and a
human-readable `message` explaining the specific rejection. Phase
2
will lift these one-by-one as the underlying service adds capability.

| Filter | Status today | Reason |
|---|---|---|
| `createdAfter`, `createdBefore` | Rejected (400) | the Orders service does not accept date-range filters at the order level. |
| `lastUpdatedAfter` | Rejected (400) | the underlying service has no order-level update-date index. |
| `orderStatuses` with >1 value | Rejected (400) | the underlying service accepts one status per call; pass a single value or omit to match all. |
| `fulfillmentTypes` | Rejected (400) | the underlying service accepts one shipNodeType per call; multi-type fan-out is Phase 2. |

These parameters remain in the contract (rather than being removed)
so that SDKs generated today stay forward-compatible with the
the roadmap surface — your code keeps compiling, only the runtime
behaviour changes when Phase 2 ships. Until then, omit them or
handle the documented 400 gracefully. The `tools/loadgen-orders.sh --contract`
smoke sweep exercises the rejection contract on every run.


</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Orders.GetOrders(createdAfter,
        createdBefore,
        lastUpdatedAfter,
        orderStatuses,
        fulfillmentTypes,
        nextToken);
    // TODO: Handle 'response' of type GetFulfillmentOrderResponse
}
catch (SdkException<GetOrdersError> ex)
{
    if (ex.Error.TryGetErrorList(out var error))
    {
        // TODO: Handle 'error' of type ErrorList
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>createdAfter</code> | <code>DateTimeOffset?</code> | Filter orders created after this date-time (ISO 8601).<br><br>**the roadmap — not yet supported.** Sending this parameter today<br>returns `400 FILTER_NOT_SUPPORTED`; the Orders service does not<br>accept date-range filters at the order level. Tracked by<br>.<br>Retained in the contract so SDKs generated today stay<br>forward-compatible. |
| <code>createdBefore</code> | <code>DateTimeOffset?</code> | Filter orders created before this date-time (ISO 8601).<br><br>**the roadmap — not yet supported.** See `createdAfter` for the<br>rationale and the tracking ticket. |
| <code>lastUpdatedAfter</code> | <code>DateTimeOffset?</code> | Filter orders updated after this date-time (ISO 8601).<br><br>**the roadmap — not yet supported.** Sending this parameter today<br>returns `400 FILTER_NOT_SUPPORTED`; the Orders service has no<br>order-level update-date index. Tracked by<br>. |
| <code>orderStatuses</code> | <code>IReadOnlyList&lt;[OrderStatus](Models/Enums/OrderStatus.cs)&gt;?</code> | Filter by order status.<br><br>**the roadmap limitation:** the Orders service accepts AT MOST ONE<br>status per call. Passing multiple values today returns `400<br>FILTER_NOT_SUPPORTED`; pass a single value or omit to match all.<br>Multi-status fan-out tracked by<br>. |
| <code>fulfillmentTypes</code> | <code>IReadOnlyList&lt;[FulfillmentType](Models/Enums/FulfillmentType.cs)&gt;?</code> | Filter by fulfillment type.<br><br>**the roadmap — not yet supported.** Sending this parameter today<br>returns `400 FILTER_NOT_SUPPORTED`; the underlying service accepts one<br>shipNodeType per call and multi-type fan-out is Phase 2. Tracked<br>by . |
| <code>nextToken</code> | <code>string?</code> | - |
| <code>pageSize</code> | <code>int?</code> | **Default**: 100 |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[GetFulfillmentOrderResponse](Models/GetFulfillmentOrderResponse.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[GetOrdersError](Errors/GetOrdersError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;RefundOrderLinesResponse&gt; RefundOrderLines(string purchaseOrderId, RefundOrderLinesRequest body, RequestOptions? requestOptions = null, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Walmart-specific write — no Amazon SP-API Orders v0 equivalent
(Amazon refunds live in the Finance API). Mirrors
gmp-orders-mono's legacy `/partner-api/{market}/v3/orders/{po}/refund`
contract, simplified for the v4 surface: a flat `orderLines[]` with
per-line refund amount + reason instead of the legacy three-level
nesting (`orderLines → refunds → refundCharges`).


</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Orders.RefundOrderLines(purchaseOrderId, body);
    // TODO: Handle 'response' of type RefundOrderLinesResponse
}
catch (SdkException<RefundOrderLinesError> ex)
{
    if (ex.Error.TryGetErrorList(out var error))
    {
        // TODO: Handle 'error' of type ErrorList
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>purchaseOrderId</code> | <code>string</code> | - |
| <code>body</code> | <code>[RefundOrderLinesRequest](Models/RefundOrderLinesRequest.cs)</code> | - |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[RefundOrderLinesResponse](Models/RefundOrderLinesResponse.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[RefundOrderLinesError](Errors/RefundOrderLinesError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;ShipOrderLinesResponse&gt; ShipOrderLines(string purchaseOrderId, ShipOrderLinesRequest body, RequestOptions? requestOptions = null, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Orders.ShipOrderLines(purchaseOrderId, body);
    // TODO: Handle 'response' of type ShipOrderLinesResponse
}
catch (SdkException<ShipOrderLinesError> ex)
{
    if (ex.Error.TryGetErrorList(out var error))
    {
        // TODO: Handle 'error' of type ErrorList
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>purchaseOrderId</code> | <code>string</code> | - |
| <code>body</code> | <code>[ShipOrderLinesRequest](Models/ShipOrderLinesRequest.cs)</code> | - |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[ShipOrderLinesResponse](Models/ShipOrderLinesResponse.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[ShipOrderLinesError](Errors/ShipOrderLinesError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;MultiPackageShipResponse&gt; ShipOrderMultiPackage(string purchaseOrderId, MultiPackageShipRequest body, RequestOptions? requestOptions = null, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Walmart-specific extension of `/shipping`. Each package carries
its own tracking number, carrier, dimensions, and the order
lines it covers. Maps onto FMS's existing `shipments[]` envelope
(one FMS shipment per v4 package). Inspired by gmp-orders-mono's
`shipOrderV2` (multiPackageShipping) operation; we hoist
`packages[]` to the top level rather than nesting it under each
line so the request stays self-evidently package-oriented.


</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Orders.ShipOrderMultiPackage(purchaseOrderId, body);
    // TODO: Handle 'response' of type MultiPackageShipResponse
}
catch (SdkException<ShipOrderMultiPackageError> ex)
{
    if (ex.Error.TryGetErrorList(out var error))
    {
        // TODO: Handle 'error' of type ErrorList
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>purchaseOrderId</code> | <code>string</code> | - |
| <code>body</code> | <code>[MultiPackageShipRequest](Models/MultiPackageShipRequest.cs)</code> | - |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[MultiPackageShipResponse](Models/MultiPackageShipResponse.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[ShipOrderMultiPackageError](Errors/ShipOrderMultiPackageError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;UpdateShipmentStatusResponse&gt; UpdateShipmentStatus(string purchaseOrderId, UpdateShipmentStatusRequest body, RequestOptions? requestOptions = null, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Records a non-terminal shipment-lifecycle event for an order
(ready for pickup, picked up, in transit, out for delivery).
Use the dedicated `/deliver` endpoint for terminal delivery —
it carries proof-of-delivery semantics this endpoint does not.

Amazon SP-API Orders v0 `updateShipmentStatus` parity.


</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Orders.UpdateShipmentStatus(purchaseOrderId, body);
    // TODO: Handle 'response' of type UpdateShipmentStatusResponse
}
catch (SdkException<UpdateShipmentStatusError> ex)
{
    if (ex.Error.TryGetErrorList(out var error))
    {
        // TODO: Handle 'error' of type ErrorList
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>purchaseOrderId</code> | <code>string</code> | - |
| <code>body</code> | <code>[UpdateShipmentStatusRequest](Models/UpdateShipmentStatusRequest.cs)</code> | - |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[UpdateShipmentStatusResponse](Models/UpdateShipmentStatusResponse.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[UpdateShipmentStatusError](Errors/UpdateShipmentStatusError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;UpdateVerificationStatusResponse&gt; UpdateVerificationStatus(string purchaseOrderId, UpdateVerificationStatusRequest body, RequestOptions? requestOptions = null, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Parity with Amazon SP-API Orders v0 `updateVerificationStatus`. The
seller calls this after delivering a regulated-item order to
record whether the buyer's identity / age was verified at the
doorstep. An APPROVED status releases the order for settlement;
REJECTED requires a `rejectionReason` and triggers downstream
return-processing.

Gated by the CCM-managed `orders.features.regulatedInfoEnabled`
kill-switch (live-refreshable, parity with the cancel kill-switch).


</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Orders.UpdateVerificationStatus(purchaseOrderId, body);
    // TODO: Handle 'response' of type UpdateVerificationStatusResponse
}
catch (SdkException<UpdateVerificationStatusError> ex)
{
    if (ex.Error.TryGetErrorList(out var error))
    {
        // TODO: Handle 'error' of type ErrorList
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>purchaseOrderId</code> | <code>string</code> | Walmart Purchase Order ID |
| <code>body</code> | <code>[UpdateVerificationStatusRequest](Models/UpdateVerificationStatusRequest.cs)</code> | - |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[UpdateVerificationStatusResponse](Models/UpdateVerificationStatusResponse.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[UpdateVerificationStatusError](Errors/UpdateVerificationStatusError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

## Payouts

> Source: [Payouts](Api/Payouts.cs)

<details>
<summary><code>Task&lt;PayoutStatusResponse&gt; ConfigureAutoPayout(DisbursementsV4PaymentAutoPayoutRequest body, RequestOptions? requestOptions = null, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Enables or disables automatic scheduled payouts for the authenticated seller.
When enabled, payouts are triggered automatically on the standard settlement
cadence. Returns updated payout status. Requires disbursements:write scope.
Delegates to GMPPaymentsPlatform (Phase 5).


</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Payouts.ConfigureAutoPayout(body);
    // TODO: Handle 'response' of type PayoutStatusResponse
}
catch (SdkException<ConfigureAutoPayoutError> ex)
{
    if (ex.Error.TryGetErrorList(out var error))
    {
        // TODO: Handle 'error' of type ErrorList
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>body</code> | <code>[DisbursementsV4PaymentAutoPayoutRequest](Models/DisbursementsV4PaymentAutoPayoutRequest.cs)</code> | - |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[PayoutStatusResponse](Models/PayoutStatusResponse.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[ConfigureAutoPayoutError](Errors/ConfigureAutoPayoutError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;AnnualStatementOptsResponse&gt; GetAnnualStatementOpts(RequestOptions? requestOptions = null, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Returns whether the authenticated seller is opted in to annual statement
generation and the current statement year. Delegates to GMPPaymentsPlatform
GET /annualStatementOpts/{partnerId}.


</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Payouts.GetAnnualStatementOpts();
    // TODO: Handle 'response' of type AnnualStatementOptsResponse
}
catch (SdkException<GetAnnualStatementOptsError> ex)
{
    if (ex.Error.TryGetErrorList(out var error))
    {
        // TODO: Handle 'error' of type ErrorList
    }
}
```

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[AnnualStatementOptsResponse](Models/AnnualStatementOptsResponse.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[GetAnnualStatementOptsError](Errors/GetAnnualStatementOptsError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;FasterPayoutEligibilityResponse&gt; GetFasterPayoutEligibility(RequestOptions? requestOptions = null, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Returns whether the authenticated seller is eligible for an on-demand
faster payout, along with the approved amount and any ineligibility reason.
Delegates to GMPPaymentsPlatform GET /fasterPayout/eligibility/{partnerId}.


</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Payouts.GetFasterPayoutEligibility();
    // TODO: Handle 'response' of type FasterPayoutEligibilityResponse
}
catch (SdkException<GetFasterPayoutEligibilityError> ex)
{
    if (ex.Error.TryGetErrorList(out var error))
    {
        // TODO: Handle 'error' of type ErrorList
    }
}
```

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[FasterPayoutEligibilityResponse](Models/FasterPayoutEligibilityResponse.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[GetFasterPayoutEligibilityError](Errors/GetFasterPayoutEligibilityError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;PayoutStatusResponse&gt; GetPaymentStatus(RequestOptions? requestOptions = null, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Returns the current payout status for the authenticated seller, including
scheduled payout date, amount, and lifecycle state (Pending, Processing,
Completed, Failed, OnHold). Delegates to GMPPaymentsPlatform (Phase 5).


</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Payouts.GetPaymentStatus();
    // TODO: Handle 'response' of type PayoutStatusResponse
}
catch (SdkException<GetPaymentStatusError> ex)
{
    if (ex.Error.TryGetErrorList(out var error))
    {
        // TODO: Handle 'error' of type ErrorList
    }
}
```

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[PayoutStatusResponse](Models/PayoutStatusResponse.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[GetPaymentStatusError](Errors/GetPaymentStatusError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;InitiatePayoutResponse&gt; InitiateFasterPayout(RequestOptions? requestOptions = null, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Triggers an immediate on-demand payout for the authenticated seller,
bypassing the standard settlement schedule. Returns the payout ID and
initial status. Requires disbursements:write scope.
Delegates to GMPPaymentsPlatform (Phase 5).


</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Payouts.InitiateFasterPayout();
    // TODO: Handle 'response' of type InitiatePayoutResponse
}
catch (SdkException<InitiateFasterPayoutError> ex)
{
    if (ex.Error.TryGetErrorList(out var error))
    {
        // TODO: Handle 'error' of type ErrorList
    }
}
```

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[InitiatePayoutResponse](Models/InitiatePayoutResponse.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[InitiateFasterPayoutError](Errors/InitiateFasterPayoutError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

## ProductTypeDefinitions

> Source: [ProductTypeDefinitions](Api/ProductTypeDefinitions.cs)

<details>
<summary><code>Task&lt;ProductTypeDefinition&gt; GetDefinitionsProductType(string productType, string? sellerId, string? locale = "en_US", RequestOptions? requestOptions = null, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

**Placeholder — not yet implemented.**

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.ProductTypeDefinitions.GetDefinitionsProductType(productType, sellerId);
    // TODO: Handle 'response' of type ProductTypeDefinition
}
catch (SdkException<GetDefinitionsProductTypeError> ex)
{
    if (ex.Error.TryGetErrorList(out var error))
    {
        // TODO: Handle 'error' of type ErrorList
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>productType</code> | <code>string</code> | - |
| <code>sellerId</code> | <code>string?</code> | - |
| <code>locale</code> | <code>string?</code> | **Default**: "en_US" |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[ProductTypeDefinition](Models/ProductTypeDefinition.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[GetDefinitionsProductTypeError](Errors/GetDefinitionsProductTypeError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;ProductTypeList&gt; SearchDefinitionsProductTypes(string? keywords, string? itemName, string? locale = "en_US", RequestOptions? requestOptions = null, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

**Placeholder — not yet implemented.**

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.ProductTypeDefinitions.SearchDefinitionsProductTypes(keywords, itemName);
    // TODO: Handle 'response' of type ProductTypeList
}
catch (SdkException<SearchDefinitionsProductTypesError> ex)
{
    if (ex.Error.TryGetErrorList(out var error))
    {
        // TODO: Handle 'error' of type ErrorList
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>keywords</code> | <code>string?</code> | - |
| <code>itemName</code> | <code>string?</code> | - |
| <code>locale</code> | <code>string?</code> | **Default**: "en_US" |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[ProductTypeList](Models/ProductTypeList.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[SearchDefinitionsProductTypesError](Errors/SearchDefinitionsProductTypesError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

## Reconciliation

> Source: [Reconciliation](Api/Reconciliation.cs)

<details>
<summary><code>Task&lt;ReportAvailabilityResponse&gt; CheckDownloadReportByPeriod(string partnerId, DateTimeOffset date, RequestOptions? requestOptions = null, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Checks which reconciliation report versions (legacy, v1/WFS) are available
for a given partner and date. Delegates to mp-payment-reporting
GET /v3/report/reconreport/reconReportAvailability.
Note: the upstream date param is named `date` (not `reportDate`).


</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Reconciliation.CheckDownloadReportByPeriod(partnerId, date);
    // TODO: Handle 'response' of type ReportAvailabilityResponse
}
catch (SdkException<CheckDownloadReportByPeriodError> ex)
{
    if (ex.Error.TryGetErrorList(out var error))
    {
        // TODO: Handle 'error' of type ErrorList
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>partnerId</code> | <code>string</code> | Numeric partner/seller ID |
| <code>date</code> | <code>DateTimeOffset</code> | Report date in yyyy-MM-dd format |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[ReportAvailabilityResponse](Models/ReportAvailabilityResponse.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[CheckDownloadReportByPeriodError](Errors/CheckDownloadReportByPeriodError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;BinaryContent&gt; DownloadReconciliationReport(string partnerId, string reportDate, RequestOptions? requestOptions = null, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Downloads a reconciliation report ZIP for the given partner and date.
Delegates to mp-payment-reporting GET /v1/mt/report/reconreport/reconFile (Azure MT storage).


</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Reconciliation.DownloadReconciliationReport(partnerId, reportDate);
    // TODO: Handle 'response' of type BinaryContent
}
catch (SdkException<DownloadReconciliationReportError> ex)
{
    if (ex.Error.TryGetErrorList(out var error))
    {
        // TODO: Handle 'error' of type ErrorList
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>partnerId</code> | <code>string</code> | Numeric partner/seller ID |
| <code>reportDate</code> | <code>string</code> | Report date in MMddyyyy format (e.g. 06172026) |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>BinaryContent</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[DownloadReconciliationReportError](Errors/DownloadReconciliationReportError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;ReportAvailabilityResponse&gt; ListReconciliationDates(string partnerId, RequestOptions? requestOptions = null, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Returns the set of available reconciliation report dates for a partner.
Delegates to mp-payment-reporting GET /v3/report/reconreport/availableReconFiles.


</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Reconciliation.ListReconciliationDates(partnerId);
    // TODO: Handle 'response' of type ReportAvailabilityResponse
}
catch (SdkException<ListReconciliationDatesError> ex)
{
    if (ex.Error.TryGetErrorList(out var error))
    {
        // TODO: Handle 'error' of type ErrorList
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>partnerId</code> | <code>string</code> | Numeric partner/seller ID |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[ReportAvailabilityResponse](Models/ReportAvailabilityResponse.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[ListReconciliationDatesError](Errors/ListReconciliationDatesError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

## ReportSchedules

> Source: [ReportSchedules](Api/ReportSchedules.cs)

<details>
<summary><code>Task&lt;CancelReportScheduleResponse&gt; CancelReportSchedule(string reportScheduleId, RequestOptions? requestOptions = null, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.ReportSchedules.CancelReportSchedule(reportScheduleId);
    // TODO: Handle 'response' of type CancelReportScheduleResponse
}
catch (SdkException<CancelReportScheduleError> ex)
{
    if (ex.Error.TryGetErrorList(out var error))
    {
        // TODO: Handle 'error' of type ErrorList
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>reportScheduleId</code> | <code>string</code> | - |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[CancelReportScheduleResponse](Models/CancelReportScheduleResponse.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[CancelReportScheduleError](Errors/CancelReportScheduleError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;CreateReportScheduleResponse&gt; CreateReportSchedule(CreateReportScheduleSpecification body, RequestOptions? requestOptions = null, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.ReportSchedules.CreateReportSchedule(body);
    // TODO: Handle 'response' of type CreateReportScheduleResponse
}
catch (SdkException<CreateReportScheduleError> ex)
{
    if (ex.Error.TryGetErrorList(out var error))
    {
        // TODO: Handle 'error' of type ErrorList
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>body</code> | <code>[CreateReportScheduleSpecification](Models/CreateReportScheduleSpecification.cs)</code> | - |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[CreateReportScheduleResponse](Models/CreateReportScheduleResponse.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[CreateReportScheduleError](Errors/CreateReportScheduleError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;ReportSchedule&gt; GetReportSchedule(string reportScheduleId, RequestOptions? requestOptions = null, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.ReportSchedules.GetReportSchedule(reportScheduleId);
    // TODO: Handle 'response' of type ReportSchedule
}
catch (SdkException<GetReportScheduleError> ex)
{
    if (ex.Error.TryGetErrorList(out var error))
    {
        // TODO: Handle 'error' of type ErrorList
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>reportScheduleId</code> | <code>string</code> | - |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[ReportSchedule](Models/ReportSchedule.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[GetReportScheduleError](Errors/GetReportScheduleError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;GetReportSchedulesResponse&gt; GetReportSchedules(IReadOnlyList&lt;ReportType1&gt;? reportTypes, RequestOptions? requestOptions = null, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.ReportSchedules.GetReportSchedules(reportTypes);
    // TODO: Handle 'response' of type GetReportSchedulesResponse
}
catch (SdkException<GetReportSchedulesError> ex)
{
    if (ex.Error.TryGetErrorList(out var error))
    {
        // TODO: Handle 'error' of type ErrorList
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>reportTypes</code> | <code>IReadOnlyList&lt;[ReportType1](Models/Enums/ReportType1.cs)&gt;?</code> | Filter by report type. Values are Walmart Partner Reporting Platform enum names. Runtime availability is CCM-controlled; consult PRP docs for current PROD-enabled types. |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[GetReportSchedulesResponse](Models/GetReportSchedulesResponse.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[GetReportSchedulesError](Errors/GetReportSchedulesError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

## Reports

> Source: [Reports](Api/Reports.cs)

<details>
<summary><code>Task&lt;CancelReportResponse&gt; CancelReport(string reportId, RequestOptions? requestOptions = null, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Reports.CancelReport(reportId);
    // TODO: Handle 'response' of type CancelReportResponse
}
catch (SdkException<CancelReportError> ex)
{
    if (ex.Error.TryGetErrorList(out var error))
    {
        // TODO: Handle 'error' of type ErrorList
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>reportId</code> | <code>string</code> | - |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[CancelReportResponse](Models/CancelReportResponse.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[CancelReportError](Errors/CancelReportError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;CreateReportResponse&gt; CreateReport(CreateReportSpecification body, RequestOptions? requestOptions = null, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Submits a report request. Poll `GET /reports/{reportId}` for status.
Report type taxonomy TBD — coordinate with Pod 5 for financial reports.


</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Reports.CreateReport(body);
    // TODO: Handle 'response' of type CreateReportResponse
}
catch (SdkException<CreateReportError> ex)
{
    if (ex.Error.TryGetErrorList(out var error))
    {
        // TODO: Handle 'error' of type ErrorList
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>body</code> | <code>[CreateReportSpecification](Models/CreateReportSpecification.cs)</code> | - |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[CreateReportResponse](Models/CreateReportResponse.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[CreateReportError](Errors/CreateReportError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;BinaryContent&gt; DownloadNewReport(string partnerId, string reportDate, RequestOptions? requestOptions = null, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Downloads the current-format settlement summary report ZIP.
Delegates to mp-payment-reporting GET /v3/report/reconreport/v1/reconFile (Swift v1 storage).


</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Reports.DownloadNewReport(partnerId, reportDate);
    // TODO: Handle 'response' of type BinaryContent
}
catch (SdkException<DownloadNewReportError> ex)
{
    if (ex.Error.TryGetErrorList(out var error))
    {
        // TODO: Handle 'error' of type ErrorList
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>partnerId</code> | <code>string</code> | Numeric partner/seller ID |
| <code>reportDate</code> | <code>string</code> | Report date in MMddyyyy format (e.g. 06172026) |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>BinaryContent</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[DownloadNewReportError](Errors/DownloadNewReportError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;BinaryContent&gt; DownloadOldReport(string partnerId, string reportDate, RequestOptions? requestOptions = null, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Downloads the legacy-format settlement summary report ZIP.
Delegates to mp-payment-reporting GET /v3/report/reconreport/reconFile (legacy Swift storage).


</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Reports.DownloadOldReport(partnerId, reportDate);
    // TODO: Handle 'response' of type BinaryContent
}
catch (SdkException<DownloadOldReportError> ex)
{
    if (ex.Error.TryGetErrorList(out var error))
    {
        // TODO: Handle 'error' of type ErrorList
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>partnerId</code> | <code>string</code> | Numeric partner/seller ID |
| <code>reportDate</code> | <code>string</code> | Report date in MMddyyyy format (e.g. 06172026) |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>BinaryContent</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[DownloadOldReportError](Errors/DownloadOldReportError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;Report&gt; GetReport(string reportId, RequestOptions? requestOptions = null, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Reports.GetReport(reportId);
    // TODO: Handle 'response' of type Report
}
catch (SdkException<GetReportError> ex)
{
    if (ex.Error.TryGetErrorList(out var error))
    {
        // TODO: Handle 'error' of type ErrorList
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>reportId</code> | <code>string</code> | - |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[Report](Models/Report.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[GetReportError](Errors/GetReportError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;ReportDocument&gt; GetReportDocument(string reportDocumentId, RequestOptions? requestOptions = null, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Returns a pre-signed URL for downloading the completed report.
Do not log the pre-signed URL.


</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Reports.GetReportDocument(reportDocumentId);
    // TODO: Handle 'response' of type ReportDocument
}
catch (SdkException<GetReportDocumentError> ex)
{
    if (ex.Error.TryGetErrorList(out var error))
    {
        // TODO: Handle 'error' of type ErrorList
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>reportDocumentId</code> | <code>string</code> | - |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[ReportDocument](Models/ReportDocument.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[GetReportDocumentError](Errors/GetReportDocumentError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;GetReportsResponse&gt; GetReports(IReadOnlyList&lt;ReportType1&gt;? reportTypes, IReadOnlyList&lt;ProcessingStatus&gt;? processingStatuses, DateTimeOffset? createdSince, DateTimeOffset? createdUntil, string? nextToken, int? pageSize = 10, RequestOptions? requestOptions = null, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Reports.GetReports(reportTypes,
        processingStatuses,
        createdSince,
        createdUntil,
        nextToken);
    // TODO: Handle 'response' of type GetReportsResponse
}
catch (SdkException<GetReportsError> ex)
{
    if (ex.Error.TryGetErrorList(out var error))
    {
        // TODO: Handle 'error' of type ErrorList
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>reportTypes</code> | <code>IReadOnlyList&lt;[ReportType1](Models/Enums/ReportType1.cs)&gt;?</code> | Filter by report type. Values are Walmart Partner Reporting Platform enum names. Runtime availability is CCM-controlled; consult PRP docs for current PROD-enabled types. |
| <code>processingStatuses</code> | <code>IReadOnlyList&lt;[ProcessingStatus](Models/Enums/ProcessingStatus.cs)&gt;?</code> | - |
| <code>createdSince</code> | <code>DateTimeOffset?</code> | - |
| <code>createdUntil</code> | <code>DateTimeOffset?</code> | - |
| <code>nextToken</code> | <code>string?</code> | - |
| <code>pageSize</code> | <code>int?</code> | **Default**: 10 |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[GetReportsResponse](Models/GetReportsResponse.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[GetReportsError](Errors/GetReportsError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

## Sellers

> Source: [Sellers](Api/Sellers.cs)

<details>
<summary><code>Task&lt;SellerAccount&gt; GetAccount(RequestOptions? requestOptions = null, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Returns the authenticated seller's account information including
business name, email, account status, and seller type.


</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Sellers.GetAccount();
    // TODO: Handle 'response' of type SellerAccount
}
catch (SdkException<GetAccountError> ex)
{
    if (ex.Error.TryGetErrorList(out var error))
    {
        // TODO: Handle 'error' of type ErrorList
    }
}
```

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[SellerAccount](Models/SellerAccount.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[GetAccountError](Errors/GetAccountError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;GetMarketplaceParticipationsResponse&gt; GetMarketplaceParticipations(RequestOptions? requestOptions = null, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Returns the list of marketplaces the authenticated seller participates in
(e.g. Walmart US, Walmart Canada, Walmart Mexico).


</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Sellers.GetMarketplaceParticipations();
    // TODO: Handle 'response' of type GetMarketplaceParticipationsResponse
}
catch (SdkException<GetMarketplaceParticipationsError> ex)
{
    if (ex.Error.TryGetErrorList(out var error))
    {
        // TODO: Handle 'error' of type ErrorList
    }
}
```

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[GetMarketplaceParticipationsResponse](Models/GetMarketplaceParticipationsResponse.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[GetMarketplaceParticipationsError](Errors/GetMarketplaceParticipationsError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

## Settlement

> Source: [Settlement](Api/Settlement.cs)

<details>
<summary><code>Task&lt;SettlementDetailsResponse&gt; ListSettlementDetails(string partnerId, string reportDate, string? nextToken, int? pageSize = 10, RequestOptions? requestOptions = null, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Returns paginated settlement transaction detail for the given partner and report date.
Contains PII (purchase order IDs). Delegates to mp-payment-reporting
GET /v3/report/reconreport/v1/getJson with offset-based pagination.
nextToken is a Base64-encoded offset into the report file.


</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Settlement.ListSettlementDetails(partnerId, reportDate, nextToken);
    // TODO: Handle 'response' of type SettlementDetailsResponse
}
catch (SdkException<ListSettlementDetailsError> ex)
{
    if (ex.Error.TryGetErrorList(out var error))
    {
        // TODO: Handle 'error' of type ErrorList
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>partnerId</code> | <code>string</code> | Numeric partner/seller ID |
| <code>reportDate</code> | <code>string</code> | Report date in MMddyyyy format (e.g. 06172026) |
| <code>nextToken</code> | <code>string?</code> | Opaque cursor from a prior response; omit for first page |
| <code>pageSize</code> | <code>int?</code> | **Default**: 10 |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[SettlementDetailsResponse](Models/SettlementDetailsResponse.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[ListSettlementDetailsError](Errors/ListSettlementDetailsError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;SettlementPeriodsResponse&gt; ListSettlementPeriods(string? nextToken, int? pageSize = 10, RequestOptions? requestOptions = null, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Returns available settlement period dates for the authenticated seller.
Delegates to mp-payment-reporting GET /v3/report/reconreport/v1/availableReconFiles.


</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Settlement.ListSettlementPeriods(nextToken);
    // TODO: Handle 'response' of type SettlementPeriodsResponse
}
catch (SdkException<ListSettlementPeriodsError> ex)
{
    if (ex.Error.TryGetErrorList(out var error))
    {
        // TODO: Handle 'error' of type ErrorList
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>nextToken</code> | <code>string?</code> | Opaque cursor from a prior response; omit for first page |
| <code>pageSize</code> | <code>int?</code> | **Default**: 10 |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[SettlementPeriodsResponse](Models/SettlementPeriodsResponse.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[ListSettlementPeriodsError](Errors/ListSettlementPeriodsError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;TransactionSearchResponse&gt; SearchTransactions(string? nextToken, DateTimeOffset? postedAfter, DateTimeOffset? postedBefore, int? pageSize = 10, RequestOptions? requestOptions = null, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Returns a paginated list of payment transactions for the authenticated seller
filtered by optional date range. Contains PII (purchase order IDs).
Delegates to GMPPaymentsPlatform (Phase 5).


</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Settlement.SearchTransactions(nextToken, postedAfter, postedBefore);
    // TODO: Handle 'response' of type TransactionSearchResponse
}
catch (SdkException<SearchTransactionsError> ex)
{
    if (ex.Error.TryGetErrorList(out var error))
    {
        // TODO: Handle 'error' of type ErrorList
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>nextToken</code> | <code>string?</code> | Opaque cursor from a prior response; omit for first page |
| <code>postedAfter</code> | <code>DateTimeOffset?</code> | - |
| <code>postedBefore</code> | <code>DateTimeOffset?</code> | - |
| <code>pageSize</code> | <code>int?</code> | **Default**: 10 |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[TransactionSearchResponse](Models/TransactionSearchResponse.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[SearchTransactionsError](Errors/SearchTransactionsError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

## Uploads

> Source: [Uploads](Api/Uploads.cs)

<details>
<summary><code>Task&lt;CreateUploadDestinationResponse&gt; CreateUploadDestinationForResource(Resource resource, ContentType1 contentType, IReadOnlyList&lt;string&gt; marketplaceIds, string contentMd5, RequestOptions? requestOptions = null, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Returns a pre-signed URL and upload destination ID for uploading
a document for the given resource (e.g. feeds, reports).
**Do not log the pre-signed URL — it contains temporary credentials.**


</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Uploads.CreateUploadDestinationForResource(resource,
        contentType,
        marketplaceIds,
        contentMd5);
    // TODO: Handle 'response' of type CreateUploadDestinationResponse
}
catch (SdkException<CreateUploadDestinationForResourceError> ex)
{
    if (ex.Error.TryGetErrorList(out var error))
    {
        // TODO: Handle 'error' of type ErrorList
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>resource</code> | <code>[Resource](Models/Enums/Resource.cs)</code> | The resource type for the upload destination (e.g. feeds) |
| <code>contentType</code> | <code>[ContentType1](Models/Enums/ContentType1.cs)</code> | MIME type of the content to be uploaded |
| <code>marketplaceIds</code> | <code>IReadOnlyList&lt;string&gt;</code> | - |
| <code>contentMd5</code> | <code>string</code> | MD5 hash of the content to be uploaded, encoded as base64 |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[CreateUploadDestinationResponse](Models/CreateUploadDestinationResponse.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[CreateUploadDestinationForResourceError](Errors/CreateUploadDestinationForResourceError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

## WfsInventory

> Source: [WfsInventory](Api/WfsInventory.cs)

<details>
<summary><code>Task&lt;GetWfsInventoryResponse&gt; GetWfsInventoryItems(string? skus, string? nextToken, int? pageSize = 100, RequestOptions? requestOptions = null, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Returns inventory for items managed by Walmart Fulfillment Services (WFS).
Includes stock health, age buckets, and demand-intelligence fields
not available on seller-fulfilled inventory.

**Rate limit:** 300 items per page maximum.
Requests retrieving more than 100 items per page will receive
`X-RateLimit-Limit` and `X-RateLimit-Remaining` headers in the response.


</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.WfsInventory.GetWfsInventoryItems(skus, nextToken);
    // TODO: Handle 'response' of type GetWfsInventoryResponse
}
catch (SdkException<GetWfsInventoryItemsError> ex)
{
    if (ex.Error.TryGetErrorList(out var error))
    {
        // TODO: Handle 'error' of type ErrorList
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>skus</code> | <code>string?</code> | Comma-separated seller SKUs to filter (max 50). Omit to return all WFS items. |
| <code>nextToken</code> | <code>string?</code> | - |
| <code>pageSize</code> | <code>int?</code> | **Default**: 100 |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[GetWfsInventoryResponse](Models/GetWfsInventoryResponse.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[GetWfsInventoryItemsError](Errors/GetWfsInventoryItemsError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

## Messaging

> Source: [Messaging](Api/Messaging.cs)

<details>
<summary><code>Task&lt;object&gt; CreateWarranty(string spApiOrderId, IReadOnlyList&lt;string&gt; marketplaceIds, object body, RequestOptions? requestOptions = null, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Messaging.CreateWarranty(spApiOrderId, marketplaceIds, body);
    // TODO: Handle 'response' of type object
}
catch (SdkException<CreateWarrantyError> ex)
{
    if (ex.Error.TryGetErrorList(out var error))
    {
        // TODO: Handle 'error' of type ErrorList
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>spApiOrderId</code> | <code>string</code> | A marketplace order identifier. This identifies the order for which a message is sent. |
| <code>marketplaceIds</code> | <code>IReadOnlyList&lt;string&gt;</code> | A marketplace identifier. This identifies the marketplace in which the order was placed. You can only specify one market |
| <code>body</code> | <code>object</code> | - |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>object</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[CreateWarrantyError](Errors/CreateWarrantyError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;object&gt; GetAttributes(string spApiOrderId, IReadOnlyList&lt;string&gt; marketplaceIds, RequestOptions? requestOptions = null, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Messaging.GetAttributes(spApiOrderId, marketplaceIds);
    // TODO: Handle 'response' of type object
}
catch (SdkException<GetAttributesError> ex)
{
    if (ex.Error.TryGetErrorList(out var error))
    {
        // TODO: Handle 'error' of type ErrorList
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>spApiOrderId</code> | <code>string</code> | A marketplace order identifier. This identifies the order for which a message is sent. |
| <code>marketplaceIds</code> | <code>IReadOnlyList&lt;string&gt;</code> | A marketplace identifier. This identifies the marketplace in which the order was placed. You can only specify one market |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>object</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[GetAttributesError](Errors/GetAttributesError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;object&gt; ConfirmCustomizationDetails(string spApiOrderId, IReadOnlyList&lt;string&gt; marketplaceIds, object body, RequestOptions? requestOptions = null, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Messaging.ConfirmCustomizationDetails(spApiOrderId, marketplaceIds, body);
    // TODO: Handle 'response' of type object
}
catch (SdkException<ConfirmCustomizationDetailsError> ex)
{
    if (ex.Error.TryGetErrorList(out var error))
    {
        // TODO: Handle 'error' of type ErrorList
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>spApiOrderId</code> | <code>string</code> | A marketplace order identifier. This identifies the order for which a message is sent. |
| <code>marketplaceIds</code> | <code>IReadOnlyList&lt;string&gt;</code> | A marketplace identifier. This identifies the marketplace in which the order was placed. You can only specify one market |
| <code>body</code> | <code>object</code> | - |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>object</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[ConfirmCustomizationDetailsError](Errors/ConfirmCustomizationDetailsError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;object&gt; CreateConfirmDeliveryDetails(string spApiOrderId, IReadOnlyList&lt;string&gt; marketplaceIds, object body, RequestOptions? requestOptions = null, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Messaging.CreateConfirmDeliveryDetails(spApiOrderId, marketplaceIds, body);
    // TODO: Handle 'response' of type object
}
catch (SdkException<CreateConfirmDeliveryDetailsError> ex)
{
    if (ex.Error.TryGetErrorList(out var error))
    {
        // TODO: Handle 'error' of type ErrorList
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>spApiOrderId</code> | <code>string</code> | A marketplace order identifier. This identifies the order for which a message is sent. |
| <code>marketplaceIds</code> | <code>IReadOnlyList&lt;string&gt;</code> | A marketplace identifier. This identifies the marketplace in which the order was placed. You can only specify one market |
| <code>body</code> | <code>object</code> | - |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>object</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[CreateConfirmDeliveryDetailsError](Errors/CreateConfirmDeliveryDetailsError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;object&gt; CreateConfirmOrderDetails(string spApiOrderId, IReadOnlyList&lt;string&gt; marketplaceIds, object body, RequestOptions? requestOptions = null, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Messaging.CreateConfirmOrderDetails(spApiOrderId, marketplaceIds, body);
    // TODO: Handle 'response' of type object
}
catch (SdkException<CreateConfirmOrderDetailsError> ex)
{
    if (ex.Error.TryGetErrorList(out var error))
    {
        // TODO: Handle 'error' of type ErrorList
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>spApiOrderId</code> | <code>string</code> | A marketplace order identifier. This identifies the order for which a message is sent. |
| <code>marketplaceIds</code> | <code>IReadOnlyList&lt;string&gt;</code> | A marketplace identifier. This identifies the marketplace in which the order was placed. You can only specify one market |
| <code>body</code> | <code>object</code> | - |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>object</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[CreateConfirmOrderDetailsError](Errors/CreateConfirmOrderDetailsError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;object&gt; CreateConfirmServiceDetails(string spApiOrderId, IReadOnlyList&lt;string&gt; marketplaceIds, object body, RequestOptions? requestOptions = null, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Messaging.CreateConfirmServiceDetails(spApiOrderId, marketplaceIds, body);
    // TODO: Handle 'response' of type object
}
catch (SdkException<CreateConfirmServiceDetailsError> ex)
{
    if (ex.Error.TryGetErrorList(out var error))
    {
        // TODO: Handle 'error' of type ErrorList
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>spApiOrderId</code> | <code>string</code> | A marketplace order identifier. This identifies the order for which a message is sent. |
| <code>marketplaceIds</code> | <code>IReadOnlyList&lt;string&gt;</code> | A marketplace identifier. This identifies the marketplace in which the order was placed. You can only specify one market |
| <code>body</code> | <code>object</code> | - |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>object</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[CreateConfirmServiceDetailsError](Errors/CreateConfirmServiceDetailsError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;object&gt; CreateDigitalAccessKey(string spApiOrderId, IReadOnlyList&lt;string&gt; marketplaceIds, object body, RequestOptions? requestOptions = null, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Messaging.CreateDigitalAccessKey(spApiOrderId, marketplaceIds, body);
    // TODO: Handle 'response' of type object
}
catch (SdkException<CreateDigitalAccessKeyError> ex)
{
    if (ex.Error.TryGetErrorList(out var error))
    {
        // TODO: Handle 'error' of type ErrorList
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>spApiOrderId</code> | <code>string</code> | A marketplace order identifier. This identifies the order for which a message is sent. |
| <code>marketplaceIds</code> | <code>IReadOnlyList&lt;string&gt;</code> | A marketplace identifier. This identifies the marketplace in which the order was placed. You can only specify one market |
| <code>body</code> | <code>object</code> | - |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>object</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[CreateDigitalAccessKeyError](Errors/CreateDigitalAccessKeyError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;object&gt; CreateLegalDisclosure(string spApiOrderId, IReadOnlyList&lt;string&gt; marketplaceIds, object body, RequestOptions? requestOptions = null, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Messaging.CreateLegalDisclosure(spApiOrderId, marketplaceIds, body);
    // TODO: Handle 'response' of type object
}
catch (SdkException<CreateLegalDisclosureError> ex)
{
    if (ex.Error.TryGetErrorList(out var error))
    {
        // TODO: Handle 'error' of type ErrorList
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>spApiOrderId</code> | <code>string</code> | A marketplace order identifier. This identifies the order for which a message is sent. |
| <code>marketplaceIds</code> | <code>IReadOnlyList&lt;string&gt;</code> | A marketplace identifier. This identifies the marketplace in which the order was placed. You can only specify one market |
| <code>body</code> | <code>object</code> | - |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>object</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[CreateLegalDisclosureError](Errors/CreateLegalDisclosureError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;object&gt; CreateUnexpectedProblem(string spApiOrderId, IReadOnlyList&lt;string&gt; marketplaceIds, object body, RequestOptions? requestOptions = null, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Messaging.CreateUnexpectedProblem(spApiOrderId, marketplaceIds, body);
    // TODO: Handle 'response' of type object
}
catch (SdkException<CreateUnexpectedProblemError> ex)
{
    if (ex.Error.TryGetErrorList(out var error))
    {
        // TODO: Handle 'error' of type ErrorList
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>spApiOrderId</code> | <code>string</code> | A marketplace order identifier. This identifies the order for which a message is sent. |
| <code>marketplaceIds</code> | <code>IReadOnlyList&lt;string&gt;</code> | A marketplace identifier. This identifies the marketplace in which the order was placed. You can only specify one market |
| <code>body</code> | <code>object</code> | - |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>object</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[CreateUnexpectedProblemError](Errors/CreateUnexpectedProblemError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;object&gt; GetMessagingActionsForOrder(string spApiOrderId, IReadOnlyList&lt;string&gt; marketplaceIds, RequestOptions? requestOptions = null, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Messaging.GetMessagingActionsForOrder(spApiOrderId, marketplaceIds);
    // TODO: Handle 'response' of type object
}
catch (SdkException<GetMessagingActionsForOrderError> ex)
{
    if (ex.Error.TryGetErrorList(out var error))
    {
        // TODO: Handle 'error' of type ErrorList
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>spApiOrderId</code> | <code>string</code> | A marketplace order identifier. This specifies the order for which you want a list of available message types. |
| <code>marketplaceIds</code> | <code>IReadOnlyList&lt;string&gt;</code> | A marketplace identifier. This identifies the marketplace in which the order was placed. You can only specify one market |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>object</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[GetMessagingActionsForOrderError](Errors/GetMessagingActionsForOrderError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;object&gt; SendInvoice(string spApiOrderId, IReadOnlyList&lt;string&gt; marketplaceIds, object body, RequestOptions? requestOptions = null, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Messaging.SendInvoice(spApiOrderId, marketplaceIds, body);
    // TODO: Handle 'response' of type object
}
catch (SdkException<SendInvoiceError> ex)
{
    if (ex.Error.TryGetErrorList(out var error))
    {
        // TODO: Handle 'error' of type ErrorList
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>spApiOrderId</code> | <code>string</code> | A marketplace order identifier. This identifies the order for which a message is sent. |
| <code>marketplaceIds</code> | <code>IReadOnlyList&lt;string&gt;</code> | A marketplace identifier. This identifies the marketplace in which the order was placed. You can only specify one market |
| <code>body</code> | <code>object</code> | - |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>object</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[SendInvoiceError](Errors/SendInvoiceError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

## Notifications

> Source: [Notifications](Api/Notifications.cs)

<details>
<summary><code>Task&lt;Channel&gt; CreateDestination(object body, RequestOptions? requestOptions = null, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Notifications.CreateDestination(body);
    // TODO: Handle 'response' of type Channel
}
catch (SdkException<CreateDestinationError> ex)
{
    if (ex.Error.TryGetNoContent(out var error))
    {
        // TODO: Handle 'error' of type RawError
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>body</code> | <code>object</code> | - |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[Channel](Models/Channel.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[CreateDestinationError](Errors/CreateDestinationError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;object&gt; CreateSubscription(string notificationType, object body, RequestOptions? requestOptions = null, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Notifications.CreateSubscription(notificationType, body);
    // TODO: Handle 'response' of type object
}
catch (SdkException<CreateSubscriptionError> ex)
{
    if (ex.Error.TryGetNoContent(out var error))
    {
        // TODO: Handle 'error' of type RawError
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>notificationType</code> | <code>string</code> | The type of notification. Must be one of: EMAIL, WEBHOOKS, SMS, PULL, MOBILE_PUSH. |
| <code>body</code> | <code>object</code> | - |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>object</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[CreateSubscriptionError](Errors/CreateSubscriptionError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;Channel&gt; DeleteDestination(string destinationId, RequestOptions? requestOptions = null, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Notifications.DeleteDestination(destinationId);
    // TODO: Handle 'response' of type Channel
}
catch (SdkException<DeleteDestinationError> ex)
{
    if (ex.Error.TryGetNoContent(out var error))
    {
        // TODO: Handle 'error' of type RawError
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>destinationId</code> | <code>string</code> | The identifier for the destination that you want to delete. |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[Channel](Models/Channel.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[DeleteDestinationError](Errors/DeleteDestinationError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;object&gt; DeleteSubscriptionById(string subscriptionId, string notificationType, RequestOptions? requestOptions = null, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Notifications.DeleteSubscriptionById(subscriptionId, notificationType);
    // TODO: Handle 'response' of type object
}
catch (SdkException<DeleteSubscriptionByIdError> ex)
{
    if (ex.Error.TryGetNoContent(out var error))
    {
        // TODO: Handle 'error' of type RawError
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>subscriptionId</code> | <code>string</code> | The identifier for the subscription that you want to delete. |
| <code>notificationType</code> | <code>string</code> | The type of notification. Must be one of: EMAIL, WEBHOOKS, SMS, PULL, MOBILE_PUSH. |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>object</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[DeleteSubscriptionByIdError](Errors/DeleteSubscriptionByIdError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;Channel&gt; GetDestination(string destinationId, RequestOptions? requestOptions = null, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Notifications.GetDestination(destinationId);
    // TODO: Handle 'response' of type Channel
}
catch (SdkException<GetDestinationError> ex)
{
    if (ex.Error.TryGetNoContent(out var error))
    {
        // TODO: Handle 'error' of type RawError
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>destinationId</code> | <code>string</code> | The identifier generated when you created the destination. |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[Channel](Models/Channel.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[GetDestinationError](Errors/GetDestinationError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;ChannelList&gt; GetDestinations(RequestOptions? requestOptions = null, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Notifications.GetDestinations();
    // TODO: Handle 'response' of type ChannelList
}
catch (SdkException<GetDestinationsError> ex)
{
    if (ex.Error.TryGetNoContent(out var error))
    {
        // TODO: Handle 'error' of type RawError
    }
}
```

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[ChannelList](Models/ChannelList.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[GetDestinationsError](Errors/GetDestinationsError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;object&gt; GetSubscription(string notificationType, string? payloadVersion, RequestOptions? requestOptions = null, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Notifications.GetSubscription(notificationType, payloadVersion);
    // TODO: Handle 'response' of type object
}
catch (SdkException<GetSubscriptionError> ex)
{
    if (ex.Error.TryGetNoContent(out var error))
    {
        // TODO: Handle 'error' of type RawError
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>notificationType</code> | <code>string</code> | The type of notification. Must be one of: EMAIL, WEBHOOKS, SMS, PULL, MOBILE_PUSH. |
| <code>payloadVersion</code> | <code>string?</code> | The version of the payload object to be used in the notification. |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>object</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[GetSubscriptionError](Errors/GetSubscriptionError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;object&gt; GetSubscriptionById(string subscriptionId, string notificationType, RequestOptions? requestOptions = null, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Notifications.GetSubscriptionById(subscriptionId, notificationType);
    // TODO: Handle 'response' of type object
}
catch (SdkException<GetSubscriptionByIdError> ex)
{
    if (ex.Error.TryGetNoContent(out var error))
    {
        // TODO: Handle 'error' of type RawError
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>subscriptionId</code> | <code>string</code> | The identifier for the subscription that you want to get. |
| <code>notificationType</code> | <code>string</code> | The type of notification. Must be one of: EMAIL, WEBHOOKS, SMS, PULL, MOBILE_PUSH. |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>object</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[GetSubscriptionByIdError](Errors/GetSubscriptionByIdError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;object&gt; SendTestNotification(string notificationType, object body, RequestOptions? requestOptions = null, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Notifications.SendTestNotification(notificationType, body);
    // TODO: Handle 'response' of type object
}
catch (SdkException<SendTestNotificationError> ex)
{
    if (ex.Error.TryGetNoContent(out var error))
    {
        // TODO: Handle 'error' of type RawError
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>notificationType</code> | <code>string</code> | The type of notification. Must be one of: EMAIL, WEBHOOKS, SMS, PULL, MOBILE_PUSH. |
| <code>body</code> | <code>object</code> | - |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>object</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[SendTestNotificationError](Errors/SendTestNotificationError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

## ProductFees

> Source: [ProductFees](Api/ProductFees.cs)

<details>
<summary><code>Task&lt;GetMyFeesEstimateResponse&gt; GetMyFeesEstimateForItem(string walmartItemId, GetMyFeesEstimateRequest body, RequestOptions? requestOptions = null, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Returns an estimated fee for a single item identified by Walmart Item ID.
Walmart Item ID replaces the SP-API ASIN path parameter.

SP-API equivalent: `getMyFeesEstimateForASIN` (identifier changed from
ASIN to Walmart Item ID; request/response shape is otherwise 1:1).


</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.ProductFees.GetMyFeesEstimateForItem(walmartItemId, body);
    // TODO: Handle 'response' of type GetMyFeesEstimateResponse
}
catch (SdkException<GetMyFeesEstimateForItemError> ex)
{
    if (ex.Error.TryGetErrorList(out var error))
    {
        // TODO: Handle 'error' of type ErrorList
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>walmartItemId</code> | <code>string</code> | The Walmart Item ID of the item. Replaces SP-API ASIN. |
| <code>body</code> | <code>[GetMyFeesEstimateRequest](Models/GetMyFeesEstimateRequest.cs)</code> | - |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[GetMyFeesEstimateResponse](Models/GetMyFeesEstimateResponse.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[GetMyFeesEstimateForItemError](Errors/GetMyFeesEstimateForItemError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;GetMyFeesEstimateResponse&gt; GetMyFeesEstimateForSku(string sellerSku, string marketplaceId, GetMyFeesEstimateRequest body, RequestOptions? requestOptions = null, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Returns an estimated fee for a seller listing identified by Seller SKU.


</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.ProductFees.GetMyFeesEstimateForSku(sellerSku, marketplaceId, body);
    // TODO: Handle 'response' of type GetMyFeesEstimateResponse
}
catch (SdkException<GetMyFeesEstimateForSkuError> ex)
{
    if (ex.Error.TryGetErrorList(out var error))
    {
        // TODO: Handle 'error' of type ErrorList
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>sellerSku</code> | <code>string</code> | The seller's SKU for the listing. Scoped to the authenticated seller. |
| <code>marketplaceId</code> | <code>string</code> | Marketplace identifier. |
| <code>body</code> | <code>[GetMyFeesEstimateRequest](Models/GetMyFeesEstimateRequest.cs)</code> | - |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[GetMyFeesEstimateResponse](Models/GetMyFeesEstimateResponse.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[GetMyFeesEstimateForSkuError](Errors/GetMyFeesEstimateForSkuError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;IReadOnlyList&lt;FeesEstimateResult&gt;&gt; GetMyFeesEstimates(IReadOnlyList&lt;FeesEstimateByIdRequest&gt; body, RequestOptions? requestOptions = null, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Returns estimated Walmart fees for a list of items identified by
Walmart Item ID or Seller SKU.


</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.ProductFees.GetMyFeesEstimates(body);
    // TODO: Handle 'response' of type IReadOnlyList<FeesEstimateResult>
}
catch (SdkException<GetMyFeesEstimatesError> ex)
{
    if (ex.Error.TryGetErrorList(out var error))
    {
        // TODO: Handle 'error' of type ErrorList
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>body</code> | <code>IReadOnlyList&lt;[FeesEstimateByIdRequest](Models/FeesEstimateByIdRequest.cs)&gt;</code> | - |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>IReadOnlyList&lt;[FeesEstimateResult](Models/FeesEstimateResult.cs)&gt;</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[GetMyFeesEstimatesError](Errors/GetMyFeesEstimatesError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

## ProductPricing

> Source: [ProductPricing](Api/ProductPricing.cs)

<details>
<summary><code>Task&lt;GetPricingResponse&gt; GetCompetitivePricing(string marketplaceId, ItemType itemType, IReadOnlyList&lt;string&gt;? skus, IReadOnlyList&lt;string&gt;? walmartItemIds, CustomerType? customerType, RequestOptions? requestOptions = null, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Returns competitive pricing information for a seller's offer listings based on seller SKU or Walmart Item ID .

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.ProductPricing.GetCompetitivePricing(marketplaceId,
        itemType,
        skus,
        walmartItemIds,
        customerType);
    // TODO: Handle 'response' of type GetPricingResponse
}
catch (SdkException<GetCompetitivePricingError> ex)
{
    if (ex.Error.TryGetListOfError3(out var error))
    {
        // TODO: Handle 'error' of type IReadOnlyList<Error3>
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>marketplaceId</code> | <code>string</code> | A marketplace identifier. Specifies the marketplace for which prices are returned. |
| <code>itemType</code> | <code>[ItemType](Models/Enums/ItemType.cs)</code> | Indicates whether Walmart Item ID values or seller SKU values are used to identify items. |
| <code>skus</code> | <code>IReadOnlyList&lt;string&gt;?</code> | A list of up to twenty seller SKU values used to identify items in the given marketplace. |
| <code>walmartItemIds</code> | <code>IReadOnlyList&lt;string&gt;?</code> | A list of up to twenty Walmart Item ID values used to identify items in the given marketplace. |
| <code>customerType</code> | <code>[CustomerType?](Models/Enums/CustomerType.cs)</code> | Indicates whether to request pricing information from the point of view of Consumer or Business buyers. Default is Consumer. |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[GetPricingResponse](Models/GetPricingResponse.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[GetCompetitivePricingError](Errors/GetCompetitivePricingError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;CompetitiveSummaryBatchResponse&gt; GetCompetitiveSummary(CompetitiveSummaryBatchRequest body, RequestOptions? requestOptions = null, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

**Planned — not yet available in production.** Returns competitive summary including featured buying options and lowest priced offers
for a batch of Walmart Item IDs .

**Phase 1 stub** — no upstream data source identified.
Returns HTTP 501 until an upstream is confirmed.
Track: .


</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.ProductPricing.GetCompetitiveSummary(body);
    // TODO: Handle 'response' of type CompetitiveSummaryBatchResponse
}
catch (SdkException<GetCompetitiveSummaryError> ex)
{
    if (ex.Error.TryGetListOfError3(out var error))
    {
        // TODO: Handle 'error' of type IReadOnlyList<Error3>
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>body</code> | <code>[CompetitiveSummaryBatchRequest](Models/CompetitiveSummaryBatchRequest.cs)</code> | - |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[CompetitiveSummaryBatchResponse](Models/CompetitiveSummaryBatchResponse.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[GetCompetitiveSummaryError](Errors/GetCompetitiveSummaryError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;GetFeaturedOfferExpectedPriceBatchResponse&gt; GetFeaturedOfferExpectedPriceBatch(GetFeaturedOfferExpectedPriceBatchRequest body, RequestOptions? requestOptions = null, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

**Planned — not yet available in production.** Returns the featured offer expected price (FOEP) for a batch of seller SKUs.

**Phase 1 stub** — no upstream data source identified.
Returns HTTP 501 until an upstream is confirmed.
Track: .


</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.ProductPricing.GetFeaturedOfferExpectedPriceBatch(body);
    // TODO: Handle 'response' of type GetFeaturedOfferExpectedPriceBatchResponse
}
catch (SdkException<GetFeaturedOfferExpectedPriceBatchError> ex)
{
    if (ex.Error.TryGetListOfError3(out var error))
    {
        // TODO: Handle 'error' of type IReadOnlyList<Error3>
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>body</code> | <code>[GetFeaturedOfferExpectedPriceBatchRequest](Models/GetFeaturedOfferExpectedPriceBatchRequest.cs)</code> | - |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[GetFeaturedOfferExpectedPriceBatchResponse](Models/GetFeaturedOfferExpectedPriceBatchResponse.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[GetFeaturedOfferExpectedPriceBatchError](Errors/GetFeaturedOfferExpectedPriceBatchError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;GetOffersResponse&gt; GetItemOffers(string itemId, string marketplaceId, ConditionType2 itemCondition, CustomerType? customerType, RequestOptions? requestOptions = null, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Returns the lowest priced offers for a single item based on Walmart Item ID and item condition.

Uses Walmart Item ID as the primary identifier(ASIN not supported —
no ASIN resolver exists in the Walmart platform; IQS queries by product.item_id).

Backed by IQS catalog_index cross-seller query (same as getListingOffers hop-2).
Returns 404 when no offers are found for the given itemId.


</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.ProductPricing.GetItemOffers(itemId, marketplaceId, itemCondition, customerType);
    // TODO: Handle 'response' of type GetOffersResponse
}
catch (SdkException<GetItemOffersError> ex)
{
    if (ex.Error.TryGetListOfError3(out var error))
    {
        // TODO: Handle 'error' of type IReadOnlyList<Error3>
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>itemId</code> | <code>string</code> | The Walmart Item ID of the item. |
| <code>marketplaceId</code> | <code>string</code> | A marketplace identifier. Specifies the marketplace for which prices are returned. |
| <code>itemCondition</code> | <code>[ConditionType2](Models/Enums/ConditionType2.cs)</code> | Filters the offer listings based on item condition. Possible values: New, Used, Collectible, Refurbished, Club. |
| <code>customerType</code> | <code>[CustomerType?](Models/Enums/CustomerType.cs)</code> | Indicates whether to request Consumer or Business offers. Default is Consumer. |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[GetOffersResponse](Models/GetOffersResponse.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[GetItemOffersError](Errors/GetItemOffersError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;GetItemOffersBatchResponse&gt; GetItemOffersBatch(GetItemOffersBatchRequest body, RequestOptions? requestOptions = null, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Batch version of getItemOffers. Accepts up to 20 Walmart Item ID requests.
Uses Walmart Item ID as the primary identifier.

Implemented as in-process fan-out over getItemOffers.
Each item gets its own per-item HTTP status code in the response body;
the outer HTTP response is always 200.
Implemented: .


</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.ProductPricing.GetItemOffersBatch(body);
    // TODO: Handle 'response' of type GetItemOffersBatchResponse
}
catch (SdkException<GetItemOffersBatchError> ex)
{
    if (ex.Error.TryGetListOfError3(out var error))
    {
        // TODO: Handle 'error' of type IReadOnlyList<Error3>
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>body</code> | <code>[GetItemOffersBatchRequest](Models/GetItemOffersBatchRequest.cs)</code> | - |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[GetItemOffersBatchResponse](Models/GetItemOffersBatchResponse.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[GetItemOffersBatchError](Errors/GetItemOffersBatchError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;GetOffersResponse&gt; GetListingOffers(string sellerSku, string marketplaceId, ConditionType2 itemCondition, CustomerType? customerType, RequestOptions? requestOptions = null, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Returns the lowest priced offers for a single SKU listing, based on SKU and item condition.

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.ProductPricing.GetListingOffers(sellerSku, marketplaceId, itemCondition, customerType);
    // TODO: Handle 'response' of type GetOffersResponse
}
catch (SdkException<GetListingOffersError> ex)
{
    if (ex.Error.TryGetListOfError3(out var error))
    {
        // TODO: Handle 'error' of type IReadOnlyList<Error3>
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>sellerSku</code> | <code>string</code> | Identifies an item in the given marketplace. SellerSKU is qualified by the seller's SellerId. |
| <code>marketplaceId</code> | <code>string</code> | A marketplace identifier. Specifies the marketplace for which prices are returned. |
| <code>itemCondition</code> | <code>[ConditionType2](Models/Enums/ConditionType2.cs)</code> | Filters the offer listings based on item condition. Possible values: New, Used, Collectible, Refurbished, Club. |
| <code>customerType</code> | <code>[CustomerType?](Models/Enums/CustomerType.cs)</code> | Indicates whether to request Consumer or Business offers. Default is Consumer. |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[GetOffersResponse](Models/GetOffersResponse.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[GetListingOffersError](Errors/GetListingOffersError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;GetListingOffersBatchResponse&gt; GetListingOffersBatch(GetListingOffersBatchRequest body, RequestOptions? requestOptions = null, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Batch version of getListingOffers. Accepts up to 20 SKU requests.

Implemented as in-process fan-out over getListingOffers (IQS-backed).
Each SKU gets its own per-item HTTP status code in the response body;
the outer HTTP response is always 200.
Implemented: .


</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.ProductPricing.GetListingOffersBatch(body);
    // TODO: Handle 'response' of type GetListingOffersBatchResponse
}
catch (SdkException<GetListingOffersBatchError> ex)
{
    if (ex.Error.TryGetListOfError3(out var error))
    {
        // TODO: Handle 'error' of type IReadOnlyList<Error3>
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>body</code> | <code>[GetListingOffersBatchRequest](Models/GetListingOffersBatchRequest.cs)</code> | - |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[GetListingOffersBatchResponse](Models/GetListingOffersBatchResponse.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[GetListingOffersBatchError](Errors/GetListingOffersBatchError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;GetPricingResponse&gt; GetPricing(string marketplaceId, ItemType itemType, IReadOnlyList&lt;string&gt;? skus, IReadOnlyList&lt;string&gt;? walmartItemIds, ConditionType2? itemCondition, OfferType? offerType, CustomerType? customerType, RequestOptions? requestOptions = null, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Returns pricing information for a seller's active offer listings based on seller SKU or Walmart Item ID .

</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.ProductPricing.GetPricing(marketplaceId,
        itemType,
        skus,
        walmartItemIds,
        itemCondition,
        offerType,
        customerType);
    // TODO: Handle 'response' of type GetPricingResponse
}
catch (SdkException<GetPricingError> ex)
{
    if (ex.Error.TryGetListOfError3(out var error))
    {
        // TODO: Handle 'error' of type IReadOnlyList<Error3>
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>marketplaceId</code> | <code>string</code> | A marketplace identifier. Specifies the marketplace for which prices are returned. |
| <code>itemType</code> | <code>[ItemType](Models/Enums/ItemType.cs)</code> | Indicates whether Walmart Item ID values or seller SKU values are used to identify items. |
| <code>skus</code> | <code>IReadOnlyList&lt;string&gt;?</code> | A list of up to twenty seller SKU values used to identify items in the given marketplace. |
| <code>walmartItemIds</code> | <code>IReadOnlyList&lt;string&gt;?</code> | A list of up to twenty Walmart Item ID values used to identify items in the given marketplace. |
| <code>itemCondition</code> | <code>[ConditionType2?](Models/Enums/ConditionType2.cs)</code> | Filters the offer listings based on item condition. Possible values: New, Used, Collectible, Refurbished, Club. |
| <code>offerType</code> | <code>[OfferType?](Models/Enums/OfferType.cs)</code> | Indicates whether to request pricing information for the seller's B2C or B2B offers. Default is B2C. |
| <code>customerType</code> | <code>[CustomerType?](Models/Enums/CustomerType.cs)</code> | Indicates whether to request Consumer or Business offers. Default is Consumer. |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[GetPricingResponse](Models/GetPricingResponse.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[GetPricingError](Errors/GetPricingError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

## Sales

> Source: [Sales](Api/Sales.cs)

<details>
<summary><code>Task&lt;object&gt; GetOrderMetrics(IReadOnlyList&lt;string&gt; marketplaceIds, string interval, Granularity granularity, string? granularityTimeZone, BuyerType? buyerType, string? fulfillmentNetwork, FirstDayOfWeek? firstDayOfWeek, string? asin, string? sku, string? spApiProgram, RequestOptions? requestOptions = null, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Sales.GetOrderMetrics(marketplaceIds,
        interval,
        granularity,
        granularityTimeZone,
        buyerType,
        fulfillmentNetwork,
        firstDayOfWeek,
        asin,
        sku,
        spApiProgram);
    // TODO: Handle 'response' of type object
}
catch (SdkException<GetOrderMetricsError> ex)
{
    if (ex.Error.TryGetErrorList(out var error))
    {
        // TODO: Handle 'error' of type ErrorList
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>marketplaceIds</code> | <code>IReadOnlyList&lt;string&gt;</code> | A marketplace identifier. This specifies the marketplace in which the order was placed. Only one marketplace can be specified |
| <code>interval</code> | <code>string</code> | A time interval used for selecting order metrics. This takes the form of two dates separated by two hyphens (first date is inclusive; second date is exclusive). Dates are in ISO8601 format and must represent absolute time (either Z notation or offset notation). Example: 2018-09-01T00:00:00-07:00--2018-09-04T00:00:00-07:00 requests order metrics for Sept 1st, 2nd and 3rd in the -07:00 zone. |
| <code>granularity</code> | <code>[Granularity](Models/Enums/Granularity.cs)</code> | The granularity of the grouping of order metrics, based on a unit of time. Specifying granularity=Hour results in a successful request only if the interval specified is less than or equal to 30 days from now. For all other granularities, the interval specified must be less or equal to 2 years from now. Specifying granularity=Total results in order metrics that are aggregated over the entire interval that you specify. If the interval start and end date don’t align with the specified granularity, the head and tail end of the response interval will contain partial data. Example: Day to get a daily breakdown of the request interval, where the day boundary is defined by the granularityTimeZone. |
| <code>granularityTimeZone</code> | <code>string?</code> | An IANA-compatible time zone for determining the day boundary. Required when specifying a granularity value greater than Hour. The granularityTimeZone value must align with the offset of the specified interval value. For example, if the interval value uses Z notation, then granularityTimeZone must be UTC. If the interval value uses an offset, then granularityTimeZone must be an IANA-compatible time zone that matches the offset. Example: US/Pacific to compute day boundaries, accounting for daylight time savings, for US/Pacific zone. |
| <code>buyerType</code> | <code>[BuyerType?](Models/Enums/BuyerType.cs)</code> | Filters the results by the buyer type that you specify, B2B (business to business) or B2C (business to customer). Example: B2B, if you want the response to include order metrics for only B2B buyers. |
| <code>fulfillmentNetwork</code> | <code>string?</code> | Filters the results by the fulfillment network that you specify, MFN (merchant fulfillment network) or AFN (marketplace fulfillment network). Do not include this filter if you want the response to include order metrics for all fulfillment networks. Example: AFN, if you want the response to include order metrics for only the marketplace fulfillment network. |
| <code>firstDayOfWeek</code> | <code>[FirstDayOfWeek?](Models/Enums/FirstDayOfWeek.cs)</code> | Specifies the day that the week starts on when granularity=Week, either Monday or Sunday. Default: Monday. Example: Sund |
| <code>asin</code> | <code>string?</code> | Filters the results by the ASIN that you specify. Specifying both ASIN and SKU returns an error. Do not include this filter if you want the response to include order metrics for all ASINs. Example: B0792R1RSN, if you want the response to include order metrics for only ASIN B0792R1RSN. |
| <code>sku</code> | <code>string?</code> | Filters the results by the SKU that you specify. Specifying both ASIN and SKU returns an error. Do not include this filter if you want the response to include order metrics for all SKUs. Example: TestSKU, if you want the response to include order metrics for only SKU TestSKU. |
| <code>spApiProgram</code> | <code>string?</code> | Filters the results by the program that you specify. Do not include this filter if you want the response to inclu |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>object</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[GetOrderMetricsError](Errors/GetOrderMetricsError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

## Shipping

> Source: [Shipping](Api/Shipping.cs)

<details>
<summary><code>Task&lt;CancelShipmentResponse1&gt; CancelShipment2(string shipmentId, RequestOptions? requestOptions = null, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Cancels a shipment that has not yet shipped. Cancellation
eligibility is carrier-dependent; refer to the response
cancellation status to confirm.


</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Shipping.CancelShipment2(shipmentId);
    // TODO: Handle 'response' of type CancelShipmentResponse1
}
catch (SdkException<CancelShipment2Error> ex)
{
    if (ex.Error.TryGetErrorList(out var error))
    {
        // TODO: Handle 'error' of type ErrorList
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>shipmentId</code> | <code>string</code> | Identifier of the shipment to cancel. |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[CancelShipmentResponse1](Models/CancelShipmentResponse1.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[CancelShipment2Error](Errors/CancelShipment2Error.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;GetAccessPointsResponse&gt; GetAccessPoints(string accessPointTypes, string countryCode, string postalCode, RequestOptions? requestOptions = null, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Returns access points (pickup and dropoff locations) near the
supplied postal code and country, optionally filtered by access
point type.


</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Shipping.GetAccessPoints(accessPointTypes, countryCode, postalCode);
    // TODO: Handle 'response' of type GetAccessPointsResponse
}
catch (SdkException<GetAccessPointsError> ex)
{
    if (ex.Error.TryGetErrorList(out var error))
    {
        // TODO: Handle 'error' of type ErrorList
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>accessPointTypes</code> | <code>string</code> | Comma-separated list of access point types to include. |
| <code>countryCode</code> | <code>string</code> | ISO 3166-1 alpha-2 country code (e.g. US, CA, MX). |
| <code>postalCode</code> | <code>string</code> | Postal code to search around. |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[GetAccessPointsResponse](Models/GetAccessPointsResponse.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[GetAccessPointsError](Errors/GetAccessPointsError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;GetAdditionalInputsResponse&gt; GetAdditionalInputs(string rateId, string requestToken, RequestOptions? requestOptions = null, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Returns a JSON Schema document describing any
carrier-and-service-specific inputs required to purchase a
shipment for the supplied requestToken + rateId. The schema is
served verbatim and the calling client should validate the
seller's input against it before issuing purchaseShipment.


</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Shipping.GetAdditionalInputs(rateId, requestToken);
    // TODO: Handle 'response' of type GetAdditionalInputsResponse
}
catch (SdkException<GetAdditionalInputsError> ex)
{
    if (ex.Error.TryGetErrorList(out var error))
    {
        // TODO: Handle 'error' of type ErrorList
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>rateId</code> | <code>string</code> | rateId returned by a prior getRates response. |
| <code>requestToken</code> | <code>string</code> | requestToken returned by a prior getRates response. |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[GetAdditionalInputsResponse](Models/GetAdditionalInputsResponse.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[GetAdditionalInputsError](Errors/GetAdditionalInputsError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;GetFulfillmentOrderResponse&gt; GetRates(GetRatesRequest body, RequestOptions? requestOptions = null, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Returns a list of shipping rate quotes for the given shipment
request. The seller can then call purchaseShipment with the
selected rateId to commit to a label purchase.


</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Shipping.GetRates(body);
    // TODO: Handle 'response' of type GetFulfillmentOrderResponse
}
catch (SdkException<GetRatesError> ex)
{
    if (ex.Error.TryGetErrorList(out var error))
    {
        // TODO: Handle 'error' of type ErrorList
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>body</code> | <code>[GetRatesRequest](Models/GetRatesRequest.cs)</code> | - |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[GetFulfillmentOrderResponse](Models/GetFulfillmentOrderResponse.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[GetRatesError](Errors/GetRatesError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;GetShipmentDocumentsResponse&gt; GetShipmentDocuments(string shipmentId, string? packageClientReferenceId, Format1? format, RequestOptions? requestOptions = null, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Returns the label, customs, and other printable documents
associated with a previously-purchased shipment.


</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Shipping.GetShipmentDocuments(shipmentId, packageClientReferenceId, format);
    // TODO: Handle 'response' of type GetShipmentDocumentsResponse
}
catch (SdkException<GetShipmentDocumentsError> ex)
{
    if (ex.Error.TryGetErrorList(out var error))
    {
        // TODO: Handle 'error' of type ErrorList
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>shipmentId</code> | <code>string</code> | Identifier of the shipment whose documents to retrieve. |
| <code>packageClientReferenceId</code> | <code>string?</code> | Optional package-level reference id to retrieve documents<br>for a specific package within a multi-package shipment. |
| <code>format</code> | <code>[Format1?](Models/Enums/Format1.cs)</code> | Requested document format (defaults to PDF). |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[GetShipmentDocumentsResponse](Models/GetShipmentDocumentsResponse.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[GetShipmentDocumentsError](Errors/GetShipmentDocumentsError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;GetTrackingResponse&gt; GetTracking(string trackingId, string? carrierId, RequestOptions? requestOptions = null, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Returns the current tracking status, event history, and any
proof-of-delivery details for the given trackingId. TNT
resolves carrier internally from the trackingId alone, so
carrierId is optional -- confirmed unnecessary by the TNT/
Vulcan team (STRIDE-TNT-CORE-PACKAGE-SERVICES) 2026-08-19.
When provided, it's used only as a defense-in-depth check
against the resolved carrier; a mismatch surfaces as 404.


</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Shipping.GetTracking(trackingId, carrierId);
    // TODO: Handle 'response' of type GetTrackingResponse
}
catch (SdkException<GetTrackingError> ex)
{
    if (ex.Error.TryGetErrorList(out var error))
    {
        // TODO: Handle 'error' of type ErrorList
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>trackingId</code> | <code>string</code> | Tracking identifier returned by purchaseShipment. |
| <code>carrierId</code> | <code>string?</code> | Optional carrier identifier for defense-in-depth validation<br>against TNT's resolved carrier. Not required by TNT itself<br>-- omit unless you specifically want mismatch protection. |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[GetTrackingResponse](Models/GetTrackingResponse.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[GetTrackingError](Errors/GetTrackingError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;GetFulfillmentOrderShipmentsResponse&gt; OneClickShipment(OneClickShipmentRequest body, RequestOptions? requestOptions = null, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Convenience endpoint that combines rate quote and purchase into
a single round trip when the seller already knows the desired
service level. Returns the purchased shipment record directly.


</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Shipping.OneClickShipment(body);
    // TODO: Handle 'response' of type GetFulfillmentOrderShipmentsResponse
}
catch (SdkException<OneClickShipmentError> ex)
{
    if (ex.Error.TryGetErrorList(out var error))
    {
        // TODO: Handle 'error' of type ErrorList
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>body</code> | <code>[OneClickShipmentRequest](Models/OneClickShipmentRequest.cs)</code> | - |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[GetFulfillmentOrderShipmentsResponse](Models/GetFulfillmentOrderShipmentsResponse.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[OneClickShipmentError](Errors/OneClickShipmentError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;GetFulfillmentOrderShipmentsResponse&gt; PurchaseShipment(PurchaseShipmentRequest body, RequestOptions? requestOptions = null, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Purchases the shipping label for the rate selected from a prior
getRates response. Returns the shipment record with label
document references.


</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Shipping.PurchaseShipment(body);
    // TODO: Handle 'response' of type GetFulfillmentOrderShipmentsResponse
}
catch (SdkException<PurchaseShipmentError> ex)
{
    if (ex.Error.TryGetErrorList(out var error))
    {
        // TODO: Handle 'error' of type ErrorList
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>body</code> | <code>[PurchaseShipmentRequest](Models/PurchaseShipmentRequest.cs)</code> | - |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[GetFulfillmentOrderShipmentsResponse](Models/GetFulfillmentOrderShipmentsResponse.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[PurchaseShipmentError](Errors/PurchaseShipmentError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task SubmitNdrFeedback(SubmitNdrFeedbackRequest body, RequestOptions? requestOptions = null, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Description

<dl>
<dd>

Submits seller feedback on a non-delivery event for a shipment,
instructing the carrier on how to proceed (return, reattempt,
redirect, etc).


</dd>
</dl>

### Usage

<dl>
<dd>

```csharp
try
{
    await client.Shipping.SubmitNdrFeedback(body);
}
catch (SdkException<SubmitNdrFeedbackError> ex)
{
    if (ex.Error.TryGetErrorList(out var error))
    {
        // TODO: Handle 'error' of type ErrorList
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>body</code> | <code>[SubmitNdrFeedbackRequest](Models/SubmitNdrFeedbackRequest.cs)</code> | - |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: No content

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[SubmitNdrFeedbackError](Errors/SubmitNdrFeedbackError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

## Solicitations

> Source: [Solicitations](Api/Solicitations.cs)

<details>
<summary><code>Task&lt;object&gt; CreateProductReviewAndSellerFeedbackSolicitation(string spApiOrderId, IReadOnlyList&lt;string&gt; marketplaceIds, RequestOptions? requestOptions = null, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Solicitations.CreateProductReviewAndSellerFeedbackSolicitation(spApiOrderId,
        marketplaceIds);
    // TODO: Handle 'response' of type object
}
catch (SdkException<CreateProductReviewAndSellerFeedbackSolicitationError> ex)
{
    if (ex.Error.TryGetErrorList(out var error))
    {
        // TODO: Handle 'error' of type ErrorList
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>spApiOrderId</code> | <code>string</code> | An SP-API order identifier. This specifies the order for which a solicitation is sent. |
| <code>marketplaceIds</code> | <code>IReadOnlyList&lt;string&gt;</code> | A marketplace identifier. This specifies the marketplace in which the order was placed. Only one marketplace can be spec |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>object</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[CreateProductReviewAndSellerFeedbackSolicitationError](Errors/CreateProductReviewAndSellerFeedbackSolicitationError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;object&gt; GetSolicitationActionsForOrder(string spApiOrderId, IReadOnlyList&lt;string&gt; marketplaceIds, RequestOptions? requestOptions = null, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Solicitations.GetSolicitationActionsForOrder(spApiOrderId, marketplaceIds);
    // TODO: Handle 'response' of type object
}
catch (SdkException<GetSolicitationActionsForOrderError> ex)
{
    if (ex.Error.TryGetErrorList(out var error))
    {
        // TODO: Handle 'error' of type ErrorList
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>spApiOrderId</code> | <code>string</code> | An SP-API order identifier. This specifies the order for which you want a list of available solicitation types. |
| <code>marketplaceIds</code> | <code>IReadOnlyList&lt;string&gt;</code> | A marketplace identifier. This specifies the marketplace in which the order was placed. Only one marketplace can be spec |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>object</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[GetSolicitationActionsForOrderError](Errors/GetSolicitationActionsForOrderError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

## WfsInbound

> Source: [WfsInbound](Api/WfsInbound.cs)

<details>
<summary><code>Task&lt;CancelInboundPlanResponse&gt; CancelInboundPlan(string inboundPlanId, RequestOptions? requestOptions = null, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.WfsInbound.CancelInboundPlan(inboundPlanId);
    // TODO: Handle 'response' of type CancelInboundPlanResponse
}
catch (SdkException<CancelInboundPlanError> ex)
{
    if (ex.Error.TryGetCommonErrorList(out var error))
    {
        // TODO: Handle 'error' of type CommonErrorList
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>inboundPlanId</code> | <code>string</code> | Identifier of an inbound plan. |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[CancelInboundPlanResponse](Models/CancelInboundPlanResponse.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[CancelInboundPlanError](Errors/CancelInboundPlanError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;CancelInboundPlanResponse&gt; CancelSelfShipAppointment(string inboundPlanId, string shipmentId, CancelSelfShipAppointmentRequest body, RequestOptions? requestOptions = null, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.WfsInbound.CancelSelfShipAppointment(inboundPlanId, shipmentId, body);
    // TODO: Handle 'response' of type CancelInboundPlanResponse
}
catch (SdkException<CancelSelfShipAppointmentError> ex)
{
    if (ex.Error.TryGetCommonErrorList(out var error))
    {
        // TODO: Handle 'error' of type CommonErrorList
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>inboundPlanId</code> | <code>string</code> | Identifier of an inbound plan. |
| <code>shipmentId</code> | <code>string</code> | Identifier of a shipment. |
| <code>body</code> | <code>[CancelSelfShipAppointmentRequest](Models/CancelSelfShipAppointmentRequest.cs)</code> | - |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[CancelInboundPlanResponse](Models/CancelInboundPlanResponse.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[CancelSelfShipAppointmentError](Errors/CancelSelfShipAppointmentError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;CancelInboundPlanResponse&gt; ConfirmDeliveryWindowOptions(string inboundPlanId, string shipmentId, string deliveryWindowOptionId, RequestOptions? requestOptions = null, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.WfsInbound.ConfirmDeliveryWindowOptions(inboundPlanId,
        shipmentId,
        deliveryWindowOptionId);
    // TODO: Handle 'response' of type CancelInboundPlanResponse
}
catch (SdkException<ConfirmDeliveryWindowOptionsError> ex)
{
    if (ex.Error.TryGetCommonErrorList(out var error))
    {
        // TODO: Handle 'error' of type CommonErrorList
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>inboundPlanId</code> | <code>string</code> | Identifier of an inbound plan. |
| <code>shipmentId</code> | <code>string</code> | The shipment to confirm the delivery window option for. |
| <code>deliveryWindowOptionId</code> | <code>string</code> | The ID of the delivery window option to be confirmed. |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[CancelInboundPlanResponse](Models/CancelInboundPlanResponse.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[ConfirmDeliveryWindowOptionsError](Errors/ConfirmDeliveryWindowOptionsError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;CancelInboundPlanResponse&gt; ConfirmPackingOption(string inboundPlanId, string packingOptionId, RequestOptions? requestOptions = null, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.WfsInbound.ConfirmPackingOption(inboundPlanId, packingOptionId);
    // TODO: Handle 'response' of type CancelInboundPlanResponse
}
catch (SdkException<ConfirmPackingOptionError> ex)
{
    if (ex.Error.TryGetCommonErrorList(out var error))
    {
        // TODO: Handle 'error' of type CommonErrorList
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>inboundPlanId</code> | <code>string</code> | Identifier of an inbound plan. |
| <code>packingOptionId</code> | <code>string</code> | Identifier of a packing option. |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[CancelInboundPlanResponse](Models/CancelInboundPlanResponse.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[ConfirmPackingOptionError](Errors/ConfirmPackingOptionError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;CancelInboundPlanResponse&gt; ConfirmPlacementOption(string inboundPlanId, string placementOptionId, RequestOptions? requestOptions = null, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.WfsInbound.ConfirmPlacementOption(inboundPlanId, placementOptionId);
    // TODO: Handle 'response' of type CancelInboundPlanResponse
}
catch (SdkException<ConfirmPlacementOptionError> ex)
{
    if (ex.Error.TryGetCommonErrorList(out var error))
    {
        // TODO: Handle 'error' of type CommonErrorList
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>inboundPlanId</code> | <code>string</code> | Identifier of an inbound plan. |
| <code>placementOptionId</code> | <code>string</code> | The identifier of a placement option. |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[CancelInboundPlanResponse](Models/CancelInboundPlanResponse.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[ConfirmPlacementOptionError](Errors/ConfirmPlacementOptionError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;CancelInboundPlanResponse&gt; ConfirmShipmentContentUpdatePreview(string inboundPlanId, string shipmentId, string contentUpdatePreviewId, RequestOptions? requestOptions = null, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.WfsInbound.ConfirmShipmentContentUpdatePreview(inboundPlanId,
        shipmentId,
        contentUpdatePreviewId);
    // TODO: Handle 'response' of type CancelInboundPlanResponse
}
catch (SdkException<ConfirmShipmentContentUpdatePreviewError> ex)
{
    if (ex.Error.TryGetCommonErrorList(out var error))
    {
        // TODO: Handle 'error' of type CommonErrorList
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>inboundPlanId</code> | <code>string</code> | Identifier of an inbound plan. |
| <code>shipmentId</code> | <code>string</code> | Identifier of a shipment. |
| <code>contentUpdatePreviewId</code> | <code>string</code> | Identifier of a content update preview. |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[CancelInboundPlanResponse](Models/CancelInboundPlanResponse.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[ConfirmShipmentContentUpdatePreviewError](Errors/ConfirmShipmentContentUpdatePreviewError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;CancelInboundPlanResponse&gt; ConfirmTransportationOptions(string inboundPlanId, ConfirmTransportationOptionsRequest body, RequestOptions? requestOptions = null, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.WfsInbound.ConfirmTransportationOptions(inboundPlanId, body);
    // TODO: Handle 'response' of type CancelInboundPlanResponse
}
catch (SdkException<ConfirmTransportationOptionsError> ex)
{
    if (ex.Error.TryGetCommonErrorList(out var error))
    {
        // TODO: Handle 'error' of type CommonErrorList
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>inboundPlanId</code> | <code>string</code> | Identifier of an inbound plan. |
| <code>body</code> | <code>[ConfirmTransportationOptionsRequest](Models/ConfirmTransportationOptionsRequest.cs)</code> | - |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[CancelInboundPlanResponse](Models/CancelInboundPlanResponse.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[ConfirmTransportationOptionsError](Errors/ConfirmTransportationOptionsError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;CreateInboundPlanResponse&gt; CreateInboundPlan(CreateInboundPlanRequest body, RequestOptions? requestOptions = null, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.WfsInbound.CreateInboundPlan(body);
    // TODO: Handle 'response' of type CreateInboundPlanResponse
}
catch (SdkException<CreateInboundPlanError> ex)
{
    if (ex.Error.TryGetCommonErrorList(out var error))
    {
        // TODO: Handle 'error' of type CommonErrorList
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>body</code> | <code>[CreateInboundPlanRequest](Models/CreateInboundPlanRequest.cs)</code> | - |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[CreateInboundPlanResponse](Models/CreateInboundPlanResponse.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[CreateInboundPlanError](Errors/CreateInboundPlanError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;CreateMarketplaceItemLabelsResponse&gt; CreateMarketplaceItemLabels(CreateMarketplaceItemLabelsRequest body, RequestOptions? requestOptions = null, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.WfsInbound.CreateMarketplaceItemLabels(body);
    // TODO: Handle 'response' of type CreateMarketplaceItemLabelsResponse
}
catch (SdkException<CreateMarketplaceItemLabelsError> ex)
{
    if (ex.Error.TryGetCommonErrorList(out var error))
    {
        // TODO: Handle 'error' of type CommonErrorList
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>body</code> | <code>[CreateMarketplaceItemLabelsRequest](Models/CreateMarketplaceItemLabelsRequest.cs)</code> | - |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[CreateMarketplaceItemLabelsResponse](Models/CreateMarketplaceItemLabelsResponse.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[CreateMarketplaceItemLabelsError](Errors/CreateMarketplaceItemLabelsError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;CancelInboundPlanResponse&gt; GenerateDeliveryWindowOptions(string inboundPlanId, string shipmentId, RequestOptions? requestOptions = null, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.WfsInbound.GenerateDeliveryWindowOptions(inboundPlanId, shipmentId);
    // TODO: Handle 'response' of type CancelInboundPlanResponse
}
catch (SdkException<GenerateDeliveryWindowOptionsError> ex)
{
    if (ex.Error.TryGetCommonErrorList(out var error))
    {
        // TODO: Handle 'error' of type CommonErrorList
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>inboundPlanId</code> | <code>string</code> | Identifier of an inbound plan. |
| <code>shipmentId</code> | <code>string</code> | The shipment to generate delivery window options for. |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[CancelInboundPlanResponse](Models/CancelInboundPlanResponse.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[GenerateDeliveryWindowOptionsError](Errors/GenerateDeliveryWindowOptionsError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;CancelInboundPlanResponse&gt; GeneratePackingOptions(string inboundPlanId, RequestOptions? requestOptions = null, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.WfsInbound.GeneratePackingOptions(inboundPlanId);
    // TODO: Handle 'response' of type CancelInboundPlanResponse
}
catch (SdkException<GeneratePackingOptionsError> ex)
{
    if (ex.Error.TryGetCommonErrorList(out var error))
    {
        // TODO: Handle 'error' of type CommonErrorList
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>inboundPlanId</code> | <code>string</code> | Identifier of an inbound plan. |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[CancelInboundPlanResponse](Models/CancelInboundPlanResponse.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[GeneratePackingOptionsError](Errors/GeneratePackingOptionsError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;CancelInboundPlanResponse&gt; GeneratePlacementOptions(string inboundPlanId, GeneratePlacementOptionsRequest body, RequestOptions? requestOptions = null, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.WfsInbound.GeneratePlacementOptions(inboundPlanId, body);
    // TODO: Handle 'response' of type CancelInboundPlanResponse
}
catch (SdkException<GeneratePlacementOptionsError> ex)
{
    if (ex.Error.TryGetCommonErrorList(out var error))
    {
        // TODO: Handle 'error' of type CommonErrorList
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>inboundPlanId</code> | <code>string</code> | Identifier of an inbound plan. |
| <code>body</code> | <code>[GeneratePlacementOptionsRequest](Models/GeneratePlacementOptionsRequest.cs)</code> | - |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[CancelInboundPlanResponse](Models/CancelInboundPlanResponse.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[GeneratePlacementOptionsError](Errors/GeneratePlacementOptionsError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;CancelInboundPlanResponse&gt; GenerateSelfShipAppointmentSlots(string inboundPlanId, string shipmentId, GenerateSelfShipAppointmentSlotsRequest body, RequestOptions? requestOptions = null, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.WfsInbound.GenerateSelfShipAppointmentSlots(inboundPlanId, shipmentId, body);
    // TODO: Handle 'response' of type CancelInboundPlanResponse
}
catch (SdkException<GenerateSelfShipAppointmentSlotsError> ex)
{
    if (ex.Error.TryGetCommonErrorList(out var error))
    {
        // TODO: Handle 'error' of type CommonErrorList
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>inboundPlanId</code> | <code>string</code> | Identifier of an inbound plan. |
| <code>shipmentId</code> | <code>string</code> | Identifier of a shipment. |
| <code>body</code> | <code>[GenerateSelfShipAppointmentSlotsRequest](Models/GenerateSelfShipAppointmentSlotsRequest.cs)</code> | - |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[CancelInboundPlanResponse](Models/CancelInboundPlanResponse.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[GenerateSelfShipAppointmentSlotsError](Errors/GenerateSelfShipAppointmentSlotsError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;CancelInboundPlanResponse&gt; GenerateShipmentContentUpdatePreviews(string inboundPlanId, string shipmentId, GenerateShipmentContentUpdatePreviewsRequest body, RequestOptions? requestOptions = null, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.WfsInbound.GenerateShipmentContentUpdatePreviews(inboundPlanId, shipmentId, body);
    // TODO: Handle 'response' of type CancelInboundPlanResponse
}
catch (SdkException<GenerateShipmentContentUpdatePreviewsError> ex)
{
    if (ex.Error.TryGetCommonErrorList(out var error))
    {
        // TODO: Handle 'error' of type CommonErrorList
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>inboundPlanId</code> | <code>string</code> | Identifier of an inbound plan. |
| <code>shipmentId</code> | <code>string</code> | Identifier of a shipment. |
| <code>body</code> | <code>[GenerateShipmentContentUpdatePreviewsRequest](Models/GenerateShipmentContentUpdatePreviewsRequest.cs)</code> | - |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[CancelInboundPlanResponse](Models/CancelInboundPlanResponse.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[GenerateShipmentContentUpdatePreviewsError](Errors/GenerateShipmentContentUpdatePreviewsError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;CancelInboundPlanResponse&gt; GenerateTransportationOptions(string inboundPlanId, GenerateTransportationOptionsRequest body, RequestOptions? requestOptions = null, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.WfsInbound.GenerateTransportationOptions(inboundPlanId, body);
    // TODO: Handle 'response' of type CancelInboundPlanResponse
}
catch (SdkException<GenerateTransportationOptionsError> ex)
{
    if (ex.Error.TryGetCommonErrorList(out var error))
    {
        // TODO: Handle 'error' of type CommonErrorList
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>inboundPlanId</code> | <code>string</code> | Identifier of an inbound plan. |
| <code>body</code> | <code>[GenerateTransportationOptionsRequest](Models/GenerateTransportationOptionsRequest.cs)</code> | - |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[CancelInboundPlanResponse](Models/CancelInboundPlanResponse.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[GenerateTransportationOptionsError](Errors/GenerateTransportationOptionsError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;GetDeliveryChallanDocumentResponse&gt; GetDeliveryChallanDocument(string inboundPlanId, string shipmentId, RequestOptions? requestOptions = null, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.WfsInbound.GetDeliveryChallanDocument(inboundPlanId, shipmentId);
    // TODO: Handle 'response' of type GetDeliveryChallanDocumentResponse
}
catch (SdkException<GetDeliveryChallanDocumentError> ex)
{
    if (ex.Error.TryGetCommonErrorList(out var error))
    {
        // TODO: Handle 'error' of type CommonErrorList
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>inboundPlanId</code> | <code>string</code> | Identifier of an inbound plan. |
| <code>shipmentId</code> | <code>string</code> | Identifier of a shipment. |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[GetDeliveryChallanDocumentResponse](Models/GetDeliveryChallanDocumentResponse.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[GetDeliveryChallanDocumentError](Errors/GetDeliveryChallanDocumentError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;CommonInboundOperationStatus&gt; GetInboundOperationStatus(string operationId, RequestOptions? requestOptions = null, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.WfsInbound.GetInboundOperationStatus(operationId);
    // TODO: Handle 'response' of type CommonInboundOperationStatus
}
catch (SdkException<GetInboundOperationStatusError> ex)
{
    if (ex.Error.TryGetCommonErrorList(out var error))
    {
        // TODO: Handle 'error' of type CommonErrorList
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>operationId</code> | <code>string</code> | Identifier of an asynchronous operation. |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[CommonInboundOperationStatus](Models/CommonInboundOperationStatus.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[GetInboundOperationStatusError](Errors/GetInboundOperationStatusError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;InboundPlan&gt; GetInboundPlan(string inboundPlanId, RequestOptions? requestOptions = null, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.WfsInbound.GetInboundPlan(inboundPlanId);
    // TODO: Handle 'response' of type InboundPlan
}
catch (SdkException<GetInboundPlanError> ex)
{
    if (ex.Error.TryGetCommonErrorList(out var error))
    {
        // TODO: Handle 'error' of type CommonErrorList
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>inboundPlanId</code> | <code>string</code> | Identifier of an inbound plan. |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[InboundPlan](Models/InboundPlan.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[GetInboundPlanError](Errors/GetInboundPlanError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;GetSelfShipAppointmentSlotsResponse&gt; GetSelfShipAppointmentSlots(string inboundPlanId, string shipmentId, int? pageSize, string? paginationToken, RequestOptions? requestOptions = null, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.WfsInbound.GetSelfShipAppointmentSlots(inboundPlanId,
        shipmentId,
        pageSize,
        paginationToken);
    // TODO: Handle 'response' of type GetSelfShipAppointmentSlotsResponse
}
catch (SdkException<GetSelfShipAppointmentSlotsError> ex)
{
    if (ex.Error.TryGetCommonErrorList(out var error))
    {
        // TODO: Handle 'error' of type CommonErrorList
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>inboundPlanId</code> | <code>string</code> | Identifier of an inbound plan. |
| <code>shipmentId</code> | <code>string</code> | Identifier of a shipment. |
| <code>pageSize</code> | <code>int?</code> | The number of self ship appointment slots to return in the response matching the given query. |
| <code>paginationToken</code> | <code>string?</code> | A token to fetch a certain page when there are multiple pages worth of results. |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[GetSelfShipAppointmentSlotsResponse](Models/GetSelfShipAppointmentSlotsResponse.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[GetSelfShipAppointmentSlotsError](Errors/GetSelfShipAppointmentSlotsError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;CommonShipment&gt; GetShipment(string inboundPlanId, string shipmentId, RequestOptions? requestOptions = null, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.WfsInbound.GetShipment(inboundPlanId, shipmentId);
    // TODO: Handle 'response' of type CommonShipment
}
catch (SdkException<GetShipmentError> ex)
{
    if (ex.Error.TryGetCommonErrorList(out var error))
    {
        // TODO: Handle 'error' of type CommonErrorList
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>inboundPlanId</code> | <code>string</code> | Identifier of an inbound plan. |
| <code>shipmentId</code> | <code>string</code> | Identifier of a shipment. A shipment contains the boxes and units being inbounded. |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[CommonShipment](Models/CommonShipment.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[GetShipmentError](Errors/GetShipmentError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;CommonContentUpdatePreview&gt; GetShipmentContentUpdatePreview(string inboundPlanId, string shipmentId, string contentUpdatePreviewId, RequestOptions? requestOptions = null, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.WfsInbound.GetShipmentContentUpdatePreview(inboundPlanId,
        shipmentId,
        contentUpdatePreviewId);
    // TODO: Handle 'response' of type CommonContentUpdatePreview
}
catch (SdkException<GetShipmentContentUpdatePreviewError> ex)
{
    if (ex.Error.TryGetCommonErrorList(out var error))
    {
        // TODO: Handle 'error' of type CommonErrorList
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>inboundPlanId</code> | <code>string</code> | Identifier of an inbound plan. |
| <code>shipmentId</code> | <code>string</code> | Identifier of a shipment. |
| <code>contentUpdatePreviewId</code> | <code>string</code> | Identifier of a content update preview. |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[CommonContentUpdatePreview](Models/CommonContentUpdatePreview.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[GetShipmentContentUpdatePreviewError](Errors/GetShipmentContentUpdatePreviewError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;ListDeliveryWindowOptionsResponse&gt; ListDeliveryWindowOptions(string inboundPlanId, string shipmentId, int? pageSize, string? paginationToken, RequestOptions? requestOptions = null, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.WfsInbound.ListDeliveryWindowOptions(inboundPlanId,
        shipmentId,
        pageSize,
        paginationToken);
    // TODO: Handle 'response' of type ListDeliveryWindowOptionsResponse
}
catch (SdkException<ListDeliveryWindowOptionsError> ex)
{
    if (ex.Error.TryGetCommonErrorList(out var error))
    {
        // TODO: Handle 'error' of type CommonErrorList
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>inboundPlanId</code> | <code>string</code> | Identifier of an inbound plan. |
| <code>shipmentId</code> | <code>string</code> | The shipment to get delivery window options for. |
| <code>pageSize</code> | <code>int?</code> | The number of delivery window options to return in the response matching the given query. |
| <code>paginationToken</code> | <code>string?</code> | A token to fetch a certain page when there are multiple pages worth of results. |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[ListDeliveryWindowOptionsResponse](Models/ListDeliveryWindowOptionsResponse.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[ListDeliveryWindowOptionsError](Errors/ListDeliveryWindowOptionsError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;ListInboundPlanBoxesResponse&gt; ListInboundPlanBoxes(string inboundPlanId, int? pageSize, string? paginationToken, RequestOptions? requestOptions = null, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.WfsInbound.ListInboundPlanBoxes(inboundPlanId, pageSize, paginationToken);
    // TODO: Handle 'response' of type ListInboundPlanBoxesResponse
}
catch (SdkException<ListInboundPlanBoxesError> ex)
{
    if (ex.Error.TryGetCommonErrorList(out var error))
    {
        // TODO: Handle 'error' of type CommonErrorList
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>inboundPlanId</code> | <code>string</code> | Identifier of an inbound plan. |
| <code>pageSize</code> | <code>int?</code> | The number of boxes to return in the response matching the given query. |
| <code>paginationToken</code> | <code>string?</code> | A token to fetch a certain page when there are multiple pages worth of results. |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[ListInboundPlanBoxesResponse](Models/ListInboundPlanBoxesResponse.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[ListInboundPlanBoxesError](Errors/ListInboundPlanBoxesError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;ListInboundPlanItemsResponse&gt; ListInboundPlanItems(string inboundPlanId, int? pageSize, string? paginationToken, RequestOptions? requestOptions = null, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.WfsInbound.ListInboundPlanItems(inboundPlanId, pageSize, paginationToken);
    // TODO: Handle 'response' of type ListInboundPlanItemsResponse
}
catch (SdkException<ListInboundPlanItemsError> ex)
{
    if (ex.Error.TryGetCommonErrorList(out var error))
    {
        // TODO: Handle 'error' of type CommonErrorList
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>inboundPlanId</code> | <code>string</code> | Identifier of an inbound plan. |
| <code>pageSize</code> | <code>int?</code> | The number of items to return in the response matching the given query. |
| <code>paginationToken</code> | <code>string?</code> | A token to fetch a certain page when there are multiple pages worth of results. |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[ListInboundPlanItemsResponse](Models/ListInboundPlanItemsResponse.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[ListInboundPlanItemsError](Errors/ListInboundPlanItemsError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;ListInboundPlanPalletsResponse&gt; ListInboundPlanPallets(string inboundPlanId, int? pageSize, string? paginationToken, RequestOptions? requestOptions = null, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.WfsInbound.ListInboundPlanPallets(inboundPlanId, pageSize, paginationToken);
    // TODO: Handle 'response' of type ListInboundPlanPalletsResponse
}
catch (SdkException<ListInboundPlanPalletsError> ex)
{
    if (ex.Error.TryGetCommonErrorList(out var error))
    {
        // TODO: Handle 'error' of type CommonErrorList
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>inboundPlanId</code> | <code>string</code> | Identifier of an inbound plan. |
| <code>pageSize</code> | <code>int?</code> | The number of pallets to return in the response matching the given query. |
| <code>paginationToken</code> | <code>string?</code> | A token to fetch a certain page when there are multiple pages worth of results. |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[ListInboundPlanPalletsResponse](Models/ListInboundPlanPalletsResponse.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[ListInboundPlanPalletsError](Errors/ListInboundPlanPalletsError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;ListInboundPlansResponse&gt; ListInboundPlans(string? paginationToken, string? status, string? sortBy, string? sortOrder, int? pageSize = 10, RequestOptions? requestOptions = null, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.WfsInbound.ListInboundPlans(paginationToken, status, sortBy, sortOrder);
    // TODO: Handle 'response' of type ListInboundPlansResponse
}
catch (SdkException<ListInboundPlansError> ex)
{
    if (ex.Error.TryGetCommonErrorList(out var error))
    {
        // TODO: Handle 'error' of type CommonErrorList
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>paginationToken</code> | <code>string?</code> | A token to fetch a certain page when there are multiple pages worth of results. |
| <code>status</code> | <code>string?</code> | The status of an inbound plan. Possible values: `ACTIVE`, `VOIDED`, `SHIPPED`, `ERRORED`. |
| <code>sortBy</code> | <code>string?</code> | Sort by field. |
| <code>sortOrder</code> | <code>string?</code> | The sort order. Possible values: `ASC`, `DESC`. |
| <code>pageSize</code> | <code>int?</code> | The number of inbound plans to return in the response matching the given query.<br>**Default**: 10 |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[ListInboundPlansResponse](Models/ListInboundPlansResponse.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[ListInboundPlansError](Errors/ListInboundPlansError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;ListItemComplianceDetailsResponse&gt; ListItemComplianceDetails(IReadOnlyList&lt;string&gt; mskus, string marketplaceId, RequestOptions? requestOptions = null, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.WfsInbound.ListItemComplianceDetails(mskus, marketplaceId);
    // TODO: Handle 'response' of type ListItemComplianceDetailsResponse
}
catch (SdkException<ListItemComplianceDetailsError> ex)
{
    if (ex.Error.TryGetCommonErrorList(out var error))
    {
        // TODO: Handle 'error' of type CommonErrorList
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>mskus</code> | <code>IReadOnlyList&lt;string&gt;</code> | A list of merchant SKUs, a merchant-supplied identifier of a specific SKU. |
| <code>marketplaceId</code> | <code>string</code> | The Walmart Marketplace ID. For a list of possible values, refer to [Marketplace IDs](https://developer-docs.walmart.com/seller-api/docs/marketplace-ids). |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[ListItemComplianceDetailsResponse](Models/ListItemComplianceDetailsResponse.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[ListItemComplianceDetailsError](Errors/ListItemComplianceDetailsError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;ListInboundPlanBoxesResponse&gt; ListPackingGroupBoxes(string inboundPlanId, string packingGroupId, int? pageSize, string? paginationToken, RequestOptions? requestOptions = null, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.WfsInbound.ListPackingGroupBoxes(inboundPlanId,
        packingGroupId,
        pageSize,
        paginationToken);
    // TODO: Handle 'response' of type ListInboundPlanBoxesResponse
}
catch (SdkException<ListPackingGroupBoxesError> ex)
{
    if (ex.Error.TryGetCommonErrorList(out var error))
    {
        // TODO: Handle 'error' of type CommonErrorList
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>inboundPlanId</code> | <code>string</code> | Identifier of an inbound plan. |
| <code>packingGroupId</code> | <code>string</code> | Identifier of a packing group. |
| <code>pageSize</code> | <code>int?</code> | The number of packing group boxes to return in the response matching the given query. |
| <code>paginationToken</code> | <code>string?</code> | A token to fetch a certain page when there are multiple pages worth of results. |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[ListInboundPlanBoxesResponse](Models/ListInboundPlanBoxesResponse.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[ListPackingGroupBoxesError](Errors/ListPackingGroupBoxesError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;ListInboundPlanItemsResponse&gt; ListPackingGroupItems(string inboundPlanId, string packingGroupId, int? pageSize, string? paginationToken, RequestOptions? requestOptions = null, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.WfsInbound.ListPackingGroupItems(inboundPlanId,
        packingGroupId,
        pageSize,
        paginationToken);
    // TODO: Handle 'response' of type ListInboundPlanItemsResponse
}
catch (SdkException<ListPackingGroupItemsError> ex)
{
    if (ex.Error.TryGetCommonErrorList(out var error))
    {
        // TODO: Handle 'error' of type CommonErrorList
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>inboundPlanId</code> | <code>string</code> | Identifier of an inbound plan. |
| <code>packingGroupId</code> | <code>string</code> | Identifier of a packing group. |
| <code>pageSize</code> | <code>int?</code> | The number of packing group items to return in the response matching the given query. |
| <code>paginationToken</code> | <code>string?</code> | A token to fetch a certain page when there are multiple pages worth of results. |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[ListInboundPlanItemsResponse](Models/ListInboundPlanItemsResponse.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[ListPackingGroupItemsError](Errors/ListPackingGroupItemsError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;ListPackingOptionsResponse&gt; ListPackingOptions(string inboundPlanId, int? pageSize, string? paginationToken, RequestOptions? requestOptions = null, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.WfsInbound.ListPackingOptions(inboundPlanId, pageSize, paginationToken);
    // TODO: Handle 'response' of type ListPackingOptionsResponse
}
catch (SdkException<ListPackingOptionsError> ex)
{
    if (ex.Error.TryGetCommonErrorList(out var error))
    {
        // TODO: Handle 'error' of type CommonErrorList
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>inboundPlanId</code> | <code>string</code> | Identifier of an inbound plan. |
| <code>pageSize</code> | <code>int?</code> | The number of packing options to return in the response matching the given query. |
| <code>paginationToken</code> | <code>string?</code> | A token to fetch a certain page when there are multiple pages worth of results. |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[ListPackingOptionsResponse](Models/ListPackingOptionsResponse.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[ListPackingOptionsError](Errors/ListPackingOptionsError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;ListPlacementOptionsResponse&gt; ListPlacementOptions(string inboundPlanId, int? pageSize, string? paginationToken, RequestOptions? requestOptions = null, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.WfsInbound.ListPlacementOptions(inboundPlanId, pageSize, paginationToken);
    // TODO: Handle 'response' of type ListPlacementOptionsResponse
}
catch (SdkException<ListPlacementOptionsError> ex)
{
    if (ex.Error.TryGetCommonErrorList(out var error))
    {
        // TODO: Handle 'error' of type CommonErrorList
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>inboundPlanId</code> | <code>string</code> | Identifier of an inbound plan. |
| <code>pageSize</code> | <code>int?</code> | The number of placement options to return in the response matching the given query. |
| <code>paginationToken</code> | <code>string?</code> | A token to fetch a certain page when there are multiple pages worth of results. |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[ListPlacementOptionsResponse](Models/ListPlacementOptionsResponse.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[ListPlacementOptionsError](Errors/ListPlacementOptionsError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;ListPrepDetailsResponse&gt; ListPrepDetails(string marketplaceId, IReadOnlyList&lt;string&gt; mskus, RequestOptions? requestOptions = null, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.WfsInbound.ListPrepDetails(marketplaceId, mskus);
    // TODO: Handle 'response' of type ListPrepDetailsResponse
}
catch (SdkException<ListPrepDetailsError> ex)
{
    if (ex.Error.TryGetCommonErrorList(out var error))
    {
        // TODO: Handle 'error' of type CommonErrorList
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>marketplaceId</code> | <code>string</code> | The Walmart Marketplace ID. For a list of possible values, refer to [Marketplace IDs](https://developer-docs.walmart.com/seller-api/docs/marketplace-ids). |
| <code>mskus</code> | <code>IReadOnlyList&lt;string&gt;</code> | A list of merchant SKUs, a merchant-supplied identifier of a specific SKU. |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[ListPrepDetailsResponse](Models/ListPrepDetailsResponse.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[ListPrepDetailsError](Errors/ListPrepDetailsError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;ListInboundPlanBoxesResponse&gt; ListShipmentBoxes(string inboundPlanId, string shipmentId, int? pageSize, string? paginationToken, RequestOptions? requestOptions = null, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.WfsInbound.ListShipmentBoxes(inboundPlanId, shipmentId, pageSize, paginationToken);
    // TODO: Handle 'response' of type ListInboundPlanBoxesResponse
}
catch (SdkException<ListShipmentBoxesError> ex)
{
    if (ex.Error.TryGetCommonErrorList(out var error))
    {
        // TODO: Handle 'error' of type CommonErrorList
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>inboundPlanId</code> | <code>string</code> | Identifier of an inbound plan. |
| <code>shipmentId</code> | <code>string</code> | Identifier of a shipment. A shipment contains the boxes and units being inbounded. |
| <code>pageSize</code> | <code>int?</code> | The number of boxes to return in the response matching the given query. |
| <code>paginationToken</code> | <code>string?</code> | A token to fetch a certain page when there are multiple pages worth of results. |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[ListInboundPlanBoxesResponse](Models/ListInboundPlanBoxesResponse.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[ListShipmentBoxesError](Errors/ListShipmentBoxesError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;ListShipmentContentUpdatePreviewsResponse&gt; ListShipmentContentUpdatePreviews(string inboundPlanId, string shipmentId, int? pageSize, string? paginationToken, RequestOptions? requestOptions = null, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.WfsInbound.ListShipmentContentUpdatePreviews(inboundPlanId,
        shipmentId,
        pageSize,
        paginationToken);
    // TODO: Handle 'response' of type ListShipmentContentUpdatePreviewsResponse
}
catch (SdkException<ListShipmentContentUpdatePreviewsError> ex)
{
    if (ex.Error.TryGetCommonErrorList(out var error))
    {
        // TODO: Handle 'error' of type CommonErrorList
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>inboundPlanId</code> | <code>string</code> | Identifier of an inbound plan. |
| <code>shipmentId</code> | <code>string</code> | Identifier of a shipment. |
| <code>pageSize</code> | <code>int?</code> | The number of content update previews to return. |
| <code>paginationToken</code> | <code>string?</code> | A token to fetch a certain page when there are multiple pages worth of results. |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[ListShipmentContentUpdatePreviewsResponse](Models/ListShipmentContentUpdatePreviewsResponse.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[ListShipmentContentUpdatePreviewsError](Errors/ListShipmentContentUpdatePreviewsError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;ListInboundPlanItemsResponse&gt; ListShipmentItems(string inboundPlanId, string shipmentId, int? pageSize, string? paginationToken, RequestOptions? requestOptions = null, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.WfsInbound.ListShipmentItems(inboundPlanId, shipmentId, pageSize, paginationToken);
    // TODO: Handle 'response' of type ListInboundPlanItemsResponse
}
catch (SdkException<ListShipmentItemsError> ex)
{
    if (ex.Error.TryGetCommonErrorList(out var error))
    {
        // TODO: Handle 'error' of type CommonErrorList
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>inboundPlanId</code> | <code>string</code> | Identifier of an inbound plan. |
| <code>shipmentId</code> | <code>string</code> | Identifier of a shipment. A shipment contains the boxes and units being inbounded. |
| <code>pageSize</code> | <code>int?</code> | The number of items to return in the response matching the given query. |
| <code>paginationToken</code> | <code>string?</code> | A token to fetch a certain page when there are multiple pages worth of results. |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[ListInboundPlanItemsResponse](Models/ListInboundPlanItemsResponse.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[ListShipmentItemsError](Errors/ListShipmentItemsError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;ListInboundPlanPalletsResponse&gt; ListShipmentPallets(string inboundPlanId, string shipmentId, int? pageSize, string? paginationToken, RequestOptions? requestOptions = null, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.WfsInbound.ListShipmentPallets(inboundPlanId, shipmentId, pageSize, paginationToken);
    // TODO: Handle 'response' of type ListInboundPlanPalletsResponse
}
catch (SdkException<ListShipmentPalletsError> ex)
{
    if (ex.Error.TryGetCommonErrorList(out var error))
    {
        // TODO: Handle 'error' of type CommonErrorList
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>inboundPlanId</code> | <code>string</code> | Identifier of an inbound plan. |
| <code>shipmentId</code> | <code>string</code> | Identifier of a shipment. |
| <code>pageSize</code> | <code>int?</code> | The number of pallets to return in the response matching the given query. |
| <code>paginationToken</code> | <code>string?</code> | A token to fetch a certain page when there are multiple pages worth of results. |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[ListInboundPlanPalletsResponse](Models/ListInboundPlanPalletsResponse.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[ListShipmentPalletsError](Errors/ListShipmentPalletsError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;ListTransportationOptionsResponse&gt; ListTransportationOptions(string inboundPlanId, int? pageSize, string? paginationToken, string? placementOptionId, string? shipmentId, RequestOptions? requestOptions = null, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.WfsInbound.ListTransportationOptions(inboundPlanId,
        pageSize,
        paginationToken,
        placementOptionId,
        shipmentId);
    // TODO: Handle 'response' of type ListTransportationOptionsResponse
}
catch (SdkException<ListTransportationOptionsError> ex)
{
    if (ex.Error.TryGetCommonErrorList(out var error))
    {
        // TODO: Handle 'error' of type CommonErrorList
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>inboundPlanId</code> | <code>string</code> | Identifier of an inbound plan. |
| <code>pageSize</code> | <code>int?</code> | The number of transportation options to return in the response matching the given query. |
| <code>paginationToken</code> | <code>string?</code> | A token to fetch a certain page when there are multiple pages worth of results. |
| <code>placementOptionId</code> | <code>string?</code> | The placement option to get transportation options for. Either `placementOptionId` or `shipmentId` must be specified. |
| <code>shipmentId</code> | <code>string?</code> | The shipment to get transportation options for. Either `placementOptionId` or `shipmentId` must be specified. |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[ListTransportationOptionsResponse](Models/ListTransportationOptionsResponse.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[ListTransportationOptionsError](Errors/ListTransportationOptionsError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;ScheduleSelfShipAppointmentResponse&gt; ScheduleSelfShipAppointment(string inboundPlanId, string shipmentId, string slotId, ScheduleSelfShipAppointmentRequest body, RequestOptions? requestOptions = null, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.WfsInbound.ScheduleSelfShipAppointment(inboundPlanId, shipmentId, slotId, body);
    // TODO: Handle 'response' of type ScheduleSelfShipAppointmentResponse
}
catch (SdkException<ScheduleSelfShipAppointmentError> ex)
{
    if (ex.Error.TryGetCommonErrorList(out var error))
    {
        // TODO: Handle 'error' of type CommonErrorList
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>inboundPlanId</code> | <code>string</code> | Identifier of an inbound plan. |
| <code>shipmentId</code> | <code>string</code> | Identifier of a shipment. |
| <code>slotId</code> | <code>string</code> | An identifier to a self-ship appointment slot. |
| <code>body</code> | <code>[ScheduleSelfShipAppointmentRequest](Models/ScheduleSelfShipAppointmentRequest.cs)</code> | - |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[ScheduleSelfShipAppointmentResponse](Models/ScheduleSelfShipAppointmentResponse.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[ScheduleSelfShipAppointmentError](Errors/ScheduleSelfShipAppointmentError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;CancelInboundPlanResponse&gt; SetPackingInformation(string inboundPlanId, SetPackingInformationRequest body, RequestOptions? requestOptions = null, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.WfsInbound.SetPackingInformation(inboundPlanId, body);
    // TODO: Handle 'response' of type CancelInboundPlanResponse
}
catch (SdkException<SetPackingInformationError> ex)
{
    if (ex.Error.TryGetCommonErrorList(out var error))
    {
        // TODO: Handle 'error' of type CommonErrorList
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>inboundPlanId</code> | <code>string</code> | Identifier of an inbound plan. |
| <code>body</code> | <code>[SetPackingInformationRequest](Models/SetPackingInformationRequest.cs)</code> | - |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[CancelInboundPlanResponse](Models/CancelInboundPlanResponse.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[SetPackingInformationError](Errors/SetPackingInformationError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;CancelInboundPlanResponse&gt; SetPrepDetails(SetPrepDetailsRequest body, RequestOptions? requestOptions = null, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.WfsInbound.SetPrepDetails(body);
    // TODO: Handle 'response' of type CancelInboundPlanResponse
}
catch (SdkException<SetPrepDetailsError> ex)
{
    if (ex.Error.TryGetCommonErrorList(out var error))
    {
        // TODO: Handle 'error' of type CommonErrorList
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>body</code> | <code>[SetPrepDetailsRequest](Models/SetPrepDetailsRequest.cs)</code> | - |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[CancelInboundPlanResponse](Models/CancelInboundPlanResponse.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[SetPrepDetailsError](Errors/SetPrepDetailsError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task UpdateInboundPlanName(string inboundPlanId, UpdateInboundPlanNameRequest body, RequestOptions? requestOptions = null, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Usage

<dl>
<dd>

```csharp
try
{
    await client.WfsInbound.UpdateInboundPlanName(inboundPlanId, body);
}
catch (SdkException<UpdateInboundPlanNameError> ex)
{
    if (ex.Error.TryGetCommonErrorList(out var error))
    {
        // TODO: Handle 'error' of type CommonErrorList
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>inboundPlanId</code> | <code>string</code> | Identifier of an inbound plan. |
| <code>body</code> | <code>[UpdateInboundPlanNameRequest](Models/UpdateInboundPlanNameRequest.cs)</code> | - |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: No content

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[UpdateInboundPlanNameError](Errors/UpdateInboundPlanNameError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;CancelInboundPlanResponse&gt; UpdateItemComplianceDetails(string marketplaceId, UpdateItemComplianceDetailsRequest body, RequestOptions? requestOptions = null, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.WfsInbound.UpdateItemComplianceDetails(marketplaceId, body);
    // TODO: Handle 'response' of type CancelInboundPlanResponse
}
catch (SdkException<UpdateItemComplianceDetailsError> ex)
{
    if (ex.Error.TryGetCommonErrorList(out var error))
    {
        // TODO: Handle 'error' of type CommonErrorList
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>marketplaceId</code> | <code>string</code> | The Walmart Marketplace ID. For a list of possible values, refer to [Marketplace IDs](https://developer-docs.walmart.com/seller-api/docs/marketplace-ids). |
| <code>body</code> | <code>[UpdateItemComplianceDetailsRequest](Models/UpdateItemComplianceDetailsRequest.cs)</code> | - |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[CancelInboundPlanResponse](Models/CancelInboundPlanResponse.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[UpdateItemComplianceDetailsError](Errors/UpdateItemComplianceDetailsError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task UpdateShipmentName(string inboundPlanId, string shipmentId, UpdateShipmentNameRequest body, RequestOptions? requestOptions = null, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Usage

<dl>
<dd>

```csharp
try
{
    await client.WfsInbound.UpdateShipmentName(inboundPlanId, shipmentId, body);
}
catch (SdkException<UpdateShipmentNameError> ex)
{
    if (ex.Error.TryGetCommonErrorList(out var error))
    {
        // TODO: Handle 'error' of type CommonErrorList
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>inboundPlanId</code> | <code>string</code> | Identifier of an inbound plan. |
| <code>shipmentId</code> | <code>string</code> | Identifier of a shipment. |
| <code>body</code> | <code>[UpdateShipmentNameRequest](Models/UpdateShipmentNameRequest.cs)</code> | - |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: No content

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[UpdateShipmentNameError](Errors/UpdateShipmentNameError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;CancelInboundPlanResponse&gt; UpdateShipmentSourceAddress(string inboundPlanId, string shipmentId, UpdateShipmentSourceAddressRequest body, RequestOptions? requestOptions = null, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.WfsInbound.UpdateShipmentSourceAddress(inboundPlanId, shipmentId, body);
    // TODO: Handle 'response' of type CancelInboundPlanResponse
}
catch (SdkException<UpdateShipmentSourceAddressError> ex)
{
    if (ex.Error.TryGetCommonErrorList(out var error))
    {
        // TODO: Handle 'error' of type CommonErrorList
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>inboundPlanId</code> | <code>string</code> | Identifier of an inbound plan. |
| <code>shipmentId</code> | <code>string</code> | Identifier of a shipment. |
| <code>body</code> | <code>[UpdateShipmentSourceAddressRequest](Models/UpdateShipmentSourceAddressRequest.cs)</code> | - |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[CancelInboundPlanResponse](Models/CancelInboundPlanResponse.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[UpdateShipmentSourceAddressError](Errors/UpdateShipmentSourceAddressError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;CancelInboundPlanResponse&gt; UpdateShipmentTrackingDetails(string inboundPlanId, string shipmentId, UpdateShipmentTrackingDetailsRequest body, RequestOptions? requestOptions = null, CancellationToken ct = default);</code></summary>

<dl>
<dd>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.WfsInbound.UpdateShipmentTrackingDetails(inboundPlanId, shipmentId, body);
    // TODO: Handle 'response' of type CancelInboundPlanResponse
}
catch (SdkException<UpdateShipmentTrackingDetailsError> ex)
{
    if (ex.Error.TryGetCommonErrorList(out var error))
    {
        // TODO: Handle 'error' of type CommonErrorList
    }
}
```

</dd>
</dl>

### Parameters

<dl>
<dd>

| Name | Type | Description |
| --- | --- | --- |
| <code>inboundPlanId</code> | <code>string</code> | Identifier of an inbound plan. |
| <code>shipmentId</code> | <code>string</code> | Identifier of a shipment. |
| <code>body</code> | <code>[UpdateShipmentTrackingDetailsRequest](Models/UpdateShipmentTrackingDetailsRequest.cs)</code> | - |

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[CancelInboundPlanResponse](Models/CancelInboundPlanResponse.cs)</code>

**OnError**: <code>[SdkException](Core/Exceptions/SdkException.cs)&lt;[UpdateShipmentTrackingDetailsError](Errors/UpdateShipmentTrackingDetailsError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

