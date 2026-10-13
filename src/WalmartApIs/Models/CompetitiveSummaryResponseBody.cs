using System.Collections.Generic;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// The body of a competitive summary response.
/// </summary>
public record CompetitiveSummaryResponseBody
{
    /// <summary>
    /// The Walmart Item ID of the item.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("walmartItemId")]
    public string? WalmartItemId { get; init; }

    /// <summary>
    /// A marketplace identifier.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("marketplaceId")]
    public string? MarketplaceId { get; init; }

    /// <summary>
    /// A list of featured buying options.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("featuredBuyingOptions")]
    public IReadOnlyList<object>? FeaturedBuyingOptions { get; init; }

    /// <summary>
    /// A list of lowest priced offers by condition.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("lowestPricedOffers")]
    public IReadOnlyList<object>? LowestPricedOffers { get; init; }

    /// <summary>
    /// A list of reference prices.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("referencePrices")]
    public IReadOnlyList<object>? ReferencePrices { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
