using WalmartApIs.Models;

namespace WalmartApIs.Requests.ProductPricing;

/// <summary>
/// The inputs of the GetCompetitiveSummary operation.
/// </summary>
public sealed record GetCompetitiveSummaryRequest
{
    public required CompetitiveSummaryBatchRequest Body { get; init; }
}
