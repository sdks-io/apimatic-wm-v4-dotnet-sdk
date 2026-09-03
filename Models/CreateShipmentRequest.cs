using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;
using WalmartApIs.Models.Enums;

namespace WalmartApIs.Models;

public record CreateShipmentRequest
{
    [JsonPropertyName("shipmentRequestDetails")]
    public required ShipmentRequestDetails ShipmentRequestDetails { get; init; }

    [JsonPropertyName("shippingServiceId")]
    public required string ShippingServiceId { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("shippingServiceOfferId")]
    public string? ShippingServiceOfferId { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("labelFormat")]
    public LabelFormat? LabelFormat { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
