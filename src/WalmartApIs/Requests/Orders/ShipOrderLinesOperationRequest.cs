using WalmartApIs.Models;

namespace WalmartApIs.Requests.Orders;

/// <summary>
/// The inputs of the ShipOrderLines operation.
/// </summary>
public sealed record ShipOrderLinesOperationRequest
{
    public required string PurchaseOrderId { get; init; }

    public required ShipOrderLinesRequest Body { get; init; }
}
