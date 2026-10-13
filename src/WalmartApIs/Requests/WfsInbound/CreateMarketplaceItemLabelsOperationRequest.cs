using WalmartApIs.Models;

namespace WalmartApIs.Requests.WfsInbound;

/// <summary>
/// The inputs of the CreateMarketplaceItemLabels operation.
/// </summary>
public sealed record CreateMarketplaceItemLabelsOperationRequest
{
    public required CreateMarketplaceItemLabelsRequest Body { get; init; }
}
