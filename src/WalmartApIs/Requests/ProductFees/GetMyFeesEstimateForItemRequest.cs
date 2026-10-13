using WalmartApIs.Models;

namespace WalmartApIs.Requests.ProductFees;

/// <summary>
/// The inputs of the GetMyFeesEstimateForItem operation.
/// </summary>
public sealed record GetMyFeesEstimateForItemRequest
{
    /// <summary>
    /// The Walmart Item ID of the item. Replaces SP-API ASIN.
    /// </summary>
    public required string WalmartItemId { get; init; }

    public required GetMyFeesEstimateRequest Body { get; init; }
}
