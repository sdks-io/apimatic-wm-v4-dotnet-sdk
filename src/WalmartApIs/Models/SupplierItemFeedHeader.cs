using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;
using WalmartApIs.Models.Enums;

namespace WalmartApIs.Models;

/// <summary>
/// Metadata header for the rich media feed.
/// </summary>
public record SupplierItemFeedHeader
{
    /// <summary>
    /// Feed type identifier. Allowed value: <c>OMNI_RICH_MEDIA</c>.
    /// </summary>
    [JsonPropertyName("feedType")]
    public string FeedType { get; } = "OMNI_RICH_MEDIA";

    /// <summary>
    /// Locale code for the feed content.
    /// </summary>
    [JsonPropertyName("locale")]
    public required string Locale { get; init; }

    /// <summary>
    /// Schema version string for the feed.
    /// </summary>
    [JsonPropertyName("version")]
    public required string Version { get; init; }

    /// <summary>
    /// Rich media sub-category that determines the required Visible block. Allowed values: <c>video</c>, <c>360_spin_image</c>.
    /// </summary>
    [JsonPropertyName("subCategory")]
    public required SubCategory SubCategory { get; init; }

    /// <summary>
    /// Subset that identifies the feed source or audience. Allowed value: <c>EXTERNAL</c>.
    /// </summary>
    [JsonPropertyName("subset")]
    public string Subset { get; } = "EXTERNAL";

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
