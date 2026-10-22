using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;
using WalmartApIs.Core.Validation.Attributes;

namespace WalmartApIs.Models;

/// <summary>
/// Pagination configuration for campaign recommendations.
/// <para>
/// <b>Defaults when page is not provided</b>: <c>offset=0</c>, <c>limit=10</c>
/// </para>
/// <para>
/// Both <c>offset</c> and <c>limit</c> are required when the <c>page</c> object is provided.
/// </para>
/// </summary>
public record CampaignRecommendationsPage
{
    /// <summary>
    /// The starting position for fetching records (0-based).
    /// <para>
    /// <b>Constraints</b>: Must be zero or a positive value
    /// <b>Default</b>: 0 (when page is not provided)
    /// </para>
    /// </summary>
    [JsonPropertyName("offset")]
    [Minimum(0)]
    public int Offset { get; init; } = 0;

    /// <summary>
    /// Maximum number of records to fetch per page.
    /// <para>
    /// <b>Constraints</b>: Must be between 1 and 100
    /// <b>Default</b>: 10 (when page is not provided)
    /// </para>
    /// </summary>
    [JsonPropertyName("limit")]
    [Minimum(1)]
    [Maximum(100)]
    public int Limit { get; init; } = 10;

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
