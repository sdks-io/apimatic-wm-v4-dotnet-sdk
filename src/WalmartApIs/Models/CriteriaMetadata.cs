using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// Specifies the metadata value for each criterion&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US only&lt;/b&gt;
/// </summary>
public record CriteriaMetadata
{
    /// <summary>
    /// Specifies number of orders received in the given timeframe.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US | CA&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("orders")]
    public double? Orders { get; init; }

    /// <summary>
    /// Specifies the number of days the seller has been active on the platform.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US | CA&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("activeDays")]
    public double? ActiveDays { get; init; }

    /// <summary>
    /// Specifies the on-time delivery rate within the given timeframe.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US | CA&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("onTimeDeliveryRate")]
    public double? OnTimeDeliveryRate { get; init; }

    /// <summary>
    /// Specifies the cancellation rate within the given timeframe.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US | CA&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("cancellationRate")]
    public double? CancellationRate { get; init; }

    /// <summary>
    /// Specifies the seller's response rate.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US | CA&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("sellerResponseRate")]
    public double? SellerResponseRate { get; init; }

    /// <summary>
    /// Specifies the seller's shipping score.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US only&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("shippingScore")]
    public double? ShippingScore { get; init; }

    /// <summary>
    /// Specifies the seller's content score.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US | CA&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("contentScore")]
    public double? ContentScore { get; init; }

    /// <summary>
    /// Specifies the seller's meet or beat score.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US | CA&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("priceMbScore")]
    public double? PriceMbScore { get; init; }

    /// <summary>
    /// Specifies the difference between the promised and actual delivery dates.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: CA only&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("promiseAccuracy")]
    public double? PromiseAccuracy { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
