using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// Array orderRefund.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: MX&lt;/b&gt;
/// </summary>
public record OrderRefund
{
    /// <summary>
    /// Array of Order lines.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: MX&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("orderLines")]
    public OrderLines? OrderLines { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
