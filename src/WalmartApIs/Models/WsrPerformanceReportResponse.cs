using System.Collections.Generic;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// Performance report response containing aggregated metrics data and pagination info.
/// <para>
/// <b>Note</b>: The availability of identifier fields (<c>adGroupId</c>, <c>creativeId</c>) depends on
/// the <c>performanceBy</c> parameter used in the request.
/// </para>
/// </summary>
public record WsrPerformanceReportResponse
{
    /// <summary>
    /// List of performance metrics data aggregated by the specified
    /// performance level (<c>CAMPAIGN</c>, <c>ADGROUP</c>, or <c>CREATIVE</c>).
    /// <para>
    /// Empty array when no data is available for the given criteria.
    /// </para>
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("data")]
    public IReadOnlyList<WsrPerformanceData>? Data { get; init; }

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
