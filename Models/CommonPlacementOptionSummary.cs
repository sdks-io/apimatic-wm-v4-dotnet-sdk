using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// Summary information about a placement option.
/// </summary>
public record CommonPlacementOptionSummary
{
    /// <summary>
    /// The identifier of a placement option.
    /// </summary>
    [JsonPropertyName("placementOptionId")]
    [StringLength(38, MinimumLength = 38)]
    [RegularExpression("^[a-zA-Z0-9-]*$")]
    public required string PlacementOptionId { get; init; }

    /// <summary>
    /// The status of a placement option. Possible values: <c>OFFERED</c>, <c>ACCEPTED</c>.
    /// </summary>
    [JsonPropertyName("status")]
    [StringLength(1024, MinimumLength = 1)]
    public required string Status { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
