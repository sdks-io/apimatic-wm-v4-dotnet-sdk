using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// item.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability:  MX&lt;/b&gt;
/// </summary>
public record Item12
{
    /// <summary>
    /// productName.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability:  MX&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("productName")]
    public string? ProductName { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
