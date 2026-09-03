using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;
using WalmartApIs.Models.Enums;

namespace WalmartApIs.Models;

public record WfsItem
{
    /// <summary>
    /// Seller-assigned SKU identifier.
    /// </summary>
    [JsonPropertyName("sellerSku")]
    public required string SellerSku { get; init; }

    /// <summary>
    /// Walmart internal item ID.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("walmartItemId")]
    public string? WalmartItemId { get; init; }

    /// <summary>
    /// Global Trade Item Number (14-digit).
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("gtin")]
    public string? Gtin { get; init; }

    /// <summary>
    /// Walmart offer ID.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("offerId")]
    public string? OfferId { get; init; }

    /// <summary>
    /// Item title as listed on Walmart.com.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("productName")]
    public string? ProductName { get; init; }

    /// <summary>
    /// Item brand name.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("brand")]
    public string? Brand { get; init; }

    /// <summary>
    /// Item condition.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("condition")]
    public Condition? Condition { get; init; }

    /// <summary>
    /// Timestamp of the most recent inventory update for this item.
    /// Null if no update timestamp is available.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("lastUpdated")]
    public DateTimeOffset? LastUpdated { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("inventoryDetails")]
    public WfsInventoryDetails? InventoryDetails { get; init; }

    /// <summary>
    /// Demand intelligence and replenishment recommendations (WFS-only — no SP-API equivalent)
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("inventoryInsights")]
    public WfsInventoryInsights? InventoryInsights { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
