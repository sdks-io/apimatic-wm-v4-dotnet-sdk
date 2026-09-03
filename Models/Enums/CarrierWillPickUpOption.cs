using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<CarrierWillPickUpOption>))]
public sealed record CarrierWillPickUpOption : StringEnum<CarrierWillPickUpOption>
{
    private CarrierWillPickUpOption(string value) : base(value)
    {
    }

    public static readonly CarrierWillPickUpOption CarrierContact = new("CarrierContact");

    public static readonly CarrierWillPickUpOption SellerContact = new("SellerContact");

    public static readonly CarrierWillPickUpOption NoPreference = new("NoPreference");

    public static CarrierWillPickUpOption FromValue(string value) => FromValueCore(value);
}
