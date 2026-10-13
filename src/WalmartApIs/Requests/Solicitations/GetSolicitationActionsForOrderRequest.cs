using System.Collections.Generic;

namespace WalmartApIs.Requests.Solicitations;

/// <summary>
/// The inputs of the GetSolicitationActionsForOrder operation.
/// </summary>
public sealed record GetSolicitationActionsForOrderRequest
{
    /// <summary>
    /// An SP-API order identifier. This specifies the order for which you want a list of available solicitation types.
    /// </summary>
    public required string SpApiOrderId { get; init; }

    /// <summary>
    /// A marketplace identifier. This specifies the marketplace in which the order was placed. Only one marketplace can be spec
    /// </summary>
    public required IReadOnlyList<string> MarketplaceIds { get; init; }
}
