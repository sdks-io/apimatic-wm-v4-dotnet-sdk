using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

/// <summary>
/// Unit of measurement for the package length, width, and height. Allowed values: IN (inches), FT (feet), CM (centimeters). Required when packageType is CUSTOM_PACKAGE; not required for other standard package types (e.g., FEDEX_ENVELOPE, FEDEX_PAK) where dimensions are predetermined by the carrier.
/// </summary>
[JsonConverter(typeof(StringEnumConverter<BoxDimensionUnit1>))]
public sealed record BoxDimensionUnit1 : OpenStringEnum<BoxDimensionUnit1>
{
    private BoxDimensionUnit1(string value) : base(value)
    {
    }

    public static readonly BoxDimensionUnit1 In = new("IN");

    public static readonly BoxDimensionUnit1 Ft = new("FT");

    public static readonly BoxDimensionUnit1 Cm = new("CM");

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
