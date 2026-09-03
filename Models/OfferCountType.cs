using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;
using WalmartApIs.Models.Enums;

namespace WalmartApIs.Models;

/// <summary>
/// The total number of offers for the specified condition and fulfillment channel.
/// </summary>
public record OfferCountType
{
    /// <summary>
    /// Indicates the condition of the item. For example: New, Used, Collectible, Refurbished, or Club.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("condition")]
    public string? Condition { get; init; }

    /// <summary>
    /// Indicates whether the item is fulfilled by the seller or by Walmart Fulfillment Services.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("fulfillmentChannel")]
    public FulfillmentChannelType? FulfillmentChannel { get; init; }

    /// <summary>
    /// The number of offers in a fulfillment channel that meet a specific condition.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("OfferCount")]
    public int? OfferCount { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
