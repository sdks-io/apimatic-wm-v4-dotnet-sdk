using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

/// <summary>
/// ISO 8601 duration for schedule recurrence
/// </summary>
[JsonConverter(typeof(StringEnumConverter<Period>))]
public sealed record Period : StringEnum<Period>
{
    private Period(string value) : base(value)
    {
    }

    public static readonly Period Pt5M = new("PT5M");

    public static readonly Period Pt15M = new("PT15M");

    public static readonly Period Pt30M = new("PT30M");

    public static readonly Period P1D = new("P1D");

    public static readonly Period P2D = new("P2D");

    public static readonly Period P3D = new("P3D");

    public static readonly Period Pt1H = new("PT1H");

    public static readonly Period P7D = new("P7D");

    public static readonly Period P14D = new("P14D");

    public static readonly Period P15D = new("P15D");

    public static readonly Period P18D = new("P18D");

    public static readonly Period P30D = new("P30D");

    public static Period FromValue(string value) => FromValueCore(value);
}
