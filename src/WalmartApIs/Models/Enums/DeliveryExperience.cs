using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<DeliveryExperience>))]
public sealed record DeliveryExperience : OpenStringEnum<DeliveryExperience>
{
    private DeliveryExperience(string value) : base(value)
    {
    }

    public static readonly DeliveryExperience DeliveryConfirmationWithAdultSignature = new(
        "DeliveryConfirmationWithAdultSignature");

    public static readonly DeliveryExperience DeliveryConfirmationWithSignature = new(
        "DeliveryConfirmationWithSignature");

    public static readonly DeliveryExperience DeliveryConfirmationWithoutSignature = new(
        "DeliveryConfirmationWithoutSignature");

    public static readonly DeliveryExperience NoTracking = new("NoTracking");

    public TResult Match<TResult>(Func<TResult> onDeliveryConfirmationWithAdultSignature,
        Func<TResult> onDeliveryConfirmationWithSignature,
        Func<TResult> onDeliveryConfirmationWithoutSignature,
        Func<TResult> onNoTracking,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == DeliveryConfirmationWithAdultSignature => onDeliveryConfirmationWithAdultSignature(),
            _ when this == DeliveryConfirmationWithSignature => onDeliveryConfirmationWithSignature(),
            _ when this == DeliveryConfirmationWithoutSignature => onDeliveryConfirmationWithoutSignature(),
            _ when this == NoTracking => onNoTracking(),
            _ => otherwise(Value)
        };

    public void Match(Action onDeliveryConfirmationWithAdultSignature,
        Action onDeliveryConfirmationWithSignature,
        Action onDeliveryConfirmationWithoutSignature,
        Action onNoTracking,
        Action<string> otherwise)
    {
        if (this == DeliveryConfirmationWithAdultSignature) onDeliveryConfirmationWithAdultSignature();
        else if (this == DeliveryConfirmationWithSignature) onDeliveryConfirmationWithSignature();
        else if (this == DeliveryConfirmationWithoutSignature) onDeliveryConfirmationWithoutSignature();
        else if (this == NoTracking) onNoTracking();
        else otherwise(Value);
    }
}
