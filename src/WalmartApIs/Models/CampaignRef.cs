using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// Campaign association reference. Represents a campaign that an item belongs to.
/// A single item can appear in multiple campaigns.
/// </summary>
public record CampaignRef
{
    /// <summary>
    /// Campaign identifier.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("campaignId")]
    public string? CampaignId { get; init; }

    /// <summary>
    /// Human-readable campaign name.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("campaignName")]
    public string? CampaignName { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
