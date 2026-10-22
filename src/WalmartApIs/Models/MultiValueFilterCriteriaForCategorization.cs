using System.Collections.Generic;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;
using WalmartApIs.Models.Enums;

namespace WalmartApIs.Models;

/// <summary>
/// Filters based on multiple values associated with a specific parameter.
/// No parameter should be repeated.
/// </summary>
public record MultiValueFilterCriteriaForCategorization
{
    /// <summary>
    /// | Attribute | Description | Data Type |
    /// | --- | ----------- | ------- |
    /// | BRAND | To filter based on list of brands which are associated with the assortment recommendations. This is allowed when the categorization type is CATEGORY | string |
    /// | CATEGORY | To filter based on list of categories which are associated with the assortment recommendations. This is allowed when the categorization type is BRAND | string |
    /// </summary>
    [JsonPropertyName("parameter")]
    public required Parameter12 Parameter { get; init; }

    /// <summary>
    /// A list of values corresponds to the parameter in the filter. The values in the list should not be null or blank. Maximum 7 values are allowed in the list.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("values")]
    public IReadOnlyList<string>? Values { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
