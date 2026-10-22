using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;
using WalmartApIs.Models.Enums;

namespace WalmartApIs.Models;

public record Pricing
{
    /// <summary>
    /// This is applicable only for promotions
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("effectiveDate")]
    public DateTimeOffset? EffectiveDate { get; init; }

    /// <summary>
    /// This is applicable only for promotions
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("expirationDate")]
    public DateTimeOffset? ExpirationDate { get; init; }

    /// <summary>
    /// This is applicable only for promotions
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("promoId")]
    public string? PromoId { get; init; }

    /// <summary>
    /// This is applicable only for promotions
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("processMode")]
    public ProcessMode? ProcessMode { get; init; }

    [JsonPropertyName("currentPriceType")]
    public required CurrentPriceType CurrentPriceType { get; init; }

    [JsonPropertyName("currentPrice")]
    public required CurrentPrice CurrentPrice { get; init; }

    /// <summary>
    /// This is applicable only for promotions
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("comparisonPriceType")]
    public ComparisonPriceType? ComparisonPriceType { get; init; }

    /// <summary>
    /// This is applicable only for promotions
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("comparisonPrice")]
    public ComparisonPrice? ComparisonPrice { get; init; }

    /// <summary>
    /// This is applicable only for promotions
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("priceDisplayCodes")]
    public PriceDisplayCodes1? PriceDisplayCodes { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
