using System.Collections.Generic;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

public record RecommendedItem2
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
    /// The item's condition described by its appearance, quality, packaging, functionality, and previous usage.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("itemCondition")]
    public string? ItemCondition { get; init; }

    /// <summary>
    /// The estimated number of units per item currently in stock at WFS fulfillment centers.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("unitsStored")]
    public int? UnitsStored { get; init; }

    /// <summary>
    /// The overall status of the item in your Walmart Marketplace catalog. Available statuses include: Published, Unpublished, Processing, Stage, Error, or WFS Ineligible.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("publishingStatus")]
    public string? PublishingStatus { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("insights")]
    public IReadOnlyList<Insight2>? Insights { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
