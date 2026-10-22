using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

public record WeeklyTrend
{
    /// <summary>
    /// Week of the year. Example: 24
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("week")]
    public string? Week { get; init; }

    /// <summary>
    /// Year of trend. Example: 2024
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("year")]
    public string? Year { get; init; }

    /// <summary>
    /// | Trend Type | Description | Data type of value |
    /// | --- | ----------- | ------- |
    /// | PRICE_TRENDS | Indicates the price of the item in the market specific currency for the given week and year. Example: 6.54 | double |
    /// | DEMAND_TRENDS | Normalised values to indicate relative demand for the recommendation for the given week. Example: 0.08 | double |
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("value")]
    public double? Value { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
