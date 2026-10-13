using WalmartApIs.Models;

namespace WalmartApIs.Requests.Orders;

/// <summary>
/// The inputs of the DeliverOrderLines operation.
/// </summary>
public sealed record DeliverOrderLinesOperationRequest
{
    public required string PurchaseOrderId { get; init; }

    public required DeliverOrderLinesRequest Body { get; init; }
}
