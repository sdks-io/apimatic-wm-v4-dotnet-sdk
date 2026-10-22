using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

/// <summary>
/// Current status of the item in IRP.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US only&lt;/b&gt;
/// </summary>
[JsonConverter(typeof(StringEnumConverter<ItemStatus9>))]
public sealed record ItemStatus9 : OpenStringEnum<ItemStatus9>
{
    private ItemStatus9(string value) : base(value)
    {
    }

    public static readonly ItemStatus9 Complete = new("COMPLETE");

    public static readonly ItemStatus9 Eligible = new("ELIGIBLE");

    public static readonly ItemStatus9 Enrolled = new("ENROLLED");

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
