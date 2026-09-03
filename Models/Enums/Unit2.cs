using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<Unit2>))]
public sealed record Unit2 : StringEnum<Unit2>
{
    private Unit2(string value) : base(value)
    {
    }

    public static readonly Unit2 Ea = new("EA");

    public static readonly Unit2 Each = new("EACH");

    public static readonly Unit2 Case = new("CASE");

    public static readonly Unit2 Carton = new("CARTON");

    public static Unit2 FromValue(string value) => FromValueCore(value);
}
