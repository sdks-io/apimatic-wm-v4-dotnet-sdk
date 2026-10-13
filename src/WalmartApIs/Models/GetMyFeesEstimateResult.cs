using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// Wraps the fee estimate result for a single-item endpoint.
/// </summary>
public record GetMyFeesEstimateResult
{
    /// <summary>
    /// Fee estimate result for one item. Status indicates Success, ClientError,
    /// or ServiceError. Mirrors SP-API FeesEstimateResult.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("FeesEstimateResult")]
    public FeesEstimateResult? FeesEstimateResult { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
