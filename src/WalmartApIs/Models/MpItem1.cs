using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

public record MpItem1
{
    /// <summary>
    /// Applicable for CA, MX, and CL markets. Price details for the item. &lt;br&gt;&lt;b style='color:green;'&gt;Market availability: CA | MX | CL&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("Price")]
    public Price21? Price { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
