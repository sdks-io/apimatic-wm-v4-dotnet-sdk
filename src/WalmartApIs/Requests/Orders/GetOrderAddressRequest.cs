namespace WalmartApIs.Requests.Orders;

/// <summary>
/// The inputs of the GetOrderAddress operation.
/// </summary>
public sealed record GetOrderAddressRequest
{
    public required string PurchaseOrderId { get; init; }
}
