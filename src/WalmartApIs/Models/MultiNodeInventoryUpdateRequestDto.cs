using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

public record MultiNodeInventoryUpdateRequestDto
{
    [JsonPropertyName("inventories")]
    public required UpdateInventoriesRequestDto Inventories { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
