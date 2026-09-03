using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;
using WalmartApIs.Core.Validation;
using WalmartApIs.Core.Validation.Attributes;
using WalmartApIs.Models.Enums;

namespace WalmartApIs.Models;

public record ReportDocument
{
    [JsonPropertyName("reportDocumentId")]
    public required string ReportDocumentId { get; init; }

    /// <summary>
    /// Pre-signed URL to download the report — do not log
    /// </summary>
    [JsonPropertyName("url")]
    [Format(FormatKind.Uri)]
    public required string Url { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("compressionAlgorithm")]
    public CompressionAlgorithm? CompressionAlgorithm { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
