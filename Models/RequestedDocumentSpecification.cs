using System.Collections.Generic;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;
using WalmartApIs.Models.Enums;

namespace WalmartApIs.Models;

public record RequestedDocumentSpecification
{
    [JsonPropertyName("format")]
    public required Format1 Format { get; init; }

    [JsonPropertyName("size")]
    public required LabelDimensions Size { get; init; }

    [JsonPropertyName("dpi")]
    public required Dpi Dpi { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("pageLayout")]
    public PageLayout? PageLayout { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("needFileJoining")]
    public bool? NeedFileJoining { get; init; }

    /// <summary>
    /// Optional list of additional print specs (customs forms,
    /// invoice attachments, etc). Compressed; see TODO.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("printOptions")]
    public IReadOnlyList<object>? PrintOptions { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
