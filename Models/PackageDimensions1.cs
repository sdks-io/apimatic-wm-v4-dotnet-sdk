using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;
using WalmartApIs.Core.Validation.Attributes;
using WalmartApIs.Models.Enums;

namespace WalmartApIs.Models;

/// <summary>
/// Physical dimensions of a shipped package. All numeric values are
/// non-negative; unit enums avoid the unit-ambiguity bug that bit
/// gmp-orders-mono PayloadUtil pre-2024.
/// </summary>
public record PackageDimensions1
{
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("length")]
    [Minimum(0.0)]
    public double? Length { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("width")]
    [Minimum(0.0)]
    public double? Width { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("height")]
    [Minimum(0.0)]
    public double? Height { get; init; }

    [JsonPropertyName("dimensionUnit")]
    public CommonUnitOfMeasurement? DimensionUnit { get; init; } = CommonUnitOfMeasurement.In;

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("weight")]
    [Minimum(0.0)]
    public double? Weight { get; init; }

    [JsonPropertyName("weightUnit")]
    public WeightUnit? WeightUnit { get; init; } = WeightUnit.Lb;

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
