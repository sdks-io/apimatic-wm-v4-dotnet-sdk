using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// The featured offer expected price for a given SKU.
/// </summary>
public record FeaturedOfferExpectedPrice
{
    /// <summary>
    /// Currency type and monetary value.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("listingPrice")]
    public MoneyType? ListingPrice { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
