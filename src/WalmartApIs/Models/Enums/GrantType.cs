using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

/// <summary>
/// Type of grant requested. &lt;br /&gt; <b>Available grant types:</b> authorization_code, refresh_token and client_credentials
/// </summary>
[JsonConverter(typeof(StringEnumConverter<GrantType>))]
public sealed record GrantType : OpenStringEnum<GrantType>
{
    private GrantType(string value) : base(value)
    {
    }

    public static readonly GrantType AuthorizationCode = new("authorization_code");

    public static readonly GrantType RefreshToken = new("refresh_token");

    public static readonly GrantType ClientCredentials = new("client_credentials");

    public TResult Match<TResult>(Func<TResult> onAuthorizationCode,
        Func<TResult> onRefreshToken,
        Func<TResult> onClientCredentials,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == AuthorizationCode => onAuthorizationCode(),
            _ when this == RefreshToken => onRefreshToken(),
            _ when this == ClientCredentials => onClientCredentials(),
            _ => otherwise(Value)
        };

    public void Match(Action onAuthorizationCode,
        Action onRefreshToken,
        Action onClientCredentials,
        Action<string> otherwise)
    {
        if (this == AuthorizationCode) onAuthorizationCode();
        else if (this == RefreshToken) onRefreshToken();
        else if (this == ClientCredentials) onClientCredentials();
        else otherwise(Value);
    }
}
