using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;
using WalmartApIs.Core.Validation;
using WalmartApIs.Core.Validation.Attributes;
using WalmartApIs.Models.Enums;

namespace WalmartApIs.Models;

/// <summary>
/// Video rich media block. Required when <c>SupplierItemFeedHeader.subCategory</c> is <c>video</c>.
/// </summary>
public record VideoAsset
{
    /// <summary>
    /// Accessible URL for the hosted video asset.
    /// </summary>
    [JsonPropertyName("richMediaVideoAssetUrl")]
    [Format(FormatKind.Uri)]
    public required string RichMediaVideoAssetUrl { get; init; }

    /// <summary>
    /// Display title for the video.
    /// </summary>
    [JsonPropertyName("richMediaVideoTitle")]
    public required string RichMediaVideoTitle { get; init; }

    /// <summary>
    /// Accessible URL for the video thumbnail image.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("richMediaVideoThumbnailUrl")]
    [Format(FormatKind.Uri)]
    public string? RichMediaVideoThumbnailUrl { get; init; }

    /// <summary>
    /// Video category label. Allowed value: <c>Product Overview</c>.
    /// </summary>
    [JsonPropertyName("richMediaVideoCategory")]
    public string RichMediaVideoCategory { get; } = "Product Overview";

    /// <summary>
    /// Operation type. Allowed values: <c>Delink</c> and <c>null</c>(empty). Set to <c>Delink</c> to remove the GTIN association from this asset. Set to <c>null</c> (empty) for create/edit operations.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("mediaOperations")]
    public MediaOperations? MediaOperations { get; init; }

    /// <summary>
    /// Closed caption entry for the video. Maximum allowed: 1.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("richMediaClosedCaption")]
    [MaxLength(1)]
    public IReadOnlyList<ClosedCaption>? RichMediaClosedCaption { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
