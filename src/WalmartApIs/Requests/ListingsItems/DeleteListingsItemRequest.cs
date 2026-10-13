using System.Collections.Generic;

namespace WalmartApIs.Requests.ListingsItems;

/// <summary>
/// The inputs of the DeleteListingsItem operation.
/// </summary>
public sealed record DeleteListingsItemRequest
{
    /// <summary>
    /// Seller identifier
    /// </summary>
    public required string SellerId { get; init; }

    /// <summary>
    /// Seller SKU identifying the listing
    /// </summary>
    public required string Sku { get; init; }

    public required IReadOnlyList<string> MarketplaceIds { get; init; }

    public string IssueLocale { get; init; } = "en_US";
}
