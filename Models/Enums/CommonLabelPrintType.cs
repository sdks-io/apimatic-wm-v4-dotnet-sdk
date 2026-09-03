using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

/// <summary>
/// Indicates the type of print type for a given label.
/// </summary>
[JsonConverter(typeof(StringEnumConverter<CommonLabelPrintType>))]
public sealed record CommonLabelPrintType : StringEnum<CommonLabelPrintType>
{
    private CommonLabelPrintType(string value) : base(value)
    {
    }

    public static readonly CommonLabelPrintType StandardFormat = new("STANDARD_FORMAT");

    public static readonly CommonLabelPrintType ThermalPrinting = new("THERMAL_PRINTING");

    public static CommonLabelPrintType FromValue(string value) => FromValueCore(value);
}
