using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// The <c>updateShipmentTrackingDetails</c> request.
/// </summary>
public record UpdateShipmentTrackingDetailsRequest
{
    /// <summary>
    /// Tracking information input for LTL and SPD shipments.
    /// </summary>
    [JsonPropertyName("trackingDetails")]
    public required CommonTrackingDetailsInput TrackingDetails { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
