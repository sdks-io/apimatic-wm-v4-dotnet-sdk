using WalmartApIs.Models;

namespace WalmartApIs.Requests.WfsInbound;

/// <summary>
/// The inputs of the UpdateShipmentTrackingDetails operation.
/// </summary>
public sealed record UpdateShipmentTrackingDetailsOperationRequest
{
    /// <summary>
    /// Identifier of an inbound plan.
    /// </summary>
    public required string InboundPlanId { get; init; }

    /// <summary>
    /// Identifier of a shipment.
    /// </summary>
    public required string ShipmentId { get; init; }

    public required UpdateShipmentTrackingDetailsRequest Body { get; init; }
}
