namespace WalmartApIs.Requests.WfsInbound;

/// <summary>
/// The inputs of the GetDeliveryChallanDocument operation.
/// </summary>
public sealed record GetDeliveryChallanDocumentRequest
{
    /// <summary>
    /// Identifier of an inbound plan.
    /// </summary>
    public required string InboundPlanId { get; init; }

    /// <summary>
    /// Identifier of a shipment.
    /// </summary>
    public required string ShipmentId { get; init; }
}
