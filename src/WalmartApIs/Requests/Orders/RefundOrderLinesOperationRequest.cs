using WalmartApIs.Models;

namespace WalmartApIs.Requests.Orders;

/// <summary>
/// The inputs of the RefundOrderLines operation.
/// </summary>
public sealed record RefundOrderLinesOperationRequest
{
    public required string PurchaseOrderId { get; init; }

    public required RefundOrderLinesRequest Body { get; init; }
}
