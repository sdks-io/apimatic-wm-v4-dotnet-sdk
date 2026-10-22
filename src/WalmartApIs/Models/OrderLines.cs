using System.Collections.Generic;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// Array of Order lines.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: MX&lt;/b&gt;
/// </summary>
public record OrderLines
{
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("orderLine")]
    public IReadOnlyList<OrderLine>? OrderLine { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
