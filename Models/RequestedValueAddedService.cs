using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

public record RequestedValueAddedService
{
    /// <summary>
    /// Identifier of the value-added service being requested.
    /// </summary>
    [JsonPropertyName("id")]
    public required string Id { get; init; }

    /// <summary>
    /// Service-specific input payload. Validated against the
    /// schema published in availableValueAddedServices on the
    /// corresponding Rate. Compressed shape; see TODO.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("details")]
    public object? Details { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
