using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// Individual drivers of on time shipment rate
/// </summary>
public record OtsInfractionDrivers
{
    /// <summary>
    /// Marked as shipped later rate
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("markedAsShippedLateRate")]
    public double? MarkedAsShippedLateRate { get; init; }

    /// <summary>
    /// Late handover to carrier rate
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("lateHandoverToCarrierRate")]
    public double? LateHandoverToCarrierRate { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
