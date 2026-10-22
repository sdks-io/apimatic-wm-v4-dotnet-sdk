using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;
using WalmartApIs.Core.Validation.Attributes;
using WalmartApIs.Models.Enums;

namespace WalmartApIs.Models;

public record BoxDimensions2
{
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("boxLength")]
    [Minimum(0.0)]
    public double? BoxLength { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("boxWidth")]
    [Minimum(0.0)]
    public double? BoxWidth { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("boxHeight")]
    [Minimum(0.0)]
    public double? BoxHeight { get; init; }

    [JsonPropertyName("boxWeight")]
    public required double BoxWeight { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("boxDimensionUnit")]
    public BoxDimensionUnit2? BoxDimensionUnit { get; init; }

    [JsonPropertyName("boxWeightUnit")]
    public required BoxWeightUnit2 BoxWeightUnit { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
