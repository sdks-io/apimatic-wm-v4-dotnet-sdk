using WalmartApIs.Core.Validation.Attributes;

namespace WalmartApIs.Requests.WfsInbound;

/// <summary>
/// The inputs of the ListTransportationOptions operation.
/// </summary>
public sealed record ListTransportationOptionsRequest
{
    /// <summary>
    /// Identifier of an inbound plan.
    /// </summary>
    public required string InboundPlanId { get; init; }

    /// <summary>
    /// The number of transportation options to return in the response matching the given query.
    /// </summary>
    [Minimum(1)]
    [Maximum(30)]
    public int? PageSize { get; init; }

    /// <summary>
    /// A token to fetch a certain page when there are multiple pages worth of results.
    /// </summary>
    public string? PaginationToken { get; init; }

    /// <summary>
    /// The placement option to get transportation options for. Either <c>placementOptionId</c> or <c>shipmentId</c> must be specified.
    /// </summary>
    public string? PlacementOptionId { get; init; }

    /// <summary>
    /// The shipment to get transportation options for. Either <c>placementOptionId</c> or <c>shipmentId</c> must be specified.
    /// </summary>
    public string? ShipmentId { get; init; }
}
