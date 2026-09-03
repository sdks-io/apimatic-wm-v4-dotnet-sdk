using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// The request body for the getCompetitiveSummary operation.
/// </summary>
public record CompetitiveSummaryBatchRequest
{
    /// <summary>
    /// A batched list of competitive summary requests.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("requests")]
    [MinLength(1)]
    public IReadOnlyList<CompetitiveSummaryRequest>? Requests { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
