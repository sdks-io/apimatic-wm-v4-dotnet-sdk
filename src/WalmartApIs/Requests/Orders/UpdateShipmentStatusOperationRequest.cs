using WalmartApIs.Models;

namespace WalmartApIs.Requests.Orders;

/// <summary>
/// The inputs of the UpdateShipmentStatus operation.
/// </summary>
public sealed record UpdateShipmentStatusOperationRequest
{
    public required string PurchaseOrderId { get; init; }

    public required UpdateShipmentStatusRequest Body { get; init; }
}
