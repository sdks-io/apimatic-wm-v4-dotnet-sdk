using WalmartApIs.Models;

namespace WalmartApIs.Requests.ProductPricing;

/// <summary>
/// The inputs of the GetFeaturedOfferExpectedPriceBatch operation.
/// </summary>
public sealed record GetFeaturedOfferExpectedPriceBatchOperationRequest
{
    public required GetFeaturedOfferExpectedPriceBatchRequest Body { get; init; }
}
