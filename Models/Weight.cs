using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;
using WalmartApIs.Models.Enums;

namespace WalmartApIs.Models;

public record Weight
{
    [JsonPropertyName("value")]
    public required double Value { get; init; }

    [JsonPropertyName("unit")]
    public required Unit1 Unit { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
