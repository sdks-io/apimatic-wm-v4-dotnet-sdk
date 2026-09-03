using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<ShippingSpeedCategory>))]
public sealed record ShippingSpeedCategory : StringEnum<ShippingSpeedCategory>
{
    private ShippingSpeedCategory(string value) : base(value)
    {
    }

    public static readonly ShippingSpeedCategory Standard = new("Standard");

    public static readonly ShippingSpeedCategory Expedited = new("Expedited");

    public static readonly ShippingSpeedCategory Priority = new("Priority");

    public static readonly ShippingSpeedCategory ScheduledDelivery = new("ScheduledDelivery");

    public static ShippingSpeedCategory FromValue(string value) => FromValueCore(value);
}
