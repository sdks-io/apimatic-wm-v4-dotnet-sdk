using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;
using WalmartApIs.Models.Enums;

namespace WalmartApIs.Models;

public record Pricing1
{
    /// <summary>
    /// &lt;br&gt;&lt;b style='color:green;'&gt;Market availability: Global&lt;/b&gt;
    /// </summary>
    [JsonPropertyName("currentPrice")]
    public required CurrentPrice7 CurrentPrice { get; init; }

    /// <summary>
    /// &lt;br&gt;&lt;b style='color:green;'&gt;Market availability: Global&lt;/b&gt;
    /// </summary>
    [JsonPropertyName("currentPriceType")]
    public required CurrentPriceType6 CurrentPriceType { get; init; }

    /// <summary>
    /// &lt;br&gt;&lt;b style='color:green;'&gt;Market availability: Global&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("comparisonPrice")]
    public ComparisonPrice7? ComparisonPrice { get; init; }

    /// <summary>
    /// &lt;br&gt;&lt;b style='color:green;'&gt;Market availability: Global&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("comparisonPriceType")]
    public ComparisonPriceType6? ComparisonPriceType { get; init; }

    /// <summary>
    /// &lt;br&gt;&lt;b style='color:green;'&gt;Market availability: Global&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("savingsAmount")]
    public double? SavingsAmount { get; init; }

    /// <summary>
    /// &lt;br&gt;&lt;b style='color:green;'&gt;Market availability: Global&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("savingsPercent")]
    public double? SavingsPercent { get; init; }

    /// <summary>
    /// &lt;br&gt;&lt;b style='color:green;'&gt;Market availability: Global&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("priceDisplayCodes")]
    public PriceDisplayCodes3? PriceDisplayCodes { get; init; }

    /// <summary>
    /// &lt;br&gt;&lt;b style='color:green;'&gt;Market availability: Global&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("pickupDiscount")]
    public PickupDiscount1? PickupDiscount { get; init; }

    /// <summary>
    /// &lt;br&gt;&lt;b style='color:green;'&gt;Market availability: Global&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("effectiveDate")]
    public long? EffectiveDate { get; init; }

    /// <summary>
    /// &lt;br&gt;&lt;b style='color:green;'&gt;Market availability: Global&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("expirationDate")]
    public long? ExpirationDate { get; init; }

    /// <summary>
    /// &lt;br&gt;&lt;b style='color:green;'&gt;Market availability: Global&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("processMode")]
    public ProcessMode6? ProcessMode { get; init; }

    /// <summary>
    /// &lt;br&gt;&lt;b style='color:green;'&gt;Market availability: Global&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("pid")]
    public string? Pid { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
