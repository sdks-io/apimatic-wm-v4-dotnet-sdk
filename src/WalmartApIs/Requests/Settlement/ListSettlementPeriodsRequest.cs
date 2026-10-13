using WalmartApIs.Core.Validation.Attributes;

namespace WalmartApIs.Requests.Settlement;

/// <summary>
/// The inputs of the ListSettlementPeriods operation.
/// </summary>
public sealed record ListSettlementPeriodsRequest
{
    [Minimum(1)]
    [Maximum(100)]
    public int PageSize { get; init; } = 10;

    /// <summary>
    /// Opaque cursor from a prior response; omit for first page
    /// </summary>
    public string? NextToken { get; init; }
}
