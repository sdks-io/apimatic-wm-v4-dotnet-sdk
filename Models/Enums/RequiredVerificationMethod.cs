using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

/// <summary>
/// How the buyer must prove identity at delivery. NONE means no
/// verification is required (NOT_REGULATED orders always return
/// NONE).
/// </summary>
[JsonConverter(typeof(StringEnumConverter<RequiredVerificationMethod>))]
public sealed record RequiredVerificationMethod : StringEnum<RequiredVerificationMethod>
{
    private RequiredVerificationMethod(string value) : base(value)
    {
    }

    public static readonly RequiredVerificationMethod None = new("NONE");

    public static readonly RequiredVerificationMethod DriversLicense = new("DRIVERS_LICENSE");

    public static readonly RequiredVerificationMethod Passport = new("PASSPORT");

    public static readonly RequiredVerificationMethod GovernmentId = new("GOVERNMENT_ID");

    public static RequiredVerificationMethod FromValue(string value) => FromValueCore(value);
}
