using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

/// <summary>
/// How the buyer must prove identity at delivery. NONE means no
/// verification is required (NOT_REGULATED orders always return
/// NONE).
/// </summary>
[JsonConverter(typeof(StringEnumConverter<RequiredVerificationMethod>))]
public sealed record RequiredVerificationMethod : OpenStringEnum<RequiredVerificationMethod>
{
    private RequiredVerificationMethod(string value) : base(value)
    {
    }

    public static readonly RequiredVerificationMethod None = new("NONE");

    public static readonly RequiredVerificationMethod DriversLicense = new("DRIVERS_LICENSE");

    public static readonly RequiredVerificationMethod Passport = new("PASSPORT");

    public static readonly RequiredVerificationMethod GovernmentId = new("GOVERNMENT_ID");

    public TResult Match<TResult>(Func<TResult> onNone,
        Func<TResult> onDriversLicense,
        Func<TResult> onPassport,
        Func<TResult> onGovernmentId,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == None => onNone(),
            _ when this == DriversLicense => onDriversLicense(),
            _ when this == Passport => onPassport(),
            _ when this == GovernmentId => onGovernmentId(),
            _ => otherwise(Value)
        };

    public void Match(Action onNone,
        Action onDriversLicense,
        Action onPassport,
        Action onGovernmentId,
        Action<string> otherwise)
    {
        if (this == None) onNone();
        else if (this == DriversLicense) onDriversLicense();
        else if (this == Passport) onPassport();
        else if (this == GovernmentId) onGovernmentId();
        else otherwise(Value);
    }
}
