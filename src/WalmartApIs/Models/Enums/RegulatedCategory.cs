using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

/// <summary>
/// Top-level category of regulation that applies. NOT_REGULATED
/// means no verification is required and the rest of the fields
/// are informational only.
/// </summary>
[JsonConverter(typeof(StringEnumConverter<RegulatedCategory>))]
public sealed record RegulatedCategory : OpenStringEnum<RegulatedCategory>
{
    private RegulatedCategory(string value) : base(value)
    {
    }

    public static readonly RegulatedCategory NotRegulated = new("NOT_REGULATED");

    public static readonly RegulatedCategory Alcohol = new("ALCOHOL");

    public static readonly RegulatedCategory Tobacco = new("TOBACCO");

    public static readonly RegulatedCategory AgeRestricted = new("AGE_RESTRICTED");

    public static readonly RegulatedCategory Pharmacy = new("PHARMACY");

    public TResult Match<TResult>(Func<TResult> onNotRegulated,
        Func<TResult> onAlcohol,
        Func<TResult> onTobacco,
        Func<TResult> onAgeRestricted,
        Func<TResult> onPharmacy,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == NotRegulated => onNotRegulated(),
            _ when this == Alcohol => onAlcohol(),
            _ when this == Tobacco => onTobacco(),
            _ when this == AgeRestricted => onAgeRestricted(),
            _ when this == Pharmacy => onPharmacy(),
            _ => otherwise(Value)
        };

    public void Match(Action onNotRegulated,
        Action onAlcohol,
        Action onTobacco,
        Action onAgeRestricted,
        Action onPharmacy,
        Action<string> otherwise)
    {
        if (this == NotRegulated) onNotRegulated();
        else if (this == Alcohol) onAlcohol();
        else if (this == Tobacco) onTobacco();
        else if (this == AgeRestricted) onAgeRestricted();
        else if (this == Pharmacy) onPharmacy();
        else otherwise(Value);
    }
}
