using WalmartApIs.Models;

namespace WalmartApIs.Requests.FulfillmentOutbound;

/// <summary>
/// The inputs of the CreateFulfillmentOrder operation.
/// </summary>
public sealed record CreateFulfillmentOrderOperationRequest
{
    public required CreateFulfillmentOrderRequest Body { get; init; }
}
