using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// The featured offer expected price result for a specific offer.
/// </summary>
public record FeaturedOfferExpectedPriceResult
{
    /// <summary>
    /// The featured offer expected price for a given SKU.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("featuredOfferExpectedPrice")]
    public FeaturedOfferExpectedPrice? FeaturedOfferExpectedPrice { get; init; }

    /// <summary>
    /// The status of the FOEP request.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("resultStatus")]
    public string? ResultStatus { get; init; }

    /// <summary>
    /// A featured offer.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("competingFeaturedOffer")]
    public FeaturedOffer? CompetingFeaturedOffer { get; init; }

    /// <summary>
    /// A featured offer.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("currentFeaturedOffer")]
    public FeaturedOffer? CurrentFeaturedOffer { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
