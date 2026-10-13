using WalmartApIs.Models;

namespace WalmartApIs.Requests.ProductPricing;

/// <summary>
/// The inputs of the GetItemOffersBatch operation.
/// </summary>
public sealed record GetItemOffersBatchOperationRequest
{
    public required GetItemOffersBatchRequest Body { get; init; }
}
