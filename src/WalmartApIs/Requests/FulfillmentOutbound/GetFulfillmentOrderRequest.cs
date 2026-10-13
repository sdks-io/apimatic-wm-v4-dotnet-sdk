namespace WalmartApIs.Requests.FulfillmentOutbound;

/// <summary>
/// The inputs of the GetFulfillmentOrder operation.
/// </summary>
public sealed record GetFulfillmentOrderRequest
{
    public required string SellerFulfillmentOrderId { get; init; }
}
