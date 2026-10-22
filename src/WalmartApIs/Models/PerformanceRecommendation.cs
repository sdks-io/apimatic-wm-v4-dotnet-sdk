using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// Recommendations to decrease the cancellation rate
/// </summary>
public record PerformanceRecommendation
{
    /// <summary>
    /// recommendation
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("recommendation")]
    public string? Recommendation { get; init; }

    /// <summary>
    /// More information link url
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("moreInfoLink")]
    public string? MoreInfoLink { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
