using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

/// <summary>
/// The fulfillment type for the offer. Possible values: WFS, SELLER.
/// </summary>
[JsonConverter(typeof(StringEnumConverter<FulfillmentType1>))]
public sealed record FulfillmentType1 : OpenStringEnum<FulfillmentType1>
{
    private FulfillmentType1(string value) : base(value)
    {
    }

    public static readonly FulfillmentType1 Wfs = new("WFS");

    public static readonly FulfillmentType1 Seller = new("SELLER");

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
