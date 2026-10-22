using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;
using WalmartApIs.Models.Enums;

namespace WalmartApIs.Models;

/// <summary>
/// Box Dimensions
/// </summary>
public record BoxDimensions4
{
    /// <summary>
    /// Box Dimension Unit [CM, IN]. Mandatory for CUSTOM_PACKAGE type, otherwise not required. &lt;br/&gt;&lt;b&gt;Applicable to SWW and WPS.&lt;/span&gt;&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("boxDimensionUnit")]
    public BoxDimensionUnit4? BoxDimensionUnit { get; init; }

    /// <summary>
    /// Box Weight Unit [LB, KG]. &lt;br/&gt;&lt;b&gt;Applicable to SWW and WPS.&lt;/span&gt;&lt;/b&gt;
    /// </summary>
    [JsonPropertyName("boxWeightUnit")]
    public required BoxWeightUnit4 BoxWeightUnit { get; init; }

    /// <summary>
    /// Box Weight. &lt;br/&gt;&lt;b&gt;Applicable to SWW and WPS.&lt;/span&gt;&lt;/b&gt;
    /// </summary>
    [JsonPropertyName("boxWeight")]
    public required double BoxWeight { get; init; }

    /// <summary>
    /// Box Length. Mandatory for CUSTOM_PACKAGE type, otherwise not required. &lt;br/&gt;&lt;b&gt;Applicable to SWW and WPS.&lt;/span&gt;&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("boxLength")]
    public double? BoxLength { get; init; }

    /// <summary>
    /// Box Width. Mandatory for CUSTOM_PACKAGE type, otherwise not required. &lt;br/&gt;&lt;b&gt;Applicable to SWW and WPS.&lt;/span&gt;&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("boxWidth")]
    public double? BoxWidth { get; init; }

    /// <summary>
    /// Box Height. Mandatory for CUSTOM_PACKAGE type, otherwise not required. &lt;br/&gt;&lt;b&gt;Applicable to SWW and WPS.&lt;/span&gt;&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("boxHeight")]
    public double? BoxHeight { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
