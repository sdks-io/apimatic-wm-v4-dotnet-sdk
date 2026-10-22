using System.Collections.Generic;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

public record TrendDatum
{
    /// <summary>
    /// Meta information related to the trends response.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("meta")]
    public Meta9? Meta { get; init; }

    /// <summary>
    /// Trend data at a monthly level.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("monthlyTrends")]
    public IReadOnlyList<MonthlyTrend>? MonthlyTrends { get; init; }

    /// <summary>
    /// Trend data at a weekly level.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US only&lt;/span&gt;&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("weeklyTrends")]
    public IReadOnlyList<WeeklyTrend>? WeeklyTrends { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
