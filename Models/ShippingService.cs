using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;
using WalmartApIs.Models.Enums;

namespace WalmartApIs.Models;

public record ShippingService
{
    [JsonPropertyName("shippingServiceId")]
    public required string ShippingServiceId { get; init; }

    [JsonPropertyName("carrierName")]
    public required CarrierName CarrierName { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("shippingServiceName")]
    public string? ShippingServiceName { get; init; }

    [JsonPropertyName("shippingServiceOfferId")]
    public required string ShippingServiceOfferId { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("shipDate")]
    public DateTimeOffset? ShipDate { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("earliestEstimatedDeliveryDate")]
    public DateTimeOffset? EarliestEstimatedDeliveryDate { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("latestEstimatedDeliveryDate")]
    public DateTimeOffset? LatestEstimatedDeliveryDate { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("rate")]
    public Money? Rate { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("shippingServiceOptions")]
    public ShippingServiceOptions? ShippingServiceOptions { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
