using WalmartApIs.Core.Validation.Attributes;

namespace WalmartApIs.Requests.WfsInventory;

/// <summary>
/// The inputs of the GetWfsInventoryItems operation.
/// </summary>
public sealed record GetWfsInventoryItemsRequest
{
    /// <summary>
    /// Comma-separated seller SKUs to filter (max 50). Omit to return all WFS items.
    /// </summary>
    public string? Skus { get; init; }

    [Minimum(1)]
    [Maximum(300)]
    public int PageSize { get; init; } = 100;

    public string? NextToken { get; init; }
}
