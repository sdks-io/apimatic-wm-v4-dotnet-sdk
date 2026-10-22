using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

public record Replenishment
{
    /// <summary>
    /// The Walmart-assigned ID used to track items. This ID is located at the end of the item page URL.
    /// </summary>
    [JsonPropertyName("itemId")]
    public required string ItemId { get; init; }

    /// <summary>
    /// The Global Trade Identification Number (GTIN) associated with the item. If you provide a 12-digit UPC rather than a GTIN, the GTIN will start with two 0s followed by the UPC.
    /// </summary>
    [JsonPropertyName("gtin")]
    public required string Gtin { get; init; }

    /// <summary>
    /// Universal Product Code (UPC) of the item.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("upc")]
    public string? Upc { get; init; }

    /// <summary>
    /// The unique identifier assigned to the item by the seller.
    /// </summary>
    [JsonPropertyName("vendorSku")]
    public required string VendorSku { get; init; }

    /// <summary>
    /// Recommended maximum quantity for the item
    /// </summary>
    [JsonPropertyName("maxQty")]
    public required int MaxQty { get; init; }

    /// <summary>
    /// Suggested inbound quantity
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("suggestedQty")]
    public int? SuggestedQty { get; init; }

    /// <summary>
    /// Indicates whether the item is identified as a customer favorite based on customer demand.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("customerFavorite")]
    public bool? CustomerFavorite { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
