using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

/// <summary>
/// Machine-readable error code.
/// </summary>
[JsonConverter(typeof(StringEnumConverter<Error1>))]
public sealed record Error1 : StringEnum<Error1>
{
    private Error1(string value) : base(value)
    {
    }

    public static readonly Error1 InvalidRequest = new("invalid_request");

    public static readonly Error1 UnauthorizedClient = new("unauthorized_client");

    public static readonly Error1 AccessDenied = new("access_denied");

    public static readonly Error1 UnsupportedResponseType = new("unsupported_response_type");

    public static readonly Error1 InvalidScope = new("invalid_scope");

    public static readonly Error1 ServerError = new("server_error");

    public static readonly Error1 TemporarilyUnavailable = new("temporarily_unavailable");

    public static Error1 FromValue(string value) => FromValueCore(value);
}
