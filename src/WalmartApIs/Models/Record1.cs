using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// Information related to the item recommendations.
/// </summary>
public record Record1
{
    /// <summary>
    /// Unique identifier for the recommended item.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("itemRecommendationUniqueId")]
    public string? ItemRecommendationUniqueId { get; init; }

    /// <summary>
    /// Details of the recommended item.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("itemDetails")]
    public ItemDetails2? ItemDetails { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
