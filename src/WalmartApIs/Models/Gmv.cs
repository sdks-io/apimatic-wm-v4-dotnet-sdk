using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// chargeAmount.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability:  MX | CA |CL&lt;/b&gt;, Refund amount details for the return order line.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: MX | CA | CL&lt;/b&gt;, refundAmount.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability:  MX&lt;/b&gt;, taxName.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability:  MX&lt;/b&gt;, unitPrice.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability:  MX&lt;/b&gt;
/// </summary>
public record Gmv
{
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("amount")]
    public string? Amount { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("currency")]
    public string? Currency { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
