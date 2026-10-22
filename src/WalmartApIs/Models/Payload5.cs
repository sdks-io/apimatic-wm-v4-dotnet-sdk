using System.Collections.Generic;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// Payload in the response having the trend details for the recommended item.
/// </summary>
public record Payload5
{
    /// <summary>
    /// Unique ID that is returned in the response of the get recommendations API or in the on-request bulk CSV file.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US only&lt;/span&gt;&lt;/b&gt;
    /// </summary>
    [JsonPropertyName("recommendationUniqueId")]
    public required string RecommendationUniqueId { get; init; }

    /// <summary>
    /// Trend data for the recommended item. This will include Price trends and Demand trends.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US only&lt;/span&gt;&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("trends")]
    public IReadOnlyList<Trend>? Trends { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
