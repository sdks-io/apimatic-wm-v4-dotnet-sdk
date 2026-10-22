using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;
using WalmartApIs.Models.Enums;

namespace WalmartApIs.Models;

/// <summary>
/// 360-spin image rich media block. Required when <c>SupplierItemFeedHeader.subCategory</c> is <c>360_spin_image</c>.
/// </summary>
public record SpinImageAsset
{
    /// <summary>
    /// Ordered list of 24 accessible 360-spin image frame URLs, numbered sequentially with suffix from <c>_1</c> to <c>_24</c>.
    /// </summary>
    [JsonPropertyName("richMediaImageUrl")]
    [MinLength(24)]
    [MaxLength(24)]
    public required IReadOnlyList<string> RichMediaImageUrl { get; init; }

    /// <summary>
    /// Display title for the 360-spin image.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("richMedia360SpinTitle")]
    public string? RichMedia360SpinTitle { get; init; }

    /// <summary>
    /// Operation type. Allowed values: <c>Delink</c> and <c>null</c>(empty). Set to <c>Delink</c> to remove the GTIN association from this asset. Set to <c>null</c> (empty) for create/edit operations.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("mediaOperations")]
    public MediaOperations? MediaOperations { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
