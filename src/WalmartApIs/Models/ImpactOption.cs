using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// A single recommendation option with its projected performance impact.
/// </summary>
public record ImpactOption
{
    /// <summary>
    /// The recommended value for this option (For example, suggested daily budget amount in USD).
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("value")]
    public double? Value { get; init; }

    /// <summary>
    /// Projected change in ad spend (in USD) if this option is applied.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("adspendChange")]
    public double? AdspendChange { get; init; }

    /// <summary>
    /// Projected change in number of clicks if this option is applied.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("clicksChange")]
    public int? ClicksChange { get; init; }

    /// <summary>
    /// Projected change in number of impressions if this option is applied.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("impressionsChange")]
    public int? ImpressionsChange { get; init; }

    /// <summary>
    /// <c>true</c> if this is the primary recommended option. Only one option within a <c>RecommendedValueImpact</c> will have <c>isRecommended: true</c>.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("isRecommended")]
    public bool? IsRecommended { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
