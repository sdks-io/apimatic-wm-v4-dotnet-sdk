using System.Collections.Generic;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;
using WalmartApIs.Core.Validation.Attributes;

namespace WalmartApIs.Models;

/// <summary>
/// Units under investigation for inventory discrepancies.
/// </summary>
public record ResearchingQuantity
{
    /// <summary>
    /// Total units currently under investigation.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("totalResearchingQuantity")]
    [Minimum(0)]
    public int? TotalResearchingQuantity { get; init; }

    /// <summary>
    /// Breakdown of researching units by investigation duration.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("researchingQuantityBreakdown")]
    public IReadOnlyList<ResearchingQuantityEntry>? ResearchingQuantityBreakdown { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
