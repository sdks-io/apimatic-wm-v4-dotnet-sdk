using WalmartApIs.Models;

namespace WalmartApIs.Requests.WfsInbound;

/// <summary>
/// The inputs of the GenerateSelfShipAppointmentSlots operation.
/// </summary>
public sealed record GenerateSelfShipAppointmentSlotsOperationRequest
{
    /// <summary>
    /// Identifier of an inbound plan.
    /// </summary>
    public required string InboundPlanId { get; init; }

    /// <summary>
    /// Identifier of a shipment.
    /// </summary>
    public required string ShipmentId { get; init; }

    public required GenerateSelfShipAppointmentSlotsRequest Body { get; init; }
}
