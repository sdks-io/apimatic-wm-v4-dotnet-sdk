using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;
using WalmartApIs.Core.Validation;
using WalmartApIs.Core.Validation.Attributes;

namespace WalmartApIs.Models;

/// <summary>
/// A single closed caption entry for a video asset.
/// </summary>
public record ClosedCaption
{
    /// <summary>
    /// URL of the closed caption file in <c>.vtt</c> format.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("richMediaClosedCaptioningUrl")]
    [Format(FormatKind.Uri)]
    public string? RichMediaClosedCaptioningUrl { get; init; }

    /// <summary>
    /// Language of the captions.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("richMediaCaptionLanguage")]
    public string? RichMediaCaptionLanguage { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
