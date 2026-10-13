using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

/// <summary>
/// Indicates whether the offer is a B2B or B2C offer.
/// </summary>
[JsonConverter(typeof(StringEnumConverter<OfferType>))]
public sealed record OfferType : OpenStringEnum<OfferType>
{
    private OfferType(string value) : base(value)
    {
    }

    public static readonly OfferType B2C = new("B2C");

    public static readonly OfferType B2B = new("B2B");

    public TResult Match<TResult>(Func<TResult> onB2C, Func<TResult> onB2B, Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == B2C => onB2C(),
            _ when this == B2B => onB2B(),
            _ => otherwise(Value)
        };

    public void Match(Action onB2C, Action onB2B, Action<string> otherwise)
    {
        if (this == B2C) onB2C();
        else if (this == B2B) onB2B();
        else otherwise(Value);
    }
}
