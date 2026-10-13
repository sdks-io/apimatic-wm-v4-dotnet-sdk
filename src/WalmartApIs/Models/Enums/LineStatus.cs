using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<LineStatus>))]
public sealed record LineStatus : OpenStringEnum<LineStatus>
{
    private LineStatus(string value) : base(value)
    {
    }

    public static readonly LineStatus Created = new("Created");

    public static readonly LineStatus Acknowledged = new("Acknowledged");

    public static readonly LineStatus Shipped = new("Shipped");

    public static readonly LineStatus Delivered = new("Delivered");

    public static readonly LineStatus Cancelled = new("Cancelled");

    public static readonly LineStatus Refunded = new("Refunded");

    public TResult Match<TResult>(Func<TResult> onCreated,
        Func<TResult> onAcknowledged,
        Func<TResult> onShipped,
        Func<TResult> onDelivered,
        Func<TResult> onCancelled,
        Func<TResult> onRefunded,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == Created => onCreated(),
            _ when this == Acknowledged => onAcknowledged(),
            _ when this == Shipped => onShipped(),
            _ when this == Delivered => onDelivered(),
            _ when this == Cancelled => onCancelled(),
            _ when this == Refunded => onRefunded(),
            _ => otherwise(Value)
        };

    public void Match(Action onCreated,
        Action onAcknowledged,
        Action onShipped,
        Action onDelivered,
        Action onCancelled,
        Action onRefunded,
        Action<string> otherwise)
    {
        if (this == Created) onCreated();
        else if (this == Acknowledged) onAcknowledged();
        else if (this == Shipped) onShipped();
        else if (this == Delivered) onDelivered();
        else if (this == Cancelled) onCancelled();
        else if (this == Refunded) onRefunded();
        else otherwise(Value);
    }
}
