using System.Collections.Generic;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// The <c>generatePlacementOptions</c> request.
/// </summary>
public record GeneratePlacementOptionsRequest
{
    /// <summary>
    /// Custom placement options to add to the plan.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("customPlacement")]
    public IReadOnlyList<CommonCustomPlacementInput>? CustomPlacement { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
