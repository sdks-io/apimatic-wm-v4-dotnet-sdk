using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

public record BulkUpdateInventoryRequest
{
    [JsonPropertyName("items")]
    [MinLength(1)]
    [MaxLength(500)]
    public required IReadOnlyList<BulkInventoryItem> Items { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
