using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;
using WalmartApIs.Core.Validation.Attributes;
using WalmartApIs.Models.Enums;

namespace WalmartApIs.Models;

/// <summary>
/// Dimensions and weight of the package being shipped. Used together with packageType. For FEDEX_PAK or FEDEX_ENVELOPE, length/height/width are predetermined by the carrier and only weight is required. For CUSTOM_PACKAGE, all dimensions and weight are required.
/// <para>
/// &lt;b style="color: green;"&gt;Market availability: Global&lt;/b&gt;
/// </para>
/// </summary>
public record BoxDimensions3
{
    /// <summary>
    /// The length of the package. Required when packageType is CUSTOM_PACKAGE, not required for other standard package types (Example: FEDEX_ENVELOPE, FEDEX_PAK) where dimensions are predetermined by the carrier. The Unit is determined by boxDimensionUnit.
    /// <para>
    /// &lt;b style="color: green;"&gt;Market availability: Global&lt;/b&gt;
    /// </para>
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("boxLength")]
    [Minimum(0.0)]
    public double? BoxLength { get; init; }

    /// <summary>
    /// The width of the package. Required when packageType is CUSTOM_PACKAGE; not required for other standard package types (Example: FEDEX_ENVELOPE, FEDEX_PAK) where dimensions are predetermined by the carrier. The Unit is determined by boxDimensionUnit.
    /// <para>
    /// &lt;b style="color: green;"&gt;Market availability: Global&lt;/b&gt;
    /// </para>
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("boxWidth")]
    [Minimum(0.0)]
    public double? BoxWidth { get; init; }

    /// <summary>
    /// The height of the package. Required when packageType is CUSTOM_PACKAGE; not required for other standard package types (Example: FEDEX_ENVELOPE, FEDEX_PAK) where dimensions are predetermined by the carrier. The Unit is determined by boxDimensionUnit.
    /// <para>
    /// &lt;b style="color: green;"&gt;Market availability: Global&lt;/b&gt;
    /// </para>
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("boxHeight")]
    [Minimum(0.0)]
    public double? BoxHeight { get; init; }

    /// <summary>
    /// The weight of the package. Required for all package types. The Unit is determined by boxWeightUnit.
    /// <para>
    /// &lt;b style="color: green;"&gt;Market availability: Global&lt;/b&gt;
    /// </para>
    /// </summary>
    [JsonPropertyName("boxWeight")]
    public required double BoxWeight { get; init; }

    /// <summary>
    /// The unit of measurement for the package length, width, and height. Allowed values: IN (inches), FT (feet), CM (centimeters).
    /// <para>
    /// &lt;b style="color: green;"&gt;Market availability: Global&lt;/b&gt;
    /// </para>
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("boxDimensionUnit")]
    public BoxDimensionUnit3? BoxDimensionUnit { get; init; }

    /// <summary>
    /// The unit of measurement for the package weight. Allowed values: LB (pounds), KG (kilograms), OZ (ounces).
    /// <para>
    /// &lt;b style="color: green;"&gt;Market availability: Global&lt;/b&gt;
    /// </para>
    /// </summary>
    [JsonPropertyName("boxWeightUnit")]
    public required BoxWeightUnit3 BoxWeightUnit { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
