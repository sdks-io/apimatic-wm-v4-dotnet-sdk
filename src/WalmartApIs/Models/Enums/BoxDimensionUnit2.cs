using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<BoxDimensionUnit2>))]
public sealed record BoxDimensionUnit2 : OpenStringEnum<BoxDimensionUnit2>
{
    private BoxDimensionUnit2(string value) : base(value)
    {
    }

    public static readonly BoxDimensionUnit2 In = new("IN");

    public static readonly BoxDimensionUnit2 Ft = new("FT");

    public static readonly BoxDimensionUnit2 Cm = new("CM");

    public TResult Match<TResult>(Func<TResult> onIn,
        Func<TResult> onFt,
        Func<TResult> onCm,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == In => onIn(),
            _ when this == Ft => onFt(),
            _ when this == Cm => onCm(),
            _ => otherwise(Value)
        };

    public void Match(Action onIn, Action onFt, Action onCm, Action<string> otherwise)
    {
        if (this == In) onIn();
        else if (this == Ft) onFt();
        else if (this == Cm) onCm();
        else otherwise(Value);
    }
}
