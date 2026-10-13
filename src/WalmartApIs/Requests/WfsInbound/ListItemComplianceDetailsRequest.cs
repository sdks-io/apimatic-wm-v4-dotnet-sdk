using System.Collections.Generic;

namespace WalmartApIs.Requests.WfsInbound;

/// <summary>
/// The inputs of the ListItemComplianceDetails operation.
/// </summary>
public sealed record ListItemComplianceDetailsRequest
{
    /// <summary>
    /// A list of merchant SKUs, a merchant-supplied identifier of a specific SKU.
    /// </summary>
    public required IReadOnlyList<string> Mskus { get; init; }

    /// <summary>
    /// The Walmart Marketplace ID. For a list of possible values, refer to <see href="https://developer-docs.walmart.com/seller-api/docs/marketplace-ids">Marketplace IDs</see>.
    /// </summary>
    public required string MarketplaceId { get; init; }
}
