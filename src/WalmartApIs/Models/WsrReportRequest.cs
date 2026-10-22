using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;
using WalmartApIs.Models.Enums;

namespace WalmartApIs.Models;

/// <summary>
/// Request DTO for fetching campaign performance reports and item performance reports.
/// <para>
/// <b>Required Fields</b>: <c>startDate</c>, <c>endDate</c>
/// <b>Optional Fields</b>: <c>performanceBy</c> (defaults to <c>CREATIVE</c>), <c>page</c>, <c>sort</c>, <c>filters</c>
/// </para>
/// </summary>
public record WsrReportRequest
{
    /// <summary>
    /// Aggregation level for metrics. Determines which identifier fields are populated in response.
    /// <list type="bullet">
    ///   <item><description><b>CAMPAIGN</b>: Only <c>campaignId</c> populated (<c>adGroupId</c>, <c>creativeId</c> will be null)</description></item>
    ///   <item><description><b>ADGROUP</b>: <c>campaignId</c> and <c>adGroupId</c> populated (<c>creativeId</c> will be null)</description></item>
    ///   <item><description><b>CREATIVE</b>: All IDs populated (<c>campaignId</c>, <c>adGroupId</c>, <c>creativeId</c>)</description></item>
    /// </list>
    /// <para>
    /// <b>Default</b>: <c>CREATIVE</c> (when not specified)
    /// </para>
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("performanceBy")]
    public PerformanceBy? PerformanceBy { get; init; } = PerformanceBy.Creative;

    /// <summary>
    /// Report start date in ISO format (YYYY-MM-DD).
    /// <para>
    /// <b>Required</b>: Yes
    /// <b>Validation</b>: Must be a valid date in ISO format
    /// </para>
    /// </summary>
    [JsonPropertyName("startDate")]
    public required DateTimeOffset StartDate { get; init; }

    /// <summary>
    /// Report end date in ISO format (YYYY-MM-DD).
    /// <para>
    /// <b>Required</b>: Yes
    /// <b>Validation</b>:
    /// - Must be strictly after startDate (not equal)
    /// - Duration between startDate and endDate must be less than 1 year
    /// </para>
    /// </summary>
    [JsonPropertyName("endDate")]
    public required DateTimeOffset EndDate { get; init; }

    /// <summary>
    /// Pagination configuration for controlling result set size and navigation.
    /// <para>
    /// The pagination uses offset-based navigation where:
    /// - <c>offset</c> = starting record position (0-indexed)
    /// - <c>limit</c> = number of records per page
    /// </para>
    /// <para>
    /// <b>Internal Conversion</b>: pageNumber = (offset / limit) + 1
    /// </para>
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("page")]
    public WsrPage? Page { get; init; }

    /// <summary>
    /// Sort configuration for ordering the report results.
    /// <para>
    /// <b>Defaults</b>: field="gmv", order="DESC"
    /// </para>
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("sort")]
    public WsrSort? Sort { get; init; }

    /// <summary>
    /// List of filters to apply on the report.
    /// Multiple filters can be combined for more specific queries.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("filters")]
    public IReadOnlyList<WsrFilter>? Filters { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
