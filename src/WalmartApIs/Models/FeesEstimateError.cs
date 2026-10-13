using System.Collections.Generic;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// Error detail when a fee estimate could not be computed.
/// </summary>
public record FeesEstimateError
{
    [JsonPropertyName("Type")]
    public required string Type { get; init; }

    [JsonPropertyName("Code")]
    public required string Code { get; init; }

    [JsonPropertyName("Message")]
    public required string Message { get; init; }

    [JsonPropertyName("Detail")]
    public required IReadOnlyList<string> Detail { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
