using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<ReasonCode>))]
public sealed record ReasonCode : StringEnum<ReasonCode>
{
    private ReasonCode(string value) : base(value)
    {
    }

    public static readonly ReasonCode ApprovalRequired = new("APPROVAL_REQUIRED");

    public static readonly ReasonCode AsinNotApplicable = new("ASIN_NOT_APPLICABLE");

    public static readonly ReasonCode NotEligible = new("NOT_ELIGIBLE");

    public static readonly ReasonCode IneligibleItemCondition = new("INELIGIBLE_ITEM_CONDITION");

    public static readonly ReasonCode ComplianceBlocked = new("COMPLIANCE_BLOCKED");

    public static readonly ReasonCode Hazmat = new("HAZMAT");

    public static readonly ReasonCode Recalled = new("RECALLED");

    public static readonly ReasonCode RestrictedCategory = new("RESTRICTED_CATEGORY");

    public static ReasonCode FromValue(string value) => FromValueCore(value);
}
