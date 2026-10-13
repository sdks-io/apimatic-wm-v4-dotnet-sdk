namespace WalmartApIs.Requests.WfsInbound;

/// <summary>
/// The inputs of the GeneratePackingOptions operation.
/// </summary>
public sealed record GeneratePackingOptionsRequest
{
    /// <summary>
    /// Identifier of an inbound plan.
    /// </summary>
    public required string InboundPlanId { get; init; }
}
