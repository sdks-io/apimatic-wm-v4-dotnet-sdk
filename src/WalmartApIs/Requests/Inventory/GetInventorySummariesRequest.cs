using WalmartApIs.Core.Validation.Attributes;

namespace WalmartApIs.Requests.Inventory;

/// <summary>
/// The inputs of the GetInventorySummaries operation.
/// </summary>
public sealed record GetInventorySummariesRequest
{
    /// <summary>
    /// Comma-separated seller SKUs (max 50)
    /// </summary>
    public string? Skus { get; init; }

    /// <summary>
    /// Walmart Ship Node ID (for multi-node sellers)
    /// </summary>
    public string? ShipNode { get; init; }

    [Minimum(1)]
    [Maximum(500)]
    public int PageSize { get; init; } = 100;

    public string? NextToken { get; init; }
}
