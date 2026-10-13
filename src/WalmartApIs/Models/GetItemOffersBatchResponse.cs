using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// The response associated with the getItemOffersBatch API call.
/// </summary>
public record GetItemOffersBatchResponse
{
    /// <summary>
    /// A list of getItemOffers batched responses.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("responses")]
    [MinLength(1)]
    [MaxLength(20)]
    public IReadOnlyList<ItemOffersResponse>? Responses { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
