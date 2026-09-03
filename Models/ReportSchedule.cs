using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;
using WalmartApIs.Models.Enums;

namespace WalmartApIs.Models;

public record ReportSchedule
{
    [JsonPropertyName("reportScheduleId")]
    public required string ReportScheduleId { get; init; }

    [JsonPropertyName("reportType")]
    public required string ReportType { get; init; }

    /// <summary>
    /// ISO 8601 duration for schedule recurrence
    /// </summary>
    [JsonPropertyName("period")]
    public required Period Period { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("nextReportCreationTime")]
    public DateTimeOffset? NextReportCreationTime { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
