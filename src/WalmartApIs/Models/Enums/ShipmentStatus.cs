using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<ShipmentStatus>))]
public sealed record ShipmentStatus : OpenStringEnum<ShipmentStatus>
{
    private ShipmentStatus(string value) : base(value)
    {
    }

    public static readonly ShipmentStatus Purchased = new("PURCHASED");

    public static readonly ShipmentStatus Refunded = new("REFUNDED");

    public static readonly ShipmentStatus Shipped = new("SHIPPED");

    public TResult Match<TResult>(Func<TResult> onPurchased,
        Func<TResult> onRefunded,
        Func<TResult> onShipped,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == Purchased => onPurchased(),
            _ when this == Refunded => onRefunded(),
            _ when this == Shipped => onShipped(),
            _ => otherwise(Value)
        };

    public void Match(Action onPurchased, Action onRefunded, Action onShipped, Action<string> otherwise)
    {
        if (this == Purchased) onPurchased();
        else if (this == Refunded) onRefunded();
        else if (this == Shipped) onShipped();
        else otherwise(Value);
    }
}
