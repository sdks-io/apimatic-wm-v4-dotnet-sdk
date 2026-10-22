using System.Collections.Generic;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

public record DisputeContestRequest
{
    /// <summary>
    /// Items status included in the response list.
    /// </summary>
    [JsonPropertyName("issues")]
    public required IReadOnlyList<Issues> Issues { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
