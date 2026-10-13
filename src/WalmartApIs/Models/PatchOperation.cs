using System.Collections.Generic;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;
using WalmartApIs.Models.Enums;

namespace WalmartApIs.Models;

public record PatchOperation
{
    /// <summary>
    /// Patch operation type (JSON Patch)
    /// </summary>
    [JsonPropertyName("op")]
    public required Op Op { get; init; }

    /// <summary>
    /// JSON Pointer path to the attribute (RFC 6901)
    /// </summary>
    [JsonPropertyName("path")]
    public required string Path { get; init; }

    /// <summary>
    /// Value to set (absent for delete operations)
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("value")]
    public IReadOnlyList<object>? Value { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
