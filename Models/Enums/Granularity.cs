using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<Granularity>))]
public sealed record Granularity : StringEnum<Granularity>
{
    private Granularity(string value) : base(value)
    {
    }

    public static readonly Granularity Hour = new("Hour");

    public static readonly Granularity Day = new("Day");

    public static readonly Granularity Week = new("Week");

    public static readonly Granularity Month = new("Month");

    public static readonly Granularity Year = new("Year");

    public static readonly Granularity Total = new("Total");

    public static Granularity FromValue(string value) => FromValueCore(value);
}
