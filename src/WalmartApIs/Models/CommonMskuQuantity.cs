using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;
using WalmartApIs.Core.Validation.Attributes;

namespace WalmartApIs.Models;

/// <summary>
/// Represents an MSKU and the related quantity.
/// </summary>
public record CommonMskuQuantity
{
    /// <summary>
    /// The merchant SKU, a merchant-supplied identifier for a specific SKU.
    /// </summary>
    [JsonPropertyName("msku")]
    [StringLength(255, MinimumLength = 1)]
    public required string Msku { get; init; }

    /// <summary>
    /// A positive integer.
    /// </summary>
    [JsonPropertyName("quantity")]
    [Minimum(1)]
    [Maximum(10000)]
    public required int Quantity { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
