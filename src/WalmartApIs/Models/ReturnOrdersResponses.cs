using System.Collections.Generic;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

public record ReturnOrdersResponses
{
    /// <summary>
    /// Meta data about the list.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: MX&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("meta")]
    public Meta12? Meta { get; init; }

    /// <summary>
    /// returnOrders.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability:  MX&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("returnOrders")]
    public IReadOnlyList<ReturnOrder1>? ReturnOrders { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
