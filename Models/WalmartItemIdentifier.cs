using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// Schema to identify an item by MarketPlaceId and Walmart Item ID .
/// </summary>
public record WalmartItemIdentifier
{
    /// <summary>
    /// A marketplace identifier.
    /// </summary>
    [JsonPropertyName("MarketplaceId")]
    public required string MarketplaceId { get; init; }

    /// <summary>
    /// The Walmart Item ID of the item.
    /// </summary>
    [JsonPropertyName("walmartItemId")]
    public required string WalmartItemId { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
