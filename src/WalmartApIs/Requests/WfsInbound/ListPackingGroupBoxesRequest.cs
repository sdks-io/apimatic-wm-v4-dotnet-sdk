using WalmartApIs.Core.Validation.Attributes;

namespace WalmartApIs.Requests.WfsInbound;

/// <summary>
/// The inputs of the ListPackingGroupBoxes operation.
/// </summary>
public sealed record ListPackingGroupBoxesRequest
{
    /// <summary>
    /// Identifier of an inbound plan.
    /// </summary>
    public required string InboundPlanId { get; init; }

    /// <summary>
    /// Identifier of a packing group.
    /// </summary>
    public required string PackingGroupId { get; init; }

    /// <summary>
    /// The number of packing group boxes to return in the response matching the given query.
    /// </summary>
    [Minimum(1)]
    [Maximum(30)]
    public int? PageSize { get; init; }

    /// <summary>
    /// A token to fetch a certain page when there are multiple pages worth of results.
    /// </summary>
    public string? PaginationToken { get; init; }
}
