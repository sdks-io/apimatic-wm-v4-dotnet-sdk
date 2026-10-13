using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// The <c>getDeliveryChallanDocument</c> response.
/// </summary>
public record GetDeliveryChallanDocumentResponse
{
    /// <summary>
    /// Resource to download the requested document.
    /// </summary>
    [JsonPropertyName("documentDownload")]
    public required CommonDocumentDownload DocumentDownload { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
