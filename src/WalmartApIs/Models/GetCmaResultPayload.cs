using System.Collections.Generic;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;
using WalmartApIs.Models.Enums;

namespace WalmartApIs.Models;

public record GetCmaResultPayload
{
    /// <summary>
    /// Past number of days the metrics calculated
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("reportDuration")]
    public int? ReportDuration { get; init; }

    /// <summary>
    /// Timestamp when metrics are calculated in ISO format
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("updatedTimestamp")]
    public string? UpdatedTimestamp { get; init; }

    /// <summary>
    /// Cumulative carrier method accuracy
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("cumulativeAccuracy")]
    public double? CumulativeAccuracy { get; init; }

    /// <summary>
    /// Cumulative carrier method accuracy trend
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("cumulativeAccuracyTrend")]
    public CumulativeAccuracyTrend2? CumulativeAccuracyTrend { get; init; }

    /// <summary>
    /// Number of orders impacted
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("impactedOrderCount")]
    public int? ImpactedOrderCount { get; init; }

    /// <summary>
    /// Recommended Carrier method accuracy value
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("recommendedAccuracy")]
    public double? RecommendedAccuracy { get; init; }

    /// <summary>
    /// Individual carrier method accuracies
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("infractionDrivers")]
    public IReadOnlyDictionary<string, double>? InfractionDrivers { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
