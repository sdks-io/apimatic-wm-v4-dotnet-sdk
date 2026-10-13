using WalmartApIs.Models;

namespace WalmartApIs.Requests.Orders;

/// <summary>
/// The inputs of the CancelOrderLines operation.
/// </summary>
public sealed record CancelOrderLinesOperationRequest
{
    public required string PurchaseOrderId { get; init; }

    public required CancelOrderLinesRequest Body { get; init; }
}
