using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// Specifies the identifiers used to uniquely identify an item.
/// </summary>
public record IdentifierType1
{
    /// <summary>
    /// Schema to identify an item by MarketPlaceId and Walmart Item ID .
    /// </summary>
    [JsonPropertyName("MarketplaceItem")]
    public required WalmartItemIdentifier MarketplaceItem { get; init; }

    /// <summary>
    /// Schema to identify an item by MarketPlaceId, SellerId, and SellerSKU.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("SKUIdentifier")]
    public SellerSkuIdentifier? SkuIdentifier { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
