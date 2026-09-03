using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// The request body for the getFeaturedOfferExpectedPriceBatch operation.
/// </summary>
public record GetFeaturedOfferExpectedPriceBatchRequest
{
    /// <summary>
    /// A batched list of FOEP requests.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("requests")]
    [MinLength(1)]
    public IReadOnlyList<FeaturedOfferExpectedPriceRequest>? Requests { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
