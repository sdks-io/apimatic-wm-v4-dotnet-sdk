using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// Contains pricing information for bulk purchase discounts.
/// </summary>
public record QuantityDiscountPriceType
{
    /// <summary>
    /// Indicates at what quantity this price becomes active.
    /// </summary>
    [JsonPropertyName("quantityTier")]
    public required int QuantityTier { get; init; }

    /// <summary>
    /// Indicates the type of quantity discount this price applies to.
    /// </summary>
    [JsonPropertyName("quantityDiscountType")]
    public string QuantityDiscountType { get; } = "QUANTITY_DISCOUNT";

    /// <summary>
    /// Currency type and monetary value.
    /// </summary>
    [JsonPropertyName("listingPrice")]
    public required MoneyType ListingPrice { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
