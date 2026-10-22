using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;
using WalmartApIs.Core.Validation.Attributes;

namespace WalmartApIs.Models;

/// <summary>
/// Pagination configuration for controlling result set size and navigation.
/// <para>
/// The pagination uses offset-based navigation where:
/// - <c>offset</c> = starting record position (0-indexed)
/// - <c>limit</c> = number of records per page
/// </para>
/// <para>
/// <b>Internal Conversion</b>: pageNumber = (offset / limit) + 1
/// </para>
/// </summary>
public record WsrPage
{
    /// <summary>
    /// Maximum number of records to fetch per page.
    /// <para>
    /// <b>Constraints</b>: Must be a positive value
    /// <b>Default</b>: 10
    /// </para>
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("limit")]
    [Minimum(1)]
    public int? Limit { get; init; } = 10;

    /// <summary>
    /// The starting position for fetching records (0-indexed).
    /// <para>
    /// <b>Important</b>: This is a record offset, NOT a page number.
    /// - <c>offset=0</c> returns records 1-10 (with <c>limit=10</c>)
    /// - <c>offset=10</c> returns records 11-20 (with <c>limit=10</c>)
    /// </para>
    /// <para>
    /// <b>Default</b>: 0
    /// </para>
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("offset")]
    [Minimum(0)]
    public int? Offset { get; init; } = 0;

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
