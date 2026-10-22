using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

/// <summary>
/// Shipping priority will help system decide the carrier service for fulfillment in case there are multiple shipping options available for customers with different carrier services in terms of shipping cost and speed.
/// &lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US&lt;/span&gt;&lt;/b&gt;
/// </summary>
[JsonConverter(typeof(StringEnumConverter<ShippingPriority7>))]
public sealed record ShippingPriority7 : OpenStringEnum<ShippingPriority7>
{
    private ShippingPriority7(string value) : base(value)
    {
    }

    public static readonly ShippingPriority7 Slowest = new("SLOWEST");

    public static readonly ShippingPriority7 Fastest = new("FASTEST");

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
