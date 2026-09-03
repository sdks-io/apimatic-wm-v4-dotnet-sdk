using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<CarrierName>))]
public sealed record CarrierName : StringEnum<CarrierName>
{
    private CarrierName(string value) : base(value)
    {
    }

    public static readonly CarrierName Ups = new("UPS");

    public static readonly CarrierName Usps = new("USPS");

    public static readonly CarrierName FedEx = new("FedEx");

    public static readonly CarrierName OnTrac = new("OnTrac");

    public static readonly CarrierName LaserShip = new("LaserShip");

    public static readonly CarrierName WalmartGround = new("WALMART_GROUND");

    public static readonly CarrierName Other = new("OTHER");

    public static CarrierName FromValue(string value) => FromValueCore(value);
}
