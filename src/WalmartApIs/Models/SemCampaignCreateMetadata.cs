using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;
using WalmartApIs.Models.Enums;

namespace WalmartApIs.Models;

/// <summary>
/// Metadata for creating a campaign.
/// </summary>
public record SemCampaignCreateMetadata
{
    /// <summary>
    /// Name of the campaign. Allowed characters: letters, digits, dashes, underscores, and spaces. Maximum 255 characters allowed.
    /// </summary>
    [JsonPropertyName("name")]
    public required string Name { get; init; }

    /// <summary>
    /// Start date of the campaign in YYYY-MM-DD format.
    /// </summary>
    [JsonPropertyName("startDate")]
    [RegularExpression("YYYY-MM-DD")]
    public required string StartDate { get; init; }

    /// <summary>
    /// End date of the campaign in YYYY-MM-DD format.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("endDate")]
    [RegularExpression("YYYY-MM-DD")]
    public string? EndDate { get; init; } = "";

    /// <summary>
    /// Daily budget allocated for the campaign. Must be a positive value with up to 2 decimal places. Daily budget must be between $5.00 and $2,500.00.
    /// </summary>
    [JsonPropertyName("dailyBudget")]
    public required double DailyBudget { get; init; }

    /// <summary>
    /// Total budget allocated for the campaign. Must be a positive value with up to 2 decimal places. Total budget must be between $5.00 and $250,000.00. Total budget must be greater than or equal to daily budget.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("totalBudget")]
    public double? TotalBudget { get; init; }

    /// <summary>
    /// Bidding strategy type for the campaign.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("biddingStrategyType")]
    public BiddingStrategyType? BiddingStrategyType { get; init; }

    /// <summary>
    /// Target ROAS for the campaign. Must be a positive value between 1.00 and 20.00, with up to 2 decimal places.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("targetRoas")]
    public double? TargetRoas { get; init; } = 3.5d;

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
