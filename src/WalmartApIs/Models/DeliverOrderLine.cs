using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

public record DeliverOrderLine
{
    [JsonPropertyName("lineNumber")]
    public required string LineNumber { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("deliveredQuantity")]
    public QuantityWithUnit? DeliveredQuantity { get; init; }

    /// <summary>
    /// Optional proof-of-delivery breadcrumb — the tracking number
    /// the carrier scanned at delivery. Not validated against the
    /// tracking number the seller posted at ship time; both are
    /// preserved verbatim for downstream audit.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("trackingNumber")]
    public string? TrackingNumber { get; init; }

    /// <summary>
    /// Optional package identifier within a multi-package shipment.
    /// Maps to gmp-orders-mono's per-package delivery event.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("packageNumber")]
    public string? PackageNumber { get; init; }

    /// <summary>
    /// ISO-8601 timestamp at which the carrier reported delivery.
    /// Optional — if omitted, FMS defaults to server time.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("deliveredDate")]
    public DateTimeOffset? DeliveredDate { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
