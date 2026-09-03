using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// Provide units going to the ship node.
/// </summary>
public record CommonCustomPlacementInput
{
    /// <summary>
    /// Items included while creating Inbound Plan.
    /// </summary>
    [JsonPropertyName("items")]
    [MinLength(1)]
    [MaxLength(2000)]
    public required IReadOnlyList<CommonItemInput> Items { get; init; }

    /// <summary>
    /// Ship Node ID.
    /// </summary>
    [JsonPropertyName("warehouseId")]
    [StringLength(1024, MinimumLength = 1)]
    public required string WarehouseId { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
