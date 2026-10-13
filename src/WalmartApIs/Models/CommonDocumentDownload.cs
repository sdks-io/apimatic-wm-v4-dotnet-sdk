using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// Resource to download the requested document.
/// </summary>
public record CommonDocumentDownload
{
    /// <summary>
    /// The type of download. Possible values: <c>URL</c>.
    /// </summary>
    [JsonPropertyName("downloadType")]
    public required string DownloadType { get; init; }

    /// <summary>
    /// The URI's expiration time. In ISO 8601 datetime format with pattern <c>yyyy-MM-ddTHH:mm:ss.sssZ</c>.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("expiration")]
    public DateTimeOffset? Expiration { get; init; }

    /// <summary>
    /// Uniform resource identifier to identify where the document is located.
    /// </summary>
    [JsonPropertyName("uri")]
    public required string Uri { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
