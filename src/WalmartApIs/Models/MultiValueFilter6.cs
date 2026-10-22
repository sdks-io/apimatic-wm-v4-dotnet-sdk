using System.Collections.Generic;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;
using WalmartApIs.Models.Enums;

namespace WalmartApIs.Models;

/// <summary>
/// Filters based on multiple values associated with a specific parameter.
/// No parameter should be repeated.
/// </summary>
public record MultiValueFilter6
{
    /// <summary>
    /// | Attribute | Description | Data Type |
    /// | --- | ----------- | ------- |
    /// | BRAND &lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US, CA, MX&lt;/span&gt;&lt;/b&gt; | To filter based on list of brands which are associated with the assortment recommendations | string |
    /// | CATEGORY &lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US, CA, MX&lt;/span&gt;&lt;/b&gt; | To filter based on list of categories which are associated with the assortment recommendations | string |
    /// | PRODUCT_TYPE &lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US only&lt;/span&gt;&lt;/b&gt; | To filter based on list of product types which are associated with the assortment recommendations | string |
    /// </summary>
    [JsonPropertyName("parameter")]
    public required Parameter15 Parameter { get; init; }

    /// <summary>
    /// A list of values corresponds to the parameter in the filter. The values in the list should not be null or blank. Maximum size of the list should be 7.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("values")]
    public IReadOnlyList<string>? Values { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
