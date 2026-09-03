using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// Packing information for the inbound plan.
/// </summary>
public record CommonPackageGroupingInput
{
    /// <summary>
    /// Box level information being provided.
    /// </summary>
    [JsonPropertyName("boxes")]
    [MinLength(1)]
    [MaxLength(5000)]
    public required IReadOnlyList<CommonBoxInput> Boxes { get; init; }

    /// <summary>
    /// The ID of the <c>packingGroup</c> that packages are grouped according to. Provide before placement confirmation.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("packingGroupId")]
    [StringLength(38, MinimumLength = 38)]
    [RegularExpression("^[a-zA-Z0-9-]*$")]
    public string? PackingGroupId { get; init; }

    /// <summary>
    /// The ID of the shipment that packages are grouped according to. Provide after placement confirmation.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("shipmentId")]
    [StringLength(38, MinimumLength = 38)]
    [RegularExpression("^[a-zA-Z0-9-]*$")]
    public string? ShipmentId { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
