using System.Collections.Generic;
using WalmartApIs.Models.Enums;

namespace WalmartApIs.Requests.ReportSchedules;

/// <summary>
/// The inputs of the GetReportSchedules operation.
/// </summary>
public sealed record GetReportSchedulesRequest
{
    /// <summary>
    /// Filter by report type. Values are Walmart Partner Reporting Platform enum names. Runtime availability is CCM-controlled; consult PRP docs for current PROD-enabled types.
    /// </summary>
    public IReadOnlyList<ReportType1>? ReportTypes { get; init; }
}
