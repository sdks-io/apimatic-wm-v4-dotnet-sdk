using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<CarrierWillPickUpOption>))]
public sealed record CarrierWillPickUpOption : OpenStringEnum<CarrierWillPickUpOption>
{
    private CarrierWillPickUpOption(string value) : base(value)
    {
    }

    public static readonly CarrierWillPickUpOption CarrierContact = new("CarrierContact");

    public static readonly CarrierWillPickUpOption SellerContact = new("SellerContact");

    public static readonly CarrierWillPickUpOption NoPreference = new("NoPreference");

    public TResult Match<TResult>(Func<TResult> onCarrierContact,
        Func<TResult> onSellerContact,
        Func<TResult> onNoPreference,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == CarrierContact => onCarrierContact(),
            _ when this == SellerContact => onSellerContact(),
            _ when this == NoPreference => onNoPreference(),
            _ => otherwise(Value)
        };

    public void Match(Action onCarrierContact, Action onSellerContact, Action onNoPreference, Action<string> otherwise)
    {
        if (this == CarrierContact) onCarrierContact();
        else if (this == SellerContact) onSellerContact();
        else if (this == NoPreference) onNoPreference();
        else otherwise(Value);
    }
}
