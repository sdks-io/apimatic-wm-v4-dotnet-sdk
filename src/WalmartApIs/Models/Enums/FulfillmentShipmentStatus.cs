using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<FulfillmentShipmentStatus>))]
public sealed record FulfillmentShipmentStatus : OpenStringEnum<FulfillmentShipmentStatus>
{
    private FulfillmentShipmentStatus(string value) : base(value)
    {
    }

    public static readonly FulfillmentShipmentStatus Pending = new("PENDING");

    public static readonly FulfillmentShipmentStatus Shipped = new("SHIPPED");

    public static readonly FulfillmentShipmentStatus CancelledByFulfiller = new("CANCELLED_BY_FULFILLER");

    public static readonly FulfillmentShipmentStatus CancelledBySeller = new("CANCELLED_BY_SELLER");

    public TResult Match<TResult>(Func<TResult> onPending,
        Func<TResult> onShipped,
        Func<TResult> onCancelledByFulfiller,
        Func<TResult> onCancelledBySeller,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == Pending => onPending(),
            _ when this == Shipped => onShipped(),
            _ when this == CancelledByFulfiller => onCancelledByFulfiller(),
            _ when this == CancelledBySeller => onCancelledBySeller(),
            _ => otherwise(Value)
        };

    public void Match(Action onPending,
        Action onShipped,
        Action onCancelledByFulfiller,
        Action onCancelledBySeller,
        Action<string> otherwise)
    {
        if (this == Pending) onPending();
        else if (this == Shipped) onShipped();
        else if (this == CancelledByFulfiller) onCancelledByFulfiller();
        else if (this == CancelledBySeller) onCancelledBySeller();
        else otherwise(Value);
    }
}
