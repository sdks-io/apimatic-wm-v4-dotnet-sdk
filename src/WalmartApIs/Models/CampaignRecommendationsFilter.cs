using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;
using WalmartApIs.Models.Enums;

namespace WalmartApIs.Models;

/// <summary>
/// Filter configuration to narrow down campaign recommendation results.
/// <para>
/// <b>Validation Rules</b>:
/// - Both <c>field</c> and <c>values</c> are required when a filter is provided
/// - Each filter field must be specified only once (no duplicate fields)
/// - Filter values must contain at least one value
/// - Multiple values within a filter act as an OR condition
/// - Multiple filters are combined using the AND operator.
/// </para>
/// </summary>
public record CampaignRecommendationsFilter
{
    /// <summary>
    /// Field by which the filtering is to be done.
    /// <para>
    /// <b>Supported fields</b>:
    /// - <c>campaignIds</c>: Filter by specific campaign identifiers
    /// - <c>recommendationType</c>: Filter by recommendation type (<c>BUDGET</c>, <c>BIDDING_STRATEGY</c>)
    /// </para>
    /// </summary>
    [JsonPropertyName("field")]
    public required Field3 Field { get; init; }

    /// <summary>
    /// List of values for the specified field.
    /// Multiple values act as an OR condition within the filter.
    /// <para>
    /// <b>Valid values by field</b>:
    /// - <c>campaignIds</c>: Numeric string campaign IDs
    /// - <c>recommendationType</c>: <c>BUDGET</c>, <c>BIDDING_STRATEGY</c>
    /// </para>
    /// </summary>
    [JsonPropertyName("values")]
    [MinLength(1)]
    public required IReadOnlyList<string> Values { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
