using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

/// <summary>
/// Indicates whether the item is fulfilled by the seller or by Walmart Fulfillment Services.
/// </summary>
[JsonConverter(typeof(StringEnumConverter<FulfillmentChannelType>))]
public sealed record FulfillmentChannelType : StringEnum<FulfillmentChannelType>
{
    private FulfillmentChannelType(string value) : base(value)
    {
    }

    public static readonly FulfillmentChannelType Wfs = new("WFS");

    public static readonly FulfillmentChannelType Seller = new("SELLER");

    public static FulfillmentChannelType FromValue(string value) => FromValueCore(value);
}
