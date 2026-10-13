using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

/// <summary>
/// Indicates whether the item is fulfilled by WFS or the seller.
/// </summary>
[JsonConverter(typeof(StringEnumConverter<FulfillmentChannel1>))]
public sealed record FulfillmentChannel1 : OpenStringEnum<FulfillmentChannel1>
{
    private FulfillmentChannel1(string value) : base(value)
    {
    }

    public static readonly FulfillmentChannel1 Wfs = new("WFS");

    public static readonly FulfillmentChannel1 Seller = new("SELLER");

    public TResult Match<TResult>(Func<TResult> onWfs, Func<TResult> onSeller, Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == Wfs => onWfs(),
            _ when this == Seller => onSeller(),
            _ => otherwise(Value)
        };

    public void Match(Action onWfs, Action onSeller, Action<string> otherwise)
    {
        if (this == Wfs) onWfs();
        else if (this == Seller) onSeller();
        else otherwise(Value);
    }
}
