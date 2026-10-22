using System.Collections.Generic;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// List of ingestion status details for items in the feed.
/// </summary>
public record ItemDetails5
{
    /// <summary>
    /// The ingestion status of an individual item.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("itemIngestionStatus")]
    public IReadOnlyList<ItemIngestionStatus>? ItemIngestionStatus { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
