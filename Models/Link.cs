using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;
using WalmartApIs.Core.Validation;
using WalmartApIs.Core.Validation.Attributes;

namespace WalmartApIs.Models;

public record Link
{
    /// <summary>
    /// URI to resolve the restriction (e.g. approval request URL)
    /// </summary>
    [JsonPropertyName("resource")]
    [Format(FormatKind.Uri)]
    public required string Resource { get; init; }

    [JsonPropertyName("verb")]
    public string Verb { get; } = "GET";

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("title")]
    public string? Title { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("type")]
    public string? Type { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
