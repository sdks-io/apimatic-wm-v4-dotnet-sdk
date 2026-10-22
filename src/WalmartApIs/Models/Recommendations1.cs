using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// Recommendations on how to increase chances of Pro Seller Badge eligibility&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: MX only&lt;/b&gt;
/// </summary>
public record Recommendations1
{
    /// <summary>
    /// Recommendations on reducing the delivery defect rate&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: MX only&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("deliveryDefectRate")]
    public string? DeliveryDefectRate { get; init; }

    /// <summary>
    /// Recommendations on reducing the Cancellation rate&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: MX only&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("cancellationRate")]
    public string? CancellationRate { get; init; }

    /// <summary>
    /// Recommendations on reducing the Actual vs Promised Delivery Gap&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: MX only&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("actualVsPromisedGap")]
    public string? ActualVsPromisedGap { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
