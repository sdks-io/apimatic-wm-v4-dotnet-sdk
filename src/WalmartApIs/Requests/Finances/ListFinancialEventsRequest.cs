using System;

namespace WalmartApIs.Requests.Finances;

/// <summary>
/// The inputs of the ListFinancialEvents operation.
/// </summary>
public sealed record ListFinancialEventsRequest
{
    /// <summary>
    /// Ignored — GMP returns all results in a single page.
    /// </summary>
    public int? MaxResultsPerPage { get; init; }

    /// <summary>
    /// Not supported — returns 400 Bad Request if supplied.
    /// </summary>
    public DateTimeOffset? PostedAfter { get; init; }

    /// <summary>
    /// Not supported — returns 400 Bad Request if supplied.
    /// </summary>
    public DateTimeOffset? PostedBefore { get; init; }

    /// <summary>
    /// Not supported — returns 400 Bad Request if supplied.
    /// </summary>
    public string? NextToken { get; init; }
}
