using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

public record MonthlyTrend
{
    /// <summary>
    /// Month of the year.
    /// <para>
    ///  Values: JAN, FEB, MAR, APR, MAY, JUN, JUL, AUG, SEP, OCT, NOV, DEC
    /// </para>
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("month")]
    public string? Month { get; init; }

    /// <summary>
    /// Year of trend.
    /// <para>
    ///  Example: 2024
    /// </para>
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("year")]
    public string? Year { get; init; }

    /// <summary>
    /// | Trend Type | Description | Data type of value |
    /// | --- | ----------- | ------- |
    /// | PRICE_TRENDS | Indicates the price of the item in the market specific currency for the given month and year. Example: 5.99 | double |
    /// | DEMAND_TRENDS | Normalised values to indicate relative demand for the recommendation for the given month. Example: 0.07 | double |
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("value")]
    public double? Value { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
