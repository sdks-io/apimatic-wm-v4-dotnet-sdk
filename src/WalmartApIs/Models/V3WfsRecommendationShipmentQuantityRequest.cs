using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// Provide either <c>listOfGtins</c> or <c>listOfSkus</c>.
/// </summary>
public record V3WfsRecommendationShipmentQuantityRequest
{
    /// <summary>
    /// List of GTINs to request recommended shipment quantities for.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("listOfGtins")]
    [MaxLength(1000)]
    public IReadOnlyList<string>? ListOfGtins { get; init; }

    /// <summary>
    /// List of SKUs to request recommended shipment quantities for.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("listOfSkus")]
    [MaxLength(1000)]
    public IReadOnlyList<string>? ListOfSkus { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
