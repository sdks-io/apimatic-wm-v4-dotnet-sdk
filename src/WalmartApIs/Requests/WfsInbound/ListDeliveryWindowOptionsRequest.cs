using WalmartApIs.Core.Validation.Attributes;

namespace WalmartApIs.Requests.WfsInbound;

/// <summary>
/// The inputs of the ListDeliveryWindowOptions operation.
/// </summary>
public sealed record ListDeliveryWindowOptionsRequest
{
    /// <summary>
    /// Identifier of an inbound plan.
    /// </summary>
    public required string InboundPlanId { get; init; }

    /// <summary>
    /// The shipment to get delivery window options for.
    /// </summary>
    public required string ShipmentId { get; init; }

    /// <summary>
    /// The number of delivery window options to return in the response matching the given query.
    /// </summary>
    [Minimum(1)]
    [Maximum(30)]
    public int? PageSize { get; init; }

    /// <summary>
    /// A token to fetch a certain page when there are multiple pages worth of results.
    /// </summary>
    public string? PaginationToken { get; init; }
}
