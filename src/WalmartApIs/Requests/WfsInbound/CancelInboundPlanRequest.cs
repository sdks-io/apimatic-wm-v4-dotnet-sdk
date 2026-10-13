namespace WalmartApIs.Requests.WfsInbound;

/// <summary>
/// The inputs of the CancelInboundPlan operation.
/// </summary>
public sealed record CancelInboundPlanRequest
{
    /// <summary>
    /// Identifier of an inbound plan.
    /// </summary>
    public required string InboundPlanId { get; init; }
}
