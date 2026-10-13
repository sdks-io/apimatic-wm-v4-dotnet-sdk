using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

/// <summary>
/// Indicates the type of print type for a given label.
/// </summary>
[JsonConverter(typeof(StringEnumConverter<CommonLabelPrintType>))]
public sealed record CommonLabelPrintType : OpenStringEnum<CommonLabelPrintType>
{
    private CommonLabelPrintType(string value) : base(value)
    {
    }

    public static readonly CommonLabelPrintType StandardFormat = new("STANDARD_FORMAT");

    public static readonly CommonLabelPrintType ThermalPrinting = new("THERMAL_PRINTING");

    public TResult Match<TResult>(Func<TResult> onStandardFormat,
        Func<TResult> onThermalPrinting,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == StandardFormat => onStandardFormat(),
            _ when this == ThermalPrinting => onThermalPrinting(),
            _ => otherwise(Value)
        };

    public void Match(Action onStandardFormat, Action onThermalPrinting, Action<string> otherwise)
    {
        if (this == StandardFormat) onStandardFormat();
        else if (this == ThermalPrinting) onThermalPrinting();
        else otherwise(Value);
    }
}
