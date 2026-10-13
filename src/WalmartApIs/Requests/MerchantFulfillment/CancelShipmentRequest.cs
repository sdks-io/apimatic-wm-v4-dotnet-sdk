namespace WalmartApIs.Requests.MerchantFulfillment;

/// <summary>
/// The inputs of the CancelShipment operation.
/// </summary>
public sealed record CancelShipmentRequest
{
    public required string ShipmentId { get; init; }
}
