using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;
using WalmartApIs.Models.Enums;

namespace WalmartApIs.Models;

/// <summary>
/// An actionable recommendation for a campaign. Includes the recommendation type, suggested value, and projected performance impact at three levels (recommended, minimum, maximum).
/// </summary>
public record CampaignRecommendation
{
    /// <summary>
    /// Recommendation category.
    /// <list type="bullet">
    ///   <item><description><b>BUDGET</b>: Recommended budget adjustment (daily or total)</description></item>
    ///   <item><description><b>BIDDING_STRATEGY</b>: Recommended change to bidding strategy</description></item>
    /// </list>
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("type")]
    public TypeEnum? Type { get; init; }

    /// <summary>
    /// Specific recommendation subtype indicating the optimization action being suggested. Example values include <c>INCREASE_DAILY_BUDGET</c> and bidding strategy adjustment actions.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("subType")]
    public string? SubType { get; init; }

    /// <summary>
    /// The primary recommended value as a string representation. For budget recommendations, this is the suggested new budget amount.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("recommendedValue")]
    public string? RecommendedValue { get; init; }

    /// <summary>
    /// Projected performance impact of the recommendation at three levels.
    /// <list type="bullet">
    ///   <item><description><b>recommended</b>: The optimal suggested value (marked <c>isRecommended: true</c>)</description></item>
    ///   <item><description><b>minRecommendation</b>: A conservative lower-bound option. May be <c>null</c> if not applicable.</description></item>
    ///   <item><description><b>maxRecommendation</b>: An aggressive upper-bound option. May be <c>null</c> if not applicable.</description></item>
    /// </list>
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("recommendedValueImpact")]
    public RecommendedValueImpact? RecommendedValueImpact { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
