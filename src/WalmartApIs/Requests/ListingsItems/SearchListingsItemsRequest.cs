using System.Collections.Generic;
using WalmartApIs.Core.Validation.Attributes;
using WalmartApIs.Models.Enums;

namespace WalmartApIs.Requests.ListingsItems;

/// <summary>
/// The inputs of the SearchListingsItems operation.
/// </summary>
public sealed record SearchListingsItemsRequest
{
    /// <summary>
    /// Seller identifier
    /// </summary>
    public required string SellerId { get; init; }

    public required IReadOnlyList<string> MarketplaceIds { get; init; }

    public IReadOnlyList<IncludedDatum1>? IncludedData { get; init; }

    /// <summary>
    /// Maximum number of results per page
    /// </summary>
    [Minimum(1)]
    [Maximum(20)]
    public int PageSize { get; init; } = 10;

    /// <summary>
    /// Opaque cursor returned by a previous call for the next page
    /// </summary>
    public string? PageToken { get; init; }
}
