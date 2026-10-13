using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;
using WalmartApIs.Core.Validation.Attributes;
using WalmartApIs.Models.Enums;

namespace WalmartApIs.Models;

/// <summary>
/// Contains information about a box used in the inbound plan.
/// </summary>
public record CommonBox
{
    /// <summary>
    /// The ID provided by Walmart that identifies a given box.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("boxId")]
    [StringLength(1024, MinimumLength = 1)]
    public string? BoxId { get; init; }

    /// <summary>
    /// Indication of how box content is meant to be provided.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("contentInformationSource")]
    public CommonBoxContentInformationSource? ContentInformationSource { get; init; }

    /// <summary>
    /// Representation of a location used within the inbounding experience.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("destinationRegion")]
    public CommonRegion? DestinationRegion { get; init; }

    /// <summary>
    /// Measurement of a package's dimensions.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("dimensions")]
    public CommonDimensions? Dimensions { get; init; }

    /// <summary>
    /// The external identifier for this container / box.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("externalContainerIdentifier")]
    [StringLength(1024, MinimumLength = 1)]
    public string? ExternalContainerIdentifier { get; init; }

    /// <summary>
    /// Type of the external identifier used. Can be: <c>WALMART</c>, <c>SSCC</c>.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("externalContainerIdentifierType")]
    [StringLength(1024, MinimumLength = 1)]
    public string? ExternalContainerIdentifierType { get; init; }

    /// <summary>
    /// Items contained within the box.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("items")]
    public IReadOnlyList<CommonItem>? Items { get; init; }

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
    /// Template name of the box.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("templateName")]
    [StringLength(1024, MinimumLength = 1)]
    public string? TemplateName { get; init; }

    /// <summary>
    /// The weight of a package.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("weight")]
    public CommonWeight? Weight { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
