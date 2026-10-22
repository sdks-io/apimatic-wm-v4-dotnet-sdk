using System.Collections.Generic;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

public record UpdateInventoriesRequestDto
{
    [JsonPropertyName("nodes")]
    public required IReadOnlyList<UpdateInventoriesRequestNodeDto> Nodes { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
