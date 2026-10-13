using WalmartApIs.Models;

namespace WalmartApIs.Requests.WfsInbound;

/// <summary>
/// The inputs of the CreateInboundPlan operation.
/// </summary>
public sealed record CreateInboundPlanOperationRequest
{
    public required CreateInboundPlanRequest Body { get; init; }
}
