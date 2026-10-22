using System.Collections.Generic;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

public record RefundRequest
{
    /// <summary>
    /// A unique ID associated with the sales order for specified customer.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US | MX&lt;/b&gt;
    /// </summary>
    [JsonPropertyName("customerOrderId")]
    public required string CustomerOrderId { get; init; }

    /// <summary>
    /// Array of refund lines.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US&lt;/b&gt;
    /// </summary>
    [JsonPropertyName("refundLines")]
    public required IReadOnlyList<RefundLine> RefundLines { get; init; }

    /// <summary>
    /// Array orderRefund.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: MX&lt;/b&gt;
    /// </summary>
    [JsonPropertyName("orderRefund")]
    public required OrderRefund OrderRefund { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
