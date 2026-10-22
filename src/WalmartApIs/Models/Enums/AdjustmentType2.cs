using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

/// <summary>
/// Specifies how price adjustment is applied. UNIT for a fixed amount or PERCENTAGE for a percentage-based change.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US | CA | MX&lt;/b&gt;
/// </summary>
[JsonConverter(typeof(StringEnumConverter<AdjustmentType2>))]
public sealed record AdjustmentType2 : OpenStringEnum<AdjustmentType2>
{
    private AdjustmentType2(string value) : base(value)
    {
    }

    public static readonly AdjustmentType2 Unit = new("UNIT");

    public static readonly AdjustmentType2 Percentage = new("PERCENTAGE");

    public TResult Match<TResult>(Func<TResult> onUnit, Func<TResult> onPercentage, Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == Unit => onUnit(),
            _ when this == Percentage => onPercentage(),
            _ => otherwise(Value)
        };

    public void Match(Action onUnit, Action onPercentage, Action<string> otherwise)
    {
        if (this == Unit) onUnit();
        else if (this == Percentage) onPercentage();
        else otherwise(Value);
    }
}
