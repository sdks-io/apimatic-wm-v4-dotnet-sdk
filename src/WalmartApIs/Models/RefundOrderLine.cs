using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;
using WalmartApIs.Models.Enums;

namespace WalmartApIs.Models;

public record RefundOrderLine
{
    [JsonPropertyName("lineNumber")]
    public required string LineNumber { get; init; }

    [JsonPropertyName("refundAmount")]
    public required Money RefundAmount { get; init; }

    /// <summary>
    /// Why the refund is being issued. Compressed from gmp-orders-mono's
    /// 22-entry <c>RefundReason</c> enum to the three classes that actually
    /// drive downstream behaviour today (return-flow vs cancel-flow vs
    /// goodwill-credit). Free-form sub-reason goes in <c>reason</c>.
    /// </summary>
    [JsonPropertyName("refundType")]
    public required RefundType RefundType { get; init; }

    /// <summary>
    /// Optional free-form note (e.g. "item arrived damaged").
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("reason")]
    [MaxLength(500)]
    public string? Reason { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
