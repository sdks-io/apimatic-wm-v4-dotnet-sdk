using System.Collections.Generic;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// Search response containing paginated campaign-level recommendations and pagination metadata.
/// <para>
/// Each campaign in the <c>data</c> array includes its current settings (bidding strategy, target ROAS, daily budget) and an array of actionable recommendations with projected performance impact.
/// </para>
/// </summary>
public record CampaignRecommendationsSearchResponse
{
    /// <summary>
    /// Pagination metadata for navigating through search results.
    /// <para>
    /// Includes <c>hasNextPage</c> and <c>hasPreviousPage</c> boolean flags for
    /// convenient pagination control in UIs.
    /// </para>
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("pagination")]
    public DiagnosticPagination? Pagination { get; init; }

    /// <summary>
    /// Paginated list of campaign-level suggestions.
    /// Each campaign appears once with all its recommendations.
    /// Empty array when no campaigns match the search criteria.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("data")]
    public IReadOnlyList<CampaignSuggestion>? Data { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
