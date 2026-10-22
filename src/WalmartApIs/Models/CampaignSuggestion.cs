using System.Collections.Generic;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// Campaign-level suggestion containing current campaign settings and an array of actionable recommendations.
/// </summary>
public record CampaignSuggestion
{
    /// <summary>
    /// Unique campaign identifier.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("campaignId")]
    public string? CampaignId { get; init; }

    /// <summary>
    /// Human-readable campaign name.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("name")]
    public string? Name { get; init; }

    /// <summary>
    /// Current bidding strategy type configured for the campaign (For example, <c>TARGET_ROAS</c>, <c>MAXIMIZE_CLICKS</c>).
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("biddingStrategyType")]
    public string? BiddingStrategyType { get; init; }

    /// <summary>
    /// Current target Return on Ad Spend (ROAS) configured for the campaign. Only applicable when <c>biddingStrategyType</c> is <c>TARGET_ROAS</c>.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("targetRoas")]
    public double? TargetRoas { get; init; }

    /// <summary>
    /// Current daily budget configured for the campaign (in USD).
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("dailyBudget")]
    public double? DailyBudget { get; init; }

    /// <summary>
    /// List of actionable recommendations for this campaign.
    /// Each recommendation includes the type, recommended value, and projected performance impact.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("campaignRecommendations")]
    public IReadOnlyList<CampaignRecommendation>? CampaignRecommendations { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
