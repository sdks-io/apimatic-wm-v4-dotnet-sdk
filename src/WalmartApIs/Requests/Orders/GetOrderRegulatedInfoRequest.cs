namespace WalmartApIs.Requests.Orders;

/// <summary>
/// The inputs of the GetOrderRegulatedInfo operation.
/// </summary>
public sealed record GetOrderRegulatedInfoRequest
{
    /// <summary>
    /// Walmart Purchase Order ID
    /// </summary>
    public required string PurchaseOrderId { get; init; }
}
