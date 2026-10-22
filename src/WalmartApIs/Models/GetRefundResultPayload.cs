using System.Collections.Generic;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;
using WalmartApIs.Models.Enums;

namespace WalmartApIs.Models;

public record GetRefundResultPayload
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
    /// Cumulative refunds rate
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("cumulativeRate")]
    public double? CumulativeRate { get; init; }

    /// <summary>
    /// Cumulative refunds rate trend
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("cumulativeRateTrend")]
    public CumulativeRateTrend6? CumulativeRateTrend { get; init; }

    /// <summary>
    /// gmvLoss incurred
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("gmvLoss")]
    public double? GmvLoss { get; init; }

    /// <summary>
    /// gmv Loss trend
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("gmvLossTrend")]
    public GmvLossTrend? GmvLossTrend { get; init; }

    /// <summary>
    /// Number of orders impacted
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("ordersImpacted")]
    public int? OrdersImpacted { get; init; }

    /// <summary>
    /// Impacted orders trend
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("ordersImpactedTrend")]
    public OrdersImpactedTrend? OrdersImpactedTrend { get; init; }

    /// <summary>
    /// Maximum allowed cumulative refund rate as per Walmart standards
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
    /// Seller accountable drivers, which impacting the refunds rate
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("sellerAccountableDrivers")]
    public SellerAccountableRefundsDrivers? SellerAccountableDrivers { get; init; }

    /// <summary>
    /// Non Accountable drivers, which impacting the refunds rate
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("nonAccountableDrivers")]
    public NonAccountableRefundsDrivers? NonAccountableDrivers { get; init; }

    /// <summary>
    /// recommendations insights
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("recommendations")]
    public IReadOnlyList<PerformanceRecommendation>? Recommendations { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
