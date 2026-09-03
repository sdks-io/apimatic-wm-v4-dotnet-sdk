using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;
using WalmartApIs.Core.Validation.Attributes;
using WalmartApIs.Models.Enums;

namespace WalmartApIs.Models;

/// <summary>
/// The range of weights that are allowed for a package.
/// </summary>
public record CommonWeightRange
{
    /// <summary>
    /// Maximum allowed weight.
    /// </summary>
    [JsonPropertyName("maximum")]
    [Minimum(0.0)]
    [Maximum(100000.0)]
    public required double Maximum { get; init; }

    /// <summary>
    /// Minimum allowed weight.
    /// </summary>
    [JsonPropertyName("minimum")]
    [Minimum(0.0)]
    [Maximum(100000.0)]
    public required double Minimum { get; init; }

    /// <summary>
    /// Unit of the weight being measured.
    /// </summary>
    [JsonPropertyName("unit")]
    public required CommonUnitOfWeight Unit { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
