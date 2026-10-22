using System.Collections.Generic;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;
using WalmartApIs.Models.Enums;
using WalmartApIs.Models.OneOf;

namespace WalmartApIs.Models;

public record RichMediaAssetPayload
{
    /// <summary>
    /// SHA-1 hash that uniquely identifies this rich media asset.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("hash")]
    public string? Hash { get; init; }

    /// <summary>
    /// Display title for the rich media asset.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("mediaTitle")]
    public string? MediaTitle { get; init; }

    /// <summary>
    /// Type of rich media asset. Determines the structure of the <c>richMediaAsset</c> object.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("mediaType")]
    public MediaType? MediaType { get; init; }

    /// <summary>
    /// Originating source of the rich media asset. Possible values: <c>MARKETPLACE_PARTNER</c>, <c>SELLER_API</c>
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("source")]
    public Source? Source { get; init; }

    /// <summary>
    /// List of items associated with this rich media asset.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("items")]
    public IReadOnlyList<AssociatedItemPayload>? Items { get; init; }

    /// <summary>
    /// Asset content details. Structure varies by <c>mediaType</c>: <c>VIDEO</c> assets contain video URL, optional closed captions, category, and thumbnail; <c>IMAGES360</c> assets contain an ordered array of image frame URLs.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("richMediaAsset")]
    public RichMediaAssetDetail? RichMediaAsset { get; init; }

    /// <summary>
    /// Timestamp when the asset was first created, in epoch milliseconds.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("addedDtm")]
    public string? AddedDtm { get; init; }

    /// <summary>
    /// Timestamp when the asset record was last updated, in epoch milliseconds.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("updatedDtm")]
    public string? UpdatedDtm { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
