using System.Collections.Generic;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;
using WalmartApIs.Models.Enums;

namespace WalmartApIs.Models;

public record Filter2
{
    /// <summary>
    /// | Attribute | Description | Data Type
    /// | --- | ----------- | -------
    /// | contentDiscoverabilityPercentage&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US, CA, MX&lt;/b&gt; | Item's content and discoverability score expressed as a percentage. | string |
    /// | qualityScorePercentage&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US, CA, MX&lt;/b&gt; | Item's overall Listing Quality score, rated as a percentage. | string |
    /// | offerPercentage&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US, CA, MX&lt;/b&gt; | Item's offer score, based on: item price, shipping price and speed, and in-stock rate.| string |
    /// | ratingReviewsPercentage&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US, CA, MX&lt;/b&gt; | Rating and reviews score, as a percentage. | string |
    /// | viewTrendingItems&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US, CA, MX&lt;/b&gt; | Indicates to return details for trending items that have non-zero page views. Acceptable values are "true" if pageView &gt; 0, or "false" if pageView &gt;= 0. | string |
    /// | viewPostPurchaseItems&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US, CA, MX&lt;/b&gt; | Show items with post-purchase quality issues. If item has post-purchase value &gt;= 1, it filters all items greater or equal based on post purchase value. | string |
    /// | wfsFlag&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US, CA, MX&lt;/b&gt; | Show WFS-eligible items. Value of this parameter can be true or false. | string |
    /// | categoryName&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US, CA, MX&lt;/b&gt; | Item's category name. | string |
    /// | hasIssues&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US, CA, MX&lt;/b&gt; | Provides a count of item with issues. | integer |
    /// | productType&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US, CA, MX&lt;/b&gt; | Product type to classify the item (e.g. Pants). | string|
    /// | attributeList&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US, CA, MX&lt;/b&gt; | List of all available filter attributes. | string |
    /// | productTypes&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US, CA, MX&lt;/b&gt; | List of all available product. | List&lt;String&gt; |
    /// | brandList&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US, CA, MX&lt;/b&gt; | List of all available brand. | List&lt;String&gt; |
    /// | oos&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US, CA, MX&lt;/b&gt; | Filter using out of stock offer based on days. Min value = 0, Max Value = 7. | integer |
    /// | fastAndFreeShipping&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US, CA, MX&lt;/b&gt; | Possible values are 1 for offers eligible for free shipping and 0 for offers not eligible for free shipping. No value shows all the offers. | integer |
    /// | priceMeetBeatFlag&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US, CA,  MX&lt;/b&gt; | Possible values are -1 for no match, 0 for lose, 1 for meets and 2 for beats. No value shows all the offers. | integer |
    /// | conditionList&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US, CA, MX&lt;/b&gt; | Specifies the condition of the item. Can take values (New, New without box, New without tags, Restored Premium, Restored, Remanufactured, Open Box, Pre-Owned: Like New, Pre-Owned: Good, Pre-Owned: Fair, New with defects) | List&lt;String&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("field")]
    public Field5? Field { get; init; }

    /// <summary>
    /// &lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US | CA | MX&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("op")]
    public Op2? Op { get; init; }

    /// <summary>
    /// &lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US | CA | MX&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("values")]
    public IReadOnlyList<int>? Values { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
