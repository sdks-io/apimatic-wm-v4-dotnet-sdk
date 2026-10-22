using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

/// <summary>
/// Shipping priority will help system decide the carrier service for fulfillment in case there are multiple shipping options available for customers with different carrier services in terms of shipping cost and speed.
/// </summary>
[JsonConverter(typeof(StringEnumConverter<ShippingPriority>))]
public sealed record ShippingPriority : OpenStringEnum<ShippingPriority>
{
    private ShippingPriority(string value) : base(value)
    {
    }

    public static readonly ShippingPriority Slowest = new("SLOWEST");

    public static readonly ShippingPriority Fastest = new("FASTEST");

    public TResult Match<TResult>(Func<TResult> onSlowest, Func<TResult> onFastest, Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == Slowest => onSlowest(),
            _ when this == Fastest => onFastest(),
            _ => otherwise(Value)
        };

    public void Match(Action onSlowest, Action onFastest, Action<string> otherwise)
    {
        if (this == Slowest) onSlowest();
        else if (this == Fastest) onFastest();
        else otherwise(Value);
    }
}
