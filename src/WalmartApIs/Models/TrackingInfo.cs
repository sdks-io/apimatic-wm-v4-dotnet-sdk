using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;
using WalmartApIs.Models.Enums;

namespace WalmartApIs.Models;

public record TrackingInfo
{
    [JsonPropertyName("carrier")]
    public required CarrierName Carrier { get; init; }

    [JsonPropertyName("trackingNumber")]
    public required string TrackingNumber { get; init; }

    [JsonPropertyName("shippedDate")]
    public required DateTimeOffset ShippedDate { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("methodCode")]
    public MethodCode? MethodCode { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
