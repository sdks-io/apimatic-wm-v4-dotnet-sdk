using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

public record RichMediaClosedCaption
{
    /// <summary>
    /// Human-readable language name for this caption track.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("richMediaCaptionLanguage")]
    public string? RichMediaCaptionLanguage { get; init; }

    /// <summary>
    /// URL of the closed caption file in <c>.vtt</c> format.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("richMediaVideoClosedCaptionUrl")]
    public string? RichMediaVideoClosedCaptionUrl { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
