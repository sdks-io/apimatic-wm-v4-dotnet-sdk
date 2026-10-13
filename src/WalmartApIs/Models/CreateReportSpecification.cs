using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;
using WalmartApIs.Models.Enums;

namespace WalmartApIs.Models;

public record CreateReportSpecification
{
    /// <summary>
    /// Report type — Walmart Partner Reporting Platform enum name. Runtime availability is CCM-controlled; consult PRP docs for current PROD-enabled types.
    /// </summary>
    [JsonPropertyName("reportType")]
    public required ReportType ReportType { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("dataStartTime")]
    public DateTimeOffset? DataStartTime { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("dataEndTime")]
    public DateTimeOffset? DataEndTime { get; init; }

    /// <summary>
    /// Additional report-type-specific options
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("reportOptions")]
    public IReadOnlyDictionary<string, string>? ReportOptions { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("marketplaceIds")]
    public IReadOnlyList<string>? MarketplaceIds { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
