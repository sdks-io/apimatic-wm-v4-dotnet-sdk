using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// Contains price information about the product, including LowestPrices, BuyBoxPrices, and NumberOfOffers.
/// </summary>
public record Summary
{
    /// <summary>
    /// The number of unique offers contained in NumberOfOffers.
    /// </summary>
    [JsonPropertyName("TotalOfferCount")]
    public required int TotalOfferCount { get; init; }

    /// <summary>
    /// A list of the total number of offers, by condition and fulfillment channel.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("NumberOfOffers")]
    public IReadOnlyList<OfferCountType>? NumberOfOffers { get; init; }

    /// <summary>
    /// A list of the lowest prices.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("LowestPrices")]
    public IReadOnlyList<LowestPriceType>? LowestPrices { get; init; }

    /// <summary>
    /// A list of the Buy Box prices.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("BuyBoxPrices")]
    public IReadOnlyList<BuyBoxPriceType>? BuyBoxPrices { get; init; }

    /// <summary>
    /// Currency type and monetary value.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("ListPrice")]
    public MoneyType? ListPrice { get; init; }

    /// <summary>
    /// Currency type and monetary value.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("CompetitivePriceThreshold")]
    public MoneyType? CompetitivePriceThreshold { get; init; }

    /// <summary>
    /// Currency type and monetary value.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("SuggestedLowerPricePlusShipping")]
    public MoneyType? SuggestedLowerPricePlusShipping { get; init; }

    /// <summary>
    /// A list of sales rank information for the item, by category.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("SalesRankings")]
    public IReadOnlyList<SalesRankType>? SalesRankings { get; init; }

    /// <summary>
    /// A list of the total number of offers eligible for the Buy Box, by condition and fulfillment channel.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("BuyBoxEligibleOffers")]
    public IReadOnlyList<OfferCountType>? BuyBoxEligibleOffers { get; init; }

    /// <summary>
    /// When the status is ActiveButTooSoonForProcessing, the time when offers will be available for processing.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("OffersAvailableTime")]
    public DateTimeOffset? OffersAvailableTime { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
