using WalmartApIs.Models;

namespace WalmartApIs.Requests.ReportSchedules;

/// <summary>
/// The inputs of the CreateReportSchedule operation.
/// </summary>
public sealed record CreateReportScheduleRequest
{
    public required CreateReportScheduleSpecification Body { get; init; }
}
