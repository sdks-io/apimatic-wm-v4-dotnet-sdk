using System.Collections.Generic;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;
using WalmartApIs.Models.AnyOf;

namespace WalmartApIs.Models;

/// <summary>
/// Request Payload
/// </summary>
public record GenerateReportPayload
{
    /// <summary>
    /// Row Level filters
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("rowFilters")]
    public IReadOnlyList<RowFilter1>? RowFilters { get; init; }

    /// <summary>
    /// Columns to exclude from report.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("excludeColumns")]
    public IReadOnlyList<string>? ExcludeColumns { get; init; }

    /// <summary>
    /// Start timestamp of the report date range.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("dataStartTime")]
    public string? DataStartTime { get; init; }

    /// <summary>
    /// End timestamp of the report date range.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("dataEndTime")]
    public string? DataEndTime { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
