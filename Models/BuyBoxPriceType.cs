using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;
using WalmartApIs.Models.Enums;

namespace WalmartApIs.Models;

/// <summary>
/// Schema for an individual Buy Box price.
/// </summary>
public record BuyBoxPriceType
{
    /// <summary>
    /// Indicates the condition of the item. For example: New, Used, Collectible, Refurbished, or Club.
    /// </summary>
    [JsonPropertyName("condition")]
    public required string Condition { get; init; }

    /// <summary>
    /// Indicates whether the offer is a B2B or B2C offer.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("offerType")]
    public OfferType? OfferType { get; init; }

    /// <summary>
    /// Indicates at what quantity this price becomes active.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("quantityTier")]
    public int? QuantityTier { get; init; }

    /// <summary>
    /// Indicates the type of quantity discount this price applies to.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("quantityDiscountType")]
    public QuantityDiscountType? QuantityDiscountType { get; init; }

    /// <summary>
    /// Currency type and monetary value.
    /// </summary>
    [JsonPropertyName("LandedPrice")]
    public required MoneyType LandedPrice { get; init; }

    /// <summary>
    /// Currency type and monetary value.
    /// </summary>
    [JsonPropertyName("ListingPrice")]
    public required MoneyType ListingPrice { get; init; }

    /// <summary>
    /// Currency type and monetary value.
    /// </summary>
    [JsonPropertyName("Shipping")]
    public required MoneyType Shipping { get; init; }

    /// <summary>
    /// The seller identifier for the offer.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("sellerId")]
    public string? SellerId { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
