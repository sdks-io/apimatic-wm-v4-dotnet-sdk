using WalmartApIs.Models;

namespace WalmartApIs.Requests.WfsInbound;

/// <summary>
/// The inputs of the SetPackingInformation operation.
/// </summary>
public sealed record SetPackingInformationOperationRequest
{
    /// <summary>
    /// Identifier of an inbound plan.
    /// </summary>
    public required string InboundPlanId { get; init; }

    public required SetPackingInformationRequest Body { get; init; }
}
