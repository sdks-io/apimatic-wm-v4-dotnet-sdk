using System.Collections.Generic;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// Contains input information to update SPD tracking information.
/// </summary>
public record CommonSpdTrackingDetailInput
{
    /// <summary>
    /// List of Small Parcel Delivery (SPD) tracking items input.
    /// </summary>
    [JsonPropertyName("spdTrackingItems")]
    public required IReadOnlyList<CommonSpdTrackingItemInput> SpdTrackingItems { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
