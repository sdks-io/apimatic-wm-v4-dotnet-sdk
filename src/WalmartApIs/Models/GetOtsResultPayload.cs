using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;
using WalmartApIs.Models.Enums;

namespace WalmartApIs.Models;

public record GetOtsResultPayload
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
    /// Cumulative on time shipment rate
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("cumulativeRate")]
    public double? CumulativeRate { get; init; }

    /// <summary>
    /// Cumulative on time shipment rate trend
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("cumulativeRateTrend")]
    public CumulativeRateTrend2? CumulativeRateTrend { get; init; }

    /// <summary>
    /// Number of orders impacted
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("impactedOrderCount")]
    public int? ImpactedOrderCount { get; init; }

    /// <summary>
    /// Recommended on time shipment rate value
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("recommendedRate")]
    public double? RecommendedRate { get; init; }

    /// <summary>
    /// Individual drivers of on time shipment rate
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("infractionDrivers")]
    public OtsInfractionDrivers? InfractionDrivers { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
