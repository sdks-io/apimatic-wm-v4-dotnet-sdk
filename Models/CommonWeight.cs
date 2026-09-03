using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;
using WalmartApIs.Core.Validation.Attributes;
using WalmartApIs.Models.Enums;

namespace WalmartApIs.Models;

/// <summary>
/// The weight of a package.
/// </summary>
public record CommonWeight
{
    /// <summary>
    /// Unit of the weight being measured.
    /// </summary>
    [JsonPropertyName("unit")]
    public required CommonUnitOfWeight Unit { get; init; }

    /// <summary>
    /// Value of a weight.
    /// </summary>
    [JsonPropertyName("value")]
    [Minimum(0.0)]
    [Maximum(100000.0)]
    public required double Value { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
