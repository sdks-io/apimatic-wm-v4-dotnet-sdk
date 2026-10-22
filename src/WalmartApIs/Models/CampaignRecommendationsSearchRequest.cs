using System.Collections.Generic;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// Request DTO for searching campaign-level recommendations.
/// <para>
/// All fields are optional. The request body itself is also optional — when absent, sensible defaults are applied:
/// - <c>page.offset</c>: 0
/// - <c>page.limit</c>: 10
/// - No filters, no sorting
/// </para>
/// <para>
/// <b>Filter behavior</b>: Filters are combined using the AND operator. Multiple values within a single filter act as OR.
/// </para>
/// </summary>
public record CampaignRecommendationsSearchRequest
{
    /// <summary>
    /// Pagination configuration for campaign recommendations.
    /// <para>
    /// <b>Defaults when page is not provided</b>: <c>offset=0</c>, <c>limit=10</c>
    /// </para>
    /// <para>
    /// Both <c>offset</c> and <c>limit</c> are required when the <c>page</c> object is provided.
    /// </para>
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("page")]
    public CampaignRecommendationsPage? Page { get; init; }

    /// <summary>
    /// Sorting configuration for ordering search results.
    /// <para>
    /// Both <c>field</c> and <c>order</c> are required when the <c>sort</c> object is provided.
    /// </para>
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("sort")]
    public RecommendationsSort? Sort { get; init; }

    /// <summary>
    /// List of filters to narrow down results.
    /// Multiple filters are combined using the AND operator.
    /// Each filter field must be specified only once (no duplicates).
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("filters")]
    public IReadOnlyList<CampaignRecommendationsFilter>? Filters { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
