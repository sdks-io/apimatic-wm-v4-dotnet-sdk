using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<SellerType>))]
public sealed record SellerType : StringEnum<SellerType>
{
    private SellerType(string value) : base(value)
    {
    }

    public static readonly SellerType Marketplace = new("Marketplace");

    public static readonly SellerType Wfs = new("WFS");

    public static readonly SellerType Both = new("Both");

    public static SellerType FromValue(string value) => FromValueCore(value);
}
