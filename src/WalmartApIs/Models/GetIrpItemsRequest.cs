using System.Collections.Generic;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

public record GetIrpItemsRequest
{
    /// <summary>
    /// Search request.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("search")]
    public IReadOnlyList<SearchRequest>? Search { get; init; }

    /// <summary>
    /// Filter request.
    /// </summary>
    [JsonPropertyName("filter")]
    public required FilterRequest Filter { get; init; }

    /// <summary>
    /// Sort request.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("sort")]
    public IReadOnlyList<SortRequest>? Sort { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
