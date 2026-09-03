using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<FulfillmentShipmentStatus>))]
public sealed record FulfillmentShipmentStatus : StringEnum<FulfillmentShipmentStatus>
{
    private FulfillmentShipmentStatus(string value) : base(value)
    {
    }

    public static readonly FulfillmentShipmentStatus Pending = new("PENDING");

    public static readonly FulfillmentShipmentStatus Shipped = new("SHIPPED");

    public static readonly FulfillmentShipmentStatus CancelledByFulfiller = new("CANCELLED_BY_FULFILLER");

    public static readonly FulfillmentShipmentStatus CancelledBySeller = new("CANCELLED_BY_SELLER");

    public static FulfillmentShipmentStatus FromValue(string value) => FromValueCore(value);
}
