using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// An individual FOEP request for a particular SKU.
/// </summary>
public record FeaturedOfferExpectedPriceRequest
{
    /// <summary>
    /// A marketplace identifier.
    /// </summary>
    [JsonPropertyName("marketplaceId")]
    public required string MarketplaceId { get; init; }

    /// <summary>
    /// The seller stock keeping unit (SKU) of the item.
    /// </summary>
    [JsonPropertyName("sku")]
    public required string Sku { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
