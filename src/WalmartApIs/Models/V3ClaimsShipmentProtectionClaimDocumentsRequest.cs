using System.Collections.Generic;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

public record V3ClaimsShipmentProtectionClaimDocumentsRequest
{
    /// <summary>
    /// Array of document IDs to download
    /// </summary>
    [JsonPropertyName("documentIds")]
    public required IReadOnlyList<string> DocumentIds { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
