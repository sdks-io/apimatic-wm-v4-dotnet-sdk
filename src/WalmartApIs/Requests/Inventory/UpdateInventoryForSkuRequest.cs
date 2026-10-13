using WalmartApIs.Models;

namespace WalmartApIs.Requests.Inventory;

/// <summary>
/// The inputs of the UpdateInventoryForSku operation.
/// </summary>
public sealed record UpdateInventoryForSkuRequest
{
    public required string Sku { get; init; }

    public required UpdateInventoryRequest Body { get; init; }
}
