using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// The possible shipping modes for the packing option for a given shipping solution.
/// </summary>
public record CommonShippingRequirements
{
    /// <summary>
    /// Available shipment modes for this shipping program.
    /// </summary>
    [JsonPropertyName("modes")]
    public required IReadOnlyList<string> Modes { get; init; }

    /// <summary>
    /// Shipping program for the option. Can be: <c>WALMART_PARTNERED_CARRIER</c>, <c>USE_YOUR_OWN_CARRIER</c>.
    /// </summary>
    [JsonPropertyName("solution")]
    [StringLength(1024, MinimumLength = 1)]
    public required string Solution { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
