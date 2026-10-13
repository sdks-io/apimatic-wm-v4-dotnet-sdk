using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// Small Parcel Delivery (SPD) tracking items input information.
/// </summary>
public record CommonSpdTrackingItemInput
{
    /// <summary>
    /// The ID provided by Walmart that identifies a given box.
    /// </summary>
    [JsonPropertyName("boxId")]
    [StringLength(1024, MinimumLength = 1)]
    public required string BoxId { get; init; }

    /// <summary>
    /// The tracking ID associated with each box in a non-partnered SPD shipment.
    /// </summary>
    [JsonPropertyName("trackingId")]
    [StringLength(64, MinimumLength = 1)]
    public required string TrackingId { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
