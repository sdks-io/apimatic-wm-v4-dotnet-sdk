using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

/// <summary>
/// Box Weight Unit [LB, KG]. &lt;br/&gt;&lt;b&gt;Applicable to SWW and WPS.&lt;/span&gt;&lt;/b&gt;
/// </summary>
[JsonConverter(typeof(StringEnumConverter<BoxWeightUnit4>))]
public sealed record BoxWeightUnit4 : OpenStringEnum<BoxWeightUnit4>
{
    private BoxWeightUnit4(string value) : base(value)
    {
    }

    public static readonly BoxWeightUnit4 Lb = new("LB");

    public static readonly BoxWeightUnit4 Kg = new("KG");

    public TResult Match<TResult>(Func<TResult> onLb, Func<TResult> onKg, Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == Lb => onLb(),
            _ when this == Kg => onKg(),
            _ => otherwise(Value)
        };

    public void Match(Action onLb, Action onKg, Action<string> otherwise)
    {
        if (this == Lb) onLb();
        else if (this == Kg) onKg();
        else otherwise(Value);
    }
}
