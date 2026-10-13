using System.Collections.Generic;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

public record AcknowledgeOrderRequest
{
    [JsonPropertyName("orderLines")]
    public required IReadOnlyList<AcknowledgeOrderLine> OrderLines { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
