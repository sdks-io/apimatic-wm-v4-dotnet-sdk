using System.Collections.Generic;
using WalmartApIs.Models.Enums;

namespace WalmartApIs.Requests.ListingsItems;

/// <summary>
/// The inputs of the GetListingsItem operation.
/// </summary>
public sealed record GetListingsItemRequest
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

    /// <summary>
    /// Locale for issue messages (e.g. en_US)
    /// </summary>
    public string IssueLocale { get; init; } = "en_US";

    public IReadOnlyList<IncludedDatum1>? IncludedData { get; init; }
}
