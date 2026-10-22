using System.Collections.Generic;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

public record V3ItemsDisputeDuplicatesContestRequest
{
    /// <summary>
    /// Items status included in the response list.
    /// <para>
    /// &lt;strong style="color: green;"&gt;<b>Market availability: US only</b>&lt;/strong&gt;
    /// </para>
    /// </summary>
    [JsonPropertyName("issues")]
    public required IReadOnlyList<Issues1> Issues { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
