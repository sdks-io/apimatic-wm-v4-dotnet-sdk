using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

/// <summary>
/// Non-terminal shipment-lifecycle state. Mirrors Amazon SP-API
/// Orders v0 <c>shipmentStatus</c>. For terminal <c>Delivered</c> use the
/// dedicated <c>/deliver</c> endpoint.
/// </summary>
[JsonConverter(typeof(StringEnumConverter<ShipmentStatus1>))]
public sealed record ShipmentStatus1 : StringEnum<ShipmentStatus1>
{
    private ShipmentStatus1(string value) : base(value)
    {
    }

    public static readonly ShipmentStatus1 ReadyForPickup = new("READY_FOR_PICKUP");

    public static readonly ShipmentStatus1 PickedUp = new("PICKED_UP");

    public static readonly ShipmentStatus1 InTransit = new("IN_TRANSIT");

    public static readonly ShipmentStatus1 OutForDelivery = new("OUT_FOR_DELIVERY");

    public static ShipmentStatus1 FromValue(string value) => FromValueCore(value);
}
