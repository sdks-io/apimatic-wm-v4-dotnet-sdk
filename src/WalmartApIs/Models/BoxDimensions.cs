using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;
using WalmartApIs.Core.Validation.Attributes;
using WalmartApIs.Models.Enums;

namespace WalmartApIs.Models;

/// <summary>
/// Dimensions and weight for a shipping package.
/// </summary>
public record BoxDimensions
{
    /// <summary>
    /// Length of the package. Required when packageType is CUSTOM_PACKAGE; not required for other standard package types (e.g., FEDEX_ENVELOPE, FEDEX_PAK) where dimensions are predetermined by the carrier. The Unit is determined by boxDimensionUnit.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("boxLength")]
    [Minimum(0.0)]
    public double? BoxLength { get; init; }

    /// <summary>
    /// Width of the package. Required when packageType is CUSTOM_PACKAGE; not required for other standard package types (e.g., FEDEX_ENVELOPE, FEDEX_PAK) where dimensions are predetermined by the carrier. The Unit is determined by boxDimensionUnit.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("boxWidth")]
    [Minimum(0.0)]
    public double? BoxWidth { get; init; }

    /// <summary>
    /// Height of the package. Required when packageType is CUSTOM_PACKAGE; not required for other standard package types (e.g., FEDEX_ENVELOPE, FEDEX_PAK) where dimensions are predetermined by the carrier. The Unit is determined by boxDimensionUnit.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("boxHeight")]
    [Minimum(0.0)]
    public double? BoxHeight { get; init; }

    /// <summary>
    /// Weight of the package. Required for all package types. The Unit is determined by boxWeightUnit.
    /// </summary>
    [JsonPropertyName("boxWeight")]
    public required double BoxWeight { get; init; }

    /// <summary>
    /// Unit of measurement for the package length, width, and height. Allowed values: IN (inches), FT (feet), CM (centimeters).
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("boxDimensionUnit")]
    public BoxDimensionUnit? BoxDimensionUnit { get; init; }

    /// <summary>
    /// Unit of measurement for the package weight. Allowed values: LB (pounds), KG (kilograms), OZ (ounces).
    /// </summary>
    [JsonPropertyName("boxWeightUnit")]
    public required BoxWeightUnit BoxWeightUnit { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
