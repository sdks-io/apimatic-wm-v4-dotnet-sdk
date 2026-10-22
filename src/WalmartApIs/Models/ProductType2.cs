using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// The productType is only applicable for categories.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US only&lt;/b&gt;
/// </summary>
public record ProductType2
{
    /// <summary>
    /// &lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US only&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("name")]
    public string? Name { get; init; }

    /// <summary>
    /// &lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US only&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("count")]
    public int? Count { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
