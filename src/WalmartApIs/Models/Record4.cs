using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// Information related to the item recommendations.
/// </summary>
public record Record4
{
    /// <summary>
    /// Unique identifier for the recommended item. &lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US | CA | MX&lt;/span&gt;&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("itemRecommendationUniqueId")]
    public string? ItemRecommendationUniqueId { get; init; }

    /// <summary>
    /// Details of the recommended item.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("itemDetails")]
    public ItemDetails3? ItemDetails { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
