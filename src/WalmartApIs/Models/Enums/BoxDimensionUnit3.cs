using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

/// <summary>
/// The unit of measurement for the package length, width, and height. Allowed values: IN (inches), FT (feet), CM (centimeters).
/// <para>
/// &lt;b style="color: green;"&gt;Market availability: Global&lt;/b&gt;
/// </para>
/// </summary>
[JsonConverter(typeof(StringEnumConverter<BoxDimensionUnit3>))]
public sealed record BoxDimensionUnit3 : OpenStringEnum<BoxDimensionUnit3>
{
    private BoxDimensionUnit3(string value) : base(value)
    {
    }

    public static readonly BoxDimensionUnit3 In = new("IN");

    public static readonly BoxDimensionUnit3 Ft = new("FT");

    public static readonly BoxDimensionUnit3 Cm = new("CM");

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
