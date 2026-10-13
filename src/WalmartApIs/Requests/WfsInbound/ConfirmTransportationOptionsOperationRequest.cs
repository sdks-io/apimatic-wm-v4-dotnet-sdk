using WalmartApIs.Models;

namespace WalmartApIs.Requests.WfsInbound;

/// <summary>
/// The inputs of the ConfirmTransportationOptions operation.
/// </summary>
public sealed record ConfirmTransportationOptionsOperationRequest
{
    /// <summary>
    /// Identifier of an inbound plan.
    /// </summary>
    public required string InboundPlanId { get; init; }

    public required ConfirmTransportationOptionsRequest Body { get; init; }
}
