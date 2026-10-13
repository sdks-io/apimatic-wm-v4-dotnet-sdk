using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WalmartApIs.Core.Validation.Attributes;
using WalmartApIs.Models.Enums;

namespace WalmartApIs.Requests.Catalog;

/// <summary>
/// The inputs of the SearchCatalogItems operation.
/// </summary>
public sealed record SearchCatalogItemsRequest
{
    /// <summary>
    /// Walmart marketplace identifiers. Use WALMART_US for the US marketplace.
    /// </summary>
    [MaxLength(1)]
    public required IReadOnlyList<string> MarketplaceIds { get; init; }

    /// <summary>
    /// Keyword search terms
    /// </summary>
    [MaxLength(500)]
    public string? Keywords { get; init; }

    /// <summary>
    /// Comma-separated Walmart Item IDs (14-digit). Max 20.
    /// </summary>
    public string? WalmartItemIds { get; init; }

    /// <summary>
    /// Seller-defined SKU
    /// </summary>
    [MaxLength(50)]
    public string? SellerSku { get; init; }

    /// <summary>
    /// Global Trade Item Number (14-digit)
    /// </summary>
    [RegularExpression("^\\d{14}$")]
    public string? Gtin { get; init; }

    /// <summary>
    /// Universal Product Code (12-digit)
    /// </summary>
    [RegularExpression("^\\d{12}$")]
    public string? Upc { get; init; }

    /// <summary>
    /// Data sections to include in the response
    /// </summary>
    public IReadOnlyList<IncludedDatum>? IncludedData { get; init; }

    /// <summary>
    /// Number of results per page (1–20).
    /// <b>Known limitation:</b> The PIQS keyword search backend hard-caps results at 40 items per call regardless of this value.
    /// </summary>
    [Minimum(1)]
    [Maximum(20)]
    public int PageSize { get; init; } = 10;

    /// <summary>
    /// Token for the next page of results, obtained from <c>pagination.nextToken</c> in a previous response.
    /// <b>Known limitation:</b> Cursor-based pagination is not currently supported for keyword search. The PIQS search backend (<c>/v3/items/walmart/search</c>) does not return a <c>nextCursor</c> and does not honour this parameter. Results are capped at 40 items per call. Reserved for future use once PIQS exposes pagination support.
    /// </summary>
    public string? PageToken { get; init; }
}
