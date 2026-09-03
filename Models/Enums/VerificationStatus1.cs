using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<VerificationStatus1>))]
public sealed record VerificationStatus1 : StringEnum<VerificationStatus1>
{
    private VerificationStatus1(string value) : base(value)
    {
    }

    public static readonly VerificationStatus1 Approved = new("APPROVED");

    public static readonly VerificationStatus1 Rejected = new("REJECTED");

    public static VerificationStatus1 FromValue(string value) => FromValueCore(value);
}
