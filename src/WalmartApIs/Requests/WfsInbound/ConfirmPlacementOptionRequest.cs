namespace WalmartApIs.Requests.WfsInbound;

/// <summary>
/// The inputs of the ConfirmPlacementOption operation.
/// </summary>
public sealed record ConfirmPlacementOptionRequest
{
    /// <summary>
    /// Identifier of an inbound plan.
    /// </summary>
    public required string InboundPlanId { get; init; }

    /// <summary>
    /// The identifier of a placement option.
    /// </summary>
    public required string PlacementOptionId { get; init; }
}
