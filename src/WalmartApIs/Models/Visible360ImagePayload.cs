using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// Visible block for a 360-spin image rich media asset. Discriminator for this block is set as subcategory: <c>IMAGES360</c>
/// </summary>
public record Visible360ImagePayload
{
    /// <summary>
    /// 360-spin image rich media block. Required when <c>SupplierItemFeedHeader.subCategory</c> is <c>360_spin_image</c>.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("360SpinImage")]
    public SpinImageAsset? SpinImage360 { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
