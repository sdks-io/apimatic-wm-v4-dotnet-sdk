using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

public record MultiPackageShipResponse
{
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("purchaseOrderId")]
    public string? PurchaseOrderId { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("shippedAt")]
    public DateTimeOffset? ShippedAt { get; init; }

    /// <summary>
    /// Number of <c>packages[]</c> entries successfully forwarded to FMS
    /// — echoed back so callers can sanity-check against what they
    /// sent.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("packagesAccepted")]
    public int? PackagesAccepted { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
