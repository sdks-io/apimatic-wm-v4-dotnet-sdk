using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// A featured offer.
/// </summary>
public record FeaturedOffer
{
    /// <summary>
    /// Identifies an offer.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("offerIdentifier")]
    public OfferIdentifier? OfferIdentifier { get; init; }

    /// <summary>
    /// The item condition.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("condition")]
    public string? Condition { get; init; }

    /// <summary>
    /// Currency type and monetary value.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("price")]
    public MoneyType? Price { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
