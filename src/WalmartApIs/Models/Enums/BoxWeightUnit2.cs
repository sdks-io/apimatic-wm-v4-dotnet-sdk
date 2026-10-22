using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<BoxWeightUnit2>))]
public sealed record BoxWeightUnit2 : OpenStringEnum<BoxWeightUnit2>
{
    private BoxWeightUnit2(string value) : base(value)
    {
    }

    public static readonly BoxWeightUnit2 Lb = new("LB");

    public static readonly BoxWeightUnit2 Kg = new("KG");

    public static readonly BoxWeightUnit2 Oz = new("OZ");

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
