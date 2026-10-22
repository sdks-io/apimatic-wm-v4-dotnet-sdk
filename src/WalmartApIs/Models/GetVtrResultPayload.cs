using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;
using WalmartApIs.Models.Enums;

namespace WalmartApIs.Models;

public record GetVtrResultPayload
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
    /// Cumulative valid tracking rate
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("cumulativeRate")]
    public double? CumulativeRate { get; init; }

    /// <summary>
    /// Cumulative valid tracking rate trend
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("cumulativeRateTrend")]
    public CumulativeRateTrend? CumulativeRateTrend { get; init; }

    /// <summary>
    /// Number of customers impacted
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("impactedCustomerCount")]
    public int? ImpactedCustomerCount { get; init; }

    /// <summary>
    /// Minimum seller accountable valid tracking rate required as per Walmart standards
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
    /// Seller accountable drivers, which impacting the valid tracking rate
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("sellerAccountableDrivers")]
    public SellerAccountableVtrDrivers? SellerAccountableDrivers { get; init; }

    /// <summary>
    /// Non Accountable drivers, which impacting the valid tracking rate
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("nonAccountableDrivers")]
    public NonAccountableVtrDrivers? NonAccountableDrivers { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
