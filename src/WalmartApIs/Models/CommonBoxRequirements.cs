using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// The requirements for a box in the packing option.
/// </summary>
public record CommonBoxRequirements
{
    /// <summary>
    /// The range of weights that are allowed for a package.
    /// </summary>
    [JsonPropertyName("weight")]
    public required CommonWeightRange Weight { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
