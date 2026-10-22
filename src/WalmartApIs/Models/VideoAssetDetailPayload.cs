using System.Collections.Generic;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// Rich media content for a VIDEO type asset.
/// </summary>
public record VideoAssetDetailPayload
{
    /// <summary>
    /// Discriminator field identifying this as a VIDEO asset.
    /// </summary>
    [JsonPropertyName("mediaType")]
    public string MediaType { get; } = "VIDEO";

    /// <summary>
    /// Closed caption tracks associated with the video. May be empty if no captions are available.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("richMediaClosedCaption")]
    public IReadOnlyList<RichMediaClosedCaption>? RichMediaClosedCaption { get; init; }

    /// <summary>
    /// URL of the video asset file.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("richMediaVideoAssetUrl")]
    public string? RichMediaVideoAssetUrl { get; init; }

    /// <summary>
    /// Category classifying the type of video content.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("richMediaVideoCategory")]
    public string? RichMediaVideoCategory { get; init; }

    /// <summary>
    /// Display title of the video.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("richMediaVideoTitle")]
    public string? RichMediaVideoTitle { get; init; }

    /// <summary>
    /// URL of the video thumbnail image.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("richMediaVideoThumbnailUrl")]
    public string? RichMediaVideoThumbnailUrl { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
