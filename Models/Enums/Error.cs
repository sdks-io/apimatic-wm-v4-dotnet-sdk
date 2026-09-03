using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

/// <summary>
/// Machine-readable error code.
/// </summary>
[JsonConverter(typeof(StringEnumConverter<Error>))]
public sealed record Error : StringEnum<Error>
{
    private Error(string value) : base(value)
    {
    }

    public static readonly Error InvalidRequest = new("invalid_request");

    public static readonly Error InvalidClient = new("invalid_client");

    public static readonly Error InvalidGrant = new("invalid_grant");

    public static readonly Error UnauthorizedClient = new("unauthorized_client");

    public static readonly Error UnsupportedGrantType = new("unsupported_grant_type");

    public static readonly Error InvalidScope = new("invalid_scope");

    public static Error FromValue(string value) => FromValueCore(value);
}
