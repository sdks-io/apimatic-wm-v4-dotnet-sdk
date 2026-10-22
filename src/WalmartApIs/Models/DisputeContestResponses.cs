using System.Collections.Generic;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

public record DisputeContestResponses
{
    /// <summary>
    /// Items status included in the response list.
    /// </summary>
    [JsonPropertyName("itemResponse")]
    public required IReadOnlyList<DisputeContestResponse> ItemResponse { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
