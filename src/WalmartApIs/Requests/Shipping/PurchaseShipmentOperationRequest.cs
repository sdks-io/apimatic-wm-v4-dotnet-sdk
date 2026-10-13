using WalmartApIs.Models;

namespace WalmartApIs.Requests.Shipping;

/// <summary>
/// The inputs of the PurchaseShipment operation.
/// </summary>
public sealed record PurchaseShipmentOperationRequest
{
    public required PurchaseShipmentRequest Body { get; init; }
}
