using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<FulfillmentType>))]
public sealed record FulfillmentType : StringEnum<FulfillmentType>
{
    private FulfillmentType(string value) : base(value)
    {
    }

    public static readonly FulfillmentType SellerFulfilled = new("SellerFulfilled");

    public static readonly FulfillmentType Wfs = new("WFS");

    public static FulfillmentType FromValue(string value) => FromValueCore(value);
}
