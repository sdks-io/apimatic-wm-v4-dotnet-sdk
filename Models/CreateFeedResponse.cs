using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

public record CreateFeedResponse
{
    /// <summary>
    /// Unique identifier for the submitted feed. Use this to poll feed status.
    /// </summary>
    [JsonPropertyName("feedId")]
    public required string FeedId { get; init; }

    /// <summary>
    /// The feed type that was submitted
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("feedType")]
    public string? FeedType { get; init; }

    /// <summary>
    /// The marketplace the feed was submitted to
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("marketplaceId")]
    public string? MarketplaceId { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
