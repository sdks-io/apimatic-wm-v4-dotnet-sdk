using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// The response associated with the getListingOffersBatch API call.
/// </summary>
public record GetListingOffersBatchResponse
{
    /// <summary>
    /// A list of getListingOffers batched responses.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("responses")]
    [MinLength(1)]
    [MaxLength(20)]
    public IReadOnlyList<ListingOffersResponse>? Responses { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
