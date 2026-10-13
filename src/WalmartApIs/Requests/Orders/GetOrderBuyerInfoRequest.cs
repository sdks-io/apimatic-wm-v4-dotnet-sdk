namespace WalmartApIs.Requests.Orders;

/// <summary>
/// The inputs of the GetOrderBuyerInfo operation.
/// </summary>
public sealed record GetOrderBuyerInfoRequest
{
    public required string PurchaseOrderId { get; init; }
}
