using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

/// <summary>
/// IRP status of the items.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US only&lt;/b&gt;
/// </summary>
[JsonConverter(typeof(StringEnumConverter<ItemStatus10>))]
public sealed record ItemStatus10 : OpenStringEnum<ItemStatus10>
{
    private ItemStatus10(string value) : base(value)
    {
    }

    public static readonly ItemStatus10 Enrolled = new("ENROLLED");

    public static readonly ItemStatus10 Eligible = new("ELIGIBLE");

    public static readonly ItemStatus10 Complete = new("COMPLETE");

    public TResult Match<TResult>(Func<TResult> onEnrolled,
        Func<TResult> onEligible,
        Func<TResult> onComplete,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == Enrolled => onEnrolled(),
            _ when this == Eligible => onEligible(),
            _ when this == Complete => onComplete(),
            _ => otherwise(Value)
        };

    public void Match(Action onEnrolled, Action onEligible, Action onComplete, Action<string> otherwise)
    {
        if (this == Enrolled) onEnrolled();
        else if (this == Eligible) onEligible();
        else if (this == Complete) onComplete();
        else otherwise(Value);
    }
}
