using WalmartApIs.Models;

namespace WalmartApIs.Requests.Shipping;

/// <summary>
/// The inputs of the OneClickShipment operation.
/// </summary>
public sealed record OneClickShipmentOperationRequest
{
    public required OneClickShipmentRequest Body { get; init; }
}
