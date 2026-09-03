using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

/// <summary>
/// Indicates whether the item is fulfilled by WFS or the seller.
/// </summary>
[JsonConverter(typeof(StringEnumConverter<FulfillmentChannel1>))]
public sealed record FulfillmentChannel1 : StringEnum<FulfillmentChannel1>
{
    private FulfillmentChannel1(string value) : base(value)
    {
    }

    public static readonly FulfillmentChannel1 Wfs = new("WFS");

    public static readonly FulfillmentChannel1 Seller = new("SELLER");

    public static FulfillmentChannel1 FromValue(string value) => FromValueCore(value);
}
