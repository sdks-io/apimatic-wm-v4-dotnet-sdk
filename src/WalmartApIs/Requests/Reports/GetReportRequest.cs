namespace WalmartApIs.Requests.Reports;

/// <summary>
/// The inputs of the GetReport operation.
/// </summary>
public sealed record GetReportRequest
{
    public required string ReportId { get; init; }
}
