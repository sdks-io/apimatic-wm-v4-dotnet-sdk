using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<ShipmentStatus>))]
public sealed record ShipmentStatus : StringEnum<ShipmentStatus>
{
    private ShipmentStatus(string value) : base(value)
    {
    }

    public static readonly ShipmentStatus Purchased = new("PURCHASED");

    public static readonly ShipmentStatus Refunded = new("REFUNDED");

    public static readonly ShipmentStatus Shipped = new("SHIPPED");

    public static ShipmentStatus FromValue(string value) => FromValueCore(value);
}
