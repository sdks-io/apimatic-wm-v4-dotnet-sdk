using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

public record Inventory1
{
    /// <summary>
    /// A seller-provided Product ID. Response will have decoded value.
    /// </summary>
    [JsonPropertyName("sku")]
    public required string Sku { get; init; }

    /// <summary>
    /// Quantity that has been ordered by the customers but not yet shipped.
    /// </summary>
    [JsonPropertyName("quantity")]
    public required SupplyQuantity Quantity { get; init; }

    /// <summary>
    /// Information about when the inventory is expected at the given ship node.Format:YYYY-MM-DD
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("inventoryAvailableDate")]
    public string? InventoryAvailableDate { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
