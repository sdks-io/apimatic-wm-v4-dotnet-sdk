using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

public record GetAdditionalInputsResponse
{
    /// <summary>
    /// JSON Schema (draft-07 compatible) describing the additional
    /// inputs required for the given rateId. Served verbatim from
    /// the upstream carrier integration.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("payload")]
    public object? Payload { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
