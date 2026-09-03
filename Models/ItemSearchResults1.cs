using System.Collections.Generic;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

public record ItemSearchResults1
{
    /// <summary>
    /// Total number of matching listings items
    /// </summary>
    [JsonPropertyName("numberOfResults")]
    public required int NumberOfResults { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("pagination")]
    public PaginationModel? Pagination { get; init; }

    [JsonPropertyName("items")]
    public required IReadOnlyList<Item1> Items { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
