using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

/// <summary>
/// Indicates the type of quantity discount this price applies to.
/// </summary>
[JsonConverter(typeof(StringEnumConverter<QuantityDiscountType>))]
public sealed record QuantityDiscountType : OpenStringEnum<QuantityDiscountType>
{
    private QuantityDiscountType(string value) : base(value)
    {
    }

    public static readonly QuantityDiscountType QuantityDiscount = new("QUANTITY_DISCOUNT");

    public TResult Match<TResult>(Func<TResult> onQuantityDiscount, Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == QuantityDiscount => onQuantityDiscount(),
            _ => otherwise(Value)
        };

    public void Match(Action onQuantityDiscount, Action<string> otherwise)
    {
        if (this == QuantityDiscount) onQuantityDiscount();
        else otherwise(Value);
    }
}
