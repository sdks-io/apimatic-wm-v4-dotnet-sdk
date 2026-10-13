namespace WalmartApIs.Requests.WfsInbound;

/// <summary>
/// The inputs of the GetInboundPlan operation.
/// </summary>
public sealed record GetInboundPlanRequest
{
    /// <summary>
    /// Identifier of an inbound plan.
    /// </summary>
    public required string InboundPlanId { get; init; }
}
