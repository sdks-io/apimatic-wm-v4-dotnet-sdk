namespace WalmartApIs.Requests.Orders;

/// <summary>
/// The inputs of the GetOrderItems operation.
/// </summary>
public sealed record GetOrderItemsRequest
{
    public required string PurchaseOrderId { get; init; }
}
