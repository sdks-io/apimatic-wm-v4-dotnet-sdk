using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// Shows whether the seller has met the requirements for the badge.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: MX only&lt;/b&gt;
/// </summary>
public record MeetsCriteria2
{
    /// <summary>
    /// Indicates whether the seller has met the minimum number of orders required.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: MX only&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("ordersCriteriaMet")]
    public bool? OrdersCriteriaMet { get; init; }

    /// <summary>
    /// Indicates whether the seller has a low delivery defect, meeting the threshold for the badge.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: MX only&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("deliveryDefectCriteriaMet")]
    public bool? DeliveryDefectCriteriaMet { get; init; }

    /// <summary>
    /// Indicates whether the seller has a low cancellation rate, meeting the threshold for the badge.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: MX only&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("cancellationCriteriaMet")]
    public bool? CancellationCriteriaMet { get; init; }

    /// <summary>
    /// Indicates whether the seller has a low gap between actual and promised delivery dates, meeting the threshold for the badge.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: MX only&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("actualVsPromisedGapCriteriaMet")]
    public bool? ActualVsPromisedGapCriteriaMet { get; init; }

    /// <summary>
    /// Indicates whether the seller has met the minimum number of active days required.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: MX only&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("activeDaysCriteriaMet")]
    public bool? ActiveDaysCriteriaMet { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
