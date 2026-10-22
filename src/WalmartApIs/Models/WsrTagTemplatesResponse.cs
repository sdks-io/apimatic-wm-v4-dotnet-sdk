using System.Collections.Generic;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// Response containing tag templates for different page types.
/// </summary>
public record WsrTagTemplatesResponse
{
    /// <summary>
    /// List of tag templates for different page types.
    /// <para>
    /// &lt;span style="color:green"&gt;<b>Market availability: Global</b>&lt;/span&gt;
    /// </para>
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("data")]
    public IReadOnlyList<WsrTagTemplate>? Data { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
