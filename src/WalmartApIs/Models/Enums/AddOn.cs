using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

/// <summary>
/// Add-ons Type. Add-ons can be opted during label generation for a shipping. Supported values for add-ons are INSURANCE and SIGNATURE. We support standard SIGNATURE Type for now.
/// </summary>
[JsonConverter(typeof(StringEnumConverter<AddOn>))]
public sealed record AddOn : OpenStringEnum<AddOn>
{
    private AddOn(string value) : base(value)
    {
    }

    public static readonly AddOn Signature = new("SIGNATURE");

    public static readonly AddOn Insurance = new("INSURANCE");

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
