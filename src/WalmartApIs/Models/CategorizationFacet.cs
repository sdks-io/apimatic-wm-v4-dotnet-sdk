using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// Information of item recommendations based on the categorizationType.
/// </summary>
public record CategorizationFacet
{
    /// <summary>
    /// Name of the brand or category as per the categorizationType.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("name")]
    public string? Name { get; init; }

    /// <summary>
    /// The number of item recommendations associated with the name. The name can be associated with the categorization type.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("numberOfItemRecommendations")]
    public long? NumberOfItemRecommendations { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
