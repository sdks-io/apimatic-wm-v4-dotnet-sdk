using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// Total quantity returned in this return line.&gt;
/// </summary>
public record Quantity
{
    /// <summary>
    /// The unit of measure in the item's weight (e.g., 'EACH' or 'EA')
    /// </summary>
    [JsonPropertyName("unitOfMeasure")]
    public required string UnitOfMeasure { get; init; }

    /// <summary>
    /// The quantity of the unit of measure for the item
    /// </summary>
    [JsonPropertyName("measurementValue")]
    public required int MeasurementValue { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
