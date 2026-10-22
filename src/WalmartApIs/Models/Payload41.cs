using System.Collections.Generic;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;
using WalmartApIs.Models.Enums;

namespace WalmartApIs.Models;

/// <summary>
/// Response payload.
/// </summary>
public record Payload41
{
    /// <summary>
    /// The total number of items found.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US only&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("totalItems")]
    public int? TotalItems { get; init; }

    /// <summary>
    /// The total number of items fetched.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US only&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("fetchedItems")]
    public int? FetchedItems { get; init; }

    /// <summary>
    /// Date range to filter impressions, page views, and sales.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US only&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("dateRange")]
    public DateRange4? DateRange { get; init; } = DateRange4._7Days;

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("items")]
    public IReadOnlyList<Item121>? Items { get; init; }

    /// <summary>
    /// Specifies the searchId to fetch the subsequent set of results.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US only&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("scrollId")]
    public string? ScrollId { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
