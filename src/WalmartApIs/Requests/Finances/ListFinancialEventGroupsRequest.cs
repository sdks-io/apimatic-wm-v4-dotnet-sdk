using System;

namespace WalmartApIs.Requests.Finances;

/// <summary>
/// The inputs of the ListFinancialEventGroups operation.
/// </summary>
public sealed record ListFinancialEventGroupsRequest
{
    /// <summary>
    /// The maximum number of results per page.
    /// </summary>
    public int? MaxResultsPerPage { get; init; }

    /// <summary>
    /// Financial event groups that opened before this date/time (ISO 8601).
    /// </summary>
    public DateTimeOffset? FinancialEventGroupStartedBefore { get; init; }

    /// <summary>
    /// Financial event groups that opened after this date/time (ISO 8601).
    /// </summary>
    public DateTimeOffset? FinancialEventGroupStartedAfter { get; init; }

    /// <summary>
    /// Cursor token for the next page of results.
    /// </summary>
    public string? NextToken { get; init; }
}
