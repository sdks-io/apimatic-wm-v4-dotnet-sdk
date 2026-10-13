using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

/// <summary>
/// Indicates whether the item is fulfilled by the seller or by Walmart Fulfillment Services.
/// </summary>
[JsonConverter(typeof(StringEnumConverter<FulfillmentChannelType>))]
public sealed record FulfillmentChannelType : OpenStringEnum<FulfillmentChannelType>
{
    private FulfillmentChannelType(string value) : base(value)
    {
    }

    public static readonly FulfillmentChannelType Wfs = new("WFS");

    public static readonly FulfillmentChannelType Seller = new("SELLER");

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
