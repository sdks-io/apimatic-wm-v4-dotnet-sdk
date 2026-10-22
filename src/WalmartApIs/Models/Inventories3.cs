using System.Collections.Generic;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// &lt;strong style="color: green;"&gt;Market availability: Global&lt;/strong&gt;
/// </summary>
public record Inventories3
{
    [JsonPropertyName("nodes")]
    public required IReadOnlyList<Node10> Nodes { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
