using System.Collections.Generic;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// The <c>listPlacementOptions</c> response.
/// </summary>
public record ListPlacementOptionsResponse
{
    /// <summary>
    /// Placement options generated for the inbound plan.
    /// </summary>
    [JsonPropertyName("placementOptions")]
    public required IReadOnlyList<CommonPlacementOption> PlacementOptions { get; init; }

    /// <summary>
    /// Contains tokens to fetch from a certain page.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("pagination")]
    public CommonPagination? Pagination { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
