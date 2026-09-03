using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;
using WalmartApIs.Core.Validation.Attributes;
using WalmartApIs.Models.Enums;

namespace WalmartApIs.Models;

/// <summary>
/// Measurement of a package's dimensions.
/// </summary>
public record CommonDimensions
{
    /// <summary>
    /// The height of a package.
    /// </summary>
    [JsonPropertyName("height")]
    [Minimum(0.0)]
    [Maximum(100000.0)]
    public required double Height { get; init; }

    /// <summary>
    /// The length of a package.
    /// </summary>
    [JsonPropertyName("length")]
    [Minimum(0.0)]
    [Maximum(100000.0)]
    public required double Length { get; init; }

    /// <summary>
    /// The width of a package.
    /// </summary>
    [JsonPropertyName("width")]
    [Minimum(0.0)]
    [Maximum(100000.0)]
    public required double Width { get; init; }

    /// <summary>
    /// Unit of linear measure.
    /// </summary>
    [JsonPropertyName("unitOfMeasurement")]
    public required CommonUnitOfMeasurement UnitOfMeasurement { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
