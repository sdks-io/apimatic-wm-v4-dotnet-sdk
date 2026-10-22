using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// Pagination criteria
/// </summary>
public record SemPage
{
    /// <summary>
    /// The starting position for fetching records. Must be zero or a positive value.
    /// </summary>
    [JsonPropertyName("offset")]
    public required int Offset { get; init; }

    /// <summary>
    /// The maximum number of records to fetch per page. Must be a positive value and cannot exceed 200.
    /// </summary>
    [JsonPropertyName("limit")]
    public required int Limit { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
