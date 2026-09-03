using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// Specifies the date that the seller expects their shipment will be shipped.
/// </summary>
public record CommonDates
{
    /// <summary>
    /// Contains a start and end DateTime representing a time range.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("readyToShipWindow")]
    public CommonWindow? ReadyToShipWindow { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
