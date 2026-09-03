using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<ShipmentStatus11>))]
public sealed record ShipmentStatus11 : StringEnum<ShipmentStatus11>
{
    private ShipmentStatus11(string value) : base(value)
    {
    }

    public static readonly ShipmentStatus11 ReadyForPickup = new("READY_FOR_PICKUP");

    public static readonly ShipmentStatus11 PickedUp = new("PICKED_UP");

    public static readonly ShipmentStatus11 InTransit = new("IN_TRANSIT");

    public static readonly ShipmentStatus11 OutForDelivery = new("OUT_FOR_DELIVERY");

    public static ShipmentStatus11 FromValue(string value) => FromValueCore(value);
}
