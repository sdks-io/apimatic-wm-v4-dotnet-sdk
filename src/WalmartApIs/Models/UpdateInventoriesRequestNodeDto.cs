using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

public record UpdateInventoriesRequestNodeDto
{
    /// <summary>
    /// ShipNode Id of the ship node for which the inventory is requested
    /// </summary>
    [JsonPropertyName("shipNode")]
    public required string ShipNode { get; init; }

    /// <summary>
    /// Quantity that has been ordered by the customers but not yet shipped.
    /// </summary>
    [JsonPropertyName("inputQty")]
    public required SupplyQuantity InputQty { get; init; }

    /// <summary>
    /// Inventory available date for a ship node. Format:YYYY-MM-DD
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("inventoryAvailableDate")]
    public string? InventoryAvailableDate { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
