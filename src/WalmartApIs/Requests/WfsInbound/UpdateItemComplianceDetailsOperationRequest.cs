using WalmartApIs.Models;

namespace WalmartApIs.Requests.WfsInbound;

/// <summary>
/// The inputs of the UpdateItemComplianceDetails operation.
/// </summary>
public sealed record UpdateItemComplianceDetailsOperationRequest
{
    /// <summary>
    /// The Walmart Marketplace ID. For a list of possible values, refer to <see href="https://developer-docs.walmart.com/seller-api/docs/marketplace-ids">Marketplace IDs</see>.
    /// </summary>
    public required string MarketplaceId { get; init; }

    public required UpdateItemComplianceDetailsRequest Body { get; init; }
}
