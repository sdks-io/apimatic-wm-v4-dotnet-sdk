using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

public record RefundOrderLinesResponse
{
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("purchaseOrderId")]
    public string? PurchaseOrderId { get; init; }

    /// <summary>
    /// Seller-visible refund handle, generated server-side. Stable
    /// for the lifetime of the refund; future GET endpoints will
    /// accept it as a path variable.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("refundId")]
    public string? RefundId { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("refundedAt")]
    public DateTimeOffset? RefundedAt { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
