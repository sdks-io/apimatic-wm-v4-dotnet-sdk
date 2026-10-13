namespace WalmartApIs.Requests.WfsInbound;

/// <summary>
/// The inputs of the ConfirmDeliveryWindowOptions operation.
/// </summary>
public sealed record ConfirmDeliveryWindowOptionsRequest
{
    /// <summary>
    /// Identifier of an inbound plan.
    /// </summary>
    public required string InboundPlanId { get; init; }

    /// <summary>
    /// The shipment to confirm the delivery window option for.
    /// </summary>
    public required string ShipmentId { get; init; }

    /// <summary>
    /// The ID of the delivery window option to be confirmed.
    /// </summary>
    public required string DeliveryWindowOptionId { get; init; }
}
