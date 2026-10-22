using System.Collections.Generic;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// &lt;br&gt;&lt;b style='color:green;'&gt;Market availability: CA | MX | CL&lt;/b&gt;
/// </summary>
public record ItemDetails6
{
    /// <summary>
    /// &lt;br&gt;&lt;b style='color:green;'&gt;Market availability: CA | MX | CL&lt;/b&gt;
    /// </summary>
    [JsonPropertyName("itemIngestionStatus")]
    public required IReadOnlyList<ItemIngestionStatus1> ItemIngestionStatus { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
