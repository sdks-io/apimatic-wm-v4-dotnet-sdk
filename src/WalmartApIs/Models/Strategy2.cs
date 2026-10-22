using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;
using WalmartApIs.Models.Enums;

namespace WalmartApIs.Models;

public record Strategy2
{
    /// <summary>
    /// Strategy type supported for markets is Buy Box Price(for us and mx), External Price(for US, MX and CA), Competitive Price(for us and mx).&lt;br&gt;&lt;b style="color:green;"&gt;Market availability: US | CA | MX&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("strategyType")]
    public StrategyType? StrategyType { get; init; }

    /// <summary>
    /// Specifies how price adjustment is applied. UNIT for a fixed amount or PERCENTAGE for a percentage-based change.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US | CA | MX&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("adjustmentType")]
    public AdjustmentType2? AdjustmentType { get; init; }

    /// <summary>
    /// Defines the value by which price is adjusted, based on the selected adjustment value.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US | CA | MX&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("adjustmentValue")]
    public double? AdjustmentValue { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
