namespace WalmartApIs.Requests.Orders;

/// <summary>
/// The inputs of the GetOrder operation.
/// </summary>
public sealed record GetOrderRequest
{
    /// <summary>
    /// Walmart Purchase Order ID
    /// </summary>
    public required string PurchaseOrderId { get; init; }
}
