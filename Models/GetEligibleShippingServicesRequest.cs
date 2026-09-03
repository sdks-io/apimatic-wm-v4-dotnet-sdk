using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

public record GetEligibleShippingServicesRequest
{
    [JsonPropertyName("shipmentRequestDetails")]
    public required ShipmentRequestDetails ShipmentRequestDetails { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
