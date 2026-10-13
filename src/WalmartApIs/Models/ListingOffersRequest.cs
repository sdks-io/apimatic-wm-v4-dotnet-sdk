using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;
using WalmartApIs.Models.Enums;

namespace WalmartApIs.Models;

/// <summary>
/// List of request parameters accepted by the getListingOffers operation.
/// </summary>
public record ListingOffersRequest
{
    /// <summary>
    /// The resource path of the operation being called in batch, without query parameters.
    /// </summary>
    [JsonPropertyName("uri")]
    public required string Uri { get; init; }

    /// <summary>
    /// The HTTP method associated with the individual APIs being called as part of the batch request.
    /// </summary>
    [JsonPropertyName("method")]
    public required HttpMethodEnum Method { get; init; }

    /// <summary>
    /// A mapping of additional HTTP headers to send for the individual batch request.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("headers")]
    public object? Headers { get; init; }

    /// <summary>
    /// A marketplace identifier.
    /// </summary>
    [JsonPropertyName("MarketplaceId")]
    public required string MarketplaceId { get; init; }

    /// <summary>
    /// Indicates the condition of the item. Possible values: New, Used, Collectible, Refurbished, Club.
    /// </summary>
    [JsonPropertyName("ItemCondition")]
    public required ConditionType2 ItemCondition { get; init; }

    /// <summary>
    /// Indicates whether to request Consumer or Business offers. Default is Consumer.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("CustomerType")]
    public CustomerType? CustomerType { get; init; }

    /// <summary>
    /// The seller stock keeping unit (SKU) of the item.
    /// </summary>
    [JsonPropertyName("SellerSKU")]
    public required string SellerSku { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
