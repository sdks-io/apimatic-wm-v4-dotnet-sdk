using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<LabelFormat>))]
public sealed record LabelFormat : StringEnum<LabelFormat>
{
    private LabelFormat(string value) : base(value)
    {
    }

    public static readonly LabelFormat Pdf = new("PDF");

    public static readonly LabelFormat Png = new("PNG");

    public static readonly LabelFormat Zpl = new("ZPL");

    public static readonly LabelFormat Zpl300 = new("ZPL300");

    public static readonly LabelFormat ShippingServiceDefault = new("ShippingServiceDefault");

    public static LabelFormat FromValue(string value) => FromValueCore(value);
}
