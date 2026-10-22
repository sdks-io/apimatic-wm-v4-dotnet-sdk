using System.Collections.Generic;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

public record Trend
{
    /// <summary>
    /// Type of trend.
    /// <para>
    ///  Values: DEMAND_TRENDS, PRICE_TRENDS
    /// </para>
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("trendType")]
    public string? TrendType { get; init; }

    /// <summary>
    /// Trend data for the recommended item. The array will be empty if trends are not available for the item.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("trendData")]
    public IReadOnlyList<TrendDatum>? TrendData { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
