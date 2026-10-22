using System.Collections.Generic;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

public record RowFilter
{
    [JsonPropertyName("type")]
    public required string Type { get; init; }

    [JsonPropertyName("values")]
    public required IReadOnlyList<string> Values { get; init; }

    [JsonPropertyName("columnName")]
    public required string ColumnName { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
