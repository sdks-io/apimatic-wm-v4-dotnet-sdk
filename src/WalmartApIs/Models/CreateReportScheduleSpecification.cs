using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;
using WalmartApIs.Models.Enums;

namespace WalmartApIs.Models;

public record CreateReportScheduleSpecification
{
    [JsonPropertyName("reportType")]
    public required string ReportType { get; init; }

    [JsonPropertyName("period")]
    public required Period1 Period { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("marketplaceIds")]
    public IReadOnlyList<string>? MarketplaceIds { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("reportOptions")]
    public IReadOnlyDictionary<string, string>? ReportOptions { get; init; }

    /// <summary>
    /// When to first run the schedule (default now)
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("nextReportCreationTime")]
    public DateTimeOffset? NextReportCreationTime { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
