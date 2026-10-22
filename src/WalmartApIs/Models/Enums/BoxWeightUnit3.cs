using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

/// <summary>
/// The unit of measurement for the package weight. Allowed values: LB (pounds), KG (kilograms), OZ (ounces).
/// <para>
/// &lt;b style="color: green;"&gt;Market availability: Global&lt;/b&gt;
/// </para>
/// </summary>
[JsonConverter(typeof(StringEnumConverter<BoxWeightUnit3>))]
public sealed record BoxWeightUnit3 : OpenStringEnum<BoxWeightUnit3>
{
    private BoxWeightUnit3(string value) : base(value)
    {
    }

    public static readonly BoxWeightUnit3 Lb = new("LB");

    public static readonly BoxWeightUnit3 Kg = new("KG");

    public static readonly BoxWeightUnit3 Oz = new("OZ");

    public TResult Match<TResult>(Func<TResult> onLb,
        Func<TResult> onKg,
        Func<TResult> onOz,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == Lb => onLb(),
            _ when this == Kg => onKg(),
            _ when this == Oz => onOz(),
            _ => otherwise(Value)
        };

    public void Match(Action onLb, Action onKg, Action onOz, Action<string> otherwise)
    {
        if (this == Lb) onLb();
        else if (this == Kg) onKg();
        else if (this == Oz) onOz();
        else otherwise(Value);
    }
}
