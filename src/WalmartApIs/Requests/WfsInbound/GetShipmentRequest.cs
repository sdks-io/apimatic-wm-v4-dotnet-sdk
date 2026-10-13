namespace WalmartApIs.Requests.WfsInbound;

/// <summary>
/// The inputs of the GetShipment operation.
/// </summary>
public sealed record GetShipmentRequest
{
    /// <summary>
    /// Identifier of an inbound plan.
    /// </summary>
    public required string InboundPlanId { get; init; }

    /// <summary>
    /// Identifier of a shipment. A shipment contains the boxes and units being inbounded.
    /// </summary>
    public required string ShipmentId { get; init; }
}
