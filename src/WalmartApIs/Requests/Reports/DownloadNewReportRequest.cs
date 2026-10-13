using System.ComponentModel.DataAnnotations;

namespace WalmartApIs.Requests.Reports;

/// <summary>
/// The inputs of the DownloadNewReport operation.
/// </summary>
public sealed record DownloadNewReportRequest
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
