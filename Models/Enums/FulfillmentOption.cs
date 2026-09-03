using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<FulfillmentOption>))]
public sealed record FulfillmentOption : StringEnum<FulfillmentOption>
{
    private FulfillmentOption(string value) : base(value)
    {
    }

    public static readonly FulfillmentOption S2H = new("S2H");

    public static readonly FulfillmentOption S2S = new("S2S");

    public static readonly FulfillmentOption PickupToday = new("PICKUP_TODAY");

    public static FulfillmentOption FromValue(string value) => FromValueCore(value);
}
