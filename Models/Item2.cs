using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;
using WalmartApIs.Core.Validation.Attributes;

namespace WalmartApIs.Models;

public record Item2
{
    [JsonPropertyName("orderItemId")]
    public required string OrderItemId { get; init; }

    [JsonPropertyName("quantity")]
    [Minimum(1)]
    public required int Quantity { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
