using System.Collections.Generic;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;
using WalmartApIs.Models.Enums;

namespace WalmartApIs.Models;

/// <summary>
/// Schema for an individual offer detail.
/// </summary>
public record OfferDetail
{
    /// <summary>
    /// When true, this is the seller's offer.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("MyOffer")]
    public bool? MyOffer { get; init; }

    /// <summary>
    /// Indicates whether the offer is a B2B or B2C offer.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("offerType")]
    public OfferType? OfferType { get; init; }

    /// <summary>
    /// The subcondition of the item. Subcondition values: New, Mint, Very Good, Good, Acceptable, Poor, Club, OEM, Warranty, Refurbished Warranty, Refurbished, Open Box, or Other.
    /// </summary>
    [JsonPropertyName("SubCondition")]
    public required string SubCondition { get; init; }

    /// <summary>
    /// The seller identifier for the offer.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("SellerId")]
    public string? SellerId { get; init; }

    /// <summary>
    /// Information about the condition of the item.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("ConditionNotes")]
    public string? ConditionNotes { get; init; }

    /// <summary>
    /// Information about the seller's feedback, including the percentage of positive feedback and total ratings.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("SellerFeedbackRating")]
    public SellerFeedbackType? SellerFeedbackRating { get; init; }

    /// <summary>
    /// The time range in which an item will likely be shipped once an order has been placed.
    /// </summary>
    [JsonPropertyName("ShippingTime")]
    public required DetailedShippingTimeType ShippingTime { get; init; }

    /// <summary>
    /// Currency type and monetary value.
    /// </summary>
    [JsonPropertyName("ListingPrice")]
    public required MoneyType ListingPrice { get; init; }

    /// <summary>
    /// Item pricing information when buying in bulk.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("quantityDiscountPrices")]
    public IReadOnlyList<QuantityDiscountPriceType>? QuantityDiscountPrices { get; init; }

    /// <summary>
    /// Currency type and monetary value.
    /// </summary>
    [JsonPropertyName("Shipping")]
    public required MoneyType Shipping { get; init; }

    /// <summary>
    /// The state and country from where the item is shipped.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("ShipsFrom")]
    public ShipsFromType? ShipsFrom { get; init; }

    /// <summary>
    /// When true, the offer is fulfilled by Walmart Fulfillment Services (WFS).
    /// </summary>
    [JsonPropertyName("IsFulfilledByWFS")]
    public required bool IsFulfilledByWfs { get; init; }

    /// <summary>
    /// Walmart Fulfillment Services prime eligibility information.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("WFSPrimeDetails")]
    public WfsPrimeDetailsType? WfsPrimeDetails { get; init; }

    /// <summary>
    /// When true, the offer is currently in the Buy Box.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("IsBuyBoxWinner")]
    public bool? IsBuyBoxWinner { get; init; }

    /// <summary>
    /// When true, the seller of the item is eligible to win the Buy Box.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("IsFeaturedMerchant")]
    public bool? IsFeaturedMerchant { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
