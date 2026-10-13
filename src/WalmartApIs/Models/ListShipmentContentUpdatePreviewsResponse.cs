using System.Collections.Generic;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// The <c>listShipmentContentUpdatePreviews</c> response.
/// </summary>
public record ListShipmentContentUpdatePreviewsResponse
{
    /// <summary>
    /// A list of content update previews in a shipment.
    /// </summary>
    [JsonPropertyName("contentUpdatePreviews")]
    public required IReadOnlyList<CommonContentUpdatePreview> ContentUpdatePreviews { get; init; }

    /// <summary>
    /// Contains tokens to fetch from a certain page.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("pagination")]
    public CommonPagination? Pagination { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
