namespace WalmartApIs.Requests.ReportSchedules;

/// <summary>
/// The inputs of the GetReportSchedule operation.
/// </summary>
public sealed record GetReportScheduleRequest
{
    public required string ReportScheduleId { get; init; }
}
