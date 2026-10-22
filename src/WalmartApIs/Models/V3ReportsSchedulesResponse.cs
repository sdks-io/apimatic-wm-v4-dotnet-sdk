using System.Collections.Generic;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

public record V3ReportsSchedulesResponse
{
    /// <summary>
    /// Current page
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("page")]
    public int? Page { get; init; }

    /// <summary>
    /// Number of records fetched.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("totalCount")]
    public long? TotalCount { get; init; }

    /// <summary>
    /// Number of records to be returned. Default is 10.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("limit")]
    public int? Limit { get; init; }

    /// <summary>
    /// Specifies pagination when records exceed the specified limit (or default of 10); pass this parameter for the next API call. You only need to pass the cursor value as a query parameter, not the initial API call query parameters. For example, if ['nextCursor'='reportType=ITEM&amp;requestStatus=ERROR&amp;requestSubmissionStartDate=2021-08-20T10:52:59Z&amp;requestSubmissionEndDate=2021-09-14T10:52:59Z&amp;page=2&amp;limit=1'] then the subsequent call will be: [marketplace.walmartapis.com/v3/reports/reportRequests?reportType=ITEM&amp;requestStatus=ERROR&amp;requestSubmissionStartDate=2021-08-20T10:52:59Z&amp;requestSubmissionEndDate=2021-09-14T10:52:59Z&amp;page=2&amp;limit=1]. You only need to use the nextCursor value instead of the original query parameters.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("nextCursor")]
    public string? NextCursor { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("schedules")]
    public IReadOnlyList<Schedule>? Schedules { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
