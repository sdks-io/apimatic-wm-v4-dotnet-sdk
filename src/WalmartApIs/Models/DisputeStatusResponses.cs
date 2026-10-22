using System.Collections.Generic;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

public record DisputeStatusResponses
{
    /// <summary>
    /// Items status included in the list.
    /// </summary>
    [JsonPropertyName("itemResponse")]
    public required IReadOnlyList<DisputeStatusResponse> ItemResponse { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
