using System.Collections.Generic;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

public record RecommendedItem
{
    /// <summary>
    /// The Global Trade Identification Number (GTIN) associated with the item. If you provide a 12-digit UPC rather than a GTIN, the GTIN will start with two 0s followed by the UPC.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("gtin")]
    public string? Gtin { get; init; }

    /// <summary>
    /// The unique identifier you as the seller have assigned to your item.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("sku")]
    public string? Sku { get; init; }

    /// <summary>
    /// Unique identifier assigned by Walmart for each item.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("itemId")]
    public string? ItemId { get; init; }

    /// <summary>
    /// The company name or manufacturer of the item.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("brand")]
    public string? Brand { get; init; }

    /// <summary>
    /// The name of the item.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("itemName")]
    public string? ItemName { get; init; }

    /// <summary>
    /// Out-of-stock items have 0 units available to sell.
    /// At-risk items have fewer than 28 days of supply, including both available and inbound units.
    /// In-stock items have more than 28 days of total supply.
    /// Long term out of stock items that have been consistently out of stock for more than 30 days.
    /// New to WFS items that have been set up in WFS but haven't been inbounded because a shipment order has not been created.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("stockStatus")]
    public string? StockStatus { get; init; }

    /// <summary>
    /// The item's condition described by its appearance, quality, packaging, functionality, and previous usage.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("itemCondition")]
    public string? ItemCondition { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("insights")]
    public IReadOnlyList<Insight>? Insights { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
