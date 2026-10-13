using System.Collections.Generic;

namespace WalmartApIs.Requests.Messaging;

/// <summary>
/// The inputs of the CreateDigitalAccessKey operation.
/// </summary>
public sealed record CreateDigitalAccessKeyRequest
{
    /// <summary>
    /// A marketplace order identifier. This identifies the order for which a message is sent.
    /// </summary>
    public required string SpApiOrderId { get; init; }

    /// <summary>
    /// A marketplace identifier. This identifies the marketplace in which the order was placed. You can only specify one market
    /// </summary>
    public required IReadOnlyList<string> MarketplaceIds { get; init; }

    public required object Body { get; init; }
}
