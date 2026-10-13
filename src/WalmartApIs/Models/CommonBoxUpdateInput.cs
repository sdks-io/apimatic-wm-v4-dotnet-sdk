using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;
using WalmartApIs.Core.Validation.Attributes;
using WalmartApIs.Models.Enums;

namespace WalmartApIs.Models;

/// <summary>
/// Input information for updating a box.
/// </summary>
public record CommonBoxUpdateInput
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
    /// Primary key to uniquely identify a Box Package. Provide to update an existing box; omit to add a new box. Any existing packageIds not provided will be treated as to-be-removed.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("packageId")]
    [StringLength(38, MinimumLength = 38)]
    [RegularExpression("^[a-zA-Z0-9-]*$")]
    public string? PackageId { get; init; }

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
