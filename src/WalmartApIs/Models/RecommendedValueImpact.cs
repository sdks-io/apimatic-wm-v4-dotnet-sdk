using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// Projected performance impact of the recommendation at three levels.
/// <list type="bullet">
///   <item><description><b>recommended</b>: The optimal suggested value (marked <c>isRecommended: true</c>)</description></item>
///   <item><description><b>minRecommendation</b>: A conservative lower-bound option. May be <c>null</c> if not applicable.</description></item>
///   <item><description><b>maxRecommendation</b>: An aggressive upper-bound option. May be <c>null</c> if not applicable.</description></item>
/// </list>
/// </summary>
public record RecommendedValueImpact
{
    /// <summary>
    /// A single recommendation option with its projected performance impact.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("recommended")]
    public ImpactOption? Recommended { get; init; }

    /// <summary>
    /// Conservative lower-bound recommendation option. May be <c>null</c> when a minimum option is not applicable.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("minRecommendation")]
    public ImpactOption? MinRecommendation { get; init; }

    /// <summary>
    /// Aggressive upper-bound recommendation option. May be <c>null</c> when a maximum option is not applicable.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("maxRecommendation")]
    public ImpactOption? MaxRecommendation { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
