using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<WeightUnit>))]
public sealed record WeightUnit : OpenStringEnum<WeightUnit>
{
    private WeightUnit(string value) : base(value)
    {
    }

    public static readonly WeightUnit Lb = new("LB");

    public static readonly WeightUnit Kg = new("KG");

    public static readonly WeightUnit Oz = new("OZ");

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
