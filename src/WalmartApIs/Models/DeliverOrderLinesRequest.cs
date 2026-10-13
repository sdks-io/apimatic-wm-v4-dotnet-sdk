using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

public record DeliverOrderLinesRequest
{
    [JsonPropertyName("orderLines")]
    [MinLength(1)]
    public required IReadOnlyList<DeliverOrderLine> OrderLines { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
