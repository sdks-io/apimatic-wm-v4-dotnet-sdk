namespace WalmartApIs.Requests.MerchantFulfillment;

/// <summary>
/// The inputs of the GetShipment2 operation.
/// </summary>
public sealed record GetShipment2Request
{
    public required string ShipmentId { get; init; }
}
