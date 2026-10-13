namespace WalmartApIs.Requests.FulfillmentOutbound;

/// <summary>
/// The inputs of the CancelFulfillmentOrder operation.
/// </summary>
public sealed record CancelFulfillmentOrderRequest
{
    public required string SellerFulfillmentOrderId { get; init; }
}
