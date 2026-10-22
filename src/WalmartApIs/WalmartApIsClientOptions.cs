using System;
using System.Collections.Generic;
using WalmartApIs.Core.Authentication.Basic;
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
    public BasicAuthCredentials? BasicAuth { get; set; }
    /// <summary>
    /// Use the access token obtained from the Token API.
    /// Include it in the WM_SEC.ACCESS_TOKEN header.
    /// </summary>
    public string? BearerAuth { get; set; }
    /// <summary>
    /// Access token required for authenticating API requests.
    /// <para>
    /// To obtain a token, call <c>POST https://marketplace.walmartapis.com/v3/token</c> with your client ID and client secret using the client credentials grant type. Refer to the <see href="https://developer.walmart.com/us-marketplace/docs/get-an-access-token">Token API documentation</see> for details.
    /// </para>
    /// <para>
    /// Pass the resulting token in the <c>WM_SEC.ACCESS_TOKEN</c> header with every API request., Access token required for authenticating API requests.
    /// </para>
    /// <para>
    /// To obtain a token, call <c>POST https://marketplace.walmartapis.com/v3/token</c> with your client ID and client secret using the OAuth 2.0 client credentials grant type. Refer to the <see href="https://developer.walmart.com/us-marketplace/docs/get-an-access-token">Token API documentation</see> for details.
    /// </para>
    /// <para>
    /// Pass the resulting token in the <c>WM_SEC.ACCESS_TOKEN</c> header with every API request., Access token obtained from the Token API. This is required for authenticating requests to Walmart Marketplace APIs., Access token required for authenticating API requests.
    /// </para>
    /// <para>
    /// To obtain a token, call <c>POST https://marketplace.walmartapis.com/v3/token</c> with your client ID and client secret using the client credentials grant type. Refer to the <see href="https://developer.walmart.com/us-marketplace/docs/get-an-access-token">Token API documentation</see> for details.
    /// </para>
    /// <para>
    /// Pass the resulting token in the <c>WM_SEC.ACCESS_TOKEN</c> header with every API request., Access token from POST /v3/token (client_credentials grant).
    /// </para>
    /// </summary>
    public string? AccessToken { get; set; }
}
