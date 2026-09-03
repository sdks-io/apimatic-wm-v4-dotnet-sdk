using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

public record AcknowledgeOrderLine
{
    [JsonPropertyName("lineNumber")]
    public required string LineNumber { get; init; }

    [JsonPropertyName("statusCode")]
    public string StatusCode { get; } = "Acknowledged";

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("statusQuantity")]
    public QuantityWithUnit? StatusQuantity { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
