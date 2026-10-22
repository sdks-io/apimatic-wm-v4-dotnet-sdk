using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<FeedType2>))]
public sealed record FeedType2 : OpenStringEnum<FeedType2>
{
    private FeedType2(string value) : base(value)
    {
    }

    public static readonly FeedType2 WalmartFundedIncentivesEnrollment = new("WALMART_FUNDED_INCENTIVES_ENROLLMENT");

    public TResult Match<TResult>(Func<TResult> onWalmartFundedIncentivesEnrollment, Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == WalmartFundedIncentivesEnrollment => onWalmartFundedIncentivesEnrollment(),
            _ => otherwise(Value)
        };

    public void Match(Action onWalmartFundedIncentivesEnrollment, Action<string> otherwise)
    {
        if (this == WalmartFundedIncentivesEnrollment) onWalmartFundedIncentivesEnrollment();
        else otherwise(Value);
    }
}
