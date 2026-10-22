using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// Different type of filters can be passed in this object.
/// </summary>
public record FilterCriteria3
{
    /// <summary>
    /// To filter with a search text having a word that can be part of the recommended data.
    ///  searchText for US 'and', for CA and MX 'Rio'. &lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US | CA | MX&lt;/span&gt;&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("searchText")]
    [MinLength(3)]
    public string? SearchText { get; init; }

    /// <summary>
    /// Filters based on multiple values associated with a specific parameter.
    /// No parameter should be repeated. &lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US | CA | MX&lt;/span&gt;&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("multiValueFilter")]
    public IReadOnlyList<MultiValueFilter6>? MultiValueFilter { get; init; }

    /// <summary>
    /// Filter based on preset parameters and their associated values is possible with EnumFilter.
    /// No parameter should be repeated. &lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US only&lt;/span&gt;&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("enumFilter")]
    public IReadOnlyList<EnumFilter4>? EnumFilter { get; init; }

    /// <summary>
    /// Filter based on a range with <c>RangeFilter</c>. You must also pass a parameter along with any of the beginning or the ending points or both.
    /// No parameter should be repeated.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US | CA | MX&lt;/span&gt;&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("rangeFilter")]
    public IReadOnlyList<RangeFilter3>? RangeFilter { get; init; }

    /// <summary>
    /// Filters the Top Go-Get Items, which are high-demand, customer-favorite items that sellers should prioritize adding to their Walmart catalog. Set to <c>true</c> to return only Top Go-Get Items.
    /// &lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US | CA | MX&lt;/span&gt;&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("isTopGoGetItem")]
    public bool? IsTopGoGetItem { get; init; }

    /// <summary>
    /// Filter for newly added recommendations. These are high-demand, customer-favorite items added to the recommendation set within the past 30 days. Set to <c>true</c> to return only these items.
    /// &lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US | CA | MX&lt;/span&gt;&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("isNewRecommendation")]
    public bool? IsNewRecommendation { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
