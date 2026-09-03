using System.Collections.Generic;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// The response schema for the getCompetitiveSummary operation.
/// </summary>
public record CompetitiveSummaryBatchResponse
{
    /// <summary>
    /// A batched list of competitive summary responses.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("responses")]
    public IReadOnlyList<CompetitiveSummaryResponse>? Responses { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
