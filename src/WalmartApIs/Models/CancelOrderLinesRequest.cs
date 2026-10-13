using System.Collections.Generic;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

public record CancelOrderLinesRequest
{
    [JsonPropertyName("orderLines")]
    public required IReadOnlyList<CancelOrderLine> OrderLines { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
