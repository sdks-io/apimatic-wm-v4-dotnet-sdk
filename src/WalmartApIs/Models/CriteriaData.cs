using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// Shows the criteria for the Pro Seller badge.
/// </summary>
public record CriteriaData
{
    /// <summary>
    /// Number of orders received during the last 90 days.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("orders")]
    public int? Orders { get; init; }

    /// <summary>
    /// Delivery Defect rate in the given timeframe.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("deliveryDefectRate")]
    public string? DeliveryDefectRate { get; init; }

    /// <summary>
    /// Cancellation rate in the given timeframe.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("cancellationRate")]
    public string? CancellationRate { get; init; }

    /// <summary>
    /// Trending Catalog Quality Score coverage.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("listingQualityCatalog")]
    public int? ListingQualityCatalog { get; init; }

    /// <summary>
    /// Days active on the platform.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("activeDays")]
    public int? ActiveDays { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
