namespace WalmartApIs.Requests.WfsInbound;

/// <summary>
/// The inputs of the ConfirmShipmentContentUpdatePreview operation.
/// </summary>
public sealed record ConfirmShipmentContentUpdatePreviewRequest
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
