using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<CancellationReason>))]
public sealed record CancellationReason : OpenStringEnum<CancellationReason>
{
    private CancellationReason(string value) : base(value)
    {
    }

    public static readonly CancellationReason CustomerRequested = new("CUSTOMER_REQUESTED");

    public static readonly CancellationReason OutOfStock = new("OUT_OF_STOCK");

    public static readonly CancellationReason PriceError = new("PRICE_ERROR");

    public static readonly CancellationReason SellerInitiated = new("SELLER_INITIATED");

    public TResult Match<TResult>(Func<TResult> onCustomerRequested,
        Func<TResult> onOutOfStock,
        Func<TResult> onPriceError,
        Func<TResult> onSellerInitiated,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == CustomerRequested => onCustomerRequested(),
            _ when this == OutOfStock => onOutOfStock(),
            _ when this == PriceError => onPriceError(),
            _ when this == SellerInitiated => onSellerInitiated(),
            _ => otherwise(Value)
        };

    public void Match(Action onCustomerRequested,
        Action onOutOfStock,
        Action onPriceError,
        Action onSellerInitiated,
        Action<string> otherwise)
    {
        if (this == CustomerRequested) onCustomerRequested();
        else if (this == OutOfStock) onOutOfStock();
        else if (this == PriceError) onPriceError();
        else if (this == SellerInitiated) onSellerInitiated();
        else otherwise(Value);
    }
}
