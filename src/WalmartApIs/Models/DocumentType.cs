using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;
using WalmartApIs.Models.Enums;

namespace WalmartApIs.Models;

/// <summary>
/// Object describing a single uploaded document.
/// </summary>
public record DocumentType
{
    /// <summary>
    /// Original file name as uploaded.
    /// </summary>
    [JsonPropertyName("fileName")]
    public required string FileName { get; init; }

    /// <summary>
    /// Document category.
    /// </summary>
    [JsonPropertyName("type")]
    public required Type1 Type { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
