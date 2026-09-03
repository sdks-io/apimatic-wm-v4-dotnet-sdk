using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<GrantType1>))]
public sealed record GrantType1 : StringEnum<GrantType1>
{
    private GrantType1(string value) : base(value)
    {
    }

    public static readonly GrantType1 AuthorizationCode = new("authorization_code");

    public static readonly GrantType1 RefreshToken = new("refresh_token");

    public static GrantType1 FromValue(string value) => FromValueCore(value);
}
