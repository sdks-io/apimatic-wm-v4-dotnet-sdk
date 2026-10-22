using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

public record TotalInsight
{
    /// <summary>
    /// Estimated total dollar amount you could lose in sales each day if both out-of-stock and at-risk items are not restocked.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("totalEstimatedSalesLift")]
    public double? TotalEstimatedSalesLift { get; init; }

    /// <summary>
    /// Estimated dollar amount you could lose in sales each day if all out-of-stock items are not restocked.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("totalForecastedSalesLost")]
    public double? TotalForecastedSalesLost { get; init; }

    /// <summary>
    /// Estimated dollar amount you could lose in daily sales if all items with under 4 weeks of supply are not restocked.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("totalForecastedSalesAtRisk")]
    public double? TotalForecastedSalesAtRisk { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
