using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<DeliveryExperience>))]
public sealed record DeliveryExperience : StringEnum<DeliveryExperience>
{
    private DeliveryExperience(string value) : base(value)
    {
    }

    public static readonly DeliveryExperience DeliveryConfirmationWithAdultSignature = new("DeliveryConfirmationWithAdultSignature");

    public static readonly DeliveryExperience DeliveryConfirmationWithSignature = new("DeliveryConfirmationWithSignature");

    public static readonly DeliveryExperience DeliveryConfirmationWithoutSignature = new("DeliveryConfirmationWithoutSignature");

    public static readonly DeliveryExperience NoTracking = new("NoTracking");

    public static DeliveryExperience FromValue(string value) => FromValueCore(value);
}
