using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

/// <summary>
/// The fulfillment type for the offer. Possible values: WFS, SELLER.
/// </summary>
[JsonConverter(typeof(StringEnumConverter<FulfillmentType1>))]
public sealed record FulfillmentType1 : StringEnum<FulfillmentType1>
{
    private FulfillmentType1(string value) : base(value)
    {
    }

    public static readonly FulfillmentType1 Wfs = new("WFS");

    public static readonly FulfillmentType1 Seller = new("SELLER");

    public static FulfillmentType1 FromValue(string value) => FromValueCore(value);
}
