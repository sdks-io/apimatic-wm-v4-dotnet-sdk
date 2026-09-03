using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// The request associated with the getListingOffersBatch API call.
/// </summary>
public record GetListingOffersBatchRequest
{
    /// <summary>
    /// A list of getListingOffers batched requests to run.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("requests")]
    [MinLength(1)]
    [MaxLength(20)]
    public IReadOnlyList<ListingOffersRequest>? Requests { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
