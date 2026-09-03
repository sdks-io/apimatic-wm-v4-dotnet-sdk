using System.Collections.Generic;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;
using WalmartApIs.Core.Validation.Attributes;
using WalmartApIs.Models.Enums;

namespace WalmartApIs.Models;

/// <summary>
/// Input information for a given box.
/// </summary>
public record CommonBoxInput
{
    /// <summary>
    /// Indication of how box content is meant to be provided.
    /// </summary>
    [JsonPropertyName("contentInformationSource")]
    public required CommonBoxContentInformationSource ContentInformationSource { get; init; }

    /// <summary>
    /// Measurement of a package's dimensions.
    /// </summary>
    [JsonPropertyName("dimensions")]
    public required CommonDimensions Dimensions { get; init; }

    /// <summary>
    /// The items and their quantity in the box. This must be empty if the box <c>contentInformationSource</c> is <c>BARCODE_2D</c> or <c>MANUAL_PROCESS</c>.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("items")]
    public IReadOnlyList<CommonItemInput>? Items { get; init; }

    /// <summary>
    /// The number of containers where all other properties like weight or dimensions are identical.
    /// </summary>
    [JsonPropertyName("quantity")]
    [Minimum(1)]
    [Maximum(10000)]
    public required int Quantity { get; init; }

    /// <summary>
    /// The weight of a package.
    /// </summary>
    [JsonPropertyName("weight")]
    public required CommonWeight Weight { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
