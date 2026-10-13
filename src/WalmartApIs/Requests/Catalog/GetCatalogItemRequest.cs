using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WalmartApIs.Models.Enums;

namespace WalmartApIs.Requests.Catalog;

/// <summary>
/// The inputs of the GetCatalogItem operation.
/// </summary>
public sealed record GetCatalogItemRequest
{
    /// <summary>
    /// Walmart Item ID (14-digit numeric identifier)
    /// </summary>
    [RegularExpression("^\\d{14}$")]
    public required string WalmartItemId { get; init; }

    /// <summary>
    /// Walmart marketplace identifiers. Use WALMART_US for the US marketplace.
    /// </summary>
    [MaxLength(1)]
    public required IReadOnlyList<string> MarketplaceIds { get; init; }

    /// <summary>
    /// Data sections to include in the response
    /// </summary>
    public IReadOnlyList<IncludedDatum>? IncludedData { get; init; }
}
