namespace WalmartApIs.Requests.Reports;

/// <summary>
/// The inputs of the CancelReport operation.
/// </summary>
public sealed record CancelReportRequest
{
    public required string ReportId { get; init; }
}
