using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;
using WalmartApIs.Models.Enums;

namespace WalmartApIs.Models;

public record V3GrowthAssortmentRecommendationsCategorizationCountsRequest
{
    /// <summary>
    /// | Attribute | Description | Data Type |
    /// | --- | ----------- | ------- |
    /// | BRAND | To get list of brands which are associated with the assortment recommendations | string |
    /// | CATEGORY | To get list of categories which are associated with the assortment recommendations | string |
    /// <para>
    /// &lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US | CA | MX&lt;/span&gt;&lt;/b&gt;
    /// </para>
    /// </summary>
    [JsonPropertyName("categorizationType")]
    public required CategorizationType3 CategorizationType { get; init; }

    /// <summary>
    /// Meta information for the request. &lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US only&lt;/span&gt;&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("meta")]
    public Meta10? Meta { get; init; }

    /// <summary>
    /// Different type of filters can be passed in this object.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US | CA | MX&lt;/span&gt;&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("filterCriteria")]
    public FilterCriteria4? FilterCriteria { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
