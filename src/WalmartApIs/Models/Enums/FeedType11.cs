using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<FeedType11>))]
public sealed record FeedType11 : OpenStringEnum<FeedType11>
{
    private FeedType11(string value) : base(value)
    {
    }

    public static readonly FeedType11 IncentiveEnrollment = new("INCENTIVE_ENROLLMENT");

    public TResult Match<TResult>(Func<TResult> onIncentiveEnrollment, Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == IncentiveEnrollment => onIncentiveEnrollment(),
            _ => otherwise(Value)
        };

    public void Match(Action onIncentiveEnrollment, Action<string> otherwise)
    {
        if (this == IncentiveEnrollment) onIncentiveEnrollment();
        else otherwise(Value);
    }
}
