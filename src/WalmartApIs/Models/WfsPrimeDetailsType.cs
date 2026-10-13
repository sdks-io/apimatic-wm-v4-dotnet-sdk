using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// Walmart Fulfillment Services prime eligibility information.
/// </summary>
public record WfsPrimeDetailsType
{
    /// <summary>
    /// Indicates whether the offer is eligible for WFS Prime.
    /// </summary>
    [JsonPropertyName("IsWFSPrime")]
    public required bool IsWfsPrime { get; init; }

    /// <summary>
    /// Indicates whether the offer is eligible for WFS Prime throughout the entire marketplace.
    /// </summary>
    [JsonPropertyName("IsNationalWFSPrime")]
    public required bool IsNationalWfsPrime { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
