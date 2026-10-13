using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// Tracking information for LTL and SPD shipments.
/// </summary>
public record CommonTrackingDetails
{
    /// <summary>
    /// Contains information related to Less-Than-Truckload (LTL) shipment tracking.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("ltlTrackingDetail")]
    public CommonLtlTrackingDetail? LtlTrackingDetail { get; init; }

    /// <summary>
    /// Contains information related to Small Parcel Delivery (SPD) shipment tracking.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("spdTrackingDetail")]
    public CommonSpdTrackingDetail? SpdTrackingDetail { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
