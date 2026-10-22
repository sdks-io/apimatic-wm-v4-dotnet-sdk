using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// Array of return lines.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US&lt;/b&gt;
/// </summary>
public record ReturnLine
{
    /// <summary>
    /// Identifier of the return label.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("returnOrderLineNumber")]
    public int? ReturnOrderLineNumber { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
