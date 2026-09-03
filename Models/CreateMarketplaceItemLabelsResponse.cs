using System.Collections.Generic;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// The <c>createMarketplaceItemLabels</c> response.
/// </summary>
public record CreateMarketplaceItemLabelsResponse
{
    /// <summary>
    /// Resources to download the requested document.
    /// </summary>
    [JsonPropertyName("documentDownloads")]
    public required IReadOnlyList<CommonDocumentDownload> DocumentDownloads { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
