using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

public record OrderLine
{
    /// <summary>
    /// The order line number
    /// </summary>
    [JsonPropertyName("lineNumber")]
    public required string LineNumber { get; init; }

    [JsonPropertyName("orderLineStatuses")]
    public required OrderLineStatuses OrderLineStatuses { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
