using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// Request wrapper for single-item fee estimate endpoints.
/// Mirrors SP-API GetMyFeesEstimateRequest.
/// </summary>
public record GetMyFeesEstimateRequest
{
    /// <summary>
    /// Fee estimate parameters for a single item. Used in both single-item
    /// and batch endpoints. Mirrors SP-API FeesEstimateRequest.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("FeesEstimateRequest")]
    public FeesEstimateRequest? FeesEstimateRequest { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
