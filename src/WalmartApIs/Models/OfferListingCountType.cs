using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// The number of offer listings with the specified condition.
/// </summary>
public record OfferListingCountType
{
    /// <summary>
    /// The number of offer listings.
    /// </summary>
    [JsonPropertyName("Count")]
    public required int Count { get; init; }

    /// <summary>
    /// The condition of the item.
    /// </summary>
    [JsonPropertyName("condition")]
    public required string Condition { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
