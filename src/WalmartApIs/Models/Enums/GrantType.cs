using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

/// <summary>
/// The OAuth grant type.
/// </summary>
[JsonConverter(typeof(StringEnumConverter<GrantType>))]
public sealed record GrantType : OpenStringEnum<GrantType>
{
    private GrantType(string value) : base(value)
    {
    }

    public static readonly GrantType ClientCredentials = new("client_credentials");

    public static readonly GrantType AuthorizationCode = new("authorization_code");

    public static readonly GrantType RefreshToken = new("refresh_token");

    public TResult Match<TResult>(Func<TResult> onClientCredentials,
        Func<TResult> onAuthorizationCode,
        Func<TResult> onRefreshToken,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == ClientCredentials => onClientCredentials(),
            _ when this == AuthorizationCode => onAuthorizationCode(),
            _ when this == RefreshToken => onRefreshToken(),
            _ => otherwise(Value)
        };

    public void Match(Action onClientCredentials,
        Action onAuthorizationCode,
        Action onRefreshToken,
        Action<string> otherwise)
    {
        if (this == ClientCredentials) onClientCredentials();
        else if (this == AuthorizationCode) onAuthorizationCode();
        else if (this == RefreshToken) onRefreshToken();
        else otherwise(Value);
    }
}
