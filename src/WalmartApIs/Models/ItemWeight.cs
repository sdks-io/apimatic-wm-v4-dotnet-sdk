using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// itemWeight.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US&lt;/b&gt;
/// </summary>
public record ItemWeight
{
    /// <summary>
    /// Unit of measure for the quantity.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("unitOfMeasure")]
    public string? UnitOfMeasure { get; init; }

    /// <summary>
    /// Numeric value for the quantity in the specified unit of measure.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("measurementValue")]
    public double? MeasurementValue { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
