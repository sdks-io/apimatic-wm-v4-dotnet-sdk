using System.Collections.Generic;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// Search response containing paginated item-level diagnostics and pagination metadata.
/// <para>
/// Each item's <c>issues</c> array contains <c>issueType</c> values as lightweight lookup keys.
/// Partners should use the dedicated <c>GET /item-issues/issue-types</c> endpoint to retrieve
/// complete issue metadata (name, description, category, fixability, help links) and cache
/// it locally (recommended TTL: 24 hours) to enrich search results.
/// </para>
/// </summary>
public record ItemDiagnosticSearchResponse
{
    /// <summary>
    /// Pagination metadata for navigating through search results.
    /// <para>
    /// Includes <c>hasNextPage</c> and <c>hasPreviousPage</c> boolean flags for
    /// convenient pagination control in UIs.
    /// </para>
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("pagination")]
    public DiagnosticPagination? Pagination { get; init; }

    /// <summary>
    /// Paginated list of item-level diagnostics.
    /// Each item appears once per unique <c>offerId</c> with all campaign associations.
    /// Empty array when no items match the search criteria.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("data")]
    public IReadOnlyList<ActiveItemIssues>? Data { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
