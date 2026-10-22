using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

/// <summary>
/// | Attribute | Description | Data Type |
/// | --- | ----------- | ------- |
/// | ELIGIBLE | To get items which are eligible for the program | string |
/// | ENROLLED | To get items which are currently enrolled into the program | string |
/// | COMPLETE | To get items which have attained target reviews through the program | string |
/// </summary>
[JsonConverter(typeof(StringEnumConverter<ItemStatus3>))]
public sealed record ItemStatus3 : OpenStringEnum<ItemStatus3>
{
    private ItemStatus3(string value) : base(value)
    {
    }

    public static readonly ItemStatus3 Eligible = new("ELIGIBLE");

    public static readonly ItemStatus3 Enrolled = new("ENROLLED");

    public static readonly ItemStatus3 Complete = new("COMPLETE");

    public TResult Match<TResult>(Func<TResult> onEligible,
        Func<TResult> onEnrolled,
        Func<TResult> onComplete,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == Eligible => onEligible(),
            _ when this == Enrolled => onEnrolled(),
            _ when this == Complete => onComplete(),
            _ => otherwise(Value)
        };

    public void Match(Action onEligible, Action onEnrolled, Action onComplete, Action<string> otherwise)
    {
        if (this == Eligible) onEligible();
        else if (this == Enrolled) onEnrolled();
        else if (this == Complete) onComplete();
        else otherwise(Value);
    }
}
