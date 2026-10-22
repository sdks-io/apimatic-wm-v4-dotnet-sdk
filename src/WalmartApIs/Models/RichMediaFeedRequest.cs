using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// Request body for creating, updating, or delinking rich media assets.
/// </summary>
public record RichMediaFeedRequest
{
    /// <summary>
    /// Metadata header for the rich media feed.
    /// </summary>
    [JsonPropertyName("SupplierItemFeedHeader")]
    public required SupplierItemFeedHeader SupplierItemFeedHeader { get; init; }

    /// <summary>
    /// One or multiple rich media asset details and associated items.
    /// </summary>
    [JsonPropertyName("SupplierItem")]
    [MinLength(1)]
    public required IReadOnlyList<SupplierItemPayload> SupplierItem { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
