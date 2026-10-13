using WalmartApIs.Models;

namespace WalmartApIs.Requests.ProductPricing;

/// <summary>
/// The inputs of the GetListingOffersBatch operation.
/// </summary>
public sealed record GetListingOffersBatchOperationRequest
{
    public required GetListingOffersBatchRequest Body { get; init; }
}
