using System.Collections.Generic;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// The <c>listPackingOptions</c> response.
/// </summary>
public record ListPackingOptionsResponse
{
    /// <summary>
    /// List of packing options.
    /// </summary>
    [JsonPropertyName("packingOptions")]
    public required IReadOnlyList<CommonPackingOption> PackingOptions { get; init; }

    /// <summary>
    /// Contains tokens to fetch from a certain page.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("pagination")]
    public CommonPagination? Pagination { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
