using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WalmartApIs.Models.Enums;

namespace WalmartApIs.Requests.ProductPricing;

/// <summary>
/// The inputs of the GetCompetitivePricing operation.
/// </summary>
public sealed record GetCompetitivePricingRequest
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
    /// Indicates whether to request pricing information from the point of view of Consumer or Business buyers. Default is Consumer.
    /// </summary>
    public CustomerType? CustomerType { get; init; }
}
