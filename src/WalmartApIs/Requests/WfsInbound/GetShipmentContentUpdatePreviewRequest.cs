namespace WalmartApIs.Requests.WfsInbound;

/// <summary>
/// The inputs of the GetShipmentContentUpdatePreview operation.
/// </summary>
public sealed record GetShipmentContentUpdatePreviewRequest
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
    /// Identifier of a content update preview.
    /// </summary>
    public required string ContentUpdatePreviewId { get; init; }
}
