using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;
using WalmartApIs.Models.Enums;

namespace WalmartApIs.Models;

public record PackageDocument
{
    [JsonPropertyName("type")]
    public required Type1 Type { get; init; }

    [JsonPropertyName("format")]
    public required Format1 Format { get; init; }

    /// <summary>
    /// Base64-encoded document bytes.
    /// </summary>
    [JsonPropertyName("contents")]
    public required string Contents { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
