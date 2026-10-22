using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// Sorting criteria
/// </summary>
public record SemSort
{
    /// <summary>
    /// Field to sort by.
    /// </summary>
    [JsonPropertyName("field")]
    public required string Field { get; init; }

    /// <summary>
    /// Sort direction. Allowed values: ASC, DESC.
    /// </summary>
    [JsonPropertyName("order")]
    public required string Order { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
