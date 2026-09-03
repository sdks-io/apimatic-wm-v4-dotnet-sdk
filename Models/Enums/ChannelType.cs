using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

/// <summary>
/// Sales-channel hint that lets shipping-v4 route differently for
/// WFS-fulfilled orders, marketplace-seller-fulfilled orders, and
/// external (off-Walmart) orders.
/// </summary>
[JsonConverter(typeof(StringEnumConverter<ChannelType>))]
public sealed record ChannelType : StringEnum<ChannelType>
{
    private ChannelType(string value) : base(value)
    {
    }

    public static readonly ChannelType WalmartMarketplace = new("WALMART_MARKETPLACE");

    public static readonly ChannelType External = new("EXTERNAL");

    public static readonly ChannelType Wfs = new("WFS");

    public static ChannelType FromValue(string value) => FromValueCore(value);
}
