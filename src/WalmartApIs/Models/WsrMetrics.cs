using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// Performance metrics for the aggregated data.
/// <para>
/// All metrics are based on last-touch attribution with a 14-day window.
/// </para>
/// </summary>
public record WsrMetrics
{
    /// <summary>
    /// Number of clicks on affiliate links.
    /// Defaults to 0 if no traffic data available.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("clicks")]
    public int? Clicks { get; init; }

    /// <summary>
    /// Number of orders based on last-touch 14-day attribution.
    /// Defaults to 0 if no attribution data available.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("orders")]
    public int? Orders { get; init; } = 0;

    /// <summary>
    /// Gross Merchandise Value (GMV) in USD based on last-touch 14-day attribution.
    /// This represents the total revenue generated from orders attributed to affiliate links.
    /// Defaults to 0.0 if no attribution data available.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("gmv")]
    public double? Gmv { get; init; } = 0d;

    /// <summary>
    /// Commission earned from Walmart Seller Referral (WSR) program in USD.
    /// This is the primary commission earned through the affiliate program.
    /// Defaults to 0.0 if no commission data available.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("wsrCommission")]
    public double? WsrCommission { get; init; } = 0d;

    /// <summary>
    /// Commission earned from other promotional programs in USD.
    /// This includes any additional commissions beyond the WSR program.
    /// Defaults to 0.0 if no commission data available.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("otherCommission")]
    public double? OtherCommission { get; init; } = 0d;

    /// <summary>
    /// Total number of units sold based on last-touch 14-day attribution.
    /// Defaults to 0 if no attribution data available.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("totalUnits")]
    public int? TotalUnits { get; init; } = 0;

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
