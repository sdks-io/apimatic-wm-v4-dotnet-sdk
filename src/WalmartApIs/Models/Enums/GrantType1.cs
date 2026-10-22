using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

/// <summary>
/// Type of grant requested. &lt;br /&gt; <b>Available grant types:</b> authorization_code, refresh_token and client_credentials
/// <para>
/// &lt;strong style="color: green;"&gt;<b>Market availability: Global</b>&lt;/strong&gt;
/// </para>
/// </summary>
[JsonConverter(typeof(StringEnumConverter<GrantType1>))]
public sealed record GrantType1 : OpenStringEnum<GrantType1>
{
    private GrantType1(string value) : base(value)
    {
    }

    public static readonly GrantType1 AuthorizationCode = new("authorization_code");

    public static readonly GrantType1 RefreshToken = new("refresh_token");

    public static readonly GrantType1 ClientCredentials = new("client_credentials");

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
