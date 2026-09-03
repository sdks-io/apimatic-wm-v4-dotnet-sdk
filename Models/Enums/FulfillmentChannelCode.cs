using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<FulfillmentChannelCode>))]
public sealed record FulfillmentChannelCode : StringEnum<FulfillmentChannelCode>
{
    private FulfillmentChannelCode(string value) : base(value)
    {
    }

    public static readonly FulfillmentChannelCode Default = new("DEFAULT");

    public static readonly FulfillmentChannelCode Wfs = new("WFS");

    public static FulfillmentChannelCode FromValue(string value) => FromValueCore(value);
}
