using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// List of items with performance data
/// </summary>
public record SemItemReport
{
    /// <summary>
    /// A unique ID which identifies the item.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("itemId")]
    public string? ItemId { get; init; }

    /// <summary>
    /// An arbitrary alphanumeric unique ID, specified by the seller, which identifies each item.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("sku")]
    public string? Sku { get; init; }

    /// <summary>
    /// Product ID of the item
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("productId")]
    public string? ProductId { get; init; }

    /// <summary>
    /// A seller-specified, alphanumeric string uniquely identifying the product name.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("productName")]
    public string? ProductName { get; init; }

    /// <summary>
    /// Category of the item.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("categoryName")]
    public string? CategoryName { get; init; }

    /// <summary>
    /// URL where the item can be viewed.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("productUrl")]
    public string? ProductUrl { get; init; }

    /// <summary>
    /// URL of the image representing the item.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("productImageUrl")]
    public string? ProductImageUrl { get; init; }

    /// <summary>
    /// Status of the item
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("status")]
    public string? Status { get; init; }

    /// <summary>
    /// OLQ Score of the item
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("olqScore")]
    public double? OlqScore { get; init; }

    /// <summary>
    /// Offer Price
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("offerPrice")]
    public double? OfferPrice { get; init; }

    /// <summary>
    /// Competitor Price
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("competitorPrice")]
    public double? CompetitorPrice { get; init; }

    /// <summary>
    /// Google Price
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("googlePrice")]
    public double? GooglePrice { get; init; }

    /// <summary>
    /// Performance data of the campaign
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("traffic")]
    public SemTraffic? Traffic { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
