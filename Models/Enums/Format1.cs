using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<Format1>))]
public sealed record Format1 : StringEnum<Format1>
{
    private Format1(string value) : base(value)
    {
    }

    public static readonly Format1 Pdf = new("PDF");

    public static readonly Format1 Png = new("PNG");

    public static readonly Format1 Zpl203 = new("ZPL203");

    public static readonly Format1 Zpl300 = new("ZPL300");

    public static Format1 FromValue(string value) => FromValueCore(value);
}
