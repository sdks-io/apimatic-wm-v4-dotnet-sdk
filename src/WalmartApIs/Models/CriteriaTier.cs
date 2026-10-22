using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// Specifies the tier for each criterion.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US | CA&lt;/b&gt;
/// </summary>
public record CriteriaTier
{
    /// <summary>
    /// Specifies the eligible tier based on number of orders.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US | CA&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("orders")]
    public string? Orders { get; init; }

    /// <summary>
    /// Specifies the eligible tier based on the number of active days.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US | CA&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("activeDays")]
    public string? ActiveDays { get; init; }

    /// <summary>
    /// Specifies the eligible tier based on the OTD rate.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US | CA&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("onTimeDeliveryRate")]
    public string? OnTimeDeliveryRate { get; init; }

    /// <summary>
    /// Specifies the eligible tier based on the cancellation rate.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US | CA&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("cancellationRate")]
    public string? CancellationRate { get; init; }

    /// <summary>
    /// Specifies the eligible tier based on the seller response.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US | CA&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("sellerResponseRate")]
    public string? SellerResponseRate { get; init; }

    /// <summary>
    /// Specifies the eligible tier based on shipping score&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US only&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("shippingScore")]
    public string? ShippingScore { get; init; }

    /// <summary>
    /// Specifies the eligible tier based on the content score.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US | CA&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("contentScore")]
    public string? ContentScore { get; init; }

    /// <summary>
    /// Specifies the eligible tier based on the price meet or beat score.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US | CA&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("priceMbScore")]
    public string? PriceMbScore { get; init; }

    /// <summary>
    /// Specifies the difference between the promised and the actual delivery dates.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: CA only&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("promiseAccuracy")]
    public double? PromiseAccuracy { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
