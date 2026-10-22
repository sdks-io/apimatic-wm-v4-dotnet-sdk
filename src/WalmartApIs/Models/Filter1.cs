using System.Collections.Generic;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;
using WalmartApIs.Models.Enums;

namespace WalmartApIs.Models;

/// <summary>
/// Specifies the filter request.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US only&lt;/b&gt;
/// </summary>
public record Filter1
{
    /// <summary>
    /// | Attribute | Description | Data Type |
    /// | --- | ----------- | ------- |
    /// | ELIGIBLE | To get items which are eligible for the program | string |
    /// | ENROLLED | To get items which are currently enrolled into the program | string |
    /// | COMPLETE | To get items which have attained target reviews through the program | string |
    /// &lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US only&lt;/b&gt;
    /// </summary>
    [JsonPropertyName("itemStatus")]
    public required ItemStatus8 ItemStatus { get; init; }

    /// <summary>
    /// Date range to filter impressions, page views, and sales.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US only&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("dateRange")]
    public DateRange4? DateRange { get; init; } = DateRange4._7Days;

    /// <summary>
    /// Category of the items.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("category")]
    public IReadOnlyList<string>? Category { get; init; }

    /// <summary>
    /// Price range of the items.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US only&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("price")]
    public Price22? Price { get; init; }

    /// <summary>
    /// Filter items by customer favorite status. Set to true to return only customer favorite items. Set to false to return only non-customer favorite items. If omitted, all items are returned regardless of customer favorite status.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US only&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("isCustomerFavorite")]
    public bool? IsCustomerFavorite { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
