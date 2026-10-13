using WalmartApIs.Core.Validation.Attributes;

namespace WalmartApIs.Requests.WfsInbound;

/// <summary>
/// The inputs of the ListPlacementOptions operation.
/// </summary>
public sealed record ListPlacementOptionsRequest
{
    /// <summary>
    /// Identifier of an inbound plan.
    /// </summary>
    public required string InboundPlanId { get; init; }

    /// <summary>
    /// The number of placement options to return in the response matching the given query.
    /// </summary>
    [Minimum(1)]
    [Maximum(30)]
    public int? PageSize { get; init; }

    /// <summary>
    /// A token to fetch a certain page when there are multiple pages worth of results.
    /// </summary>
    public string? PaginationToken { get; init; }
}
