<!-- Generated file — do not edit; regenerated with the SDK. -->

# SDK map — Walmart APIs (.NET)

> A generated table of contents for this SDK. Consult this map and its sub-pages to learn signatures, error types, and server/auth wiring **by lookup**. Model shapes and enum values are *not* duplicated here — the map names the file declaring each type; read the shape there. The compiler is the backstop: a wrong name fails to build.

|  |  |
| --- | --- |
| SDK display name | Walmart APIs |
| Root namespace | `WalmartApIs` |
| Target framework | `netstandard2.0` (C# `LangVersion 14`, `Nullable enable`) |
| API spec version | `v4` |
| Generator | APIMatic |

Staleness check: the API spec version above changes when the SDK is regenerated from a new spec. If a lookup here fails to compile, trust the compiler and re-read the source file named in the row.

All `Source` paths on this map and its sub-pages are relative to the **SDK root** — the directory holding this file — never to the page that carries them; the project file is `src/WalmartApIs/WalmartApIs.csproj`. Open them as-is from the SDK root, from any page; if the SDK sits under a subdirectory of a larger repo, prefix that subdirectory.

---

## Getting a client

```csharp
var httpClient = new HttpClient();
// TODO: configure more client options here
var options = new WalmartApIsClientOptions
{
    BasicClientAuth = new BasicAuthCredentials { Username = "YOUR_USERNAME", Password = "YOUR_PASSWORD" },
    SellerAuthClientCredentials = new OAuth2ClientCredentials
    {
        ClientId = "YOUR_CLIENT_ID",
        ClientSecret = "YOUR_CLIENT_SECRET",
    },
    WalletAuth = new OAuth2ClientCredentials { ClientId = "YOUR_CLIENT_ID", ClientSecret = "YOUR_CLIENT_SECRET" },
    SellerAuthAuthorizationCode = new OAuth2AuthorizationCodeCredentials
    {
        ClientId = "YOUR_CLIENT_ID",
        RedirectUri = "YOUR_REDIRECT_URI",
        PromptForAuthorizationCode = (authUrl, ct) => Task.FromResult(""),
    },
    Environment = ServerEnvironment.Production,
};
var client = new WalmartApIsClient(httpClient, options);
```

DI alternative (`services.AddWalmartApIsClient`):

```csharp
services.AddWalmartApIsClient(options =>
{
    options.BasicClientAuth = new BasicAuthCredentials { Username = "YOUR_USERNAME", Password = "YOUR_PASSWORD" };
    options.SellerAuthClientCredentials =
        new OAuth2ClientCredentials { ClientId = "YOUR_CLIENT_ID", ClientSecret = "YOUR_CLIENT_SECRET" };
    options.WalletAuth =
        new OAuth2ClientCredentials { ClientId = "YOUR_CLIENT_ID", ClientSecret = "YOUR_CLIENT_SECRET" };
    options.SellerAuthAuthorizationCode =
        new OAuth2AuthorizationCodeCredentials
        {
            ClientId = "YOUR_CLIENT_ID",
            RedirectUri = "YOUR_REDIRECT_URI",
            PromptForAuthorizationCode = (authUrl, ct) => Task.FromResult(""),
        };
    options.Environment = ServerEnvironment.Production;
    // TODO: configure more client options here
});
```

Every API group is a property on the client (e.g. `client.Authorization`). Source: `src/WalmartApIs/WalmartApIsClient.cs`. The only constructor is `WalmartApIsClient(HttpClient httpClient, WalmartApIsClientOptions options)`.

All `WalmartApIsClientOptions` properties (source: `src/WalmartApIs/WalmartApIsClientOptions.cs`):

| Property | Type |
| --- | --- |
| `Environment` | `ServerEnvironment` |
| `Retry` | `RetryOptions` |
| `Logging` | `LoggingOptions` |
| `TimeProvider` | `TimeProvider` |
| `Server` | `ServerOptions` |
| `StreamReadTimeout` | `TimeSpan?` |
| `Hooks` | `IReadOnlyList<SdkHook>` |
| `SellerAuthAuthorizationCode` | `OAuth2AuthorizationCodeCredentials?` |
| `SellerAuthAuthorizationCodeTokenStrategy` | `IOAuth2RefreshableTokenStrategy<OAuth2AuthorizationCodeCredentials>?` |
| `SellerAuthClientCredentials` | `OAuth2ClientCredentials?` |
| `SellerAuthClientCredentialsTokenStrategy` | `IOAuth2TokenStrategy<OAuth2ClientCredentials>?` |
| `BasicClientAuth` | `BasicAuthCredentials?` |
| `WalletAuth` | `OAuth2ClientCredentials?` |
| `WalletAuthTokenStrategy` | `IOAuth2TokenStrategy<OAuth2ClientCredentials>?` |

`ServerEnvironment` (source: `src/WalmartApIs/Servers/ServerEnvironment.cs`, namespace `WalmartApIs.Servers`)
`OAuth2AuthorizationCodeCredentials` (source: `src/WalmartApIs/Core/Authentication/OAuth2/AuthorizationCode/OAuth2AuthorizationCodeCredentials.cs`, namespace `WalmartApIs.Core.Authentication.OAuth2.AuthorizationCode`)
`OAuth2ClientCredentials` (source: `src/WalmartApIs/Core/Authentication/OAuth2/ClientCredentials/OAuth2ClientCredentials.cs`, namespace `WalmartApIs.Core.Authentication.OAuth2.ClientCredentials`)
`BasicAuthCredentials` (source: `src/WalmartApIs/Core/Authentication/Basic/BasicAuthCredentials.cs`, namespace `WalmartApIs.Core.Authentication.Basic`)

`RetryOptions` members (namespace `WalmartApIs.Core.Configuration` — add `using WalmartApIs.Core.Configuration;`; source: `src/WalmartApIs/Core/Configuration/RetryOptions.cs`; all members are `required`, so build a full instance or start from `RetryOptions.Default()`):

| Member | Type |
| --- | --- |
| `StatusCodesToRetry` | `IReadOnlyList<HttpStatusCode>` |
| `HttpMethodsToRetry` | `IReadOnlyList<HttpMethod>` |
| `MaxRetries` | `int` |
| `Delay` | `TimeSpan` |
| `Timeout` | `TimeSpan?` |
| `BackOffFactor` | `int` |
| `UseExponentialBackoff` | `bool` |
| `MaxJitter` | `TimeSpan` |
| `OnRetry` | `Action<RetryAttempt>?` |

---

## Error-handling model (read once — applies to every operation)

Operations are **throw-based**. On an error status the SDK throws `ApiException<TError>` (`src/WalmartApIs/Core/Exceptions/ApiException.cs`, namespace `WalmartApIs.Core.Exceptions`) exposing `.Error` of type `TError` beside the `StatusCode`, `Headers` and `ContentType` of the response. There are two cases:

- **Case A — typed error.** `TError` is a generated `…Error : ApiError` class (namespace `WalmartApIs.Errors`) with status-specific `TryGet…(out …)` accessors (each returns `true` when that shape is present) plus the inherited `TryGetRawError(out RawError)` fallback. The operation blocks name the exact `TryGet…` methods and the HTTP status each maps to.
- **Case B — raw error.** `TError` is `RawError` (`src/WalmartApIs/Core/ErrorResponse/RawError.cs`, namespace `WalmartApIs.Core.ErrorResponse`): `StatusCode: HttpStatusCode` · `ReadAsBytes(): ReadOnlyMemory<byte>` · `ReadAsString(): string` · `ReadAsJson<T>(): T?`.

⚠ Each of the three lives in its own namespace. `src/WalmartApIs/Core/` holds several namespaces, so a catch block naming `ApiException<T>`, a typed `{Operation}Error` and `RawError` together needs a `using` for each.

`ApiException<TError>` is one leaf of the `SdkException` family (`src/WalmartApIs/Core/Exceptions/SdkException.cs`): a request that produced no usable response surfaces as `SdkConnectionException` or `SdkTimeoutException`, a body that does not match its declared type as `ResponseDeserializationException`, and a credential that could not be applied as `AuthSchemeException`. Every one of them names the failed call. The full table is in [README → Error Handling](README.md#error-handling).

Core error types (`src/WalmartApIs/Core/ErrorResponse/`) — public members with their **declared types**, verbatim from source:

| Type | Public members | Source |
| --- | --- | --- |
| `ApiError` — abstract base of the 174 typed error classes in `src/WalmartApIs/Errors/` | `TryGetRawError(out RawError error): bool` | `src/WalmartApIs/Core/ErrorResponse/ApiError.cs` |
| `RawError` | `StatusCode: HttpStatusCode` · `ReadAsBytes(): ReadOnlyMemory<byte>` · `ReadAsString(): string` · `ReadAsJson<T>(): T?` | `src/WalmartApIs/Core/ErrorResponse/RawError.cs` |

Typed-error payload shapes (the `out` types in each operation page's error-accessor cells) are ordinary records/unions — no special handling. The operation's **Type sources** table gives the file that declares each one; read field names, declared types, and JSON wire names there, as for any other model.

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
    // Case A — typed error
    if (ex.Error.TryGetAuthorizeError(out var error))
    {
        // Handle 400
    }
    else if (ex.Error.TryGetRawError(out var raw))
    {
        // Any other error status
    }
}
catch (ApiException<RawError> ex)
{
    // Case B — raw error
    // ex.Error.StatusCode, ex.Error.ReadAsString(), ex.Error.ReadAsJson<T>()
}
```

**No-throw (`…Result`) variants: absent across this SDK** — every operation is throw-only. Of **174 operations**, **174 are Case A (typed)** and **0 are Case B (raw)**.

---

## Operations — by controller (30 groups, 174 operations)

Each links to a sub-page with one row per operation: signature, the request record's required members, query-param wire names, return type, error Case A/B, and Case A's typed accessors with their statuses. Each operation also carries a **Type sources** table — every type it names, with the file that declares it — so resolving a body, return, or error payload to its source is a lookup, never a search. `RawError` is excluded there (its members and path are above); an operation with no table names nothing but primitives and `RawError`.

**Each row states what is specific to its operation. Everything below holds for EVERY operation unless that operation's row says otherwise, so a row silent on one of these points is telling you the default here applies — take it and move on rather than opening the source to confirm it.**

| Applies to every operation | Stated where | A row appears only when |
| --- | --- | --- |
| **Throw-only** — no `…Result`/no-throw variant exists anywhere in this SDK | this page, Error-handling model | a no-throw sibling exists (none do at this SDK version) |
| **No pagination** — the operation returns a single response, not a `Pageable` | here | pagination is offered — the block carries a **Pagination** bullet naming the posture (page-, offset-, cursor- or link-based, or the `page`-without-page-size case) |
| **Case B error accessors are always these four** — `StatusCode: HttpStatusCode` · `ReadAsBytes(): ReadOnlyMemory<byte>` · `ReadAsString(): string` · `ReadAsJson<T>(): T?` | the `RawError` row above | never — a `Case B` label always implies exactly these four; Case A rows list their own typed accessors |
| **Server group `Default`** — base URL per Servers & auth below | here | the operation is on another group — its block carries a **Server group** bullet |
| **Inputs are one request record** — an operation that takes input takes a single request record as its first parameter; build it with an object initializer, using the property names in the record's source (its file is in the operation's **Type sources**). A member the row does not list as required is optional or already carries the spec's default | here | never — it always holds |

**The HTTP verb and route live on the operation itself**, in the source file named at the top of its operations page. This map is method-first: the C# method is the interface you call. When something wire-level needs the route — reproducing a raw request, pointing the client at a mock, reading a provider-side log — read it from that file; do not reconstruct it from memory or infer it from the method name.

**The endpoint's behavioural prose lives there too**, as the XML `<remarks>` on the method. Rows here give you the contract — names, types, shapes, errors. Where an operation's *semantics* decide what you must pass — a parameter whose value changes server-side behaviour, an ordering or exclusivity rule between fields — that is what `<remarks>` settles; read it there rather than filling it in from memory.

| Controller (`client.X`) | Ops | Page |
| --- | --- | --- |
| `Authorization` | 3 | [map/operations/Authorization.md](map/operations/Authorization.md) |
| `Catalog` | 2 | [map/operations/Catalog.md](map/operations/Catalog.md) |
| `DataKiosk` | 5 | [map/operations/DataKiosk.md](map/operations/DataKiosk.md) |
| `Disputes` | 1 | [map/operations/Disputes.md](map/operations/Disputes.md) |
| `Feeds` | 5 | [map/operations/Feeds.md](map/operations/Feeds.md) |
| `FinalPayout` | 2 | [map/operations/FinalPayout.md](map/operations/FinalPayout.md) |
| `Finances` | 4 | [map/operations/Finances.md](map/operations/Finances.md) |
| `FulfillmentOutbound` | 7 | [map/operations/FulfillmentOutbound.md](map/operations/FulfillmentOutbound.md) |
| `Inventory` | 4 | [map/operations/Inventory.md](map/operations/Inventory.md) |
| `ListingsItems` | 5 | [map/operations/ListingsItems.md](map/operations/ListingsItems.md) |
| `ListingsRestrictions` | 1 | [map/operations/ListingsRestrictions.md](map/operations/ListingsRestrictions.md) |
| `MerchantFulfillment` | 5 | [map/operations/MerchantFulfillment.md](map/operations/MerchantFulfillment.md) |
| `Orders` | 14 | [map/operations/Orders.md](map/operations/Orders.md) |
| `Payouts` | 5 | [map/operations/Payouts.md](map/operations/Payouts.md) |
| `ProductTypeDefinitions` | 2 | [map/operations/ProductTypeDefinitions.md](map/operations/ProductTypeDefinitions.md) |
| `Reconciliation` | 3 | [map/operations/Reconciliation.md](map/operations/Reconciliation.md) |
| `ReportSchedules` | 4 | [map/operations/ReportSchedules.md](map/operations/ReportSchedules.md) |
| `Reports` | 7 | [map/operations/Reports.md](map/operations/Reports.md) |
| `Sellers` | 2 | [map/operations/Sellers.md](map/operations/Sellers.md) |
| `Settlement` | 3 | [map/operations/Settlement.md](map/operations/Settlement.md) |
| `Uploads` | 1 | [map/operations/Uploads.md](map/operations/Uploads.md) |
| `WfsInventory` | 1 | [map/operations/WfsInventory.md](map/operations/WfsInventory.md) |
| `Messaging` | 11 | [map/operations/Messaging.md](map/operations/Messaging.md) |
| `Notifications` | 9 | [map/operations/Notifications.md](map/operations/Notifications.md) |
| `ProductFees` | 3 | [map/operations/ProductFees.md](map/operations/ProductFees.md) |
| `ProductPricing` | 8 | [map/operations/ProductPricing.md](map/operations/ProductPricing.md) |
| `Sales` | 1 | [map/operations/Sales.md](map/operations/Sales.md) |
| `Shipping` | 9 | [map/operations/Shipping.md](map/operations/Shipping.md) |
| `Solicitations` | 2 | [map/operations/Solicitations.md](map/operations/Solicitations.md) |
| `WfsInbound` | 45 | [map/operations/WfsInbound.md](map/operations/WfsInbound.md) |

---

## Models — where they live, how to build them

**Shapes live only in the source.** Every file under `src/WalmartApIs/Models/`, `src/WalmartApIs/Errors/` and `src/WalmartApIs/Requests/` declares exactly one public type, named after the file, and no two share a name — so a type name *is* its path. Take it from the operation's **Type sources** table, or build it from the kind's directory below. Never grep for a type.

| Group | Count | Directory (file = `<TypeName>.cs`) |
| --- | --- | --- |
| Records (plain `record` data models) | 410 | `src/WalmartApIs/Models/` |
| Enums (`OpenStringEnum<T>` / `OpenIntEnum<T>`) — C# member names + wire values | 119 | `src/WalmartApIs/Models/Enums/` |
| Typed error classes (`: ApiError`, one per Case A operation) | 174 | `src/WalmartApIs/Errors/` |
| Request records (one per operation that takes input; never serialized) | 165 | `src/WalmartApIs/Requests/` — a controller's records sit in a folder named after it (an operation with several tags is filed under the first tag it declares) |

Conventions: records are immutable, `init`-only; `required` properties must be set in the object initializer; `T?` is optional. A field's wire name is its `[JsonPropertyName]` and often differs from the C# name (`AmountInCents` ↔ `amount_in_cents`) — read it off the property, don't derive it. `OneOf`/`AnyOf` unions wrap `Optional<T>` variants — build via static factory or implicit conversion, read via `TryGet…(out …)`; `AllOf` compositions are not unions — every constituent is a `required` property, so set them all, and those constituent properties carry no `[JsonPropertyName]` and have no wire name of their own, because the generated converter flattens each constituent's own fields directly into the one parent JSON object. Enums are **not** C# enums — use the static members, whose names are PascalCase even when the wire value isn't (`CollectionMethod.Invoice`, not `.invoice`); there is no public factory, so resolve a raw value with `TryGetKnownValue` and branch with the generated `Match`, whose `otherwise` arm receives any value the SDK does not declare.

Namespaces by content type (add `using` accordingly):

| Contents | Namespace |
| --- | --- |
| Client & options (root) | `WalmartApIs` |
| Operation controllers (`src/WalmartApIs/Api/`) | `WalmartApIs.Api` |
| Records (`src/WalmartApIs/Models/`) | `WalmartApIs.Models` |
| Enums (`src/WalmartApIs/Models/Enums/`) | `WalmartApIs.Models.Enums` |
| Error classes (`src/WalmartApIs/Errors/`) | `WalmartApIs.Errors` |
| Request records (`src/WalmartApIs/Requests/`) | `WalmartApIs.Requests` — plus `.<Controller>` for a controller's records (an operation with several tags is filed under the first tag it declares) |

---

## Servers & auth

**OAuth2 (authorization code).** Set `options.SellerAuthAuthorizationCode` with client id, redirect URI and a `PromptForAuthorizationCode` callback; authorization at `https://marketplace.walmart.com/seller/auth/v4/authorize`, tokens from `https://marketplace.walmart.com/seller/auth/v4/token`. `options.SellerAuthAuthorizationCodeTokenStrategy` overrides how tokens are acquired and cached; leave it unset for the SDK's own handling.

**OAuth2 (client credentials).** Set `options.SellerAuthClientCredentials` with your client id and secret; tokens are fetched from `https://marketplace.walmart.com/seller/auth/v4/token`. `options.SellerAuthClientCredentialsTokenStrategy` overrides how tokens are acquired and cached; leave it unset for the SDK's own handling.

**Basic auth.** Set `options.BasicClientAuth = new BasicAuthCredentials { Username = …, Password = … }`. HTTP Basic with base64(client_id:client_secret). client_secret_post (body) also accepted; public clients send no secret.

**OAuth2 (client credentials).** Set `options.WalletAuth` with your client id and secret; tokens are fetched from `https://marketplace.walmart.com/seller/v1/auth/token`. `options.WalletAuthTokenStrategy` overrides how tokens are acquired and cached; leave it unset for the SDK's own handling.

Operation blocks name their credential in an **Auth** bullet; an operation whose spec declares no scheme carries no such bullet.

- `AND` — every credential listed must be set for the call to be fully authenticated.
- `OR` — the first credential you set that applies successfully is the one sent, in the order listed.

A credential you never set is skipped rather than throwing, and the request is sent anyway — so an authentication failure can mean no credential was sent rather than a bad one. Under `OR`, if every credential you did set fails to apply, `AuthSchemeException` is thrown.

**Environments.** `options.Environment` selects the target environment (`src/WalmartApIs/Servers/ServerEnvironment.cs`):

| Environment | Value | Hosting |
| --- | --- | --- |
| `ServerEnvironment.Production` *(default)* | `production` | Production |
| `ServerEnvironment.Environment2` | `environment2` | Sandbox |
| `ServerEnvironment.Environment3` | `environment3` | mock |

**2 server groups.** Base-URL templates and override points (`options.Server.…`):

| Group | `Production` base URL | `Environment2` base URL | `Environment3` base URL | Override point |
| --- | --- | --- | --- | --- |
| `Default` | `https://marketplace.walmart.com/seller` | `https://sandbox.marketplace.walmart.com/seller` | `https://walmart-apis-mock-server.onrender.com/seller` | `options.Server.Default.Production.BaseUrl` (and the other environments) |
| `Default1` | `https://marketplace.walmart.com/seller/v1` | `https://sandbox.marketplace.walmart.com/seller/v1` | `https://walmart-apis-mock-server.onrender.com/seller/v1` | `options.Server.Default1.Production.BaseUrl` (and the other environments) |

Retry/resilience is configurable via `options.Retry` (`RetryOptions`, backed by Polly).

