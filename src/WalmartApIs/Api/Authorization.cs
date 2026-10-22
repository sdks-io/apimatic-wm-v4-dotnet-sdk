using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using WalmartApIs.Core;
using WalmartApIs.Core.ErrorResponse;
using WalmartApIs.Core.Exceptions;
using WalmartApIs.Core.Models;
using WalmartApIs.Core.Request;
using WalmartApIs.Core.Response;
using WalmartApIs.Errors;
using WalmartApIs.Models;
using WalmartApIs.Requests.Authorization;

namespace WalmartApIs.Api;

public sealed class Authorization
{
    private readonly RawClient _rawClient;
    private readonly Server _server;

    internal Authorization(RawClient rawClient, Server server)
    {
        _rawClient = rawClient;
        _server = server;
    }

    /// <summary>
    /// Token Detail
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="TokenDetailResponse"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="RawError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// This process retrieves the access permissions granted by sellers to applications in the context of OAuth 2.0. The scope encompasses various API categories, each with its respective access levels, for example Reports: View Only, Item: Full Access, etc.
    /// &lt;br&gt;&lt;b style='color:green;'&gt;Market availability: Global&lt;/b&gt;
    /// </remarks>
    public Task<TokenDetailResponse> GetTokenDetail(GetTokenDetailRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/v3/token/detail"),
            [],
            [],
            [
                new HeaderParam("WM_SEC.ACCESS_TOKEN", request.WmSecAccessToken),
                new HeaderParam("WM_MARKET", request.WmMarket),
                new HeaderParam("Content-Type", request.ContentType),
                new HeaderParam("WM_QOS.CORRELATION_ID", request.WmQosCorrelationId),
                new HeaderParam("WM_SVC.NAME", request.WmSvcName),
                new HeaderParam("WM_CONSUMER.CHANNEL.TYPE", request.WmConsumerChannelType),
            ],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<TokenDetailResponse>(),
            RawErrorResponse.Instance,
            [],
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Token API
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="OAuthTokenModel"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="TokenApiError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// &lt;p&gt;This endpoint issues access tokens required for authenticating API requests. It supports multiple OAuth 2.0 grant types to accommodate various integration scenarios.&lt;/p&gt; &lt;b style='color:green;'&gt;Market availability: Global&lt;/b&gt;&lt;br/&gt;&lt;h3&gt;Supported Grant Types&lt;/h3&gt;&lt;table&gt;&lt;tr&gt;&lt;th&gt;Grant Type&lt;/th&gt;&lt;th&gt;Description&lt;/th&gt;&lt;th&gt;How to get the credentials&lt;/th&gt;&lt;/tr&gt;&lt;tr&gt;&lt;td&gt;authorization_code&lt;/td&gt;&lt;td&gt;Exchanges an authorization code for an access token.&lt;/td&gt;&lt;td&gt;Used in app integration only via the OAuth consent screen. This is applicable to the &lt;strong&gt;US market only&lt;/strong&gt;. Refer to &lt;a href=/global-marketplace/docs/oauth-20-authorization&gt;OAuth 2.0 authorization&lt;/a&gt; for more details.&lt;/td&gt;&lt;/tr&gt;&lt;tr&gt;&lt;td&gt;client_credentials&lt;/td&gt;&lt;td&gt;Issues a token using client ID and secret.&lt;/td&gt;&lt;td&gt;For &lt;strong&gt;sellers&lt;/strong&gt;: Obtain client_id and client_secret from the &lt;strong&gt;Developer Portal&lt;/strong&gt;.&lt;br/&gt;For &lt;strong&gt;solution providers&lt;/strong&gt;: Obtain credentials from sellers via &lt;a href=/global-marketplace/docs/delegated-access-auth&gt;Delegated Access authorization&lt;/a&gt;.&lt;/td&gt;&lt;/tr&gt;&lt;tr&gt;&lt;td&gt;refresh_token&lt;/td&gt;&lt;td&gt;Issues a new access token using a refresh token.&lt;/td&gt;&lt;td&gt;Provided during the authorization_code flow. This is applicable to the &lt;strong&gt;US market only&lt;/strong&gt;. Refer to &lt;a href=/global-marketplace/docs/oauth-20-authorization&gt;OAuth 2.0 authorization&lt;/a&gt; for more details.&lt;/td&gt;&lt;/tr&gt;&lt;/table&gt;&lt;br/&gt;&lt;b&gt;Note:&lt;br/&gt;&lt;/b&gt; Use authorization_code and refresh_token &lt;b&gt;only for app-based integrations.&lt;/b&gt; These grant types are currently &lt;b&gt;supported only in the US market&lt;/b&gt;.&lt;br/&gt;&lt;br/&gt;&lt;h3&gt;Token Lifetimes&lt;/h3&gt;&lt;table&gt;&lt;tr&gt;&lt;th&gt;Token Type&lt;/th&gt;&lt;th&gt;Duration&lt;/th&gt;&lt;/tr&gt;&lt;tr&gt;&lt;td&gt;Access Token&lt;/td&gt;&lt;td&gt;15 minutes &lt;i&gt;(900 seconds)&lt;/i&gt;&lt;/td&gt;&lt;/tr&gt;&lt;tr&gt;&lt;td&gt;Refresh Token&lt;/td&gt;&lt;td&gt;1 year &lt;i&gt;(365 days)&lt;/i&gt;&lt;/td&gt;&lt;/tr&gt;&lt;/table&gt;
    /// </remarks>
    public Task<OAuthTokenModel> TokenApi(TokenApiRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default("/v3/token"),
            [],
            [],
            [
                new HeaderParam("WM_MARKET", request.WmMarket),
                new HeaderParam("Authorization", request.Authorization),
                new HeaderParam("WM_QOS.CORRELATION_ID", request.WmQosCorrelationId),
                new HeaderParam("WM_SVC.NAME", request.WmSvcName),
                new HeaderParam("WM_PARTNER.ID", request.WmPartnerId),
                new HeaderParam("WM_CONSUMER.CHANNEL.TYPE", request.WmConsumerChannelType),
                new HeaderParam("Idempotency-Key", Guid.NewGuid()),
            ],
            HttpMethod.Post,
            FormUrlEncodedRequest.Create(
                new Param("grant_type", request.GrantType),
                new Param("code", request.Code),
                new Param("redirect_uri", request.RedirectUri),
                new Param("refresh_token", request.RefreshToken)),
            JsonResponse.Create<OAuthTokenModel>(),
            TokenApiError.Response,
            [],
            requestOptions,
            cancellationToken);
}
