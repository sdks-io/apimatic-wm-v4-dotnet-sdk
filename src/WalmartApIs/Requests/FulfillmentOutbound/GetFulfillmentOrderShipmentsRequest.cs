namespace WalmartApIs.Requests.FulfillmentOutbound;

/// <summary>
/// The inputs of the GetFulfillmentOrderShipments operation.
/// </summary>
public sealed record GetFulfillmentOrderShipmentsRequest
{
    public required string SellerFulfillmentOrderId { get; init; }
}
