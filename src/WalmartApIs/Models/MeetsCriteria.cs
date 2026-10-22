using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// Shows whether the seller has met the requirements for the badge.
/// </summary>
public record MeetsCriteria
{
    /// <summary>
    /// Indicates whether the seller has met the minimum number of orders required.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("isOrdersCriteriaMet")]
    public bool? IsOrdersCriteriaMet { get; init; }

    /// <summary>
    /// Indicates whether the seller has a low delivery defect, meeting the threshold for the badge.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("isDeliveryDefectCriteriaMet")]
    public bool? IsDeliveryDefectCriteriaMet { get; init; }

    /// <summary>
    /// Indicates whether the seller has a low cancellation rate, meeting the threshold for the badge.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("isCancellationCriteriaMet")]
    public bool? IsCancellationCriteriaMet { get; init; }

    /// <summary>
    /// Indicates whether the seller is meeting the trending catalog requirement.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("isListingQualityCatalogCriteriaMet")]
    public bool? IsListingQualityCatalogCriteriaMet { get; init; }

    /// <summary>
    /// Indicates whether the seller has met the minimum number of active days required.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("isActiveDaysCriteriaMet")]
    public bool? IsActiveDaysCriteriaMet { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
