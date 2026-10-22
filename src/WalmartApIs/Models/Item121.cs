using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;
using WalmartApIs.Models.Enums;

namespace WalmartApIs.Models;

public record Item121
{
    /// <summary>
    /// Specifies the item identifier.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US only&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("itemId")]
    public string? ItemId { get; init; }

    /// <summary>
    /// Name of the item.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US only&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("itemName")]
    public string? ItemName { get; init; }

    /// <summary>
    /// Units sold during the specified date range. The default date range is the last 7 days. May be null when data is unavailable for the item.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US only&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("sales")]
    public int? Sales { get; init; }

    /// <summary>
    /// Current number of reviews on the item.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US only&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("currentReviews")]
    public int? CurrentReviews { get; init; }

    /// <summary>
    /// The number of times the item appeared in search results during the specified date range. The default date range is the last 7 days. May be null when data is unavailable for the item.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US only&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("impressions")]
    public int? Impressions { get; init; }

    /// <summary>
    /// The number of views on the item page during the specified date range. The default date range is the last 7 days. May be null when data is unavailable for the item.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US only&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("currentPageViews")]
    public int? CurrentPageViews { get; init; }

    /// <summary>
    /// The number of reviews collected for the item through IRP.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US only&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("reviewsCollected")]
    public int? ReviewsCollected { get; init; }

    /// <summary>
    /// Represents the Stock Keeping Unit (SKU), which is a unique identifier as defined by the seller. This identifier helps in tracking inventory and managing items efficiently.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US only&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("sku")]
    public string? Sku { get; init; }

    /// <summary>
    /// Current status of the item in IRP.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US only&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("itemStatus")]
    public ItemStatus9? ItemStatus { get; init; }

    /// <summary>
    /// Priority of the item as recommended by Walmart.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US only&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("itemPriority")]
    public int? ItemPriority { get; init; }

    /// <summary>
    /// Indicates whether the item is a customer favorite. When the isCustomerFavorite request filter is omitted, this field may be true, false, or null depending on available item data. When the filter is provided, only items matching the filter value are returned (true returns only customer favorites; false returns only non-customer favorites).&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US only&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("isCustomerFavorite")]
    public bool? IsCustomerFavorite { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
