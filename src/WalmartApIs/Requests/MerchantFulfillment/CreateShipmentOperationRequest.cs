using WalmartApIs.Models;

namespace WalmartApIs.Requests.MerchantFulfillment;

/// <summary>
/// The inputs of the CreateShipment operation.
/// </summary>
public sealed record CreateShipmentOperationRequest
{
    public required CreateShipmentRequest Body { get; init; }
}
