using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;
using WalmartApIs.Models.Enums;

namespace WalmartApIs.Models;

/// <summary>
/// Filter configuration to narrow down item diagnostic results.
/// <para>
/// <b>Validation Rules</b>:
/// - Both <c>field</c> and <c>values</c> are required when a filter is provided
/// - Each filter field must be specified only once (no duplicate fields)
/// - Each filter field supports a maximum of 100 values
/// - Filter values are case-insensitive
/// - Multiple values within a filter act as an OR condition
/// - Multiple filters are combined with AND logic
/// </para>
/// </summary>
public record ItemDiagnosticFilter
{
    /// <summary>
    /// Field by which the filtering is to be done.
    /// <para>
    /// <b>Supported fields</b>:
    /// - <c>issues</c>: Filter by specific issue types (For example, <c>ITEM_OUT_OF_STOCK</c>, <c>TITLE_TOO_LONG</c>)
    /// - <c>issueCategory</c>: Filter by issue severity category (<c>LIMITED</c>, <c>BLOCKED</c>, <c>NO_ISSUES</c>)
    /// - <c>itemId</c>: Filter by Walmart item IDs (numeric strings). Currently filters within items in active SEM campaigns. *In a future release, this will also support items not yet associated with any campaign.*
    /// </para>
    /// </summary>
    [JsonPropertyName("field")]
    public required Field2 Field { get; init; }

    /// <summary>
    /// List of values for the specified field.
    /// Multiple values act as an OR condition within the filter.
    /// <para>
    /// <b>Constraints</b>: At least 1 value required, maximum 100 values per filter.
    /// </para>
    /// <para>
    /// <b>Valid values by field</b>:
    /// - <c>issues</c>: Any valid <c>issueType</c> enum value (Refer to the issue types endpoint)
    /// - <c>issueCategory</c>: <c>LIMITED</c>, <c>BLOCKED</c>, <c>NO_ISSUES</c>
    /// - <c>itemId</c>: Numeric string item IDs (currently scoped to items in active SEM campaigns)
    /// </para>
    /// </summary>
    [JsonPropertyName("values")]
    [MinLength(1)]
    [MaxLength(100)]
    public required IReadOnlyList<string> Values { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
