using System.Collections.Generic;
using WalmartApIs.Models;

namespace WalmartApIs.Requests.ListingsItems;

/// <summary>
/// The inputs of the PutListingsItem operation.
/// </summary>
public sealed record PutListingsItemRequest
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

    public required ListingsItemPutRequest Body { get; init; }
}
