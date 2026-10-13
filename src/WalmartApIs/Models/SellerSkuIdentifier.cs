using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// Schema to identify an item by MarketPlaceId, SellerId, and SellerSKU.
/// </summary>
public record SellerSkuIdentifier
{
    /// <summary>
    /// A marketplace identifier.
    /// </summary>
    [JsonPropertyName("MarketplaceId")]
    public required string MarketplaceId { get; init; }

    /// <summary>
    /// The seller identifier submitted for the operation.
    /// </summary>
    [JsonPropertyName("SellerId")]
    public required string SellerId { get; init; }

    /// <summary>
    /// The seller stock keeping unit (SKU) of the item.
    /// </summary>
    [JsonPropertyName("SellerSKU")]
    public required string SellerSku { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
