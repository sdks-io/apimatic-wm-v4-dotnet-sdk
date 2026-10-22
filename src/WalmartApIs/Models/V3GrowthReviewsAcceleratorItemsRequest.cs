using System.Collections.Generic;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

public record V3GrowthReviewsAcceleratorItemsRequest
{
    /// <summary>
    /// Defines the search criteria for filtering items. This allows searching by product name or SKU to match specific items in the marketplace.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US only&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("search")]
    public IReadOnlyList<Search1>? Search { get; init; }

    /// <summary>
    /// Specifies the filter request.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US only&lt;/b&gt;
    /// </summary>
    [JsonPropertyName("filter")]
    public required Filter1 Filter { get; init; }

    /// <summary>
    /// Specifies the sort request.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US only&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("sort")]
    public IReadOnlyList<Sort1>? Sort { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
