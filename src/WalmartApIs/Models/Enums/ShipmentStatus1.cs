using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

/// <summary>
/// Non-terminal shipment-lifecycle state. Mirrors Amazon SP-API
/// Orders v0 <c>shipmentStatus</c>. For terminal <c>Delivered</c> use the
/// dedicated <c>/deliver</c> endpoint.
/// </summary>
[JsonConverter(typeof(StringEnumConverter<ShipmentStatus1>))]
public sealed record ShipmentStatus1 : OpenStringEnum<ShipmentStatus1>
{
    private ShipmentStatus1(string value) : base(value)
    {
    }

    public static readonly ShipmentStatus1 ReadyForPickup = new("READY_FOR_PICKUP");

    public static readonly ShipmentStatus1 PickedUp = new("PICKED_UP");

    public static readonly ShipmentStatus1 InTransit = new("IN_TRANSIT");

    public static readonly ShipmentStatus1 OutForDelivery = new("OUT_FOR_DELIVERY");

    public TResult Match<TResult>(Func<TResult> onReadyForPickup,
        Func<TResult> onPickedUp,
        Func<TResult> onInTransit,
        Func<TResult> onOutForDelivery,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == ReadyForPickup => onReadyForPickup(),
            _ when this == PickedUp => onPickedUp(),
            _ when this == InTransit => onInTransit(),
            _ when this == OutForDelivery => onOutForDelivery(),
            _ => otherwise(Value)
        };

    public void Match(Action onReadyForPickup,
        Action onPickedUp,
        Action onInTransit,
        Action onOutForDelivery,
        Action<string> otherwise)
    {
        if (this == ReadyForPickup) onReadyForPickup();
        else if (this == PickedUp) onPickedUp();
        else if (this == InTransit) onInTransit();
        else if (this == OutForDelivery) onOutForDelivery();
        else otherwise(Value);
    }
}
