namespace WalmartApIs.Requests.Reports;

/// <summary>
/// The inputs of the GetReportDocument operation.
/// </summary>
public sealed record GetReportDocumentRequest
{
    public required string ReportDocumentId { get; init; }
}
