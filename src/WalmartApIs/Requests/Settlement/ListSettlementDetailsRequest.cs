using System.ComponentModel.DataAnnotations;
using WalmartApIs.Core.Validation.Attributes;

namespace WalmartApIs.Requests.Settlement;

/// <summary>
/// The inputs of the ListSettlementDetails operation.
/// </summary>
public sealed record ListSettlementDetailsRequest
{
    /// <summary>
    /// Numeric partner/seller ID
    /// </summary>
    [RegularExpression("^[0-9]{1,50}$")]
    public required string PartnerId { get; init; }

    /// <summary>
    /// Report date in MMddyyyy format (e.g. 06172026)
    /// </summary>
    public required string ReportDate { get; init; }

    [Minimum(1)]
    [Maximum(100)]
    public int PageSize { get; init; } = 10;

    /// <summary>
    /// Opaque cursor from a prior response; omit for first page
    /// </summary>
    public string? NextToken { get; init; }
}
