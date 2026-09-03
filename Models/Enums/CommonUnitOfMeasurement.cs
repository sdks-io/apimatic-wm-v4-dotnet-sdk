using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

/// <summary>
/// Unit of linear measure.
/// </summary>
[JsonConverter(typeof(StringEnumConverter<CommonUnitOfMeasurement>))]
public sealed record CommonUnitOfMeasurement : StringEnum<CommonUnitOfMeasurement>
{
    private CommonUnitOfMeasurement(string value) : base(value)
    {
    }

    public static readonly CommonUnitOfMeasurement In = new("IN");

    public static readonly CommonUnitOfMeasurement Cm = new("CM");

    public static CommonUnitOfMeasurement FromValue(string value) => FromValueCore(value);
}
