using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;
using WalmartApIs.Models.Enums;

namespace WalmartApIs.Models;

/// <summary>
/// Schema for competitive pricing information.
/// </summary>
public record CompetitivePriceType
{
    /// <summary>
    /// The pricing model for each price that is returned. Possible values: 1 - New Buy Box Price. 2 - Used Buy Box Price.
    /// </summary>
    [JsonPropertyName("CompetitivePriceId")]
    public required string CompetitivePriceId { get; init; }

    /// <summary>
    /// Item price information. LandedPrice = ListingPrice + Shipping. Walmart does not have a seller-configurable per-offer loyalty points mechanism; the Points field from the SP-API reference spec is omitted..
    /// </summary>
    [JsonPropertyName("Price")]
    public required PriceType Price { get; init; }

    /// <summary>
    /// Indicates the condition of the item. Possible values: New, Used, Collectible, Refurbished, or Club.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("condition")]
    public string? Condition { get; init; }

    /// <summary>
    /// Indicates the subcondition of the item.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("subcondition")]
    public string? Subcondition { get; init; }

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
    /// The seller identifier for the offer.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("sellerId")]
    public string? SellerId { get; init; }

    /// <summary>
    /// Indicates whether the pricing information is for an offer listing that belongs to the requester.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("belongsToRequester")]
    public bool? BelongsToRequester { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
