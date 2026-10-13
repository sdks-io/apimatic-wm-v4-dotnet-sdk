using System.Collections.Generic;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// Competitive pricing information for the item.
/// </summary>
public record CompetitivePricingType
{
    /// <summary>
    /// A list of competitive pricing information.
    /// </summary>
    [JsonPropertyName("CompetitivePrices")]
    public required IReadOnlyList<CompetitivePriceType> CompetitivePrices { get; init; }

    /// <summary>
    /// The number of active offer listings for the item, by condition.
    /// </summary>
    [JsonPropertyName("NumberOfOfferListings")]
    public required IReadOnlyList<OfferListingCountType> NumberOfOfferListings { get; init; }

    /// <summary>
    /// Currency type and monetary value.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("TradeInValue")]
    public MoneyType? TradeInValue { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
