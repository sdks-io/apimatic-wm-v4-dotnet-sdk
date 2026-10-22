using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// Shows the criteria for the Pro Seller badge.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: MX only&lt;/b&gt;
/// </summary>
public record CriteriaData2
{
    /// <summary>
    /// Number of orders received during the last 90 days.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: MX only&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("orders")]
    public int? Orders { get; init; }

    /// <summary>
    /// Delivery Defect rate in the given timeframe.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: MX only&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("deliveryDefectRate")]
    public string? DeliveryDefectRate { get; init; }

    /// <summary>
    /// Cancellation rate in the given timeframe.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: MX only&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("cancellationRate")]
    public string? CancellationRate { get; init; }

    /// <summary>
    /// Avg gap (in days) between actual and promised delivery in the given timeframe.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: MX only&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("actualVsPromisedGap")]
    public int? ActualVsPromisedGap { get; init; }

    /// <summary>
    /// Days active on the platform.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: MX only&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("activeDays")]
    public int? ActiveDays { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
