using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;
using WalmartApIs.Models.Enums;

namespace WalmartApIs.Models;

/// <summary>
/// An MSKU and its related prep details (input).
/// </summary>
public record CommonMskuPrepDetailInput
{
    /// <summary>
    /// The merchant SKU, a merchant-supplied identifier for a specific SKU.
    /// </summary>
    [JsonPropertyName("msku")]
    [StringLength(255, MinimumLength = 1)]
    public required string Msku { get; init; }

    /// <summary>
    /// The preparation category for shipping an item to Walmart's fulfillment network.
    /// </summary>
    [JsonPropertyName("prepCategory")]
    public required CommonPrepCategory PrepCategory { get; init; }

    /// <summary>
    /// A list of preparation types associated with a preparation category.
    /// </summary>
    [JsonPropertyName("prepTypes")]
    public required IReadOnlyList<CommonPrepType> PrepTypes { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
