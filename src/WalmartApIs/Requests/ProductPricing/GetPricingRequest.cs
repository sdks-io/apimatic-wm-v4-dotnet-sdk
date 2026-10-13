using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WalmartApIs.Models.Enums;

namespace WalmartApIs.Requests.ProductPricing;

/// <summary>
/// The inputs of the GetPricing operation.
/// </summary>
public sealed record GetPricingRequest
{
    /// <summary>
    /// A marketplace identifier. Specifies the marketplace for which prices are returned.
    /// </summary>
    public required string MarketplaceId { get; init; }

    /// <summary>
    /// Indicates whether Walmart Item ID values or seller SKU values are used to identify items.
    /// </summary>
    public ItemType ItemType { get; init; } = ItemType.Sku;

    /// <summary>
    /// A list of up to twenty seller SKU values used to identify items in the given marketplace.
    /// </summary>
    [MaxLength(20)]
    public IReadOnlyList<string>? Skus { get; init; }

    /// <summary>
    /// A list of up to twenty Walmart Item ID values used to identify items in the given marketplace.
    /// </summary>
    [MaxLength(20)]
    public IReadOnlyList<string>? WalmartItemIds { get; init; }

    /// <summary>
    /// Filters the offer listings based on item condition. Possible values: New, Used, Collectible, Refurbished, Club.
    /// </summary>
    public ConditionType2? ItemCondition { get; init; }

    /// <summary>
    /// Indicates whether to request pricing information for the seller's B2C or B2B offers. Default is B2C.
    /// </summary>
    public OfferType? OfferType { get; init; }

    /// <summary>
    /// Indicates whether to request Consumer or Business offers. Default is Consumer.
    /// </summary>
    public CustomerType? CustomerType { get; init; }
}
