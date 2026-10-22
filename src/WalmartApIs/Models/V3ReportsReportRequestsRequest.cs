using System.Collections.Generic;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;
using WalmartApIs.Models.AnyOf;
using WalmartApIs.Models.Enums;

namespace WalmartApIs.Models;

/// <summary>
/// Request payload
/// </summary>
public record V3ReportsReportRequestsRequest
{
    /// <summary>
    /// Specifies a set of row level filters used to narrow down data by specific reportType. Refer to the guide section for more details.
    /// <para>
    /// &lt;strong style="color: green;"&gt;Market availability: Global&lt;/strong&gt;
    /// </para>
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("rowFilters")]
    public IReadOnlyList<RowFilter1>? RowFilters { get; init; }

    /// <summary>
    /// Specifies columns to exclude from a report. Note that not all reports support this filter. Refer to the guide section for more details.
    /// <para>
    /// &lt;strong style="color: green;"&gt;Market availability: Global&lt;/strong&gt;
    /// </para>
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("excludeColumns")]
    public IReadOnlyList<string>? ExcludeColumns { get; init; }

    /// <summary>
    /// Start timestamp for the report data range. Use ISO 8601 format for the date (<c>YYYY-MM-DDTHH:mm:ssZ</c>). Required when using <c>reportType=ITEM_PERFORMANCE</c> and <c>reportVersion=v3</c>. The date range from <c>dataStartTime</c> to <c>dataEndTime</c> must not exceed 2 years (730 days).
    /// <para>
    /// &lt;strong style="color: green;"&gt;Market availability: Global&lt;/strong&gt;
    /// </para>
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("dataStartTime")]
    public string? DataStartTime { get; init; }

    /// <summary>
    /// End timestamp for the report data range. Use ISO 8601 format for the date (<c>YYYY-MM-DDTHH:mm:ssZ</c>). Required when using <c>reportType=ITEM_PERFORMANCE</c> and <c>reportVersion=v3</c>. Must be greater than or equal to <c>dataStartTime</c>.
    /// <para>
    /// &lt;strong style="color: green;"&gt;Market availability: Global&lt;/strong&gt;
    /// </para>
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("dataEndTime")]
    public string? DataEndTime { get; init; }

    /// <summary>
    /// Specifies the date granularity for aggregating report data. Required when using <c>reportType=ITEM_PERFORMANCE</c> and <c>reportVersion=v3</c>. Valid values are <c>DAILY</c>, <c>WEEKLY</c>, <c>MONTHLY</c>, or <c>QUARTERLY</c>. Ignored for all other report types and versions.
    /// <para>
    /// &lt;strong style="color: green;"&gt;Market availability: Global&lt;/strong&gt;
    /// </para>
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("dateGranularity")]
    public DateGranularity? DateGranularity { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
