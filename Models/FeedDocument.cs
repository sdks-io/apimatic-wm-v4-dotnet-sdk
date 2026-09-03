using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;
using WalmartApIs.Core.Validation;
using WalmartApIs.Core.Validation.Attributes;
using WalmartApIs.Models.Enums;

namespace WalmartApIs.Models;

public record FeedDocument
{
    /// <summary>
    /// Unique identifier for this feed result document
    /// </summary>
    [JsonPropertyName("feedDocumentId")]
    public required string FeedDocumentId { get; init; }

    /// <summary>
    /// Pre-signed URL to download the document (valid 15 minutes) — do not log
    /// </summary>
    [JsonPropertyName("url")]
    [Format(FormatKind.Uri)]
    public required string Url { get; init; }

    /// <summary>
    /// Compression applied to the document; decompress before parsing if present
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("compressionAlgorithm")]
    public CompressionAlgorithm? CompressionAlgorithm { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
