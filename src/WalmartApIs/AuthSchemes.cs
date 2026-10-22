using WalmartApIs.Core.Authentication;
using WalmartApIs.Core.Authentication.ApiKey;
using WalmartApIs.Core.Authentication.Basic;
using WalmartApIs.Core.Authentication.Bearer;

namespace WalmartApIs;

internal sealed class AuthSchemes
{
    public IAuthScheme BasicAuth { get; }
    public IAuthScheme AccessToken { get; }
    public IAuthScheme BearerAuth { get; }

    public AuthSchemes(WalmartApIsClientOptions options)
    {
        BasicAuth = BasicAuthScheme.Create(options.BasicAuth);
        AccessToken = ApiKeyHeaderScheme.Create("WM_SEC.ACCESS_TOKEN", options.AccessToken);
        BearerAuth = BearerAuthScheme.Create(options.BearerAuth);
    }
}
