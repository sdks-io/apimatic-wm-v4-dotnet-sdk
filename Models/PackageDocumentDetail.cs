using System.Collections.Generic;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

public record PackageDocumentDetail
{
    [JsonPropertyName("packageClientReferenceId")]
    public required string PackageClientReferenceId { get; init; }

    [JsonPropertyName("packageDocuments")]
    public required IReadOnlyList<PackageDocument> PackageDocuments { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("trackingId")]
    public string? TrackingId { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
