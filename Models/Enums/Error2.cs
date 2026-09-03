using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

/// <summary>
/// Machine-readable error code.
/// </summary>
[JsonConverter(typeof(StringEnumConverter<Error2>))]
public sealed record Error2 : StringEnum<Error2>
{
    private Error2(string value) : base(value)
    {
    }

    public static readonly Error2 InvalidRedirectUri = new("invalid_redirect_uri");

    public static readonly Error2 InvalidClientMetadata = new("invalid_client_metadata");

    public static readonly Error2 InvalidSoftwareStatement = new("invalid_software_statement");

    public static readonly Error2 UnapprovedSoftwareStatement = new("unapproved_software_statement");

    public static Error2 FromValue(string value) => FromValueCore(value);
}
