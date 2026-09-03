using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<Format>))]
public sealed record Format : StringEnum<Format>
{
    private Format(string value) : base(value)
    {
    }

    public static readonly Format Pdf = new("PDF");

    public static readonly Format Png = new("PNG");

    public static readonly Format Zpl = new("ZPL");

    public static readonly Format Zpl300 = new("ZPL300");

    public static readonly Format ShippingServiceDefault = new("ShippingServiceDefault");

    public static Format FromValue(string value) => FromValueCore(value);
}
