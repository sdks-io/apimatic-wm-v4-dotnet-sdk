using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

/// <summary>
/// Current status of the item in IRP.
/// </summary>
[JsonConverter(typeof(StringEnumConverter<ItemStatus>))]
public sealed record ItemStatus : OpenStringEnum<ItemStatus>
{
    private ItemStatus(string value) : base(value)
    {
    }

    public static readonly ItemStatus Complete = new("COMPLETE");

    public static readonly ItemStatus Eligible = new("ELIGIBLE");

    public static readonly ItemStatus Enrolled = new("ENROLLED");

    public TResult Match<TResult>(Func<TResult> onComplete,
        Func<TResult> onEligible,
        Func<TResult> onEnrolled,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == Complete => onComplete(),
            _ when this == Eligible => onEligible(),
            _ when this == Enrolled => onEnrolled(),
            _ => otherwise(Value)
        };

    public void Match(Action onComplete, Action onEligible, Action onEnrolled, Action<string> otherwise)
    {
        if (this == Complete) onComplete();
        else if (this == Eligible) onEligible();
        else if (this == Enrolled) onEnrolled();
        else otherwise(Value);
    }
}
