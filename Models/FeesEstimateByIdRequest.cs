using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;
using WalmartApIs.Models.Enums;

namespace WalmartApIs.Models;

/// <summary>
/// A single fee estimate request for the batch endpoint. Combines the
/// item identifier (IdType + IdValue) with the fee estimate parameters.
/// Mirrors SP-API FeesEstimateByIdRequest.
/// </summary>
public record FeesEstimateByIdRequest
{
    /// <summary>
    /// Type of item identifier.
    /// </summary>
    [JsonPropertyName("IdType")]
    public required IdType IdType { get; init; }

    /// <summary>
    /// The item identifier value (Walmart Item ID or Seller SKU).
    /// </summary>
    [JsonPropertyName("IdValue")]
    public required string IdValue { get; init; }

    /// <summary>
    /// Fee estimate parameters for a single item. Used in both single-item
    /// and batch endpoints. Mirrors SP-API FeesEstimateRequest.
    /// </summary>
    [JsonPropertyName("FeesEstimateRequest")]
    public required FeesEstimateRequest FeesEstimateRequest { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
