using WalmartApIs.Models;

namespace WalmartApIs.Requests.Orders;

/// <summary>
/// The inputs of the AcknowledgeOrder operation.
/// </summary>
public sealed record AcknowledgeOrderOperationRequest
{
    public required string PurchaseOrderId { get; init; }

    public required AcknowledgeOrderRequest Body { get; init; }
}
