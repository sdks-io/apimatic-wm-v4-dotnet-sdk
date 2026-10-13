using WalmartApIs.Models;

namespace WalmartApIs.Requests.Orders;

/// <summary>
/// The inputs of the UpdateVerificationStatus operation.
/// </summary>
public sealed record UpdateVerificationStatusOperationRequest
{
    /// <summary>
    /// Walmart Purchase Order ID
    /// </summary>
    public required string PurchaseOrderId { get; init; }

    public required UpdateVerificationStatusRequest Body { get; init; }
}
