using System.Collections.Generic;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;
using WalmartApIs.Models.Enums;

namespace WalmartApIs.Models;

/// <summary>
/// Schema for an individual offer.
/// </summary>
public record OfferType1
{
    /// <summary>
    /// Indicates whether the offer is a B2B or B2C offer.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("offerType")]
    public OfferType? OfferType { get; init; }

    /// <summary>
    /// Item price information. LandedPrice = ListingPrice + Shipping. Walmart does not have a seller-configurable per-offer loyalty points mechanism; the Points field from the SP-API reference spec is omitted..
    /// </summary>
    [JsonPropertyName("BuyingPrice")]
    public required PriceType BuyingPrice { get; init; }

    /// <summary>
    /// Currency type and monetary value.
    /// </summary>
    [JsonPropertyName("RegularPrice")]
    public required MoneyType RegularPrice { get; init; }

    /// <summary>
    /// Currency type and monetary value.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("businessPrice")]
    public MoneyType? BusinessPrice { get; init; }

    /// <summary>
    /// Item pricing information when buying in bulk.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("quantityDiscountPrices")]
    public IReadOnlyList<QuantityDiscountPriceType>? QuantityDiscountPrices { get; init; }

    /// <summary>
    /// The fulfillment channel for the offer listing. Possible values: WFS, SELLER.
    /// </summary>
    [JsonPropertyName("FulfillmentChannel")]
    public required FulfillmentChannel FulfillmentChannel { get; init; }

    /// <summary>
    /// The item condition for the offer listing. Possible values: New, Used, Collectible, Refurbished, or Club.
    /// </summary>
    [JsonPropertyName("ItemCondition")]
    public required string ItemCondition { get; init; }

    /// <summary>
    /// The item subcondition for the offer listing.
    /// </summary>
    [JsonPropertyName("ItemSubCondition")]
    public required string ItemSubCondition { get; init; }

    /// <summary>
    /// The seller stock keeping unit (SKU) of the item.
    /// </summary>
    [JsonPropertyName("SellerSKU")]
    public required string SellerSku { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
