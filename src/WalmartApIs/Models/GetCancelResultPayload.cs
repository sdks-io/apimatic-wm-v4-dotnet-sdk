using System.Collections.Generic;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;
using WalmartApIs.Models.Enums;

namespace WalmartApIs.Models;

public record GetCancelResultPayload
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
    /// Cumulative rate of orders cancelled
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("cumulativeRate")]
    public double? CumulativeRate { get; init; }

    /// <summary>
    /// Cumulative rate of orders cancelled trend
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("cumulativeRateTrend")]
    public CumulativeRateTrend8? CumulativeRateTrend { get; init; }

    /// <summary>
    /// gmvLoss incurred
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("gmvLoss")]
    public double? GmvLoss { get; init; }

    /// <summary>
    /// Number of orders impacted
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("ordersImpacted")]
    public int? OrdersImpacted { get; init; }

    /// <summary>
    /// Maximum allowed cumulative cancellations rate as per Walmart standards
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("standard")]
    public string? Standard { get; init; }

    /// <summary>
    /// Risk level as per Walmart standards
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("riskLevel")]
    public RiskLevel? RiskLevel { get; init; }

    /// <summary>
    /// Seller accountable drivers, which impacting the cancellations rate
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("sellerAccountableDrivers")]
    public SellerAccountableCancellationsDrivers? SellerAccountableDrivers { get; init; }

    /// <summary>
    /// Non Accountable drivers, which impacting the cancellations rate
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("nonAccountableDrivers")]
    public NonAccountableCancellationsDrivers? NonAccountableDrivers { get; init; }

    /// <summary>
    /// Recommendations to decrease the cancellation rate
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("recommendations")]
    public IReadOnlyList<PerformanceRecommendation>? Recommendations { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
