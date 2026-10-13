using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

public record CreateFeedJsonRequest
{
    /// <summary>
    /// Feed payload as inline JSON. Structure varies by feedType.
    /// </summary>
    [JsonPropertyName("feedData")]
    public required object FeedData { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
