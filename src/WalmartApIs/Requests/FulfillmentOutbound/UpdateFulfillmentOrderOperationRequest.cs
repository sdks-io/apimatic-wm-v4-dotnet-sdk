using WalmartApIs.Models;

namespace WalmartApIs.Requests.FulfillmentOutbound;

/// <summary>
/// The inputs of the UpdateFulfillmentOrder operation.
/// </summary>
public sealed record UpdateFulfillmentOrderOperationRequest
{
    public required string SellerFulfillmentOrderId { get; init; }

    public required UpdateFulfillmentOrderRequest Body { get; init; }
}
