using System.Collections.Generic;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;
using WalmartApIs.Models.Enums;

namespace WalmartApIs.Models;

public record GetOtdResultPayload
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
    /// shipping methods used to calculate these metrics
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("shippingMethod")]
    public ShippingMethod? ShippingMethod { get; init; }

    /// <summary>
    /// Overall ontime delivery rate
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("overallRate")]
    public double? OverallRate { get; init; }

    /// <summary>
    /// Overall On Time Delivery trand
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("overallTrend")]
    public OverallTrend? OverallTrend { get; init; }

    /// <summary>
    /// Seller accountable ontime delivery rate
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("sellerAccountableRate")]
    public double? SellerAccountableRate { get; init; }

    /// <summary>
    /// Seller accountable On Time Delivery rate trend
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("sellerAccountableTrend")]
    public SellerAccountableTrend? SellerAccountableTrend { get; init; }

    /// <summary>
    /// Number of customers impacted
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("impactedCustomerCount")]
    public int? ImpactedCustomerCount { get; init; }

    /// <summary>
    /// Minimum seller accountable on time delivery rate required as per Walmart standards
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
    /// Seller accountable drivers, which impacting the on time delivery rate
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("sellerAccountableDrivers")]
    public SellerAccountableOtdDrivers? SellerAccountableDrivers { get; init; }

    /// <summary>
    /// Non Accountable drivers, which impacting the on time delivery rate
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("nonAccountableDrivers")]
    public NonAccountableOtdDrivers? NonAccountableDrivers { get; init; }

    /// <summary>
    /// Recommendations to improve the On Time Delivery rate
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("recommendations")]
    public IReadOnlyList<PerformanceRecommendation>? Recommendations { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
