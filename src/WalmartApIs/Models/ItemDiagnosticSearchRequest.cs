using System.Collections.Generic;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// Request DTO for searching item-level diagnostics.
/// <para>
/// All fields are optional. The request body itself is also optional — when absent, sensible defaults are applied:
/// - <c>page.offset</c>: 0
/// - <c>page.limit</c>: 100
/// - No filters (returns only items with issues: <c>BLOCKED</c> or <c>LIMITED</c>)
/// </para>
/// <para>
/// <b>Current scope</b>: Results are scoped to items in active SEM campaigns. In a future release, the <c>itemId</c> filter will support querying any item in the seller's catalog.
/// </para>
/// <para>
/// <b>Default behavior</b>: When no <c>issueCategory</c> filter is provided, the API returns <b>only items with issues</b> (<c>BLOCKED</c> or <c>LIMITED</c>). This design decision ensures diagnostics consumers receive actionable problems first, reducing payload size and improving relevance. To include healthy items, explicitly pass <c>issueCategory</c> with value <c>NO_ISSUES</c> or use all three values.
/// </para>
/// <para>
/// <b>Filter behavior</b>: Filters are combined with AND logic. Multiple values within a single filter act as OR. For example, filtering by <c>issueCategory</c>=[<c>BLOCKED</c>, <c>LIMITED</c>] returns items that are either <c>BLOCKED</c> or <c>LIMITED</c>. Adding a second filter <c>issues</c>=[<c>ITEM_OUT_OF_STOCK</c>] narrows results to items that are (<c>BLOCKED</c> or <c>LIMITED</c>) AND have <c>ITEM_OUT_OF_STOCK</c>.
/// </para>
/// </summary>
public record ItemDiagnosticSearchRequest
{
    /// <summary>
    /// Pagination configuration for controlling result set size and navigation.
    /// <para>
    /// <b>Defaults when page is not provided</b>: offset=0, limit=100
    /// </para>
    /// <para>
    /// Both <c>offset</c> and <c>limit</c> are required when the <c>page</c> object is provided.
    /// </para>
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("page")]
    public DiagnosticPage? Page { get; init; }

    /// <summary>
    /// List of filters to narrow down results.
    /// Multiple filters are combined using the AND operator.
    /// Each filter field must be specified only once (no duplicates).
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("filters")]
    public IReadOnlyList<ItemDiagnosticFilter>? Filters { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
