using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// Response for single-item fee estimate endpoints.
/// Mirrors SP-API GetMyFeesEstimateResponse.
/// </summary>
public record GetMyFeesEstimateResponse
{
    /// <summary>
    /// Wraps the fee estimate result for a single-item endpoint.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("payload")]
    public GetMyFeesEstimateResult? Payload { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("errors")]
    public ErrorList? Errors { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
