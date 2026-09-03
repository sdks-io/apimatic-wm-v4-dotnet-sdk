using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<FulfillmentOrderStatus>))]
public sealed record FulfillmentOrderStatus : StringEnum<FulfillmentOrderStatus>
{
    private FulfillmentOrderStatus(string value) : base(value)
    {
    }

    public static readonly FulfillmentOrderStatus Received = new("RECEIVED");

    public static readonly FulfillmentOrderStatus Invalid = new("INVALID");

    public static readonly FulfillmentOrderStatus Planning = new("PLANNING");

    public static readonly FulfillmentOrderStatus Processing = new("PROCESSING");

    public static readonly FulfillmentOrderStatus Cancelled = new("CANCELLED");

    public static readonly FulfillmentOrderStatus Complete = new("COMPLETE");

    public static readonly FulfillmentOrderStatus CompletePartialled = new("COMPLETE_PARTIALLED");

    public static readonly FulfillmentOrderStatus Unfulfillable = new("UNFULFILLABLE");

    public static FulfillmentOrderStatus FromValue(string value) => FromValueCore(value);
}
