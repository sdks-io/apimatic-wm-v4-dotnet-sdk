using System.Collections.Generic;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;
using WalmartApIs.Models.Enums;

namespace WalmartApIs.Models;

public record Filter
{
    /// <summary>
    /// | Attribute | Description | Data Type
    /// | --- | ----------- | -------
    /// | contentDiscoverabilityPercentage | Item's content and discoverability score expressed as a percentage. | string |
    /// | qualityScorePercentage | Item's overall Listing Quality score, rated as a percentage. | string |
    /// | offerPercentage | Item's offer score, based on: item price, shipping price and speed, and in-stock rate.| string |
    /// | ratingReviewsPercentage | Rating and reviews score, as a percentage. | string |
    /// | viewTrendingItems | Indicates to return details for trending items that have non-zero page views. Acceptable values are "true" if pageView &gt; 0, or "false" if pageView &gt;= 0. | string |
    /// | viewPostPurchaseItems | Show items with post-purchase quality issues. If item has post-purchase value &gt;= 1, it filters all items greater or equal based on post purchase value. | string |
    /// | wfsFlag | Show WFS-eligible items. Value of this parameter can be true or false. | string |
    /// | categoryName | Item's category name. | string |
    /// | hasIssues | Provides a count of item with issues. | integer |
    /// | productType | Product type to classify the item (e.g. Pants). | string|
    /// | attributeList | List of all available filter attributes. | string |
    /// | productTypes | List of all available product. | List&lt;String&gt; |
    /// | brandList | List of all available brand. | List&lt;String&gt; |
    /// | oos | Filter using out of stock offer based on days. Min value = 0, Max Value = 7. | integer |
    /// | fastAndFreeShipping | Possible values are 1 for offers eligible for free shipping and 0 for offers not eligible for free shipping. No value shows all the offers. | integer |
    /// | priceMeetBeatFlag | Possible values are -1 for no match, 0 for lose, 1 for meets and 2 for beats. No value shows all the offers. | integer |
    /// | conditionList | Specifies the condition of the item. Can take values (New, New without box, New without tags, Restored Premium, Restored, Remanufactured, Open Box, Pre-Owned: Like New, Pre-Owned: Good, Pre-Owned: Fair, New with defects) | List&lt;String&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("field")]
    public Field4? Field { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("op")]
    public Op? Op { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("values")]
    public IReadOnlyList<int>? Values { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
