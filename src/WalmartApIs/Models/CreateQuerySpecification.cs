using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

public record CreateQuerySpecification
{
    /// <summary>
    /// Structured query string. Format TBD pending ADR:
    /// GraphQL vs Walmart-native query DSL (Pod 4).
    /// </summary>
    [JsonPropertyName("query")]
    public required string Query { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("pagination")]
    public Pagination2? Pagination { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
