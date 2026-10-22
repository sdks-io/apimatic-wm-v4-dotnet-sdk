using System.Collections.Generic;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// Item report response containing item-level performance data and pagination info.
/// <para>
/// Each record includes both campaign hierarchy identifiers and item-specific details.
/// </para>
/// </summary>
public record WsrItemReportResponse
{
    /// <summary>
    /// List of item-level performance data.
    /// Empty array when no data is available for the given criteria.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("data")]
    public IReadOnlyList<WsrItemData>? Data { get; init; }

    /// <summary>
    /// Pagination metadata for navigating through the report results.
    /// <para>
    /// <b>Empty Response</b>: When no data is available, all fields will be 0.
    /// </para>
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("pagination")]
    public WsrPagination? Pagination { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
