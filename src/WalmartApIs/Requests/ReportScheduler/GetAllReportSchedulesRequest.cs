using WalmartApIs.Models.Enums;

namespace WalmartApIs.Requests.ReportScheduler;

/// <summary>
/// The inputs of the GetAllReportSchedules operation.
/// </summary>
public sealed record GetAllReportSchedulesRequest
{
    /// <summary>
    /// Specifies the type of report to be generated. Example: ITEM for Item Report.
    /// </summary>
    public required ReportType10 ReportType { get; init; }

    /// <summary>
    /// Specifies the name of the Walmart service being called.
    /// </summary>
    public required string WmSvcName { get; init; }

    /// <summary>
    /// A unique ID which identifies each API call and used to track and debug issues; use a random generated GUID for this ID
    /// </summary>
    public required string WmQosCorrelationId { get; init; }

    /// <summary>
    /// Access token obtained from the Token API. This is required for authenticating requests to Walmart Marketplace APIs.
    /// </summary>
    public required string WmSecAccessToken { get; init; }
}
