using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<FulfillmentType>))]
public sealed record FulfillmentType : OpenStringEnum<FulfillmentType>
{
    private FulfillmentType(string value) : base(value)
    {
    }

    public static readonly FulfillmentType SellerFulfilled = new("SellerFulfilled");

    public static readonly FulfillmentType Wfs = new("WFS");

    public TResult Match<TResult>(Func<TResult> onSellerFulfilled,
        Func<TResult> onWfs,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == SellerFulfilled => onSellerFulfilled(),
            _ when this == Wfs => onWfs(),
            _ => otherwise(Value)
        };

    public void Match(Action onSellerFulfilled, Action onWfs, Action<string> otherwise)
    {
        if (this == SellerFulfilled) onSellerFulfilled();
        else if (this == Wfs) onWfs();
        else otherwise(Value);
    }
}
