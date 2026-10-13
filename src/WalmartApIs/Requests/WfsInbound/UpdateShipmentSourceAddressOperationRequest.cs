using WalmartApIs.Models;

namespace WalmartApIs.Requests.WfsInbound;

/// <summary>
/// The inputs of the UpdateShipmentSourceAddress operation.
/// </summary>
public sealed record UpdateShipmentSourceAddressOperationRequest
{
    /// <summary>
    /// Identifier of an inbound plan.
    /// </summary>
    public required string InboundPlanId { get; init; }

    /// <summary>
    /// Identifier of a shipment.
    /// </summary>
    public required string ShipmentId { get; init; }

    public required UpdateShipmentSourceAddressRequest Body { get; init; }
}
