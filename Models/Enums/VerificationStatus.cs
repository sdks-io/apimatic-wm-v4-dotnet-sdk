using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

/// <summary>
/// Outcome of the doorstep / pickup identity verification.
/// </summary>
[JsonConverter(typeof(StringEnumConverter<VerificationStatus>))]
public sealed record VerificationStatus : StringEnum<VerificationStatus>
{
    private VerificationStatus(string value) : base(value)
    {
    }

    public static readonly VerificationStatus Approved = new("APPROVED");

    public static readonly VerificationStatus Rejected = new("REJECTED");

    public static VerificationStatus FromValue(string value) => FromValueCore(value);
}
