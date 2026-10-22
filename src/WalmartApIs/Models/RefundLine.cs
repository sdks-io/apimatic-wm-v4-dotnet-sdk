using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// A line number associated with each individual line in the return order. If return order has only one return order line and it is not provided in the request, the only available return order line is auto-selected. If return order has multiple return order lines, the required return order line must be provided in the request. If not provided in the request, it will result in data-error..&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US&lt;/b&gt;
/// </summary>
public record RefundLine
{
    [JsonPropertyName("returnOrderLineNumber")]
    public required int ReturnOrderLineNumber { get; init; }

    /// <summary>
    /// Total quantity returned in this return line.&gt;
    /// </summary>
    [JsonPropertyName("quantity")]
    public required Quantity Quantity { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
