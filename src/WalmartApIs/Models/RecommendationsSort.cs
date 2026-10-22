using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;
using WalmartApIs.Models.Enums;

namespace WalmartApIs.Models;

/// <summary>
/// Sorting configuration for ordering search results.
/// <para>
/// Both <c>field</c> and <c>order</c> are required when the <c>sort</c> object is provided.
/// </para>
/// </summary>
public record RecommendationsSort
{
    /// <summary>
    /// Field by which the results should be sorted.
    /// </summary>
    [JsonPropertyName("field")]
    public string Field { get; } = "adspend";

    /// <summary>
    /// Sort direction.
    /// </summary>
    [JsonPropertyName("order")]
    public required Order1 Order { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
