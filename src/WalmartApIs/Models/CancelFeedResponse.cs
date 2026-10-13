using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

public record CancelFeedResponse
{
    /// <summary>
    /// The feed that was requested to be cancelled
    /// </summary>
    [JsonPropertyName("feedId")]
    public required string FeedId { get; init; }

    /// <summary>
    /// Result of the cancellation request
    /// </summary>
    [JsonPropertyName("status")]
    public required string Status { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
