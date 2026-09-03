using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;
using WalmartApIs.Models.Enums;

namespace WalmartApIs.Models;

/// <summary>
/// Common request parameters for ItemOffersRequest and ListingOffersRequest.
/// </summary>
public record BatchOffersRequestParams
{
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

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
