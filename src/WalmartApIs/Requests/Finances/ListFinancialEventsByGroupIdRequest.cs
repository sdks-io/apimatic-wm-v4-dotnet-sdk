using System;

namespace WalmartApIs.Requests.Finances;

/// <summary>
/// The inputs of the ListFinancialEventsByGroupId operation.
/// </summary>
public sealed record ListFinancialEventsByGroupIdRequest
{
    /// <summary>
    /// The identifier of the financial event group.
    /// </summary>
    public required string EventGroupId { get; init; }

    /// <summary>
    /// The maximum number of results to return per page.
    /// </summary>
    public int? MaxResultsPerPage { get; init; }

    /// <summary>
    /// Financial events posted after (or on) this date (ISO 8601).
    /// </summary>
    public DateTimeOffset? PostedAfter { get; init; }

    /// <summary>
    /// Financial events posted before (but not on) this date (ISO 8601).
    /// </summary>
    public DateTimeOffset? PostedBefore { get; init; }

    /// <summary>
    /// Cursor token for the next page of results.
    /// </summary>
    public string? NextToken { get; init; }
}
