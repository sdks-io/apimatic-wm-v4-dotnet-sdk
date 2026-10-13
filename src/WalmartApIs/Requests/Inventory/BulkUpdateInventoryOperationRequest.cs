using WalmartApIs.Models;

namespace WalmartApIs.Requests.Inventory;

/// <summary>
/// The inputs of the BulkUpdateInventory operation.
/// </summary>
public sealed record BulkUpdateInventoryOperationRequest
{
    public required BulkUpdateInventoryRequest Body { get; init; }
}
