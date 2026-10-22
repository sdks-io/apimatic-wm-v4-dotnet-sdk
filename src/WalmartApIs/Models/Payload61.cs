using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;
using WalmartApIs.Models.Enums;

namespace WalmartApIs.Models;

public record Payload61
{
    /// <summary>
    /// Specifies the day of the month on which the schedule will be triggered.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("dayOfMonth")]
    public double? DayOfMonth { get; init; }

    /// <summary>
    /// Specifies the month in which the schedule will be triggered. Allowed values are from 1 to 12.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("monthOfYear")]
    public double? MonthOfYear { get; init; }

    /// <summary>
    /// Specifies the day of the week on which the schedule will be triggered. Allowed values are from 0 to 6, where 0 represents Monday and 6 represents Sunday.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("dayOfWeek")]
    public double? DayOfWeek { get; init; }

    /// <summary>
    /// Specifies the hour of the day at which the schedule will be triggered. Allowed values are from 0 to 23, where 0 corresponds to 12:00 AM UTC and 23 corresponds to 11:00 PM UTC. The hour selection is based on the UTC timezone.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("hour")]
    public double? Hour { get; init; }

    /// <summary>
    /// Specifies the frequency at which the report should be generated. For example, if set to YEARLY, the report will be generated once every year.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("frequency")]
    public Frequency? Frequency { get; init; }

    /// <summary>
    /// Defines the interval at which the report repeats based on the selected frequency.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("repeatsEvery")]
    public double? RepeatsEvery { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("filters")]
    public Filters? Filters { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
