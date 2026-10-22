using System.Collections.Generic;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

public record RequestsStatusResponse
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
    /// Used for pagination when more than specified limit (or default 10) records are found. Use this param for next API call. Just have to use this value as query param. Need to pass only the cursor value and not the initial API call query params. For e.g. if ['nextCursor'='reportType=ITEM&amp;requestStatus=ERROR&amp;requestSubmissionStartDate=2021-08-20T10:52:59Z&amp;requestSubmissionEndDate=2021-09-14T10:52:59Z&amp;page=2&amp;limit=1'] then subsequent call to will be [marketplace.walmartapis.com/v3/reports/reportRequests?reportType=ITEM&amp;requestStatus=ERROR&amp;requestSubmissionStartDate=2021-08-20T10:52:59Z&amp;requestSubmissionEndDate=2021-09-14T10:52:59Z&amp;page=2&amp;limit=1]. Just have to use nextCursor value instead of query params
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("nextCursor")]
    public string? NextCursor { get; init; }

    /// <summary>
    /// List of requests
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("requests")]
    public IReadOnlyList<RequestStatusResponse>? Requests { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
