using System.Collections.Generic;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

public record V3ItemsDisputeDuplicatesStatusResponse
{
    /// <summary>
    /// Items status included in the list.
    /// </summary>
    [JsonPropertyName("itemResponse")]
    public required IReadOnlyList<ItemResponse3> ItemResponse { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
