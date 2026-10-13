using System.Collections.Generic;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;
using WalmartApIs.Models.Enums;

namespace WalmartApIs.Models;

public record Issue
{
    /// <summary>
    /// Machine-readable issue code
    /// </summary>
    [JsonPropertyName("code")]
    public required string Code { get; init; }

    /// <summary>
    /// Human-readable issue message (locale-aware)
    /// </summary>
    [JsonPropertyName("message")]
    public required string Message { get; init; }

    [JsonPropertyName("severity")]
    public required Severity Severity { get; init; }

    /// <summary>
    /// Affected attribute names
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("attributeNames")]
    public IReadOnlyList<string>? AttributeNames { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
