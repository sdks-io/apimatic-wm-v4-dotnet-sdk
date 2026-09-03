using System.Collections.Generic;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// The body of a FOEP response.
/// </summary>
public record FeaturedOfferExpectedPriceResponseBody
{
    /// <summary>
    /// Identifies an offer.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("offerIdentifier")]
    public OfferIdentifier? OfferIdentifier { get; init; }

    /// <summary>
    /// A list of FOEP results for the requested offer.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("featuredOfferExpectedPriceResults")]
    public IReadOnlyList<FeaturedOfferExpectedPriceResult>? FeaturedOfferExpectedPriceResults { get; init; }

    /// <summary>
    /// A list of error responses returned when a request is unsuccessful.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("errors")]
    public IReadOnlyList<Error3>? Errors { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
