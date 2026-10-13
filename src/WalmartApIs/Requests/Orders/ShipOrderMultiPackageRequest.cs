using WalmartApIs.Models;

namespace WalmartApIs.Requests.Orders;

/// <summary>
/// The inputs of the ShipOrderMultiPackage operation.
/// </summary>
public sealed record ShipOrderMultiPackageRequest
{
    public required string PurchaseOrderId { get; init; }

    public required MultiPackageShipRequest Body { get; init; }
}
