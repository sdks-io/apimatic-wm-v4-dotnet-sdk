using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// Summary information about a packing option.
/// </summary>
public record CommonPackingOptionSummary
{
    /// <summary>
    /// Identifier of a packing option.
    /// </summary>
    [JsonPropertyName("packingOptionId")]
    [StringLength(38, MinimumLength = 38)]
    [RegularExpression("^[a-zA-Z0-9-]*$")]
    public required string PackingOptionId { get; init; }

    /// <summary>
    /// The status of a packing option. Possible values: <c>OFFERED</c>, <c>ACCEPTED</c>, <c>EXPIRED</c>.
    /// </summary>
    [JsonPropertyName("status")]
    [StringLength(1024, MinimumLength = 1)]
    public required string Status { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
