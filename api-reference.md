# Reference

Every operation below is shown in its throwing form. On an error status it throws `ApiException<TError>` — the status code, headers, content type and the operation's error type, `RawError` (the raw body) when the spec declares none — and where an operation offers an `…AsResult` sibling, that sibling returns `ApiResult<TResponse, TError>` instead. A request that produces no usable response surfaces as `SdkConnectionException` or `SdkTimeoutException`, a body that does not match the documented response type as `ResponseDeserializationException`, and a credential that cannot be applied as `AuthSchemeException`; all of them derive from `SdkException` and name the failed call. See [README → Error Handling](README.md#error-handling).

> Source: [WalmartApIsClient](src/WalmartApIs/WalmartApIsClient.cs)

## Authorization

> Source: [Authorization](src/WalmartApIs/Api/Authorization.cs)

<details>
<summary><code>Task Authorize(AuthorizeRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

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
    await client.Authorization.Authorize(new AuthorizeRequest
    {
        ResponseType = ResponseType1.Code,
        ClientId = "some example string",
        RedirectUri = "https://example.com",
        Scope = "some example string",
        State = "some example string",
        CodeChallenge = "some example string",
        CodeChallengeMethod = CodeChallengeMethod.S256,
    });
}
catch (ApiException<AuthorizeApiError> ex)
{
    if (ex.Error.TryGetAuthorizeError(out var error))
    {
        // TODO: Handle 'error' of type AuthorizeError
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[AuthorizeRequest](src/WalmartApIs/Requests/Authorization/AuthorizeRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: No content

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[AuthorizeApiError](src/WalmartApIs/Errors/AuthorizeApiError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;TokenResponse&gt; CreateToken(CreateTokenRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

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
    var response = await client.Authorization.CreateToken(new CreateTokenRequest
    {
        GrantType = GrantType.ClientCredentials,
    });
    // TODO: Handle 'response' of type TokenResponse
}
catch (ApiException<CreateTokenError> ex)
{
    if (ex.Error.TryGetOAuthError(out var error))
    {
        // TODO: Handle 'error' of type OAuthError
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[CreateTokenRequest](src/WalmartApIs/Requests/Authorization/CreateTokenRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[TokenResponse](src/WalmartApIs/Models/TokenResponse.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[CreateTokenError](src/WalmartApIs/Errors/CreateTokenError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;ClientRegistrationResponse&gt; RegisterClient(RegisterClientRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

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
    var response = await client.Authorization.RegisterClient(new RegisterClientRequest
    {
        Body = new ClientRegistrationRequest { RedirectUris = ["https://example.com"] },
    });
    // TODO: Handle 'response' of type ClientRegistrationResponse
}
catch (ApiException<RegisterClientError> ex)
{
    if (ex.Error.TryGetRegistrationError(out var error))
    {
        // TODO: Handle 'error' of type RegistrationError
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[RegisterClientRequest](src/WalmartApIs/Requests/Authorization/RegisterClientRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[ClientRegistrationResponse](src/WalmartApIs/Models/ClientRegistrationResponse.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[RegisterClientError](src/WalmartApIs/Errors/RegisterClientError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

## Catalog

> Source: [Catalog](src/WalmartApIs/Api/Catalog.cs)

<details>
<summary><code>Task&lt;Item&gt; GetCatalogItem(GetCatalogItemRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Catalog.GetCatalogItem(new GetCatalogItemRequest
    {
        WalmartItemId = "00000000000000",
        MarketplaceIds = ["some example string"],
    });
    // TODO: Handle 'response' of type Item
}
catch (ApiException<GetCatalogItemError> ex)
{
    if (ex.Error.TryGetErrorList(out var error))
    {
        // TODO: Handle 'error' of type ErrorList
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[GetCatalogItemRequest](src/WalmartApIs/Requests/Catalog/GetCatalogItemRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[Item](src/WalmartApIs/Models/Item.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[GetCatalogItemError](src/WalmartApIs/Errors/GetCatalogItemError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;ItemSearchResults&gt; SearchCatalogItems(SearchCatalogItemsRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

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
    var response = await client.Catalog.SearchCatalogItems(new SearchCatalogItemsRequest
    {
        MarketplaceIds = ["some example string"],
    });
    // TODO: Handle 'response' of type ItemSearchResults
}
catch (ApiException<SearchCatalogItemsError> ex)
{
    if (ex.Error.TryGetErrorList(out var error))
    {
        // TODO: Handle 'error' of type ErrorList
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[SearchCatalogItemsRequest](src/WalmartApIs/Requests/Catalog/SearchCatalogItemsRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[ItemSearchResults](src/WalmartApIs/Models/ItemSearchResults.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[SearchCatalogItemsError](src/WalmartApIs/Errors/SearchCatalogItemsError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

## DataKiosk

> Source: [DataKiosk](src/WalmartApIs/Api/DataKiosk.cs)

<details>
<summary><code>Task&lt;CancelQueryResponse&gt; CancelQuery(CancelQueryRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.DataKiosk.CancelQuery(new CancelQueryRequest { QueryId = "some example string" });
    // TODO: Handle 'response' of type CancelQueryResponse
}
catch (ApiException<CancelQueryError> ex)
{
    if (ex.Error.TryGetErrorList(out var error))
    {
        // TODO: Handle 'error' of type ErrorList
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[CancelQueryRequest](src/WalmartApIs/Requests/DataKiosk/CancelQueryRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[CancelQueryResponse](src/WalmartApIs/Models/CancelQueryResponse.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[CancelQueryError](src/WalmartApIs/Errors/CancelQueryError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;CreateQueryResponse&gt; CreateQuery(CreateQueryRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

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
    var response = await client.DataKiosk.CreateQuery(new CreateQueryRequest
    {
        Body = new CreateQuerySpecification { Query = "some example string" },
    });
    // TODO: Handle 'response' of type CreateQueryResponse
}
catch (ApiException<CreateQueryError> ex)
{
    if (ex.Error.TryGetErrorList(out var error))
    {
        // TODO: Handle 'error' of type ErrorList
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[CreateQueryRequest](src/WalmartApIs/Requests/DataKiosk/CreateQueryRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[CreateQueryResponse](src/WalmartApIs/Models/CreateQueryResponse.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[CreateQueryError](src/WalmartApIs/Errors/CreateQueryError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;Document&gt; GetDocument(GetDocumentRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

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
    var response = await client.DataKiosk.GetDocument(new GetDocumentRequest { DocumentId = "some example string" });
    // TODO: Handle 'response' of type Document
}
catch (ApiException<GetDocumentError> ex)
{
    if (ex.Error.TryGetErrorList(out var error))
    {
        // TODO: Handle 'error' of type ErrorList
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[GetDocumentRequest](src/WalmartApIs/Requests/DataKiosk/GetDocumentRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[Document](src/WalmartApIs/Models/Document.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[GetDocumentError](src/WalmartApIs/Errors/GetDocumentError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;GetQueriesResponse&gt; GetQueries(GetQueriesRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

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
    var response = await client.DataKiosk.GetQueries(new GetQueriesRequest());
    // TODO: Handle 'response' of type GetQueriesResponse
}
catch (ApiException<GetQueriesError> ex)
{
    if (ex.Error.TryGetErrorList(out var error))
    {
        // TODO: Handle 'error' of type ErrorList
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[GetQueriesRequest](src/WalmartApIs/Requests/DataKiosk/GetQueriesRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[GetQueriesResponse](src/WalmartApIs/Models/GetQueriesResponse.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[GetQueriesError](src/WalmartApIs/Errors/GetQueriesError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;Query&gt; GetQuery(GetQueryRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.DataKiosk.GetQuery(new GetQueryRequest { QueryId = "some example string" });
    // TODO: Handle 'response' of type Query
}
catch (ApiException<GetQueryError> ex)
{
    if (ex.Error.TryGetErrorList(out var error))
    {
        // TODO: Handle 'error' of type ErrorList
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[GetQueryRequest](src/WalmartApIs/Requests/DataKiosk/GetQueryRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[Query](src/WalmartApIs/Models/Query.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[GetQueryError](src/WalmartApIs/Errors/GetQueryError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

## Disputes

> Source: [Disputes](src/WalmartApIs/Api/Disputes.cs)

<details>
<summary><code>Task&lt;DisputeEligibilityResponse&gt; CheckDisputeEligibility(RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

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
catch (ApiException<CheckDisputeEligibilityError> ex)
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

**OnSuccess**: <code>[DisputeEligibilityResponse](src/WalmartApIs/Models/DisputeEligibilityResponse.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[CheckDisputeEligibilityError](src/WalmartApIs/Errors/CheckDisputeEligibilityError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

## Feeds

> Source: [Feeds](src/WalmartApIs/Api/Feeds.cs)

<details>
<summary><code>Task&lt;CancelFeedResponse&gt; CancelFeed(CancelFeedRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

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
    var response = await client.Feeds.CancelFeed(new CancelFeedRequest { FeedId = "some example string" });
    // TODO: Handle 'response' of type CancelFeedResponse
}
catch (ApiException<CancelFeedError> ex)
{
    if (ex.Error.TryGetErrorList1(out var error))
    {
        // TODO: Handle 'error' of type ErrorList1
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[CancelFeedRequest](src/WalmartApIs/Requests/Feeds/CancelFeedRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[CancelFeedResponse](src/WalmartApIs/Models/CancelFeedResponse.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[CancelFeedError](src/WalmartApIs/Errors/CancelFeedError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;CreateFeedResponse&gt; CreateFeed(CreateFeedRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

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
    var response = await client.Feeds.CreateFeed(new CreateFeedRequest
    {
        FeedType = FeedType.ListingsFeed,
        File = Array.Empty<byte>(),
    });
    // TODO: Handle 'response' of type CreateFeedResponse
}
catch (ApiException<CreateFeedError> ex)
{
    if (ex.Error.TryGetErrorList1(out var error))
    {
        // TODO: Handle 'error' of type ErrorList1
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[CreateFeedRequest](src/WalmartApIs/Requests/Feeds/CreateFeedRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[CreateFeedResponse](src/WalmartApIs/Models/CreateFeedResponse.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[CreateFeedError](src/WalmartApIs/Errors/CreateFeedError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;Feed&gt; GetFeed(GetFeedRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Feeds.GetFeed(new GetFeedRequest { FeedId = "some example string" });
    // TODO: Handle 'response' of type Feed
}
catch (ApiException<GetFeedError> ex)
{
    if (ex.Error.TryGetErrorList1(out var error))
    {
        // TODO: Handle 'error' of type ErrorList1
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[GetFeedRequest](src/WalmartApIs/Requests/Feeds/GetFeedRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[Feed](src/WalmartApIs/Models/Feed.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[GetFeedError](src/WalmartApIs/Errors/GetFeedError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;BinaryContent&gt; GetFeedDocument(GetFeedDocumentRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

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
    var response = await client.Feeds.GetFeedDocument(new GetFeedDocumentRequest { FeedId = "some example string" });
    // TODO: Handle 'response' of type BinaryContent
}
catch (ApiException<GetFeedDocumentError> ex)
{
    if (ex.Error.TryGetErrorList1(out var error))
    {
        // TODO: Handle 'error' of type ErrorList1
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[GetFeedDocumentRequest](src/WalmartApIs/Requests/Feeds/GetFeedDocumentRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>BinaryContent</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[GetFeedDocumentError](src/WalmartApIs/Errors/GetFeedDocumentError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;GetFeedsResponse&gt; GetFeeds(GetFeedsRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Feeds.GetFeeds(new GetFeedsRequest());
    // TODO: Handle 'response' of type GetFeedsResponse
}
catch (ApiException<GetFeedsError> ex)
{
    if (ex.Error.TryGetErrorList1(out var error))
    {
        // TODO: Handle 'error' of type ErrorList1
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[GetFeedsRequest](src/WalmartApIs/Requests/Feeds/GetFeedsRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[GetFeedsResponse](src/WalmartApIs/Models/GetFeedsResponse.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[GetFeedsError](src/WalmartApIs/Errors/GetFeedsError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

## FinalPayout

> Source: [FinalPayout](src/WalmartApIs/Api/FinalPayout.cs)

<details>
<summary><code>Task&lt;FinalPayoutCaseStatusResponse&gt; GetFinalPayoutCaseStatus(RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

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
catch (ApiException<GetFinalPayoutCaseStatusError> ex)
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

**OnSuccess**: <code>[FinalPayoutCaseStatusResponse](src/WalmartApIs/Models/FinalPayoutCaseStatusResponse.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[GetFinalPayoutCaseStatusError](src/WalmartApIs/Errors/GetFinalPayoutCaseStatusError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;FinalPayoutCaseStatusResponse&gt; UpdateFinalPayoutCaseStatus(UpdateFinalPayoutCaseStatusRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

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
    var response = await client.FinalPayout.UpdateFinalPayoutCaseStatus(new UpdateFinalPayoutCaseStatusRequest
    {
        Body = new DisbursementsV4FinalPayoutCaseUpdateStatusRequest { Status = Status3.Resolved },
    });
    // TODO: Handle 'response' of type FinalPayoutCaseStatusResponse
}
catch (ApiException<UpdateFinalPayoutCaseStatusError> ex)
{
    if (ex.Error.TryGetErrorList(out var error))
    {
        // TODO: Handle 'error' of type ErrorList
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[UpdateFinalPayoutCaseStatusRequest](src/WalmartApIs/Requests/FinalPayout/UpdateFinalPayoutCaseStatusRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[FinalPayoutCaseStatusResponse](src/WalmartApIs/Models/FinalPayoutCaseStatusResponse.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[UpdateFinalPayoutCaseStatusError](src/WalmartApIs/Errors/UpdateFinalPayoutCaseStatusError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

## Finances

> Source: [Finances](src/WalmartApIs/Api/Finances.cs)

<details>
<summary><code>Task&lt;object&gt; ListFinancialEventGroups(ListFinancialEventGroupsRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

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
    var response = await client.Finances.ListFinancialEventGroups(new ListFinancialEventGroupsRequest());
    // TODO: Handle 'response' of type object
}
catch (ApiException<ListFinancialEventGroupsError> ex)
{
    if (ex.Error.TryGetErrorList(out var error))
    {
        // TODO: Handle 'error' of type ErrorList
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[ListFinancialEventGroupsRequest](src/WalmartApIs/Requests/Finances/ListFinancialEventGroupsRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>object</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[ListFinancialEventGroupsError](src/WalmartApIs/Errors/ListFinancialEventGroupsError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;object&gt; ListFinancialEvents(ListFinancialEventsRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

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
    var response = await client.Finances.ListFinancialEvents(new ListFinancialEventsRequest());
    // TODO: Handle 'response' of type object
}
catch (ApiException<ListFinancialEventsError> ex)
{
    if (ex.Error.TryGetErrorList(out var error))
    {
        // TODO: Handle 'error' of type ErrorList
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[ListFinancialEventsRequest](src/WalmartApIs/Requests/Finances/ListFinancialEventsRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>object</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[ListFinancialEventsError](src/WalmartApIs/Errors/ListFinancialEventsError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;object&gt; ListFinancialEventsByGroupId(ListFinancialEventsByGroupIdRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

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
    var response = await client.Finances.ListFinancialEventsByGroupId(new ListFinancialEventsByGroupIdRequest
    {
        EventGroupId = "some example string",
    });
    // TODO: Handle 'response' of type object
}
catch (ApiException<ListFinancialEventsByGroupIdError> ex)
{
    if (ex.Error.TryGetErrorList(out var error))
    {
        // TODO: Handle 'error' of type ErrorList
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[ListFinancialEventsByGroupIdRequest](src/WalmartApIs/Requests/Finances/ListFinancialEventsByGroupIdRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>object</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[ListFinancialEventsByGroupIdError](src/WalmartApIs/Errors/ListFinancialEventsByGroupIdError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;object&gt; ListFinancialEventsByOrderId(ListFinancialEventsByOrderIdRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

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
    var response = await client.Finances.ListFinancialEventsByOrderId(new ListFinancialEventsByOrderIdRequest
    {
        OrderId = "some example string",
    });
    // TODO: Handle 'response' of type object
}
catch (ApiException<ListFinancialEventsByOrderIdError> ex)
{
    if (ex.Error.TryGetErrorList(out var error))
    {
        // TODO: Handle 'error' of type ErrorList
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[ListFinancialEventsByOrderIdRequest](src/WalmartApIs/Requests/Finances/ListFinancialEventsByOrderIdRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>object</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[ListFinancialEventsByOrderIdError](src/WalmartApIs/Errors/ListFinancialEventsByOrderIdError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

## FulfillmentOutbound

> Source: [FulfillmentOutbound](src/WalmartApIs/Api/FulfillmentOutbound.cs)

<details>
<summary><code>Task&lt;CancelFulfillmentOrderResponse&gt; CancelFulfillmentOrder(CancelFulfillmentOrderRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.FulfillmentOutbound.CancelFulfillmentOrder(new CancelFulfillmentOrderRequest
    {
        SellerFulfillmentOrderId = "some example string",
    });
    // TODO: Handle 'response' of type CancelFulfillmentOrderResponse
}
catch (ApiException<CancelFulfillmentOrderError> ex)
{
    if (ex.Error.TryGetErrorList(out var error))
    {
        // TODO: Handle 'error' of type ErrorList
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[CancelFulfillmentOrderRequest](src/WalmartApIs/Requests/FulfillmentOutbound/CancelFulfillmentOrderRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[CancelFulfillmentOrderResponse](src/WalmartApIs/Models/CancelFulfillmentOrderResponse.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[CancelFulfillmentOrderError](src/WalmartApIs/Errors/CancelFulfillmentOrderError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;CreateFulfillmentOrderResponse&gt; CreateFulfillmentOrder(CreateFulfillmentOrderOperationRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.FulfillmentOutbound.CreateFulfillmentOrder(new CreateFulfillmentOrderOperationRequest
    {
        Body = new CreateFulfillmentOrderRequest
        {
            SellerFulfillmentOrderId = "some example string",
            DisplayableOrderId = "some example string",
            DisplayableOrderDate = DateTimeOffset.Parse("2024-01-15T09:30:00Z"),
            ShippingSpeedCategory = ShippingSpeedCategory.Standard,
            DestinationAddress = new Address
            {
                Name = "some example string",
                AddressLine1 = "some example string",
                City = "some example string",
                StateOrRegion = "some example string",
                PostalCode = "some example string",
                CountryCode = "some example string",
            },
            Items = [
                new CreateFulfillmentOrderItem
                {
                    SellerSku = "some example string",
                    SellerFulfillmentOrderItemId = "some example string",
                    Quantity = 1,
                },
            ],
        },
    });
    // TODO: Handle 'response' of type CreateFulfillmentOrderResponse
}
catch (ApiException<CreateFulfillmentOrderError> ex)
{
    if (ex.Error.TryGetErrorList(out var error))
    {
        // TODO: Handle 'error' of type ErrorList
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[CreateFulfillmentOrderOperationRequest](src/WalmartApIs/Requests/FulfillmentOutbound/CreateFulfillmentOrderOperationRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[CreateFulfillmentOrderResponse](src/WalmartApIs/Models/CreateFulfillmentOrderResponse.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[CreateFulfillmentOrderError](src/WalmartApIs/Errors/CreateFulfillmentOrderError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;GetFulfillmentOrderResponse&gt; GetFulfillmentOrder(GetFulfillmentOrderRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.FulfillmentOutbound.GetFulfillmentOrder(new GetFulfillmentOrderRequest
    {
        SellerFulfillmentOrderId = "some example string",
    });
    // TODO: Handle 'response' of type GetFulfillmentOrderResponse
}
catch (ApiException<GetFulfillmentOrderError> ex)
{
    if (ex.Error.TryGetErrorList(out var error))
    {
        // TODO: Handle 'error' of type ErrorList
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[GetFulfillmentOrderRequest](src/WalmartApIs/Requests/FulfillmentOutbound/GetFulfillmentOrderRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[GetFulfillmentOrderResponse](src/WalmartApIs/Models/GetFulfillmentOrderResponse.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[GetFulfillmentOrderError](src/WalmartApIs/Errors/GetFulfillmentOrderError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;GetFulfillmentOrderShipmentsResponse&gt; GetFulfillmentOrderShipments(GetFulfillmentOrderShipmentsRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.FulfillmentOutbound.GetFulfillmentOrderShipments(new GetFulfillmentOrderShipmentsRequest
    {
        SellerFulfillmentOrderId = "some example string",
    });
    // TODO: Handle 'response' of type GetFulfillmentOrderShipmentsResponse
}
catch (ApiException<GetFulfillmentOrderShipmentsError> ex)
{
    if (ex.Error.TryGetErrorList(out var error))
    {
        // TODO: Handle 'error' of type ErrorList
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[GetFulfillmentOrderShipmentsRequest](src/WalmartApIs/Requests/FulfillmentOutbound/GetFulfillmentOrderShipmentsRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[GetFulfillmentOrderShipmentsResponse](src/WalmartApIs/Models/GetFulfillmentOrderShipmentsResponse.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[GetFulfillmentOrderShipmentsError](src/WalmartApIs/Errors/GetFulfillmentOrderShipmentsError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;GetFulfillmentPreviewResponse&gt; GetFulfillmentPreview(GetFulfillmentPreviewOperationRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

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
    var response = await client.FulfillmentOutbound.GetFulfillmentPreview(new GetFulfillmentPreviewOperationRequest
    {
        Body = new GetFulfillmentPreviewRequest
        {
            Address = new Address
            {
                Name = "some example string",
                AddressLine1 = "some example string",
                City = "some example string",
                StateOrRegion = "some example string",
                PostalCode = "some example string",
                CountryCode = "some example string",
            },
            Items = [
                new GetFulfillmentPreviewItem
                {
                    SellerSku = "some example string",
                    Quantity = 1,
                    SellerFulfillmentOrderItemId = "some example string",
                },
            ],
        },
    });
    // TODO: Handle 'response' of type GetFulfillmentPreviewResponse
}
catch (ApiException<GetFulfillmentPreviewError> ex)
{
    if (ex.Error.TryGetErrorList(out var error))
    {
        // TODO: Handle 'error' of type ErrorList
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[GetFulfillmentPreviewOperationRequest](src/WalmartApIs/Requests/FulfillmentOutbound/GetFulfillmentPreviewOperationRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[GetFulfillmentPreviewResponse](src/WalmartApIs/Models/GetFulfillmentPreviewResponse.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[GetFulfillmentPreviewError](src/WalmartApIs/Errors/GetFulfillmentPreviewError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;ListAllFulfillmentOrdersResponse&gt; ListAllFulfillmentOrders(ListAllFulfillmentOrdersRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.FulfillmentOutbound.ListAllFulfillmentOrders(new ListAllFulfillmentOrdersRequest());
    // TODO: Handle 'response' of type ListAllFulfillmentOrdersResponse
}
catch (ApiException<ListAllFulfillmentOrdersError> ex)
{
    if (ex.Error.TryGetErrorList(out var error))
    {
        // TODO: Handle 'error' of type ErrorList
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[ListAllFulfillmentOrdersRequest](src/WalmartApIs/Requests/FulfillmentOutbound/ListAllFulfillmentOrdersRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[ListAllFulfillmentOrdersResponse](src/WalmartApIs/Models/ListAllFulfillmentOrdersResponse.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[ListAllFulfillmentOrdersError](src/WalmartApIs/Errors/ListAllFulfillmentOrdersError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;UpdateFulfillmentOrderResponse&gt; UpdateFulfillmentOrder(UpdateFulfillmentOrderOperationRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.FulfillmentOutbound.UpdateFulfillmentOrder(new UpdateFulfillmentOrderOperationRequest
    {
        SellerFulfillmentOrderId = "some example string",
        Body = new UpdateFulfillmentOrderRequest(),
    });
    // TODO: Handle 'response' of type UpdateFulfillmentOrderResponse
}
catch (ApiException<UpdateFulfillmentOrderError> ex)
{
    if (ex.Error.TryGetErrorList(out var error))
    {
        // TODO: Handle 'error' of type ErrorList
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[UpdateFulfillmentOrderOperationRequest](src/WalmartApIs/Requests/FulfillmentOutbound/UpdateFulfillmentOrderOperationRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[UpdateFulfillmentOrderResponse](src/WalmartApIs/Models/UpdateFulfillmentOrderResponse.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[UpdateFulfillmentOrderError](src/WalmartApIs/Errors/UpdateFulfillmentOrderError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

## Inventory

> Source: [Inventory](src/WalmartApIs/Api/Inventory.cs)

<details>
<summary><code>Task&lt;BulkUpdateInventoryResponse&gt; BulkUpdateInventory(BulkUpdateInventoryOperationRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

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
    var response = await client.Inventory.BulkUpdateInventory(new BulkUpdateInventoryOperationRequest
    {
        Body = new BulkUpdateInventoryRequest
        {
            Items = [new BulkInventoryItem { SellerSku = "some example string", Quantity = 1 }],
        },
    });
    // TODO: Handle 'response' of type BulkUpdateInventoryResponse
}
catch (ApiException<BulkUpdateInventoryError> ex)
{
    if (ex.Error.TryGetErrorList(out var error))
    {
        // TODO: Handle 'error' of type ErrorList
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[BulkUpdateInventoryOperationRequest](src/WalmartApIs/Requests/Inventory/BulkUpdateInventoryOperationRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[BulkUpdateInventoryResponse](src/WalmartApIs/Models/BulkUpdateInventoryResponse.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[BulkUpdateInventoryError](src/WalmartApIs/Errors/BulkUpdateInventoryError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;InventorySummary&gt; GetInventoryForSku(GetInventoryForSkuRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Inventory.GetInventoryForSku(new GetInventoryForSkuRequest
    {
        Sku = "some example string",
    });
    // TODO: Handle 'response' of type InventorySummary
}
catch (ApiException<GetInventoryForSkuError> ex)
{
    if (ex.Error.TryGetErrorList(out var error))
    {
        // TODO: Handle 'error' of type ErrorList
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[GetInventoryForSkuRequest](src/WalmartApIs/Requests/Inventory/GetInventoryForSkuRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[InventorySummary](src/WalmartApIs/Models/InventorySummary.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[GetInventoryForSkuError](src/WalmartApIs/Errors/GetInventoryForSkuError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;GetInventorySummariesResponse&gt; GetInventorySummaries(GetInventorySummariesRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Inventory.GetInventorySummaries(new GetInventorySummariesRequest());
    // TODO: Handle 'response' of type GetInventorySummariesResponse
}
catch (ApiException<GetInventorySummariesError> ex)
{
    if (ex.Error.TryGetErrorList(out var error))
    {
        // TODO: Handle 'error' of type ErrorList
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[GetInventorySummariesRequest](src/WalmartApIs/Requests/Inventory/GetInventorySummariesRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[GetInventorySummariesResponse](src/WalmartApIs/Models/GetInventorySummariesResponse.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[GetInventorySummariesError](src/WalmartApIs/Errors/GetInventorySummariesError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;UpdateInventoryResponse&gt; UpdateInventoryForSku(UpdateInventoryForSkuRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Inventory.UpdateInventoryForSku(new UpdateInventoryForSkuRequest
    {
        Sku = "some example string",
        Body = new UpdateInventoryRequest { Quantity = 1 },
    });
    // TODO: Handle 'response' of type UpdateInventoryResponse
}
catch (ApiException<UpdateInventoryForSkuError> ex)
{
    if (ex.Error.TryGetErrorList(out var error))
    {
        // TODO: Handle 'error' of type ErrorList
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[UpdateInventoryForSkuRequest](src/WalmartApIs/Requests/Inventory/UpdateInventoryForSkuRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[UpdateInventoryResponse](src/WalmartApIs/Models/UpdateInventoryResponse.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[UpdateInventoryForSkuError](src/WalmartApIs/Errors/UpdateInventoryForSkuError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

## ListingsItems

> Source: [ListingsItems](src/WalmartApIs/Api/ListingsItems.cs)

<details>
<summary><code>Task&lt;ListingsItemSubmissionResponse&gt; DeleteListingsItem(DeleteListingsItemRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.ListingsItems.DeleteListingsItem(new DeleteListingsItemRequest
    {
        SellerId = "some example string",
        Sku = "some example string",
        MarketplaceIds = ["some example string"],
    });
    // TODO: Handle 'response' of type ListingsItemSubmissionResponse
}
catch (ApiException<DeleteListingsItemError> ex)
{
    if (ex.Error.TryGetErrorList(out var error))
    {
        // TODO: Handle 'error' of type ErrorList
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[DeleteListingsItemRequest](src/WalmartApIs/Requests/ListingsItems/DeleteListingsItemRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[ListingsItemSubmissionResponse](src/WalmartApIs/Models/ListingsItemSubmissionResponse.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[DeleteListingsItemError](src/WalmartApIs/Errors/DeleteListingsItemError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;Item1&gt; GetListingsItem(GetListingsItemRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.ListingsItems.GetListingsItem(new GetListingsItemRequest
    {
        SellerId = "some example string",
        Sku = "some example string",
        MarketplaceIds = ["some example string"],
    });
    // TODO: Handle 'response' of type Item1
}
catch (ApiException<GetListingsItemError> ex)
{
    if (ex.Error.TryGetErrorList(out var error))
    {
        // TODO: Handle 'error' of type ErrorList
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[GetListingsItemRequest](src/WalmartApIs/Requests/ListingsItems/GetListingsItemRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[Item1](src/WalmartApIs/Models/Item1.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[GetListingsItemError](src/WalmartApIs/Errors/GetListingsItemError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;ListingsItemSubmissionResponse&gt; PatchListingsItem(PatchListingsItemRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.ListingsItems.PatchListingsItem(new PatchListingsItemRequest
    {
        SellerId = "some example string",
        Sku = "some example string",
        MarketplaceIds = ["some example string"],
        Body = new ListingsItemPatchRequest
        {
            ProductType = "some example string",
            Patches = [new PatchOperation { Op = Op.Add, Path = "some example string" }],
        },
    });
    // TODO: Handle 'response' of type ListingsItemSubmissionResponse
}
catch (ApiException<PatchListingsItemError> ex)
{
    if (ex.Error.TryGetErrorList(out var error))
    {
        // TODO: Handle 'error' of type ErrorList
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[PatchListingsItemRequest](src/WalmartApIs/Requests/ListingsItems/PatchListingsItemRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[ListingsItemSubmissionResponse](src/WalmartApIs/Models/ListingsItemSubmissionResponse.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[PatchListingsItemError](src/WalmartApIs/Errors/PatchListingsItemError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;ListingsItemSubmissionResponse&gt; PutListingsItem(PutListingsItemRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.ListingsItems.PutListingsItem(new PutListingsItemRequest
    {
        SellerId = "some example string",
        Sku = "some example string",
        MarketplaceIds = ["some example string"],
        Body = new ListingsItemPutRequest { ProductType = "some example string", Attributes = attributes },
    });
    // TODO: Handle 'response' of type ListingsItemSubmissionResponse
}
catch (ApiException<PutListingsItemError> ex)
{
    if (ex.Error.TryGetErrorList(out var error))
    {
        // TODO: Handle 'error' of type ErrorList
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[PutListingsItemRequest](src/WalmartApIs/Requests/ListingsItems/PutListingsItemRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[ListingsItemSubmissionResponse](src/WalmartApIs/Models/ListingsItemSubmissionResponse.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[PutListingsItemError](src/WalmartApIs/Errors/PutListingsItemError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;ItemSearchResults1&gt; SearchListingsItems(SearchListingsItemsRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

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
    var response = await client.ListingsItems.SearchListingsItems(new SearchListingsItemsRequest
    {
        SellerId = "some example string",
        MarketplaceIds = ["some example string"],
    });
    // TODO: Handle 'response' of type ItemSearchResults1
}
catch (ApiException<SearchListingsItemsError> ex)
{
    if (ex.Error.TryGetErrorList(out var error))
    {
        // TODO: Handle 'error' of type ErrorList
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[SearchListingsItemsRequest](src/WalmartApIs/Requests/ListingsItems/SearchListingsItemsRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[ItemSearchResults1](src/WalmartApIs/Models/ItemSearchResults1.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[SearchListingsItemsError](src/WalmartApIs/Errors/SearchListingsItemsError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

## ListingsRestrictions

> Source: [ListingsRestrictions](src/WalmartApIs/Api/ListingsRestrictions.cs)

<details>
<summary><code>Task&lt;RestrictionList&gt; GetListingsRestrictions(GetListingsRestrictionsRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

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
    var response = await client.ListingsRestrictions.GetListingsRestrictions(new GetListingsRestrictionsRequest
    {
        Asin = "some example string",
        ConditionType = ConditionType1.NewNew,
        SellerId = "some example string",
        MarketplaceIds = ["some example string"],
    });
    // TODO: Handle 'response' of type RestrictionList
}
catch (ApiException<GetListingsRestrictionsError> ex)
{
    if (ex.Error.TryGetErrorList(out var error))
    {
        // TODO: Handle 'error' of type ErrorList
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[GetListingsRestrictionsRequest](src/WalmartApIs/Requests/ListingsRestrictions/GetListingsRestrictionsRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[RestrictionList](src/WalmartApIs/Models/RestrictionList.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[GetListingsRestrictionsError](src/WalmartApIs/Errors/GetListingsRestrictionsError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

## MerchantFulfillment

> Source: [MerchantFulfillment](src/WalmartApIs/Api/MerchantFulfillment.cs)

<details>
<summary><code>Task&lt;CancelShipmentResponse&gt; CancelShipment(CancelShipmentRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.MerchantFulfillment.CancelShipment(new CancelShipmentRequest
    {
        ShipmentId = "some example string",
    });
    // TODO: Handle 'response' of type CancelShipmentResponse
}
catch (ApiException<CancelShipmentError> ex)
{
    if (ex.Error.TryGetErrorList(out var error))
    {
        // TODO: Handle 'error' of type ErrorList
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[CancelShipmentRequest](src/WalmartApIs/Requests/MerchantFulfillment/CancelShipmentRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[CancelShipmentResponse](src/WalmartApIs/Models/CancelShipmentResponse.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[CancelShipmentError](src/WalmartApIs/Errors/CancelShipmentError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;CreateShipmentResponse&gt; CreateShipment(CreateShipmentOperationRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

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
    var response = await client.MerchantFulfillment.CreateShipment(new CreateShipmentOperationRequest
    {
        Body = new CreateShipmentRequest
        {
            ShipmentRequestDetails = new ShipmentRequestDetails
            {
                PurchaseOrderId = "some example string",
                ShipFromAddress = new Address1
                {
                    Name = "some example string",
                    AddressLine1 = "some example string",
                    City = "some example string",
                    StateOrRegion = "some example string",
                    PostalCode = "some example string",
                    CountryCode = "some example string",
                },
                ShipToAddress = new Address1
                {
                    Name = "some example string",
                    AddressLine1 = "some example string",
                    City = "some example string",
                    StateOrRegion = "some example string",
                    PostalCode = "some example string",
                    CountryCode = "some example string",
                },
                PackageDimensions = new PackageDimensions
                {
                    Length = 1.5d,
                    Width = 1.5d,
                    Height = 1.5d,
                    Unit = Unit.Inches,
                },
                Weight = new Weight { Value = 1.5d, Unit = Unit1.Oz },
                ShipDate = DateTimeOffset.Parse("2024-01-15T09:30:00Z"),
                ShippingServiceOptions = new ShippingServiceOptions(),
            },
            ShippingServiceId = "some example string",
        },
    });
    // TODO: Handle 'response' of type CreateShipmentResponse
}
catch (ApiException<CreateShipmentError> ex)
{
    if (ex.Error.TryGetErrorList(out var error))
    {
        // TODO: Handle 'error' of type ErrorList
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[CreateShipmentOperationRequest](src/WalmartApIs/Requests/MerchantFulfillment/CreateShipmentOperationRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[CreateShipmentResponse](src/WalmartApIs/Models/CreateShipmentResponse.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[CreateShipmentError](src/WalmartApIs/Errors/CreateShipmentError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;GetEligibleShippingServicesResponse&gt; GetEligibleShippingServices(GetEligibleShippingServicesOperationRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

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
    var response = await client.MerchantFulfillment.GetEligibleShippingServices(
        new GetEligibleShippingServicesOperationRequest
        {
            Body = new GetEligibleShippingServicesRequest
            {
                ShipmentRequestDetails = new ShipmentRequestDetails
                {
                    PurchaseOrderId = "some example string",
                    ShipFromAddress = new Address1
                    {
                        Name = "some example string",
                        AddressLine1 = "some example string",
                        City = "some example string",
                        StateOrRegion = "some example string",
                        PostalCode = "some example string",
                        CountryCode = "some example string",
                    },
                    ShipToAddress = new Address1
                    {
                        Name = "some example string",
                        AddressLine1 = "some example string",
                        City = "some example string",
                        StateOrRegion = "some example string",
                        PostalCode = "some example string",
                        CountryCode = "some example string",
                    },
                    PackageDimensions = new PackageDimensions
                    {
                        Length = 1.5d,
                        Width = 1.5d,
                        Height = 1.5d,
                        Unit = Unit.Inches,
                    },
                    Weight = new Weight { Value = 1.5d, Unit = Unit1.Oz },
                    ShipDate = DateTimeOffset.Parse("2024-01-15T09:30:00Z"),
                    ShippingServiceOptions = new ShippingServiceOptions(),
                },
            },
        });
    // TODO: Handle 'response' of type GetEligibleShippingServicesResponse
}
catch (ApiException<GetEligibleShippingServicesError> ex)
{
    if (ex.Error.TryGetErrorList(out var error))
    {
        // TODO: Handle 'error' of type ErrorList
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[GetEligibleShippingServicesOperationRequest](src/WalmartApIs/Requests/MerchantFulfillment/GetEligibleShippingServicesOperationRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[GetEligibleShippingServicesResponse](src/WalmartApIs/Models/GetEligibleShippingServicesResponse.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[GetEligibleShippingServicesError](src/WalmartApIs/Errors/GetEligibleShippingServicesError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;Label&gt; GetLabel(GetLabelRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

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
    var response = await client.MerchantFulfillment.GetLabel(new GetLabelRequest
    {
        ShipmentId = "some example string",
    });
    // TODO: Handle 'response' of type Label
}
catch (ApiException<GetLabelError> ex)
{
    if (ex.Error.TryGetErrorList(out var error))
    {
        // TODO: Handle 'error' of type ErrorList
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[GetLabelRequest](src/WalmartApIs/Requests/MerchantFulfillment/GetLabelRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[Label](src/WalmartApIs/Models/Label.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[GetLabelError](src/WalmartApIs/Errors/GetLabelError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;GetShipmentResponse&gt; GetShipment2(GetShipment2Request request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.MerchantFulfillment.GetShipment2(new GetShipment2Request
    {
        ShipmentId = "some example string",
    });
    // TODO: Handle 'response' of type GetShipmentResponse
}
catch (ApiException<GetShipment2Error> ex)
{
    if (ex.Error.TryGetErrorList(out var error))
    {
        // TODO: Handle 'error' of type ErrorList
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[GetShipment2Request](src/WalmartApIs/Requests/MerchantFulfillment/GetShipment2Request.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[GetShipmentResponse](src/WalmartApIs/Models/GetShipmentResponse.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[GetShipment2Error](src/WalmartApIs/Errors/GetShipment2Error.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

## Orders

> Source: [Orders](src/WalmartApIs/Api/Orders.cs)

<details>
<summary><code>Task&lt;AcknowledgeOrderResponse&gt; AcknowledgeOrder(AcknowledgeOrderOperationRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Orders.AcknowledgeOrder(new AcknowledgeOrderOperationRequest
    {
        PurchaseOrderId = "some example string",
        Body = new AcknowledgeOrderRequest
        {
            OrderLines = [new AcknowledgeOrderLine { LineNumber = "some example string" }],
        },
    });
    // TODO: Handle 'response' of type AcknowledgeOrderResponse
}
catch (ApiException<AcknowledgeOrderError> ex)
{
    if (ex.Error.TryGetErrorList(out var error))
    {
        // TODO: Handle 'error' of type ErrorList
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[AcknowledgeOrderOperationRequest](src/WalmartApIs/Requests/Orders/AcknowledgeOrderOperationRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[AcknowledgeOrderResponse](src/WalmartApIs/Models/AcknowledgeOrderResponse.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[AcknowledgeOrderError](src/WalmartApIs/Errors/AcknowledgeOrderError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;CancelOrderLinesResponse&gt; CancelOrderLines(CancelOrderLinesOperationRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Orders.CancelOrderLines(new CancelOrderLinesOperationRequest
    {
        PurchaseOrderId = "some example string",
        Body = new CancelOrderLinesRequest
        {
            OrderLines = [
                new CancelOrderLine
                {
                    LineNumber = "some example string",
                    CancellationReason = CancellationReason.CustomerRequested,
                },
            ],
        },
    });
    // TODO: Handle 'response' of type CancelOrderLinesResponse
}
catch (ApiException<CancelOrderLinesError> ex)
{
    if (ex.Error.TryGetErrorList(out var error))
    {
        // TODO: Handle 'error' of type ErrorList
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[CancelOrderLinesOperationRequest](src/WalmartApIs/Requests/Orders/CancelOrderLinesOperationRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[CancelOrderLinesResponse](src/WalmartApIs/Models/CancelOrderLinesResponse.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[CancelOrderLinesError](src/WalmartApIs/Errors/CancelOrderLinesError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;DeliverOrderLinesResponse&gt; DeliverOrderLines(DeliverOrderLinesOperationRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

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
    var response = await client.Orders.DeliverOrderLines(new DeliverOrderLinesOperationRequest
    {
        PurchaseOrderId = "some example string",
        Body = new DeliverOrderLinesRequest
        {
            OrderLines = [new DeliverOrderLine { LineNumber = "some example string" }],
        },
    });
    // TODO: Handle 'response' of type DeliverOrderLinesResponse
}
catch (ApiException<DeliverOrderLinesError> ex)
{
    if (ex.Error.TryGetErrorList(out var error))
    {
        // TODO: Handle 'error' of type ErrorList
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[DeliverOrderLinesOperationRequest](src/WalmartApIs/Requests/Orders/DeliverOrderLinesOperationRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[DeliverOrderLinesResponse](src/WalmartApIs/Models/DeliverOrderLinesResponse.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[DeliverOrderLinesError](src/WalmartApIs/Errors/DeliverOrderLinesError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;GetOrderResponse&gt; GetOrder(GetOrderRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Orders.GetOrder(new GetOrderRequest { PurchaseOrderId = "some example string" });
    // TODO: Handle 'response' of type GetOrderResponse
}
catch (ApiException<GetOrderError> ex)
{
    if (ex.Error.TryGetErrorList(out var error))
    {
        // TODO: Handle 'error' of type ErrorList
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[GetOrderRequest](src/WalmartApIs/Requests/Orders/GetOrderRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[GetOrderResponse](src/WalmartApIs/Models/GetOrderResponse.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[GetOrderError](src/WalmartApIs/Errors/GetOrderError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;GetOrderAddressResponse&gt; GetOrderAddress(GetOrderAddressRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

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
    var response = await client.Orders.GetOrderAddress(new GetOrderAddressRequest
    {
        PurchaseOrderId = "some example string",
    });
    // TODO: Handle 'response' of type GetOrderAddressResponse
}
catch (ApiException<GetOrderAddressError> ex)
{
    if (ex.Error.TryGetErrorList(out var error))
    {
        // TODO: Handle 'error' of type ErrorList
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[GetOrderAddressRequest](src/WalmartApIs/Requests/Orders/GetOrderAddressRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[GetOrderAddressResponse](src/WalmartApIs/Models/GetOrderAddressResponse.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[GetOrderAddressError](src/WalmartApIs/Errors/GetOrderAddressError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;GetOrderBuyerInfoResponse&gt; GetOrderBuyerInfo(GetOrderBuyerInfoRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

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
    var response = await client.Orders.GetOrderBuyerInfo(new GetOrderBuyerInfoRequest
    {
        PurchaseOrderId = "some example string",
    });
    // TODO: Handle 'response' of type GetOrderBuyerInfoResponse
}
catch (ApiException<GetOrderBuyerInfoError> ex)
{
    if (ex.Error.TryGetErrorList(out var error))
    {
        // TODO: Handle 'error' of type ErrorList
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[GetOrderBuyerInfoRequest](src/WalmartApIs/Requests/Orders/GetOrderBuyerInfoRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[GetOrderBuyerInfoResponse](src/WalmartApIs/Models/GetOrderBuyerInfoResponse.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[GetOrderBuyerInfoError](src/WalmartApIs/Errors/GetOrderBuyerInfoError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;GetFulfillmentOrderShipmentsResponse&gt; GetOrderItems(GetOrderItemsRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

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
    var response = await client.Orders.GetOrderItems(new GetOrderItemsRequest
    {
        PurchaseOrderId = "some example string",
    });
    // TODO: Handle 'response' of type GetFulfillmentOrderShipmentsResponse
}
catch (ApiException<GetOrderItemsError> ex)
{
    if (ex.Error.TryGetErrorList(out var error))
    {
        // TODO: Handle 'error' of type ErrorList
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[GetOrderItemsRequest](src/WalmartApIs/Requests/Orders/GetOrderItemsRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[GetFulfillmentOrderShipmentsResponse](src/WalmartApIs/Models/GetFulfillmentOrderShipmentsResponse.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[GetOrderItemsError](src/WalmartApIs/Errors/GetOrderItemsError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;GetOrderRegulatedInfoResponse&gt; GetOrderRegulatedInfo(GetOrderRegulatedInfoRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

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
    var response = await client.Orders.GetOrderRegulatedInfo(new GetOrderRegulatedInfoRequest
    {
        PurchaseOrderId = "some example string",
    });
    // TODO: Handle 'response' of type GetOrderRegulatedInfoResponse
}
catch (ApiException<GetOrderRegulatedInfoError> ex)
{
    if (ex.Error.TryGetErrorList(out var error))
    {
        // TODO: Handle 'error' of type ErrorList
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[GetOrderRegulatedInfoRequest](src/WalmartApIs/Requests/Orders/GetOrderRegulatedInfoRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[GetOrderRegulatedInfoResponse](src/WalmartApIs/Models/GetOrderRegulatedInfoResponse.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[GetOrderRegulatedInfoError](src/WalmartApIs/Errors/GetOrderRegulatedInfoError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;GetFulfillmentOrderResponse&gt; GetOrders(GetOrdersRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

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
    var response = await client.Orders.GetOrders(new GetOrdersRequest());
    // TODO: Handle 'response' of type GetFulfillmentOrderResponse
}
catch (ApiException<GetOrdersError> ex)
{
    if (ex.Error.TryGetErrorList(out var error))
    {
        // TODO: Handle 'error' of type ErrorList
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[GetOrdersRequest](src/WalmartApIs/Requests/Orders/GetOrdersRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[GetFulfillmentOrderResponse](src/WalmartApIs/Models/GetFulfillmentOrderResponse.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[GetOrdersError](src/WalmartApIs/Errors/GetOrdersError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;RefundOrderLinesResponse&gt; RefundOrderLines(RefundOrderLinesOperationRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

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
    var response = await client.Orders.RefundOrderLines(new RefundOrderLinesOperationRequest
    {
        PurchaseOrderId = "some example string",
        Body = new RefundOrderLinesRequest
        {
            OrderLines = [
                new RefundOrderLine
                {
                    LineNumber = "some example string",
                    RefundAmount = new Money(),
                    RefundType = RefundType.Return,
                },
            ],
        },
    });
    // TODO: Handle 'response' of type RefundOrderLinesResponse
}
catch (ApiException<RefundOrderLinesError> ex)
{
    if (ex.Error.TryGetErrorList(out var error))
    {
        // TODO: Handle 'error' of type ErrorList
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[RefundOrderLinesOperationRequest](src/WalmartApIs/Requests/Orders/RefundOrderLinesOperationRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[RefundOrderLinesResponse](src/WalmartApIs/Models/RefundOrderLinesResponse.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[RefundOrderLinesError](src/WalmartApIs/Errors/RefundOrderLinesError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;ShipOrderLinesResponse&gt; ShipOrderLines(ShipOrderLinesOperationRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Orders.ShipOrderLines(new ShipOrderLinesOperationRequest
    {
        PurchaseOrderId = "some example string",
        Body = new ShipOrderLinesRequest
        {
            OrderLines = [
                new ShipOrderLine
                {
                    LineNumber = "some example string",
                    TrackingInfo = new TrackingInfo
                    {
                        Carrier = CarrierName.Ups,
                        TrackingNumber = "some example string",
                        ShippedDate = DateTimeOffset.Parse("2024-01-15T09:30:00Z"),
                    },
                },
            ],
        },
    });
    // TODO: Handle 'response' of type ShipOrderLinesResponse
}
catch (ApiException<ShipOrderLinesError> ex)
{
    if (ex.Error.TryGetErrorList(out var error))
    {
        // TODO: Handle 'error' of type ErrorList
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[ShipOrderLinesOperationRequest](src/WalmartApIs/Requests/Orders/ShipOrderLinesOperationRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[ShipOrderLinesResponse](src/WalmartApIs/Models/ShipOrderLinesResponse.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[ShipOrderLinesError](src/WalmartApIs/Errors/ShipOrderLinesError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;MultiPackageShipResponse&gt; ShipOrderMultiPackage(ShipOrderMultiPackageRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

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
    var response = await client.Orders.ShipOrderMultiPackage(new ShipOrderMultiPackageRequest
    {
        PurchaseOrderId = "some example string",
        Body = new MultiPackageShipRequest
        {
            Packages = [
                new ShipPackage
                {
                    TrackingInfo = new TrackingInfo
                    {
                        Carrier = CarrierName.Ups,
                        TrackingNumber = "some example string",
                        ShippedDate = DateTimeOffset.Parse("2024-01-15T09:30:00Z"),
                    },
                    Lines = [new ShipPackageLine { LineNumber = "some example string" }],
                },
            ],
        },
    });
    // TODO: Handle 'response' of type MultiPackageShipResponse
}
catch (ApiException<ShipOrderMultiPackageError> ex)
{
    if (ex.Error.TryGetErrorList(out var error))
    {
        // TODO: Handle 'error' of type ErrorList
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[ShipOrderMultiPackageRequest](src/WalmartApIs/Requests/Orders/ShipOrderMultiPackageRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[MultiPackageShipResponse](src/WalmartApIs/Models/MultiPackageShipResponse.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[ShipOrderMultiPackageError](src/WalmartApIs/Errors/ShipOrderMultiPackageError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;UpdateShipmentStatusResponse&gt; UpdateShipmentStatus(UpdateShipmentStatusOperationRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

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
    var response = await client.Orders.UpdateShipmentStatus(new UpdateShipmentStatusOperationRequest
    {
        PurchaseOrderId = "some example string",
        Body = new UpdateShipmentStatusRequest
        {
            ShipmentStatus = ShipmentStatus1.ReadyForPickup,
            OrderLines = [new UpdateShipmentStatusLine { LineNumber = "some example string" }],
        },
    });
    // TODO: Handle 'response' of type UpdateShipmentStatusResponse
}
catch (ApiException<UpdateShipmentStatusError> ex)
{
    if (ex.Error.TryGetErrorList(out var error))
    {
        // TODO: Handle 'error' of type ErrorList
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[UpdateShipmentStatusOperationRequest](src/WalmartApIs/Requests/Orders/UpdateShipmentStatusOperationRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[UpdateShipmentStatusResponse](src/WalmartApIs/Models/UpdateShipmentStatusResponse.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[UpdateShipmentStatusError](src/WalmartApIs/Errors/UpdateShipmentStatusError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;UpdateVerificationStatusResponse&gt; UpdateVerificationStatus(UpdateVerificationStatusOperationRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

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
    var response = await client.Orders.UpdateVerificationStatus(new UpdateVerificationStatusOperationRequest
    {
        PurchaseOrderId = "some example string",
        Body = new UpdateVerificationStatusRequest { VerificationStatus = VerificationStatus.Approved },
    });
    // TODO: Handle 'response' of type UpdateVerificationStatusResponse
}
catch (ApiException<UpdateVerificationStatusError> ex)
{
    if (ex.Error.TryGetErrorList(out var error))
    {
        // TODO: Handle 'error' of type ErrorList
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[UpdateVerificationStatusOperationRequest](src/WalmartApIs/Requests/Orders/UpdateVerificationStatusOperationRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[UpdateVerificationStatusResponse](src/WalmartApIs/Models/UpdateVerificationStatusResponse.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[UpdateVerificationStatusError](src/WalmartApIs/Errors/UpdateVerificationStatusError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

## Payouts

> Source: [Payouts](src/WalmartApIs/Api/Payouts.cs)

<details>
<summary><code>Task&lt;PayoutStatusResponse&gt; ConfigureAutoPayout(ConfigureAutoPayoutRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

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
    var response = await client.Payouts.ConfigureAutoPayout(new ConfigureAutoPayoutRequest
    {
        Body = new DisbursementsV4PaymentAutoPayoutRequest { Enabled = true },
    });
    // TODO: Handle 'response' of type PayoutStatusResponse
}
catch (ApiException<ConfigureAutoPayoutError> ex)
{
    if (ex.Error.TryGetErrorList(out var error))
    {
        // TODO: Handle 'error' of type ErrorList
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[ConfigureAutoPayoutRequest](src/WalmartApIs/Requests/Payouts/ConfigureAutoPayoutRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[PayoutStatusResponse](src/WalmartApIs/Models/PayoutStatusResponse.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[ConfigureAutoPayoutError](src/WalmartApIs/Errors/ConfigureAutoPayoutError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;AnnualStatementOptsResponse&gt; GetAnnualStatementOpts(RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

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
catch (ApiException<GetAnnualStatementOptsError> ex)
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

**OnSuccess**: <code>[AnnualStatementOptsResponse](src/WalmartApIs/Models/AnnualStatementOptsResponse.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[GetAnnualStatementOptsError](src/WalmartApIs/Errors/GetAnnualStatementOptsError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;FasterPayoutEligibilityResponse&gt; GetFasterPayoutEligibility(RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

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
catch (ApiException<GetFasterPayoutEligibilityError> ex)
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

**OnSuccess**: <code>[FasterPayoutEligibilityResponse](src/WalmartApIs/Models/FasterPayoutEligibilityResponse.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[GetFasterPayoutEligibilityError](src/WalmartApIs/Errors/GetFasterPayoutEligibilityError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;PayoutStatusResponse&gt; GetPaymentStatus(RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

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
catch (ApiException<GetPaymentStatusError> ex)
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

**OnSuccess**: <code>[PayoutStatusResponse](src/WalmartApIs/Models/PayoutStatusResponse.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[GetPaymentStatusError](src/WalmartApIs/Errors/GetPaymentStatusError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;InitiatePayoutResponse&gt; InitiateFasterPayout(RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

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
catch (ApiException<InitiateFasterPayoutError> ex)
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

**OnSuccess**: <code>[InitiatePayoutResponse](src/WalmartApIs/Models/InitiatePayoutResponse.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[InitiateFasterPayoutError](src/WalmartApIs/Errors/InitiateFasterPayoutError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

## ProductTypeDefinitions

> Source: [ProductTypeDefinitions](src/WalmartApIs/Api/ProductTypeDefinitions.cs)

<details>
<summary><code>Task&lt;ProductTypeDefinition&gt; GetDefinitionsProductType(GetDefinitionsProductTypeRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

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
    var response = await client.ProductTypeDefinitions.GetDefinitionsProductType(new GetDefinitionsProductTypeRequest
    {
        ProductType = "some example string",
    });
    // TODO: Handle 'response' of type ProductTypeDefinition
}
catch (ApiException<GetDefinitionsProductTypeError> ex)
{
    if (ex.Error.TryGetErrorList(out var error))
    {
        // TODO: Handle 'error' of type ErrorList
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[GetDefinitionsProductTypeRequest](src/WalmartApIs/Requests/ProductTypeDefinitions/GetDefinitionsProductTypeRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[ProductTypeDefinition](src/WalmartApIs/Models/ProductTypeDefinition.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[GetDefinitionsProductTypeError](src/WalmartApIs/Errors/GetDefinitionsProductTypeError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;ProductTypeList&gt; SearchDefinitionsProductTypes(SearchDefinitionsProductTypesRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

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
    var response = await client.ProductTypeDefinitions.SearchDefinitionsProductTypes(
        new SearchDefinitionsProductTypesRequest());
    // TODO: Handle 'response' of type ProductTypeList
}
catch (ApiException<SearchDefinitionsProductTypesError> ex)
{
    if (ex.Error.TryGetErrorList(out var error))
    {
        // TODO: Handle 'error' of type ErrorList
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[SearchDefinitionsProductTypesRequest](src/WalmartApIs/Requests/ProductTypeDefinitions/SearchDefinitionsProductTypesRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[ProductTypeList](src/WalmartApIs/Models/ProductTypeList.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[SearchDefinitionsProductTypesError](src/WalmartApIs/Errors/SearchDefinitionsProductTypesError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

## Reconciliation

> Source: [Reconciliation](src/WalmartApIs/Api/Reconciliation.cs)

<details>
<summary><code>Task&lt;ReportAvailabilityResponse&gt; CheckDownloadReportByPeriod(CheckDownloadReportByPeriodRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

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
    var response = await client.Reconciliation.CheckDownloadReportByPeriod(new CheckDownloadReportByPeriodRequest
    {
        PartnerId = "some example string",
        Date = DateTimeOffset.Parse("2024-01-15T00:00:00Z"),
    });
    // TODO: Handle 'response' of type ReportAvailabilityResponse
}
catch (ApiException<CheckDownloadReportByPeriodError> ex)
{
    if (ex.Error.TryGetErrorList(out var error))
    {
        // TODO: Handle 'error' of type ErrorList
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[CheckDownloadReportByPeriodRequest](src/WalmartApIs/Requests/Reconciliation/CheckDownloadReportByPeriodRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[ReportAvailabilityResponse](src/WalmartApIs/Models/ReportAvailabilityResponse.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[CheckDownloadReportByPeriodError](src/WalmartApIs/Errors/CheckDownloadReportByPeriodError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;BinaryContent&gt; DownloadReconciliationReport(DownloadReconciliationReportRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

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
    var response = await client.Reconciliation.DownloadReconciliationReport(new DownloadReconciliationReportRequest
    {
        PartnerId = "some example string",
        ReportDate = "some example string",
    });
    // TODO: Handle 'response' of type BinaryContent
}
catch (ApiException<DownloadReconciliationReportError> ex)
{
    if (ex.Error.TryGetErrorList(out var error))
    {
        // TODO: Handle 'error' of type ErrorList
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[DownloadReconciliationReportRequest](src/WalmartApIs/Requests/Reconciliation/DownloadReconciliationReportRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>BinaryContent</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[DownloadReconciliationReportError](src/WalmartApIs/Errors/DownloadReconciliationReportError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;ReportAvailabilityResponse&gt; ListReconciliationDates(ListReconciliationDatesRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

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
    var response = await client.Reconciliation.ListReconciliationDates(new ListReconciliationDatesRequest
    {
        PartnerId = "some example string",
    });
    // TODO: Handle 'response' of type ReportAvailabilityResponse
}
catch (ApiException<ListReconciliationDatesError> ex)
{
    if (ex.Error.TryGetErrorList(out var error))
    {
        // TODO: Handle 'error' of type ErrorList
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[ListReconciliationDatesRequest](src/WalmartApIs/Requests/Reconciliation/ListReconciliationDatesRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[ReportAvailabilityResponse](src/WalmartApIs/Models/ReportAvailabilityResponse.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[ListReconciliationDatesError](src/WalmartApIs/Errors/ListReconciliationDatesError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

## ReportSchedules

> Source: [ReportSchedules](src/WalmartApIs/Api/ReportSchedules.cs)

<details>
<summary><code>Task&lt;CancelReportScheduleResponse&gt; CancelReportSchedule(CancelReportScheduleRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.ReportSchedules.CancelReportSchedule(new CancelReportScheduleRequest
    {
        ReportScheduleId = "some example string",
    });
    // TODO: Handle 'response' of type CancelReportScheduleResponse
}
catch (ApiException<CancelReportScheduleError> ex)
{
    if (ex.Error.TryGetErrorList(out var error))
    {
        // TODO: Handle 'error' of type ErrorList
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[CancelReportScheduleRequest](src/WalmartApIs/Requests/ReportSchedules/CancelReportScheduleRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[CancelReportScheduleResponse](src/WalmartApIs/Models/CancelReportScheduleResponse.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[CancelReportScheduleError](src/WalmartApIs/Errors/CancelReportScheduleError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;CreateReportScheduleResponse&gt; CreateReportSchedule(CreateReportScheduleRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.ReportSchedules.CreateReportSchedule(new CreateReportScheduleRequest
    {
        Body = new CreateReportScheduleSpecification { ReportType = "some example string", Period = Period1.Pt5M },
    });
    // TODO: Handle 'response' of type CreateReportScheduleResponse
}
catch (ApiException<CreateReportScheduleError> ex)
{
    if (ex.Error.TryGetErrorList(out var error))
    {
        // TODO: Handle 'error' of type ErrorList
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[CreateReportScheduleRequest](src/WalmartApIs/Requests/ReportSchedules/CreateReportScheduleRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[CreateReportScheduleResponse](src/WalmartApIs/Models/CreateReportScheduleResponse.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[CreateReportScheduleError](src/WalmartApIs/Errors/CreateReportScheduleError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;ReportSchedule&gt; GetReportSchedule(GetReportScheduleRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.ReportSchedules.GetReportSchedule(new GetReportScheduleRequest
    {
        ReportScheduleId = "some example string",
    });
    // TODO: Handle 'response' of type ReportSchedule
}
catch (ApiException<GetReportScheduleError> ex)
{
    if (ex.Error.TryGetErrorList(out var error))
    {
        // TODO: Handle 'error' of type ErrorList
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[GetReportScheduleRequest](src/WalmartApIs/Requests/ReportSchedules/GetReportScheduleRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[ReportSchedule](src/WalmartApIs/Models/ReportSchedule.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[GetReportScheduleError](src/WalmartApIs/Errors/GetReportScheduleError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;GetReportSchedulesResponse&gt; GetReportSchedules(GetReportSchedulesRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.ReportSchedules.GetReportSchedules(new GetReportSchedulesRequest());
    // TODO: Handle 'response' of type GetReportSchedulesResponse
}
catch (ApiException<GetReportSchedulesError> ex)
{
    if (ex.Error.TryGetErrorList(out var error))
    {
        // TODO: Handle 'error' of type ErrorList
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[GetReportSchedulesRequest](src/WalmartApIs/Requests/ReportSchedules/GetReportSchedulesRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[GetReportSchedulesResponse](src/WalmartApIs/Models/GetReportSchedulesResponse.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[GetReportSchedulesError](src/WalmartApIs/Errors/GetReportSchedulesError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

## Reports

> Source: [Reports](src/WalmartApIs/Api/Reports.cs)

<details>
<summary><code>Task&lt;CancelReportResponse&gt; CancelReport(CancelReportRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Reports.CancelReport(new CancelReportRequest { ReportId = "some example string" });
    // TODO: Handle 'response' of type CancelReportResponse
}
catch (ApiException<CancelReportError> ex)
{
    if (ex.Error.TryGetErrorList(out var error))
    {
        // TODO: Handle 'error' of type ErrorList
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[CancelReportRequest](src/WalmartApIs/Requests/Reports/CancelReportRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[CancelReportResponse](src/WalmartApIs/Models/CancelReportResponse.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[CancelReportError](src/WalmartApIs/Errors/CancelReportError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;CreateReportResponse&gt; CreateReport(CreateReportRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

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
    var response = await client.Reports.CreateReport(new CreateReportRequest
    {
        Body = new CreateReportSpecification { ReportType = ReportType.Item },
    });
    // TODO: Handle 'response' of type CreateReportResponse
}
catch (ApiException<CreateReportError> ex)
{
    if (ex.Error.TryGetErrorList(out var error))
    {
        // TODO: Handle 'error' of type ErrorList
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[CreateReportRequest](src/WalmartApIs/Requests/Reports/CreateReportRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[CreateReportResponse](src/WalmartApIs/Models/CreateReportResponse.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[CreateReportError](src/WalmartApIs/Errors/CreateReportError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;BinaryContent&gt; DownloadNewReport(DownloadNewReportRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

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
    var response = await client.Reports.DownloadNewReport(new DownloadNewReportRequest
    {
        PartnerId = "some example string",
        ReportDate = "some example string",
    });
    // TODO: Handle 'response' of type BinaryContent
}
catch (ApiException<DownloadNewReportError> ex)
{
    if (ex.Error.TryGetErrorList(out var error))
    {
        // TODO: Handle 'error' of type ErrorList
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[DownloadNewReportRequest](src/WalmartApIs/Requests/Reports/DownloadNewReportRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>BinaryContent</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[DownloadNewReportError](src/WalmartApIs/Errors/DownloadNewReportError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;BinaryContent&gt; DownloadOldReport(DownloadOldReportRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

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
    var response = await client.Reports.DownloadOldReport(new DownloadOldReportRequest
    {
        PartnerId = "some example string",
        ReportDate = "some example string",
    });
    // TODO: Handle 'response' of type BinaryContent
}
catch (ApiException<DownloadOldReportError> ex)
{
    if (ex.Error.TryGetErrorList(out var error))
    {
        // TODO: Handle 'error' of type ErrorList
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[DownloadOldReportRequest](src/WalmartApIs/Requests/Reports/DownloadOldReportRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>BinaryContent</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[DownloadOldReportError](src/WalmartApIs/Errors/DownloadOldReportError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;Report&gt; GetReport(GetReportRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Reports.GetReport(new GetReportRequest { ReportId = "some example string" });
    // TODO: Handle 'response' of type Report
}
catch (ApiException<GetReportError> ex)
{
    if (ex.Error.TryGetErrorList(out var error))
    {
        // TODO: Handle 'error' of type ErrorList
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[GetReportRequest](src/WalmartApIs/Requests/Reports/GetReportRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[Report](src/WalmartApIs/Models/Report.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[GetReportError](src/WalmartApIs/Errors/GetReportError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;ReportDocument&gt; GetReportDocument(GetReportDocumentRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

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
    var response = await client.Reports.GetReportDocument(new GetReportDocumentRequest
    {
        ReportDocumentId = "some example string",
    });
    // TODO: Handle 'response' of type ReportDocument
}
catch (ApiException<GetReportDocumentError> ex)
{
    if (ex.Error.TryGetErrorList(out var error))
    {
        // TODO: Handle 'error' of type ErrorList
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[GetReportDocumentRequest](src/WalmartApIs/Requests/Reports/GetReportDocumentRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[ReportDocument](src/WalmartApIs/Models/ReportDocument.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[GetReportDocumentError](src/WalmartApIs/Errors/GetReportDocumentError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;GetReportsResponse&gt; GetReports(GetReportsRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Reports.GetReports(new GetReportsRequest());
    // TODO: Handle 'response' of type GetReportsResponse
}
catch (ApiException<GetReportsError> ex)
{
    if (ex.Error.TryGetErrorList(out var error))
    {
        // TODO: Handle 'error' of type ErrorList
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[GetReportsRequest](src/WalmartApIs/Requests/Reports/GetReportsRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[GetReportsResponse](src/WalmartApIs/Models/GetReportsResponse.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[GetReportsError](src/WalmartApIs/Errors/GetReportsError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

## Sellers

> Source: [Sellers](src/WalmartApIs/Api/Sellers.cs)

<details>
<summary><code>Task&lt;SellerAccount&gt; GetAccount(RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

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
catch (ApiException<GetAccountError> ex)
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

**OnSuccess**: <code>[SellerAccount](src/WalmartApIs/Models/SellerAccount.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[GetAccountError](src/WalmartApIs/Errors/GetAccountError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;GetMarketplaceParticipationsResponse&gt; GetMarketplaceParticipations(RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

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
catch (ApiException<GetMarketplaceParticipationsError> ex)
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

**OnSuccess**: <code>[GetMarketplaceParticipationsResponse](src/WalmartApIs/Models/GetMarketplaceParticipationsResponse.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[GetMarketplaceParticipationsError](src/WalmartApIs/Errors/GetMarketplaceParticipationsError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

## Settlement

> Source: [Settlement](src/WalmartApIs/Api/Settlement.cs)

<details>
<summary><code>Task&lt;SettlementDetailsResponse&gt; ListSettlementDetails(ListSettlementDetailsRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

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
    var response = await client.Settlement.ListSettlementDetails(new ListSettlementDetailsRequest
    {
        PartnerId = "some example string",
        ReportDate = "some example string",
    });
    // TODO: Handle 'response' of type SettlementDetailsResponse
}
catch (ApiException<ListSettlementDetailsError> ex)
{
    if (ex.Error.TryGetErrorList(out var error))
    {
        // TODO: Handle 'error' of type ErrorList
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[ListSettlementDetailsRequest](src/WalmartApIs/Requests/Settlement/ListSettlementDetailsRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[SettlementDetailsResponse](src/WalmartApIs/Models/SettlementDetailsResponse.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[ListSettlementDetailsError](src/WalmartApIs/Errors/ListSettlementDetailsError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;SettlementPeriodsResponse&gt; ListSettlementPeriods(ListSettlementPeriodsRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

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
    var response = await client.Settlement.ListSettlementPeriods(new ListSettlementPeriodsRequest());
    // TODO: Handle 'response' of type SettlementPeriodsResponse
}
catch (ApiException<ListSettlementPeriodsError> ex)
{
    if (ex.Error.TryGetErrorList(out var error))
    {
        // TODO: Handle 'error' of type ErrorList
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[ListSettlementPeriodsRequest](src/WalmartApIs/Requests/Settlement/ListSettlementPeriodsRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[SettlementPeriodsResponse](src/WalmartApIs/Models/SettlementPeriodsResponse.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[ListSettlementPeriodsError](src/WalmartApIs/Errors/ListSettlementPeriodsError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;TransactionSearchResponse&gt; SearchTransactions(SearchTransactionsRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

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
    var response = await client.Settlement.SearchTransactions(new SearchTransactionsRequest());
    // TODO: Handle 'response' of type TransactionSearchResponse
}
catch (ApiException<SearchTransactionsError> ex)
{
    if (ex.Error.TryGetErrorList(out var error))
    {
        // TODO: Handle 'error' of type ErrorList
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[SearchTransactionsRequest](src/WalmartApIs/Requests/Settlement/SearchTransactionsRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[TransactionSearchResponse](src/WalmartApIs/Models/TransactionSearchResponse.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[SearchTransactionsError](src/WalmartApIs/Errors/SearchTransactionsError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

## Uploads

> Source: [Uploads](src/WalmartApIs/Api/Uploads.cs)

<details>
<summary><code>Task&lt;CreateUploadDestinationResponse&gt; CreateUploadDestinationForResource(CreateUploadDestinationForResourceRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

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
    var response = await client.Uploads.CreateUploadDestinationForResource(new CreateUploadDestinationForResourceRequest
    {
        Resource = Resource.Feeds,
        ContentType = ContentType1.TextXmlCharsetUtf8,
        MarketplaceIds = ["some example string"],
        ContentMd5 = "some example string",
    });
    // TODO: Handle 'response' of type CreateUploadDestinationResponse
}
catch (ApiException<CreateUploadDestinationForResourceError> ex)
{
    if (ex.Error.TryGetErrorList(out var error))
    {
        // TODO: Handle 'error' of type ErrorList
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[CreateUploadDestinationForResourceRequest](src/WalmartApIs/Requests/Uploads/CreateUploadDestinationForResourceRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[CreateUploadDestinationResponse](src/WalmartApIs/Models/CreateUploadDestinationResponse.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[CreateUploadDestinationForResourceError](src/WalmartApIs/Errors/CreateUploadDestinationForResourceError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

## WfsInventory

> Source: [WfsInventory](src/WalmartApIs/Api/WfsInventory.cs)

<details>
<summary><code>Task&lt;GetWfsInventoryResponse&gt; GetWfsInventoryItems(GetWfsInventoryItemsRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

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
    var response = await client.WfsInventory.GetWfsInventoryItems(new GetWfsInventoryItemsRequest());
    // TODO: Handle 'response' of type GetWfsInventoryResponse
}
catch (ApiException<GetWfsInventoryItemsError> ex)
{
    if (ex.Error.TryGetErrorList(out var error))
    {
        // TODO: Handle 'error' of type ErrorList
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[GetWfsInventoryItemsRequest](src/WalmartApIs/Requests/WfsInventory/GetWfsInventoryItemsRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[GetWfsInventoryResponse](src/WalmartApIs/Models/GetWfsInventoryResponse.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[GetWfsInventoryItemsError](src/WalmartApIs/Errors/GetWfsInventoryItemsError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

## Messaging

> Source: [Messaging](src/WalmartApIs/Api/Messaging.cs)

<details>
<summary><code>Task&lt;object&gt; CreateWarranty(CreateWarrantyRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Messaging.CreateWarranty(new CreateWarrantyRequest
    {
        SpApiOrderId = "some example string",
        MarketplaceIds = ["some example string"],
        Body = body,
    });
    // TODO: Handle 'response' of type object
}
catch (ApiException<CreateWarrantyError> ex)
{
    if (ex.Error.TryGetErrorList(out var error))
    {
        // TODO: Handle 'error' of type ErrorList
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[CreateWarrantyRequest](src/WalmartApIs/Requests/Messaging/CreateWarrantyRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>object</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[CreateWarrantyError](src/WalmartApIs/Errors/CreateWarrantyError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;object&gt; GetAttributes(GetAttributesRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Messaging.GetAttributes(new GetAttributesRequest
    {
        SpApiOrderId = "some example string",
        MarketplaceIds = ["some example string"],
    });
    // TODO: Handle 'response' of type object
}
catch (ApiException<GetAttributesError> ex)
{
    if (ex.Error.TryGetErrorList(out var error))
    {
        // TODO: Handle 'error' of type ErrorList
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[GetAttributesRequest](src/WalmartApIs/Requests/Messaging/GetAttributesRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>object</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[GetAttributesError](src/WalmartApIs/Errors/GetAttributesError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;object&gt; ConfirmCustomizationDetails(ConfirmCustomizationDetailsRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Messaging.ConfirmCustomizationDetails(new ConfirmCustomizationDetailsRequest
    {
        SpApiOrderId = "some example string",
        MarketplaceIds = ["some example string"],
        Body = body,
    });
    // TODO: Handle 'response' of type object
}
catch (ApiException<ConfirmCustomizationDetailsError> ex)
{
    if (ex.Error.TryGetErrorList(out var error))
    {
        // TODO: Handle 'error' of type ErrorList
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[ConfirmCustomizationDetailsRequest](src/WalmartApIs/Requests/Messaging/ConfirmCustomizationDetailsRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>object</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[ConfirmCustomizationDetailsError](src/WalmartApIs/Errors/ConfirmCustomizationDetailsError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;object&gt; CreateConfirmDeliveryDetails(CreateConfirmDeliveryDetailsRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Messaging.CreateConfirmDeliveryDetails(new CreateConfirmDeliveryDetailsRequest
    {
        SpApiOrderId = "some example string",
        MarketplaceIds = ["some example string"],
        Body = body,
    });
    // TODO: Handle 'response' of type object
}
catch (ApiException<CreateConfirmDeliveryDetailsError> ex)
{
    if (ex.Error.TryGetErrorList(out var error))
    {
        // TODO: Handle 'error' of type ErrorList
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[CreateConfirmDeliveryDetailsRequest](src/WalmartApIs/Requests/Messaging/CreateConfirmDeliveryDetailsRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>object</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[CreateConfirmDeliveryDetailsError](src/WalmartApIs/Errors/CreateConfirmDeliveryDetailsError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;object&gt; CreateConfirmOrderDetails(CreateConfirmOrderDetailsRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Messaging.CreateConfirmOrderDetails(new CreateConfirmOrderDetailsRequest
    {
        SpApiOrderId = "some example string",
        MarketplaceIds = ["some example string"],
        Body = body,
    });
    // TODO: Handle 'response' of type object
}
catch (ApiException<CreateConfirmOrderDetailsError> ex)
{
    if (ex.Error.TryGetErrorList(out var error))
    {
        // TODO: Handle 'error' of type ErrorList
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[CreateConfirmOrderDetailsRequest](src/WalmartApIs/Requests/Messaging/CreateConfirmOrderDetailsRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>object</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[CreateConfirmOrderDetailsError](src/WalmartApIs/Errors/CreateConfirmOrderDetailsError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;object&gt; CreateConfirmServiceDetails(CreateConfirmServiceDetailsRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Messaging.CreateConfirmServiceDetails(new CreateConfirmServiceDetailsRequest
    {
        SpApiOrderId = "some example string",
        MarketplaceIds = ["some example string"],
        Body = body,
    });
    // TODO: Handle 'response' of type object
}
catch (ApiException<CreateConfirmServiceDetailsError> ex)
{
    if (ex.Error.TryGetErrorList(out var error))
    {
        // TODO: Handle 'error' of type ErrorList
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[CreateConfirmServiceDetailsRequest](src/WalmartApIs/Requests/Messaging/CreateConfirmServiceDetailsRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>object</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[CreateConfirmServiceDetailsError](src/WalmartApIs/Errors/CreateConfirmServiceDetailsError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;object&gt; CreateDigitalAccessKey(CreateDigitalAccessKeyRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Messaging.CreateDigitalAccessKey(new CreateDigitalAccessKeyRequest
    {
        SpApiOrderId = "some example string",
        MarketplaceIds = ["some example string"],
        Body = body,
    });
    // TODO: Handle 'response' of type object
}
catch (ApiException<CreateDigitalAccessKeyError> ex)
{
    if (ex.Error.TryGetErrorList(out var error))
    {
        // TODO: Handle 'error' of type ErrorList
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[CreateDigitalAccessKeyRequest](src/WalmartApIs/Requests/Messaging/CreateDigitalAccessKeyRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>object</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[CreateDigitalAccessKeyError](src/WalmartApIs/Errors/CreateDigitalAccessKeyError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;object&gt; CreateLegalDisclosure(CreateLegalDisclosureRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Messaging.CreateLegalDisclosure(new CreateLegalDisclosureRequest
    {
        SpApiOrderId = "some example string",
        MarketplaceIds = ["some example string"],
        Body = body,
    });
    // TODO: Handle 'response' of type object
}
catch (ApiException<CreateLegalDisclosureError> ex)
{
    if (ex.Error.TryGetErrorList(out var error))
    {
        // TODO: Handle 'error' of type ErrorList
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[CreateLegalDisclosureRequest](src/WalmartApIs/Requests/Messaging/CreateLegalDisclosureRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>object</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[CreateLegalDisclosureError](src/WalmartApIs/Errors/CreateLegalDisclosureError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;object&gt; CreateUnexpectedProblem(CreateUnexpectedProblemRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Messaging.CreateUnexpectedProblem(new CreateUnexpectedProblemRequest
    {
        SpApiOrderId = "some example string",
        MarketplaceIds = ["some example string"],
        Body = body,
    });
    // TODO: Handle 'response' of type object
}
catch (ApiException<CreateUnexpectedProblemError> ex)
{
    if (ex.Error.TryGetErrorList(out var error))
    {
        // TODO: Handle 'error' of type ErrorList
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[CreateUnexpectedProblemRequest](src/WalmartApIs/Requests/Messaging/CreateUnexpectedProblemRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>object</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[CreateUnexpectedProblemError](src/WalmartApIs/Errors/CreateUnexpectedProblemError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;object&gt; GetMessagingActionsForOrder(GetMessagingActionsForOrderRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Messaging.GetMessagingActionsForOrder(new GetMessagingActionsForOrderRequest
    {
        SpApiOrderId = "some example string",
        MarketplaceIds = ["some example string"],
    });
    // TODO: Handle 'response' of type object
}
catch (ApiException<GetMessagingActionsForOrderError> ex)
{
    if (ex.Error.TryGetErrorList(out var error))
    {
        // TODO: Handle 'error' of type ErrorList
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[GetMessagingActionsForOrderRequest](src/WalmartApIs/Requests/Messaging/GetMessagingActionsForOrderRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>object</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[GetMessagingActionsForOrderError](src/WalmartApIs/Errors/GetMessagingActionsForOrderError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;object&gt; SendInvoice(SendInvoiceRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Messaging.SendInvoice(new SendInvoiceRequest
    {
        SpApiOrderId = "some example string",
        MarketplaceIds = ["some example string"],
        Body = body,
    });
    // TODO: Handle 'response' of type object
}
catch (ApiException<SendInvoiceError> ex)
{
    if (ex.Error.TryGetErrorList(out var error))
    {
        // TODO: Handle 'error' of type ErrorList
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[SendInvoiceRequest](src/WalmartApIs/Requests/Messaging/SendInvoiceRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>object</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[SendInvoiceError](src/WalmartApIs/Errors/SendInvoiceError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

## Notifications

> Source: [Notifications](src/WalmartApIs/Api/Notifications.cs)

<details>
<summary><code>Task&lt;Channel&gt; CreateDestination(CreateDestinationRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Notifications.CreateDestination(new CreateDestinationRequest { Body = body });
    // TODO: Handle 'response' of type Channel
}
catch (ApiException<CreateDestinationError> ex)
{
    if (ex.Error.TryGetNoContent(out var error))
    {
        // TODO: Handle 'error' of type RawError
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[CreateDestinationRequest](src/WalmartApIs/Requests/Notifications/CreateDestinationRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[Channel](src/WalmartApIs/Models/Channel.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[CreateDestinationError](src/WalmartApIs/Errors/CreateDestinationError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;object&gt; CreateSubscription(CreateSubscriptionRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Notifications.CreateSubscription(new CreateSubscriptionRequest
    {
        NotificationType = "some example string",
        Body = body,
    });
    // TODO: Handle 'response' of type object
}
catch (ApiException<CreateSubscriptionError> ex)
{
    if (ex.Error.TryGetNoContent(out var error))
    {
        // TODO: Handle 'error' of type RawError
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[CreateSubscriptionRequest](src/WalmartApIs/Requests/Notifications/CreateSubscriptionRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>object</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[CreateSubscriptionError](src/WalmartApIs/Errors/CreateSubscriptionError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;Channel&gt; DeleteDestination(DeleteDestinationRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Notifications.DeleteDestination(new DeleteDestinationRequest
    {
        DestinationId = "some example string",
    });
    // TODO: Handle 'response' of type Channel
}
catch (ApiException<DeleteDestinationError> ex)
{
    if (ex.Error.TryGetNoContent(out var error))
    {
        // TODO: Handle 'error' of type RawError
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[DeleteDestinationRequest](src/WalmartApIs/Requests/Notifications/DeleteDestinationRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[Channel](src/WalmartApIs/Models/Channel.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[DeleteDestinationError](src/WalmartApIs/Errors/DeleteDestinationError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;object&gt; DeleteSubscriptionById(DeleteSubscriptionByIdRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Notifications.DeleteSubscriptionById(new DeleteSubscriptionByIdRequest
    {
        SubscriptionId = "some example string",
        NotificationType = "some example string",
    });
    // TODO: Handle 'response' of type object
}
catch (ApiException<DeleteSubscriptionByIdError> ex)
{
    if (ex.Error.TryGetNoContent(out var error))
    {
        // TODO: Handle 'error' of type RawError
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[DeleteSubscriptionByIdRequest](src/WalmartApIs/Requests/Notifications/DeleteSubscriptionByIdRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>object</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[DeleteSubscriptionByIdError](src/WalmartApIs/Errors/DeleteSubscriptionByIdError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;Channel&gt; GetDestination(GetDestinationRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Notifications.GetDestination(new GetDestinationRequest
    {
        DestinationId = "some example string",
    });
    // TODO: Handle 'response' of type Channel
}
catch (ApiException<GetDestinationError> ex)
{
    if (ex.Error.TryGetNoContent(out var error))
    {
        // TODO: Handle 'error' of type RawError
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[GetDestinationRequest](src/WalmartApIs/Requests/Notifications/GetDestinationRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[Channel](src/WalmartApIs/Models/Channel.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[GetDestinationError](src/WalmartApIs/Errors/GetDestinationError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;ChannelList&gt; GetDestinations(RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

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
catch (ApiException<GetDestinationsError> ex)
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

**OnSuccess**: <code>[ChannelList](src/WalmartApIs/Models/ChannelList.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[GetDestinationsError](src/WalmartApIs/Errors/GetDestinationsError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;object&gt; GetSubscription(GetSubscriptionRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Notifications.GetSubscription(new GetSubscriptionRequest
    {
        NotificationType = "some example string",
    });
    // TODO: Handle 'response' of type object
}
catch (ApiException<GetSubscriptionError> ex)
{
    if (ex.Error.TryGetNoContent(out var error))
    {
        // TODO: Handle 'error' of type RawError
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[GetSubscriptionRequest](src/WalmartApIs/Requests/Notifications/GetSubscriptionRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>object</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[GetSubscriptionError](src/WalmartApIs/Errors/GetSubscriptionError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;object&gt; GetSubscriptionById(GetSubscriptionByIdRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Notifications.GetSubscriptionById(new GetSubscriptionByIdRequest
    {
        SubscriptionId = "some example string",
        NotificationType = "some example string",
    });
    // TODO: Handle 'response' of type object
}
catch (ApiException<GetSubscriptionByIdError> ex)
{
    if (ex.Error.TryGetNoContent(out var error))
    {
        // TODO: Handle 'error' of type RawError
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[GetSubscriptionByIdRequest](src/WalmartApIs/Requests/Notifications/GetSubscriptionByIdRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>object</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[GetSubscriptionByIdError](src/WalmartApIs/Errors/GetSubscriptionByIdError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;object&gt; SendTestNotification(SendTestNotificationRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Notifications.SendTestNotification(new SendTestNotificationRequest
    {
        NotificationType = "some example string",
        Body = body,
    });
    // TODO: Handle 'response' of type object
}
catch (ApiException<SendTestNotificationError> ex)
{
    if (ex.Error.TryGetNoContent(out var error))
    {
        // TODO: Handle 'error' of type RawError
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[SendTestNotificationRequest](src/WalmartApIs/Requests/Notifications/SendTestNotificationRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>object</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[SendTestNotificationError](src/WalmartApIs/Errors/SendTestNotificationError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

## ProductFees

> Source: [ProductFees](src/WalmartApIs/Api/ProductFees.cs)

<details>
<summary><code>Task&lt;GetMyFeesEstimateResponse&gt; GetMyFeesEstimateForItem(GetMyFeesEstimateForItemRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

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
    var response = await client.ProductFees.GetMyFeesEstimateForItem(new GetMyFeesEstimateForItemRequest
    {
        WalmartItemId = "some example string",
        Body = new GetMyFeesEstimateRequest(),
    });
    // TODO: Handle 'response' of type GetMyFeesEstimateResponse
}
catch (ApiException<GetMyFeesEstimateForItemError> ex)
{
    if (ex.Error.TryGetErrorList(out var error))
    {
        // TODO: Handle 'error' of type ErrorList
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[GetMyFeesEstimateForItemRequest](src/WalmartApIs/Requests/ProductFees/GetMyFeesEstimateForItemRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[GetMyFeesEstimateResponse](src/WalmartApIs/Models/GetMyFeesEstimateResponse.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[GetMyFeesEstimateForItemError](src/WalmartApIs/Errors/GetMyFeesEstimateForItemError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;GetMyFeesEstimateResponse&gt; GetMyFeesEstimateForSku(GetMyFeesEstimateForSkuRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

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
    var response = await client.ProductFees.GetMyFeesEstimateForSku(new GetMyFeesEstimateForSkuRequest
    {
        SellerSku = "some example string",
        MarketplaceId = "some example string",
        Body = new GetMyFeesEstimateRequest(),
    });
    // TODO: Handle 'response' of type GetMyFeesEstimateResponse
}
catch (ApiException<GetMyFeesEstimateForSkuError> ex)
{
    if (ex.Error.TryGetErrorList(out var error))
    {
        // TODO: Handle 'error' of type ErrorList
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[GetMyFeesEstimateForSkuRequest](src/WalmartApIs/Requests/ProductFees/GetMyFeesEstimateForSkuRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[GetMyFeesEstimateResponse](src/WalmartApIs/Models/GetMyFeesEstimateResponse.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[GetMyFeesEstimateForSkuError](src/WalmartApIs/Errors/GetMyFeesEstimateForSkuError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;IReadOnlyList&lt;FeesEstimateResult&gt;&gt; GetMyFeesEstimates(GetMyFeesEstimatesRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

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
    var response = await client.ProductFees.GetMyFeesEstimates(new GetMyFeesEstimatesRequest
    {
        Body = [
            new FeesEstimateByIdRequest
            {
                IdType = IdType.WalmartItemId,
                IdValue = "some example string",
                FeesEstimateRequest = new FeesEstimateRequest
                {
                    MarketplaceId = "some example string",
                    IsWalmartFulfilled = true,
                    PriceToEstimateFees = new PriceToEstimateFees
                    {
                        ListingPrice = new MoneyType1 { CurrencyCode = currencyCode, Amount = amount },
                    },
                },
            },
        ],
    });
    // TODO: Handle 'response' of type IReadOnlyList<FeesEstimateResult>
}
catch (ApiException<GetMyFeesEstimatesError> ex)
{
    if (ex.Error.TryGetErrorList(out var error))
    {
        // TODO: Handle 'error' of type ErrorList
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[GetMyFeesEstimatesRequest](src/WalmartApIs/Requests/ProductFees/GetMyFeesEstimatesRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>IReadOnlyList&lt;[FeesEstimateResult](src/WalmartApIs/Models/FeesEstimateResult.cs)&gt;</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[GetMyFeesEstimatesError](src/WalmartApIs/Errors/GetMyFeesEstimatesError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

## ProductPricing

> Source: [ProductPricing](src/WalmartApIs/Api/ProductPricing.cs)

<details>
<summary><code>Task&lt;GetPricingResponse&gt; GetCompetitivePricing(GetCompetitivePricingRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

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
    var response = await client.ProductPricing.GetCompetitivePricing(new GetCompetitivePricingRequest
    {
        MarketplaceId = "some example string",
        ItemType = ItemType.WalmartItemId,
    });
    // TODO: Handle 'response' of type GetPricingResponse
}
catch (ApiException<GetCompetitivePricingError> ex)
{
    if (ex.Error.TryGetListOfError3(out var error))
    {
        // TODO: Handle 'error' of type IReadOnlyList<Error3>
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[GetCompetitivePricingRequest](src/WalmartApIs/Requests/ProductPricing/GetCompetitivePricingRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[GetPricingResponse](src/WalmartApIs/Models/GetPricingResponse.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[GetCompetitivePricingError](src/WalmartApIs/Errors/GetCompetitivePricingError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;CompetitiveSummaryBatchResponse&gt; GetCompetitiveSummary(GetCompetitiveSummaryRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

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
    var response = await client.ProductPricing.GetCompetitiveSummary(new GetCompetitiveSummaryRequest
    {
        Body = new CompetitiveSummaryBatchRequest(),
    });
    // TODO: Handle 'response' of type CompetitiveSummaryBatchResponse
}
catch (ApiException<GetCompetitiveSummaryError> ex)
{
    if (ex.Error.TryGetListOfError3(out var error))
    {
        // TODO: Handle 'error' of type IReadOnlyList<Error3>
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[GetCompetitiveSummaryRequest](src/WalmartApIs/Requests/ProductPricing/GetCompetitiveSummaryRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[CompetitiveSummaryBatchResponse](src/WalmartApIs/Models/CompetitiveSummaryBatchResponse.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[GetCompetitiveSummaryError](src/WalmartApIs/Errors/GetCompetitiveSummaryError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;GetFeaturedOfferExpectedPriceBatchResponse&gt; GetFeaturedOfferExpectedPriceBatch(GetFeaturedOfferExpectedPriceBatchOperationRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

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
    var response = await client.ProductPricing.GetFeaturedOfferExpectedPriceBatch(
        new GetFeaturedOfferExpectedPriceBatchOperationRequest
        {
            Body = new GetFeaturedOfferExpectedPriceBatchRequest(),
        });
    // TODO: Handle 'response' of type GetFeaturedOfferExpectedPriceBatchResponse
}
catch (ApiException<GetFeaturedOfferExpectedPriceBatchError> ex)
{
    if (ex.Error.TryGetListOfError3(out var error))
    {
        // TODO: Handle 'error' of type IReadOnlyList<Error3>
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[GetFeaturedOfferExpectedPriceBatchOperationRequest](src/WalmartApIs/Requests/ProductPricing/GetFeaturedOfferExpectedPriceBatchOperationRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[GetFeaturedOfferExpectedPriceBatchResponse](src/WalmartApIs/Models/GetFeaturedOfferExpectedPriceBatchResponse.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[GetFeaturedOfferExpectedPriceBatchError](src/WalmartApIs/Errors/GetFeaturedOfferExpectedPriceBatchError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;GetOffersResponse&gt; GetItemOffers(GetItemOffersRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

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
    var response = await client.ProductPricing.GetItemOffers(new GetItemOffersRequest
    {
        ItemId = "some example string",
        MarketplaceId = "some example string",
        ItemCondition = ConditionType2.New,
    });
    // TODO: Handle 'response' of type GetOffersResponse
}
catch (ApiException<GetItemOffersError> ex)
{
    if (ex.Error.TryGetListOfError3(out var error))
    {
        // TODO: Handle 'error' of type IReadOnlyList<Error3>
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[GetItemOffersRequest](src/WalmartApIs/Requests/ProductPricing/GetItemOffersRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[GetOffersResponse](src/WalmartApIs/Models/GetOffersResponse.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[GetItemOffersError](src/WalmartApIs/Errors/GetItemOffersError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;GetItemOffersBatchResponse&gt; GetItemOffersBatch(GetItemOffersBatchOperationRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

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
    var response = await client.ProductPricing.GetItemOffersBatch(new GetItemOffersBatchOperationRequest
    {
        Body = new GetItemOffersBatchRequest(),
    });
    // TODO: Handle 'response' of type GetItemOffersBatchResponse
}
catch (ApiException<GetItemOffersBatchError> ex)
{
    if (ex.Error.TryGetListOfError3(out var error))
    {
        // TODO: Handle 'error' of type IReadOnlyList<Error3>
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[GetItemOffersBatchOperationRequest](src/WalmartApIs/Requests/ProductPricing/GetItemOffersBatchOperationRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[GetItemOffersBatchResponse](src/WalmartApIs/Models/GetItemOffersBatchResponse.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[GetItemOffersBatchError](src/WalmartApIs/Errors/GetItemOffersBatchError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;GetOffersResponse&gt; GetListingOffers(GetListingOffersRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

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
    var response = await client.ProductPricing.GetListingOffers(new GetListingOffersRequest
    {
        SellerSku = "some example string",
        MarketplaceId = "some example string",
        ItemCondition = ConditionType2.New,
    });
    // TODO: Handle 'response' of type GetOffersResponse
}
catch (ApiException<GetListingOffersError> ex)
{
    if (ex.Error.TryGetListOfError3(out var error))
    {
        // TODO: Handle 'error' of type IReadOnlyList<Error3>
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[GetListingOffersRequest](src/WalmartApIs/Requests/ProductPricing/GetListingOffersRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[GetOffersResponse](src/WalmartApIs/Models/GetOffersResponse.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[GetListingOffersError](src/WalmartApIs/Errors/GetListingOffersError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;GetListingOffersBatchResponse&gt; GetListingOffersBatch(GetListingOffersBatchOperationRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

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
    var response = await client.ProductPricing.GetListingOffersBatch(new GetListingOffersBatchOperationRequest
    {
        Body = new GetListingOffersBatchRequest(),
    });
    // TODO: Handle 'response' of type GetListingOffersBatchResponse
}
catch (ApiException<GetListingOffersBatchError> ex)
{
    if (ex.Error.TryGetListOfError3(out var error))
    {
        // TODO: Handle 'error' of type IReadOnlyList<Error3>
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[GetListingOffersBatchOperationRequest](src/WalmartApIs/Requests/ProductPricing/GetListingOffersBatchOperationRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[GetListingOffersBatchResponse](src/WalmartApIs/Models/GetListingOffersBatchResponse.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[GetListingOffersBatchError](src/WalmartApIs/Errors/GetListingOffersBatchError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;GetPricingResponse&gt; GetPricing(GetPricingRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

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
    var response = await client.ProductPricing.GetPricing(new GetPricingRequest
    {
        MarketplaceId = "some example string",
        ItemType = ItemType.WalmartItemId,
    });
    // TODO: Handle 'response' of type GetPricingResponse
}
catch (ApiException<GetPricingError> ex)
{
    if (ex.Error.TryGetListOfError3(out var error))
    {
        // TODO: Handle 'error' of type IReadOnlyList<Error3>
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[GetPricingRequest](src/WalmartApIs/Requests/ProductPricing/GetPricingRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[GetPricingResponse](src/WalmartApIs/Models/GetPricingResponse.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[GetPricingError](src/WalmartApIs/Errors/GetPricingError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

## Sales

> Source: [Sales](src/WalmartApIs/Api/Sales.cs)

<details>
<summary><code>Task&lt;object&gt; GetOrderMetrics(GetOrderMetricsRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Sales.GetOrderMetrics(new GetOrderMetricsRequest
    {
        MarketplaceIds = ["some example string"],
        Interval = "some example string",
        Granularity = Granularity.Hour,
    });
    // TODO: Handle 'response' of type object
}
catch (ApiException<GetOrderMetricsError> ex)
{
    if (ex.Error.TryGetErrorList(out var error))
    {
        // TODO: Handle 'error' of type ErrorList
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[GetOrderMetricsRequest](src/WalmartApIs/Requests/Sales/GetOrderMetricsRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>object</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[GetOrderMetricsError](src/WalmartApIs/Errors/GetOrderMetricsError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

## Shipping

> Source: [Shipping](src/WalmartApIs/Api/Shipping.cs)

<details>
<summary><code>Task&lt;CancelShipmentResponse1&gt; CancelShipment2(CancelShipment2Request request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

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
    var response = await client.Shipping.CancelShipment2(new CancelShipment2Request
    {
        ShipmentId = "some example string",
    });
    // TODO: Handle 'response' of type CancelShipmentResponse1
}
catch (ApiException<CancelShipment2Error> ex)
{
    if (ex.Error.TryGetErrorList(out var error))
    {
        // TODO: Handle 'error' of type ErrorList
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[CancelShipment2Request](src/WalmartApIs/Requests/Shipping/CancelShipment2Request.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[CancelShipmentResponse1](src/WalmartApIs/Models/CancelShipmentResponse1.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[CancelShipment2Error](src/WalmartApIs/Errors/CancelShipment2Error.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;GetAccessPointsResponse&gt; GetAccessPoints(GetAccessPointsRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

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
    var response = await client.Shipping.GetAccessPoints(new GetAccessPointsRequest
    {
        AccessPointTypes = "some example string",
        CountryCode = "some example string",
        PostalCode = "some example string",
    });
    // TODO: Handle 'response' of type GetAccessPointsResponse
}
catch (ApiException<GetAccessPointsError> ex)
{
    if (ex.Error.TryGetErrorList(out var error))
    {
        // TODO: Handle 'error' of type ErrorList
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[GetAccessPointsRequest](src/WalmartApIs/Requests/Shipping/GetAccessPointsRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[GetAccessPointsResponse](src/WalmartApIs/Models/GetAccessPointsResponse.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[GetAccessPointsError](src/WalmartApIs/Errors/GetAccessPointsError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;GetAdditionalInputsResponse&gt; GetAdditionalInputs(GetAdditionalInputsRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

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
    var response = await client.Shipping.GetAdditionalInputs(new GetAdditionalInputsRequest
    {
        RateId = "some example string",
        RequestToken = "some example string",
    });
    // TODO: Handle 'response' of type GetAdditionalInputsResponse
}
catch (ApiException<GetAdditionalInputsError> ex)
{
    if (ex.Error.TryGetErrorList(out var error))
    {
        // TODO: Handle 'error' of type ErrorList
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[GetAdditionalInputsRequest](src/WalmartApIs/Requests/Shipping/GetAdditionalInputsRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[GetAdditionalInputsResponse](src/WalmartApIs/Models/GetAdditionalInputsResponse.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[GetAdditionalInputsError](src/WalmartApIs/Errors/GetAdditionalInputsError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;GetFulfillmentOrderResponse&gt; GetRates(GetRatesOperationRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

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
    var response = await client.Shipping.GetRates(new GetRatesOperationRequest
    {
        Body = new GetRatesRequest
        {
            ShipTo = new Address1
            {
                Name = "some example string",
                AddressLine1 = "some example string",
                City = "some example string",
                StateOrRegion = "some example string",
                PostalCode = "some example string",
                CountryCode = "some example string",
            },
            ShipFrom = new Address1
            {
                Name = "some example string",
                AddressLine1 = "some example string",
                City = "some example string",
                StateOrRegion = "some example string",
                PostalCode = "some example string",
                CountryCode = "some example string",
            },
            Packages = [
                new Package
                {
                    Dimensions = new PackageDimensions
                    {
                        Length = 1.5d,
                        Width = 1.5d,
                        Height = 1.5d,
                        Unit = Unit.Inches,
                    },
                    Weight = new Weight { Value = 1.5d, Unit = Unit1.Oz },
                    PackageClientReferenceId = "some example string",
                },
            ],
            ChannelDetails = new ChannelDetails { ChannelType = ChannelType.WalmartMarketplace },
        },
    });
    // TODO: Handle 'response' of type GetFulfillmentOrderResponse
}
catch (ApiException<GetRatesError> ex)
{
    if (ex.Error.TryGetErrorList(out var error))
    {
        // TODO: Handle 'error' of type ErrorList
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[GetRatesOperationRequest](src/WalmartApIs/Requests/Shipping/GetRatesOperationRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[GetFulfillmentOrderResponse](src/WalmartApIs/Models/GetFulfillmentOrderResponse.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[GetRatesError](src/WalmartApIs/Errors/GetRatesError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;GetShipmentDocumentsResponse&gt; GetShipmentDocuments(GetShipmentDocumentsRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

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
    var response = await client.Shipping.GetShipmentDocuments(new GetShipmentDocumentsRequest
    {
        ShipmentId = "some example string",
    });
    // TODO: Handle 'response' of type GetShipmentDocumentsResponse
}
catch (ApiException<GetShipmentDocumentsError> ex)
{
    if (ex.Error.TryGetErrorList(out var error))
    {
        // TODO: Handle 'error' of type ErrorList
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[GetShipmentDocumentsRequest](src/WalmartApIs/Requests/Shipping/GetShipmentDocumentsRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[GetShipmentDocumentsResponse](src/WalmartApIs/Models/GetShipmentDocumentsResponse.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[GetShipmentDocumentsError](src/WalmartApIs/Errors/GetShipmentDocumentsError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;GetTrackingResponse&gt; GetTracking(GetTrackingRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

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
    var response = await client.Shipping.GetTracking(new GetTrackingRequest { TrackingId = "some example string" });
    // TODO: Handle 'response' of type GetTrackingResponse
}
catch (ApiException<GetTrackingError> ex)
{
    if (ex.Error.TryGetErrorList(out var error))
    {
        // TODO: Handle 'error' of type ErrorList
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[GetTrackingRequest](src/WalmartApIs/Requests/Shipping/GetTrackingRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[GetTrackingResponse](src/WalmartApIs/Models/GetTrackingResponse.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[GetTrackingError](src/WalmartApIs/Errors/GetTrackingError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;GetFulfillmentOrderShipmentsResponse&gt; OneClickShipment(OneClickShipmentOperationRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

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
    var response = await client.Shipping.OneClickShipment(new OneClickShipmentOperationRequest
    {
        Body = new OneClickShipmentRequest
        {
            ShipTo = new Address1
            {
                Name = "some example string",
                AddressLine1 = "some example string",
                City = "some example string",
                StateOrRegion = "some example string",
                PostalCode = "some example string",
                CountryCode = "some example string",
            },
            ShipFrom = new Address1
            {
                Name = "some example string",
                AddressLine1 = "some example string",
                City = "some example string",
                StateOrRegion = "some example string",
                PostalCode = "some example string",
                CountryCode = "some example string",
            },
            Packages = [
                new Package
                {
                    Dimensions = new PackageDimensions
                    {
                        Length = 1.5d,
                        Width = 1.5d,
                        Height = 1.5d,
                        Unit = Unit.Inches,
                    },
                    Weight = new Weight { Value = 1.5d, Unit = Unit1.Oz },
                    PackageClientReferenceId = "some example string",
                },
            ],
            ServiceSelection = new ServiceSelection(),
            RequestedDocumentSpecification = new RequestedDocumentSpecification
            {
                Format = Format1.Pdf,
                Size = new LabelDimensions(),
                Dpi = Dpi.Value203,
            },
            ChannelDetails = new ChannelDetails { ChannelType = ChannelType.WalmartMarketplace },
        },
    });
    // TODO: Handle 'response' of type GetFulfillmentOrderShipmentsResponse
}
catch (ApiException<OneClickShipmentError> ex)
{
    if (ex.Error.TryGetErrorList(out var error))
    {
        // TODO: Handle 'error' of type ErrorList
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[OneClickShipmentOperationRequest](src/WalmartApIs/Requests/Shipping/OneClickShipmentOperationRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[GetFulfillmentOrderShipmentsResponse](src/WalmartApIs/Models/GetFulfillmentOrderShipmentsResponse.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[OneClickShipmentError](src/WalmartApIs/Errors/OneClickShipmentError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;GetFulfillmentOrderShipmentsResponse&gt; PurchaseShipment(PurchaseShipmentOperationRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

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
    var response = await client.Shipping.PurchaseShipment(new PurchaseShipmentOperationRequest
    {
        Body = new PurchaseShipmentRequest
        {
            RequestToken = "some example string",
            RateId = "some example string",
            RequestedDocumentSpecification = new RequestedDocumentSpecification
            {
                Format = Format1.Pdf,
                Size = new LabelDimensions(),
                Dpi = Dpi.Value203,
            },
        },
    });
    // TODO: Handle 'response' of type GetFulfillmentOrderShipmentsResponse
}
catch (ApiException<PurchaseShipmentError> ex)
{
    if (ex.Error.TryGetErrorList(out var error))
    {
        // TODO: Handle 'error' of type ErrorList
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[PurchaseShipmentOperationRequest](src/WalmartApIs/Requests/Shipping/PurchaseShipmentOperationRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[GetFulfillmentOrderShipmentsResponse](src/WalmartApIs/Models/GetFulfillmentOrderShipmentsResponse.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[PurchaseShipmentError](src/WalmartApIs/Errors/PurchaseShipmentError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task SubmitNdrFeedback(SubmitNdrFeedbackOperationRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

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
    await client.Shipping.SubmitNdrFeedback(new SubmitNdrFeedbackOperationRequest
    {
        Body = new SubmitNdrFeedbackRequest
        {
            SellerTrackingId = "some example string",
            NdrAction = NdrAction.ReturnToOrigin,
        },
    });
}
catch (ApiException<SubmitNdrFeedbackError> ex)
{
    if (ex.Error.TryGetErrorList(out var error))
    {
        // TODO: Handle 'error' of type ErrorList
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[SubmitNdrFeedbackOperationRequest](src/WalmartApIs/Requests/Shipping/SubmitNdrFeedbackOperationRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: No content

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[SubmitNdrFeedbackError](src/WalmartApIs/Errors/SubmitNdrFeedbackError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

## Solicitations

> Source: [Solicitations](src/WalmartApIs/Api/Solicitations.cs)

<details>
<summary><code>Task&lt;object&gt; CreateProductReviewAndSellerFeedbackSolicitation(CreateProductReviewAndSellerFeedbackSolicitationRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Solicitations.CreateProductReviewAndSellerFeedbackSolicitation(
        new CreateProductReviewAndSellerFeedbackSolicitationRequest
        {
            SpApiOrderId = "some example string",
            MarketplaceIds = ["some example string"],
        });
    // TODO: Handle 'response' of type object
}
catch (ApiException<CreateProductReviewAndSellerFeedbackSolicitationError> ex)
{
    if (ex.Error.TryGetErrorList(out var error))
    {
        // TODO: Handle 'error' of type ErrorList
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[CreateProductReviewAndSellerFeedbackSolicitationRequest](src/WalmartApIs/Requests/Solicitations/CreateProductReviewAndSellerFeedbackSolicitationRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>object</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[CreateProductReviewAndSellerFeedbackSolicitationError](src/WalmartApIs/Errors/CreateProductReviewAndSellerFeedbackSolicitationError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;object&gt; GetSolicitationActionsForOrder(GetSolicitationActionsForOrderRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.Solicitations.GetSolicitationActionsForOrder(new GetSolicitationActionsForOrderRequest
    {
        SpApiOrderId = "some example string",
        MarketplaceIds = ["some example string"],
    });
    // TODO: Handle 'response' of type object
}
catch (ApiException<GetSolicitationActionsForOrderError> ex)
{
    if (ex.Error.TryGetErrorList(out var error))
    {
        // TODO: Handle 'error' of type ErrorList
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[GetSolicitationActionsForOrderRequest](src/WalmartApIs/Requests/Solicitations/GetSolicitationActionsForOrderRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>object</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[GetSolicitationActionsForOrderError](src/WalmartApIs/Errors/GetSolicitationActionsForOrderError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

## WfsInbound

> Source: [WfsInbound](src/WalmartApIs/Api/WfsInbound.cs)

<details>
<summary><code>Task&lt;CancelInboundPlanResponse&gt; CancelInboundPlan(CancelInboundPlanRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.WfsInbound.CancelInboundPlan(new CancelInboundPlanRequest
    {
        InboundPlanId = "some example string",
    });
    // TODO: Handle 'response' of type CancelInboundPlanResponse
}
catch (ApiException<CancelInboundPlanError> ex)
{
    if (ex.Error.TryGetCommonErrorList(out var error))
    {
        // TODO: Handle 'error' of type CommonErrorList
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[CancelInboundPlanRequest](src/WalmartApIs/Requests/WfsInbound/CancelInboundPlanRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[CancelInboundPlanResponse](src/WalmartApIs/Models/CancelInboundPlanResponse.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[CancelInboundPlanError](src/WalmartApIs/Errors/CancelInboundPlanError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;CancelInboundPlanResponse&gt; CancelSelfShipAppointment(CancelSelfShipAppointmentOperationRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.WfsInbound.CancelSelfShipAppointment(new CancelSelfShipAppointmentOperationRequest
    {
        InboundPlanId = "some example string",
        ShipmentId = "some example string",
        Body = new CancelSelfShipAppointmentRequest(),
    });
    // TODO: Handle 'response' of type CancelInboundPlanResponse
}
catch (ApiException<CancelSelfShipAppointmentError> ex)
{
    if (ex.Error.TryGetCommonErrorList(out var error))
    {
        // TODO: Handle 'error' of type CommonErrorList
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[CancelSelfShipAppointmentOperationRequest](src/WalmartApIs/Requests/WfsInbound/CancelSelfShipAppointmentOperationRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[CancelInboundPlanResponse](src/WalmartApIs/Models/CancelInboundPlanResponse.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[CancelSelfShipAppointmentError](src/WalmartApIs/Errors/CancelSelfShipAppointmentError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;CancelInboundPlanResponse&gt; ConfirmDeliveryWindowOptions(ConfirmDeliveryWindowOptionsRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.WfsInbound.ConfirmDeliveryWindowOptions(new ConfirmDeliveryWindowOptionsRequest
    {
        InboundPlanId = "some example string",
        ShipmentId = "some example string",
        DeliveryWindowOptionId = "some example string",
    });
    // TODO: Handle 'response' of type CancelInboundPlanResponse
}
catch (ApiException<ConfirmDeliveryWindowOptionsError> ex)
{
    if (ex.Error.TryGetCommonErrorList(out var error))
    {
        // TODO: Handle 'error' of type CommonErrorList
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[ConfirmDeliveryWindowOptionsRequest](src/WalmartApIs/Requests/WfsInbound/ConfirmDeliveryWindowOptionsRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[CancelInboundPlanResponse](src/WalmartApIs/Models/CancelInboundPlanResponse.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[ConfirmDeliveryWindowOptionsError](src/WalmartApIs/Errors/ConfirmDeliveryWindowOptionsError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;CancelInboundPlanResponse&gt; ConfirmPackingOption(ConfirmPackingOptionRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.WfsInbound.ConfirmPackingOption(new ConfirmPackingOptionRequest
    {
        InboundPlanId = "some example string",
        PackingOptionId = "some example string",
    });
    // TODO: Handle 'response' of type CancelInboundPlanResponse
}
catch (ApiException<ConfirmPackingOptionError> ex)
{
    if (ex.Error.TryGetCommonErrorList(out var error))
    {
        // TODO: Handle 'error' of type CommonErrorList
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[ConfirmPackingOptionRequest](src/WalmartApIs/Requests/WfsInbound/ConfirmPackingOptionRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[CancelInboundPlanResponse](src/WalmartApIs/Models/CancelInboundPlanResponse.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[ConfirmPackingOptionError](src/WalmartApIs/Errors/ConfirmPackingOptionError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;CancelInboundPlanResponse&gt; ConfirmPlacementOption(ConfirmPlacementOptionRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.WfsInbound.ConfirmPlacementOption(new ConfirmPlacementOptionRequest
    {
        InboundPlanId = "some example string",
        PlacementOptionId = "some example string",
    });
    // TODO: Handle 'response' of type CancelInboundPlanResponse
}
catch (ApiException<ConfirmPlacementOptionError> ex)
{
    if (ex.Error.TryGetCommonErrorList(out var error))
    {
        // TODO: Handle 'error' of type CommonErrorList
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[ConfirmPlacementOptionRequest](src/WalmartApIs/Requests/WfsInbound/ConfirmPlacementOptionRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[CancelInboundPlanResponse](src/WalmartApIs/Models/CancelInboundPlanResponse.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[ConfirmPlacementOptionError](src/WalmartApIs/Errors/ConfirmPlacementOptionError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;CancelInboundPlanResponse&gt; ConfirmShipmentContentUpdatePreview(ConfirmShipmentContentUpdatePreviewRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.WfsInbound.ConfirmShipmentContentUpdatePreview(
        new ConfirmShipmentContentUpdatePreviewRequest
        {
            InboundPlanId = "some example string",
            ShipmentId = "some example string",
            ContentUpdatePreviewId = "some example string",
        });
    // TODO: Handle 'response' of type CancelInboundPlanResponse
}
catch (ApiException<ConfirmShipmentContentUpdatePreviewError> ex)
{
    if (ex.Error.TryGetCommonErrorList(out var error))
    {
        // TODO: Handle 'error' of type CommonErrorList
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[ConfirmShipmentContentUpdatePreviewRequest](src/WalmartApIs/Requests/WfsInbound/ConfirmShipmentContentUpdatePreviewRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[CancelInboundPlanResponse](src/WalmartApIs/Models/CancelInboundPlanResponse.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[ConfirmShipmentContentUpdatePreviewError](src/WalmartApIs/Errors/ConfirmShipmentContentUpdatePreviewError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;CancelInboundPlanResponse&gt; ConfirmTransportationOptions(ConfirmTransportationOptionsOperationRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.WfsInbound.ConfirmTransportationOptions(new ConfirmTransportationOptionsOperationRequest
    {
        InboundPlanId = "some example string",
        Body = new ConfirmTransportationOptionsRequest
        {
            TransportationSelections = [
                new CommonTransportationSelection
                {
                    ShipmentId = "some example string",
                    TransportationOptionId = "some example string",
                },
            ],
        },
    });
    // TODO: Handle 'response' of type CancelInboundPlanResponse
}
catch (ApiException<ConfirmTransportationOptionsError> ex)
{
    if (ex.Error.TryGetCommonErrorList(out var error))
    {
        // TODO: Handle 'error' of type CommonErrorList
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[ConfirmTransportationOptionsOperationRequest](src/WalmartApIs/Requests/WfsInbound/ConfirmTransportationOptionsOperationRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[CancelInboundPlanResponse](src/WalmartApIs/Models/CancelInboundPlanResponse.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[ConfirmTransportationOptionsError](src/WalmartApIs/Errors/ConfirmTransportationOptionsError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;CreateInboundPlanResponse&gt; CreateInboundPlan(CreateInboundPlanOperationRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.WfsInbound.CreateInboundPlan(new CreateInboundPlanOperationRequest
    {
        Body = new CreateInboundPlanRequest
        {
            DestinationMarketplaces = ["some example string"],
            Items = [
                new CommonItemInput
                {
                    LabelOwner = CommonLabelOwner.Seller,
                    Msku = "some example string",
                    PrepOwner = CommonPrepOwner.Seller,
                    Quantity = 1,
                },
            ],
            SourceAddress = new CommonAddressInput
            {
                AddressLine1 = "some example string",
                City = "some example string",
                CountryCode = "some example string",
                Name = "some example string",
                PhoneNumber = "some example string",
                PostalCode = "some example string",
            },
        },
    });
    // TODO: Handle 'response' of type CreateInboundPlanResponse
}
catch (ApiException<CreateInboundPlanError> ex)
{
    if (ex.Error.TryGetCommonErrorList(out var error))
    {
        // TODO: Handle 'error' of type CommonErrorList
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[CreateInboundPlanOperationRequest](src/WalmartApIs/Requests/WfsInbound/CreateInboundPlanOperationRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[CreateInboundPlanResponse](src/WalmartApIs/Models/CreateInboundPlanResponse.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[CreateInboundPlanError](src/WalmartApIs/Errors/CreateInboundPlanError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;CreateMarketplaceItemLabelsResponse&gt; CreateMarketplaceItemLabels(CreateMarketplaceItemLabelsOperationRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.WfsInbound.CreateMarketplaceItemLabels(new CreateMarketplaceItemLabelsOperationRequest
    {
        Body = new CreateMarketplaceItemLabelsRequest
        {
            LabelType = CommonLabelPrintType.StandardFormat,
            MarketplaceId = "some example string",
            MskuQuantities = [new CommonMskuQuantity { Msku = "some example string", Quantity = 1 }],
        },
    });
    // TODO: Handle 'response' of type CreateMarketplaceItemLabelsResponse
}
catch (ApiException<CreateMarketplaceItemLabelsError> ex)
{
    if (ex.Error.TryGetCommonErrorList(out var error))
    {
        // TODO: Handle 'error' of type CommonErrorList
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[CreateMarketplaceItemLabelsOperationRequest](src/WalmartApIs/Requests/WfsInbound/CreateMarketplaceItemLabelsOperationRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[CreateMarketplaceItemLabelsResponse](src/WalmartApIs/Models/CreateMarketplaceItemLabelsResponse.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[CreateMarketplaceItemLabelsError](src/WalmartApIs/Errors/CreateMarketplaceItemLabelsError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;CancelInboundPlanResponse&gt; GenerateDeliveryWindowOptions(GenerateDeliveryWindowOptionsRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.WfsInbound.GenerateDeliveryWindowOptions(new GenerateDeliveryWindowOptionsRequest
    {
        InboundPlanId = "some example string",
        ShipmentId = "some example string",
    });
    // TODO: Handle 'response' of type CancelInboundPlanResponse
}
catch (ApiException<GenerateDeliveryWindowOptionsError> ex)
{
    if (ex.Error.TryGetCommonErrorList(out var error))
    {
        // TODO: Handle 'error' of type CommonErrorList
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[GenerateDeliveryWindowOptionsRequest](src/WalmartApIs/Requests/WfsInbound/GenerateDeliveryWindowOptionsRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[CancelInboundPlanResponse](src/WalmartApIs/Models/CancelInboundPlanResponse.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[GenerateDeliveryWindowOptionsError](src/WalmartApIs/Errors/GenerateDeliveryWindowOptionsError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;CancelInboundPlanResponse&gt; GeneratePackingOptions(GeneratePackingOptionsRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.WfsInbound.GeneratePackingOptions(new GeneratePackingOptionsRequest
    {
        InboundPlanId = "some example string",
    });
    // TODO: Handle 'response' of type CancelInboundPlanResponse
}
catch (ApiException<GeneratePackingOptionsError> ex)
{
    if (ex.Error.TryGetCommonErrorList(out var error))
    {
        // TODO: Handle 'error' of type CommonErrorList
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[GeneratePackingOptionsRequest](src/WalmartApIs/Requests/WfsInbound/GeneratePackingOptionsRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[CancelInboundPlanResponse](src/WalmartApIs/Models/CancelInboundPlanResponse.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[GeneratePackingOptionsError](src/WalmartApIs/Errors/GeneratePackingOptionsError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;CancelInboundPlanResponse&gt; GeneratePlacementOptions(GeneratePlacementOptionsOperationRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.WfsInbound.GeneratePlacementOptions(new GeneratePlacementOptionsOperationRequest
    {
        InboundPlanId = "some example string",
        Body = new GeneratePlacementOptionsRequest(),
    });
    // TODO: Handle 'response' of type CancelInboundPlanResponse
}
catch (ApiException<GeneratePlacementOptionsError> ex)
{
    if (ex.Error.TryGetCommonErrorList(out var error))
    {
        // TODO: Handle 'error' of type CommonErrorList
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[GeneratePlacementOptionsOperationRequest](src/WalmartApIs/Requests/WfsInbound/GeneratePlacementOptionsOperationRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[CancelInboundPlanResponse](src/WalmartApIs/Models/CancelInboundPlanResponse.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[GeneratePlacementOptionsError](src/WalmartApIs/Errors/GeneratePlacementOptionsError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;CancelInboundPlanResponse&gt; GenerateSelfShipAppointmentSlots(GenerateSelfShipAppointmentSlotsOperationRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.WfsInbound.GenerateSelfShipAppointmentSlots(
        new GenerateSelfShipAppointmentSlotsOperationRequest
        {
            InboundPlanId = "some example string",
            ShipmentId = "some example string",
            Body = new GenerateSelfShipAppointmentSlotsRequest(),
        });
    // TODO: Handle 'response' of type CancelInboundPlanResponse
}
catch (ApiException<GenerateSelfShipAppointmentSlotsError> ex)
{
    if (ex.Error.TryGetCommonErrorList(out var error))
    {
        // TODO: Handle 'error' of type CommonErrorList
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[GenerateSelfShipAppointmentSlotsOperationRequest](src/WalmartApIs/Requests/WfsInbound/GenerateSelfShipAppointmentSlotsOperationRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[CancelInboundPlanResponse](src/WalmartApIs/Models/CancelInboundPlanResponse.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[GenerateSelfShipAppointmentSlotsError](src/WalmartApIs/Errors/GenerateSelfShipAppointmentSlotsError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;CancelInboundPlanResponse&gt; GenerateShipmentContentUpdatePreviews(GenerateShipmentContentUpdatePreviewsOperationRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.WfsInbound.GenerateShipmentContentUpdatePreviews(
        new GenerateShipmentContentUpdatePreviewsOperationRequest
        {
            InboundPlanId = "some example string",
            ShipmentId = "some example string",
            Body = new GenerateShipmentContentUpdatePreviewsRequest
            {
                Boxes = [
                    new CommonBoxUpdateInput
                    {
                        ContentInformationSource = CommonBoxContentInformationSource.BoxContentProvided,
                        Dimensions = new CommonDimensions
                        {
                            Height = 1.5d,
                            Length = 1.5d,
                            Width = 1.5d,
                            UnitOfMeasurement = CommonUnitOfMeasurement.In,
                        },
                        Quantity = 1,
                        Weight = new CommonWeight { Unit = CommonUnitOfWeight.Lb, Value = 1.5d },
                    },
                ],
                Items = [
                    new CommonItemInput
                    {
                        LabelOwner = CommonLabelOwner.Seller,
                        Msku = "some example string",
                        PrepOwner = CommonPrepOwner.Seller,
                        Quantity = 1,
                    },
                ],
            },
        });
    // TODO: Handle 'response' of type CancelInboundPlanResponse
}
catch (ApiException<GenerateShipmentContentUpdatePreviewsError> ex)
{
    if (ex.Error.TryGetCommonErrorList(out var error))
    {
        // TODO: Handle 'error' of type CommonErrorList
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[GenerateShipmentContentUpdatePreviewsOperationRequest](src/WalmartApIs/Requests/WfsInbound/GenerateShipmentContentUpdatePreviewsOperationRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[CancelInboundPlanResponse](src/WalmartApIs/Models/CancelInboundPlanResponse.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[GenerateShipmentContentUpdatePreviewsError](src/WalmartApIs/Errors/GenerateShipmentContentUpdatePreviewsError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;CancelInboundPlanResponse&gt; GenerateTransportationOptions(GenerateTransportationOptionsOperationRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.WfsInbound.GenerateTransportationOptions(
        new GenerateTransportationOptionsOperationRequest
        {
            InboundPlanId = "some example string",
            Body = new GenerateTransportationOptionsRequest
            {
                PlacementOptionId = "some example string",
                ShipmentTransportationConfigurations = [
                    new CommonShipmentTransportationConfiguration
                    {
                        ReadyToShipWindow = new CommonWindowInput
                        {
                            Start = DateTimeOffset.Parse("2024-01-15T09:30:00Z"),
                        },
                        ShipmentId = "some example string",
                    },
                ],
            },
        });
    // TODO: Handle 'response' of type CancelInboundPlanResponse
}
catch (ApiException<GenerateTransportationOptionsError> ex)
{
    if (ex.Error.TryGetCommonErrorList(out var error))
    {
        // TODO: Handle 'error' of type CommonErrorList
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[GenerateTransportationOptionsOperationRequest](src/WalmartApIs/Requests/WfsInbound/GenerateTransportationOptionsOperationRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[CancelInboundPlanResponse](src/WalmartApIs/Models/CancelInboundPlanResponse.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[GenerateTransportationOptionsError](src/WalmartApIs/Errors/GenerateTransportationOptionsError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;GetDeliveryChallanDocumentResponse&gt; GetDeliveryChallanDocument(GetDeliveryChallanDocumentRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.WfsInbound.GetDeliveryChallanDocument(new GetDeliveryChallanDocumentRequest
    {
        InboundPlanId = "some example string",
        ShipmentId = "some example string",
    });
    // TODO: Handle 'response' of type GetDeliveryChallanDocumentResponse
}
catch (ApiException<GetDeliveryChallanDocumentError> ex)
{
    if (ex.Error.TryGetCommonErrorList(out var error))
    {
        // TODO: Handle 'error' of type CommonErrorList
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[GetDeliveryChallanDocumentRequest](src/WalmartApIs/Requests/WfsInbound/GetDeliveryChallanDocumentRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[GetDeliveryChallanDocumentResponse](src/WalmartApIs/Models/GetDeliveryChallanDocumentResponse.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[GetDeliveryChallanDocumentError](src/WalmartApIs/Errors/GetDeliveryChallanDocumentError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;CommonInboundOperationStatus&gt; GetInboundOperationStatus(GetInboundOperationStatusRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.WfsInbound.GetInboundOperationStatus(new GetInboundOperationStatusRequest
    {
        OperationId = "some example string",
    });
    // TODO: Handle 'response' of type CommonInboundOperationStatus
}
catch (ApiException<GetInboundOperationStatusError> ex)
{
    if (ex.Error.TryGetCommonErrorList(out var error))
    {
        // TODO: Handle 'error' of type CommonErrorList
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[GetInboundOperationStatusRequest](src/WalmartApIs/Requests/WfsInbound/GetInboundOperationStatusRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[CommonInboundOperationStatus](src/WalmartApIs/Models/CommonInboundOperationStatus.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[GetInboundOperationStatusError](src/WalmartApIs/Errors/GetInboundOperationStatusError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;InboundPlan&gt; GetInboundPlan(GetInboundPlanRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.WfsInbound.GetInboundPlan(new GetInboundPlanRequest
    {
        InboundPlanId = "some example string",
    });
    // TODO: Handle 'response' of type InboundPlan
}
catch (ApiException<GetInboundPlanError> ex)
{
    if (ex.Error.TryGetCommonErrorList(out var error))
    {
        // TODO: Handle 'error' of type CommonErrorList
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[GetInboundPlanRequest](src/WalmartApIs/Requests/WfsInbound/GetInboundPlanRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[InboundPlan](src/WalmartApIs/Models/InboundPlan.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[GetInboundPlanError](src/WalmartApIs/Errors/GetInboundPlanError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;GetSelfShipAppointmentSlotsResponse&gt; GetSelfShipAppointmentSlots(GetSelfShipAppointmentSlotsRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.WfsInbound.GetSelfShipAppointmentSlots(new GetSelfShipAppointmentSlotsRequest
    {
        InboundPlanId = "some example string",
        ShipmentId = "some example string",
    });
    // TODO: Handle 'response' of type GetSelfShipAppointmentSlotsResponse
}
catch (ApiException<GetSelfShipAppointmentSlotsError> ex)
{
    if (ex.Error.TryGetCommonErrorList(out var error))
    {
        // TODO: Handle 'error' of type CommonErrorList
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[GetSelfShipAppointmentSlotsRequest](src/WalmartApIs/Requests/WfsInbound/GetSelfShipAppointmentSlotsRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[GetSelfShipAppointmentSlotsResponse](src/WalmartApIs/Models/GetSelfShipAppointmentSlotsResponse.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[GetSelfShipAppointmentSlotsError](src/WalmartApIs/Errors/GetSelfShipAppointmentSlotsError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;CommonShipment&gt; GetShipment(GetShipmentRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.WfsInbound.GetShipment(new GetShipmentRequest
    {
        InboundPlanId = "some example string",
        ShipmentId = "some example string",
    });
    // TODO: Handle 'response' of type CommonShipment
}
catch (ApiException<GetShipmentError> ex)
{
    if (ex.Error.TryGetCommonErrorList(out var error))
    {
        // TODO: Handle 'error' of type CommonErrorList
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[GetShipmentRequest](src/WalmartApIs/Requests/WfsInbound/GetShipmentRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[CommonShipment](src/WalmartApIs/Models/CommonShipment.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[GetShipmentError](src/WalmartApIs/Errors/GetShipmentError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;CommonContentUpdatePreview&gt; GetShipmentContentUpdatePreview(GetShipmentContentUpdatePreviewRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.WfsInbound.GetShipmentContentUpdatePreview(new GetShipmentContentUpdatePreviewRequest
    {
        InboundPlanId = "some example string",
        ShipmentId = "some example string",
        ContentUpdatePreviewId = "some example string",
    });
    // TODO: Handle 'response' of type CommonContentUpdatePreview
}
catch (ApiException<GetShipmentContentUpdatePreviewError> ex)
{
    if (ex.Error.TryGetCommonErrorList(out var error))
    {
        // TODO: Handle 'error' of type CommonErrorList
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[GetShipmentContentUpdatePreviewRequest](src/WalmartApIs/Requests/WfsInbound/GetShipmentContentUpdatePreviewRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[CommonContentUpdatePreview](src/WalmartApIs/Models/CommonContentUpdatePreview.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[GetShipmentContentUpdatePreviewError](src/WalmartApIs/Errors/GetShipmentContentUpdatePreviewError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;ListDeliveryWindowOptionsResponse&gt; ListDeliveryWindowOptions(ListDeliveryWindowOptionsRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.WfsInbound.ListDeliveryWindowOptions(new ListDeliveryWindowOptionsRequest
    {
        InboundPlanId = "some example string",
        ShipmentId = "some example string",
    });
    // TODO: Handle 'response' of type ListDeliveryWindowOptionsResponse
}
catch (ApiException<ListDeliveryWindowOptionsError> ex)
{
    if (ex.Error.TryGetCommonErrorList(out var error))
    {
        // TODO: Handle 'error' of type CommonErrorList
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[ListDeliveryWindowOptionsRequest](src/WalmartApIs/Requests/WfsInbound/ListDeliveryWindowOptionsRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[ListDeliveryWindowOptionsResponse](src/WalmartApIs/Models/ListDeliveryWindowOptionsResponse.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[ListDeliveryWindowOptionsError](src/WalmartApIs/Errors/ListDeliveryWindowOptionsError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;ListInboundPlanBoxesResponse&gt; ListInboundPlanBoxes(ListInboundPlanBoxesRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.WfsInbound.ListInboundPlanBoxes(new ListInboundPlanBoxesRequest
    {
        InboundPlanId = "some example string",
    });
    // TODO: Handle 'response' of type ListInboundPlanBoxesResponse
}
catch (ApiException<ListInboundPlanBoxesError> ex)
{
    if (ex.Error.TryGetCommonErrorList(out var error))
    {
        // TODO: Handle 'error' of type CommonErrorList
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[ListInboundPlanBoxesRequest](src/WalmartApIs/Requests/WfsInbound/ListInboundPlanBoxesRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[ListInboundPlanBoxesResponse](src/WalmartApIs/Models/ListInboundPlanBoxesResponse.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[ListInboundPlanBoxesError](src/WalmartApIs/Errors/ListInboundPlanBoxesError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;ListInboundPlanItemsResponse&gt; ListInboundPlanItems(ListInboundPlanItemsRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.WfsInbound.ListInboundPlanItems(new ListInboundPlanItemsRequest
    {
        InboundPlanId = "some example string",
    });
    // TODO: Handle 'response' of type ListInboundPlanItemsResponse
}
catch (ApiException<ListInboundPlanItemsError> ex)
{
    if (ex.Error.TryGetCommonErrorList(out var error))
    {
        // TODO: Handle 'error' of type CommonErrorList
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[ListInboundPlanItemsRequest](src/WalmartApIs/Requests/WfsInbound/ListInboundPlanItemsRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[ListInboundPlanItemsResponse](src/WalmartApIs/Models/ListInboundPlanItemsResponse.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[ListInboundPlanItemsError](src/WalmartApIs/Errors/ListInboundPlanItemsError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;ListInboundPlanPalletsResponse&gt; ListInboundPlanPallets(ListInboundPlanPalletsRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.WfsInbound.ListInboundPlanPallets(new ListInboundPlanPalletsRequest
    {
        InboundPlanId = "some example string",
    });
    // TODO: Handle 'response' of type ListInboundPlanPalletsResponse
}
catch (ApiException<ListInboundPlanPalletsError> ex)
{
    if (ex.Error.TryGetCommonErrorList(out var error))
    {
        // TODO: Handle 'error' of type CommonErrorList
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[ListInboundPlanPalletsRequest](src/WalmartApIs/Requests/WfsInbound/ListInboundPlanPalletsRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[ListInboundPlanPalletsResponse](src/WalmartApIs/Models/ListInboundPlanPalletsResponse.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[ListInboundPlanPalletsError](src/WalmartApIs/Errors/ListInboundPlanPalletsError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;ListInboundPlansResponse&gt; ListInboundPlans(ListInboundPlansRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.WfsInbound.ListInboundPlans(new ListInboundPlansRequest());
    // TODO: Handle 'response' of type ListInboundPlansResponse
}
catch (ApiException<ListInboundPlansError> ex)
{
    if (ex.Error.TryGetCommonErrorList(out var error))
    {
        // TODO: Handle 'error' of type CommonErrorList
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[ListInboundPlansRequest](src/WalmartApIs/Requests/WfsInbound/ListInboundPlansRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[ListInboundPlansResponse](src/WalmartApIs/Models/ListInboundPlansResponse.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[ListInboundPlansError](src/WalmartApIs/Errors/ListInboundPlansError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;ListItemComplianceDetailsResponse&gt; ListItemComplianceDetails(ListItemComplianceDetailsRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.WfsInbound.ListItemComplianceDetails(new ListItemComplianceDetailsRequest
    {
        Mskus = ["some example string"],
        MarketplaceId = "some example string",
    });
    // TODO: Handle 'response' of type ListItemComplianceDetailsResponse
}
catch (ApiException<ListItemComplianceDetailsError> ex)
{
    if (ex.Error.TryGetCommonErrorList(out var error))
    {
        // TODO: Handle 'error' of type CommonErrorList
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[ListItemComplianceDetailsRequest](src/WalmartApIs/Requests/WfsInbound/ListItemComplianceDetailsRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[ListItemComplianceDetailsResponse](src/WalmartApIs/Models/ListItemComplianceDetailsResponse.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[ListItemComplianceDetailsError](src/WalmartApIs/Errors/ListItemComplianceDetailsError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;ListInboundPlanBoxesResponse&gt; ListPackingGroupBoxes(ListPackingGroupBoxesRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.WfsInbound.ListPackingGroupBoxes(new ListPackingGroupBoxesRequest
    {
        InboundPlanId = "some example string",
        PackingGroupId = "some example string",
    });
    // TODO: Handle 'response' of type ListInboundPlanBoxesResponse
}
catch (ApiException<ListPackingGroupBoxesError> ex)
{
    if (ex.Error.TryGetCommonErrorList(out var error))
    {
        // TODO: Handle 'error' of type CommonErrorList
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[ListPackingGroupBoxesRequest](src/WalmartApIs/Requests/WfsInbound/ListPackingGroupBoxesRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[ListInboundPlanBoxesResponse](src/WalmartApIs/Models/ListInboundPlanBoxesResponse.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[ListPackingGroupBoxesError](src/WalmartApIs/Errors/ListPackingGroupBoxesError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;ListInboundPlanItemsResponse&gt; ListPackingGroupItems(ListPackingGroupItemsRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.WfsInbound.ListPackingGroupItems(new ListPackingGroupItemsRequest
    {
        InboundPlanId = "some example string",
        PackingGroupId = "some example string",
    });
    // TODO: Handle 'response' of type ListInboundPlanItemsResponse
}
catch (ApiException<ListPackingGroupItemsError> ex)
{
    if (ex.Error.TryGetCommonErrorList(out var error))
    {
        // TODO: Handle 'error' of type CommonErrorList
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[ListPackingGroupItemsRequest](src/WalmartApIs/Requests/WfsInbound/ListPackingGroupItemsRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[ListInboundPlanItemsResponse](src/WalmartApIs/Models/ListInboundPlanItemsResponse.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[ListPackingGroupItemsError](src/WalmartApIs/Errors/ListPackingGroupItemsError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;ListPackingOptionsResponse&gt; ListPackingOptions(ListPackingOptionsRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.WfsInbound.ListPackingOptions(new ListPackingOptionsRequest
    {
        InboundPlanId = "some example string",
    });
    // TODO: Handle 'response' of type ListPackingOptionsResponse
}
catch (ApiException<ListPackingOptionsError> ex)
{
    if (ex.Error.TryGetCommonErrorList(out var error))
    {
        // TODO: Handle 'error' of type CommonErrorList
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[ListPackingOptionsRequest](src/WalmartApIs/Requests/WfsInbound/ListPackingOptionsRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[ListPackingOptionsResponse](src/WalmartApIs/Models/ListPackingOptionsResponse.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[ListPackingOptionsError](src/WalmartApIs/Errors/ListPackingOptionsError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;ListPlacementOptionsResponse&gt; ListPlacementOptions(ListPlacementOptionsRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.WfsInbound.ListPlacementOptions(new ListPlacementOptionsRequest
    {
        InboundPlanId = "some example string",
    });
    // TODO: Handle 'response' of type ListPlacementOptionsResponse
}
catch (ApiException<ListPlacementOptionsError> ex)
{
    if (ex.Error.TryGetCommonErrorList(out var error))
    {
        // TODO: Handle 'error' of type CommonErrorList
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[ListPlacementOptionsRequest](src/WalmartApIs/Requests/WfsInbound/ListPlacementOptionsRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[ListPlacementOptionsResponse](src/WalmartApIs/Models/ListPlacementOptionsResponse.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[ListPlacementOptionsError](src/WalmartApIs/Errors/ListPlacementOptionsError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;ListPrepDetailsResponse&gt; ListPrepDetails(ListPrepDetailsRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.WfsInbound.ListPrepDetails(new ListPrepDetailsRequest
    {
        MarketplaceId = "some example string",
        Mskus = ["some example string"],
    });
    // TODO: Handle 'response' of type ListPrepDetailsResponse
}
catch (ApiException<ListPrepDetailsError> ex)
{
    if (ex.Error.TryGetCommonErrorList(out var error))
    {
        // TODO: Handle 'error' of type CommonErrorList
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[ListPrepDetailsRequest](src/WalmartApIs/Requests/WfsInbound/ListPrepDetailsRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[ListPrepDetailsResponse](src/WalmartApIs/Models/ListPrepDetailsResponse.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[ListPrepDetailsError](src/WalmartApIs/Errors/ListPrepDetailsError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;ListInboundPlanBoxesResponse&gt; ListShipmentBoxes(ListShipmentBoxesRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.WfsInbound.ListShipmentBoxes(new ListShipmentBoxesRequest
    {
        InboundPlanId = "some example string",
        ShipmentId = "some example string",
    });
    // TODO: Handle 'response' of type ListInboundPlanBoxesResponse
}
catch (ApiException<ListShipmentBoxesError> ex)
{
    if (ex.Error.TryGetCommonErrorList(out var error))
    {
        // TODO: Handle 'error' of type CommonErrorList
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[ListShipmentBoxesRequest](src/WalmartApIs/Requests/WfsInbound/ListShipmentBoxesRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[ListInboundPlanBoxesResponse](src/WalmartApIs/Models/ListInboundPlanBoxesResponse.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[ListShipmentBoxesError](src/WalmartApIs/Errors/ListShipmentBoxesError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;ListShipmentContentUpdatePreviewsResponse&gt; ListShipmentContentUpdatePreviews(ListShipmentContentUpdatePreviewsRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.WfsInbound.ListShipmentContentUpdatePreviews(
        new ListShipmentContentUpdatePreviewsRequest
        {
            InboundPlanId = "some example string",
            ShipmentId = "some example string",
        });
    // TODO: Handle 'response' of type ListShipmentContentUpdatePreviewsResponse
}
catch (ApiException<ListShipmentContentUpdatePreviewsError> ex)
{
    if (ex.Error.TryGetCommonErrorList(out var error))
    {
        // TODO: Handle 'error' of type CommonErrorList
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[ListShipmentContentUpdatePreviewsRequest](src/WalmartApIs/Requests/WfsInbound/ListShipmentContentUpdatePreviewsRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[ListShipmentContentUpdatePreviewsResponse](src/WalmartApIs/Models/ListShipmentContentUpdatePreviewsResponse.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[ListShipmentContentUpdatePreviewsError](src/WalmartApIs/Errors/ListShipmentContentUpdatePreviewsError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;ListInboundPlanItemsResponse&gt; ListShipmentItems(ListShipmentItemsRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.WfsInbound.ListShipmentItems(new ListShipmentItemsRequest
    {
        InboundPlanId = "some example string",
        ShipmentId = "some example string",
    });
    // TODO: Handle 'response' of type ListInboundPlanItemsResponse
}
catch (ApiException<ListShipmentItemsError> ex)
{
    if (ex.Error.TryGetCommonErrorList(out var error))
    {
        // TODO: Handle 'error' of type CommonErrorList
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[ListShipmentItemsRequest](src/WalmartApIs/Requests/WfsInbound/ListShipmentItemsRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[ListInboundPlanItemsResponse](src/WalmartApIs/Models/ListInboundPlanItemsResponse.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[ListShipmentItemsError](src/WalmartApIs/Errors/ListShipmentItemsError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;ListInboundPlanPalletsResponse&gt; ListShipmentPallets(ListShipmentPalletsRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.WfsInbound.ListShipmentPallets(new ListShipmentPalletsRequest
    {
        InboundPlanId = "some example string",
        ShipmentId = "some example string",
    });
    // TODO: Handle 'response' of type ListInboundPlanPalletsResponse
}
catch (ApiException<ListShipmentPalletsError> ex)
{
    if (ex.Error.TryGetCommonErrorList(out var error))
    {
        // TODO: Handle 'error' of type CommonErrorList
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[ListShipmentPalletsRequest](src/WalmartApIs/Requests/WfsInbound/ListShipmentPalletsRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[ListInboundPlanPalletsResponse](src/WalmartApIs/Models/ListInboundPlanPalletsResponse.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[ListShipmentPalletsError](src/WalmartApIs/Errors/ListShipmentPalletsError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;ListTransportationOptionsResponse&gt; ListTransportationOptions(ListTransportationOptionsRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.WfsInbound.ListTransportationOptions(new ListTransportationOptionsRequest
    {
        InboundPlanId = "some example string",
    });
    // TODO: Handle 'response' of type ListTransportationOptionsResponse
}
catch (ApiException<ListTransportationOptionsError> ex)
{
    if (ex.Error.TryGetCommonErrorList(out var error))
    {
        // TODO: Handle 'error' of type CommonErrorList
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[ListTransportationOptionsRequest](src/WalmartApIs/Requests/WfsInbound/ListTransportationOptionsRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[ListTransportationOptionsResponse](src/WalmartApIs/Models/ListTransportationOptionsResponse.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[ListTransportationOptionsError](src/WalmartApIs/Errors/ListTransportationOptionsError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;ScheduleSelfShipAppointmentResponse&gt; ScheduleSelfShipAppointment(ScheduleSelfShipAppointmentOperationRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.WfsInbound.ScheduleSelfShipAppointment(new ScheduleSelfShipAppointmentOperationRequest
    {
        InboundPlanId = "some example string",
        ShipmentId = "some example string",
        SlotId = "some example string",
        Body = new ScheduleSelfShipAppointmentRequest(),
    });
    // TODO: Handle 'response' of type ScheduleSelfShipAppointmentResponse
}
catch (ApiException<ScheduleSelfShipAppointmentError> ex)
{
    if (ex.Error.TryGetCommonErrorList(out var error))
    {
        // TODO: Handle 'error' of type CommonErrorList
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[ScheduleSelfShipAppointmentOperationRequest](src/WalmartApIs/Requests/WfsInbound/ScheduleSelfShipAppointmentOperationRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[ScheduleSelfShipAppointmentResponse](src/WalmartApIs/Models/ScheduleSelfShipAppointmentResponse.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[ScheduleSelfShipAppointmentError](src/WalmartApIs/Errors/ScheduleSelfShipAppointmentError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;CancelInboundPlanResponse&gt; SetPackingInformation(SetPackingInformationOperationRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.WfsInbound.SetPackingInformation(new SetPackingInformationOperationRequest
    {
        InboundPlanId = "some example string",
        Body = new SetPackingInformationRequest
        {
            PackageGroupings = [
                new CommonPackageGroupingInput
                {
                    Boxes = [
                        new CommonBoxInput
                        {
                            ContentInformationSource = CommonBoxContentInformationSource.BoxContentProvided,
                            Dimensions = new CommonDimensions
                            {
                                Height = height,
                                Length = length,
                                Width = width,
                                UnitOfMeasurement = unitOfMeasurement,
                            },
                            Quantity = 1,
                            Weight = new CommonWeight { Unit = unit, Value = value },
                        },
                    ],
                },
            ],
        },
    });
    // TODO: Handle 'response' of type CancelInboundPlanResponse
}
catch (ApiException<SetPackingInformationError> ex)
{
    if (ex.Error.TryGetCommonErrorList(out var error))
    {
        // TODO: Handle 'error' of type CommonErrorList
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[SetPackingInformationOperationRequest](src/WalmartApIs/Requests/WfsInbound/SetPackingInformationOperationRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[CancelInboundPlanResponse](src/WalmartApIs/Models/CancelInboundPlanResponse.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[SetPackingInformationError](src/WalmartApIs/Errors/SetPackingInformationError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;CancelInboundPlanResponse&gt; SetPrepDetails(SetPrepDetailsOperationRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.WfsInbound.SetPrepDetails(new SetPrepDetailsOperationRequest
    {
        Body = new SetPrepDetailsRequest
        {
            MarketplaceId = "some example string",
            MskuPrepDetails = [
                new CommonMskuPrepDetailInput
                {
                    Msku = "some example string",
                    PrepCategory = CommonPrepCategory.Adult,
                    PrepTypes = [CommonPrepType.ItemBlackShrinkwrap],
                },
            ],
        },
    });
    // TODO: Handle 'response' of type CancelInboundPlanResponse
}
catch (ApiException<SetPrepDetailsError> ex)
{
    if (ex.Error.TryGetCommonErrorList(out var error))
    {
        // TODO: Handle 'error' of type CommonErrorList
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[SetPrepDetailsOperationRequest](src/WalmartApIs/Requests/WfsInbound/SetPrepDetailsOperationRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[CancelInboundPlanResponse](src/WalmartApIs/Models/CancelInboundPlanResponse.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[SetPrepDetailsError](src/WalmartApIs/Errors/SetPrepDetailsError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task UpdateInboundPlanName(UpdateInboundPlanNameOperationRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Usage

<dl>
<dd>

```csharp
try
{
    await client.WfsInbound.UpdateInboundPlanName(new UpdateInboundPlanNameOperationRequest
    {
        InboundPlanId = "some example string",
        Body = new UpdateInboundPlanNameRequest { Name = "some example string" },
    });
}
catch (ApiException<UpdateInboundPlanNameError> ex)
{
    if (ex.Error.TryGetCommonErrorList(out var error))
    {
        // TODO: Handle 'error' of type CommonErrorList
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[UpdateInboundPlanNameOperationRequest](src/WalmartApIs/Requests/WfsInbound/UpdateInboundPlanNameOperationRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: No content

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[UpdateInboundPlanNameError](src/WalmartApIs/Errors/UpdateInboundPlanNameError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;CancelInboundPlanResponse&gt; UpdateItemComplianceDetails(UpdateItemComplianceDetailsOperationRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.WfsInbound.UpdateItemComplianceDetails(new UpdateItemComplianceDetailsOperationRequest
    {
        MarketplaceId = "some example string",
        Body = new UpdateItemComplianceDetailsRequest
        {
            Msku = "some example string",
            TaxDetails = new CommonTaxDetails(),
        },
    });
    // TODO: Handle 'response' of type CancelInboundPlanResponse
}
catch (ApiException<UpdateItemComplianceDetailsError> ex)
{
    if (ex.Error.TryGetCommonErrorList(out var error))
    {
        // TODO: Handle 'error' of type CommonErrorList
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[UpdateItemComplianceDetailsOperationRequest](src/WalmartApIs/Requests/WfsInbound/UpdateItemComplianceDetailsOperationRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[CancelInboundPlanResponse](src/WalmartApIs/Models/CancelInboundPlanResponse.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[UpdateItemComplianceDetailsError](src/WalmartApIs/Errors/UpdateItemComplianceDetailsError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task UpdateShipmentName(UpdateShipmentNameOperationRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Usage

<dl>
<dd>

```csharp
try
{
    await client.WfsInbound.UpdateShipmentName(new UpdateShipmentNameOperationRequest
    {
        InboundPlanId = "some example string",
        ShipmentId = "some example string",
        Body = new UpdateShipmentNameRequest { Name = "some example string" },
    });
}
catch (ApiException<UpdateShipmentNameError> ex)
{
    if (ex.Error.TryGetCommonErrorList(out var error))
    {
        // TODO: Handle 'error' of type CommonErrorList
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[UpdateShipmentNameOperationRequest](src/WalmartApIs/Requests/WfsInbound/UpdateShipmentNameOperationRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: No content

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[UpdateShipmentNameError](src/WalmartApIs/Errors/UpdateShipmentNameError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;CancelInboundPlanResponse&gt; UpdateShipmentSourceAddress(UpdateShipmentSourceAddressOperationRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.WfsInbound.UpdateShipmentSourceAddress(new UpdateShipmentSourceAddressOperationRequest
    {
        InboundPlanId = "some example string",
        ShipmentId = "some example string",
        Body = new UpdateShipmentSourceAddressRequest
        {
            Address = new CommonAddressInput
            {
                AddressLine1 = "some example string",
                City = "some example string",
                CountryCode = "some example string",
                Name = "some example string",
                PhoneNumber = "some example string",
                PostalCode = "some example string",
            },
        },
    });
    // TODO: Handle 'response' of type CancelInboundPlanResponse
}
catch (ApiException<UpdateShipmentSourceAddressError> ex)
{
    if (ex.Error.TryGetCommonErrorList(out var error))
    {
        // TODO: Handle 'error' of type CommonErrorList
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[UpdateShipmentSourceAddressOperationRequest](src/WalmartApIs/Requests/WfsInbound/UpdateShipmentSourceAddressOperationRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[CancelInboundPlanResponse](src/WalmartApIs/Models/CancelInboundPlanResponse.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[UpdateShipmentSourceAddressError](src/WalmartApIs/Errors/UpdateShipmentSourceAddressError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

<details>
<summary><code>Task&lt;CancelInboundPlanResponse&gt; UpdateShipmentTrackingDetails(UpdateShipmentTrackingDetailsOperationRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);</code></summary>

<dl>
<dd>

### Usage

<dl>
<dd>

```csharp
try
{
    var response = await client.WfsInbound.UpdateShipmentTrackingDetails(
        new UpdateShipmentTrackingDetailsOperationRequest
        {
            InboundPlanId = "some example string",
            ShipmentId = "some example string",
            Body = new UpdateShipmentTrackingDetailsRequest { TrackingDetails = new CommonTrackingDetailsInput() },
        });
    // TODO: Handle 'response' of type CancelInboundPlanResponse
}
catch (ApiException<UpdateShipmentTrackingDetailsError> ex)
{
    if (ex.Error.TryGetCommonErrorList(out var error))
    {
        // TODO: Handle 'error' of type CommonErrorList
    }
}
```

</dd>
</dl>

### Request

<dl>
<dd>

<code>[UpdateShipmentTrackingDetailsOperationRequest](src/WalmartApIs/Requests/WfsInbound/UpdateShipmentTrackingDetailsOperationRequest.cs)</code>

</dd>
</dl>

### Response

<dl>
<dd>

**OnSuccess**: <code>[CancelInboundPlanResponse](src/WalmartApIs/Models/CancelInboundPlanResponse.cs)</code>

**OnError**: <code>[ApiException](src/WalmartApIs/Core/Exceptions/ApiException.cs)&lt;[UpdateShipmentTrackingDetailsError](src/WalmartApIs/Errors/UpdateShipmentTrackingDetailsError.cs)&gt;</code>

</dd>
</dl>

</dd>
</dl>

</details>

