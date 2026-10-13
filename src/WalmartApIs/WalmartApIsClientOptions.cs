using System;
using System.Collections.Generic;
using WalmartApIs.Core.Authentication.Basic;
using WalmartApIs.Core.Authentication.OAuth2;
using WalmartApIs.Core.Authentication.OAuth2.AuthorizationCode;
using WalmartApIs.Core.Authentication.OAuth2.ClientCredentials;
using WalmartApIs.Core.Configuration;
using WalmartApIs.Core.Hooks;
using WalmartApIs.Servers;

namespace WalmartApIs;

public class WalmartApIsClientOptions
{
    public ServerEnvironment Environment { get; set; } = ServerEnvironment.Default();
    public RetryOptions Retry { get; set; } = RetryOptions.Default();
    public LoggingOptions Logging { get; set; } = new();
    public TimeProvider TimeProvider { get; set; } = TimeProvider.System;
    public ServerOptions Server { get; set; } = new();
    /// <summary>
    /// Maximum time to wait for the next frame of a streaming (SSE) response before the stream is
    /// torn down with a timeout. Bounds only the wait for the server between frames, never the
    /// caller's own processing time. Set to null to wait indefinitely.
    /// </summary>
    public TimeSpan? StreamReadTimeout { get; set; } = TimeSpan.FromSeconds(60);
    public IReadOnlyList<SdkHook> Hooks { get; set; } = [];
    public OAuth2AuthorizationCodeCredentials? SellerAuthAuthorizationCode { get; set; }
    public IOAuth2RefreshableTokenStrategy<OAuth2AuthorizationCodeCredentials>? SellerAuthAuthorizationCodeTokenStrategy { get; set; }
    public OAuth2ClientCredentials? SellerAuthClientCredentials { get; set; }
    public IOAuth2TokenStrategy<OAuth2ClientCredentials>? SellerAuthClientCredentialsTokenStrategy { get; set; }
    /// <summary>
    /// HTTP Basic with base64(client_id:client_secret). client_secret_post (body) also accepted; public clients send no secret.
    /// </summary>
    public BasicAuthCredentials? BasicClientAuth { get; set; }
    public OAuth2ClientCredentials? WalletAuth { get; set; }
    public IOAuth2TokenStrategy<OAuth2ClientCredentials>? WalletAuthTokenStrategy { get; set; }
}
