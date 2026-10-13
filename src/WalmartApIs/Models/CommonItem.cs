using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;
using WalmartApIs.Core.Validation.Attributes;

namespace WalmartApIs.Models;

/// <summary>
/// Information associated with a single SKU in the seller's catalog.
/// </summary>
public record CommonItem
{
    /// <summary>
    /// The merchant-defined SKU ID.
    /// </summary>
    [JsonPropertyName("msku")]
    [StringLength(255, MinimumLength = 1)]
    public required string Msku { get; init; }

    /// <summary>
    /// The expiration date of the MSKU. In ISO 8601 date format with pattern <c>YYYY-MM-DD</c>. The same MSKU with different expiration dates cannot go into the same box.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("expiration")]
    [RegularExpression("^([0-9]{4})-(0[1-9]|1[0-2])-(0[1-9]|[1-2][0-9]|3[0-1])$")]
    public string? Expiration { get; init; }

    /// <summary>
    /// Specifies who will label the items. Options include <c>SELLER</c> and <c>NONE</c>.
    /// </summary>
    [JsonPropertyName("labelOwner")]
    [StringLength(1024, MinimumLength = 1)]
    public required string LabelOwner { get; init; }

    /// <summary>
    /// The manufacturing lot code.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("manufacturingLotCode")]
    [StringLength(256, MinimumLength = 1)]
    public string? ManufacturingLotCode { get; init; }

    /// <summary>
    /// Special preparations that are required for an item.
    /// </summary>
    [JsonPropertyName("prepInstructions")]
    public required IReadOnlyList<CommonPrepInstruction> PrepInstructions { get; init; }

    /// <summary>
    /// The number of the specified MSKU.
    /// </summary>
    [JsonPropertyName("quantity")]
    [Minimum(1)]
    [Maximum(500000)]
    public required int Quantity { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
