using System.ComponentModel.DataAnnotations;
using WalmartApIs.Core.Validation.Attributes;

namespace WalmartApIs.Requests.WfsInbound;

/// <summary>
/// The inputs of the ListInboundPlans operation.
/// </summary>
public sealed record ListInboundPlansRequest
{
    /// <summary>
    /// The number of inbound plans to return in the response matching the given query.
    /// </summary>
    [Minimum(1)]
    [Maximum(30)]
    public int PageSize { get; init; } = 10;

    /// <summary>
    /// A token to fetch a certain page when there are multiple pages worth of results.
    /// </summary>
    [StringLength(1024, MinimumLength = 0)]
    public string? PaginationToken { get; init; }

    /// <summary>
    /// The status of an inbound plan. Possible values: <c>ACTIVE</c>, <c>VOIDED</c>, <c>SHIPPED</c>, <c>ERRORED</c>.
    /// </summary>
    public string? Status { get; init; }

    /// <summary>
    /// Sort by field.
    /// </summary>
    public string? SortBy { get; init; }

    /// <summary>
    /// The sort order. Possible values: <c>ASC</c>, <c>DESC</c>.
    /// </summary>
    public string? SortOrder { get; init; }
}
