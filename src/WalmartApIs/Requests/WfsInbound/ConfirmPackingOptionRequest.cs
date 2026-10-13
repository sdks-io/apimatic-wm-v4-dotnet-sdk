namespace WalmartApIs.Requests.WfsInbound;

/// <summary>
/// The inputs of the ConfirmPackingOption operation.
/// </summary>
public sealed record ConfirmPackingOptionRequest
{
    /// <summary>
    /// Identifier of an inbound plan.
    /// </summary>
    public required string InboundPlanId { get; init; }

    /// <summary>
    /// Identifier of a packing option.
    /// </summary>
    public required string PackingOptionId { get; init; }
}
