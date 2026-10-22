using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// Post Purchase Quality
/// </summary>
public record PostPurchaseQuality
{
    /// <summary>
    /// Defect Ratio
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("defectRatio")]
    public int? DefectRatio { get; init; }

    /// <summary>
    /// Item Defect Count
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("itemDefectCnt")]
    public int? ItemDefectCnt { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
