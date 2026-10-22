using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// &lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US | CA | MX&lt;/b&gt;
/// </summary>
public record Gmv4
{
    /// <summary>
    /// &lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US | CA | MX&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("amount")]
    public string? Amount { get; init; }

    /// <summary>
    /// &lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US | CA | MX&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("currency")]
    public string? Currency { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
