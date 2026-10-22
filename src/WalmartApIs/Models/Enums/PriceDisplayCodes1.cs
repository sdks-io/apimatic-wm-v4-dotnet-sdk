using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

/// <summary>
/// This is applicable only for promotions
/// </summary>
[JsonConverter(typeof(StringEnumConverter<PriceDisplayCodes1>))]
public sealed record PriceDisplayCodes1 : OpenStringEnum<PriceDisplayCodes1>
{
    private PriceDisplayCodes1(string value) : base(value)
    {
    }

    public static readonly PriceDisplayCodes1 Cart = new("CART");

    public static readonly PriceDisplayCodes1 Checkout = new("CHECKOUT");

    public TResult Match<TResult>(Func<TResult> onCart, Func<TResult> onCheckout, Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == Cart => onCart(),
            _ when this == Checkout => onCheckout(),
            _ => otherwise(Value)
        };

    public void Match(Action onCart, Action onCheckout, Action<string> otherwise)
    {
        if (this == Cart) onCart();
        else if (this == Checkout) onCheckout();
        else otherwise(Value);
    }
}
