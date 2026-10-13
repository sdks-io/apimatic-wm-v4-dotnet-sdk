using WalmartApIs.Models;

namespace WalmartApIs.Requests.ProductFees;

/// <summary>
/// The inputs of the GetMyFeesEstimateForSku operation.
/// </summary>
public sealed record GetMyFeesEstimateForSkuRequest
{
    /// <summary>
    /// The seller's SKU for the listing. Scoped to the authenticated seller.
    /// </summary>
    public required string SellerSku { get; init; }

    /// <summary>
    /// Marketplace identifier.
    /// </summary>
    public required string MarketplaceId { get; init; }

    public required GetMyFeesEstimateRequest Body { get; init; }
}
