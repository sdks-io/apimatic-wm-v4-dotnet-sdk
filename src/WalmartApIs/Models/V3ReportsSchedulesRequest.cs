using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

public record V3ReportsSchedulesRequest
{
    /// <summary>
    /// Defines the interval at which the report repeats based on the selected frequency.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("repeatsEvery")]
    public double? RepeatsEvery { get; init; }

    /// <summary>
    /// Specifies the hour of the day at which the schedule will be triggered. Allowed values are from 0 to 23, where 0 corresponds to 12:00 AM UTC and 23 corresponds to 11:00 PM UTC. The hour selection is based on the UTC timezone.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("hour")]
    public double? Hour { get; init; }

    /// <summary>
    /// Specifies the day of the month on which the schedule will be triggered.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("dayOfMonth")]
    public double? DayOfMonth { get; init; }

    /// <summary>
    /// Specifies the day of the week on which the schedule will be triggered. Allowed values are from 0 to 6, where 0 represents Monday and 6 represents Sunday.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("dayOfWeek")]
    public double? DayOfWeek { get; init; }

    /// <summary>
    /// Specifies the month in which the schedule will be triggered. Allowed values are from 1 to 12.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("monthOfYear")]
    public double? MonthOfYear { get; init; }

    /// <summary>
    /// Specifies the start date for the schedule. The date should be in a valid date format (Example: YYYY-MM-DD).
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("scheduleStartDate")]
    public string? ScheduleStartDate { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
