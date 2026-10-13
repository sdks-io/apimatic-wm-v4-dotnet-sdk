using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;
using WalmartApIs.Models.Enums;

namespace WalmartApIs.Models;

public record InventorySummary
{
    [JsonPropertyName("sellerSku")]
    public required string SellerSku { get; init; }

    /// <summary>
    /// Item title as listed on the marketplace. Null if not available.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("productName")]
    public string? ProductName { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("walmartItemId")]
    public string? WalmartItemId { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("shipNode")]
    public string? ShipNode { get; init; }

    /// <summary>
    /// Item condition.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("condition")]
    public Condition? Condition { get; init; }

    /// <summary>
    /// Timestamp of the most recent inventory update for this SKU at this ship node.
    /// Null if no update timestamp is available.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("lastUpdated")]
    public DateTimeOffset? LastUpdated { get; init; }

    /// <summary>
    /// Date from which this inventory is available to sell at this ship node.
    /// Null if no availability date has been set.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("inventoryAvailableDate")]
    public DateTimeOffset? InventoryAvailableDate { get; init; }

    /// <summary>
    /// Inventory quantity breakdown for this SKU at this ship node.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("inventoryDetails")]
    public InventoryDetails? InventoryDetails { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
