using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// The <c>generateShipmentContentUpdatePreviews</c> request.
/// </summary>
public record GenerateShipmentContentUpdatePreviewsRequest
{
    /// <summary>
    /// A list of boxes that will be present in the shipment after the update.
    /// </summary>
    [JsonPropertyName("boxes")]
    [MinLength(1)]
    [MaxLength(5000)]
    public required IReadOnlyList<CommonBoxUpdateInput> Boxes { get; init; }

    /// <summary>
    /// A list of all items that will be present in the shipment after the update.
    /// </summary>
    [JsonPropertyName("items")]
    [MinLength(1)]
    [MaxLength(2000)]
    public required IReadOnlyList<CommonItemInput> Items { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
