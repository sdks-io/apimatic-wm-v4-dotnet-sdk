namespace WalmartApIs.Requests.Shipping;

/// <summary>
/// The inputs of the CancelShipment2 operation.
/// </summary>
public sealed record CancelShipment2Request
{
    /// <summary>
    /// Identifier of the shipment to cancel.
    /// </summary>
    public required string ShipmentId { get; init; }
}
