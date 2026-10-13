using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;
using WalmartApIs.Models.Enums;

namespace WalmartApIs.Models;

/// <summary>
/// An MSKU and its related prep details.
/// </summary>
public record CommonMskuPrepDetail
{
    /// <summary>
    /// A constraint that applies to all owners. If no constraint is specified, defer to any individual owner constraints.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("allOwnersConstraint")]
    public CommonAllOwnersConstraint? AllOwnersConstraint { get; init; }

    /// <summary>
    /// A constraint that can apply to an individual owner.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("labelOwnerConstraint")]
    public CommonOwnerConstraint? LabelOwnerConstraint { get; init; }

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
    /// A constraint that can apply to an individual owner.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("prepOwnerConstraint")]
    public CommonOwnerConstraint? PrepOwnerConstraint { get; init; }

    /// <summary>
    /// A list of preparation types associated with a preparation category.
    /// </summary>
    [JsonPropertyName("prepTypes")]
    public required IReadOnlyList<CommonPrepType> PrepTypes { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
