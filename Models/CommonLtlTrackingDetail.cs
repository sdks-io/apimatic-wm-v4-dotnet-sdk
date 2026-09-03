using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// Contains information related to Less-Than-Truckload (LTL) shipment tracking.
/// </summary>
public record CommonLtlTrackingDetail
{
    /// <summary>
    /// The number of the carrier shipment acknowledgement document.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("billOfLadingNumber")]
    [StringLength(1024, MinimumLength = 1)]
    public string? BillOfLadingNumber { get; init; }

    /// <summary>
    /// The number associated with the freight bill.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("freightBillNumber")]
    public IReadOnlyList<string>? FreightBillNumber { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
