using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;
using WalmartApIs.Core.Validation.Attributes;

namespace WalmartApIs.Models;

/// <summary>
/// Demand intelligence and replenishment recommendations (WFS-only — no SP-API equivalent)
/// </summary>
public record WfsInventoryInsights
{
    /// <summary>
    /// Estimated units to sell in weeks 1–4.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("salesForecastWeek1to4")]
    public double? SalesForecastWeek1To4 { get; init; }

    /// <summary>
    /// Estimated units to sell in weeks 5–8.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("salesForecastWeek5to8")]
    public double? SalesForecastWeek5To8 { get; init; }

    /// <summary>
    /// Estimated units to sell in weeks 9–12.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("salesForecastWeek9to12")]
    public double? SalesForecastWeek9To12 { get; init; }

    /// <summary>
    /// Units shipped ÷ average stored, last 90 days.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("sellThroughRate")]
    public double? SellThroughRate { get; init; }

    /// <summary>
    /// Estimated days until stock exhaustion at current sell rate
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("daysOfSupply")]
    public string? DaysOfSupply { get; init; }

    /// <summary>
    /// Projected date of stock exhaustion
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("outOfStockDate")]
    public DateTimeOffset? OutOfStockDate { get; init; }

    /// <summary>
    /// Walmart-recommended reorder quantity
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("suggestedUnits")]
    [Minimum(0)]
    public int? SuggestedUnits { get; init; }

    /// <summary>
    /// Units exceeding 180 days of supply
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("surplusUnits")]
    [Minimum(0)]
    public int? SurplusUnits { get; init; }

    /// <summary>
    /// Whether this item is flagged as a customer favorite
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("customerFavorite")]
    public bool? CustomerFavorite { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
