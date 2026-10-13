using WalmartApIs.Models.Enums;

namespace WalmartApIs.Requests.ProductPricing;

/// <summary>
/// The inputs of the GetItemOffers operation.
/// </summary>
public sealed record GetItemOffersRequest
{
    /// <summary>
    /// The Walmart Item ID of the item.
    /// </summary>
    public required string ItemId { get; init; }

    /// <summary>
    /// A marketplace identifier. Specifies the marketplace for which prices are returned.
    /// </summary>
    public required string MarketplaceId { get; init; }

    /// <summary>
    /// Filters the offer listings based on item condition. Possible values: New, Used, Collectible, Refurbished, Club.
    /// </summary>
    public required ConditionType2 ItemCondition { get; init; }

    /// <summary>
    /// Indicates whether to request Consumer or Business offers. Default is Consumer.
    /// </summary>
    public CustomerType? CustomerType { get; init; }
}
