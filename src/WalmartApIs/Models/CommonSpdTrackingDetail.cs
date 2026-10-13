using System.Collections.Generic;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// Contains information related to Small Parcel Delivery (SPD) shipment tracking.
/// </summary>
public record CommonSpdTrackingDetail
{
    /// <summary>
    /// List of Small Parcel Delivery (SPD) tracking items.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("spdTrackingItems")]
    public IReadOnlyList<CommonSpdTrackingItem>? SpdTrackingItems { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
