using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// Contains information used to track and identify a Small Parcel Delivery (SPD) item.
/// </summary>
public record CommonSpdTrackingItem
{
    /// <summary>
    /// The ID provided by Walmart that identifies a given box.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("boxId")]
    [StringLength(1024, MinimumLength = 1)]
    public string? BoxId { get; init; }

    /// <summary>
    /// The tracking ID associated with each box in a non-partnered SPD shipment.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("trackingId")]
    [StringLength(1024, MinimumLength = 1)]
    public string? TrackingId { get; init; }

    /// <summary>
    /// Indicates whether Walmart has validated the tracking number. Possible values: <c>VALIDATED</c>, <c>NOT_VALIDATED</c>, <c>NOT_SUPPORTED</c>.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("trackingNumberValidationStatus")]
    [StringLength(1024, MinimumLength = 1)]
    public string? TrackingNumberValidationStatus { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
