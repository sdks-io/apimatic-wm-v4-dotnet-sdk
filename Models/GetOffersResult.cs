using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;
using WalmartApIs.Models.Enums;

namespace WalmartApIs.Models;

/// <summary>
/// The payload for the getListingOffers and getItemOffers operations.
/// </summary>
public record GetOffersResult
{
    /// <summary>
    /// A marketplace identifier.
    /// </summary>
    [JsonPropertyName("marketplaceId")]
    public required string MarketplaceId { get; init; }

    /// <summary>
    /// The Walmart Item ID of the item.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("walmartItemId")]
    public string? WalmartItemId { get; init; }

    /// <summary>
    /// The stock keeping unit (SKU) of the item.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("SKU")]
    public string? Sku { get; init; }

    /// <summary>
    /// Indicates the condition of the item. Possible values: New, Used, Collectible, Refurbished, Club.
    /// </summary>
    [JsonPropertyName("ItemCondition")]
    public required ConditionType2 ItemCondition { get; init; }

    /// <summary>
    /// The status of the operation.
    /// </summary>
    [JsonPropertyName("status")]
    public required string Status { get; init; }

    /// <summary>
    /// Information that identifies an item.
    /// </summary>
    [JsonPropertyName("Identifier")]
    public required ItemIdentifier1 Identifier { get; init; }

    /// <summary>
    /// Contains price information about the product, including LowestPrices, BuyBoxPrices, and NumberOfOffers.
    /// </summary>
    [JsonPropertyName("Summary")]
    public required Summary Summary { get; init; }

    /// <summary>
    /// A list of offer details. The list is the same length as TotalOfferCount in the Summary or 20, whichever is less.
    /// </summary>
    [JsonPropertyName("Offers")]
    [MaxLength(20)]
    public required IReadOnlyList<OfferDetail> Offers { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
