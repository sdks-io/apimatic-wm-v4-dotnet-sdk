using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<Unit>))]
public sealed record Unit : StringEnum<Unit>
{
    private Unit(string value) : base(value)
    {
    }

    public static readonly Unit Inches = new("inches");

    public static readonly Unit Centimeters = new("centimeters");

    public static Unit FromValue(string value) => FromValueCore(value);
}
