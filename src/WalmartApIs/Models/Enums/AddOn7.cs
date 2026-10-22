using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

/// <summary>
/// AddOns Type. AddOns can be opted during label generation for a shipping. Supported values for AddOns are INSURANCE and SIGNATURE. We support standard SIGNATURE Type for now.
/// </summary>
[JsonConverter(typeof(StringEnumConverter<AddOn7>))]
public sealed record AddOn7 : OpenStringEnum<AddOn7>
{
    private AddOn7(string value) : base(value)
    {
    }

    public static readonly AddOn7 Signature = new("SIGNATURE");

    public static readonly AddOn7 Insurance = new("INSURANCE");

    public TResult Match<TResult>(Func<TResult> onSignature,
        Func<TResult> onInsurance,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == Signature => onSignature(),
            _ when this == Insurance => onInsurance(),
            _ => otherwise(Value)
        };

    public void Match(Action onSignature, Action onInsurance, Action<string> otherwise)
    {
        if (this == Signature) onSignature();
        else if (this == Insurance) onInsurance();
        else otherwise(Value);
    }
}
