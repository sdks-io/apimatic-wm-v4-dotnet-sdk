using WalmartApIs.Models;

namespace WalmartApIs.Requests.WfsInbound;

/// <summary>
/// The inputs of the GeneratePlacementOptions operation.
/// </summary>
public sealed record GeneratePlacementOptionsOperationRequest
{
    /// <summary>
    /// Identifier of an inbound plan.
    /// </summary>
    public required string InboundPlanId { get; init; }

    public required GeneratePlacementOptionsRequest Body { get; init; }
}
