using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<SellerType>))]
public sealed record SellerType : OpenStringEnum<SellerType>
{
    private SellerType(string value) : base(value)
    {
    }

    public static readonly SellerType Marketplace = new("Marketplace");

    public static readonly SellerType Wfs = new("WFS");

    public static readonly SellerType Both = new("Both");

    public TResult Match<TResult>(Func<TResult> onMarketplace,
        Func<TResult> onWfs,
        Func<TResult> onBoth,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == Marketplace => onMarketplace(),
            _ when this == Wfs => onWfs(),
            _ when this == Both => onBoth(),
            _ => otherwise(Value)
        };

    public void Match(Action onMarketplace, Action onWfs, Action onBoth, Action<string> otherwise)
    {
        if (this == Marketplace) onMarketplace();
        else if (this == Wfs) onWfs();
        else if (this == Both) onBoth();
        else otherwise(Value);
    }
}
