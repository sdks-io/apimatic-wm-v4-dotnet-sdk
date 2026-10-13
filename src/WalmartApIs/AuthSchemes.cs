using WalmartApIs.Core;
using WalmartApIs.Core.Authentication;
using WalmartApIs.Core.Authentication.Basic;
using WalmartApIs.Core.Authentication.OAuth2;
using WalmartApIs.Core.Authentication.OAuth2.AuthorizationCode;
using WalmartApIs.Core.Authentication.OAuth2.ClientCredentials;

namespace WalmartApIs;

internal sealed class AuthSchemes
{
    public IAuthScheme BasicClientAuth { get; }
    public IAuthScheme SellerAuthClientCredentials { get; }
    public IAuthScheme WalletAuth { get; }
    public IAuthScheme SellerAuthAuthorizationCode { get; }

    public AuthSchemes(WalmartApIsClientOptions options, Server server, RawClient rawClient, UriFactory urlFactory)
    {
        BasicClientAuth = BasicAuthScheme.Create(options.BasicClientAuth);
        SellerAuthClientCredentials =
            OAuth2Scheme<OAuth2ClientCredentials>.Create(
                options.SellerAuthClientCredentials,
                options.SellerAuthClientCredentialsTokenStrategy ??
                    OAuth2ClientCredentialsStrategy.ForBasicAuthRequest(server.Default("/auth/v4/token"), rawClient),
                options.TimeProvider);
        WalletAuth =
            OAuth2Scheme<OAuth2ClientCredentials>.Create(
                options.WalletAuth,
                options.WalletAuthTokenStrategy ??
                    OAuth2ClientCredentialsStrategy.ForBasicAuthRequest(server.Default1("/auth/token"), rawClient),
                options.TimeProvider);
        SellerAuthAuthorizationCode =
            OAuth2RefreshableScheme<OAuth2AuthorizationCodeCredentials>.Create(
                options.SellerAuthAuthorizationCode,
                options.SellerAuthAuthorizationCodeTokenStrategy ??
                    OAuth2AuthorizationCodeStrategy.ForBasicAuthRequest(
                        server.Default("/auth/v4/authorize"),
                        server.Default("/auth/v4/token"),
                        rawClient,
                        urlFactory),
                options.TimeProvider);
    }
}
