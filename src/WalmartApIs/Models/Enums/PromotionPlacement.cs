using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

/// <summary>
/// Controls where discounted price is revealed to customers.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US
/// </summary>
[JsonConverter(typeof(StringEnumConverter<PromotionPlacement>))]
public sealed record PromotionPlacement : OpenStringEnum<PromotionPlacement>
{
    private PromotionPlacement(string value) : base(value)
    {
    }

    public static readonly PromotionPlacement MapCart = new("MAP Cart");

    public TResult Match<TResult>(Func<TResult> onMapCart, Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == MapCart => onMapCart(),
            _ => otherwise(Value)
        };

    public void Match(Action onMapCart, Action<string> otherwise)
    {
        if (this == MapCart) onMapCart();
        else otherwise(Value);
    }
}
