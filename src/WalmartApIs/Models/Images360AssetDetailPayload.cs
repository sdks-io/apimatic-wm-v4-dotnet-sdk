using System.Collections.Generic;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// Rich media content for an <c>IMAGES360</c> type asset.
/// </summary>
public record Images360AssetDetailPayload
{
    /// <summary>
    /// Discriminator field identifying this as an IMAGES360 asset.
    /// </summary>
    [JsonPropertyName("mediaType")]
    public string MediaType { get; } = "IMAGES360";

    /// <summary>
    /// Ordered list of 360-spin image frame URLs, numbered sequentially from <c>_1</c> to <c>_24</c>.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("richMediaImageUrl")]
    public IReadOnlyList<string>? RichMediaImageUrl { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
