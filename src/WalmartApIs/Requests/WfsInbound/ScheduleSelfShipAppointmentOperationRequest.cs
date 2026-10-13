using WalmartApIs.Models;

namespace WalmartApIs.Requests.WfsInbound;

/// <summary>
/// The inputs of the ScheduleSelfShipAppointment operation.
/// </summary>
public sealed record ScheduleSelfShipAppointmentOperationRequest
{
    /// <summary>
    /// Identifier of an inbound plan.
    /// </summary>
    public required string InboundPlanId { get; init; }

    /// <summary>
    /// Identifier of a shipment.
    /// </summary>
    public required string ShipmentId { get; init; }

    /// <summary>
    /// An identifier to a self-ship appointment slot.
    /// </summary>
    public required string SlotId { get; init; }

    public required ScheduleSelfShipAppointmentRequest Body { get; init; }
}
