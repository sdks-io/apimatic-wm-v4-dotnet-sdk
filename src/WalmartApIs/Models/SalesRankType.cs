using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// Sales rank information for the item, by category.
/// </summary>
public record SalesRankType
{
    /// <summary>
    /// Identifies the item category from which the sales rank is taken.
    /// </summary>
    [JsonPropertyName("ProductCategoryId")]
    public required string ProductCategoryId { get; init; }

    /// <summary>
    /// The sales rank of the item within the item category.
    /// </summary>
    [JsonPropertyName("Rank")]
    public required int Rank { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
