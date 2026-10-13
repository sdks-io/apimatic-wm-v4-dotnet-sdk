using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<ShippingSpeedCategory>))]
public sealed record ShippingSpeedCategory : OpenStringEnum<ShippingSpeedCategory>
{
    private ShippingSpeedCategory(string value) : base(value)
    {
    }

    public static readonly ShippingSpeedCategory Standard = new("Standard");

    public static readonly ShippingSpeedCategory Expedited = new("Expedited");

    public static readonly ShippingSpeedCategory Priority = new("Priority");

    public static readonly ShippingSpeedCategory ScheduledDelivery = new("ScheduledDelivery");

    public TResult Match<TResult>(Func<TResult> onStandard,
        Func<TResult> onExpedited,
        Func<TResult> onPriority,
        Func<TResult> onScheduledDelivery,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == Standard => onStandard(),
            _ when this == Expedited => onExpedited(),
            _ when this == Priority => onPriority(),
            _ when this == ScheduledDelivery => onScheduledDelivery(),
            _ => otherwise(Value)
        };

    public void Match(Action onStandard,
        Action onExpedited,
        Action onPriority,
        Action onScheduledDelivery,
        Action<string> otherwise)
    {
        if (this == Standard) onStandard();
        else if (this == Expedited) onExpedited();
        else if (this == Priority) onPriority();
        else if (this == ScheduledDelivery) onScheduledDelivery();
        else otherwise(Value);
    }
}
