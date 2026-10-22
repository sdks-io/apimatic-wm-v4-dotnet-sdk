using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

/// <summary>
/// Box Dimension Unit [CM, IN]. Mandatory for CUSTOM_PACKAGE type, otherwise not required. &lt;br/&gt;&lt;b&gt;Applicable to SWW and WPS.&lt;/span&gt;&lt;/b&gt;
/// </summary>
[JsonConverter(typeof(StringEnumConverter<BoxDimensionUnit4>))]
public sealed record BoxDimensionUnit4 : OpenStringEnum<BoxDimensionUnit4>
{
    private BoxDimensionUnit4(string value) : base(value)
    {
    }

    public static readonly BoxDimensionUnit4 Cm = new("CM");

    public static readonly BoxDimensionUnit4 In = new("IN");

    public TResult Match<TResult>(Func<TResult> onCm, Func<TResult> onIn, Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == Cm => onCm(),
            _ when this == In => onIn(),
            _ => otherwise(Value)
        };

    public void Match(Action onCm, Action onIn, Action<string> otherwise)
    {
        if (this == Cm) onCm();
        else if (this == In) onIn();
        else otherwise(Value);
    }
}
