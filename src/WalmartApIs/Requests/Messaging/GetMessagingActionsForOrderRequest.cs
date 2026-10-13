using System.Collections.Generic;

namespace WalmartApIs.Requests.Messaging;

/// <summary>
/// The inputs of the GetMessagingActionsForOrder operation.
/// </summary>
public sealed record GetMessagingActionsForOrderRequest
{
    /// <summary>
    /// A marketplace order identifier. This specifies the order for which you want a list of available message types.
    /// </summary>
    public required string SpApiOrderId { get; init; }

    /// <summary>
    /// A marketplace identifier. This identifies the marketplace in which the order was placed. You can only specify one market
    /// </summary>
    public required IReadOnlyList<string> MarketplaceIds { get; init; }
}
