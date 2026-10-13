using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

/// <summary>
/// Sales-channel hint that lets shipping-v4 route differently for
/// WFS-fulfilled orders, marketplace-seller-fulfilled orders, and
/// external (off-Walmart) orders.
/// </summary>
[JsonConverter(typeof(StringEnumConverter<ChannelType>))]
public sealed record ChannelType : OpenStringEnum<ChannelType>
{
    private ChannelType(string value) : base(value)
    {
    }

    public static readonly ChannelType WalmartMarketplace = new("WALMART_MARKETPLACE");

    public static readonly ChannelType External = new("EXTERNAL");

    public static readonly ChannelType Wfs = new("WFS");

    public TResult Match<TResult>(Func<TResult> onWalmartMarketplace,
        Func<TResult> onExternal,
        Func<TResult> onWfs,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == WalmartMarketplace => onWalmartMarketplace(),
            _ when this == External => onExternal(),
            _ when this == Wfs => onWfs(),
            _ => otherwise(Value)
        };

    public void Match(Action onWalmartMarketplace, Action onExternal, Action onWfs, Action<string> otherwise)
    {
        if (this == WalmartMarketplace) onWalmartMarketplace();
        else if (this == External) onExternal();
        else if (this == Wfs) onWfs();
        else otherwise(Value);
    }
}
