using WalmartApIs.Models;

namespace WalmartApIs.Requests.WfsInbound;

/// <summary>
/// The inputs of the GenerateTransportationOptions operation.
/// </summary>
public sealed record GenerateTransportationOptionsOperationRequest
{
    /// <summary>
    /// Identifier of an inbound plan.
    /// </summary>
    public required string InboundPlanId { get; init; }

    public required GenerateTransportationOptionsRequest Body { get; init; }
}
