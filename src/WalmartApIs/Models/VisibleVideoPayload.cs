using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// Visible block for a video rich media asset. Discriminator for this block is set as subcategory: <c>VIDEO</c>
/// </summary>
public record VisibleVideoPayload
{
    /// <summary>
    /// Video rich media block. Required when <c>SupplierItemFeedHeader.subCategory</c> is <c>video</c>.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("Video")]
    public VideoAsset? Video { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
