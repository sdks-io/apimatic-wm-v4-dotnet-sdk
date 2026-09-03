using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<Period1>))]
public sealed record Period1 : StringEnum<Period1>
{
    private Period1(string value) : base(value)
    {
    }

    public static readonly Period1 Pt5M = new("PT5M");

    public static readonly Period1 Pt15M = new("PT15M");

    public static readonly Period1 Pt30M = new("PT30M");

    public static readonly Period1 P1D = new("P1D");

    public static readonly Period1 P2D = new("P2D");

    public static readonly Period1 P3D = new("P3D");

    public static readonly Period1 Pt1H = new("PT1H");

    public static readonly Period1 P7D = new("P7D");

    public static readonly Period1 P14D = new("P14D");

    public static readonly Period1 P15D = new("P15D");

    public static readonly Period1 P18D = new("P18D");

    public static readonly Period1 P30D = new("P30D");

    public static Period1 FromValue(string value) => FromValueCore(value);
}
