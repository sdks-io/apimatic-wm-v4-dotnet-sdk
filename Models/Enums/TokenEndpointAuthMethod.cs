using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

/// <summary>
/// <c>none</c> for public clients (PKCE), <c>client_secret_post</c>/<c>client_secret_basic</c> for confidential.
/// </summary>
[JsonConverter(typeof(StringEnumConverter<TokenEndpointAuthMethod>))]
public sealed record TokenEndpointAuthMethod : StringEnum<TokenEndpointAuthMethod>
{
    private TokenEndpointAuthMethod(string value) : base(value)
    {
    }

    public static readonly TokenEndpointAuthMethod None = new("none");

    public static readonly TokenEndpointAuthMethod ClientSecretPost = new("client_secret_post");

    public static readonly TokenEndpointAuthMethod ClientSecretBasic = new("client_secret_basic");

    public static TokenEndpointAuthMethod FromValue(string value) => FromValueCore(value);
}
