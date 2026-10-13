using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;
using WalmartApIs.Core.Validation.Attributes;
using WalmartApIs.Models.Enums;

namespace WalmartApIs.Models;

/// <summary>
/// Contains information about a pallet used in the inbound plan.
/// </summary>
public record CommonPallet
{
    /// <summary>
    /// Measurement of a package's dimensions.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("dimensions")]
    public CommonDimensions? Dimensions { get; init; }

    /// <summary>
    /// Primary key to uniquely identify a Package (Box or Pallet).
    /// </summary>
    [JsonPropertyName("packageId")]
    [StringLength(38, MinimumLength = 38)]
    [RegularExpression("^[a-zA-Z0-9-]*$")]
    public required string PackageId { get; init; }

    /// <summary>
    /// The number of containers where all other properties like weight or dimensions are identical.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("quantity")]
    [Minimum(1)]
    [Maximum(10000)]
    public int? Quantity { get; init; }

    /// <summary>
    /// Indicates whether pallets will be stacked when carrier arrives for pick-up.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("stackability")]
    public CommonStackability? Stackability { get; init; }

    /// <summary>
    /// The weight of a package.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("weight")]
    public CommonWeight? Weight { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
