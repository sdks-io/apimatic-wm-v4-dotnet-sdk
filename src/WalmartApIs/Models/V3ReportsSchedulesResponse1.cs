using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;
using WalmartApIs.Models.Enums;

namespace WalmartApIs.Models;

public record V3ReportsSchedulesResponse1
{
    /// <summary>
    /// Unique identifier for the schedule.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("scheduleId")]
    public string? ScheduleId { get; init; }

    /// <summary>
    /// The timestamp (date and time) indicating when the report request was submitted.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("requestSubmissionDate")]
    public string? RequestSubmissionDate { get; init; }

    /// <summary>
    /// Specifies the type of report to be generated. Example: ITEM for Item Report.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("reportType")]
    public ReportType11? ReportType { get; init; }

    /// <summary>
    /// Specifies the version of report for which the request is created. Example: v1.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("reportVersion")]
    public string? ReportVersion { get; init; }

    /// <summary>
    /// Provides a brief summary of the report.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("reportSummary")]
    public string? ReportSummary { get; init; }

    /// <summary>
    /// Specifies the start date for the schedule. The date should be in a valid date format (Example: YYYY-MM-DD).
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("scheduleStartDate")]
    public string? ScheduleStartDate { get; init; }

    /// <summary>
    /// The next scheduled time for the report.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("nextScheduledTime")]
    public string? NextScheduledTime { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("payload")]
    public Payload61? Payload { get; init; }

    /// <summary>
    /// The date and time when the report schedule was last modified.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("requestModifiedTime")]
    public string? RequestModifiedTime { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
