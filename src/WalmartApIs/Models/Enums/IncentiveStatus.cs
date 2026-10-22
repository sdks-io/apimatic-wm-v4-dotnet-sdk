using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<IncentiveStatus>))]
public sealed record IncentiveStatus : OpenStringEnum<IncentiveStatus>
{
    private IncentiveStatus(string value) : base(value)
    {
    }

    public static readonly IncentiveStatus Eligible = new("ELIGIBLE");

    public static readonly IncentiveStatus Enrolled = new("ENROLLED");

    public TResult Match<TResult>(Func<TResult> onEligible,
        Func<TResult> onEnrolled,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == Eligible => onEligible(),
            _ when this == Enrolled => onEnrolled(),
            _ => otherwise(Value)
        };

    public void Match(Action onEligible, Action onEnrolled, Action<string> otherwise)
    {
        if (this == Eligible) onEligible();
        else if (this == Enrolled) onEnrolled();
        else otherwise(Value);
    }
}
