using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;
using WalmartApIs.Core.Validation.Attributes;
using WalmartApIs.Models.Enums;

namespace WalmartApIs.Models;

/// <summary>
/// Contains input information about a pallet to be used in the inbound plan.
/// </summary>
public record CommonPalletInput
{
    /// <summary>
    /// Measurement of a package's dimensions.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("dimensions")]
    public CommonDimensions? Dimensions { get; init; }

    /// <summary>
    /// The number of containers where all other properties like weight or dimensions are identical.
    /// </summary>
    [JsonPropertyName("quantity")]
    [Minimum(1)]
    [Maximum(10000)]
    public required int Quantity { get; init; }

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
