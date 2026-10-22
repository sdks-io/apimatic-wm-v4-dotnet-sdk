using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// Response payload containing operation results.
/// </summary>
public record Payload20
{
    /// <summary>
    /// A unique ID returned from the Bulk Upload API, used for tracking the feed file.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("feedId")]
    public string? FeedId { get; init; }

    /// <summary>
    /// Number of errors encountered during processing.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("errorCount")]
    public int? ErrorCount { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
