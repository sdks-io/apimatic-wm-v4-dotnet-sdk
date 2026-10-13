namespace WalmartApIs.Requests.ReportSchedules;

/// <summary>
/// The inputs of the CancelReportSchedule operation.
/// </summary>
public sealed record CancelReportScheduleRequest
{
    public required string ReportScheduleId { get; init; }
}
