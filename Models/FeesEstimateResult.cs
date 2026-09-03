using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;
using WalmartApIs.Models.Enums;

namespace WalmartApIs.Models;

/// <summary>
/// Fee estimate result for one item. Status indicates Success, ClientError,
/// or ServiceError. Mirrors SP-API FeesEstimateResult.
/// </summary>
public record FeesEstimateResult
{
    /// <summary>
    /// Outcome of the fee estimate.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("Status")]
    public Status4? Status { get; init; }

    /// <summary>
    /// Echoes back the item identifier and request parameters that produced
    /// this result. Mirrors SP-API FeesEstimateIdentifier.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("FeesEstimateIdentifier")]
    public FeesEstimateIdentifier? FeesEstimateIdentifier { get; init; }

    /// <summary>
    /// The estimated fees broken down by component.
    /// Mirrors SP-API FeesEstimate.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("FeesEstimate")]
    public FeesEstimate? FeesEstimate { get; init; }

    /// <summary>
    /// Error detail when a fee estimate could not be computed.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("Error")]
    public FeesEstimateError? Error { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
