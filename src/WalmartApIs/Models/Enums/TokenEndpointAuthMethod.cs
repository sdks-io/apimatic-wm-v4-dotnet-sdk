using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

/// <summary>
/// <c>none</c> for public clients (PKCE), <c>client_secret_post</c>/<c>client_secret_basic</c> for confidential.
/// </summary>
[JsonConverter(typeof(StringEnumConverter<TokenEndpointAuthMethod>))]
public sealed record TokenEndpointAuthMethod : OpenStringEnum<TokenEndpointAuthMethod>
{
    private TokenEndpointAuthMethod(string value) : base(value)
    {
    }

    public static readonly TokenEndpointAuthMethod None = new("none");

    public static readonly TokenEndpointAuthMethod ClientSecretPost = new("client_secret_post");

    public static readonly TokenEndpointAuthMethod ClientSecretBasic = new("client_secret_basic");

    public TResult Match<TResult>(Func<TResult> onNone,
        Func<TResult> onClientSecretPost,
        Func<TResult> onClientSecretBasic,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == None => onNone(),
            _ when this == ClientSecretPost => onClientSecretPost(),
            _ when this == ClientSecretBasic => onClientSecretBasic(),
            _ => otherwise(Value)
        };

    public void Match(Action onNone, Action onClientSecretPost, Action onClientSecretBasic, Action<string> otherwise)
    {
        if (this == None) onNone();
        else if (this == ClientSecretPost) onClientSecretPost();
        else if (this == ClientSecretBasic) onClientSecretBasic();
        else otherwise(Value);
    }
}
