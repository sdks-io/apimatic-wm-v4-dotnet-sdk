namespace WalmartApIs.Requests.ReportScheduler;

/// <summary>
/// The inputs of the DeleteReportSchedule operation.
/// </summary>
public sealed record DeleteReportScheduleRequest
{
    /// <summary>
    /// A unique identifier assigned to the report schedule.
    /// </summary>
    public required string ScheduleId { get; init; }

    /// <summary>
    /// Specifies the name of the Walmart service being called.
    /// </summary>
    public required string WmSvcName { get; init; }

    /// <summary>
    /// A unique ID which identifies each API call and used to track and debug issues; use a random generated GUID for this ID
    /// </summary>
    public required string WmQosCorrelationId { get; init; }
}
