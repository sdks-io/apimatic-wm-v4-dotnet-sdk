using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

/// <summary>
/// Field by which the filtering is to be done.
/// <para>
/// <b>Supported fields</b>:
/// - <c>campaignIds</c>: Filter by specific campaign identifiers
/// - <c>recommendationType</c>: Filter by recommendation type (<c>BUDGET</c>, <c>BIDDING_STRATEGY</c>)
/// </para>
/// </summary>
[JsonConverter(typeof(StringEnumConverter<Field3>))]
public sealed record Field3 : OpenStringEnum<Field3>
{
    private Field3(string value) : base(value)
    {
    }

    public static readonly Field3 CampaignIds = new("campaignIds");

    public static readonly Field3 RecommendationType = new("recommendationType");

    public TResult Match<TResult>(Func<TResult> onCampaignIds,
        Func<TResult> onRecommendationType,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == CampaignIds => onCampaignIds(),
            _ when this == RecommendationType => onRecommendationType(),
            _ => otherwise(Value)
        };

    public void Match(Action onCampaignIds, Action onRecommendationType, Action<string> otherwise)
    {
        if (this == CampaignIds) onCampaignIds();
        else if (this == RecommendationType) onRecommendationType();
        else otherwise(Value);
    }
}
