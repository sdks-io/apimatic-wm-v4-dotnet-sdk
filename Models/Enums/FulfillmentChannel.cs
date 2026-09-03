using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

/// <summary>
/// The fulfillment channel for the offer listing. Possible values: WFS, SELLER.
/// </summary>
[JsonConverter(typeof(StringEnumConverter<FulfillmentChannel>))]
public sealed record FulfillmentChannel : StringEnum<FulfillmentChannel>
{
    private FulfillmentChannel(string value) : base(value)
    {
    }

    public static readonly FulfillmentChannel Wfs = new("WFS");

    public static readonly FulfillmentChannel Seller = new("SELLER");

    public static FulfillmentChannel FromValue(string value) => FromValueCore(value);
}
