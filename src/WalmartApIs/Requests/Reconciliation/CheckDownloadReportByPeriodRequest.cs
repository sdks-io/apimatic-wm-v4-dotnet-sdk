using System;
using System.ComponentModel.DataAnnotations;

namespace WalmartApIs.Requests.Reconciliation;

/// <summary>
/// The inputs of the CheckDownloadReportByPeriod operation.
/// </summary>
public sealed record CheckDownloadReportByPeriodRequest
{
    /// <summary>
    /// Numeric partner/seller ID
    /// </summary>
    [RegularExpression("^[0-9]{1,50}$")]
    public required string PartnerId { get; init; }

    /// <summary>
    /// Report date in yyyy-MM-dd format
    /// </summary>
    public required DateTimeOffset Date { get; init; }
}
