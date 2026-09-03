using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using WalmartApIs.Core;
using WalmartApIs.Core.Exceptions;
using WalmartApIs.Core.Models;
using WalmartApIs.Core.Request;
using WalmartApIs.Core.Response;
using WalmartApIs.Errors;
using WalmartApIs.Models;
using WalmartApIs.Models.Enums;

namespace WalmartApIs.Api;

/// <summary>
/// OAuth 2.0 / 2.1 token issuance, delegated consent, and client registration.
/// </summary>
public sealed class Authorization
{
    private readonly RawClient _rawClient;
    private readonly Server _server;
    private readonly AuthSchemes _auth;

    internal Authorization(RawClient rawClient, Server server, AuthSchemes auth)
    {
        _rawClient = rawClient;
        _server = server;
        _auth = auth;
    }

    /// <summary>
    /// Authorization endpoint (delegated consent)
    /// </summary>
    /// <param name="responseType">Must be <c>code</c>.</param>
    /// <param name="clientId">The registered client identifier.</param>
    /// <param name="redirectUri">Callback URI; must exactly match a registered value.</param>
    /// <param name="scope">Space-delimited scopes. Include <c>offline_access</c> to receive a refresh token.</param>
    /// <param name="state">Opaque CSRF token; echoed back unchanged.</param>
    /// <param name="codeChallenge">PKCE challenge — base64url(SHA-256(code_verifier)).</param>
    /// <param name="codeChallengeMethod">Must be <c>S256</c>.</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="AuthorizeApiError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Browser endpoint for the authorization-code grant (RFC 6749 §3.1). The
    /// Solution Provider redirects the seller here; the seller authenticates and
    /// consents at Walmart IAM, and the response redirects to <c>redirect_uri</c> with a
    /// single-use <c>code</c>.
    /// <para>
    /// - <b>PKCE required</b> — <c>code_challenge</c> + <c>code_challenge_method=S256</c>
    ///   (RFC 7636). <c>plain</c> is not accepted.
    /// - <b>Exact</b> <c>redirect_uri</c> match against a value registered for the client.
    /// - <c>state</c> required; echoed back verbatim (CSRF).
    /// - The success and error redirects (performed by IAM) carry <c>iss</c> (RFC 9207);
    ///   clients MUST validate it.
    /// </para>
    /// <para>
    /// <b>Error handling.</b> For a valid request, this endpoint <c>302</c>-redirects to the
    /// Walmart IAM consent URL; IAM then drives consent and performs the RFC 6749
    /// §4.1.2.1 redirect back to the client's <c>redirect_uri</c> (success or error),
    /// because IAM is the party that can verify the <c>redirect_uri</c> is registered.
    /// For request-level errors that <c>the Authorization API</c> itself detects
    /// (missing/invalid <c>client_id</c>/<c>redirect_uri</c>, <c>response_type</c> != <c>code</c>,
    /// <c>code_challenge_method</c> != <c>S256</c>), it returns a JSON <c>400</c> (<c>AuthorizeError</c>).
    /// It deliberately does <b>not</b> redirect these errors to the supplied
    /// <c>redirect_uri</c>: the proxy has no client registry, so self-redirecting to an
    /// unverified URI would be an open redirect.
    /// </para>
    /// <para>
    /// &gt; <b>Upstream status (, pending):</b> <c>iss</c> emission, exact-redirect
    /// &gt; enforcement, and server-side rejection of <c>code_challenge_method=plain</c> are
    /// &gt; IAM / app-store responsibilities not yet fully in place. the Authorization API
    /// &gt; enforces the request-side invariants it can and redirects valid requests to
    /// &gt; IAM; the full guarantee lands when those upstream changes ship.
    /// </para>
    /// </remarks>
    public Task Authorize(ResponseType1 responseType,
        string clientId,
        string redirectUri,
        string scope,
        string state,
        string codeChallenge,
        CodeChallengeMethod codeChallengeMethod,
        RequestOptions? requestOptions = null,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default("/auth/v4/authorize"),
            [],
            [new Param("response_type", responseType),
                new Param("client_id", clientId),
                new Param("redirect_uri", redirectUri),
                new Param("scope", scope),
                new Param("state", state),
                new Param("code_challenge", codeChallenge),
                new Param("code_challenge_method", codeChallengeMethod)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            VoidResponse.Instance,
            AuthorizeApiErrorResponse.Instance,
            [],
            requestOptions,
            ct);

    /// <summary>
    /// Issue an access token (client_credentials, authorization_code, or refresh_token)
    /// </summary>
    /// <param name="grantType"></param>
    /// <param name="clientId"></param>
    /// <param name="clientSecret"></param>
    /// <param name="code"></param>
    /// <param name="codeVerifier"></param>
    /// <param name="refreshToken"></param>
    /// <param name="redirectUri"></param>
    /// <param name="scope"></param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="TokenResponse"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="CreateTokenError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Exchanges a grant for an OAuth access token. Supported <c>grant_type</c> values:
    /// <para>
    /// | grant_type | Flow | Required (besides grant_type) |
    /// |----------------------|------------------|---------------------------------|
    /// | <c>client_credentials</c> | seller-direct | client auth (see below) |
    /// | <c>authorization_code</c> | delegated | <c>code</c>, <c>code_verifier</c> (PKCE) |
    /// | <c>refresh_token</c> | delegated | <c>refresh_token</c> |
    /// </para>
    /// <para>
    /// <b>Client authentication:</b> credentials in the form body (<c>client_secret_post</c>)
    /// — <c>client_id</c> + <c>client_secret</c>. HTTP Basic is also accepted. **Public
    /// clients** (Solution-Provider apps registered <c>token_endpoint_auth_method: none</c>)
    /// send no secret on the delegated grants; PKCE protects the code.
    /// </para>
    /// <para>
    /// <b><c>client_credentials</c>:</b> issues <b>no</b> refresh token (re-mint on expiry).
    /// <b><c>scope</c> is decorative here</b> — accepted for compatibility but <b>not honored</b>;
    /// access is governed by the scopes provisioned per client in IAM ; there
    /// is no down-scoping and the response does not echo <c>scope</c>. (Verified: <c>/v3/token</c>
    /// ignores any <c>scope=</c> value.)
    /// </para>
    /// <para>
    /// <b><c>authorization_code</c>:</b> <c>redirect_uri</c> is accepted for OAuth 2.0 back-compat
    /// but not required in 2.1 (PKCE covers injection).
    /// </para>
    /// <para>
    /// <b><c>refresh_token</c>:</b> the response includes a <b>rotated</b> <c>refresh_token</c> — the
    /// presented token is invalidated (OAuth 2.1 §4.3.1; IAM rotates today, ~1-year
    /// TTL). A requested <c>scope</c> MUST NOT exceed the originally granted scope.
    /// </para>
    /// <para>
    /// <b>Token:</b> <c>Bearer</c> (RFC 6750), sent downstream as `Authorization: Bearer
    /// &lt;token&gt;<c> — <b>not</b> </c>WM_SEC.ACCESS_TOKEN`.
    /// </para>
    /// <para>
    /// <b>Implemented by <c>the Authorization API</c> as a stateless proxy to Walmart IAM .</b>
    /// </para>
    /// </remarks>
    public Task<TokenResponse> CreateToken(GrantType grantType,
        string? clientId,
        string? clientSecret,
        string? code,
        string? codeVerifier,
        string? refreshToken,
        string? redirectUri,
        string? scope,
        RequestOptions? requestOptions = null,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default("/auth/v4/token"),
            [],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Post,
            FormUrlEncodedRequest.Create([new Param("grant_type", grantType),
                    new Param("client_id", clientId),
                    new Param("client_secret", clientSecret),
                    new Param("code", code),
                    new Param("code_verifier", codeVerifier),
                    new Param("refresh_token", refreshToken),
                    new Param("redirect_uri", redirectUri),
                    new Param("scope", scope)]),
            JsonResponse.Create<TokenResponse>(),
            CreateTokenErrorResponse.Instance,
            [_auth.BasicClientAuth],
            requestOptions,
            ct);

    /// <summary>
    /// Dynamic Client Registration (RFC 7591)
    /// </summary>
    /// <param name="body"></param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="ClientRegistrationResponse"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="RegisterClientError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Registers a Solution Provider client and returns its <c>client_id</c> (RFC
    /// 7591). Lets Solution Providers onboard without manual registration.
    /// <para>
    /// Public clients set <c>token_endpoint_auth_method: none</c> (no secret; PKCE
    /// required). Confidential clients receive a <c>client_secret</c>. <c>redirect_uris</c>
    /// are validated and later enforced by exact match at <c>/auth/v4/authorize</c>.
    /// </para>
    /// <para>
    /// Proxied to Walmart IAM's registration endpoint (/). RFC 7592
    /// registration management (read/update/delete via a
    /// <c>registration_access_token</c>) is not offered in this version.
    /// </para>
    /// </remarks>
    public Task<ClientRegistrationResponse> RegisterClient(ClientRegistrationRequest body,
        RequestOptions? requestOptions = null,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default("/auth/v4/register"),
            [],
            [],
            [new HeaderParam("Idempotency-Key", Guid.NewGuid())],
            HttpMethod.Post,
            JsonRequest.Create(body),
            JsonResponse.Create<ClientRegistrationResponse>(),
            RegisterClientErrorResponse.Instance,
            [],
            requestOptions,
            ct);
}
