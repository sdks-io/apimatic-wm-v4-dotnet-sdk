using System.Collections.Generic;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// The response schema for the getFeaturedOfferExpectedPriceBatch operation.
/// </summary>
public record GetFeaturedOfferExpectedPriceBatchResponse
{
    /// <summary>
    /// A batched list of FOEP responses.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("responses")]
    public IReadOnlyList<FeaturedOfferExpectedPriceResponse>? Responses { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
