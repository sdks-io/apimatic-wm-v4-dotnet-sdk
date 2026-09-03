using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<WeightUnit>))]
public sealed record WeightUnit : StringEnum<WeightUnit>
{
    private WeightUnit(string value) : base(value)
    {
    }

    public static readonly WeightUnit Lb = new("LB");

    public static readonly WeightUnit Kg = new("KG");

    public static readonly WeightUnit Oz = new("OZ");

    public static WeightUnit FromValue(string value) => FromValueCore(value);
}
