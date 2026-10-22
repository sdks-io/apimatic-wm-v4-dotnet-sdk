using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<IncentiveType>))]
public sealed record IncentiveType : OpenStringEnum<IncentiveType>
{
    private IncentiveType(string value) : base(value)
    {
    }

    public static readonly IncentiveType ReducedReferral = new("REDUCED_REFERRAL");

    public static readonly IncentiveType WalmartFunded = new("WALMART_FUNDED");

    public TResult Match<TResult>(Func<TResult> onReducedReferral,
        Func<TResult> onWalmartFunded,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == ReducedReferral => onReducedReferral(),
            _ when this == WalmartFunded => onWalmartFunded(),
            _ => otherwise(Value)
        };

    public void Match(Action onReducedReferral, Action onWalmartFunded, Action<string> otherwise)
    {
        if (this == ReducedReferral) onReducedReferral();
        else if (this == WalmartFunded) onWalmartFunded();
        else otherwise(Value);
    }
}
