using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// Recommendations on how to increase chances of Pro Seller Badge eligibility
/// </summary>
public record Recommendations
{
    /// <summary>
    /// Recommendations on reducing the delivery defect rate
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("deliveryDefectRate")]
    public string? DeliveryDefectRate { get; init; }

    /// <summary>
    /// Recommendations on reducing the Cancellation rate
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("cancellationRate")]
    public string? CancellationRate { get; init; }

    /// <summary>
    /// Recommendations on increasing the trending item catalog coverage
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("listingQualityCatalog")]
    public string? ListingQualityCatalog { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
