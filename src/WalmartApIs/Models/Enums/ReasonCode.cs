using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<ReasonCode>))]
public sealed record ReasonCode : OpenStringEnum<ReasonCode>
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

    public TResult Match<TResult>(Func<TResult> onApprovalRequired,
        Func<TResult> onAsinNotApplicable,
        Func<TResult> onNotEligible,
        Func<TResult> onIneligibleItemCondition,
        Func<TResult> onComplianceBlocked,
        Func<TResult> onHazmat,
        Func<TResult> onRecalled,
        Func<TResult> onRestrictedCategory,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == ApprovalRequired => onApprovalRequired(),
            _ when this == AsinNotApplicable => onAsinNotApplicable(),
            _ when this == NotEligible => onNotEligible(),
            _ when this == IneligibleItemCondition => onIneligibleItemCondition(),
            _ when this == ComplianceBlocked => onComplianceBlocked(),
            _ when this == Hazmat => onHazmat(),
            _ when this == Recalled => onRecalled(),
            _ when this == RestrictedCategory => onRestrictedCategory(),
            _ => otherwise(Value)
        };

    public void Match(Action onApprovalRequired,
        Action onAsinNotApplicable,
        Action onNotEligible,
        Action onIneligibleItemCondition,
        Action onComplianceBlocked,
        Action onHazmat,
        Action onRecalled,
        Action onRestrictedCategory,
        Action<string> otherwise)
    {
        if (this == ApprovalRequired) onApprovalRequired();
        else if (this == AsinNotApplicable) onAsinNotApplicable();
        else if (this == NotEligible) onNotEligible();
        else if (this == IneligibleItemCondition) onIneligibleItemCondition();
        else if (this == ComplianceBlocked) onComplianceBlocked();
        else if (this == Hazmat) onHazmat();
        else if (this == Recalled) onRecalled();
        else if (this == RestrictedCategory) onRestrictedCategory();
        else otherwise(Value);
    }
}
