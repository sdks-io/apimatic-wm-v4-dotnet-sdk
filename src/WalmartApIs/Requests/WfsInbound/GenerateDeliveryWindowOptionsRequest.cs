namespace WalmartApIs.Requests.WfsInbound;

/// <summary>
/// The inputs of the GenerateDeliveryWindowOptions operation.
/// </summary>
public sealed record GenerateDeliveryWindowOptionsRequest
{
    /// <summary>
    /// Identifier of an inbound plan.
    /// </summary>
    public required string InboundPlanId { get; init; }

    /// <summary>
    /// The shipment to generate delivery window options for.
    /// </summary>
    public required string ShipmentId { get; init; }
}
