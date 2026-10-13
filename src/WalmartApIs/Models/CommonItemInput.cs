using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;
using WalmartApIs.Core.Validation.Attributes;
using WalmartApIs.Models.Enums;

namespace WalmartApIs.Models;

/// <summary>
/// Defines an item's input parameters.
/// </summary>
public record CommonItemInput
{
    /// <summary>
    /// The expiration date of the MSKU. In ISO 8601 date format with pattern <c>YYYY-MM-DD</c>. Items with the same MSKU but different expiration dates cannot go into the same box.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("expiration")]
    [RegularExpression("^([0-9]{4})-(0[1-9]|1[0-2])-(0[1-9]|[1-2][0-9]|3[0-1])$")]
    public string? Expiration { get; init; }

    /// <summary>
    /// Specifies who will label the items. Options include <c>SELLER</c> and <c>NONE</c>.
    /// </summary>
    [JsonPropertyName("labelOwner")]
    public required CommonLabelOwner LabelOwner { get; init; }

    /// <summary>
    /// The manufacturing lot code.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("manufacturingLotCode")]
    [StringLength(256, MinimumLength = 1)]
    public string? ManufacturingLotCode { get; init; }

    /// <summary>
    /// The merchant SKU, a merchant-supplied identifier of a specific SKU.
    /// </summary>
    [JsonPropertyName("msku")]
    [StringLength(255, MinimumLength = 1)]
    public required string Msku { get; init; }

    /// <summary>
    /// The owner of the preparations, if special preparations are required.
    /// </summary>
    [JsonPropertyName("prepOwner")]
    public required CommonPrepOwner PrepOwner { get; init; }

    /// <summary>
    /// The number of units of the specified MSKU that will be shipped.
    /// </summary>
    [JsonPropertyName("quantity")]
    [Minimum(1)]
    [Maximum(500000)]
    public required int Quantity { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
