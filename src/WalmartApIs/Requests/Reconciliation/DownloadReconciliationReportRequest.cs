using System.ComponentModel.DataAnnotations;

namespace WalmartApIs.Requests.Reconciliation;

/// <summary>
/// The inputs of the DownloadReconciliationReport operation.
/// </summary>
public sealed record DownloadReconciliationReportRequest
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
}
