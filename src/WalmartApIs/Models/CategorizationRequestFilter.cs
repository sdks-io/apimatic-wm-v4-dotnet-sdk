using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// Different type of filters can be passed in this object.
/// </summary>
public record CategorizationRequestFilter
{
    /// <summary>
    /// To filter with a search text having a word that can be part of the categorization data.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("searchText")]
    [MinLength(3)]
    public string? SearchText { get; init; }

    /// <summary>
    /// Filters based on multiple values associated with a specific parameter.
    /// No parameter should be repeated.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("multiValueFilter")]
    public IReadOnlyList<MultiValueFilterCriteriaForCategorization>? MultiValueFilter { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
