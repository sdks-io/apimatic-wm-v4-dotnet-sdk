using System.Collections.Generic;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

public record ListingsItemPatchRequest
{
    [JsonPropertyName("productType")]
    public required string ProductType { get; init; }

    [JsonPropertyName("patches")]
    public required IReadOnlyList<PatchOperation> Patches { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
