using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

/// <summary>
/// Bidding strategy type for the campaign.
/// </summary>
[JsonConverter(typeof(StringEnumConverter<BiddingStrategyType>))]
public sealed record BiddingStrategyType : OpenStringEnum<BiddingStrategyType>
{
    private BiddingStrategyType(string value) : base(value)
    {
    }

    public static readonly BiddingStrategyType TargetRoas = new("TARGET_ROAS");

    public static readonly BiddingStrategyType MaximizeTraffic = new("MAXIMIZE_TRAFFIC");

    public TResult Match<TResult>(Func<TResult> onTargetRoas,
        Func<TResult> onMaximizeTraffic,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == TargetRoas => onTargetRoas(),
            _ when this == MaximizeTraffic => onMaximizeTraffic(),
            _ => otherwise(Value)
        };

    public void Match(Action onTargetRoas, Action onMaximizeTraffic, Action<string> otherwise)
    {
        if (this == TargetRoas) onTargetRoas();
        else if (this == MaximizeTraffic) onMaximizeTraffic();
        else otherwise(Value);
    }
}
