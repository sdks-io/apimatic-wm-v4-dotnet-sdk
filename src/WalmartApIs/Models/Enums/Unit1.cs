using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<Unit1>))]
public sealed record Unit1 : OpenStringEnum<Unit1>
{
    private Unit1(string value) : base(value)
    {
    }

    public static readonly Unit1 Oz = new("oz");

    public static readonly Unit1 G = new("g");

    public static readonly Unit1 Lb = new("lb");

    public static readonly Unit1 Kg = new("kg");

    public TResult Match<TResult>(Func<TResult> onOz,
        Func<TResult> onG,
        Func<TResult> onLb,
        Func<TResult> onKg,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == Oz => onOz(),
            _ when this == G => onG(),
            _ when this == Lb => onLb(),
            _ when this == Kg => onKg(),
            _ => otherwise(Value)
        };

    public void Match(Action onOz, Action onG, Action onLb, Action onKg, Action<string> otherwise)
    {
        if (this == Oz) onOz();
        else if (this == G) onG();
        else if (this == Lb) onLb();
        else if (this == Kg) onKg();
        else otherwise(Value);
    }
}
