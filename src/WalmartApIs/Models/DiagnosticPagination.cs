using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// Pagination metadata for navigating through search results.
/// <para>
/// Includes <c>hasNextPage</c> and <c>hasPreviousPage</c> boolean flags for
/// convenient pagination control in UIs.
/// </para>
/// </summary>
public record DiagnosticPagination
{
    /// <summary>
    /// Current page number (0-based).
    /// Calculated as: offset / limit
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("pageNo")]
    public int? PageNo { get; init; }

    /// <summary>
    /// Number of items per page (same as <c>limit</c> in request).
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("pageSize")]
    public int? PageSize { get; init; }

    /// <summary>
    /// Total number of items matching the search criteria across all pages.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("totalCount")]
    public int? TotalCount { get; init; }

    /// <summary>
    /// Total number of pages available.
    /// Calculated as: ceil(totalCount / pageSize)
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("totalPages")]
    public int? TotalPages { get; init; }

    /// <summary>
    /// <c>true</c> if more pages exist after the current page.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("hasNextPage")]
    public bool? HasNextPage { get; init; }

    /// <summary>
    /// <c>true</c> if pages exist before the current page.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("hasPreviousPage")]
    public bool? HasPreviousPage { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
