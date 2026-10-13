namespace WalmartApIs.Requests.Inventory;

/// <summary>
/// The inputs of the GetInventoryForSku operation.
/// </summary>
public sealed record GetInventoryForSkuRequest
{
    public required string Sku { get; init; }

    /// <summary>
    /// Walmart Ship Node ID (for multi-node sellers)
    /// </summary>
    public string? ShipNode { get; init; }
}
