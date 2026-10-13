using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;
using WalmartApIs.Models.Enums;

namespace WalmartApIs.Models;

/// <summary>
/// Information that identifies an item.
/// </summary>
public record ItemIdentifier1
{
    /// <summary>
    /// A marketplace identifier.
    /// </summary>
    [JsonPropertyName("MarketplaceId")]
    public required string MarketplaceId { get; init; }

    /// <summary>
    /// The Walmart Item ID of the item.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("walmartItemId")]
    public string? WalmartItemId { get; init; }

    /// <summary>
    /// The seller stock keeping unit (SKU) of the item.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("SellerSKU")]
    public string? SellerSku { get; init; }

    /// <summary>
    /// Indicates the condition of the item. Possible values: New, Used, Collectible, Refurbished, Club.
    /// </summary>
    [JsonPropertyName("ItemCondition")]
    public required ConditionType2 ItemCondition { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
