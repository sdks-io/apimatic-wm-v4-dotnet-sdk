using WalmartApIs.Models;

namespace WalmartApIs.Requests.WfsInbound;

/// <summary>
/// The inputs of the UpdateInboundPlanName operation.
/// </summary>
public sealed record UpdateInboundPlanNameOperationRequest
{
    /// <summary>
    /// Identifier of an inbound plan.
    /// </summary>
    public required string InboundPlanId { get; init; }

    public required UpdateInboundPlanNameRequest Body { get; init; }
}
