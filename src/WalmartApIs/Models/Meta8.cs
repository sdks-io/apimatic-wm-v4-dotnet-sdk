using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;
using WalmartApIs.Core.Validation.Attributes;

namespace WalmartApIs.Models;

/// <summary>
/// Meta information for the response. &lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US only&lt;/span&gt;&lt;/b&gt;
/// </summary>
public record Meta8
{
    /// <summary>
    /// The total number of records are present for the requested variants based on the primary variant item ID.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("totalRecords")]
    public int? TotalRecords { get; init; }

    /// <summary>
    /// The number of records fetched in the response.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("recordsFetched")]
    public int? RecordsFetched { get; init; }

    /// <summary>
    /// Number of records expected in the request
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("limit")]
    [Minimum(1)]
    [Maximum(200)]
    public int? Limit { get; init; } = 200;

    /// <summary>
    /// The string returned from the initial API call to indicate nextCursor. Specify nextCursor value to retrieve the next set of records.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("nextCursor")]
    public string? NextCursor { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
