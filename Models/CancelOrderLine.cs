using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;
using WalmartApIs.Models.Enums;

namespace WalmartApIs.Models;

public record CancelOrderLine
{
    [JsonPropertyName("lineNumber")]
    public required string LineNumber { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("cancelQuantity")]
    public QuantityWithUnit? CancelQuantity { get; init; }

    [JsonPropertyName("cancellationReason")]
    public required CancellationReason CancellationReason { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
