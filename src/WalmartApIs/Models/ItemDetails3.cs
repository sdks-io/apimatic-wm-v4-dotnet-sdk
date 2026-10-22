using System.Collections.Generic;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;
using WalmartApIs.Models.Enums;

namespace WalmartApIs.Models;

/// <summary>
/// Details of the recommended item.
/// </summary>
public record ItemDetails3
{
    /// <summary>
    /// Title of the recommended item. &lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US | CA | MX&lt;/span&gt;&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("title")]
    public string? Title { get; init; }

    /// <summary>
    /// Brand of the recommended item. &lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US | CA | MX&lt;/span&gt;&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("brand")]
    public string? Brand { get; init; }

    /// <summary>
    /// Category of the recommended item. &lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US | CA | MX&lt;/span&gt;&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("category")]
    public string? Category { get; init; }

    /// <summary>
    /// Indicates the product type of an item that can be used to set up this item using Item Setup APIs or Item setup bulk upload. &lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US only&lt;/span&gt;&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("productType")]
    public string? ProductType { get; init; }

    /// <summary>
    /// GTIN of the recommended item. &lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US | CA | MX&lt;/span&gt;&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("gtin")]
    public string? Gtin { get; init; }

    /// <summary>
    /// Universal Product Code (UPC) of the recommended item. &lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US | CA | MX&lt;/span&gt;&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("upc")]
    public string? Upc { get; init; }

    /// <summary>
    /// Stock Keeping Unit (SKU) of the recommended item. &lt;br&gt;&lt;b style='color:green;'&gt;Market availability: CA | MX&lt;/span&gt;&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("sku")]
    public string? Sku { get; init; }

    /// <summary>
    /// ISBN of the recommended item. &lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US only&lt;/span&gt;&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("isbn")]
    public string? Isbn { get; init; }

    /// <summary>
    /// European Article Number (EAN) of the recommended item. &lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US only&lt;/span&gt;&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("ean")]
    public string? Ean { get; init; }

    /// <summary>
    /// Item availability status of the recommended item. &lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US | CA | MX&lt;/span&gt;&lt;/b&gt;
    /// <para>
    /// | Attribute | Description | Data Type |
    /// | --- | ----------- | ------- |
    /// | EXISTING_IN_WALMART | Indicates that item is existing in Walmart. | string |
    /// | NEW_TO_WALMART | Indicates that item is new to Walmart. | string |
    /// </para>
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("itemAvailabilityStatus")]
    public ItemAvailabilityStatus4? ItemAvailabilityStatus { get; init; }

    /// <summary>
    /// Indicates the potential revenue the recommended item can bring in over a year.
    /// This field does not promise the numbers indicated. &lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US | CA | MX&lt;/span&gt;&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("potentialSales")]
    public string? PotentialSales { get; init; }

    /// <summary>
    /// Rank of an item, from 1 to 10 (1 being highest), that indicates the relative potential sales of a product in a category. This is an estimate based on customer demand, historical category sales and other data points. &lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US | CA | MX&lt;/span&gt;&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("potentialSalesRank")]
    public string? PotentialSalesRank { get; init; }

    /// <summary>
    /// Tags that indicate why an item is in demand, helping sellers quickly assess customer interest and competitive signal. &lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US | CA | MX&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("salesInsights")]
    public SalesInsights? SalesInsights { get; init; }

    /// <summary>
    /// Top Go‑Get Items are customer favorite items sellers are recommended to prioritize and bring to their Walmart Catalog. &lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US | CA | MX&lt;/span&gt;&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("isTopGoGetItem")]
    public bool? IsTopGoGetItem { get; init; }

    /// <summary>
    /// This field is deprecated.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("shoppingTrends")]
    public IReadOnlyList<string>? ShoppingTrends { get; init; }

    /// <summary>
    /// Indicates the months of the year when high demand is observed for the recommended item. The sequence of month is in the decreasing order of the high demand. The values are comma separated. &lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US only&lt;/span&gt;&lt;/b&gt;
    /// <para>
    /// | Attribute | Description | Data Type |
    /// | --- | ----------- | ------- |
    /// | JAN, FEB, MAR, APR, MAY, JUN, JUL, AUG, SEP, OCT, NOV, DEC | Months of the year. | string |
    /// </para>
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("demandSalesTrends")]
    public DemandSalesTrends4? DemandSalesTrends { get; init; }

    /// <summary>
    /// List of the most popular keywords that people have searched for, where the item shows up in the result set. &lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US only&lt;/span&gt;&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("searchKeywords")]
    public IReadOnlyList<string>? SearchKeywords { get; init; }

    /// <summary>
    /// Total number offers for this Item on Walmart. &lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US only&lt;/span&gt;&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("offerCount")]
    public double? OfferCount { get; init; }

    /// <summary>
    /// Indicates if the shipping is free for a recommended item which is a buy box winner. &lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US | CA | MX&lt;/span&gt;&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("freeShipping")]
    public FreeShipping? FreeShipping { get; init; }

    /// <summary>
    /// Average rating of the recommended item. &lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US only&lt;/span&gt;&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("rating")]
    public double? Rating { get; init; }

    /// <summary>
    /// Total number of ratings for the recommended item. &lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US only&lt;/span&gt;&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("ratingCount")]
    public double? RatingCount { get; init; }

    /// <summary>
    /// Primary variant item ID. &lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US only&lt;/span&gt;&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("primaryVariantItemId")]
    public string? PrimaryVariantItemId { get; init; }

    /// <summary>
    /// Indicates to ensure whether the item has variants or not. If it is  &lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US only&lt;/span&gt;&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("hasVariants")]
    public bool? HasVariants { get; init; }

    /// <summary>
    /// Walmart's item information. &lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US | CA | MX&lt;/span&gt;&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("walmart")]
    public Walmart4? Walmart { get; init; }

    /// <summary>
    /// Competitor's item information.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("competitors")]
    public IReadOnlyList<Competitor4>? Competitors { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
